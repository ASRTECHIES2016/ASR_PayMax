using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASR_PayMaxLogic.Models;
using ASR_PayMax.GlobalProjectClass;
using System.Data;
using System.Configuration;

namespace ASR_PayMax.Masters
{
    public partial class SiteMaster : System.Web.UI.Page
    {
        ASR_PayMaxParameters _PayMaxParameters;
        SiteMasterParameters _SiteMaster;
        ASR_Common _Common;
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
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();

                if (ddlRegion.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Region Name');", true);
                    return;
                }
                if (ddlBranch.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Branch Name');", true);
                    return;
                }
                if (ddlClient.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Client Name');", true);
                    return;
                }
                if (ddlIndustrySegment.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Industry Segment Name');", true);
                    return;
                }
                if (ddlServiceType.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Please Select Service Type');", true);
                    return;
                }
                if (txtSiteName.Text.Trim() == "")
                {
                    UsersSession.GetMessages(this, "Warning", "Please Enter Site Name");
                    return;
                }
                //if (txtBillDuty.Text.Trim() == "")
                //{
                //    UsersSession.GetMessages(this, "Warning", "Please Enter Bill Duty Division By");
                //    return;
                //}
                if (hddSiteID.Value != "0")
                {
                    Mode = "Edit";
                }

                _SiteMaster = new SiteMasterParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_BranchID = ddlBranch.SelectedValue,
                    Str_SiteMasterID = hddSiteID.Value,
                    Str_SiteCode = txtSiteCode.Text.Trim(),
                    Str_SiteName = txtSiteName.Text.Trim(),
                    Str_ClientGroupID = "0",// ddlClientGroup.SelectedValue == "Select One" ? "0" : ddlClientGroup.SelectedValue,
                    Str_IndustrySegID = ddlIndustrySegment.SelectedValue == "Select One" || ddlIndustrySegment.SelectedValue == "" ? "0" : ddlIndustrySegment.SelectedValue,
                    Str_RegionID = ddlRegion.SelectedValue == "Select One" || ddlRegion.SelectedValue == "" ? "0" : ddlRegion.SelectedValue,
                    Str_ServiceTypeID = ddlServiceType.SelectedValue == "Select One" || ddlServiceType.SelectedValue == "" ? "0" : ddlServiceType.SelectedValue,
                    Str_ClientID = ddlClient.SelectedValue == "Select One" || ddlClient.SelectedValue == "" ? "0" : ddlClient.SelectedValue,
                    //    Str_ZoneID = ddlZone.SelectedValue == "Select One" ? "0" : ddlZone.SelectedValue,
                    Str_BillType = ddlBillType.SelectedValue == "Select One" || ddlBillType.SelectedValue == "" ? "0" : ddlBillType.SelectedValue,
                    Str_GroupID = "0",//                    ddlGroup.SelectedValue == "Select One" ? "0" : ddlGroup.SelectedValue,
                    Str_FinancialBranchID = "0",// ddlFinanceBranch.SelectedValue == "Select One" ? "0" : ddlFinanceBranch.SelectedValue,
                    Str_BillDutyDivisionBy = txtBillDuty.Text.Trim() == "" ? "0" : txtBillDuty.Text.Trim(),
                    Str_WeeklyOffDivideBy = txtWeeklyOff.Text.Trim() == "" ? "0" : txtWeeklyOff.Text.Trim(),
                    Str_AddressOne = txtSiteAddressOne.Text.Trim() ,
                    Str_AddressTwo = txtSiteAddressTwo.Text.Trim(),
                    Str_WorkOrderNumber = string.Empty,
                    Str_WorkOrderDate = string.Empty,
                    Str_ValidTill = string.Empty,
                    Str_WorkOrderValue = string.Empty,
                    Str_ManagementFees = string.Empty,
                    Str_ClientSiteCode = string.Empty,
                    Str_Narration = string.Empty,
                    Str_NoOfAgreement = string.Empty,
                    Str_Tender = string.Empty,
                    Str_TenureOfContract = string.Empty,
                    Str_MinimumEscalationClause = string.Empty,
                    Str_ReportType = string.Empty,
                    Str_BillingName = string.Empty,
                    Str_ContractValue = string.Empty,
                    Str_AnnualValue = string.Empty,
                    Str_ManpowerCost = string.Empty,
                    Str_MachineryCost = string.Empty,
                    Str_ConsumableCost = string.Empty,
                    Str_OtherCharges = string.Empty,
                    Str_MgmtFeesValue = string.Empty,
                    Str_ContractStartDate = string.Empty,
                    Str_RBIIndex = string.Empty,
                    Str_MinWages = string.Empty,
                    Str_PerIncGrowth = string.Empty,
                    Str_GuardBoardIndex = string.Empty,
                    Str_SiteType = string.Empty,
                    Str_SiteStartDate = string.Empty,
                    Str_SiteEndDate = string.Empty,
                    Bool_IsPFonBasicDAOT = chkPFOn.Checked,
                    Bool_IsESI_NewImplemented = chkNewESIC.Checked,
                    Bool_IsOnlineAttendanceFreeze = true,
                    Bool_IsCompliance = ddlCompliance.SelectedValue == "Select One" || ddlCompliance.SelectedValue == "" ? false : true,

