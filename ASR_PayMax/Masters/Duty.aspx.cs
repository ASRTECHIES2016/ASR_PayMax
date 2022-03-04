using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASR_PayMaxLogic.Models;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using ASR_PayMax.GlobalProjectClass;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;

namespace ASR_PayMax.Masters
{
    public partial class Duty : System.Web.UI.Page
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
            if (txtDutyName.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter Duty');", true);
                return;
            }


            if (!Regex.Match(txtDutyName.Text, @"[a-zA-Z0-9]+").Success)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Special Character Not Allowed');", true);
                return;
            }

            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddDutyID.Value != "0")
                {
                    Mode = "Edit";
                }
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SelectID = "51",
                    Str_GlobalID = hddDutyID.Value,
                    Str_GlobalName = txtDutyName.Text,
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _Parameters.Str_ApiUrl =  ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsDuty";
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
            hddDutyID.Value = "0";
            txtDutyName.Text = string.Empty;
            Btn_Submit.Text = "Submit";
            BindData();
        }

        protected void GridDuty_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);


                Label lblDutyID = (Label)GridDuty.Rows[RowIndex].Cells[0].FindControl("lblDutyID");
                Label lblDutyName = (Label)GridDuty.Rows[RowIndex].Cells[0].FindControl("lblDutyName");

                if (e.CommandName == "Change")
                {
                    hddDutyID.Value = lblDutyID.Text;
                    txtDutyName.Text = lblDutyName.Text;
                    Btn_Submit.Text = "Update";
                }
                if (e.CommandName == "Deleted")
                {
                    var UserDetails = UsersSession.GetSession();
                    _Parameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_SelectID = "51";
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_GlobalID = lblDutyID.Text;
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
            catch (Exception _Exception)
            {
                UsersSession.GetMessages(this, "Failure", _Exception.Message);
            }
        }

        protected void IsActive_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                var UserDetails = UsersSession.GetSession();
                CheckBox chk = (CheckBox)sender;
                GridViewRow Row = ((GridViewRow)((Control)sender).Parent.Parent.Parent.Parent);
                Label lblDutyID = (Label)GridDuty.Rows[Row.RowIndex].Cells[0].FindControl("lblDutyID");
                Label lblDutyName = (Label)GridDuty.Rows[Row.RowIndex].Cells[0].FindControl("lblDutyName");


                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "51";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_GlobalID = lblDutyID.Text;
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
            catch (Exception _Exception)
            {
                UsersSession.GetMessages(this, "Failure", _Exception.Message);
            }

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
                _Parameters.Str_SelectID = "51";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;

                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstDuty";
                _Common.BindGrid(this, GridDuty, _Parameters);
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
                //                GridDuty.DataSource = _DataSet.Tables[0];
                //                GridDuty.DataBind();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        UsersSession.GetMessages(this, "Warning", "Data not available");
                //    }
                //}

                //if (response.IsSuccessStatusCode)
                //{
                //    ASR_PayMaxParameters[] arr = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters[]>(response.Content.ReadAsStringAsync().Result);
                //    if (arr[0].Str_Status == "Get")
                //    {
                //        GridDuty.DataSource = arr;
                //        GridDuty.DataBind();
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
    }
}