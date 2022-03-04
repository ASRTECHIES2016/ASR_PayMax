using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASR_PayMaxLogic.Models;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using ASR_PayMax.GlobalProjectClass;
using System.Configuration;
using System.Data;

namespace ASR_PayMax.Masters
{
    public partial class BankBranch : System.Web.UI.Page
    {
        ASR_PayMaxParameters _Parameters;
        ASR_Common _Common;
        
        DataSet _DataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
    //        Btn_Submit.Enabled = false;
            if (!IsPostBack)
            {
                ClearBox();
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            string Mode = "Add";
            if (ddlBank.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Sorry');", true);
                return;
            }
            if (txtBranchName.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Branch Name");
                return;
            }
            if (txtIFSC_Code.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter IFSC Code");
                return;
            }
            var UserDetails = UsersSession.GetSession();
            if (hddBankBranchID.Value != "0")
            {
                Mode = "Edit";
            }
            _Parameters = new ASR_PayMaxParameters
            {
                Str_Mode = Mode,
                Str_CompanyID = UserDetails.Str_CompanyID,
                Str_SelectID = "12",
                Str_GlobalID = hddBankBranchID.Value,
                Str_GlobalCode = txtIFSC_Code.Text,
                Str_GlobalName = txtBranchName.Text,
                Str_ParentID = ddlBank.SelectedValue,
                Bool_IsActive = true,
                Str_LoginID = UserDetails.Str_LoginID
            };
            _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsBankBranch";

            try
            {
              
                HttpContent inputContent = new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, inputContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    _Parameters = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters>(response.Content.ReadAsStringAsync().Result);
                    if (_Parameters != null)
                    {
                        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                        ClearBox();
                    }
                    else
                    {
                        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                    }
                }
                else
                {
                    UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
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

        private void ClearBox()
        {
            hddBankBranchID.Value = "0";
            txtBranchName.Text = string.Empty;
            txtIFSC_Code.Text = string.Empty;
            Btn_Submit.Text = "Submit";
            BindData();
        }

        protected void GridBankBranch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);

                Label lblBankID = GridBankBranch.Rows[RowIndex].Cells[0].FindControl("lblBankID") as Label;
                Label lblBankBranchID = GridBankBranch.Rows[RowIndex].Cells[0].FindControl("lblBankBranchID") as Label;
                Label lblIFSCode = GridBankBranch.Rows[RowIndex].Cells[0].FindControl("lblIFSCode") as Label;
                Label lblBranchName = GridBankBranch.Rows[RowIndex].Cells[0].FindControl("lblBranchName") as Label;

                if (e.CommandName == "Change")
                {
                    hddBankBranchID.Value = lblBankBranchID.Text;
                    txtBranchName.Text = lblBranchName.Text;
                    txtIFSC_Code.Text = lblIFSCode.Text;
                    Btn_Submit.Text = "Update";
                    ddlBank.SelectedValue = lblBankID.Text;
                }
                if (e.CommandName == "Deleted")
                {
                    var UserDetails = UsersSession.GetSession();
                    _Parameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_SelectID = "12";
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_GlobalID = lblBankBranchID.Text;
                    _Parameters.Str_Mode = "Delete";
                    _Parameters = _Common.ModifiedData(_Parameters);
                    if (_Parameters != null)
                    {
                        ClearBox();
                        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                    }
                    else
                    {
                        //   UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                    }
                }
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
                CheckBox grdCheckBox = (CheckBox)GridBankBranch.Rows[Row.RowIndex].FindControl("IsActive");
                Label lblBankBranchID = GridBankBranch.Rows[Row.RowIndex].Cells[0].FindControl("lblBankBranchID") as Label;

                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "12";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_GlobalID = lblBankBranchID.Text;
                _Parameters.Str_Mode = "Active";
                _Parameters.Bool_IsActive = chk.Checked;
                _Parameters = _Common.ModifiedData(_Parameters);
                if (_Parameters != null)
                {
                    UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                    ClearBox();
                }
                else{ UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                }
            }
            catch (Exception _Exception)
            {
                UsersSession.GetMessages(this, "Failure", _Exception.Message.ToString());
            }


        }

        private void BindData()
        {
            HttpResponseMessage response;
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_SelectID = "13";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBank";
                _Common.BindDropDown(this, ddlBank, _Parameters);
                _Parameters.Str_SelectID = "12";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstBankBranch";
                _Common.BindGrid(this, GridBankBranch, _Parameters);
            }   
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

    }
}