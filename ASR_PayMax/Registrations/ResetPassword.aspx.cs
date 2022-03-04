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
    public partial class ResetPassword1 : System.Web.UI.Page
    {
        ASR_PayMaxParameters _Parameters;
        ASR_Common _Common;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUserName.Focus();
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            ASR_PayMaxParameters _Common = _Parameters;

            if (txtUserName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter User Name.');", true);
                return;
            }

            try
            {
                var UserDetails = UsersSession.GetSession();
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_CompanyID = "1",
                    Str_App_ID = "1",
                    Str_UserName = txtUserName.Text,
                };
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/ResetPassword";
                HttpContent inputContent = new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, inputContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    _Parameters = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters>(response.Content.ReadAsStringAsync().Result);
                    if (_Parameters.Str_Status != null)
                    {
                        if (_Parameters.Str_Status == "Success")
                        {
                            
                            if (_Parameters.Bool_Variables)
                            {
                                SendPasswordResetEmail(_Parameters.Str_EmailID, _Parameters.Str_UserName, _Parameters.Str_UnitID);
                                _Parameters.Str_Result = "An email with reset instructions to reset your passwors is sent to emial";

                            }
                            else
                            {
                                _Parameters.Str_Result = "UserName Not Found";

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

            Response.Redirect("~/UsersLogin.aspx");
        }


        private void SendPasswordResetEmail(string ToEmail, string UserName, string UniqueId)
        {
            
            
                MailMessage MailMessage = new MailMessage("asrtechie@gmail.com", ToEmail);
                StringBuilder sbEmailBody = new StringBuilder();

                sbEmailBody.Append("Dear " + UserName + ",<br/><br/>");
                sbEmailBody.Append("Please Click On The Following Link To Reset Your Password");
                sbEmailBody.Append("<br/>");
                sbEmailBody.Append("http://localhost:52737/Registrations/ChangePassword.aspx?uid=" + UniqueId);
                sbEmailBody.Append("<br/><br/>");
                sbEmailBody.Append("Team ASRTEHIES");

                MailMessage.IsBodyHtml = true;

                MailMessage.Body = sbEmailBody.ToString();
                MailMessage.Subject = "Reset Your Password";
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = "asrtechie@gmail.com",
                    Password = "Login@2016"

                };

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Send(MailMessage);
            


        }


        private void ClearBox()
        {
            txtUserName.Text = string.Empty;
            txtUserName.Focus();

            
        }

        


    }
}