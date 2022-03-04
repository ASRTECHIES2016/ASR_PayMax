using System;
using ASR_PayMaxLogic.Models;
using System.Data;
using ASR_PayMax.GlobalProjectClass;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace ASR_PayMax.Masters
{
    public partial class Qualifications : System.Web.UI.Page
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

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (txtQualification.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter Qualification');", true);
                return;
            }


            if (!Regex.Match(txtQualification.Text, @"[a-zA-Z0-9]+").Success)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Special Character Not Allowed');", true);
                return;
            }
            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddQualID.Value != "0")
                {
                    Mode = "Edit";
                }
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SelectID = "106",
                    Str_GlobalID = hddQualID.Value,
                    Str_GlobalName = txtQualification.Text,
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
            hddQualID.Value = "0";
            txtQualification.Text = string.Empty;
            Btn_Submit.Text = "Submit";
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
                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_SelectID = "106";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstGunType";
                _Common.BindGrid(this, GridQualification, _Parameters);
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
                Label lblQualificationMasterID = (Label)GridQualification.Rows[Row.RowIndex].Cells[0].FindControl("lblQualificationMasterID");

                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "106";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_GlobalID = lblQualificationMasterID.Text;
                _Parameters.Str_Mode = "Active";
                _Parameters.Bool_IsActive = chk.Checked;
                _Parameters = _Common.ModifiedData(_Parameters);
                if (_Parameters != null)
                {
                    UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                    ClearBox();
                }
                else
                {
                    //   UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }


        }

        protected void GridQualification_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            try
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);

                Label lblQualificationMasterID = GridQualification.Rows[RowIndex].Cells[0].FindControl("lblQualificationMasterID") as Label;
                Label lblQualificationName = GridQualification.Rows[RowIndex].Cells[0].FindControl("lblQualificationName") as Label;

                if (e.CommandName == "Change")
                {
                    hddQualID.Value = lblQualificationMasterID.Text;
                    txtQualification.Text = lblQualificationName.Text;
                    Btn_Submit.Text = "Update";
                }
                if (e.CommandName == "Deleted")
                {
                    var UserDetails = UsersSession.GetSession();
                    _Parameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_SelectID = "106";
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_GlobalID = lblQualificationMasterID.Text;
                    _Parameters.Str_Mode = "Delete";
                    _Parameters = _Common.ModifiedData(_Parameters);
                    if (_Parameters != null)
                    {
                        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                        ClearBox();
                    }
                    else
                    {
                        //   UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
    }
}
