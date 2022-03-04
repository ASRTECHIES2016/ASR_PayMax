using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASR_PayMaxLogic.Models;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using ASR_PayMax.GlobalProjectClass;
using System.Configuration;
using System.Data;
using Newtonsoft.Json;

namespace ASR_PayMax.Masters
{
    public partial class Designation : System.Web.UI.Page
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
            if (ddlDesignationGroupID.SelectedValue == "Select One")
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Designation Group.");
                return;
            }
            if (txtDesignation.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter Designation Name');", true);
                return;
            }

            try
            {
                string Mode = "Add";
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddDesignationID.Value != "0")
                {
                    Mode = "Edit";
                }

                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SelectID = "47",
                    Str_GlobalID = hddDesignationID.Value,
                    Str_GlobalName = txtDesignation.Text,
                    Str_ParentID = ddlDesignationGroupID.SelectedValue,
                    Str_CategoryTypeID = ddlDesignationCategoryID.SelectedValue == "Select One" ? "0" : ddlDesignationCategoryID.SelectedValue,
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsDesignation";
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

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearBox();
        }

        private void ClearBox()
        {
            hddDesignationID.Value = "0";
            txtDesignation.Text = string.Empty;
            Btn_Submit.Text = "Submit";
            BindData();
        }

        private void BindData()
        {
            HttpResponseMessage response;
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_SelectID = "45";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignationCategory";
                _Common.BindDropDown(this, ddlDesignationCategoryID, _Parameters);
                _Parameters.Str_SelectID = "46";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignationGroup";
                _Common.BindDropDown(this, ddlDesignationGroupID, _Parameters);
                _Parameters.Str_SelectID = "47";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstDesignation";
                _Common.BindGrid(this, GridDesignation, _Parameters);
                DataTable dt = new DataTable();

                dt.Columns.Add(new DataColumn("SkillName", typeof(string)));
                DataRow dr;

                dr = dt.NewRow();
                dr["SkillName"] = "Un Skilled";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["SkillName"] = "Semi Skilled";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["SkillName"] = "Skilled";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["SkillName"] = "Highly Skilled";
                dt.Rows.Add(dr);

                GridSkill.DataSource = dt;
                GridSkill.DataBind();
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        protected void GridDesignation_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);

                Label lblDesignationID = GridDesignation.Rows[RowIndex].Cells[0].FindControl("lblDesignationID") as Label;
                Label lblDesignationName = GridDesignation.Rows[RowIndex].Cells[0].FindControl("lblDesignationName") as Label;
                Label lblDesignationGroupID = GridDesignation.Rows[RowIndex].Cells[0].FindControl("lblDesignationGroupID") as Label;
                Label lblDesignationCategoryTypeID = GridDesignation.Rows[RowIndex].Cells[0].FindControl("lblDesignationCategoryTypeID") as Label;
                if (e.CommandName == "Change")
                {
                    hddDesignationID.Value = lblDesignationID.Text;
                    txtDesignation.Text = lblDesignationName.Text;
                    Btn_Submit.Text = "Update";
                    ddlDesignationGroupID.SelectedValue = lblDesignationGroupID.Text;
                    ddlDesignationCategoryID.SelectedValue = lblDesignationCategoryTypeID.Text;
                }
                if (e.CommandName == "Deleted")
                {
                    var UserDetails = UsersSession.GetSession();
                    _Parameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_SelectID = "47";
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_GlobalID = lblDesignationID.Text;
                    _Parameters.Str_Mode = "Delete";
                    _Parameters = _Common.ModifiedData(_Parameters);
                    if (_Parameters.Str_Status != null)
                    {
                        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                        ClearBox();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void IsActive_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                var UserDetails = UsersSession.GetSession();
                CheckBox chk = (CheckBox)sender;
                GridViewRow Row = ((GridViewRow)((Control)sender).Parent.Parent.Parent.Parent);
                CheckBox grdCheckBox = (CheckBox)GridDesignation.Rows[Row.RowIndex].FindControl("IsActive");
                Label lblDesignationID = (Label)GridDesignation.Rows[Row.RowIndex].Cells[0].FindControl("lblDesignationID");

                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "47";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_GlobalID = lblDesignationID.Text;
                _Parameters.Str_Mode = "Active";
                _Parameters.Bool_IsActive = chk.Checked;
                _Parameters = _Common.ModifiedData(_Parameters);
                if (_Parameters.Str_Status != null)
                {
                    UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                    ClearBox();
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }
        }
    }
}