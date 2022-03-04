using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASR_PayMaxLogic.Models;
using System.Data;
using ASR_PayMax.GlobalProjectClass;
using System.Configuration;
using System.IO;
using System.Web;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text;

namespace ASR_PayMax.Masters
{
    public partial class CompanyMaster : System.Web.UI.Page
    {
        CompanyParameters _Parameters;
        ASR_Common _Common;
        DataSet _DataSet;
        static string Str_Path, Str_ServerPath;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearBox();
            }
        }
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }


        private void createFile(string strPath, string strServerPath, string strThread)
        {
            string fileName = strPath + @"\Temp.txt";
            FileInfo fi = new FileInfo(fileName);
            try
            {
                if (fi.Exists)
                {
                    fi.Delete();
                }
                using (StreamWriter sw = fi.CreateText())
                {
                    sw.WriteLine("New File Is Created On : {0}", DateTime.Now.ToString());
                    sw.WriteLine("Server Path " + strServerPath);
                    sw.WriteLine(Environment.NewLine);
                    sw.WriteLine("Local Path " + strPath);
                    sw.WriteLine(Environment.NewLine);
                    sw.WriteLine(Environment.NewLine);
                    sw.WriteLine("Exception " + strThread);
                    sw.WriteLine("Done ! ");
                }
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch
            {
                throw;
            }
        }


        protected void GridPersonDetails_RowCreated(object sender, GridViewRowEventArgs e)
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
            dt.Columns.Add(new DataColumn("ContactDetailID", typeof(string)));
            dt.Columns.Add(new DataColumn("PersonTypeID", typeof(string)));
            dt.Columns.Add(new DataColumn("ContactName", typeof(string)));
            dt.Columns.Add(new DataColumn("ContactNo", typeof(string)));
            dt.Columns.Add(new DataColumn("EmailID", typeof(string)));
            dt.Columns.Add(new DataColumn("Descriptions", typeof(string)));
            dt.Columns.Add(new DataColumn("DesignationID", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["ContactDetailID"] = string.Empty;
            dr["PersonTypeID"] = string.Empty;
            dr["ContactName"] = string.Empty;
            dr["ContactNo"] = string.Empty;
            dr["EmailID"] = string.Empty;
            dr["Descriptions"] = string.Empty;
            dr["DesignationID"] = string.Empty;
            dt.Rows.Add(dr);
            ViewState["CurrentTable"] = dt;
            GridPersonDetails.DataSource = dt;
            GridPersonDetails.DataBind();
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
                        TextBox box1 = (TextBox)GridPersonDetails.Rows[i].Cells[1].FindControl("txtDescription");
                        TextBox box2 = (TextBox)GridPersonDetails.Rows[i].Cells[2].FindControl("txtName");
                        TextBox box3 = (TextBox)GridPersonDetails.Rows[i].Cells[3].FindControl("txtContactNo");
                        TextBox box4 = (TextBox)GridPersonDetails.Rows[i].Cells[4].FindControl("txtEmail");
                        if (box1.Text == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Failure", "showToast('Failure','Enter Descriptions Before Adding New Row',2000);", true);
                            box1.Focus();
                            return;
                        }
                        if (box2.Text == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Failure", "showToast('Failure','Enter Person Name Before Adding New Row',2000);", true);
                            box2.Focus();
                            return;
                        }
                        if (box3.Text == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Failure", "showToast('Failure','Enter Contact Before Adding New Row',2000);", true);
                            box3.Focus();
                            return;
                        }
                        if (box4.Text == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "Failure", "showToast('Failure','Enter EmailID Before Adding New Row',2000);", true);
                            box4.Focus();
                            return;
                        }

                        dtCurrentTable.Rows[i]["ContactDetailID"] = "0";
                        dtCurrentTable.Rows[i]["PersonTypeID"] = "1";
                        dtCurrentTable.Rows[i]["ContactName"] = box2.Text;
                        dtCurrentTable.Rows[i]["ContactNo"] = box3.Text;
                        dtCurrentTable.Rows[i]["EmailID"] = box4.Text;
                        dtCurrentTable.Rows[i]["Descriptions"] = box1.Text;
                        dtCurrentTable.Rows[i]["DesignationID"] = "0";
                    }


                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GridPersonDetails.DataSource = dtCurrentTable;
                    GridPersonDetails.DataBind();
                    if (GridPersonDetails.Rows.Count > 0)
                    {
                        TextBox box1 = (TextBox)GridPersonDetails.Rows[GridPersonDetails.Rows.Count - 1].Cells[1].FindControl("txtDescription");
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
                        TextBox box1 = (TextBox)GridPersonDetails.Rows[i].Cells[1].FindControl("txtDescription");
                        TextBox box2 = (TextBox)GridPersonDetails.Rows[i].Cells[2].FindControl("txtName");
                        TextBox box3 = (TextBox)GridPersonDetails.Rows[i].Cells[3].FindControl("txtContactNo");
                        TextBox box4 = (TextBox)GridPersonDetails.Rows[i].Cells[4].FindControl("txtEmail");
                        if (i < dt.Rows.Count - 1)
                        {
                            box1.Text = dt.Rows[i]["Descriptions"].ToString();
                            box2.Text = dt.Rows[i]["ContactName"].ToString();
                            box3.Text = dt.Rows[i]["ContactNo"].ToString();
                            box4.Text = dt.Rows[i]["EmailID"].ToString();
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

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            string Mode = "Add";
            try
            {
                var UserDetails = UsersSession.GetSession();
                _Common = new ASR_Common();
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                dt.Columns.RemoveAt(0);
                dt.AcceptChanges();
                dt.TableName = "ContactDetails";
                if (hddCompanyID.Value != "0")
                {
                    Mode = "Edit";
                }
                _Parameters = new CompanyParameters
                {
                    Str_Mode = Mode,
                    Str_CompanyID = UserDetails.Str_CompanyID,
                    Str_SelectID = "13",
                    Str_ClientID = hddCompanyID.Value,
                    Str_CompanyName = txtCompanyName.Text.Trim(),
                    Str_AddressOne = txtAddress.Text.Trim(),
                    Str_CityName = txtCity.Text.Trim(),
                    Str_Pincode = txtPincode.Text.Trim(),
                    Str_StateName = txtState.Text.Trim(),
                    Str_CountryName = txtCountry.Text.Trim(),
                    Str_MonthName = txtSalaryStart.Text.Trim(),
                    Str_AttachFilePathOne = FileUploading == null ? "" : FileUploading.FileName,
                    Bool_IsActive = true,
                    _DataTable = dt,
                    Str_LoginID = UserDetails.Str_LoginID
                };
                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/IUPayMax/MsCompanyMaster";
                HttpContent inputContent = new StringContent(JsonConvert.SerializeObject(_Parameters, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }), Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, inputContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    _Parameters = new JavaScriptSerializer().Deserialize<CompanyParameters>(response.Content.ReadAsStringAsync().Result);
                    if (_Parameters.Str_Status != null)
                    {
                        if (_Parameters.Str_Status == "Success")
                        {
                            UsersSession.GetMessages(this, _Parameters.Str_Status, _Parameters.Str_Result);
                            ClearBox();
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

        private void ClearBox()
        {
            hddCompanyID.Value = "0";

            Str_Path = Path.Combine(Server.MapPath("~/Images/ImageProject/"));
            Str_ServerPath = HttpContext.Current.Request.IsSecureConnection ? Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + "/ImageProject/" : Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + ":" + Request.Url.Port + "/ImageProject/";
            SetInitialRow();
        }

        protected void FileUploading_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            FileUploading.SaveAs(Str_Path + FileUploading.FileName);
            ImgCompany.ImageUrl = Str_Path + FileUploading.FileName;
            //  createFile(strPath, strServerPath, strThread);

            if (!Directory.Exists(Str_Path))
            {
                Directory.CreateDirectory(Str_Path);
            }
            else
            {
                try
                {
                    string[] OldFiles = Directory.GetFiles(Str_Path)
                                 .Where(x => new FileInfo(x).CreationTime.Date != DateTime.Today.Date).ToArray();
                    foreach (string file in OldFiles)
                    {
                        FileInfo info = new FileInfo(file);
                        info.Delete();
                    }
                }
                catch (Exception _Exception)
                {
                    _Exception.ToString();
                }
            }

        }

        protected void LknButton_Click(object sender, EventArgs e)
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
                GridPersonDetails.DataSource = dt;
                GridPersonDetails.DataBind();
            }
            SetPreviousData();
        }

    }
}