using System;
using ASR_PayMaxLogic.Models;
using ASR_PayMax.GlobalProjectClass;
using System.Configuration;
using System.Web.UI;

namespace ASR_PayMax.Masters
{
    public partial class SiteCalculation1 : System.Web.UI.Page
    {
        SiteCalculation _Parameters;
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
            if (ddlBranch.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Branch Name');", true);
                return;
            }
            if (ddlClient.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Client Name');", true);
                return;
            }
            if (ddlSite.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Site Name');", true);
                return;
            }
            if (RadioSalaryCalculation.SelectedValue=="D")
            {
                if (txtFromDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter From Date');", true);
                    return;
                }
                if (txtToDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter To Date');", true);
                    return;
                }
            }
            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddSiteCalID.Value != "0")
                {
                    Mode = "Edit";
                }
                _Parameters = new SiteCalculation
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue,
                    Str_SiteCalID = hddSiteCalID.Value,
                    Str_SiteMasterID = ddlSite.SelectedValue == "Select One" ? "0" : ddlSite.SelectedValue,
                    Str_ClientGroupID = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue,
                    Str_ExtraManPowerPerDay = txtExtraManpower.Text.Trim() == "" ? "0" : txtExtraManpower.Text.Trim(),
                    Str_SalaryCalcType = RadioSalaryCalculation.Text,
                    Str_SalaryFrom = txtFromDate.Text.Trim() == "" ? null : txtFromDate.Text.Trim(),
                    Str_SalaryTo = txtToDate.Text.Trim() == "" ? null : txtToDate.Text.Trim(),
                    Str_SalaryCalcOn = RadioSalaryCalculationOn.Text,
                    Str_SalaryCalcDays = txtCalculationOn.Text.Trim() == "" ? "0" : txtCalculationOn.Text.Trim(),
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _Parameters.Str_ApiUrl =  ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMaxMaster/MsSiteCalculation";
                if (_Common.IUMasters(this, _Parameters))
                {
                    ClearBox();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        private void ClearBox()
        {
            hddSiteCalID.Value = "0";
            txtCalculationOn.Text = string.Empty;
            txtExtraManpower.Text = string.Empty;
            txtFromDate.Text = string.Empty;
            txtToDate.Text = string.Empty;
            Btn_Submit.Text = "Submit";
            BindData();
        }
        private void BindData()
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                _Parameters = new SiteCalculation();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_SelectID = "22";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlBranch, _Parameters);
                _Parameters.Str_SelectID = "24";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlClient, _Parameters);
                _Parameters.Str_SelectID = "120";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlSite, _Parameters);
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

        protected void RadioSalaryCalculation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RadioSalaryCalculation.SelectedValue=="D")
            {
                txtToDate.Enabled = false;
                txtFromDate.Enabled = true;
                txtFromDate.Text = string.Empty;
                txtToDate.Text = string.Empty;
            }
            else
            {
                txtToDate.Enabled = false;
                txtFromDate.Enabled = false;
                txtFromDate.Text = Convert.ToString(1);
                txtToDate.Text = Convert.ToString(0);
            }

        }

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                _Parameters = new SiteCalculation();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;

                if (ddlClient.SelectedIndex > 0)
                {
                    _Parameters.Str_SelectID = "120";
                    _Parameters.Str_ParentID = ddlClient.SelectedValue;
                    //  _PayMaxParameters.Str_GlobalID = ddlClient.SelectedValue;
                    _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetClientGroup";
                    _Common.BindDropDown(this, ddlSite, _Parameters);
                }
                else
                {
                    ddlSite.Items.Clear();
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }

        }

        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {
            if(RadioSalaryCalculation.SelectedValue=="D")
            {
                txtToDate.Enabled = false;
                if (Convert.ToInt32(txtFromDate.Text) >= 2)
                    txtToDate.Text =  Convert.ToString(Convert.ToInt32(txtFromDate.Text) - 1);
                else
                { 
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter  From Date Greater Than Or Equal To 2');", true);
                    return;
                }

            }
            
        }
    }
}