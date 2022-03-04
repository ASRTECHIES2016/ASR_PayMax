using System;
using System.Web.UI;
using ASR_PayMaxLogic.Models;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Data;
using ASR_PayMax.GlobalProjectClass;
using System.Configuration;

namespace ASR_PayMax.Masters
{
    public partial class SalaryHead : System.Web.UI.Page
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
            string Mode = "Add";

            if (txtSalaryHeadCode.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter Salary Head Code');", true);
                return;
            }

            if (txtSalaryHeadName.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter Salary Head Name');", true);
                return;
            }
            if (ddlSalaryHeadGroup.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Sorry');", true);
                return;
            }
            

            try
            {
                _Common = new ASR_Common();
                var UserDetails = UsersSession.GetSession();
                if (hddSalaryHeadID.Value != "0")
                {
                    Mode = "Edit";
                }
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = "1",
                    Str_SelectID = "115",
                    Str_SequenceNo = txtSequenceNo.Text,
                    Str_SalaryHeadID = hddSalaryHeadID.Value,
                    Str_SalaryHeadCode = txtSalaryHeadCode.Text,
                    Str_SalaryHeadName = txtSalaryHeadName.Text,
                    Str_SalaryHeadGroupID = ddlSalaryHeadGroup.SelectedValue,
                    Str_PaySlip = ddlPaySlip.SelectedValue,
                    Bool_Variables = chkVariable.Checked,
                    Bool_IsActive = true,
                    Str_LoginID = "1"
                };
                _Parameters.Str_ApiUrl =  ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMaxMaster/MsSalaryHead";
                if (_Common.IUMasters(this, _Parameters))
                {
                    ClearBox();
                } 
                //HttpContent inputContent = new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json");
                //HttpResponseMessage response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, inputContent).Result;

                //if (response.IsSuccessStatusCode)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "ShowSuccess('Saved Successfully');", true);
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Sorry');", true);
                //}

                //if (response.IsSuccessStatusCode)
                //{
                //    _Parameters = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters>(response.Content.ReadAsStringAsync().Result);
                //    if (_Parameters.Str_Status != null)
                //    {
                //        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                //        ClearBox();
                //    }
                //    else
                //    {
                //        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                //    }
                //}
                //else
                //{
                //    UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                //}
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
            hddSalaryHeadID.Value = "0";
            txtSalaryHeadCode.Text = string.Empty;
            txtSequenceNo.Text = string.Empty;
            txtSalaryHeadName.Text = string.Empty;
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
                _Parameters.Str_SelectID = "114";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetSalaryHeadGroup";
                _Common.BindDropDown(this, ddlSalaryHeadGroup, _Parameters);
                _Parameters.Str_SelectID = "115";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstSalaryHead";
                _Common.BindGrid(this, GridSalaryHead, _Parameters);
                //response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json")).Result;
                //if (response.IsSuccessStatusCode)
                //{
                //    _DataSet = JsonConvert.DeserializeObject<DataSet>(response.Content.ReadAsStringAsync().Result);
                //    if (_DataSet != null)
                //    {
                //        if (_DataSet.Tables[0] != null)
                //        {
                //            if (_DataSet.Tables[0].Rows.Count > 0)
                //            {
                //                GridSalaryHead.DataSource = _DataSet.Tables[0];
                //                GridSalaryHead.DataBind();
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                //}
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        protected void GridSalaryHead_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);
                Label lblSalaryHeadMasterID = (Label)GridSalaryHead.Rows[RowIndex].Cells[0].FindControl("lblSalaryHeadMasterID");
                Label lblSalaryHeadGroupMasterID = (Label)GridSalaryHead.Rows[RowIndex].Cells[0].FindControl("lblSalaryHeadGroupMasterID");
                Label lblSequenceNo = (Label)GridSalaryHead.Rows[RowIndex].Cells[0].FindControl("lblSequenceNo");
                Label lblSalaryHeadCode = (Label)GridSalaryHead.Rows[RowIndex].Cells[0].FindControl("lblSalaryHeadCode");
                Label lblSalaryHeadName = (Label)GridSalaryHead.Rows[RowIndex].Cells[0].FindControl("lblSalaryHeadName");
                Label lblSalaryHeadGroupName = (Label)GridSalaryHead.Rows[RowIndex].Cells[0].FindControl("lblSalaryHeadGroupName");
                if (e.CommandName == "Change")
                {
                    hddSalaryHeadID.Value = lblSalaryHeadMasterID.Text;
                    ddlSalaryHeadGroup.SelectedValue = lblSalaryHeadGroupMasterID.Text;
                    txtSequenceNo.Text = lblSequenceNo.Text;
                    txtSalaryHeadCode.Text = lblSalaryHeadCode.Text;
                    txtSalaryHeadName.Text = lblSalaryHeadName.Text;

                    Btn_Submit.Text = "Update";
                }
                if (e.CommandName == "Deleted")
                {
                    var UserDetails = UsersSession.GetSession();
                    _Parameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_SelectID = "115";
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_GlobalID = lblSalaryHeadMasterID.Text;
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

        protected void IsActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                CheckBox chk = (CheckBox)sender;
                GridViewRow Row = ((GridViewRow)((Control)sender).Parent.Parent.Parent.Parent);
                CheckBox grdCheckBox = (CheckBox)GridSalaryHead.Rows[Row.RowIndex].FindControl("IsActive");
                Label lblSalaryHeadMasterID = (Label)GridSalaryHead.Rows[Row.RowIndex].Cells[0].FindControl("lblSalaryHeadMasterID");

                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "115";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_GlobalID = lblSalaryHeadMasterID.Text;
                _Parameters.Str_Mode = "Active";
                _Parameters.Bool_IsActive = chk.Checked;
                _Parameters = _Common.ModifiedData(_Parameters);
                if (_Parameters.Str_Status != null)
                {
                    UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                    ClearBox();
                }
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }
    }
}