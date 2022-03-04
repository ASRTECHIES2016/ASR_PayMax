using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASR_PayMaxLogic.Models;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using ASR_PayMax.GlobalProjectClass;
using System.Data;
using System.Configuration;

namespace ASR_PayMax.Masters
{
    public partial class Currency : System.Web.UI.Page
    {
        ASR_PayMaxParameters _Parameters;
        ASR_Common _Common;
        
        DataSet _DataSet;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Currency Code");
                return;
            }
            if (txtCurrencyName.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Currency Name");
                return;
            }
            try
            {
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = "Add",
                    Str_CompanyID = "1",
                    Str_SelectID = "209",
                    Bool_IsActive = true,
                    Str_LoginID = "1"
                };
                _Parameters.Str_ApiUrl=  ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsGun";

                HttpContent inputContent = new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, inputContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "ShowSuccess('Saved Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "ShowWarning('Sorry');", true);
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
            hddCurrencyID.Value = "0";
            txtCode.Text = string.Empty;
            txtCurrencyName.Text = string.Empty;
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
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_SelectID = "47";
          //      _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstDesignation";
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
                                GridCurrency.DataSource = _DataSet.Tables[0];
                                GridCurrency.DataBind();
                            }
                        }
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


        protected void GridCurrency_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void IsActive_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}