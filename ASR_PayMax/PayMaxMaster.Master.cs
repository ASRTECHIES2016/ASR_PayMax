//using ASR_CommonLogic.Models;
using ASR_PayMax.GlobalProjectClass;
using ASR_PayMaxLogic.Models;
using System;
using System.IO;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace ASR_PayMax
{
    public partial class PayMaxMaster : System.Web.UI.MasterPage
    {
        ASR_PayMaxParameters _Parameters;
        static string Str_ServerPath = HttpContext.Current.Request.IsSecureConnection ? HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + "/UserDocument/" : HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/UserDocument/";

        protected void Page_Load(object sender, EventArgs e)
        {
            var UserDetails = UsersSession.GetSession();
            if (UserDetails == null)
            {
                Response.Redirect("~/UsersLogin.aspx", false);
            }
            
            lblLoggedUserName1.Text ="Welcome " + UserDetails.Str_UserName;
            lblWorkingSince.Text = "Date Of Join " + UserDetails.Str_DateOfJoin;
            lblStatus.Text = "Online";
            BindMenus();
        }
        public void BindMenus()
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Parameters = new ASR_PayMaxParameters();
                
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "152";
                _Parameters.Str_GlobalID = "133";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;

                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetSidebarMenu";

                HttpContent inputContent = new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, inputContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    string _Data = new JavaScriptSerializer().Deserialize<string>(response.Content.ReadAsStringAsync().Result);
                    if (!_Data.Contains("Failure"))
                    {
                        SidebarMenuID.InnerHtml = "<li class='nav-item'><input type='text' onkeyup='myFunction()' id='SidebarMenuIDSearch' class='form-control' placeholder='Search Menu Name Here'></li>" + _Data;
                        if (HttpContext.Current.Request.Path.Contains("PayMaxDashboard"))
                        {
                            Masterbreadcrumb.InnerHtml = "<li><a href='#'><i class='fa fa-dashboard'></i>Dashboard</a></li>";
                        }
                        else
                        {
                            Masterbreadcrumb.InnerHtml = "<li><a href='" + HttpContext.Current.Request.Path + "'><i class='fa fa-dashboard'></i>" + HttpContext.Current.Request.Path.Replace("/", " > ").Split('.')[0].Remove(0, 2) + "</a></li>";
                        }

                    }
                    else
                    { }
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UsersLogin.aspx");
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registrations/ChangePassword.aspx");
        }
    }
}