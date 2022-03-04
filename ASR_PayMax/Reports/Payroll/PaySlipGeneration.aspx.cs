using ASR_PayMax.GlobalProjectClass;
using ASR_PayMaxLogic.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASR_PayMax.Reports.Payroll
{
    public partial class PaySlipGeneration : System.Web.UI.Page
    {
        SiteMasterParameters _SiteMaster;
        GenerateExcel_Report _Report;
        ASR_Common _Common;
        DataTable dt;
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
                _SiteMaster = new SiteMasterParameters();
                _SiteMaster.Str_CompanyID = UserDetails.Str_CompanyID;
                _SiteMaster.Str_LoginID = UserDetails.Str_LoginID;
                _SiteMaster.Str_SelectID = "22";
                _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlBranch, _SiteMaster);
                _SiteMaster.Str_SelectID = "24";
                _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetClientGroup";
                _Common.BindDropDown(this, ddlClient, _SiteMaster);
                ddlSite.Items.Insert(0, "Select One");
                _SiteMaster.Str_SelectID = "93";
                _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlMonth, _SiteMaster);
                _SiteMaster.Str_SelectID = "91";
                _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignation";
                _Common.BindDropDown(this, ddlYear, _SiteMaster);
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            _Report = new GenerateExcel_Report();
            _Report.ExportExcel(this, null, "PaySlip");
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlClient.SelectedIndex > 0)
                {

                    var UserDetails = UsersSession.GetSession();
                    _Common = new ASR_Common();
                    _SiteMaster = new SiteMasterParameters();
                    _SiteMaster.Str_CompanyID = UserDetails.Str_CompanyID;
                    _SiteMaster.Str_LoginID = UserDetails.Str_LoginID;
                    _SiteMaster.Str_SelectID = "120";
                    //       _SiteMaster.Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue;
                    _SiteMaster.Str_ParentID = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue;
                    //       _SiteMaster.Str_SiteMasterID = ddlSite.SelectedValue == "Select One" ? "0" : ddlSite.SelectedValue;
                    _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetSiteMaster";
                    _Common.BindDropDown(this, ddlSite, _SiteMaster);

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
                    _SiteMaster = new SiteMasterParameters();
                    _SiteMaster.Str_CompanyID = UserDetails.Str_CompanyID;
                    _SiteMaster.Str_LoginID = UserDetails.Str_LoginID;
                    _SiteMaster.Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue;
                    _SiteMaster.Str_ClientID = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue;
                    _SiteMaster.Str_SiteMasterID = ddlSite.SelectedValue == "Select One" ? "0" : ddlSite.SelectedValue;
                    _SiteMaster.Str_MonthID = ddlMonth.SelectedValue == "Select One" ? "0" : ddlMonth.SelectedValue;
                    _SiteMaster.Str_YearID = ddlYear.SelectedValue == "Select One" ? "0" : ddlYear.SelectedValue;
                    _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstSiteWiseEmployees";
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