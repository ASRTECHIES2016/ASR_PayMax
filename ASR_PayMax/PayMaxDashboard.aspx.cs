using ASR_PayMax.GlobalProjectClass;
using ASR_PayMaxLogic.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASR_PayMax
{
    public partial class PayMaxDashboard : System.Web.UI.Page
    {
        static UserControl userControl;

        protected void Page_Load(object sender, EventArgs e)
        {
            CreatePDF();
            if (!IsPostBack)
            {
                // userControl = (UserControl)Page.LoadControl("~/UserControls/CtrlDashBoard.ascx");
                //pnlDynamic.Controls.Add(userControl);
            }
            //ASR_PayMaxParameters
            //     p = new ASR_PayMaxParameters();
            //p.Str_LoginID = "1";
            //p.Str_SessionTimeOut = "20";
            //p.Str_CompanyID = "1";

            //UsersSession.SetSession(p);
        }
        [WebMethod]
        public static ASR_PayMaxParameters[] Get_EmployeeDetailByCode(string Prefix)
        {
            return Get_EmployeeDetail("Code", "0", Prefix);
        }

        [WebMethod]
        public static ASR_PayMaxParameters[] Get_EmployeeDetailByID(string Prefix)
        {
            return Get_EmployeeDetail("ID", Prefix, "0");
        }

        [WebMethod]
        public static ASR_PayMaxParameters[] Get_EmployeeDetailByFirstName(string Prefix)
        {
            return Get_EmployeeDetail("FirstName", "0", Prefix);
        }

        [WebMethod]
        public static ASR_PayMaxParameters[] Get_EmployeeDetailByMiddleName(string Prefix)
        {
            return Get_EmployeeDetail("MiddleName", "0", Prefix);
        }

        [WebMethod]
        public static ASR_PayMaxParameters[] Get_EmployeeDetailByLastName(string Prefix)
        {
            return Get_EmployeeDetail("LastName", "0", Prefix);
        }
        [WebMethod]
        public static ASR_PayMaxParameters[] Get_EmployeeDetailByFullName(string Prefix)
        {
            return Get_EmployeeDetail("FullName", "0", Prefix);
        }
        [WebMethod]
        public static ASR_PayMaxParameters[] Get_UserByFullName(string Prefix)
        {
            return Get_UserDetail("FullName", "0", Prefix);
        }
        [WebMethod]
        public static ASR_PayMaxParameters[] Get_Pincode(string Prefix)
        {
            return Get_EmployeeDetail("FullName", "0", Prefix);
        }
        [WebMethod]
        public static ASR_PayMaxParameters[] Get_City(string Prefix)
        {
            return Get_EmployeeDetail("FullName", "0", Prefix);
        }
        [WebMethod]
        public static ASR_PayMaxParameters[] Get_State(string Prefix)
        {
            return Get_EmployeeDetail("FullName", "0", Prefix);
        }
        [WebMethod]
        public static ASR_PayMaxParameters[] Get_Country(string Prefix)
        {
            return Get_EmployeeDetail("FullName", "0", Prefix);
        }
        public static ASR_PayMaxParameters[] Get_UserDetail(string Str_Mode, string Str_EmployeeID, string Prefix)
        {
            ASR_Common _Common = new ASR_Common();
            ASR_PayMaxParameters _Parameters = new ASR_PayMaxParameters();

            var UserDetails = UsersSession.GetSession();
            _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
            _Parameters.Str_LoginID = UserDetails.Str_LoginID;
            _Parameters.Str_Mode = Str_Mode;
            _Parameters.Str_UserID = Str_EmployeeID;
            _Parameters.Str_UserName = Prefix;
            _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetUserMaster";
            return _Common._ReturnArray(_Parameters);
        }
        public static ASR_PayMaxParameters[] Get_EmployeeDetail(string Str_Mode, string Str_EmployeeID, string Prefix)
        {
            ASR_Common _Common = new ASR_Common();
            ASR_PayMaxParameters _Parameters = new ASR_PayMaxParameters();

            var UserDetails = UsersSession.GetSession();
            _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
            _Parameters.Str_LoginID = UserDetails.Str_LoginID;
            _Parameters.Str_Mode = Str_Mode;
            _Parameters.Str_EmployeeID = Str_EmployeeID;
            _Parameters.Str_EmployeeName = Prefix;
            _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetEmployeeCode";
            return _Common._ReturnArray(_Parameters);
        }




        [WebMethod]
        public static ASR_PayMaxParameters[] Get_UnPostedEmployeeByCode(string Prefix)
        {
            return Get_UnPostedEmployee("Code", "0", Prefix);
        }

        [WebMethod]
        public static ASR_PayMaxParameters[] Get_UnPostedEmployeeID(string Prefix)
        {
            return Get_UnPostedEmployee("ID", Prefix, "0");
        }

        [WebMethod]
        public static ASR_PayMaxParameters[] Get_UnPostedEmployeeByFirstName(string Prefix)
        {
            return Get_UnPostedEmployee("FirstName", "0", Prefix);
        }

        [WebMethod]
        public static ASR_PayMaxParameters[] Get_UnPostedEmployeeByMiddleName(string Prefix)
        {
            return Get_UnPostedEmployee("MiddleName", "0", Prefix);
        }

        [WebMethod]
        public static ASR_PayMaxParameters[] Get_UnPostedEmployeeByLastName(string Prefix)
        {
            return Get_UnPostedEmployee("LastName", "0", Prefix);
        }
        [WebMethod]
        public static ASR_PayMaxParameters[] Get_UnPostedEmployeeByFullName(string Prefix)
        {
            return Get_UnPostedEmployee("FullName", "0", Prefix);
        }

        public static ASR_PayMaxParameters[] Get_UnPostedEmployee(string Str_Mode, string Str_EmployeeID, string Prefix)
        {
            ASR_Common _Common = new ASR_Common();
            ASR_PayMaxParameters _Parameters = new ASR_PayMaxParameters();

            var UserDetails = UsersSession.GetSession();
            _Parameters.Str_CompanyID = UserDetails.Str_CompanyID;
            _Parameters.Str_LoginID = UserDetails.Str_LoginID;
            _Parameters.Str_Mode = Str_Mode;
            _Parameters.Str_EmployeeID = Str_EmployeeID;
            _Parameters.Str_EmployeeName = Prefix;
            _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMax/GetUnPostedEmployee";
            return _Common._ReturnArray(_Parameters);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static void CtrlDynamicLoad(string CtrlName)
        {
            PayMaxDashboard _PayMaxDashboard = new PayMaxDashboard();
            _PayMaxDashboard.CtrlDynamicLoadPage(CtrlName);

            //Page page = (Page)HttpContext.Current.Handler;
            //Panel p = new Panel();
            //userControl = (UserControl)page.LoadControl("~/UserControls/" + CtrlName + ".ascx");// "~/MyControl.ascx");
            //p.Controls.Add(userControl);
            //page.Controls.Add(p);
        }

        public void CtrlDynamicLoadPage(string CtrlName)
        {

            Page page = (Page)HttpContext.Current.PreviousHandler;
            userControl = (UserControl)Page.LoadControl("~/UserControls/" + CtrlName + ".ascx");// "~/MyControl.ascx");
                                                                                                //string[] a=      HttpContext.Current.Request.Form.AllKeys;//   pnlDynamic.Controls.Add(userControl);
                                                                                                //      pnlDynamic.Controls.Add(userControl);

        }
        private void CreatePDF()
        {
            try
            {

                string fileName = string.Empty;
                DateTime fileCreationDatetime = DateTime.Now;
                fileName = string.Format("{0}.pdf", fileCreationDatetime.ToString(@"yyyyMMdd") + "_" + fileCreationDatetime.ToString(@"HHmmss"));
                string pdfPath = Server.MapPath(@"~\PDFs\");
                Directory.CreateDirectory(pdfPath);

                //        using (FileStream msReport = new FileStream(pdfPath, FileMode.Create))
                //{
                //step 1  
                using (Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 140f, 10f))
                {
                    try
                    {
                        // step 2  
                        //      PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, msReport);
                        PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, new FileStream(pdfPath + fileName, FileMode.Create, FileAccess.ReadWrite));

                        pdfWriter.PageEvent = new ITextEvents();

                        //open the stream   
                        pdfDoc.Open();

                        for (int i = 0; i < 10; i++)
                        {
                            Paragraph para = new Paragraph("Hello world. Checking Header Footer", new Font(Font.FontFamily.HELVETICA, 22));
                            para.Alignment = Element.ALIGN_CENTER;
                            pdfDoc.Add(para);
                            pdfDoc.NewPage();
                        }

                        pdfDoc.Close();
                    }
                    catch (Exception ex)
                    {
                        //handle exception  
                    }
                    finally
                    {
                    }
                }
                // }

            }
            catch (Exception _Exception)
            {
                _Exception.Message.ToString();
            }
        }

    }
    public class ITextEvents : PdfPageEventHelper
    {
        PdfContentByte cb;
        PdfTemplate headerTemplate, footerTemplate;
        BaseFont bf = null;
        DateTime PrintTime = DateTime.Now;
        #region Fields  
        private string _header;
        #endregion
        #region Properties  
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        #endregion

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                headerTemplate = cb.CreateTemplate(100, 100);
                footerTemplate = cb.CreateTemplate(100, 100);
            }
            catch (DocumentException _DocumentException)
            {
                _DocumentException.Message.ToString();
            }
            catch (System.IO.IOException _IOException)
            {
                _IOException.Message.ToString();
            }
        }

        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);
            iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            Phrase p1Header = new Phrase("Sample Header Here", baseFontNormal);
            PdfPTable pdfTab = new PdfPTable(3);
            PdfPCell pdfCell2 = new PdfPCell(p1Header);
            pdfCell2.Colspan = 3;
            pdfCell2.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell2.VerticalAlignment = Element.ALIGN_BOTTOM;
            pdfCell2.Border = 0;
            pdfTab.AddCell(pdfCell2);
            pdfTab.TotalWidth = document.PageSize.Width - 80f;
            pdfTab.WidthPercentage = 70;
            pdfTab.HorizontalAlignment = Element.ALIGN_CENTER;

            //Add paging to footer  
            String text = "Page " + writer.PageNumber + " of ";

            cb.BeginText();
            cb.SetFontAndSize(bf, 8);
            cb.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetBottom(10));
            cb.ShowText(text);
            cb.EndText();
            float len = bf.GetWidthPoint(text, 8);
            cb.AddTemplate(footerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetBottom(10));

            //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable  
            //first param is start row. -1 indicates there is no end row and all the rows to be included to write  
            //Third and fourth param is x and y position to start writing  
            pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);
            //set pdfContent value  

            //Move the pointer and draw line to separate header section from rest of page  
            cb.MoveTo(10, document.PageSize.Height - 100);
            cb.LineTo(document.PageSize.Width - 10, document.PageSize.Height - 100);
            cb.Stroke();

            //Move the pointer and draw line to separate footer section from rest of page  
            cb.MoveTo(10, document.PageSize.GetBottom(20));
            cb.LineTo(document.PageSize.Width - 10, document.PageSize.GetBottom(20));
            cb.Stroke();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            headerTemplate.BeginText();
            headerTemplate.SetFontAndSize(bf, 8);
            headerTemplate.SetTextMatrix(0, 0);
            headerTemplate.ShowText((writer.PageNumber - 1).ToString());
            headerTemplate.EndText();

            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 8);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber - 1).ToString());
            footerTemplate.EndText();
        }
    }
}