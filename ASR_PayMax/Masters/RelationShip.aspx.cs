using System;
using ASR_PayMaxLogic.Models;
using ASR_PayMax.GlobalProjectClass;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace ASR_PayMax.Masters
{
    public partial class RelationShip : System.Web.UI.Page
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
            if (txtRelationShip.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Relation Ship");
                return;
            }
            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddRelationID.Value != "0")
                {
                    Mode = "Edit";
                }
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SelectID = "110",
                    Str_GlobalID = hddRelationID.Value,
                    Str_GlobalName = txtRelationShip.Text,
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _Parameters.Str_ApiUrl =  ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsRelationship";
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
            txtRelationShip.Text = string.Empty;
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
                _Parameters.Str_SelectID = "110";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstRelationship";
                _Common.BindGrid(this, GridRelationShip, _Parameters);
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        protected void GridRelationShip_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            try
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);

                Label lblRelationshipMasterID = GridRelationShip.Rows[RowIndex].Cells[0].FindControl("lblRelationshipMasterID") as Label;
                Label lblRelationshipName = GridRelationShip.Rows[RowIndex].Cells[0].FindControl("lblRelationshipName") as Label;
              
                if (e.CommandName == "Change")
                {
                    hddRelationID.Value = lblRelationshipMasterID.Text;
                    txtRelationShip.Text = lblRelationshipName.Text;
                    Btn_Submit.Text = "Update";
                }
                if (e.CommandName == "Deleted")
                {
                    var UserDetails = UsersSession.GetSession();
                    _Parameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_SelectID = "110";
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_GlobalID = lblRelationshipMasterID.Text;
                    _Parameters.Str_Mode = "Delete";
                    _Parameters = _Common.ModifiedData(_Parameters);
                    if (_Parameters != null)
                    {
                        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                        ClearBox();
                    }
                    else
                    {
                        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                    }
                }
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
                Label lblRelationshipMasterID = (Label)GridRelationShip.Rows[Row.RowIndex].Cells[0].FindControl("lblRelationshipMasterID");

                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "110";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_GlobalID = lblRelationshipMasterID.Text;
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
                    UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                }
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }


        }
    }
}