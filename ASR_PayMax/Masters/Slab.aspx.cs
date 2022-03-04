using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASR_PayMaxLogic.Models;
using ASR_PayMax.GlobalProjectClass;
using System.Data;
using System.Configuration;

namespace ASR_PayMax.Masters
{
    public partial class Slab : System.Web.UI.Page
    {
        ASR_PayMaxParameters _Parameters;
        ASR_Common _Common;
        DataSet _DataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearBox();
            }
        }


        private void ClearBox()
        {
            hddSlabID.Value = "0";
            Btn_Submit.Text = "Submit";
            ViewState["Qualification"] = null;
            ViewState["AddressDetail"] = null;
            ViewState["EmergencyContact"] = null;
            BindData();
        }

        private void BindData()
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                _Parameters = new ASR_PayMaxParameters();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_SelectID = "115";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetSalaryHead";
                _Common.BindDropDown(this, ddlSalaryHead, _Parameters);
                _Parameters.Str_SelectID = "140";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetState";
                _Common.BindDropDown(this, ddlState, _Parameters);
                _Parameters.Str_SelectID = "116";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstGunType";
                _Common.BindGrid(this, GridSlab, _Parameters);
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }
        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (ddlState.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select State Name');", true);
                return;
            }
            if (ddlSalaryHead.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Salary Head Name');", true);
                return;
            }
            if (txtAmountFrom.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter From Amount');", true);
                return;
            }
            if (txtAmountTo.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter To Amount');", true);
                return;
            }
            if (txtPeriodFrom.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter From Period');", true);
                return;
            }
            if (txtValue.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter Value');", true);
                return;
            }
            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddSlabID.Value != "0")
                {
                    Mode = "Edit";
                }
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SelectID = "116",
                    Str_SlabID = hddSlabID.Value,
                    Str_StateID = ddlState.SelectedValue == "Select One" ? "0" : ddlState.SelectedValue,
                    Str_SalaryHeadID = ddlSalaryHead.SelectedValue == "Select One" ? "0" : ddlSalaryHead.SelectedValue,
                    Str_AmountFrom = txtAmountFrom.Text.Trim(),
                    Str_AmountTo = txtAmountTo.Text.Trim(),
                    Str_HeadValue = txtValue.Text.Trim(),
                    Str_FromDate = txtPeriodFrom.Text.Trim(),
                    Str_ToDate = txtPeriodTo.Text.Trim(),
                    Str_Remarks = txtRemarks.Text.Trim(),
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _Parameters.Str_ApiUrl =  ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsSlab";
                if (_Common.IUMasters(this, _Parameters))
                {
                    ClearBox();
                }
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearBox();
        }

        protected void IsActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                CheckBox chk = (CheckBox)sender;
                GridViewRow Row = ((GridViewRow)((Control)sender).Parent.Parent.Parent.Parent);
                CheckBox grdCheckBox = (CheckBox)GridSlab.Rows[Row.RowIndex].FindControl("IsActive");
                Label lblSalaryHeadSlabMasterId = (Label)GridSlab.Rows[Row.RowIndex].Cells[0].FindControl("lblSalaryHeadSlabMasterId");

                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "116";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_GlobalID = lblSalaryHeadSlabMasterId.Text;
                _Parameters.Str_Mode = "Active";
                _Parameters.Bool_IsActive = chk.Checked;
                _Parameters = _Common.ModifiedData(_Parameters);
                if (_Parameters.Str_Status != null)
                {
                    UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                    ClearBox();
                }
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        protected void GridSlab_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);

                Label lblRateID = GridSlab.Rows[RowIndex].Cells[0].FindControl("lblRateID") as Label;
                Label lblRateCode = GridSlab.Rows[RowIndex].Cells[0].FindControl("lblRateCode") as Label;
                Label lblRateName = GridSlab.Rows[RowIndex].Cells[0].FindControl("lblRateName") as Label;
                if (e.CommandName == "Change")
                {
                    hddSlabID.Value = lblRateID.Text;
                    // txtRateContractCode.Text = lblRateCode.Text;
                    // txtRateContract.Text = lblRateName.Text;
                    Btn_Submit.Text = "Update";
                }
                if (e.CommandName == "Deleted")
                {
                    var UserDetails = UsersSession.GetSession();
                    _Parameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_SelectID = "116";
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    // _Parameters.Str_GlobalID = lblDesignationID.Text;
                    _Parameters.Str_Mode = "Delete";
                    _Parameters = _Common.ModifiedData(_Parameters);
                    if (_Parameters.Str_Status != null)
                    {
                        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                        ClearBox();
                    }
                }
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }
    }
}