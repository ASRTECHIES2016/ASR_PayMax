using ASR_PayMax.GlobalProjectClass;
using ASR_PayMaxLogic.Models;
using System;
using System.Data;

namespace ASR_PayMax.Masters
{
    public partial class CategoryDetails : System.Web.UI.Page
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
            BindData();
        }

        private void BindData()
        {
            var UserDetails = UsersSession.GetSession();
            _Parameters = new ASR_PayMaxParameters();
            _Common = new ASR_Common();
            _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
            _Parameters.Str_LoginID = UserDetails.Str_LoginID;
         //   _Parameters.Str_SelectID = "45";
         //   _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignationCategory";
         //   _Common.BindGrid(this, GridSkill, _Parameters);
        }

            protected void Btn_Submit_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}