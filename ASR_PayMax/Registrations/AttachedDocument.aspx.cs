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
    public partial class AttachedDocument : System.Web.UI.Page
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
            txtFirstName.Text = string.Empty;
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
                _Parameters.Str_SelectID = "55";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDocument";
                _Common.BindDropDown(this, ddlDocument, _Parameters);
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }


        protected void Btn_Submit_Click(object sender, EventArgs e)
        {

            if (txtEmployeeCode.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Employee Code");
                return;
            }
            if (txtFirstName.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter First Name");
                return;
            }
            if (ddlDocument.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Document Name');", true);
                return;
            }
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        protected void AsyncUpload_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            string FilePath = Server.MapPath("~/Images/Users/");
            string FileName = AsyncUpload.FileName;
            AsyncUpload.SaveAs(FilePath + FileName);
            ImgDoccument.ImageUrl = FilePath + FileName;
        }
    }
}