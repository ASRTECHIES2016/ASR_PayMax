using ASR_PayMax.GlobalProjectClass;
using ASR_PayMaxLogic.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASR_PayMax.Transactions
{
    public partial class PaysheetGenerate : System.Web.UI.Page
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
        private void ClearBox()
        {
            BindData();
        }

        private void BindData()
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_SelectID = "22";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlBranch, _Parameters);
                _Parameters.Str_SelectID = "24";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetClientGroup";
                _Common.BindDropDown(this, ddlClient, _Parameters);
                _Parameters.Str_SelectID = "93";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlMonth, _Parameters);
                _Parameters.Str_SelectID = "91";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignation";
                _Common.BindDropDown(this, ddlYear, _Parameters);
            }
            catch (Exception _Exception)
            {
                _Exception.Message.ToString();
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                string TempID = string.Empty;
                if (ddlBranch.SelectedIndex == 0)
                {
                    UsersSession.GetMessages(this, "Warning", "Please Select Branch Name");
                    return;
                }
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                for (int i = 0; i < GridSiteMaster.Rows.Count; i++)
                {
                    Label lblSiteID = GridSiteMaster.Rows[i].Cells[0].FindControl("lblSiteID") as Label;
                    CheckBox IsActive = GridSiteMaster.Rows[i].Cells[0].FindControl("IsActive") as CheckBox;
                    if (IsActive.Checked)
                    {
                        TempID += lblSiteID.Text.Trim() + ",";
                    }
                }
                if (TempID.Length == 0)
                {
                    UsersSession.GetMessages(this, "Warning", "Please Select Site Name");
                    return;
                }
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = "Details",
                    Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue,
                    Str_ClientID = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue,
                    Str_SiteMasterID = TempID.Substring(0, TempID.Length - 1), //ddlSite.SelectedValue == "Select One" ? "0" : ddlSite.SelectedValue,
                    //Str_MonthID = ddlMonth.SelectedValue == "Select One" ? "0" : ddlMonth.SelectedValue,
                    //Str_YearID = ddlYear.SelectedValue == "Select One" ? "0" : ddlYear.SelectedValue,
                    Str_PaySheetNo = "0",
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/PaysheetGenerate";

                _Common.IUMasters(this, _Parameters);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

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
                    _Parameters = new SiteMasterParameters();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_SelectID = "120";
                    //       _Parameters.Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue;
                    _Parameters.Str_ParentID = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue;
                    //       _Parameters.Str_ParametersID = ddlSite.SelectedValue == "Select One" ? "0" : ddlSite.SelectedValue;
                    _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetSiteMaster";
                    _Common.BindDropDown(this, ddlSite, _Parameters);

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
                    _Parameters = new SiteMasterParameters();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue;
                    _Parameters.Str_ClientID = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue;
                    _Parameters.Str_SiteMasterID = ddlSite.SelectedValue == "Select One" ? "0" : ddlSite.SelectedValue;
                    _Parameters.Str_MonthID = ddlMonth.SelectedValue == "Select One" ? "0" : ddlMonth.SelectedValue;
                    _Parameters.Str_YearID = ddlYear.SelectedValue == "Select One" ? "0" : ddlYear.SelectedValue;
                    _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstSiteWiseEmployees";
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

        protected void Btn_Fetch_Click(object sender, EventArgs e)
        {
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

                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = "Details",
                    Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue,
                    Str_ClientID = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue,
                    Str_SiteMasterID = ddlSite.SelectedValue == "Select One" ? "0" : ddlSite.SelectedValue
                    //Str_MonthID = ddlMonth.SelectedValue == "Select One" ? "0" : ddlMonth.SelectedValue,
                    //Str_YearID = ddlYear.SelectedValue == "Select One" ? "0" : ddlYear.SelectedValue,
                    //Str_LoginID = UserDetails.Str_LoginID
                };
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/Get_SiteMaster";

                _Common.BindGrid(this, GridSiteMaster, _Parameters);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }


        }
    }
}