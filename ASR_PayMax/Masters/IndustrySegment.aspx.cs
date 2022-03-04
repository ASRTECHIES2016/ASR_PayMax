using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASR_PayMaxLogic.Models;
using ASR_PayMax.GlobalProjectClass;
using System.Configuration;
using System.Data;

namespace ASR_PayMax.Masters
{
    public partial class IndustrySegment1 : System.Web.UI.Page
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
            if (txtIndustrySegmentCode.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Industry Segment Code");
                return;
            }
            if (txtIndustrySegment.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Industry Segment");
                return;
            }
            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddIndustryID.Value != "0")
                {
                    Mode = "Edit";
                }
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SelectID = "77",
                    Str_GlobalID = hddIndustryID.Value,
                    Str_GlobalCode = txtIndustrySegmentCode.Text,
                    Str_GlobalName = txtIndustrySegment.Text,
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _Parameters.Str_ApiUrl =  ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsIndustrySegment";
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

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearBox();
        }

        private void ClearBox()
        {
            hddIndustryID.Value = "0";
            txtIndustrySegmentCode.Text = string.Empty;
            txtIndustrySegmentCode.Text = string.Empty;
            Btn_Submit.Text = "Submit";
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
                _Parameters.Str_SelectID = "77";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstIndustrySegment";
                _Common.BindGrid(this, GridIndustry, _Parameters);
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
                CheckBox grdCheckBox = (CheckBox)GridIndustry.Rows[Row.RowIndex].FindControl("IsActive");
                Label lblIndustryID = (Label)GridIndustry.Rows[Row.RowIndex].Cells[0].FindControl("lblIndustryID");

                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "77";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_GlobalID = lblIndustryID.Text;
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
                UsersSession.GetMessages(this, "Failure", _Exception.Message.ToString());
            }

        }

        protected void GridIndustry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);

                Label lblIndustryID = GridIndustry.Rows[RowIndex].Cells[0].FindControl("lblIndustryID") as Label;
                Label lblIndustryCode = GridIndustry.Rows[RowIndex].Cells[0].FindControl("lblIndustryCode") as Label;
                Label lblIndustrySegmentName = GridIndustry.Rows[RowIndex].Cells[0].FindControl("lblIndustrySegmentName") as Label;
                if (e.CommandName == "Change")
                {
                    hddIndustryID.Value = lblIndustryID.Text;
                    txtIndustrySegmentCode.Text = lblIndustryCode.Text;
                    txtIndustrySegment.Text = lblIndustrySegmentName.Text;
                    Btn_Submit.Text = "Update";
                }
                if (e.CommandName == "Deleted")
                {
                    var UserDetails = UsersSession.GetSession();
                    _Parameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_SelectID = "77";
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_GlobalID = lblIndustryID.Text;
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
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }
    }
}