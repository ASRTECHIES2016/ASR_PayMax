using ASR_PayMax.GlobalProjectClass;
using ASR_PayMaxLogic.Models;
using System;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASR_PayMax.AccessRights
{
    public partial class AccUserWiseRights : System.Web.UI.Page
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
                _Common.BindDropDown(this, ddlRoleName, _Parameters); DataTable _DataTable = new DataTable();
                ASR_PayMaxParameters[] arr;
                DataRow dr;
                TemplateField tfield;
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_SelectID = "98";
                _Parameters.Str_GlobalID = "2";
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
                                if (GridAccessRight.Columns.Count != (arr.Length + 2))
                                {
                                    for (int i = 0; i < arr.Length; i++)
                                    {
                                        tfield = new TemplateField();
                                        tfield.HeaderText = Convert.ToString(arr[i].Str_GlobalName);
                                        GridAccessRight.Columns.Add(tfield);
                                        _DataTable.Columns.Add(arr[i].Str_GlobalName, typeof(string));
                                    }
                                }
                                _DataTable.AcceptChanges();
                                GridAccessRight.DataSource = _DataTable;
                                GridAccessRight.DataBind();
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
            if (txtUserName.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select User Name');", true);
                return;
            }
            if (hddUserID.Value.Trim() == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select User Name');", true);
                return;
            }
            string _Data = string.Empty, ID;
            foreach (GridViewRow row1 in GridAccessRight.Rows)
            {
                ID = string.Empty;
                ID = (row1.Cells[1].FindControl("lblPID") as Label).Text;
                for (int i = 1; i < (GridAccessRight.Columns.Count - 1); i++)
                {
                    CheckBox chkRow = (row1.Cells[i + 1].FindControl(("chk" + (GridAccessRight.Columns[i + 1])).Replace(" ", "")) as CheckBox);
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
            _Parameters.Str_ParentID ="2";
            _Parameters.Str_RoleID = ddlRoleName.SelectedValue;
            _Parameters.Str_MenuID = _Data;
            _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsUserWiseRights";
            if (_Common.IUMasters(this, _Parameters))
            {
                ClearBox();
            }

        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearBox();
        }

        protected void ddlRoleName_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (ddlRoleName.SelectedIndex > 0)
                {
                    var UserDetails = UsersSession.GetSession();
                    _Parameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common(); DataTable _DataTable = new DataTable();
                    ASR_PayMaxParameters[] arr;
                    DataRow dr;
                    TemplateField tfield;
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_RoleID = ddlRoleName.SelectedValue;
                    _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetUserRoleRightMenu";
                    response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json")).Result;

                    if (response.IsSuccessStatusCode)
                    {
                         _DataTable = new JavaScriptSerializer().Deserialize<DataTable>(response.Content.ReadAsStringAsync().Result);
                        if (_DataTable.Rows.Count>0)
                        {
                           
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


        //public void Run()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        DataTable dt1 = new DataTable();
        //        SqlConnection scn = new SqlConnection(@"Data Source=LAPTOP-9C2VMCUV;Initial Catalog=PNDC;Integrated Security=True;");
        //        scn.Open();
        //        SqlCommand scmd2 = new SqlCommand("Proc_Mst_GetMenuDetails", scn)
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };
        //        scmd2.Parameters.AddWithValue("@MenuID", 0);
        //        SqlDataAdapter da2 = new SqlDataAdapter(scmd2);
        //        da2.Fill(dt);
        //        if (dt.Rows.Count > 0)
        //        {
        //            SqlCommand scmd1 = new SqlCommand("select * from Mst_AccessType", scn)
        //            {
        //                CommandType = CommandType.Text
        //            };
        //            SqlDataAdapter da1 = new SqlDataAdapter(scmd1);

        //            da1.Fill(dt1);
        //            for (int i = 0; i < dt1.Rows.Count; i++)
        //            {
        //                TemplateField tfield = new TemplateField();
        //                tfield.HeaderText = Convert.ToString(dt1.Rows[i][1]);
        //                GridAccessRight.Columns.Add(tfield);
        //            }

        //            GridAccessRight.DataSource = dt;
        //            GridAccessRight.DataBind();
        //            int count = 1;
        //            foreach (GridViewRow row1 in GridAccessRight.Rows)
        //            {
        //                for (int i = 3; i <= (dt1.Rows.Count) + 2; i++)
        //                {
        //                    CheckBox chk = new CheckBox();


        //                    //         UpdatePanel update = new UpdatePanel();
        //                    chk.ID = (row1.Cells[1].FindControl("lblPID") as Label).Text + "." + count;
        //                    //       update.ID = "UpdatePnl" + chk.ID;
        //                    //        update.UpdateMode = UpdatePanelUpdateMode.Always;
        //                    chk.Attributes["runat"] = "server";
        //                    chk.ClientIDMode = ClientIDMode.Static;
        //                    //               chk.AutoPostBack = true;
        //                    //                chk.CheckedChanged += chechkBoxChanged;
        //                    //        update.ContentTemplateContainer.Controls.Add(chk);
        //                    //      AsyncPostBackTrigger async = new AsyncPostBackTrigger();
        //                    //    async.ControlID = chk.ID;
        //                    //  async.EventName = "CheckedChanged";
        //                    //update.Triggers.Add(async);
        //                    //       update.Controls.Add(chk);
        //                    row1.Cells[i].Controls.Add(chk);

        //                    count++;
        //                }
        //                count = 1;
        //            }
        //        }
        //        scn.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        e.ToString();
        //    }
        //}
        //public void chechkBoxChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string ID = (sender as CheckBox).ID;
        //        string[] selectedchk = ID.Split('.');

        //        if (selectedchk[1] == "1")
        //        {
        //            foreach (GridViewRow row1 in GridAccessRight.Rows)
        //            {
        //                CheckBox chkAll = (CheckBox)row1.FindControl(selectedchk[0] + "." + Convert.ToString(Convert.ToInt32(selectedchk[1])));     //for All
        //                if (chkAll != null)
        //                {
        //                    if (chkAll.Checked)
        //                    {
        //                        for (int i = 2; i < (GridAccessRight.Columns.Count); i++)
        //                        {
        //                            CheckBox chkRow = (row1.FindControl(selectedchk[0] + "." + Convert.ToString(i)) as CheckBox);
        //                            chkRow.Enabled = true;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        for (int i = 2; i <= (GridAccessRight.Columns.Count) + 2; i++)
        //                        {
        //                            CheckBox chkRow = (row1.FindControl(selectedchk[0] + "." + Convert.ToString(i)) as CheckBox);
        //                            if ((chkRow.Checked))
        //                            {
        //                                chkRow.Checked = false;
        //                            }
        //                            chkRow.Enabled = false;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }
        //}
    }
}