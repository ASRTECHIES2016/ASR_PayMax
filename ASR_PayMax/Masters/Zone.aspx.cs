using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASR_PayMaxLogic.Models;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using ASR_PayMax.GlobalProjectClass;
using System.Data;
using System.Configuration;

namespace ASR_PayMax.Masters
{
    public partial class Zone : System.Web.UI.Page
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
            hddZoneID.Value = "0";
            txtZoneCode.Text = string.Empty;
            txtZoneName.Text = string.Empty;
            Btn_Submit.Text = "Submit";
            BindData();
        }
        private void BindData()
        {
            HttpResponseMessage response;
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                _Parameters = new ASR_PayMaxParameters();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_SelectID = "109";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetRegion";
                _Common.BindDropDown(this, ddlRegion, _Parameters);
                _Parameters.Str_SelectID = "157";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstZone";
                response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    _DataSet = JsonConvert.DeserializeObject<DataSet>(response.Content.ReadAsStringAsync().Result);
                    if (_DataSet != null)
                    {
                        if (_DataSet.Tables[0] != null)
                        {
                            if (_DataSet.Tables[0].Rows.Count > 0)
                            {
                                GridZone.DataSource = _DataSet.Tables[0];
                                GridZone.DataBind();
                            }
                        }
                    }
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

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (ddlRegion.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Region Name');", true);
                return;
            }
            if (txtZoneName.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Zone Name");
                return;
            }
            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddZoneID.Value != "0")
                {
                    Mode = "Edit";
                }
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SelectID = "157",
                    Str_GlobalID = hddZoneID.Value,
                    Str_GlobalCode = txtZoneCode.Text,
                    Str_GlobalName = txtZoneName.Text,
                    Str_ParentID = ddlRegion.SelectedValue == "Select One" ? "0" : ddlRegion.SelectedValue,
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _Parameters.Str_ApiUrl =  ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsZone";
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

        protected void GridZone_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);

                Label lblZoneMasterID = GridZone.Rows[RowIndex].Cells[0].FindControl("lblZoneMasterID") as Label;
                Label lblZoneCode = GridZone.Rows[RowIndex].Cells[0].FindControl("lblZoneCode") as Label;
                Label lblZoneName = GridZone.Rows[RowIndex].Cells[0].FindControl("lblZoneName") as Label;
                Label lblRegionID = GridZone.Rows[RowIndex].Cells[0].FindControl("lblRegionID") as Label;

                if (e.CommandName == "Change")
                {
                    hddZoneID.Value = lblZoneMasterID.Text;
                    txtZoneCode.Text = lblZoneCode.Text;
                    txtZoneName.Text = lblZoneName.Text;
                    ddlRegion.SelectedValue = lblRegionID.Text;
                    Btn_Submit.Text = "Update";
                }
                if (e.CommandName == "Deleted")
                {
                    var UserDetails = UsersSession.GetSession();
                    _Parameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_SelectID = "157";
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_GlobalID = lblZoneMasterID.Text;
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
                Label lblZoneMasterID = (Label)GridZone.Rows[Row.RowIndex].Cells[0].FindControl("lblZoneMasterID");

                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "157";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_GlobalID = lblZoneMasterID.Text;
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