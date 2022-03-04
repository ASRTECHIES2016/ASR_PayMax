using ASR_PayMax.GlobalProjectClass;
using ASR_PayMaxLogic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASR_PayMax.Transactions
{
    public partial class MonthAttendance : System.Web.UI.Page
    {
        SiteMasterParameters _SiteMaster;
        ASR_Common _Common;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearBox();
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (ddlBranch.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Branch Name");
                return;
            }
            if (ddlClient.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Client Name");
                return;
            }
            if (ddlSite.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Site Name");
                return;
            }
            if (ddlMonth.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Month Name");
                return;
            }
            if (ddlYear.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Year Name");
                return;
            }

            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();

                for (int i = 0; i < GridMonthAttendance.Rows.Count; i++)
                {

                    //        Label lblDesignationID = GridMonthAttendance.Rows[i].Cells[0].FindControl("lblDesignationID") as Label;
                    //         string lblEmployeeCode = (GridMonthAttendance.Rows[i].Cells[1].FindControl("lblEmployeeCode") as TextBox).Text;
                    //string txtGrossSalary = (GridMonthAttendance.Rows[i].Cells[6].FindControl("txtGrossSalary") as TextBox).Text;

                    dt = (DataTable)ViewState["MonthAttendanceDetails"];
                    dt.TableName = "MonthAttendanceDetails";
                    DataRow dr;
                    if (dt != null)
                    {
                        dr = dt.NewRow();
                        dr["MonthAttendanceID"] = "0";
                        dr["EmployeeID"] = (GridMonthAttendance.Rows[i].Cells[0].FindControl("lblEmployeeID") as Label).Text;
                        dr["MonthNames"] = ddlMonth.SelectedValue == "Select One" ? "0" : ddlMonth.SelectedValue;
                        dr["YearName"] = ddlYear.SelectedValue == "Select One" ? "0" : ddlYear.SelectedValue;
                        dr["MonthDays"] = (GridMonthAttendance.Rows[i].Cells[4].FindControl("txtMonthDays") as TextBox).Text;
                        dr["EmpMonthDays"] = (GridMonthAttendance.Rows[i].Cells[5].FindControl("txtEmpMonthDays") as TextBox).Text;
                        dr["DesignationID"] = (GridMonthAttendance.Rows[i].Cells[5].FindControl("ddlDesignationID") as DropDownList).SelectedValue == "Select One" ? "0" : (GridMonthAttendance.Rows[i].Cells[5].FindControl("ddlDesignationID") as DropDownList).SelectedValue;
                        dr["DutyID"] = (GridMonthAttendance.Rows[i].Cells[5].FindControl("ddlDuty") as DropDownList).SelectedValue == "Select One" ? "0" : (GridMonthAttendance.Rows[i].Cells[5].FindControl("ddlDuty") as DropDownList).SelectedValue;// ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue;
                        dr["SiteID"] = ddlSite.SelectedValue == "Select One" ? "0" : ddlSite.SelectedValue;
                        dr["AssignSiteID"] = "0";
                        dr["BranchID"] = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue;
                        dr["NormalDays"] = (GridMonthAttendance.Rows[i].Cells[7].FindControl("txtNormalDays") as TextBox).Text;
                        dr["WeeklyOff"] = (GridMonthAttendance.Rows[i].Cells[8].FindControl("txtWeeklyOff") as TextBox).Text;
                        dr["PaidHolidays"] = (GridMonthAttendance.Rows[i].Cells[9].FindControl("txtPaidHolidays") as TextBox).Text;
                        dr["OTDays"] = (GridMonthAttendance.Rows[i].Cells[10].FindControl("txtOTDays") as TextBox).Text;
                        dr["OTHours"] = (GridMonthAttendance.Rows[i].Cells[11].FindControl("txtOTHours") as TextBox).Text;
                        dr["CreatedBy"] = UserDetails.Str_LoginID;
                        dr["SplOTDays"] = (GridMonthAttendance.Rows[i].Cells[12].FindControl("txtSpOTDays") as TextBox).Text;
                        dr["SplOTHours"] = (GridMonthAttendance.Rows[i].Cells[13].FindControl("txtSpOTHours") as TextBox).Text;
                        dr["PL"] = (GridMonthAttendance.Rows[i].Cells[14].FindControl("txtPaidLeave") as TextBox).Text;
                        dr["CL"] = (GridMonthAttendance.Rows[i].Cells[15].FindControl("txtCasualLeave") as TextBox).Text;
                        dr["SL"] = (GridMonthAttendance.Rows[i].Cells[16].FindControl("txtSickLeave") as TextBox).Text;
                        dr["WebAtn"] = true;
                        dt.Rows.Add(dr);
                        //                   ViewState["MonthAttendanceDetails"] = dt;
                    }
                }
                //          dt.Rows.RemoveAt(0);
                //          dt.AcceptChanges();
                //            dt.Rows.RemoveAt(1);
                //            dt.AcceptChanges();
                _SiteMaster = new SiteMasterParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    _DataTable = dt,
                    Str_LoginID = UserDetails.Str_LoginID
                };

                _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/Validate/Get_Val_MonthAttendance";
             DataSet _Data = _Common._ReturnDataSet(_SiteMaster);

                _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsEmployeeMonthAttendance";

                HttpContent inputContent = new StringContent(JsonConvert.SerializeObject(_SiteMaster, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }), Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpClient().PostAsync(_SiteMaster.Str_ApiUrl, inputContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    _SiteMaster = new JavaScriptSerializer().Deserialize<SiteMasterParameters>(response.Content.ReadAsStringAsync().Result);
                    if (_SiteMaster.Str_Status != null)
                    {
                        if (_SiteMaster.Str_Status == "Success")
                        {
                            UsersSession.GetMessages(this, _SiteMaster.Str_Status, _SiteMaster.Str_Result);
                            ClearBox();
                        }
                    }
                    else
                    {
                        UsersSession.GetMessages(this, _SiteMaster.Str_Status, _SiteMaster.Str_Result);
                    }
                }
                else
                {
                    UsersSession.GetMessages(this, _SiteMaster.Str_Status, _SiteMaster.Str_Result);
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

        protected void GridMonthAttendance_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        private void ClearBox()
        {
            //txtEmployeeName.Text = string.Empty;
            txtSalaryCycle.Text = string.Empty;
            txtSalaryCycle.Text = string.Empty;
            // txtEmployeeCode.Text = string.Empty;
            GridMonthAttendance.DataSource = "";
            GridMonthAttendance.DataBind();
            InitializeTable();
            BindData();
        }

        private void InitializeTable()
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("MonthAttendanceID", typeof(string)));
            dt.Columns.Add(new DataColumn("EmployeeID", typeof(string)));
            dt.Columns.Add(new DataColumn("MonthNames", typeof(string)));
            dt.Columns.Add(new DataColumn("YearName", typeof(string)));
            dt.Columns.Add(new DataColumn("MonthDays", typeof(string)));
            dt.Columns.Add(new DataColumn("EmpMonthDays", typeof(string)));
            dt.Columns.Add(new DataColumn("DesignationID", typeof(string)));
            dt.Columns.Add(new DataColumn("DutyID", typeof(string)));
            dt.Columns.Add(new DataColumn("SiteID", typeof(string)));
            dt.Columns.Add(new DataColumn("AssignSiteID", typeof(string)));
            dt.Columns.Add(new DataColumn("BranchID", typeof(string)));
            dt.Columns.Add(new DataColumn("NormalDays", typeof(string)));
            dt.Columns.Add(new DataColumn("WeeklyOff", typeof(string)));
            dt.Columns.Add(new DataColumn("PaidHolidays", typeof(string)));
            dt.Columns.Add(new DataColumn("OTDays", typeof(string)));
            dt.Columns.Add(new DataColumn("OTHours", typeof(string)));
            dt.Columns.Add(new DataColumn("CreatedBy", typeof(string)));
            dt.Columns.Add(new DataColumn("SplOTDays", typeof(string)));
            dt.Columns.Add(new DataColumn("SplOTHours", typeof(string)));
            dt.Columns.Add(new DataColumn("PL", typeof(string)));
            dt.Columns.Add(new DataColumn("CL", typeof(string)));
            dt.Columns.Add(new DataColumn("SL", typeof(string)));
            dt.Columns.Add(new DataColumn("WebAtn", typeof(bool)));
            ViewState["MonthAttendanceDetails"] = dt;
        }

        private void BindData()
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                _SiteMaster = new SiteMasterParameters();
                _SiteMaster.Str_CompanyID = UserDetails.Str_CompanyID;
                _SiteMaster.Str_LoginID = UserDetails.Str_LoginID;
                _SiteMaster.Str_SelectID = "22";
                _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlBranch, _SiteMaster);
                _SiteMaster.Str_SelectID = "24";
                _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetClientGroup";
                _Common.BindDropDown(this, ddlClient, _SiteMaster);
                _SiteMaster.Str_SelectID = "120";
                _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlSite, _SiteMaster);
                _SiteMaster.Str_SelectID = "93";
                _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlMonth, _SiteMaster);
                _SiteMaster.Str_SelectID = "91";
                _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignation";
                _Common.BindDropDown(this, ddlYear, _SiteMaster);
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlClient.SelectedIndex > 0)
                {

                    var UserDetails = UsersSession.GetSession();
                    _Common = new ASR_Common();
                    _SiteMaster = new SiteMasterParameters();
                    _SiteMaster.Str_CompanyID = UserDetails.Str_CompanyID;
                    _SiteMaster.Str_LoginID = UserDetails.Str_LoginID;
                    _SiteMaster.Str_SelectID = "120";
                    //       _SiteMaster.Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue;
                    _SiteMaster.Str_ParentID = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue;
                    //       _SiteMaster.Str_SiteMasterID = ddlSite.SelectedValue == "Select One" ? "0" : ddlSite.SelectedValue;
                    _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetSiteMaster";
                    _Common.BindDropDown(this, ddlSite, _SiteMaster);

                }
                else
                {
                    ddlClient.SelectedIndex = 0;
                    ddlSite.SelectedIndex = 0;
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }
        }

        protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSite.SelectedIndex > 0)
                {
                    var UserDetails = UsersSession.GetSession();
                    _Common = new ASR_Common();
                    _SiteMaster = new SiteMasterParameters();
                    _SiteMaster.Str_CompanyID = UserDetails.Str_CompanyID;
                    _SiteMaster.Str_LoginID = UserDetails.Str_LoginID;
                    _SiteMaster.Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue;
                    _SiteMaster.Str_ClientID = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue;
                    _SiteMaster.Str_SiteMasterID = ddlSite.SelectedValue == "Select One" ? "0" : ddlSite.SelectedValue;
                    _SiteMaster.Str_MonthID = ddlMonth.SelectedValue == "Select One" ? "0" : ddlMonth.SelectedValue;
                    _SiteMaster.Str_YearID = ddlYear.SelectedValue == "Select One" ? "0" : ddlYear.SelectedValue;
                    _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstSiteWiseEmployees";
                    _SiteMaster._DataTable = _Common._ReturnDataSet(_SiteMaster).Tables[0];
                    ViewState["Employee"] = _SiteMaster._DataTable;
                    GridMonthAttendance.DataSource = _SiteMaster._DataTable;
                    GridMonthAttendance.DataBind();
                    DropDownList ddlDesignationID, ddlDuty;
                    Label lblDesignationID, lblDutyID;
                    for (int i = 0; i < GridMonthAttendance.Rows.Count; i++)
                    {
                        _SiteMaster = new SiteMasterParameters();
                        _SiteMaster.Str_CompanyID = UserDetails.Str_CompanyID;
                        _SiteMaster.Str_LoginID = UserDetails.Str_LoginID;
                        ddlDesignationID = (GridMonthAttendance.Rows[i].FindControl("ddlDesignationID") as DropDownList);
                        _SiteMaster.Str_SelectID = "47";
                        _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignation";
                        _Common.BindDropDown(this, ddlDesignationID, _SiteMaster);
                        lblDesignationID = (GridMonthAttendance.Rows[i].FindControl("lblDesignationID") as Label);
                        ddlDesignationID.SelectedValue = lblDesignationID.Text;

                        ddlDuty = (GridMonthAttendance.Rows[i].FindControl("ddlDuty") as DropDownList);
                        _SiteMaster.Str_SelectID = "51";
                        _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDuty";
                        _Common.BindDropDown(this, ddlDuty, _SiteMaster);
                    }
                }
                else
                {
                    ddlSite.SelectedIndex = 0;
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }
        }

        protected void Btn_Add_Employee_Click(object sender, EventArgs e)
        {
            BindEmployee();
        }
        private void BindEmployee()
        {
            try
            {
                if (ddlMonth.SelectedIndex == 0)
                {
                    UsersSession.GetMessages(this, "Warning", "Please Select Month Name");
                    return;
                }
                if (ddlYear.SelectedIndex == 0)
                {
                    UsersSession.GetMessages(this, "Warning", "Please Select Year Name");
                    return;
                }
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                _SiteMaster = new SiteMasterParameters();
                _SiteMaster.Str_CompanyID = UserDetails.Str_CompanyID;
                _SiteMaster.Str_LoginID = UserDetails.Str_LoginID;
                _SiteMaster.Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue;
                _SiteMaster.Str_MonthID = ddlMonth.SelectedValue == "Select One" ? "0" : ddlMonth.SelectedValue;
                _SiteMaster.Str_YearID = ddlYear.SelectedValue == "Select One" ? "0" : ddlYear.SelectedValue;
                _SiteMaster.Str_EmployeeID = ddlEmployeeCode.SelectedValue;//.Trim().Split('-')[0] ;
                _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstSiteWiseEmployees";
                _SiteMaster._DataSet = _Common._ReturnDataSet(_SiteMaster);
                if (_SiteMaster._DataSet != null)
                {
                    if (_SiteMaster._DataSet.Tables.Count > 0)
                    {
                        if (_SiteMaster._DataSet.Tables[0] != null)
                        {
                            if (_SiteMaster._DataSet.Tables[0].Rows.Count > 0)
                            {
                                _SiteMaster._DataTable = (DataTable)ViewState["Employee"];
                                DataRow[] foundRows = _SiteMaster._DataTable.Select("EmployeeID=" + Convert.ToInt64(_SiteMaster._DataSet.Tables[0].Rows[0]["EmployeeID"]));
                                if (foundRows.Length > 0)
                                {
                                    UsersSession.GetMessages(this, "Warning", "Record already present in table.");
                                    return;
                                }
                                _SiteMaster._DataTable.Merge(_SiteMaster._DataSet.Tables[0], false, MissingSchemaAction.Ignore);
                                _SiteMaster._DataTable.AcceptChanges();

                                GridMonthAttendance.DataSource = "";
                                GridMonthAttendance.DataBind();
                                GridMonthAttendance.DataSource = _SiteMaster._DataTable;
                                GridMonthAttendance.DataBind();
                            }
                        }
                    }
                }
                DropDownList ddlDesignationID, ddlDuty;
                Label lblDesignationID, lblDutyID;
                for (int i = 0; i < GridMonthAttendance.Rows.Count; i++)
                {
                    _SiteMaster = new SiteMasterParameters();
                    _SiteMaster.Str_CompanyID = UserDetails.Str_CompanyID;
                    _SiteMaster.Str_LoginID = UserDetails.Str_LoginID;
                    ddlDesignationID = (GridMonthAttendance.Rows[i].FindControl("ddlDesignationID") as DropDownList);
                    _SiteMaster.Str_SelectID = "47";
                    _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignation";
                    _Common.BindDropDown(this, ddlDesignationID, _SiteMaster);
                    lblDesignationID = (GridMonthAttendance.Rows[i].FindControl("lblDesignationID") as Label);
                    ddlDesignationID.SelectedValue = lblDesignationID.Text;

                    ddlDuty = (GridMonthAttendance.Rows[i].FindControl("ddlDuty") as DropDownList);
                    _SiteMaster.Str_SelectID = "51";
                    _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDuty";
                    _Common.BindDropDown(this, ddlDuty, _SiteMaster);
                }
                ddlEmployeeCode.SelectedIndex = 0;
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }

        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlBranch.SelectedIndex > 0)
                {
                    var UserDetails = UsersSession.GetSession();
                    _Common = new ASR_Common();
                    _SiteMaster = new SiteMasterParameters();
                    _SiteMaster.Str_Mode = "Branch Wise";
                    _SiteMaster.Str_CompanyID = UserDetails.Str_CompanyID;
                    _SiteMaster.Str_LoginID = UserDetails.Str_LoginID;
                    _SiteMaster.Str_BranchID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue;
                    _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranchWiseEmployees";
                    _Common.BindDropDown(this, ddlEmployeeCode, _SiteMaster);

                    _SiteMaster.Str_SelectID = "24";
                    _SiteMaster.Str_ParentID = ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue;
                    _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetChildData";
                    _Common.BindDropDown(this, ddlClient, _SiteMaster);

                }
                else
                {
                    ddlEmployeeCode.Items.Clear();
                    ddlClient.Items.Clear();
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }
        }
    }
}