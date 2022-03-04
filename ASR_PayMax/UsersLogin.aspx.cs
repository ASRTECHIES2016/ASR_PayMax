using ASR_PayMax.GlobalProjectClass;
using ASR_PayMaxLogic.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ASR_PayMax
{
    public partial class UsersLogin : System.Web.UI.Page
    {
        ASR_PayMaxParameters _Parameters;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            txtusername.Focus();
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            ASR_PayMaxParameters _Common = _Parameters;//.(_GetMasters.strUserName, _GetMasters.strUserType, txtPassword.Text, true, ConfigurationManager.AppSettings["PasswordHashKey"], ConfigurationManager.AppSettings["LoginIdHashKey"], WebConnectionString.getConnction("Admin"), ConfigurationManager.AppSettings["SQLHashKey"]);
            try
            {
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_CompanyID = "1",
                    Str_App_ID = "1",
                    Str_LoginName = txtusername.Value.Trim(),
                    Str_Password = txtpassword.Value.Trim(),
                    
                   
                };
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/CheckUser";
                HttpContent inputContent = new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, inputContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    _Parameters = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters>(response.Content.ReadAsStringAsync().Result);
                    if (_Parameters.Str_Status != null)
                    {
                        if (_Parameters.Str_Status== "Success")
                        {
                            _Parameters.Str_SessionTimeOut = "20";
                            UsersSession.SetSession(_Parameters);
                            //Response.Redirect("~/PayMaxDashboard.aspx", false);
                            FormsAuthentication.RedirectFromLoginPage(txtusername.Value.Trim(), chkRememberMe.Checked);
							
						} 
                        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
						
						ClearBox();
                    }
                    else
                    {
                      
                        _Parameters.Str_Result = "Invalid User Name and/or Password ";
                        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                        lblmsg.Text = _Parameters.Str_Result;
                    }
                }
            }
            catch (Exception _Exception)
            {
                UsersSession.GetMessages(this,  "Failure", _Exception.InnerException.InnerException.Message+" , "+ _Exception.InnerException.Message.ToString());               
            }

        }



        private void ClearBox()
        {
            txtpassword.Value = "0";
            txtusername.Value = string.Empty;
            Btn_Submit.Text = "Submit";
            BindData();
        }



        private void BindData()
        {
            //HttpResponseMessage response;
            //try
            //{
            //    var UserDetails = UsersSession.GetSession();
            //    _Parameters = new ASR_PayMaxParameters();
            //    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
            //    _Parameters.Str_SelectID = "52";
            //    _Parameters.Str_LoginID = UserDetails.Str_LoginID;

            //    _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignationGroup";

            //    response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json")).Result;

            //    if (response.IsSuccessStatusCode)
            //    {
            //        ASR_PayMaxParameters[] arr = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters[]>(response.Content.ReadAsStringAsync().Result);
            //        if (arr[0].Str_Status == "Get")
            //        {
            //            ddlDesignationGroupID.DataSource = arr;
            //            ddlDesignationGroupID.DataTextField = "Str_GlobalName";
            //            ddlDesignationGroupID.DataValueField = "Str_GlobalID";
            //            ddlDesignationGroupID.DataBind();
            //            ddlDesignationGroupID.Items.Insert(0, "Select One");
            //        }
            //        else
            //        {
            //            UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
            //        }
            //    }
            //    else
            //    {
            //        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
            //    }

            //    _Parameters.Str_SelectID = "51";
            //    _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignationCategory";
            //    response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json")).Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        ASR_PayMaxParameters[] arr = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters[]>(response.Content.ReadAsStringAsync().Result);
            //        if (arr[0].Str_Status == "Get")
            //        {
            //            ddlDesignationCategoryID.DataSource = arr;
            //            ddlDesignationCategoryID.DataTextField = "Str_GlobalName";
            //            ddlDesignationCategoryID.DataValueField = "Str_GlobalID";
            //            ddlDesignationCategoryID.DataBind();
            //            ddlDesignationCategoryID.Items.Insert(0, "Select One");
            //        }
            //        else
            //        {
            //            UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
            //        }
            //    }
            //    else
            //    {
            //        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
            //    }
            //    _Parameters.Str_SelectID = "53";
            //    _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetDesignation";
            //    response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json")).Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        ASR_PayMaxParameters[] arr = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters[]>(response.Content.ReadAsStringAsync().Result);
            //        if (arr[0].Str_Status == "Get")
            //        {
            //            GridDesignation.DataSource = arr;
            //            GridDesignation.DataBind();
            //        }
            //        else
            //        {
            //            UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
            //        }
            //    }
            //    else
            //    {
            //        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            //}
        }

    }
}