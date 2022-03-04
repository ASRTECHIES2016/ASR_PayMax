using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASR_PayMaxLogic.Models;
using ASR_PayMax.GlobalProjectClass;
using System.Configuration;

namespace ASR_PayMax.Masters
{
    public partial class SiteManpower : System.Web.UI.Page
    {
        ASR_PayMaxParameters _PayMaxParameters;
        SiteManPowerParameters _SiteManPower;
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
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddSiteManPowerID.Value != "0")
                {
                    Mode = "Edit";
                }
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
                if (ddlDesignation.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Designation Name');", true);
                    return;
                }
                if (ddlDuty.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Duty Type');", true);
                    return;
                }

                _SiteManPower = new SiteManPowerParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SiteManPowerID = hddSiteManPowerID.Value,
                    Str_SiteMasterID = ddlSite.SelectedValue == "Select One" ? "0" : ddlSite.SelectedValue,
                    Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue,
                    Str_DesignationID = ddlDesignation.SelectedValue == "Select One" ? "0" : ddlDesignation.SelectedValue,
                    Str_DutyID = ddlDuty.SelectedValue == "Select One" ? "0" : ddlDuty.SelectedValue,
                    Str_NoOfPerson = txtNoOfEmployee.Text.Trim() == "" ? "0" : txtNoOfEmployee.Text.Trim(),
                    Str_SalaryCalcOn = RadioSalary.Text,
                    Str_SalaryCalcDays = txtSalary.Text == "" ? "0" : txtSalary.Text.Trim(),
                    Str_BillingCalcOn = RadioBilling.Text,
                    Str_BillingCalcDays = txtBilling.Text.Trim() == "" ? "0" : txtBilling.Text.Trim(),
                    Str_ProductDescription = "",
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _SiteManPower.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMaxMaster/MsSiteManpower";
                if (_Common.IUMasters(this, _SiteManPower))
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
            hddSiteManPowerID.Value = "0";
            txtNoOfEmployee.Text = string.Empty;
            txtSalary.Text = string.Empty;
            txtBilling.Text = string.Empty;
            txtSalary.Enabled = false;
            txtBilling.Enabled = false;
            BindData();
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearBox();
        }
        private void BindData()
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                _PayMaxParameters = new ASR_PayMaxParameters();
                _PayMaxParameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _PayMaxParameters.Str_LoginID = UserDetails.Str_LoginID;
                _PayMaxParameters.Str_SelectID = "22";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlBranch, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "24";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetClientGroup";
                _Common.BindDropDown(this, ddlClient, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "51";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDuty";
                _Common.BindDropDown(this, ddlDuty, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "47";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignation";
                _Common.BindDropDown(this, ddlDesignation, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "119";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstSiteManpower";
                _Common.BindGrid(this, GridSiteManPower, _PayMaxParameters);
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        protected void IsActive_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                var UserDetails = UsersSession.GetSession();
                CheckBox chk = (CheckBox)sender;
                GridViewRow Row = ((GridViewRow)((Control)sender).Parent.Parent.Parent.Parent);
                CheckBox grdCheckBox = (CheckBox)GridSiteManPower.Rows[Row.RowIndex].FindControl("IsActive");
                Label ID = (Label)GridSiteManPower.Rows[Row.RowIndex].Cells[0].FindControl("lblID");

                _PayMaxParameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _PayMaxParameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _PayMaxParameters.Str_SelectID = "119";
                _PayMaxParameters.Str_LoginID = UserDetails.Str_LoginID;
                _PayMaxParameters.Str_GlobalID = ID.Text;
                _PayMaxParameters.Str_Mode = "Active";
                _PayMaxParameters.Bool_IsActive = chk.Checked;
                _PayMaxParameters = _Common.ModifiedData(_PayMaxParameters);
                if (_PayMaxParameters.Str_Status != null)
                {
                    UsersSession.GetMessages(this, _PayMaxParameters.Str_Status, _PayMaxParameters.Str_Result);
                    ClearBox();
                }
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        protected void GridSiteManPower_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);

                Label ID = GridSiteManPower.Rows[RowIndex].Cells[0].FindControl("lblID") as Label;
                if (e.CommandName == "Change")
                {
                    hddSiteManPowerID.Value = ID.Text;
                    // txtDesignation.Text = lblDesignationName.Text;``
                    Btn_Submit.Text = "Update";
                    //ddlDesignationGroupID.SelectedValue = lblDesignationGroupID.Text;
                    //ddlDesignationCategoryID.SelectedValue = lblDesignationCategoryTypeID.Text;
                }
                if (e.CommandName == "Deleted")
                {
                    var UserDetails = UsersSession.GetSession();
                    _PayMaxParameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common();
                    _PayMaxParameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _PayMaxParameters.Str_SelectID = "119";
                    _PayMaxParameters.Str_LoginID = UserDetails.Str_LoginID;
                    _PayMaxParameters.Str_GlobalID = ID.Text;
                    _PayMaxParameters.Str_Mode = "Delete";
                    _PayMaxParameters = _Common.ModifiedData(_PayMaxParameters);
                    if (_PayMaxParameters.Str_Status != null)
                    {
                        UsersSession.GetMessages(this, _PayMaxParameters.Str_Status, _PayMaxParameters.Str_Result);
                        ClearBox();
                    }
                }
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        protected void RadioSalary_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (RadioSalary.SelectedIndex == 3)
                {
                    txtSalary.Text = "0";
                    txtSalary.Enabled = true;
                }
                else
                {
                    txtSalary.Text = "";
                    txtSalary.Enabled = false;
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }
        }

        protected void RadioBilling_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (RadioBilling.SelectedIndex == 3)
                {
                    txtBilling.Text = "0";
                    txtBilling.Enabled = true;
                }
                else
                {
                    txtBilling.Text = "";
                    txtBilling.Enabled = false;
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }
        }

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                _PayMaxParameters = new ASR_PayMaxParameters();
                _PayMaxParameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _PayMaxParameters.Str_LoginID = UserDetails.Str_LoginID;

                if (ddlClient.SelectedIndex > 0)
                {
                    _PayMaxParameters.Str_SelectID = "120";
                    _PayMaxParameters.Str_ParentID = ddlClient.SelectedValue;
                    //_PayMaxParameters.Str_ClientID = ddlClient.SelectedValue;
                    //_PayMaxParameters.Str_BranchID = ddlBranch.SelectedValue;
                    //_PayMaxParameters.Str_Mode = "ID";

                    //  _PayMaxParameters.Str_GlobalID = ddlClient.SelectedValue;
                    _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetSiteMaster";
                    //_PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/Get_SiteMaster";

                    _Common.BindDropDown(this, ddlSite, _PayMaxParameters);
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
        public string MaxLength(string Str_Value, string Str_MinValue, string Str_MaxValue, int Int_Length, int Int_Max)
        {
            string Str_Result = "";
            if (Int_Length >= Str_MinValue.Length)
            {
                return Str_Result = "Minimum Length Exceeded";
            }
            if (Int_Length >= Str_MaxValue.Length)
            {
                return Str_Result = "Maximum Length Exceeded";
            }
            if (Int_Max < Str_MaxValue.Length)
            {
                return Str_Result = "Maximum Length Exceeded";
            }
            if (Convert.ToInt32(Str_Value) < Convert.ToInt32(Str_MinValue))
            {
                return Str_Result = "Maximum Value Is " + Str_Value;
            }
            if (Int_Max <= Convert.ToInt32(Str_MaxValue))
            {
                return Str_Result = "Maximum Value Is " + Int_Max;
            }
            return Str_Result;
        }

        protected void txtSalary_TextChanged(object sender, EventArgs e)
        {
            string Text = MaxLength("0", "0", txtSalary.Text, 2, 31);
            if (Text != "")
            {
                UsersSession.GetMessages(this, "Warning", Text);
            }
        }

        protected void txtBilling_TextChanged(object sender, EventArgs e)
        {
            string Text = MaxLength("0", "0", txtBilling.Text, 2, 31);
            if (Text != "")
            { UsersSession.GetMessages(this, "Warning", Text); }
        }
    }
}