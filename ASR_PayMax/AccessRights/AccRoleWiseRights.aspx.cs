using ASR_PayMax.GlobalProjectClass;
using ASR_PayMaxLogic.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASR_PayMax.AccessRights
{
    public partial class AccRoleWiseRights : System.Web.UI.Page
    {
        HttpResponseMessage response;
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
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_SelectID = "94";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignationCategory";
                _Common.BindDropDown(this, ddlRoleName, _Parameters);
                _Parameters.Str_SelectID = "98";
                _Parameters.Str_GlobalID = "0";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignationCategory";
                _Common.BindDropDown(this, ddlMenuMaster, _Parameters);
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }



        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (ddlRoleName.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Role Name');", true);
                return;
            }
            if (ddlMenuMaster.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Menu Name');", true);
                return;
            }
            string _Data = string.Empty, ID;
            foreach (GridViewRow row1 in GridAccessRole.Rows)
            {
                ID = string.Empty;
                ID = (row1.Cells[1].FindControl("lblPID") as Label).Text;
                for (int i = 1; i < (GridAccessRole.Columns.Count - 1); i++)
                {
                    CheckBox chkRow = (row1.Cells[i + 1].FindControl(("chk" + (GridAccessRole.Columns[i + 1])).Replace(" ", "")) as CheckBox);
                    if (chkRow != null)
                    {
                        if (chkRow.Checked)
                        {
                            _Data += ID + "." + i + ",";
                        }
                    }
                }
            }
            _Data = _Data.Substring(0, _Data.Length - 1);

            if (_Data.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Atleast One Menu.');", true);
                return;
            }

            var UserDetails = UsersSession.GetSession();
            _Parameters = new ASR_PayMaxParameters();
            _Common = new ASR_Common();
            _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
            _Parameters.Str_LoginID = UserDetails.Str_LoginID;
            _Parameters.Str_RoleID = ddlRoleName.SelectedValue;
            _Parameters.Str_ParentID = ddlMenuMaster.SelectedValue;
            _Parameters.Str_MenuID = _Data;
            _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsIURoleRights";
            if (_Common.IUMasters(this, _Parameters))
            {
                ClearBox();
            }

        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearBox();
        }

        protected void ddlMenuMaster_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (ddlMenuMaster.SelectedIndex > 0)
                {
                    var UserDetails = UsersSession.GetSession();
                    _Parameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common(); DataTable _DataTable = new DataTable();
                    ASR_PayMaxParameters[] arr;
                    DataRow dr;
                    TemplateField tfield;
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_SelectID = "98";
                    _Parameters.Str_GlobalID = ddlMenuMaster.SelectedValue;
                    _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignationCategory";
                    response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json")).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        arr = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters[]>(response.Content.ReadAsStringAsync().Result);
                        if (arr[0].Str_Status == "Get")
                        {
                            _DataTable.Columns.Add("MenuID", typeof(string));
                            _DataTable.Columns.Add("MenuName", typeof(string));

                            for (int i = 0; i < arr.Length; i++)
                            {
                                dr = _DataTable.NewRow();
                                dr["MenuID"] = arr[i].Str_GlobalID;
                                dr["MenuName"] = arr[i].Str_GlobalName;
                                _DataTable.Rows.Add(dr);
                            }
                            _DataTable.AcceptChanges();
                            _Parameters.Str_SelectID = "89";
                            _Parameters.Str_GlobalID = "0";
                            _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetAccessRights";
                            response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json")).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                arr = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters[]>(response.Content.ReadAsStringAsync().Result);
                                if (arr[0].Str_Status == "Get")
                                {
                                    if (GridAccessRole.Columns.Count != (arr.Length + 2))
                                    {
                                        for (int i = 0; i < arr.Length; i++)
                                        {
                                            tfield = new TemplateField();
                                            tfield.HeaderText = Convert.ToString(arr[i].Str_GlobalName);
                                            GridAccessRole.Columns.Add(tfield);
                                            _DataTable.Columns.Add(arr[i].Str_GlobalName, typeof(string));
                                        }
                                    }
                                    _DataTable.AcceptChanges();
                                    GridAccessRole.DataSource = _DataTable;
                                    GridAccessRole.DataBind();
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
                        }
                        else
                        {
                            UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        protected void GridAccessRole_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CheckBox chk;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 1; i < e.Row.Cells.Count - 1; i++)
                {
                    chk = new CheckBox();
                    chk.ID = (e.Row.Cells[1].FindControl("lblPID") as Label).Text + "." + i;
                    chk.EnableViewState = true;
                    //             chk.ClientIDMode = ClientIDMode.Static;
                    e.Row.Cells[i + 1].Controls.Add(chk);
                }
            }


            //foreach (GridViewRow row in GridAccessRole.Rows)
            //{
            //    for (int i = 1; i < row.Cells.Count - 1; i++)
            //    {
            //        chk = new CheckBox();
            //        chk.ID = (row.Cells[1].FindControl("lblPID") as Label).Text + "." + i;
            //        chk.Text = (row.Cells[1].FindControl("lblPID") as Label).Text + "." + i;
            //        //       chk.Attributes["runat"] = "server";
            //        chk.EnableViewState = true;
            //        chk.ClientIDMode = ClientIDMode.Static;
            //        row.Cells[i + 1].Controls.Add(chk);
            //    }
            //}

        }
    }
}