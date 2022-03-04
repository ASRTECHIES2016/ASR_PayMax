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

namespace ASR_PayMax.Registrations
{
    public partial class EmployeeBankDetails : System.Web.UI.Page
    {
        ASR_PayMaxParameters _Parameters;
        ASR_Common _Common;
        DataSet _DataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearBox();
            }
        }
        private void ClearBox()
        {
            hddEmployeeID.Value = "0";
            txtAccountNo.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtIFSC_Code.Text = string.Empty;
            txtRefNo.Text = string.Empty;
            Btn_Submit.Text = "Submit";
            BindData();
        }

        private void BindData()
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                _Parameters = new ASR_PayMaxParameters();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_SelectID = "23";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlBranch, _Parameters);
                _Parameters.Str_SelectID = "13";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBank";
                _Common.BindDropDown(this, ddlBankName, _Parameters);
                _Parameters.Str_SelectID = "12";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBankBranch";
                _Common.BindDropDown(this, ddlBankBranch, _Parameters);
                _Parameters.Str_SelectID = "145";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetPaymentMode";
                _Common.BindDropDown(this, ddlPaymentMode, _Parameters);
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }
    }
}