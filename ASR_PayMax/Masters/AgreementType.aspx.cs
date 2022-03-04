using System;
using System.Web.UI;
using ASR_PayMaxLogic.Models;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using ASR_PayMax.GlobalProjectClass;
using System.Data;
using System.Configuration;

namespace ASR_PayMax.Masters
{
    public partial class AgreementType1 : System.Web.UI.Page
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

        private void ClearBox()
        {
            txtGunName.Text = "";
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {

            try
            {
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = "Add",
                    Str_CompanyID = "1",
                    Str_SelectID = "209",
                    Str_GlobalID = hddGunID.Value,
                    Str_GlobalName = txtGunName.Text,
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

        }
    }
}