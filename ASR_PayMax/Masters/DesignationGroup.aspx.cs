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

namespace ASR_PayMax.Masters
{
    public partial class DesignationGroup : System.Web.UI.Page
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
            try
            {
                if (txtDesignationGroupName.Text.Trim()=="")
                {
                    UsersSession.GetMessages(this, "Warning", "Please Enter Designation Group");
                    return;
                }
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddDesignationGroupID.Value != "0")
                {
                    Mode = "Edit";
                }
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SelectID = "46",
                    Str_GlobalID = hddDesignationGroupID.Value,
                    Str_GlobalName = txtDesignationGroupName.Text,
                    Str_ParentID = "0",
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };

                _Parameters.Str_ApiUrl =  ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsDesignationGroup";
                if (_Common.IUMasters(this, _Parameters))
                {
                    ClearBox();
                }
                //HttpContent inputContent = new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json");
                //HttpResponseMessage response = new HttpClient().PostAsync(apiUrl, inputContent).Result;

                //if (response.IsSuccessStatusCode)
                //{
                //    _Parameters = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters>(response.Content.ReadAsStringAsync().Result);
                //    if (_Parameters != null)
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
                ex.ToString();
            }


        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearBox();
        }

        private void ClearBox()
        {
            hddDesignationGroupID.Value = "0";
            txtDesignationGroupName.Text = string.Empty;
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

                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "46";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstDesignationGroup";
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
                                GridDesignationGroup.DataSource = _DataSet.Tables[0];
                                GridDesignationGroup.DataBind();
                            }
                        }
                    }
                    else
                    {
                        UsersSession.GetMessages(this, "Warning", "Data not available");
                    }
                }
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        protected void GridDesignationGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);
                Label lblDesignationGroupID = GridDesignationGroup.Rows[RowIndex].Cells[0].FindControl("lblDesignationGroupID") as Label;
                Label lblDesignationGroupName = GridDesignationGroup.Rows[RowIndex].Cells[0].FindControl("lblDesignationGroupName") as Label;
                if (e.CommandName == "Change")
                {
                    hddDesignationGroupID.Value = lblDesignationGroupID.Text;
                    txtDesignationGroupName.Text = lblDesignationGroupName.Text;
                    Btn_Submit.Text = "Update";
                }
                if (e.CommandName == "Deleted")
                {
                    var UserDetails = UsersSession.GetSession();
                    _Parameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_SelectID = "46";
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_GlobalID = lblDesignationGroupID.Text;
                    _Parameters.Str_Mode = "Delete";
                    _Parameters = _Common.ModifiedData(_Parameters);
                    if (_Parameters != null)
                    {
                        ClearBox();
                        UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
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
                CheckBox grdCheckBox = (CheckBox)GridDesignationGroup.Rows[Row.RowIndex].FindControl("IsActive");
                Label lblDesignationGroupID = (Label)GridDesignationGroup.Rows[Row.RowIndex].Cells[0].FindControl("lblDesignationGroupID");

                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "46";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_GlobalID = lblDesignationGroupID.Text;
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
                _Exception.ToString();
            }

        }
    }
}