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
    public partial class TransferOrderToOtherBranch : System.Web.UI.Page
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
            hddOtherID.Value = "0";
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
                _PayMaxParameters.Str_SelectID = "13";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlPresentBranch, _PayMaxParameters);
                _Common.BindDropDown(this, ddlTransferBranch, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "24";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetClientGroup";
                _Common.BindDropDown(this, ddlPresentClient, _PayMaxParameters);
                ddlPresentSiteName.Items.Insert(0, "Select One");
                _PayMaxParameters.Str_SelectID = "107";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetRateApplicable";
                _Common.BindDropDown(this, ddlReason, _PayMaxParameters);
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }


        protected void Btn_Submit_Click(object sender, EventArgs e)
        {

            if (txtFirstName.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter First Name");
                return;
            }
            if (ddlPresentBranch.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Present Branch Name");
                return;
            }
            if (ddlPresentClient.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Present Client Name");
                return;
            }

            if (ddlPresentSiteName.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Present Site Name");
                return;
            }
            if (ddlTransferBranch.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Transfer Branch Name");
                return;
            }
            if (ddlReason.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Reoson For Transfer");
                return;
            }


            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddOtherID.Value != "0")
                {
                    Mode = "Edit";
                }
                _PayMaxParameters = new SiteMasterParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_AllotmentID = hddOtherID.Value,
                    Str_OrderType = "Other Branch Transfer",
                    Str_EmployeeID = "1",
                    Str_BranchID = ddlPresentBranch.SelectedValue == "Select One" ? "0" : ddlPresentBranch.SelectedValue,
                    Str_ClientCode = ddlPresentClient.SelectedValue == "Select One" ? "0" : ddlPresentClient.SelectedValue,
                    Str_SiteCode = ddlPresentSiteName.SelectedValue == "Select One" ? "0" : ddlPresentSiteName.SelectedValue,
                    //Str_ClientID = ddlTransferClient.SelectedValue == "Select One" ? "0" : ddlTransferClient.SelectedValue,
                    //Str_SiteMasterID = ddlTransferSiteName.SelectedValue == "Select One" ? "0" : ddlTransferSiteName.SelectedValue,
                    //Str_DesignationID = ddlDesignationID.SelectedValue == "Select One" ? "0" : ddlDesignationID.SelectedValue,
                    Str_ReasonID = ddlReason.SelectedValue == "Select One" ? "0" : ddlReason.SelectedValue,
                    Str_TransactionDate = txtTransactionDate.Text.Trim(),
                    Str_OrderNo = txtTransferOrderNo.Text.Trim(),
                    Str_FromDate = txtFromDate.Text.Trim(),
                    Str_Remarks = "",
                    Str_LoginID = UserDetails.Str_LoginID
                };
                //       _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/
                _PayMaxParameters.Str_ApiUrl =  ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsEmployeeAllotment";
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

        protected void ddlPresentClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlPresentClient.SelectedIndex > 0)
                {
                    ddlPresentSiteName.Items.Clear();
                    var UserDetails = UsersSession.GetSession();
                    _Common = new ASR_Common();
                    _PayMaxParameters = new SiteMasterParameters();
                    _PayMaxParameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _PayMaxParameters.Str_LoginID = UserDetails.Str_LoginID;
                    _PayMaxParameters.Str_SelectID = "120";
                    _PayMaxParameters.Str_ParentID = ddlPresentClient.SelectedValue;
                    _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetClientGroup";
                    _Common.BindDropDown(this, ddlPresentSiteName, _PayMaxParameters); _Common.BindDropDown(this, ddlPresentSiteName, _PayMaxParameters);
                }
            }
            catch (Exception _Exception) { _Exception.ToString(); }



        }
    }
}