using System;
using ASR_PayMaxLogic.Models;
using ASR_PayMax.GlobalProjectClass;
using System.Data;
using System.Configuration;

namespace ASR_PayMax.Masters
{
    public partial class ServiceType : System.Web.UI.Page
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
            if (txtServiceTypeName.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Service Type");
                return;
            }
            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddServiceTypeID.Value != "0")
                {
                    Mode = "Edit";
                }
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SelectID = "117",
                    Str_GlobalID = hddServiceTypeID.Value,
                    Str_GlobalCode = txtServiceTypeCode.Text,
                    Str_GlobalName = txtServiceTypeName.Text,
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _Parameters.Str_ApiUrl =  ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsServiceType";
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
            hddServiceTypeID.Value = "0";
            txtServiceTypeCode.Text = string.Empty;
            txtServiceTypeName.Text = string.Empty;
            Btn_Submit.Text = "Submit";
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
                _Parameters.Str_SelectID = "117";
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstServiceType";
                _Common.BindGrid(this, GridServiceType, _Parameters);
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
                //                GridSalaryHeadGroup.DataSource = _DataSet.Tables[0];
                //                GridSalaryHeadGroup.DataBind();
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                //}
                //if (response.IsSuccessStatusCode)
                //{
                //    _DataSet = JsonConvert.DeserializeObject<DataSet>(response.Content.ReadAsStringAsync().Result);
                //    if (_DataSet != null)
                //    {
                //        if (_DataSet.Tables[0] != null)
                //        {
                //            if (_DataSet.Tables[0].Rows.Count > 0)
                //            {
                //                //gri.DataSource = _DataSet.Tables[0];
                //                //GridDesignation.DataBind();
                //            }
                //        }
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