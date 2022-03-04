using System;
using ASR_PayMaxLogic.Models;
using ASR_PayMax.GlobalProjectClass;
using System.Data;
using System.Configuration;

namespace ASR_PayMax.Masters
{
    public partial class TenureOfContract1 : System.Web.UI.Page
    {
        ASR_PayMaxParameters _Parameters;
        ASR_Common _Common;
        DataSet _DataSet;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                //if (hddDocumentID.Value != "0")
                //{
                //    mode = "Edit";
                //}
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SelectID = "49",
                    //Str_GlobalID = hddDocumentID.Value,
                    //Str_GlobalName = txtDocumentName.Text,
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _Parameters.Str_ApiUrl =  ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsDocument";
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
            throw new NotImplementedException();
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}