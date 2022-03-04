using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASR_PayMaxLogic.Models;
using ASR_PayMax.GlobalProjectClass;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Text;

namespace ASR_PayMax.Masters
{
    public partial class Clients : System.Web.UI.Page
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
            hddClientID.Value = "0";
            Btn_Submit.Text = "Submit";
            //txtClientCode.Text = string.Empty;
            txtClientName.Text = string.Empty;
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
                _Parameters.Str_SelectID = "22";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlBranch, _Parameters);
                //var UserDetails = UsersSession.GetSession();
                //_Common = new ASR_Common();
                //_Parameters = new ASR_PayMaxParameters();
                //_Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                //_Parameters.Str_LoginID = UserDetails.Str_LoginID;
                ////_Parameters.Str_SelectID = "13";
                ////_Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                ////_Common.BindDropDown(this, ddlOffice, _Parameters);
                ////_Parameters.Str_SelectID = "107";
                ////_Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetRateApplicable";
                ////_Common.BindDropDown(this, ddlRateAplicable, _Parameters);
                //_Parameters.Str_SelectID = "24";
                //_Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstClient";
                //_Common.BindGrid(this, GridClientDetails, _Parameters);
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            string Mode = "Add";
            if (txtClientName.Text.Trim() == "" )
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Client Name Can Not Be Blanck');", true);
                return;
            }

            if (!Regex.Match(txtClientName.Text, @"[a-zA-Z]+").Success)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Client Name in Character Only');", true);
                return;
            }
            //if (ddlRateAplicable.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Rate Aplicable Type');", true);
            //    return;
            //}
            try
            {
                var UserDetails = UsersSession.GetSession();
                if (hddClientID.Value != "0")
                {
                    Mode = "Edit";
                }
                _Common = new ASR_Common();
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SelectID = "24",
                    Str_ClientGroupID = hddClientID.Value,
                    //Str_ClientGroupCode = txtClientCode.Text,
                    Str_ClientGroupName = txtClientName.Text.Trim(),
                    Str_OfficeType = ddlOffice.SelectedValue == "Select One" ? "0" : ddlOffice.SelectedValue,
                    Str_RateApplicableID = RadioRateAplicable.SelectedValue,
                    Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue,
                    Bool_IsAdminChargesApplicable = true,
                    Str_Remarks = txtRemarks.Text.Trim(),
                    Bool_IsActive = true,
                    Str_LoginID = "1"
                };

                //_Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsClientGroup";
                //HttpContent inputContent = new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json");
                //HttpResponseMessage response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, inputContent).Result;

                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsClientGroup";
                if (_Common.IUMasters(this, _Parameters))
                {
                    ClearBox();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearBox();
        }

        protected void GridClientGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);

                Label lblClientID = GridClientDetails.Rows[RowIndex].Cells[0].FindControl("lblClientID") as Label;
                Label lblClientCode = GridClientDetails.Rows[RowIndex].Cells[0].FindControl("lblClientCode") as Label;
                Label lblClientName = GridClientDetails.Rows[RowIndex].Cells[0].FindControl("lblClientName") as Label;
                Label lblOfficeType = GridClientDetails.Rows[RowIndex].Cells[0].FindControl("lblOfficeType") as Label;
                Label lblRateApplicableID = GridClientDetails.Rows[RowIndex].Cells[0].FindControl("lblRateApplicableID") as Label;

                if (e.CommandName == "Change")
                {
                    hddClientID.Value = lblClientID.Text;
                    //txtClientCode.Text = lblClientCode.Text;
                    txtClientName.Text = lblClientName.Text;
                    ddlOffice.SelectedValue = lblOfficeType.Text;
                    RadioRateAplicable.SelectedValue = lblRateApplicableID.Text;
                    Btn_Submit.Text = "Update";
                }
                if (e.CommandName == "Deleted")
                {
                    var UserDetails = UsersSession.GetSession();
                    _Parameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_SelectID = "24";
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_GlobalID = lblClientID.Text;
                    _Parameters.Str_Mode = "Delete";
                    _Parameters = _Common.ModifiedData(_Parameters);
                    if (_Parameters != null)
                    {
                        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                        ClearBox();
                    }
                    else
                    {
                        //   UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                    }
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Client", "$('#modalClient').modal('hide');", true);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }


        }

        protected void IsActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                CheckBox chk = (CheckBox)sender;
                GridViewRow Row = ((GridViewRow)((Control)sender).Parent.Parent.Parent.Parent);
                Label lblClientID = (Label)GridClientDetails.Rows[Row.RowIndex].Cells[0].FindControl("lblClientID");
                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "24";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_GlobalID = lblClientID.Text;
                _Parameters.Str_Mode = "Active";
                _Parameters.Bool_IsActive = chk.Checked;
                _Parameters = _Common.ModifiedData(_Parameters);
                if (_Parameters != null)
                {
                    UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                    //ClearBox();
                }
                else
                {
                    //   UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }
        }

        protected void Btn_Detail_Click(object sender, EventArgs e)
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                _Parameters = new ASR_PayMaxParameters();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                //_Parameters.Str_SelectID = "13";
                //_Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                //_Common.BindDropDown(this, ddlOffice, _Parameters);
                //_Parameters.Str_SelectID = "107";
                //_Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetRateApplicable";
                //_Common.BindDropDown(this, ddlRateAplicable, _Parameters);
                _Parameters.Str_SelectID = "24";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstClient";
                _Common.BindGrid(this, GridClientDetails, _Parameters);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Client", "$('#modalClient').modal('show');", true);
            }
            catch (Exception _Exception)
            {
                UsersSession.GetMessages(this.Page, "Failure", _Exception.Message.ToString());
            }

        }
    }
}