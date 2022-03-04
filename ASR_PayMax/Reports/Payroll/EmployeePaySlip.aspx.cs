using ASR_PayMax.GlobalProjectClass;
using ASR_PayMaxLogic.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASR_PayMax.Reports.Payroll
{
    public partial class EmployeePaySlip : System.Web.UI.Page
    {
        SiteMasterParameters _PayMaxParameters;
        GenerateExcel_Report _GenerateExcel;
        GeneratePdf_Report _GeneratePdf;
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
                //_PayMaxParameters.Str_SelectID = "24";
                //_PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetClientGroup";
                //_Common.BindDropDown(this, ddlClientGroup, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "24";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetClientGroup";
                _Common.BindDropDown(this, ddlClient, _PayMaxParameters);
                ddlSite.Items.Insert(0, "Select One");
                _PayMaxParameters.Str_SelectID = "93";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDuty";
                _Common.BindDropDown(this, ddlMonth, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "91";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDuty";
                _Common.BindDropDown(this, ddlYear, _PayMaxParameters);
            }
            catch (Exception _Exception)
            {
                UsersSession.GetMessages(this, "Failure", _Exception.Message.ToString());
            }
        }


        protected void Btn_Submit_Click(object sender, EventArgs e)
        {

            //_Report = new GeneratePdf_Report();

            if (ddlBranch.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Branch Name");
                return;
            }
            //if (ddlClient.SelectedIndex == 0)
            //{
            //    UsersSession.GetMessages(this, "Warning", "Please Select Client Name");
            //    return;
            //}
            //if (ddlSite.SelectedIndex == 0)
            //{
            //    UsersSession.GetMessages(this, "Warning", "Please Select Site Name");
            //    return;
            //}
            //if (ddlMonth.SelectedIndex == 0)
            //{
            //    UsersSession.GetMessages(this, "Warning", "Please Select Month Name");
            //    return;
            //}
            //if (ddlYear.SelectedIndex == 0)
            //{
            //    UsersSession.GetMessages(this, "Warning", "Please Select Year Name");
            //    return;
            //}
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();

                _PayMaxParameters = new SiteMasterParameters
                {
                    Str_Mode = "Wage Register", //ddlReportType.SelectedValue,
                    Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue,
                    Str_ClientID = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue,
                    Str_SiteMasterID = ddlSite.SelectedValue == "Select One" ? "0" : ddlSite.SelectedValue,
                    Str_MonthID = ddlMonth.SelectedValue == "Select One" ? "0" : ddlMonth.SelectedValue, //txtDate.Text.Split('-')[1],
                    Str_YearID = ddlYear.SelectedValue == "Select One" ? "0" : ddlYear.SelectedValue,//txtDate.Text.Split('-')[0],
                    Str_EmployeeType = "FRONT",
                    Str_PaySheetNo = "0",
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/Report/GenerateWageRegisterPaySlip";

                _PayMaxParameters._DataSet = _Common._ReturnDataSet(_PayMaxParameters);
                if (ddlReportType.SelectedValue == "Wage Register Excel")
                {
                    _GenerateExcel = new GenerateExcel_Report();
                    _GenerateExcel.ExportExcel(this, _PayMaxParameters._DataSet.Tables[1], "Wage Register");
                }
                else
                {
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
                    _GeneratePdf.Str_LocalFilePathTwo = Path.Combine(Server.MapPath("~/Images/Logos/ASR LOGO.png"));
                    _GeneratePdf.Str_Narration = "Wage_Register" + '_' + ddlMonth.SelectedItem.Text + '_' + ddlYear.SelectedItem.Text + '_' + DateTime.Now.Day + '_' + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Millisecond.ToString() + ".pdf";

                    if (_GeneratePdf.GenerateEmployeeWageSlip(_GeneratePdf, _PayMaxParameters._DataSet, _PayMaxParameters.Str_LocalFilePathOne, _GeneratePdf.Str_Narration, "") != "")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + _PayMaxParameters.Str_ServerFilePathOne + _GeneratePdf.Str_Narration + "','_blank');", true);
                    }
                    else
                    {
                        UsersSession.GetMessages(this, "Warning", "Data Not available and File Not Generated");
                        return;
                    }
                    
                   
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }

        }


        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {

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
                 //   _PayMaxParameters.Str_MonthID = ddlMonth.SelectedValue == "Select One" ? "0" : ddlMonth.SelectedValue;
                 //   _PayMaxParameters.Str_YearID = ddlYear.SelectedValue == "Select One" ? "0" : ddlYear.SelectedValue;
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
    }
}