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

namespace ASR_PayMax.Registrations
{
    public partial class Employees : System.Web.UI.Page
    {
        ASR_PayMaxParameters _Parameters;
        ASR_Common _Common;
        DataSet ds;
        DataRow dr;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearBox();
            }
        }


        private void ClearBox()
        {
            hddEmployeeID.Value = "0";
            txtFirstName.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtRgistrationDate.Text = string.Empty;
            txtDateOfBirth.Text = string.Empty;
            txtJoiningDate.Text = string.Empty;
            txtMonthlySalary.Text = string.Empty;
            txtPANCardNo.Text = string.Empty;
            txtAadharCardNo.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtEmailID.Text = string.Empty;
            txtAadharCardNo.Text = string.Empty;
            Btn_Submit.Text = "Submit";
            ViewState["Qualification"] = null;
            ViewState["AddressDetail"] = null;
            ViewState["EmergencyContact"] = null;
            BindData();
            txtFirstName.Focus();
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
                _Parameters.Str_SelectID = "22";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                _Common.BindDropDown(this, ddlBranch, _Parameters);
                //_Parameters.Str_SelectID = "156";
                //_Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetBranch";
                //_Common.BindDropDown(this, ddlPresentStatus, _Parameters);
                _Parameters.Str_SelectID = "47";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignation";
                _Common.BindDropDown(this, ddlDesignationID, _Parameters);
                //_Parameters.Str_SelectID = "45";
                //_Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetDesignationCategory";
                //_Common.BindDropDown(this, ddlDesignationCategoryID, _Parameters);
                _Parameters.Str_SelectID = "106";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetQualification";
                _Common.BindDropDown(this, ddlQualification, _Parameters);
                _Parameters.Str_SelectID = "3";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetAddressType";
                _Common.BindDropDown(this, ddlAddressType, _Parameters);
                _Parameters.Str_SelectID = "24";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetClientGroup";
                _Common.BindDropDown(this, ddlClient, _Parameters);
                ddlSiteName.Items.Insert(0, "Select One");
                InitializeQualification();
                InitializeAddressDetails();
                InitializeEmergencyContact();
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

        public void InitializeQualification()
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("QualificationDetailID", typeof(string)));
            dt.Columns.Add(new DataColumn("QualificationID", typeof(string)));
            dt.Columns.Add(new DataColumn("QualificationName", typeof(string)));
            dt.Columns.Add(new DataColumn("Board", typeof(string)));
            dt.Columns.Add(new DataColumn("PassingYear", typeof(string)));
            dt.Columns.Add(new DataColumn("Per", typeof(string)));
            dt.Columns.Add(new DataColumn("Grade", typeof(string)));
            //dr = dt.NewRow();
            //dr["QualificationDetailID"] = "";
            //dr["QualificationID"] = "";
            //dr["QualificationName"] = "";
            //dr["Board"] = "";
            //dr["PassingYear"] = "";
            //dr["Per"] = "";
            //dr["Grade"] = "";
            //dt.Rows.Add(dr);
            ViewState["Qualification"] = dt;
        }
        public void InitializeAddressDetails()
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("AddressDetailID", typeof(string)));
            dt.Columns.Add(new DataColumn("AddressTypeID", typeof(string)));
            dt.Columns.Add(new DataColumn("AddressTypeName", typeof(string)));
            dt.Columns.Add(new DataColumn("Address", typeof(string)));
            dt.Columns.Add(new DataColumn("PinCodeID", typeof(string)));
            dt.Columns.Add(new DataColumn("PinCode", typeof(string)));
            dt.Columns.Add(new DataColumn("CityID", typeof(string)));
            dt.Columns.Add(new DataColumn("CityName", typeof(string)));
            dt.Columns.Add(new DataColumn("StateID", typeof(string)));
            dt.Columns.Add(new DataColumn("StateName", typeof(string)));
            dt.Columns.Add(new DataColumn("CountryID", typeof(string)));
            dt.Columns.Add(new DataColumn("CountryName", typeof(string)));
            //dr = dt.NewRow();
            //dr["AddressDetailID"] = "";
            //dr["AddressTypeID"] = "";
            //dr["AddressTypeName"] = "";
            //dr["Address"] = "";
            //dr["PinCodeID"] = "";
            //dr["PinCode"] = "";
            //dr["CityID"] = "";
            //dr["CityName"] = "";
            //dr["StateID"] = "";
            //dr["StateName"] = "";
            //dr["CountryID"] = "";
            //dr["CountryName"] = "";
            //dt.Rows.Add(dr);
            ViewState["AddressDetail"] = dt;
        }
        public void InitializeEmergencyContact()
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("EmgContactDetailID", typeof(string)));
            dt.Columns.Add(new DataColumn("PersonTypeID", typeof(string)));
            dt.Columns.Add(new DataColumn("ContactName", typeof(string)));
            dt.Columns.Add(new DataColumn("ContactNo", typeof(string)));
            dt.Columns.Add(new DataColumn("EmailID", typeof(string)));
            dt.Columns.Add(new DataColumn("Address", typeof(string)));
            dt.Columns.Add(new DataColumn("PinCodeID", typeof(string)));
            dt.Columns.Add(new DataColumn("PinCode", typeof(string)));
            dt.Columns.Add(new DataColumn("CityID", typeof(string)));
            dt.Columns.Add(new DataColumn("CityName", typeof(string)));
            dt.Columns.Add(new DataColumn("StateID", typeof(string)));
            dt.Columns.Add(new DataColumn("StateName", typeof(string)));
            dt.Columns.Add(new DataColumn("CountryID", typeof(string)));
            dt.Columns.Add(new DataColumn("CountryName", typeof(string)));
            //dr = dt.NewRow();
            //dr["EmgContactDetailID"] = "";
            //dr["PersonTypeID"] = "";
            //dr["ContactName"] = "";
            //dr["ContactNo"] = "";
            //dr["EmailID"] = "";
            //dr["Address"] = "";
            //dr["PinCodeID"] = "0";
            //dr["PinCode"] = "";
            //dr["CityID"] = "0";
            //dr["CityName"] = "";
            //dr["StateID"] = "0";
            //dr["StateName"] = "";
            //dr["CountryID"] = "0";
            //dr["CountryName"] = "";
            //dt.Rows.Add(dr);

            ViewState["EmergencyContact"] = dt;
        }

        protected void Btn_Add_Qual_Click(object sender, EventArgs e)
        {
            if (ddlQualification.SelectedValue == "0")
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Address Type");
                ddlQualification.Focus();
                return;
            }
            if (txtUniversity.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter University / Board Name");
                txtUniversity.Focus();
                return;
            }
            if (txtPassingYear.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Passing Year");
                txtUniversity.Focus();
                return;
            }
            dt = (DataTable)ViewState["Qualification"];
            if (dt != null)
            {
                dr = dt.NewRow();
                dr["QualificationDetailID"] = "0";
                dr["QualificationID"] = ddlQualification.SelectedValue;
                dr["QualificationName"] = ddlQualification.SelectedItem.Text;
                dr["Board"] = txtUniversity.Text.Trim();
                dr["PassingYear"] = txtPassingYear.Text.Trim();
                dr["Per"] = txtPer.Text.Trim();
                dr["Grade"] = txtGrade.Text.Trim();
                dt.Rows.Add(dr);
                GridQualification.DataSource = dt;
                GridQualification.DataBind();
                ViewState["Qualification"] = dt;
                ClearQual();
            }
        }

        private void ClearQual()
        {
            txtUniversity.Text = string.Empty;
            txtPassingYear.Text = string.Empty;
            txtPer.Text = string.Empty;
            txtGrade.Text = string.Empty;
            var UserDetails = UsersSession.GetSession();
            _Common = new ASR_Common();
            _Parameters = new ASR_PayMaxParameters();
            _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
            _Parameters.Str_LoginID = UserDetails.Str_LoginID;
            _Parameters.Str_SelectID = "154";
            _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetQualification";
            _Common.BindDropDown(this, ddlQualification, _Parameters); ;
        }

        protected void Btn_Add_Address_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlAddressType.SelectedValue == "Select One" || ddlAddressType.SelectedValue == "0")
                {
                    UsersSession.GetMessages(this, "Warning", "Please Select Address Type");
                    return;
                }
                if (txtAddress.Text.Trim() == "")
                {
                    UsersSession.GetMessages(this, "Warning", "Please Enter Address");
                    txtAddress.Focus();
                    return;
                }
                if (txtPincode.Text.Trim() == "")
                {
                    UsersSession.GetMessages(this, "Warning", "Please Enter Pincode");
                    return;
                }
                dt = (DataTable)ViewState["AddressDetail"];
                if (dt != null)
                {
                    dr = dt.NewRow();
                    dr["AddressDetailID"] = "0";
                    dr["AddressTypeID"] = ddlAddressType.SelectedValue;
                    dr["AddressTypeName"] = ddlAddressType.SelectedItem.Text;
                    dr["Address"] = txtAddress.Text.Trim();
                    dr["PinCodeID"] = hddPincodeID.Value.Trim();
                    dr["PinCode"] = txtPincode.Text.Trim();
                    dr["CityID"] = ddlCity.SelectedValue == "Select One" ? "0" : ddlCity.SelectedValue;
                    if (ddlCity.SelectedItem != null)
                    {
                        dr["CityName"] = ddlCity.SelectedItem.Text == "Select One" ? "0" : ddlCity.SelectedItem.Text;
                    }
                    dr["StateID"] = ddlState.SelectedValue == "Select One" ? "0" : ddlState.SelectedValue;
                    if (ddlState.SelectedItem != null)
                    {
                        dr["StateName"] = ddlState.SelectedItem.Text == "Select One" ? "0" : ddlState.SelectedItem.Text;
                    }
                    //dr["CountryID"] = ddlCountry.SelectedValue == "Select One" ? "0" : ddlCountry.SelectedValue;
                    //dr["CountryName"] = ddlCountry.SelectedItem.Text == "Select One" ? "0" : ddlCountry.SelectedItem.Text;
                    dt.Rows.Add(dr);
                    GridAddress.DataSource = dt;
                    GridAddress.DataBind();
                    ViewState["AddressDetail"] = dt;
                    ClearAddress();
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }
        }

        private void ClearAddress()
        {
            txtAddress.Text = string.Empty;
            txtPincode.Text = string.Empty;
            ddlCity.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
            var UserDetails = UsersSession.GetSession();
            _Common = new ASR_Common();
            _Parameters = new ASR_PayMaxParameters();
            _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
            _Parameters.Str_LoginID = UserDetails.Str_LoginID;
            _Parameters.Str_SelectID = "3";
            _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetAddressType";
            _Common.BindDropDown(this, ddlAddressType, _Parameters);
        }

        protected void Btn_Add_EmgAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmgContactName.Text.Trim() == "")
                {
                    UsersSession.GetMessages(this, "Warning", "Please Enter Contact Name");
                    txtAddress.Focus();
                    return;
                }
                if (txtEmgContactNo.Text.Trim() == "")
                {
                    UsersSession.GetMessages(this, "Warning", "Please Enter Contact No");
                    return;
                }
                if (txtEmgPincode.Text.Trim() == "")
                {
                    UsersSession.GetMessages(this, "Warning", "Please Enter Pincode");
                    return;
                }
                dt = (DataTable)ViewState["EmergencyContact"];
                if (dt != null)
                {
                    dr = dt.NewRow();
                    dr["EmgContactDetailID"] = "0";
                    dr["PersonTypeID"] = "1";
                    dr["ContactName"] = txtEmgContactName.Text.Trim();
                    dr["ContactNo"] = txtEmgContactNo.Text.Trim();
                    dr["EmailID"] = txtEmgEmail.Text.Trim();
                    dr["Address"] = txtEmgAddress.Text.Trim();
                    //dr["PinCodeID"] = "0";
                    //dr["PinCode"] = txtEmgPincode.Text.Trim();
                    //dr["CityID"] = "0";
                    //dr["CityName"] = txtEmgCity.Text.Trim();
                    //dr["StateID"] = "0";
                    //dr["StateName"] = txtEmgState.Text.Trim();
                    //dr["CountryID"] = "0";
                    //dr["CountryName"] = txtEmgCountry.Text.Trim();
                    dr["PinCode"] = txtPincode.Text.Trim();
                    dr["CityID"] = ddlCity.SelectedValue == "Select One" ? "0" : ddlCity.SelectedValue;
                    if (ddlCity.SelectedItem != null)
                    {
                        dr["CityName"] = ddlCity.SelectedItem.Text == "Select One" ? "0" : ddlCity.SelectedItem.Text;
                    }
                    dr["StateID"] = ddlState.SelectedValue == "Select One" ? "0" : ddlState.SelectedValue;
                    if (ddlState.SelectedItem != null)
                    {
                        dr["StateName"] = ddlState.SelectedItem.Text == "Select One" ? "0" : ddlState.SelectedItem.Text;
                    }
                    //dr["CountryID"] = ddlCountry.SelectedValue == "Select One" ? "0" : ddlCountry.SelectedValue;
                    //dr["CountryName"] = ddlCountry.SelectedItem.Text == "Select One" ? "0" : ddlCountry.SelectedItem.Text;
                    //dt.Rows.Add(dr);
                    dt.Rows.Add(dr);
                    GridContactDetails.DataSource = dt;
                    GridContactDetails.DataBind();
                    ViewState["EmergencyContact"] = dt;
                    ClearEmgAddress();
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }
        }

        private void ClearEmgAddress()
        {
            txtEmgContactName.Text = string.Empty;
            txtEmgContactNo.Text = string.Empty;
            txtEmgEmail.Text = string.Empty;
            txtEmgAddress.Text = string.Empty;
            txtEmgPincode.Text = string.Empty;
            //ddlEmgCity.Text = string.Empty;
            //EmgState.Text = string.Empty;
            //EmgCountry.Text = string.Empty;
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (txtRgistrationDate.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Registration Date");
                return;
            }

            if (txtJoiningDate.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Joining Date");
                return;
            }

            if (ddlBranch.SelectedIndex == 0)
            {
                UsersSession.GetMessages(this, "Warning", "Please Select Branch Name");
                return;
            }

            if (txtFirstName.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter First Name");
                return;
            }



            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                if (hddEmployeeID.Value != "0")
                {
                    Mode = "Edit";
                }
                //ds = new DataSet();

                //dt = (DataTable)ViewState["Qualification"];
                //dt.TableName = "Qualification";
                //ds.Tables.Add(dt);
                //dt = (DataTable)ViewState["AddressDetail"];
                //dt.TableName = "AddressDetail";
                //ds.Tables.Add(dt);
                //dt = (DataTable)ViewState["EmergencyContact"];
                //dt.TableName = "EmergencyContact";
                //ds.Tables.Add(dt);

                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_EmployeeID = hddEmployeeID.Value,
                    Str_EmployeeType = "FRONT",
                    Str_EmployeeCode = txtEmployeeCode.Text.Trim(),
                    Str_DesignationCategoryTypeID = "0",
                    Str_DesignationID = ddlDesignationID.SelectedValue,
                    Str_RegistrationDate = txtRgistrationDate.Text.Trim(),
                    Str_DateOfJoin = txtJoiningDate.Text.Trim(),
                    Str_BranchID = ddlBranch.SelectedValue,
                    Str_SiteMasterID = ddlSiteName.SelectedValue,
                    Str_DateOfBirth = txtDateOfBirth.Text.Trim(),
                    Str_FirstName = txtFirstName.Text.Trim(),
                    Str_MiddleName = txtMiddleName.Text.Trim(),
                    Str_LastName = txtLastName.Text.Trim(),
                    Str_EmailID = txtEmailID.Text.Trim(),
                    Str_Gender = RadioGender.SelectedValue,
                    Str_ContactNoOne = txtContactNo.Text,
                    Str_LocalAddress = txtAddress.Text.Trim(),
                    Str_AadharCardNo = txtAadharCardNo.Text.Trim(),
                    Str_PanCardNo = txtPANCardNo.Text.Trim(),
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                    //_DataSet = ds
                };

                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMaxMaster/MsEmployeeMaster";

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


        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlClient.SelectedIndex > 0)
                {
                    var UserDetails = UsersSession.GetSession();
                    _Common = new ASR_Common();
                    _Parameters = new SiteMasterParameters();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_SelectID = "120";
                    _Parameters.Str_Mode = "ID";
                    _Parameters.Str_GlobalID = "0";// ddlBranch.SelectedValue == "Select One" ? "0" : ddlBranch.SelectedValue;
                    _Parameters.Str_ParentID = ddlClient.SelectedValue == "Select One" ? "0" : ddlClient.SelectedValue;
                    _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetSiteMaster";
                    _Common.BindDropDown(this, ddlSiteName, _Parameters);
                }
                else
                {
                    ddlSiteName.Items.Clear();
                    ddlSiteName.Items.Insert(0, "Select One");
                }
            }
            catch (Exception _Exception)
            {
                UsersSession.GetMessages(this, "Failure", _Exception.Message.ToString());
            }

        }
    }
}