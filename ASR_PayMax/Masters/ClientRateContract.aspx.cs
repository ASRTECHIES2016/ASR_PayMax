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
using ASR_PayMax.GlobalProjectClass;
using ASR_PayMaxLogic.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace ASR_PayMax.Masters
{
    public partial class ClientRateContract : System.Web.UI.Page
    {
        ASR_PayMaxParameters _PayMaxParameters;
        ASR_Common _Common;
        DataSet _DataSet;
        ArrayList arrAll;
        ArrayList arrSelected;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearBox();
            }
        }
        private void ClearBox()
        {
            hddClientRateID.Value = "0";
            ViewState["ClientRate"] = null;
            ddlAllSite.Items.Clear();
            ddlSelectedSite.Items.Clear();
            BindData();
        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {

        }

        public void InitializeDataTable()
        {
            _PayMaxParameters = new ASR_PayMaxParameters();
            _PayMaxParameters._DataTable = new DataTable();
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("ClientRateContractID", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("OperationType", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("BranchID", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("ClientGroupID", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("DesignationID", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("SiteID", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("DutyID", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("MonthID", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("YearID", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("SalaryHeadID", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("Computation", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("Percentage", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("Formula", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("OnAmount", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("MonthlyYearly", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("MaxAmount", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("TotalAmount", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("OTType", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("OTRate", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("OTFormula", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("OTCalculationOn", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("OTCalculationValue", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("SpecialOTType", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("SpecialOTRate", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("SpecialOTFormula", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("SpecialOTCalculationOn", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("SpecialOTCalculationValue", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("WOType", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("WOOption", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("WOFormula", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("WOValue", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("CreatedBy", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("LeaveType", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("LeaveFormula", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("LeaveValue", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("HolidayType", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("HolidayFormula", typeof(string)));
            _PayMaxParameters._DataTable.Columns.Add(new DataColumn("HolidayValue", typeof(string)));
            ViewState["ClientRate"] = _PayMaxParameters._DataTable; 
        }
        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeDataTable();
                _PayMaxParameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _PayMaxParameters.Str_Mode = "Add";
                _PayMaxParameters._DataTable = (DataTable)ViewState["ClientRate"];
                _PayMaxParameters._DataTable.TableName = "Rate_Contract";
                List<string> sc = new List<string>();
                foreach (ListItem item in ddlSelectedSite.Items)
                {
                    sc.Add(item.Value);
                }
                DataRow dr;

                for (int i = 0; i < GridSalaryRateDetails.Rows.Count; i++)
                {
                    dr = _PayMaxParameters._DataTable.NewRow();
                    dr["ClientRateContractID"] = "0";
                    dr["OperationType"] = "1";
                    dr["BranchID"] = "0";
                    dr["ClientGroupID"] = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue;
                    dr["DesignationID"] = ddlDesignation.SelectedValue == "Select One" ? "0" : ddlDesignation.SelectedValue;
                    dr["SiteID"] = string.Join(",", sc);// ddlGroup.SelectedValue == "Select One" ? "0" : ddlGroup.SelectedValue;
                    dr["DutyID"] = ddlDuty.SelectedValue == "Select One" ? "0" : ddlDuty.SelectedValue;

                    dr["MonthID"] = ddlMonth.SelectedValue == "Select One" ? "0" : ddlMonth.SelectedValue;
                    dr["YearID"] = ddlYear.SelectedValue == "Select One" ? "0" : ddlYear.SelectedValue;

                    dr["SalaryHeadID"] = (GridSalaryRateDetails.Rows[i].Cells[0].FindControl("lblSalaryHeadID") as Label).Text;
                    dr["Computation"] = (GridSalaryRateDetails.Rows[i].Cells[3].FindControl("ddlSalaryComputation") as DropDownList).SelectedValue;
                    dr["Percentage"] = (GridSalaryRateDetails.Rows[i].Cells[4].FindControl("txtSalaryPercentage") as TextBox).Text;
                    dr["Formula"] = (GridSalaryRateDetails.Rows[i].Cells[5].FindControl("txtSalaryFormula") as TextBox).Text;
                    dr["OnAmount"] = (GridSalaryRateDetails.Rows[i].Cells[6].FindControl("txtSalaryAmount") as TextBox).Text;
                    dr["MaxAmount"] = (GridSalaryRateDetails.Rows[i].Cells[8].FindControl("txtSalaryMaxAmount") as TextBox).Text;
                    dr["MonthlyYearly"] = (GridSalaryRateDetails.Rows[i].Cells[7].FindControl("ddlSalaryMonthlyOrYearly") as DropDownList).SelectedValue;

                    dr["TotalAmount"] = txtGrossAmount.Text.Trim() == "" ? "0" : txtGrossAmount.Text.Trim();

                    dr["OTType"] = ddlOTSalary.SelectedValue;
                    dr["OTRate"] = txtOTSalaryValue.Text.Trim();
                    dr["OTFormula"] = txtOTFormula.Text.Trim();
                    dr["OTCalculationOn"] = ddlOTType.SelectedValue;
                    dr["OTCalculationValue"] = txtOTSalaryValue.Text.Trim();

                    dr["SpecialOTType"] = ddlSpOT.SelectedValue;
                    dr["SpecialOTRate"] = txtSpOTMinAmount.Text.Trim();
                    dr["SpecialOTFormula"] = txtSpOTFormula.Text.Trim();
                    dr["SpecialOTCalculationOn"] = ddlSpeacialOTType.SelectedValue;
                    dr["SpecialOTCalculationValue"] = txtSpOTSalaryValue.Text.Trim();

                    dr["WOType"] = ddlWKOff.SelectedValue;
                    dr["WOOption"] = ddlWeekOffType.SelectedValue;
                    dr["WOFormula"] = txtWkOTFormula.Text.Trim();
                    dr["WOValue"] = txtWkOTSalaryValue.Text.Trim();

                    dr["CreatedBy"] = "1";
                    dr["LeaveType"] = "0";
                    dr["LeaveFormula"] = "0";
                    dr["LeaveValue"] = "0";
                    dr["HolidayType"] = "0";
                    dr["HolidayFormula"] = "0";
                    dr["HolidayValue"] = "0";

                    _PayMaxParameters._DataTable.Rows.Add(dr);
                }


                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MstClientRateContract";

                HttpContent inputContent = new StringContent(JsonConvert.SerializeObject(_PayMaxParameters, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }), Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpClient().PostAsync(_PayMaxParameters.Str_ApiUrl, inputContent).Result;

                if (response.IsSuccessStatusCode)
                {


					//var jsonResolver = new PropertyRenameAndIgnoreSerializerContractResolver();
					//jsonResolver.IgnoreProperty(typeof(Person), "Title");
					//jsonResolver.RenameProperty(typeof(Person), "FirstName", "firstName");

					//var serializerSettings = new JsonSerializerSettings();
					//serializerSettings.ContractResolver = jsonResolver;
					//var demo = JsonConvert.DeserializeObject<ASR_PayMaxParameters>(response.Content.ReadAsStringAsync().Result);
					_PayMaxParameters = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters>(response.Content.ReadAsStringAsync().Result);
                    if (_PayMaxParameters.Str_Status != null)
                    {
                        if (_PayMaxParameters.Str_Status == "Success")
                        {
                            UsersSession.GetMessages(this, _PayMaxParameters.Str_Status, _PayMaxParameters.Str_Result);
                            ClearBox();
                        }
                    }
                    else
                    {
                        UsersSession.GetMessages(this, _PayMaxParameters.Str_Status, _PayMaxParameters.Str_Result);
                    }
                }
                else
                {
                    UsersSession.GetMessages(this, _PayMaxParameters.Str_Status, _PayMaxParameters.Str_Result);
                }
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }

            //    if (_Common.IUMasters(this, _PayMaxParameters))
            //    {
            //        ClearBox();
            //    }




            //}
            //catch (Exception _Exception)
            //{
            //    _Exception.ToString();
            //}
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearBox();
        }

        private void BindData()
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                _PayMaxParameters = new ASR_PayMaxParameters();
                _PayMaxParameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _PayMaxParameters.Str_LoginID = UserDetails.Str_LoginID;
                _PayMaxParameters.Str_SelectID = "24";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetClientGroup";
                _Common.BindDropDown(this, ddlClient, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "47";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignation";
                _Common.BindDropDown(this, ddlDesignation, _PayMaxParameters);
                //_PayMaxParameters.Str_SelectID = "75";
                //_PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetGroup";
                //_Common.BindDropDown(this, ddlGroup, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "51";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDuty";
                _Common.BindDropDown(this, ddlDuty, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "93";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDuty";
                _Common.BindDropDown(this, ddlMonth, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "91";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDuty";
                _Common.BindDropDown(this, ddlYear, _PayMaxParameters);
                //_PayMaxParameters.Str_SelectID = "115";
                //_PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDuty";
                //_Common.BindDropDown(this, ddlWeekOffType, _PayMaxParameters);
                //_PayMaxParameters.Str_SelectID = "51";
                //_PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDuty";
                //_Common.BindDropDown(this, DropDownList2, _PayMaxParameters);
                //_PayMaxParameters.Str_SelectID = "51";
                //_PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDuty";
                //_Common.BindDropDown(this, DropDownList4, _PayMaxParameters);
                //_PayMaxParameters.Str_SelectID = "51";
                //_PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDuty";
                //_Common.BindDropDown(this, DropDownList6, _PayMaxParameters);
            }
            catch (Exception _Exception)
            {
                UsersSession.GetMessages(this, "Failure", _Exception.Message.ToString());
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var UserDetails = UsersSession.GetSession();
            _Common = new ASR_Common();
            _PayMaxParameters = new ASR_PayMaxParameters();
            _PayMaxParameters.Str_CompanyID = UserDetails.Str_CompanyID;
            _PayMaxParameters.Str_LoginID = UserDetails.Str_LoginID;
            if (ddlClient.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Client Name"); return;
            }

            if (ddlDesignation.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Designation Name"); return;
            }
            //if (ddlGroup.SelectedIndex == 0)
            //{
            //    UsersSession.GetMessages(this, "Warning", "Please Select Group Name"); return;
            //}
            if (ddlDuty.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Duty"); return;
            }

            if (ddlType.SelectedIndex == 1)
            {
                pnlSalary.Visible = true;
                pnlBilling.Visible = false;
                _PayMaxParameters.Str_SelectID = "115";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstSalaryHead";
                _Common.BindGrid(this, GridSalaryRateDetails, _PayMaxParameters);

            }
            else
            {
                pnlBilling.Visible = true;
                pnlSalary.Visible = false;
                _PayMaxParameters.Str_SelectID = "115";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstSalaryHead";
                _Common.BindGrid(this, GridSalaryRateDetails, _PayMaxParameters);
            }
        }

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                ddlAllSite.Items.Clear();
                ddlSelectedSite.Items.Clear();

                if (ddlClient.SelectedIndex > 0)
                {

                    pnlSalary.Visible = true;
                    var UserDetails = UsersSession.GetSession();
                    _Common = new ASR_Common();
                    _PayMaxParameters = new ASR_PayMaxParameters();
                    _PayMaxParameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _PayMaxParameters.Str_LoginID = UserDetails.Str_LoginID;
                    _PayMaxParameters.Str_SelectID = "120";
                    _PayMaxParameters.Str_ParentID = ddlClient.SelectedValue;
                    _PayMaxParameters.Str_GlobalID = "0";
                    _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBank";
                    _Common.BindListBox(this, ddlAllSite, _PayMaxParameters);

                }
                else
                {
                    pnlSalary.Visible = false;
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }
        }

        protected void ddlSalaryComputation_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ddlOTType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            arrAll = new ArrayList();
            arrSelected = new ArrayList();
            if (ddlAllSite.SelectedIndex >= 0)
            {
                for (int i = 0; i < ddlAllSite.Items.Count; i++)
                {
                    if (ddlAllSite.Items[i].Selected)
                    {
                        if (!arrAll.Contains(ddlAllSite.Items[i]))
                        {
                            arrAll.Add(ddlAllSite.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < arrAll.Count; i++)
                {
                    if (!ddlSelectedSite.Items.Contains(((ListItem)arrAll[i])))
                    {
                        ddlSelectedSite.Items.Add(((ListItem)arrAll[i]));
                    }
                    ddlAllSite.Items.Remove(((ListItem)arrAll[i]));
                }
                ddlSelectedSite.SelectedIndex = -1;
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            arrAll = new ArrayList();
            arrSelected = new ArrayList();
            if (ddlSelectedSite.SelectedIndex >= 0)
            {
                for (int i = 0; i < ddlSelectedSite.Items.Count; i++)
                {
                    if (ddlSelectedSite.Items[i].Selected)
                    {
                        if (!arrSelected.Contains(ddlSelectedSite.Items[i]))
                        {
                            arrSelected.Add(ddlSelectedSite.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < arrSelected.Count; i++)
                {
                    if (!ddlAllSite.Items.Contains(((ListItem)arrSelected[i])))
                    {
                        ddlAllSite.Items.Add(((ListItem)arrSelected[i]));
                    }
                    ddlSelectedSite.Items.Remove(((ListItem)arrSelected[i]));
                }
                ddlAllSite.SelectedIndex = -1;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            arrAll = new ArrayList();
            arrSelected = new ArrayList();
            while (ddlAllSite.Items.Count != 0)
            {
                for (int i = 0; i < ddlAllSite.Items.Count; i++)
                {
                    ddlSelectedSite.Items.Add(ddlAllSite.Items[i]);
                    ddlAllSite.Items.Remove(ddlAllSite.Items[i]);
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            arrAll = new ArrayList();
            arrSelected = new ArrayList();

            while (ddlSelectedSite.Items.Count != 0)
            {
                for (int i = 0; i < ddlSelectedSite.Items.Count; i++)
                {
                    ddlAllSite.Items.Add(ddlSelectedSite.Items[i]);
                    ddlSelectedSite.Items.Remove(ddlSelectedSite.Items[i]);
                }
            }

        }

        protected void ddlSpeacialOTType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlOTSalary_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSpOT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlWeekOffType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlWKOff_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}