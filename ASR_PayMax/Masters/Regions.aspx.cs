using System;
using ASR_PayMaxLogic.Models;
using System.Data;
using ASR_PayMax.GlobalProjectClass;
using System.Configuration;

namespace ASR_PayMax.Masters
{
    public partial class Regions : System.Web.UI.Page
    {
        ASR_PayMaxParameters _Parameters;
        ASR_Common _Common;
        DataSet _DataSet;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (txtRegionCode.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Region Code");
                return;
            }
            if (txtRegionName.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Region Name");
                return;
            }
            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                //if (hddDocumentID.Value != "0")
                //{
                //    Mode = "Edit";
                //}
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SelectID = "109",
                    Str_GlobalID = hddRegionID.Value,
                    Str_GlobalCode = txtRegionCode.Text.Trim(),
                    Str_GlobalName = txtRegionName.Text.Trim(),
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsDocument";
                if (_Common.IUMasters(this, _Parameters))
                {
                    ClearBox();
                }
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        private void ClearBox()
        {
            hddRegionID.Value = "0";
            txtRegionCode.Text = string.Empty;
            txtRegionName.Text = string.Empty;
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
                _Parameters.Str_SelectID = "109";

                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsGun";
                _Common.BindGrid(this, GridLanguage, _Parameters);
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
    }
}