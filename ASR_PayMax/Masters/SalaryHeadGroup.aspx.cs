using System;
using System.Web.UI;
using ASR_PayMaxLogic.Models;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using ASR_PayMax.GlobalProjectClass;
using System.Data;
using System.Configuration;

namespace ASR_PayMax.Masters
{
    public partial class SalaryHeadGroup1 : System.Web.UI.Page
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
            if (ddlHeadGroupType.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Head Type');", true);
                return;
            }
            if (txtSalaryHeadGroup.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Salary Head Group");
                return;
            }
            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                if (hddSalaryHeadGroupID.Value != "0")
                {
                    Mode = "Edit";
                }
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = "1",
                    Str_SelectID = "114",
                    Str_GlobalID = hddSalaryHeadGroupID.Value,
                    Str_GlobalName = txtSalaryHeadGroup.Text,
                    Str_GlobalCode = ddlHeadGroupType.SelectedValue,
                    Bool_IsActive = true,
                    Str_LoginID = "1"
                };
                _Parameters.Str_ApiUrl =  ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsSalaryHeadGroup";

                HttpContent inputContent = new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, inputContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    _Parameters = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters>(response.Content.ReadAsStringAsync().Result);
                    if (_Parameters.Str_Status != null)
                    {
                        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                        ClearBox();
                    }
                    else
                    {
                        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                    }
                }
                else
                {
                    UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                }
                //    if (response.IsSuccessStatusCode)
                //    {
                //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "ShowSuccess('Saved Successfully');", true);
                //    }
                //    else
                //    {
                //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Sorry');", true);
                //    }
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }
        protected void GridSalaryHeadGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);

                Label lblSalaryHeadGroupMasterID = GridSalaryHeadGroup.Rows[RowIndex].FindControl("lblSalaryHeadGroupMasterID") as Label;
                Label lblSalaryHeadGroupName = GridSalaryHeadGroup.Rows[RowIndex].Cells[0].FindControl("lblSalaryHeadGroupName") as Label;
                Label lblEarningDeduction = GridSalaryHeadGroup.Rows[RowIndex].Cells[0].FindControl("lblEarningDeduction") as Label;
                if (e.CommandName == "Change")
                {
                    hddSalaryHeadGroupID.Value = lblSalaryHeadGroupMasterID.Text;
                    txtSalaryHeadGroup.Text = lblSalaryHeadGroupName.Text;
                    ddlHeadGroupType.SelectedValue = lblEarningDeduction.Text;
                    Btn_Submit.Text = "Update";
                    //  ddlDesignationCategoryID.SelectedValue = lblDesignationCategoryTypeID.Text;
                }
                if (e.CommandName == "Deleted")
                {
                    var UserDetails = UsersSession.GetSession();
                    _Parameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_SelectID = "114";
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_GlobalID = lblSalaryHeadGroupMasterID.Text;
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
                CheckBox grdCheckBox = (CheckBox)GridSalaryHeadGroup.Rows[Row.RowIndex].FindControl("IsActive");
                Label lblSalaryHeadGroupMasterID = (Label)GridSalaryHeadGroup.Rows[Row.RowIndex].Cells[0].FindControl("lblSalaryHeadGroupMasterID");

                //         var UserDetails = UsersSession.GetSession();
                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "114";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_GlobalID = lblSalaryHeadGroupMasterID.Text;
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

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearBox();
        }

        private void ClearBox()
        {
            hddSalaryHeadGroupID.Value = "0";
            txtSalaryHeadGroup.Text = string.Empty;
            //    txtSequenceNo.Text = string.Empty;
            //    txtSalaryHeadName.Text = string.Empty;
            Btn_Submit.Text = "Submit";
            ddlHeadGroupType.SelectedIndex = 0;
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
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstSalaryHeadGroup";
                _Common.BindGrid(this, GridSalaryHeadGroup, _Parameters);
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
                //                GridSalaryHeadGroup.DataSource = _DataSet.Tables[0];
                //                GridSalaryHeadGroup.DataBind();
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                //}
                //if (response.IsSuccessStatusCode)
                //{
                //    _DataSet = JsonConvert.DeserializeObject<DataSet>(response.Content.ReadAsStringAsync().Result);
                //    if (_DataSet != null)
                //    {
                //        if (_DataSet.Tables[0] != null)
                //        {
                //            if (_DataSet.Tables[0].Rows.Count > 0)
                //            {
                //                //gri.DataSource = _DataSet.Tables[0];
                //                //GridDesignation.DataBind();
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

    }
}