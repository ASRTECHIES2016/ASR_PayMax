using ASR_PayMax.GlobalProjectClass;
using ASR_PayMaxLogic.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASR_PayMax.AccessRights
{
    public partial class AccRole : System.Web.UI.Page
    {
        ASR_PayMaxParameters _Parameters;
        ASR_Common _Common;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearBox();
                //         Run();
            }
        }
        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (txtRoleName.Text.Trim()=="")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Role Name.");
                return;
            }
            string Mode = "Add";
            try
            {
                if (txtRoleName.Text.Trim() == "")
                {
                    UsersSession.GetMessages(this, "Warning", "Sorry");
                    return;
                }
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddRoleID.Value != "0")
                {
                    Mode = "Edit";
                }
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SelectID = "94",
                    Str_GlobalID = hddRoleID.Value,
                    Str_GlobalName = txtRoleName.Text,
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };

                _Parameters.Str_ApiUrl =  ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsDesignationGroup";
                if (_Common.IUMasters(this, _Parameters))
                {
                    ClearBox();
                }

            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }
        }
        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearBox();
        }
        private void ClearBox()
        {
            hddRoleID.Value = "0";
            txtRoleName.Text = string.Empty;
            BindData();
        }
        private void BindData()
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "94";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstBank";
                _Common.BindGrid(this, GridRole, _Parameters);
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        protected void GridRole_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);

                Label lblRoleID = GridRole.Rows[RowIndex].Cells[0].FindControl("lblRoleID") as Label;
                Label lblRoleName = GridRole.Rows[RowIndex].Cells[0].FindControl("lblRoleName") as Label;

                if (e.CommandName == "Change")
                {
                    hddRoleID.Value = lblRoleID.Text;
                    txtRoleName.Text = lblRoleName.Text;
                    Btn_Submit.Text = "Update";
                }
                if (e.CommandName == "Deleted")
                {
                    var UserDetails = UsersSession.GetSession();
                    _Parameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_SelectID = "94";
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_GlobalID = lblRoleID.Text;
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

        protected void IsActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                CheckBox chk = (CheckBox)sender;
                GridViewRow Row = ((GridViewRow)((Control)sender).Parent.Parent.Parent.Parent);
                Label lblRoleID = (Label)GridRole.Rows[Row.RowIndex].Cells[0].FindControl("lblRoleID");

                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "94";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_GlobalID = lblRoleID.Text;
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
    }
}