                    Bool_IsPFApplicable = true,
                    Bool_IsESICApplicable = true,
                    Bool_IsPTApplicable = true,
                    Bool_IsLWFApplicable = true,
                    Bool_IsServiceTaxApplicable = true,
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _SiteMaster.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMaxMaster/MsSiteMaster";
                if (_Common.IUMasters(this, _SiteMaster))
                {
                    ClearBox();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void ClearBox()
        {
            hddSiteID.Value = "0";
            txtBillDuty.Text = string.Empty;
            txtPincode.Text = string.Empty;
            txtSiteAddressOne.Text = string.Empty;
            txtSiteAddressTwo.Text = string.Empty;
            txtSiteCode.Text = string.Empty;
            txtSiteName.Text = string.Empty;
            //txtWeeklyOff.Text = string.Empty;
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
                _PayMaxParameters = new ASR_PayMaxParameters();
                _PayMaxParameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _PayMaxParameters.Str_LoginID = UserDetails.Str_LoginID;
                _PayMaxParameters.Str_SelectID = "77";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetIndustrySegment";
                _Common.BindDropDown(this, ddlIndustrySegment, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "117";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetServiceType";
                _Common.BindDropDown(this, ddlServiceType, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "109";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetRegion";
                _Common.BindDropDown(this, ddlRegion, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "22";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlBranch, _PayMaxParameters);
                //_PayMaxParameters.Str_SelectID = "24";
                //_PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetClientGroup";
                //_Common.BindDropDown(this, ddlClientGroup, _PayMaxParameters);
                _PayMaxParameters.Str_SelectID = "24";
                _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetClientGroup";
                _Common.BindDropDown(this, ddlClient, _PayMaxParameters);
                //_PayMaxParameters.Str_SelectID = "13";
                //_PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                //_Common.BindDropDown(this, ddlFinanceBranch, _PayMaxParameters);
                //_PayMaxParameters.Str_SelectID = "75";
                //_PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/Group";
                //_Common.BindDropDown(this, ddlGroup, _PayMaxParameters);
                //_PayMaxParameters.Str_SelectID = "157";
                // _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetZone";
                // _Common.BindDropDown(this, ddlZone, _PayMaxParameters);
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
                GridContactPerson.DataSource = dt;
                GridContactPerson.DataBind();
            }
            SetPreviousData();
        }
        protected void GridContactPerson_RowCreated(object sender, GridViewRowEventArgs e)
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
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("ContactPersonName", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("ContactNo", typeof(string)));//for DropDownList selected item   
            dt.Columns.Add(new DataColumn("Email", typeof(string)));//for DropDownList selected item   
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Description"] = string.Empty;
            dr["ContactPersonName"] = string.Empty;
            dr["ContactNo"] = string.Empty;
            dr["Email"] = string.Empty;
            dt.Rows.Add(dr);
            ViewState["CurrentTable"] = dt;
            GridContactPerson.DataSource = dt;
            GridContactPerson.DataBind();
        }

        private void AddNewRowToGrid()
        {

            if (ViewState["CurrentTable"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)GridContactPerson.Rows[i].Cells[1].FindControl("txtDescription");
                        TextBox box2 = (TextBox)GridContactPerson.Rows[i].Cells[2].FindControl("txtName");
                        TextBox box3 = (TextBox)GridContactPerson.Rows[i].Cells[3].FindControl("txtContactNo");
                        TextBox box4 = (TextBox)GridContactPerson.Rows[i].Cells[4].FindControl("txtEmail");


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
                        //if (box1.Text == "")
                        //{
                        //    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Failure", "showToast('Failure','Enter Description Before Adding New Row',2000);", true);
                        //    box1.Focus();
                        //    return;
                        //}
                        //if (box2.Text == "")
                        //{
                        //    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Failure", "showToast('Failure','Enter Person Name Before Adding New Row',2000);", true);
                        //    box2.Focus();
                        //    return;
                        //}
                        //if (box3.Text == "")
                        //{
                        //    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Failure", "showToast('Failure','Enter Contact Before Adding New Row',2000);", true);
                        //    box3.Focus();
                        //    return;
                        //}
                        //if (box4.Text == "")
                        //{
                        //    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Failure", "showToast('Failure','Enter Email Before Adding New Row',2000);", true);
                        //    box4.Focus();
                        //    return;
                        //}

                        dtCurrentTable.Rows[i]["Description"] = box1.Text;
                        dtCurrentTable.Rows[i]["ContactPersonName"] = box2.Text;
                        dtCurrentTable.Rows[i]["ContactNo"] = box3.Text;
                        dtCurrentTable.Rows[i]["Email"] = box4.Text;
                    }


                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GridContactPerson.DataSource = dtCurrentTable;
                    GridContactPerson.DataBind();
                    if (GridContactPerson.Rows.Count > 0)
                    {
                        TextBox box1 = (TextBox)GridContactPerson.Rows[GridContactPerson.Rows.Count - 1].Cells[1].FindControl("txtDescription");
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
                        TextBox box1 = (TextBox)GridContactPerson.Rows[i].Cells[1].FindControl("txtDescription");
                        TextBox box2 = (TextBox)GridContactPerson.Rows[i].Cells[2].FindControl("txtName");
                        TextBox box3 = (TextBox)GridContactPerson.Rows[i].Cells[3].FindControl("txtContactNo");
                        TextBox box4 = (TextBox)GridContactPerson.Rows[i].Cells[4].FindControl("txtEmail");
                        if (i < dt.Rows.Count - 1)
                        {
                            box1.Text = dt.Rows[i]["Description"].ToString();
                            box2.Text = dt.Rows[i]["ContactPersonName"].ToString();
                            box3.Text = dt.Rows[i]["ContactNo"].ToString();
                            box4.Text = dt.Rows[i]["Email"].ToString();
                        }
                        rowIndex++;
                    }
                }
            }
        }
        private void ResetRowID(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }

        protected void Btn_Detail_Click(object sender, EventArgs e)
        {

        }
    }
}