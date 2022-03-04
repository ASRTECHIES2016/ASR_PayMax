using ASR_PayMax.GlobalProjectClass;
using ASR_PayMaxLogic.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASR_PayMax.Allotment
{
    public partial class PostingOrder : System.Web.UI.Page
    {
        ASR_PayMaxParameters _PayMaxParameters;
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
            hddPostingID.Value = "0";
            //       txtBranchName.Text = string.Empty;
            //       txtIFSC_Code.Text = string.Empty;
            Btn_Submit.Text = "Submit";
            BindData();
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
                _PayMaxParameters.Str_SelectID = "47";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignation";
                _Common.BindDropDown(this, ddlDesignationID, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "24";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetClientGroup";
                _Common.BindDropDown(this, ddlClient, _PayMaxParameters);
                ddlSiteName.Items.Insert(0, "Select One");
                //      _PayMaxParameters.Str_SelectID = "120";
                //      _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetSiteMaster";
                //      _Common.BindDropDown(this, ddlSiteName, _PayMaxParameters);
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (ddlBranch.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Branch Name");
                return;
            }
            if (ddlClient.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Client Name");
                return;
            }

            if (ddlSiteName.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Site Name");
                return;
            }
            if (txtUnpostedCode.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Employee Code");
                return;
            }

            if (txtUnpostedEmployee.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Employee Name");
                return;
            }
            if (ddlDesignationID.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Designation Name");
                return;
            }
            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddPostingID.Value != "0")
                {
                    Mode = "Edit";
                }
                _PayMaxParameters = new SiteMasterParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_AllotmentID = hddPostingID.Value,
                    Str_OrderType = "Posting",
                    Str_EmployeeID = hddEmployeeID.Value,
                    Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue,
                    Str_ClientCode = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue,
                    Str_SiteCode = ddlSiteName.SelectedValue == "Select One" ? "0" : ddlSiteName.SelectedValue,
                    Str_DesignationID = ddlDesignationID.SelectedValue == "Select One" ? "0" : ddlDesignationID.SelectedValue,
                    Str_TransactionDate = txtTransactionDate.Text.Trim(),
                    Str_OrderNo = txtPostingOrderNo.Text.Trim(),
                    Str_FromDate = txtFromDate.Text.Trim(),
                    Str_Remarks = "",
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsEmployeeAllotment";
                if (_Common.IUMasters(this, _PayMaxParameters))
                {
                    ClearBox();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearBox();
        }

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                _PayMaxParameters = new SiteMasterParameters();
                _PayMaxParameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _PayMaxParameters.Str_LoginID = UserDetails.Str_LoginID;
                _PayMaxParameters.Str_SelectID = "120";
                _PayMaxParameters.Str_Mode = "ID";
                _PayMaxParameters.Str_GlobalID= ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue;
                _PayMaxParameters.Str_ParentID = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue;
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetSiteMaster";
                _Common.BindDropDown(this, ddlSiteName, _PayMaxParameters);
            }
            catch (Exception _Exception) { _Exception.ToString(); }

        }
    }
}