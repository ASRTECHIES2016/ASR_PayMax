using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASR_PayMaxLogic.Models;
using System.Data;
using ASR_PayMax.GlobalProjectClass;
using System.Configuration;
using System.Net.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Text;

namespace ASR_PayMax.Masters
{
    public partial class Branch : System.Web.UI.Page
    {
        ASR_PayMaxParameters _Parameters;
        ASR_Common _Common;
        DataSet _DataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtBranchCode.Attributes.Add("readonly", "readonly");
            if (!IsPostBack)
            {
                ClearBox();
                if (Convert.ToString(Session["RedirectID"]) != "")
                {
                    ChangeBranchDetails(Convert.ToString(Session["RedirectID"]));
                    Session["RedirectID"] = null;
                }
            }
        }

        private void ChangeBranchDetails(string Str_RedirectID)
        {
            try
            {
                var UserDetails = UsersSession.GetSession();

                _Common = new ASR_Common();

                _Parameters = new ASR_PayMaxParameters
                {
                    Str_GlobalID = Str_RedirectID,
                    Str_CompanyID = "1",
                    Str_SelectID = "22"
                };

                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstBranch";

                _DataSet = _Common._ReturnDataSet(_Parameters);

                if (_DataSet != null)
                {
                    if (_DataSet.Tables.Count > 0)
                    {
                        hddBranchID.Value = Str_RedirectID;

                        //Convert.ToString(_DataSet.Tables[0].Rows[0]["BranchMasterID"]);
                        //Convert.ToString(_DataSet.Tables[0].Rows[0]["CompanyID"]);
                        txtBranchCode.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["BranchCode"]);
                        //txtBranchNo.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["ShortCode"]);
                        txtBranchName.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["BranchName"]);
                        //         Convert.ToString(_DataSet.Tables[0].Rows[0]["CompanyName"]);
                        ddlRegion.SelectedValue = Convert.ToString(_DataSet.Tables[0].Rows[0]["RegionID"]);
                        ddlCountry.SelectedValue = Convert.ToString(_DataSet.Tables[0].Rows[0]["CountryID"]);
                        //       txtBranchCode.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["RegionName"]);
                        //         star.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["BranchStartDate"]);
                        txtTelNo1.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["Telephone1"]);
                        txtTelNo2.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["Telephone2"]);
                        //    tx.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["Fax"]);
                        //       txtBranchCode.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["PF_No"]);
                        //       txtBranchCode.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["ESIC_No"]);
                        //       txtBranchCode.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["PT"]);
                        //       txtBranchCode.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["LWF"]);
                        txtPayProAccNo.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["PayProBankAccountNo"]);
                        //          tx.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["PayProBranchCode"]);
                        chkIsAdmin.Checked = Convert.ToBoolean(_DataSet.Tables[0].Rows[0]["IsAdminChargesApplicable"]);
                        //Convert.ToString(_DataSet.Tables[0].Rows[0]["AtnOpenMonthID"]);
                        //           ddlsele = Convert.ToString(_DataSet.Tables[0].Rows[0]["AtnOpenMonth"]);
                        //Convert.ToString(_DataSet.Tables[0].Rows[0]["AtnOpenYearID"]);
                        //           txtBranchCode.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["AtnOpenYear"]);
                        //Convert.ToString(_DataSet.Tables[0].Rows[0]["StaffOpenMonthID"]);
                        //           txtBranchCode.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["StaffOpenMonth"]);
                        //Convert.ToString(_DataSet.Tables[0].Rows[0]["StaffOpenYearID"]);
                        //           txtBranchCode.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["StaffOpenYear"]);
                        txtAddress1.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["Address1"]);
                        txtAddress2.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["Address2"]);
                        txtPincode.Text = Convert.ToString(_DataSet.Tables[0].Rows[0]["PinCode"]);
                        //                 chkIsAdmin.Checked = Convert.ToBoolean(_DataSet.Tables[0].Rows[0]["Active"]);


                    }
                    if (_DataSet.Tables.Count > 1)
                    {
                        Gridview2.DataSource = _DataSet.Tables[1];
                        Gridview2.DataBind();

                        for (int i = 0; i < _DataSet.Tables[1].Rows.Count; i++)
                        {
                            TextBox box1 = (TextBox)Gridview2.Rows[i].Cells[1].FindControl("txtDescription");
                            TextBox box2 = (TextBox)Gridview2.Rows[i].Cells[2].FindControl("txtName");
                            TextBox box3 = (TextBox)Gridview2.Rows[i].Cells[3].FindControl("txtContactNo");
                            TextBox box4 = (TextBox)Gridview2.Rows[i].Cells[4].FindControl("txtEmail");
                            box1.Text = _DataSet.Tables[1].Rows[i]["Descriptions"].ToString();
                            box2.Text = _DataSet.Tables[1].Rows[i]["ContactName"].ToString();
                            box3.Text = _DataSet.Tables[1].Rows[i]["ContactNo"].ToString();
                            box4.Text = _DataSet.Tables[1].Rows[i]["EmailID"].ToString();
                        }
                    }
                }

            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            string Mode = "Add";
            try
            {
                if (txtBranchName.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Enter Branch Name');", true);
                    return;
                }

                if (ddlRegion.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Region Name');", true);
                    return;
                }

                _DataSet = new DataSet();

                if (((DataTable)ViewState["CurrentTable"]).Rows.Count == 0)
                {

                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                    DataRow drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    dtCurrentTable.Rows[0]["Descriptions"] = "NA";
                    dtCurrentTable.Rows[0]["ContactName"] = "NA";
                    dtCurrentTable.Rows[0]["ContactNo"] = "0";
                    dtCurrentTable.Rows[0]["EmailID"] = "NA";
                    dtCurrentTable.Rows[0]["DesignationID"] = "0";

                    drCurrentRow["ContactDetailID"] = dtCurrentTable.Rows.Count;
                    ViewState["CurrentTable"] = dtCurrentTable;
                }

                _DataSet.Tables.Add((DataTable)ViewState["CurrentTable"]);
                if (_DataSet.Tables[0].Rows.Count > 1)
                {
                    _DataSet.Tables[0].Rows.RemoveAt(_DataSet.Tables[0].Rows.Count - 1);
                }
                _DataSet.Tables[0].TableName = "PersonDetails";

                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddBranchID.Value != "0")
                { Mode = "Edit"; }
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = "1",
                    Str_BranchID = hddBranchID.Value,
                    Str_BranchCode = txtBranchCode.Text,
                    Str_BranchName = txtBranchName.Text,
                    Str_ShortCode = "0", // txtBranchNo.Text,
                    Str_RegionID = ddlRegion.SelectedValue == "Select One" || ddlRegion.SelectedValue == "" ? "0" : ddlRegion.SelectedValue,
                    //        Str_BranchID = "0",
                   Str_CountryID= ddlCountry.SelectedValue == "Select One" || ddlCountry.SelectedValue == "" ? "0" : ddlCountry.SelectedValue,
                    Str_AddressOne = txtAddress1.Text,
                    Str_AddressTwo = txtAddress2.Text,
                    Str_CityID = ddlCity.SelectedValue == "Select One" || ddlCity.SelectedValue == "" ? "0" : ddlCity.SelectedValue,
                    Str_StateID = ddlState.SelectedValue == "Select One" || ddlState.SelectedValue == "" ? "0" : ddlState.SelectedValue,
                    Str_DistricID = "0",
                    Str_TehshilID = "0",
                    Str_Pincode = hddPinCode.Value == "" ? "0" : hddPinCode.Value,
                    Str_FaxAddress = "0",
                    Str_ContactNoOne = txtTelNo1.Text,
                    Str_ContactNoTwo = txtTelNo2.Text,
                    Str_ApproverUserID = "0",
                    Str_PayProBranchCode = txtPayProAccNo.Text,
                    Str_PayProBankAccountNo = txtPayProAccNo.Text,
                    Bool_IsAdminChargesApplicable = chkIsAdmin.Checked,
                    Bool_IsActive = true,
                   // _DataSet = _DataSet,
                    Str_LoginID = "1"
                };
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsBranchMaster";


                HttpContent inputContent = new StringContent(JsonConvert.SerializeObject(_Parameters, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }), Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, inputContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    _Parameters = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters>(response.Content.ReadAsStringAsync().Result);
                    if (_Parameters.Str_Status != null)
                    {
                        if (_Parameters.Str_Status == "Success")
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
                }
                else
                {
                    UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                }

                //if (_Common.IUMasters(this, _Parameters))
                //{
                //    ClearBox();
                //}
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
            hddBranchID.Value = "0";
            txtBranchCode.Text = string.Empty;
            txtBranchName.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtPayProAccNo.Text = string.Empty;
            txtPincode.Text = string.Empty;
            txtTelNo1.Text = string.Empty;
            txtTelNo2.Text = string.Empty;
            Btn_Submit.Text = "Submit";
            BindData();
            SetInitialRow();
        }
        private void BindData()
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                _Parameters = new ASR_PayMaxParameters();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                //_Parameters.Str_SelectID = "13";
                //_Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                //_Common.BindDropDown(this, ddlERPBranch, _Parameters);
                _Parameters.Str_SelectID = "109";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetRegion";
                _Common.BindDropDown(this, ddlRegion, _Parameters);
                _Parameters.Str_SelectID = "43";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetCountry";
                _Common.BindDropDown(this, ddlCountry, _Parameters);
                _Parameters.Str_SelectID = "140";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetState";
                _Common.BindDropDown(this, ddlState, _Parameters);
                //_Parameters.Str_SelectID = "159";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetCity";
                _Common.BindDropDown(this, ddlCity, _Parameters);
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        protected void lknButton_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowID(dt);
                    }
                }
                ViewState["CurrentTable"] = dt;
                Gridview2.DataSource = dt;
                Gridview2.DataBind();
            }
            SetPreviousData();
        }

        protected void Gridview2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                LinkButton lb = (LinkButton)e.Row.FindControl("lknButton");
                Button btn = (Button)e.Row.FindControl("ButtonAdd");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                        else
                        {
                            btn.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("ContactDetailID", typeof(string)));
            dt.Columns.Add(new DataColumn("Descriptions", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("ContactName", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("ContactNo", typeof(string)));//for DropDownList selected item   
            dt.Columns.Add(new DataColumn("EmailID", typeof(string)));//for DropDownList selected item   
            dt.Columns.Add(new DataColumn("DesignationID", typeof(string)));//for DropDownList selected item   

            dr = dt.NewRow();
            dr["ContactDetailID"] = 1;
            dr["Descriptions"] = string.Empty;
            dr["ContactName"] = string.Empty;
            dr["ContactNo"] = string.Empty;
            dr["EmailID"] = string.Empty;
            dr["DesignationID"] = string.Empty;
            dt.Rows.Add(dr);
            ViewState["CurrentTable"] = dt;
            Gridview2.DataSource = dt;
            Gridview2.DataBind();
        }

        private void AddNewRowToGrid()
        {
            try
            {
                if (ViewState["CurrentTable"] != null)
                {

                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                    DataRow drCurrentRow = null;

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            TextBox box1 = (TextBox)Gridview2.Rows[i].Cells[1].FindControl("txtDescription");
                            TextBox box2 = (TextBox)Gridview2.Rows[i].Cells[2].FindControl("txtName");
                            TextBox box3 = (TextBox)Gridview2.Rows[i].Cells[3].FindControl("txtContactNo");
                            TextBox box4 = (TextBox)Gridview2.Rows[i].Cells[4].FindControl("txtEmail");

                            if (box2.Text == "")
                            {
                                UsersSession.GetMessages(this, "Failure", "Enter Person Name Before Adding New Row.");
                                //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Failure", "showToast('Failure','Enter Person Name Before Adding New Row',2000);", true);
                                box2.Focus();
                                return;
                            }
                            if (box1.Text == "")
                            {
                                UsersSession.GetMessages(this, "Failure", "Enter Designation Before Adding New Row.");
                                //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Failure", "showToast('Failure','Enter Descriptions Before Adding New Row',2000);", true);
                                box1.Focus();
                                return;
                            }
                            if (box3.Text == "")
                            {
                                UsersSession.GetMessages(this, "Failure", "Enter Contact Before Adding New Row.");
                                //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Failure", "showToast('Failure','Enter Contact Before Adding New Row',2000);", true);
                                box3.Focus();
                                return;
                            }
                            if (box4.Text == "")
                            {
                                UsersSession.GetMessages(this, "Failure", "Enter EmailID Before Adding New Row.");
                                //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Failure", "showToast('Failure','Enter EmailID Before Adding New Row',2000);", true);
                                box4.Focus();
                                return;
                            }

                            dtCurrentTable.Rows[i]["Descriptions"] = box1.Text;
                            dtCurrentTable.Rows[i]["ContactName"] = box2.Text;
                            dtCurrentTable.Rows[i]["ContactNo"] = box3.Text;
                            dtCurrentTable.Rows[i]["EmailID"] = box4.Text;
                            dtCurrentTable.Rows[i]["DesignationID"] = "0";
                        }


                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["ContactDetailID"] = dtCurrentTable.Rows.Count + 1;
                        dtCurrentTable.Rows.Add(drCurrentRow);
                        ViewState["CurrentTable"] = dtCurrentTable;

                        Gridview2.DataSource = dtCurrentTable;
                        Gridview2.DataBind();
                        if (Gridview2.Rows.Count > 0)
                        {
                            TextBox box1 = (TextBox)Gridview2.Rows[Gridview2.Rows.Count - 1].Cells[1].FindControl("txtDescription");
                            box1.Focus();
                        }
                    }
                }
                else
                {
                    Response.Write("ViewState is null");
                }
                SetPreviousData();
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)Gridview2.Rows[i].Cells[1].FindControl("txtDescription");
                        TextBox box2 = (TextBox)Gridview2.Rows[i].Cells[2].FindControl("txtName");
                        TextBox box3 = (TextBox)Gridview2.Rows[i].Cells[3].FindControl("txtContactNo");
                        TextBox box4 = (TextBox)Gridview2.Rows[i].Cells[4].FindControl("txtEmail");
                        if (i < dt.Rows.Count - 1)
                        {
                            box1.Text = dt.Rows[i]["Descriptions"].ToString();
                            box2.Text = dt.Rows[i]["ContactName"].ToString();
                            box3.Text = dt.Rows[i]["ContactNo"].ToString();
                            box4.Text = dt.Rows[i]["EmailID"].ToString();
                            //    dt.Rows[i]["DesignationID"] .ToString();
                        }
                        rowIndex++;
                    }
                }
            }
        }
        private void ResetRowID(DataTable dt)
        {
            int ContactDetailID = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = ContactDetailID;
                    ContactDetailID++;
                }
            }
        }

    }
}