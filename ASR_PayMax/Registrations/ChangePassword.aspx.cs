using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
using ASR_PayMax.GlobalProjectClass;
using ASR_PayMaxLogic.Models;
using System.Configuration;
using System.Net.Http;
using System.Web.Script.Serialization;


namespace ASR_PayMax.Registrations
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        ASR_PayMaxParameters _Parameters;
        ASR_Common _Common;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();


            if (_Parameters.Str_UnitID == null && _Parameters.Str_UserName == "")
            {
                Response.Redirect("~/UsersLogin.aspx");
            }

            if (!IsPostBack)
            {
                if (_Parameters.Str_UnitID != null)
                {
                    if (!_Parameters.Bool_Variables)
                    {
                        _Parameters.Str_Status = "Password Reset Link has Expiered or invalid";
                    }
                    DivOldPassword.Visible = false;
                }
                else if (_Parameters.Str_UserName != "")
                {
                    DivOldPassword.Visible = true;
                }


            }

        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            ASR_PayMaxParameters _Common = _Parameters;

            if (txtOldPassword.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter Current Password');", true);
                return;
            }

            if (txtNewPassword.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter New Password');", true);
                return;
            }

            if (txtConfirmPassword.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter Confirm New Password');", true);
                return;
            }

            try
            {
                var UserDetails = UsersSession.GetSession();
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_CompanyID = "1",
                    Str_App_ID = "1",
                    Str_Password = txtNewPassword.Text.Trim(),//New Password
                    Str_EmailPassword = txtOldPassword.Text.Trim(),//Current Password
                    Str_FTPPassword = txtConfirmPassword.Text.Trim(),//Confirm New Password
                    Str_UserName = UserDetails.Str_UserName

                };
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/ChangePassword";
                HttpContent inputContent = new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, inputContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    _Parameters = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters>(response.Content.ReadAsStringAsync().Result);
                    if (_Parameters.Str_Status != null)
                    {
                        if (_Parameters.Str_Status == "Success")
                        {
                            //_Parameters.Bool_Variables For IsPasswordResetLinkValid
                            //_Parameters.Bool_IsActive For ChangeUserPassword
                            // _Parameters.Bool_IsAdminChargesApplicable For ChangeUserPasspordUsingCurrentPassword

                            if ((_Parameters.Str_UnitID != null && _Parameters.Bool_IsActive==true) ||
                                 (_Parameters.Str_UserName != "" && _Parameters.Bool_IsAdminChargesApplicable==true))
                            {
                                _Parameters.Str_Result = "Password Change Successfully";
                            }
                            else
                            {
                                if (DivOldPassword.Visible)
                                {
                                    _Parameters.Str_Result = "Invalid Current Password";
                                }
                                else
                                {
                                    _Parameters.Str_Result = "Password Reselt Link has expired or is invalid ";
                                }

                            }

                        }
                        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);

                        ClearBox();
                    }
                    else
                    {
                        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                    }
                }

            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }





        private void ClearBox()
        {
            txtOldPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearBox();

        }

        private void BindData()
        {
            var UserDetails = UsersSession.GetSession();
            _Parameters = new ASR_PayMaxParameters()
            {
                Str_UserName = UserDetails.Str_UserName,
                Str_UnitID = Request.QueryString["uid"]
            };
        }








    }



}