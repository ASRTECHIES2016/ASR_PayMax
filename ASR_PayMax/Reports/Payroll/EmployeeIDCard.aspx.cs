using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASR_PayMaxLogic.Models;
using ASR_PayMax.GlobalProjectClass;
using System.Data;
using System.Configuration;
using System.IO;

namespace ASR_PayMax.Reports.Payroll
{
    public partial class EmployeeIDCard : System.Web.UI.Page
    {
        GeneratePdf_Report _GeneratePdf;
        //GeneratePdf_Report _Report;
        SiteMasterParameters _PayMaxParameters;
        ASR_Common _Common;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearBox();
            }
        }

        private void ClearBox()
        {
            BindData();
        }

        private void BindData()
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                _PayMaxParameters = new SiteMasterParameters();
                _PayMaxParameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _PayMaxParameters.Str_LoginID = UserDetails.Str_LoginID;
                _PayMaxParameters.Str_SelectID = "22";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlBranch, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "24";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetClientGroup";
                _Common.BindDropDown(this, ddlClient, _PayMaxParameters);
                ddlSite.Items.Insert(0, "Select One");
            }
            catch (Exception _Exception)
            {
                UsersSession.GetMessages(this, "Failure", _Exception.Message.ToString());
            }
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlClient.SelectedIndex > 0)
                {
                    ddlSite.Items.Clear();
                    var UserDetails = UsersSession.GetSession();
                    _Common = new ASR_Common();
                    _PayMaxParameters = new SiteMasterParameters();
                    _PayMaxParameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _PayMaxParameters.Str_LoginID = UserDetails.Str_LoginID;
                    _PayMaxParameters.Str_SelectID = "120";
                    //       _PayMaxParameters.Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue;
                    _PayMaxParameters.Str_ParentID = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue;
                    //       _PayMaxParameters.Str_PayMaxParametersID = ddlSite.SelectedValue == "Select One" ? "0" : ddlSite.SelectedValue;
                    _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetSiteMaster";
                    _Common.BindDropDown(this, ddlSite, _PayMaxParameters);

                }
                else
                {
                    ddlClient.SelectedIndex = 0;
                    ddlSite.SelectedIndex = 0;
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }



        }

        protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (ddlSite.SelectedIndex > 0)
                {
                    var UserDetails = UsersSession.GetSession();
                    _Common = new ASR_Common();
                    _PayMaxParameters = new SiteMasterParameters();
                    _PayMaxParameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _PayMaxParameters.Str_LoginID = UserDetails.Str_LoginID;
                    _PayMaxParameters.Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue;
                    _PayMaxParameters.Str_ClientID = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue;
                    _PayMaxParameters.Str_SiteMasterID = ddlSite.SelectedValue == "Select One" ? "0" : ddlSite.SelectedValue;
                    //      _PayMaxParameters.Str_MonthID = ddlMonth.SelectedValue == "Select One" ? "0" : ddlMonth.SelectedValue;
                    //      _PayMaxParameters.Str_YearID = ddlYear.SelectedValue == "Select One" ? "0" : ddlYear.SelectedValue;
                    _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstSiteWiseEmployees";
                }
                else
                {
                    ddlSite.SelectedIndex = 0;
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }

        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {


                if (ddlBranch.SelectedIndex == 0)
                {
                    UsersSession.GetMessages(this, "Warning", "Please Select Branch Name");
                    return;
                }
                //if (ddlClient.SelectedIndex == 0)
                //{
                //    UsersSession.GetMessages(this, "warning", "please select client name");
                //    return;
                //}
                //if (ddlSite.SelectedIndex == 0)
                //{
                //    UsersSession.GetMessages(this, "warning", "please select site name");
                //    return;
                //}

                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();

                _PayMaxParameters = new SiteMasterParameters
                {
                    // Str_Mode = "Wage Register", //ddlReportType.SelectedValue,
                    Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue,
                    Str_ClientID = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue,
                    Str_SiteMasterID = ddlSite.SelectedValue == "Select One" ? "0" : ddlSite.SelectedValue,
                    Str_TransactionDate = txtDate.Text == "" ? "" : txtDate.Text.Split('/')[0], //txtDate.Text.Split('-')[0],
                    Str_PaySheetNo = "0",
                    Str_EmployeeType = "FRONT",
                    Str_LoginID = UserDetails.Str_LoginID,
                    Str_UserName=UserDetails.Str_UserName
                    
                };
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/Report/GenerateEmployeeIDCard";

                _PayMaxParameters._DataSet = _Common._ReturnDataSet(_PayMaxParameters);





                _PayMaxParameters.Str_LocalFilePathOne = Path.Combine(Server.MapPath("~/ReportFiles/"));
                if (!Directory.Exists(_PayMaxParameters.Str_LocalFilePathOne))
                {
                    Directory.CreateDirectory(_PayMaxParameters.Str_LocalFilePathOne);
                }
                _PayMaxParameters.Str_ServerFilePathOne = HttpContext.Current.Request.IsSecureConnection ?
                    Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + "/ReportFiles/" :
                    Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + ":" + Request.Url.Port + "/ReportFiles/";

                _GeneratePdf = new GeneratePdf_Report();
                _GeneratePdf.Str_PageName = "A4";
                _GeneratePdf.Str_Narration = _PayMaxParameters.Str_UserName + '_' + DateTime.Now.Day + '_' + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Millisecond.ToString() + ".pdf";

                //  _GeneratePdf.GenerateWiseRegister(_GeneratePdf, _PayMaxParameters._DataSet, _PayMaxParameters.Str_LocalFilePathOne, _GeneratePdf.Str_Narration, "");
                _GeneratePdf.GenerateWiseRegister(_GeneratePdf, _PayMaxParameters);//._DataSet, _PayMaxParameters.Str_LocalFilePathOne, _GeneratePdf.Str_Narration, "");
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + _PayMaxParameters.Str_ServerFilePathOne + _GeneratePdf.Str_Narration + "','_blank');", true);
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }

        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}