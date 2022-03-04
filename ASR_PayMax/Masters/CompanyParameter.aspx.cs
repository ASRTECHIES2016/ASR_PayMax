using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASR_PayMaxLogic.Models;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using ASR_CommonLogic.Models;
using ASR_PayMax.GlobalProjectClass;
using System.Data;
using System.Configuration;

namespace ASR_PayMax.Masters
{
    public partial class CompanyParameter : System.Web.UI.Page
    {
        CompanyParameters _CompanyParameters;
        ASR_Common _Common;
        DataTable _DataTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearBox();
                BindData();
            }
        }

        private void BindData()
        {
            _DataTable = new DataTable();

            if (_DataTable!=null)
            {
                if (_DataTable.Rows.Count>0)
                {

                }
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddParameterID.Value != "0")
                {
                    Mode = "Edit";
                }
                _CompanyParameters = new CompanyParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SelectID = "13",
                    Str_ParameterID = hddParameterID.Value,
                    Str_WorkAge = txtWorkAge.Text.Trim() == "" ? "0" : txtWorkAge.Text.Trim(),
                    Str_AdminCharges = txtAdminCharges.Text.Trim() == "" ? "0" : txtAdminCharges.Text.Trim(),
                    Str_RetirementAge=txtRetirementAge.Text.Trim() == "" ? "0" : txtRetirementAge.Text.Trim(),
                    Str_GratuityAge = txtGratuityAge.Text.Trim() == "" ? "0" : txtGratuityAge.Text.Trim(),
                    Str_GratuityAmount = txtGratuityAmount.Text.Trim() == "" ? "0" : txtGratuityAmount.Text.Trim(),
                    Bool_EarningRoundOff = chkEarningRoundOff.Checked,
                    Bool_DeductionRoundOff = chkDeductionRoundOff.Checked,
                    Bool_EmpMultipleInstallment_E = chkMultipleInstalment_E_E.Checked,
                    Bool_StaffEmpMultipleInstallment_E = chkMultipleInstalment_E_S.Checked,
                    Bool_EmpMultipleInstallment_D = chkMultipleInstalment_D_E.Checked,
                    Bool_StaffEmpMultipleInstallment_D = chkMultipleInstalment_D_S.Checked,
                    Str_PreJoiningDate = txtAdminCharges.Text.Trim() == "" ? "0" : txtAdminCharges.Text.Trim(),
                    Str_PFDeductionRule = txtAdminCharges.Text.Trim() == "" ? "0" : txtAdminCharges.Text.Trim(),
                    Str_IDCardSign = "",

                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _CompanyParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsCompanyParameter";
                _Common.IUMasters(this, _CompanyParameters);
                ClearBox();
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


        private void ClearBox()
        {
            txtRetirementAge.Text = string.Empty;
            txtGratuityAmount.Text = string.Empty;
            txtAdminCharges.Text = string.Empty;
            txtRetirementAge.Text = string.Empty;
            txtDeductionRule.Text = string.Empty;
            txtGratuityAge.Text = string.Empty;
            txtJoining.Text = string.Empty;
            txtWorkAge.Text = string.Empty;
        }
    }
}