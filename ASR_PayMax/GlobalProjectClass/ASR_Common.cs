using ASR_CommonLogic.Models;
using ASR_PayMax.Masters;
using ASR_PayMaxLogic.Models;
using ExcelDataReader;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ASR_PayMax.GlobalProjectClass
{
    public class ASR_Common
    {
        HttpResponseMessage response;
        ASR_PayMaxParameters[] arr;
        DataSet _DataSet;
        public ASR_PayMaxParameters ModifiedData(ASR_PayMaxParameters _PayMaxParameters)
        {
            _PayMaxParameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/UpdateDetails";

            response = new HttpClient().PostAsync(_PayMaxParameters.Str_ApiUrl, new StringContent(new JavaScriptSerializer().Serialize(_PayMaxParameters), Encoding.UTF8, "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                return new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return _PayMaxParameters = null;
            }
        }

        public void BindDropDown(Page _Page, DropDownList ddl, ASR_PayMaxParameters _Parameters)
        {

            response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                ASR_PayMaxParameters[] arr = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters[]>(response.Content.ReadAsStringAsync().Result);
                if (arr[0].Str_Status == "Get")
                {
                    ddl.DataSource = arr;
                    ddl.DataTextField = "Str_GlobalName";
                    ddl.DataValueField = "Str_GlobalID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, "Select One");
                }
                else
                {
                    UsersSession.GetMessages(_Page, _Parameters.Str_Status, _Parameters.Str_Result);
                }
            }
            else
            {
                UsersSession.GetMessages(_Page, _Parameters.Str_Status, _Parameters.Str_Result);
            }

        }
        public void BindListBox(Page _Page, ListBox ddl, ASR_PayMaxParameters _Parameters)
        {

            response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                ASR_PayMaxParameters[] arr = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters[]>(response.Content.ReadAsStringAsync().Result);
                if (arr[0].Str_Status == "Get")
                {
                    ddl.DataSource = arr;
                    ddl.DataTextField = "Str_GlobalName";
                    ddl.DataValueField = "Str_GlobalID";
                    ddl.DataBind();
                    //ddl.Items.Insert(0, "Select One");
                }
                else
                {
                    UsersSession.GetMessages(_Page, _Parameters.Str_Status, _Parameters.Str_Result);
                }
            }
            else
            {
                UsersSession.GetMessages(_Page, _Parameters.Str_Status, _Parameters.Str_Result);
            }

        }
        public void BindGrid(Page _Page, GridView Grid, ASR_PayMaxParameters _Parameters)
        {
            response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                _DataSet = JsonConvert.DeserializeObject<DataSet>(response.Content.ReadAsStringAsync().Result);
                if (_DataSet != null)
                {
                    if (_DataSet.Tables.Count > 0)
                    {
                        if (_DataSet.Tables[0] != null)
                        {
                            if (_DataSet.Tables[0].Rows.Count > 0)
                            {
                                Grid.DataSource = _DataSet.Tables[0];
                                Grid.DataBind();
                            }
                        }
                    }
                }
            }
            else
            {
                UsersSession.GetMessages(_Page, _Parameters.Str_Status, _Parameters.Str_Result);
            }
        }
        public ASR_PayMaxParameters[] _ReturnArray(ASR_PayMaxParameters _Parameters)
        {

            response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                arr = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters[]>(response.Content.ReadAsStringAsync().Result);
                if (arr[0].Str_Status == "Get")
                {
                    return arr;
                }
                else
                {
                    return arr = null;
                }
            }
            else
            {
                return arr = null;
            }
        }
        public DataSet _ReturnDataSet(ASR_PayMaxParameters _Parameters)
        {
            try
            {
                response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    _DataSet = JsonConvert.DeserializeObject<DataSet>(response.Content.ReadAsStringAsync().Result);
                    if (_DataSet != null)
                    {
                        if (_DataSet.Tables.Count > 0)
                        {
                            return _DataSet;
                        }
                        else
                        {
                            return _DataSet = null;
                        }
                    }
                    else
                    {
                        return _DataSet = null;
                    }
                }
                else
                {
                    return _DataSet = null;
                }
            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
                return _DataSet = null;
            }
        }
        public bool IUMasters(Page _Page, ASR_PayMaxParameters _Parameters)
        {
            try
            {
                HttpContent inputContent = new StringContent(new JavaScriptSerializer().Serialize(_Parameters), Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpClient().PostAsync(_Parameters.Str_ApiUrl, inputContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    _Parameters = new JavaScriptSerializer().Deserialize<ASR_PayMaxParameters>(response.Content.ReadAsStringAsync().Result);
                    if (_Parameters != null)
                    {

                        if (_Parameters.Str_Status != null)
                        {
                            if (_Parameters.Str_Status == "Success")
                            {
                                UsersSession.GetMessages(_Page, _Parameters.Str_Status, _Parameters.Str_Result.Replace("'", ""));
                                return true;
                            }
                            else
                            {
                                UsersSession.GetMessages(_Page, _Parameters.Str_Status, _Parameters.Str_Result.Replace("'",""));
                                return false;
                            }
                        }
                        else
                        {
                            UsersSession.GetMessages(_Page, "Failure", "Does not Get Any Output.");
                            return false;
                        }
                    }
                    else
                    {
                        UsersSession.GetMessages(_Page, "Failure", "Class Does not Get Any Output.");
                        return false;
                    }
                }
                else
                {
                    UsersSession.GetMessages(_Page, "Failure", "Parameters Getting Null Values.");
                    return false;
                }
            }
            catch (Exception _Exception)
            {
                UsersSession.GetMessages(_Page, "Failure", _Exception.Message);
                return false;
            }
        }
        public void IUError(Page _Page, string Str_PageName, string Str_PageUrl, string Str_PageEvent, string Str_FunctionName, string Str_LineNo, string Str_ErrorSource, string Str_ErrorMessage, string Str_ErrorDetails)
        {
            try
            {
                ErrorLogDetails _ErrorLogDetail = new ErrorLogDetails();
                _ErrorLogDetail.Str_PageName = Str_PageName;
                _ErrorLogDetail.Str_PageUrl = Str_PageUrl;
                _ErrorLogDetail.Str_PageEvent = Str_PageEvent;
                _ErrorLogDetail.Str_FunctionName = Str_FunctionName;
                _ErrorLogDetail.Str_LineNo = Str_LineNo;
                _ErrorLogDetail.Str_ErrorSource = Str_ErrorSource;
                _ErrorLogDetail.Str_ErrorMessage = Str_ErrorMessage;
                _ErrorLogDetail.Str_ErrorDetails = Str_ErrorDetails;
                HttpContent inputContent = new StringContent(new JavaScriptSerializer().Serialize(_ErrorLogDetail), Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpClient().PostAsync("api/IUPayMax/ErrorLogDetails", inputContent).Result;

            }
            catch (Exception _Exception)
            {
                _Exception.ToString();
            }
        }

        public string Get_Url(Page _Page,string strPath)
        {
            return _Page.Request.IsSecureConnection ? _Page.Request.Url.Scheme + "://" + _Page.Request.Url.Host + "/" + strPath + "/" : _Page.Request.Url.Scheme + "://" + _Page.Request.Url.Host + ":" + _Page.Request.Url.Port + "/" + strPath + "/";
        }
        public DataSet Get_ConvertExcelToDataSet(FileStream Mystream)
        {
            IExcelDataReader Reader = null;

            if (Mystream.Name.EndsWith(".xls"))
                Reader = ExcelReaderFactory.CreateBinaryReader(Mystream);
            else if (Mystream.Name.EndsWith(".xlsx"))
                Reader = ExcelReaderFactory.CreateOpenXmlReader(Mystream);
            else
                throw new Exception("Invalid FileName");

            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };
            DataSet result = Reader.AsDataSet(conf);
            return result;
        }
        public string Get_FileNameWithExtensionFromPath(string FileWithPath)
        {
            string str = "";
            str = FileWithPath.Substring(FileWithPath.LastIndexOf('\\'), FileWithPath.Length - FileWithPath.LastIndexOf('\\'));
            return str.Replace("\\", "");
        }
        public string Get_FileNameWithoutExtension(string FileName)
        {
            string str = "";
            str = FileName.Substring(0, FileName.LastIndexOf('.'));
            return str;
        }
        public void LoadImage(DataRow objDataRow, string strImageField, string FilePath)
        {
            try
            {
                FileStream fs = new FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                byte[] Image = new byte[fs.Length];
                fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                objDataRow[strImageField] = Image;
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }
        public string Get_ConvertDataTableToJsonString(DataTable dt)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }
        public DataTable Get_ConvertJsonStringToTable(string jsonContent)
        {
            DataTable _DataTable;
            return _DataTable = JsonConvert.DeserializeObject<DataTable>(jsonContent);
        }
        public DataTable Get_ConvertCsvToDataTable(string FileSaveWithPath)
        {
            DataTable dtCsv = new DataTable();
            string Fulltext;
            using (StreamReader sr = new StreamReader(FileSaveWithPath))
            {
                while (!sr.EndOfStream)
                {
                    Fulltext = sr.ReadToEnd().ToString(); //read full file text  
                    string[] rows = Fulltext.Split('\n'); //split full file text into rows  
                    for (int i = 0; i < rows.Length - 1; i++)
                    {
                        string[] rowValues = rows[i].Split(','); //split each row with comma to get individual values  
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < rowValues.Length; j++)
                                {
                                    dtCsv.Columns.Add(rowValues[j]); //add headers  
                                }
                            }
                            else
                            {
                                DataRow dr = dtCsv.NewRow();
                                for (int k = 0; k < rowValues.Length; k++)
                                {
                                    dr[k] = rowValues[k].ToString();
                                }
                                dtCsv.Rows.Add(dr); //add other rows  
                            }
                        }
                    }
                }
            }
            return dtCsv;
        }
        public string Get_ConvertDataTableToCSV(DataTable datatable, char seperator)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < datatable.Columns.Count; i++)
            {
                sb.Append(datatable.Columns[i]);
                if (i < datatable.Columns.Count - 1)
                    sb.Append(seperator);
            }
            sb.AppendLine();
            foreach (DataRow dr in datatable.Rows)
            {
                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    sb.Append(dr[i].ToString());

                    if (i < datatable.Columns.Count - 1)
                        sb.Append(seperator);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
        #region Created by Jay kumar Patel On 07 October 2019  Other Details
        public DataSet Get_ConvertXMLtoDataSet(ASR_Common _MaxCommonParameter, string strFileName)
        {
            _MaxCommonParameter._DataSet = new DataSet();
            try
            {
                _MaxCommonParameter._DataSet.ReadXml(strFileName);
                return _MaxCommonParameter._DataSet;
            }
            catch (Exception Ex)
            {
                Ex.ToString();
                return _MaxCommonParameter._DataSet;
            }
        }
        public string Get_ConvertDataTableToXMLString(DataTable dt)
        {
            try
            {
                XDocument _XDocument = new XDocument(new XDeclaration("1.0", "utf-8", "true"));
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        XElement _XElement = new XElement(col.ColumnName, row[col]);
                        _XDocument.Add(_XElement);
                    }
                }
                string _encodedXML = string.Format("<pre>{0}</pre>", HttpUtility.HtmlEncode(_XDocument));
                return _encodedXML;
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
        }

        public void Get_ConvertDataTableToExcel(Page _Page, DataTable dt, string FileName)
        {
            string attachment = "attachment; filename=" + FileName + ".xls";
            _Page.Response.ClearContent();
            _Page.Response.AddHeader("content-disposition", attachment);
            _Page.Response.ContentType = "application/vnd.ms-excel";
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            Table table = new Table();
            TableHeaderRow th = new TableHeaderRow();
            foreach (DataColumn dc in dt.Columns)
            {
                TableHeaderCell tc = new TableHeaderCell();
                tc.Wrap = false;
                if (dc.ColumnName.Substring(dc.ColumnName.Length - 2).ToUpper() != "ID")
                {
                    tc.Text = dc.ColumnName;
                    tc.BackColor = Color.LightGray;
                    tc.Attributes.Add("font-weight", "bold");
                    th.Cells.Add(tc);
                }
            }
            table.Rows.Add(th);
            TableRow row;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = new TableRow();
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.ColumnName.Substring(col.ColumnName.Length - 2).ToUpper() != "ID")
                    {
                        TableCell tc = new TableCell();
                        tc.Wrap = false;
                        tc.Text = dt.Rows[i][col.ColumnName].ToString();
                        row.Cells.Add(tc);
                    }
                }
                table.Rows.Add(row);
            }
            table.GridLines = GridLines.Both;
            table.RenderControl(hw);
            _Page.Response.Write(tw);
            _Page.Response.End();
        }

        #endregion
    }
}