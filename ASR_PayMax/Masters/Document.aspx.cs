using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASR_PayMaxLogic.Models;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using ASR_PayMax.GlobalProjectClass;
using System.Configuration;
using System.Data;
using Newtonsoft.Json;

namespace ASR_PayMax.Masters
{
    public partial class Document : System.Web.UI.Page
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
            if (txtDocumentName.Text.Trim() == "")
            {
                UsersSession.GetMessages(this, "Warning", "Please Enter Document Name");
                return;
            }
            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                if (hddDocumentID.Value != "0")
                {
                    Mode = "Edit";
                }
                _Parameters = new ASR_PayMaxParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SelectID = "49",
                    Str_GlobalID = hddDocumentID.Value,
                    Str_GlobalName = txtDocumentName.Text,
                    Bool_IsActive = true,
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _Parameters.Str_ApiUrl =  ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsDocument";
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
            hddDocumentID.Value = "0";
            txtDocumentName.Text = string.Empty;
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
                _Parameters.Str_SelectID = "49";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstDocument";
                _Common.BindGrid(this, GridDocument, _Parameters);
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
                //                GridDocument.DataSource = _DataSet.Tables[0];
                //                GridDocument.DataBind();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        UsersSession.GetMessages(this, "Warning", "Data not available");
                //    }
                //}
                //if (response.IsSuccessStatusCode)
                //{
                //    ASR_PayMaxParameters[] arr = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters[]>(response.Content.ReadAsStringAsync().Result);
                //    if (arr[0].Str_Status == "Get")
                //    {
                //        GridDocument.DataSource = arr;
                //        GridDocument.DataBind();
                //    }
                //    else
                //    {
                //        UsersSession.GetMessages(this, arr[0].Str_Status, arr[0].Str_Result);
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

        protected void IsActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var UserDetails = UsersSession.GetSession();
                CheckBox chk = (CheckBox)sender;
                GridViewRow Row = ((GridViewRow)((Control)sender).Parent.Parent.Parent.Parent);
                CheckBox grdCheckBox = (CheckBox)GridDocument.Rows[Row.RowIndex].FindControl("IsActive");
                Label lblDocumentID = (Label)GridDocument.Rows[Row.RowIndex].Cells[0].FindControl("lblDocumentID");

                _Parameters = new ASR_PayMaxParameters();
                _Common = new ASR_Common();
                _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                _Parameters.Str_SelectID = "49";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                _Parameters.Str_GlobalID = lblDocumentID.Text;
                _Parameters.Str_Mode = "Active";
                _Parameters.Bool_IsActive = chk.Checked;
                _Parameters = _Common.ModifiedData(_Parameters);
                if (_Parameters != null)
                {
                    UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                    ClearBox();
                }
                else
                {
                       UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }

        }

        protected void GridDocument_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);

                Label lblDocumentID = GridDocument.Rows[RowIndex].Cells[0].FindControl("lblDocumentID") as Label;
                Label lblDocument = GridDocument.Rows[RowIndex].Cells[0].FindControl("lblDocument") as Label;

                if (e.CommandName == "Change")
                {
                    hddDocumentID.Value = lblDocumentID.Text;
                    txtDocumentName.Text = lblDocument.Text;
                    Btn_Submit.Text = "Update";
                }
                if (e.CommandName == "Deleted")
                {
                    var UserDetails = UsersSession.GetSession();
                    _Parameters = new ASR_PayMaxParameters();
                    _Common = new ASR_Common();
                    _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
                    _Parameters.Str_SelectID = "49";
                    _Parameters.Str_LoginID = UserDetails.Str_LoginID;
                    _Parameters.Str_GlobalID = lblDocumentID.Text;
                    _Parameters.Str_Mode = "Delete";
                    _Parameters = _Common.ModifiedData(_Parameters);
                    if (_Parameters != null)
                    {
                         UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                        ClearBox();
                    }
                    else
                    {
                         UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }


        }
    }
}