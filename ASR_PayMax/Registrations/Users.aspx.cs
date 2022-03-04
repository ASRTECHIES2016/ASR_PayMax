using System.Web.UI;
using ASR_PayMaxLogic.Models;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using ASR_PayMax.GlobalProjectClass;
using System.Configuration;
using System;
using System.Web.Security;

namespace ASR_PayMax.Registrations
{
    public partial class Users : System.Web.UI.Page
    {
        ASR_PayMaxParameters _Parameters;
        ASR_Common _Common;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearBox();
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            string Mode = "Add";
            if (txtFirstName.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter First Name.');", true);
                return;
            }
            if (ddlRole.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Role Name');", true);
                return;
            }
            if (ddlDesignation.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Designation');", true);
                return;
            }
            if (txtUserName.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter User Name.');", true);
                return;
            }
            if (txtPassword.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter Password');", true);
                return;
            }
            try
            {
                //FormsAuthentication.HashPasswordForStoringInConfigFile(_Parameters.Str_Password, "SHA1");
               //use Membership
                
                var UserDetails = UsersSession.GetSession();
                if (hddUserID.Value != "0")
                {
                    Mode = "Edit";
                }
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_GlobalID = hddUserID.Value,
                    Str_DesignationID = ddlDesignation.SelectedValue,
                    Str_RoleID = ddlDesignation.SelectedValue,
                    Str_FirstName = txtFirstName.Text.Trim(),
                    Str_MiddleName = txtMiddleName.Text.Trim(),
                    Str_LastName = txtLastName.Text.Trim(),
                    Str_EmailID = txtEmail.Text.Trim(),
                    Str_ContactNoOne = txtContactNo.Text,
                    Str_LocalAddress=txtAddress.Text.Trim(),
                    Str_LoginName=txtUserName.Text.Trim(),
                    Str_Password=txtPassword.Text.Trim(),
                    Str_UserType = RadioBilling.SelectedValue,
                    Str_Gender = RadioGender.SelectedValue,                    
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };

                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMaxMaster/MsLoginUserMaster";
                HttpContent inputContent = new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, inputContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    _Parameters = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters>(response.Content.ReadAsStringAsync().Result);
                    if (_Parameters.Str_Status != null)
                    {
                        if (_Parameters.Str_Status == "Success")
                        {
                            UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                            ClearBox();
                        }
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
            hddUserID.Value = "0";
            //   txtDesignation.Text = string.Empty;
            Btn_Submit.Text = "Submit";
			txtFirstName.Text = string.Empty;
			txtMiddleName.Text = string.Empty;
			txtLastName.Text = string.Empty;
			RadioGender.SelectedIndex = 0;
			txtEmail.Text = string.Empty;
			txtContactNo.Text = string.Empty;
			txtAddress.Text = string.Empty;
			txtUserName.Text = string.Empty;
			txtPassword.Text = string.Empty;
			txtConPassword.Text = string.Empty;
			BindData();
            txtFirstName.Focus();
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

                _Parameters.Str_SelectID = "47";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignation";
                _Common.BindDropDown(this, ddlDesignation, _Parameters);
                _Parameters.Str_SelectID = "47";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignation";
                _Common.BindDropDown(this, ddlRole, _Parameters);
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }
    }
}