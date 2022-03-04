using ASR_PayMaxLogic.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace ASR_PayMax.GlobalProjectClass
{
    public class GeneratePdf_Report : SiteMasterParameters
    {
        Document doc = null;
        string FileName = string.Empty;
        string Message = string.Empty;
        Paragraph FullCompanyName = null;

        //  public string GenerateWiseRegister(GeneratePdf_Report _Report, DataSet PaySlipData, string strFilePath, string strServerPath, string strCompanyLogoPath)
        public string GenerateWiseRegister(GeneratePdf_Report _Report, SiteMasterParameters _PayMaxParameters)//,DataSet PaySlipData, string strFilePath, string strServerPath, string strCompanyLogoPath)
        {
            try
            {
                doc = new Document(PageSize._11X17.Rotate(), 10f, 10f, 5f, 5f);

                FileName = _Report.Str_Narration;
                DataSet PaySlipData = _PayMaxParameters._DataSet;

                DataTable rptEmployeeDetails, rptCompanyTable, rptSalaryTable;

                if (PaySlipData != null)
                {
                    if (PaySlipData.Tables[0] != null)
                    {
                        if (PaySlipData.Tables[0].Rows.Count > 0)
                        {
                            rptCompanyTable = PaySlipData.Tables[0];
                            rptEmployeeDetails = PaySlipData.Tables[1];
                            rptSalaryTable = PaySlipData.Tables[2];
                        }
                        else
                        {
                            rptEmployeeDetails = null; return FileName="";
                        }
                    }
                    else
                    {
                        _DataTable = null; return FileName="";
                    }
                }
                else
                {
                    return FileName="";
                }
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(_PayMaxParameters.Str_LocalFilePathOne + FileName, FileMode.Create));

                PdfPTable EmployeeEarning;
                PdfPTable EmployeeDeduction;
                EmployeeEarning = new PdfPTable(3);
                EmployeeDeduction = new PdfPTable(2);
                PdfPTable HeaderTbl = new PdfPTable(3);
                PdfPCell Cell;
                float TotalAmount = 0f;
                float TotalEarnAmount = 0f;
                float TotalDedAmount = 0f;
                string TwoDecimalOnlyFirstValue = "";
                string TwoDecimalOnlySecondValue = "";

                if (!doc.IsOpen())
                {
                    doc.Open();
                }


                float[] HeaderTblCellWidth = new float[] { 35, 25, 40 };
                HeaderTbl.SetWidths(HeaderTblCellWidth);
                HeaderTbl.WidthPercentage = 100;

                FullCompanyName = new Paragraph();
                FullCompanyName.Add(new Chunk("Name & Address of Contractor \n\n" + Convert.ToString(rptCompanyTable.Rows[0]["ClientName"]) + "\n\nPF Establishment No. \n\n " + Convert.ToString(rptCompanyTable.Rows[0]["BranchCode"]) + "\n\nNature & Location of Work \n\n" + Convert.ToString(rptCompanyTable.Rows[0]["SiteName"]) + "\n\nWages Register for the Month : " + _PayMaxParameters.Str_MonthName + _PayMaxParameters.Str_YearName + "\n\n", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8)));
                Cell = new PdfPCell(FullCompanyName);
                Cell.HorizontalAlignment = Element.ALIGN_LEFT;
                Cell.PaddingLeft = 0;
                Cell.Border = 0;
                HeaderTbl.AddCell(Cell);

                FullCompanyName = new Paragraph();
                FullCompanyName.Add(new Chunk("  FORM NO 13 \n\n", FontFactory.GetFont(FontFactory.COURIER_BOLD, 10)));
                FullCompanyName.Add(new Chunk("   [77(a)(i)] \n\n", FontFactory.GetFont(FontFactory.COURIER, 8)));
                FullCompanyName.Add(new Chunk("REGISTER OF WAGES", FontFactory.GetFont(FontFactory.COURIER_BOLD, 9)));
                Cell = new PdfPCell(FullCompanyName);
                Cell.Padding = 2;
                Cell.Border = 0;
                HeaderTbl.AddCell(Cell);

                FullCompanyName = new Paragraph();
                FullCompanyName.Add(new Chunk("Name & Address of Establishment in under which contract is carried on \n\n" + Convert.ToString(rptCompanyTable.Rows[0]["BranchName"]) + "\n\nName & Address of Principal Employer \n\n" + Convert.ToString(rptCompanyTable.Rows[0]["Branch Address"]) + "\n\nCost Center Code  \n\n" + Convert.ToString(rptCompanyTable.Rows[0]["SiteCode"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8)));
                Cell = new PdfPCell(FullCompanyName);
                Cell.HorizontalAlignment = Element.ALIGN_LEFT;
                Cell.PaddingLeft = 0;
                Cell.Border = 0;
                HeaderTbl.AddCell(Cell);
                doc.Add(HeaderTbl);

                #region Loop for Employees
                float[] EmployeeTblCellWidth = new float[] { 11, 9, 8, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7 };

                PdfPTable EmployeeParentTbl = new PdfPTable(1);
                EmployeeParentTbl.DefaultCell.Border = 0;
                EmployeeParentTbl.WidthPercentage = 100;
                EmployeeParentTbl.KeepTogether = true;

                PdfPTable EmployeeHeaderTbl = new PdfPTable(17);
                EmployeeHeaderTbl.SetWidths(EmployeeTblCellWidth);
                EmployeeHeaderTbl.DefaultCell.Border = 0;
                EmployeeHeaderTbl.WidthPercentage = 100;
                EmployeeHeaderTbl.KeepTogether = true;

                PdfPTable EmployeeTbl = new PdfPTable(17);
                EmployeeTbl.SetWidths(EmployeeTblCellWidth);
                EmployeeTbl.DefaultCell.Border = 0;
                EmployeeTbl.WidthPercentage = 100;
                EmployeeTbl.KeepTogether = true;


                Cell = new PdfPCell(new Paragraph(""));
                Cell.Border = 0;
                Cell.Colspan = 5;
                EmployeeHeaderTbl.AddCell(Cell);

                Cell = new PdfPCell(new Paragraph("Rates"));
                Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                Cell.Colspan = 3;
                EmployeeHeaderTbl.AddCell(Cell);

                Cell = new PdfPCell(new Paragraph("Earning"));
                Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                Cell.Colspan = 4;
                EmployeeHeaderTbl.AddCell(Cell);

                Cell = new PdfPCell(new Paragraph("Deduction"));
                Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                Cell.Colspan = 3;
                EmployeeHeaderTbl.AddCell(Cell);

                Cell = new PdfPCell(new Paragraph(""));
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                Cell = new PdfPCell(new Paragraph(""));
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                #region Add Cells

                Paragraph EmployeeDetail = new Paragraph(" Sr No.", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                Paragraph LBLBankName = new Paragraph("Bank Name", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLBankName);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                Paragraph LBLESI = new Paragraph("PF NO", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLESI);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                Paragraph LBLDayWork = new Paragraph("Day Work", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLDayWork);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("PL", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("Basic", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("Wash", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("Medi", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("Basic", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("Wash", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("PuncAll", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("Medi", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("PF", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("Advance", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("Food", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("Net", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                EmployeeHeaderTbl.AddCell(Cell);
                EmployeeDetail = new Paragraph("Signature", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph(" Emp Code", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                LBLBankName = new Paragraph("Pay Mode", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLBankName);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                LBLESI = new Paragraph("ESI NO ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLESI);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                LBLDayWork = new Paragraph("LOP", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLDayWork);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("CL", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("VDA", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("SPAll", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("Bonus", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("VDA", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("SPAll", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("AttAWD", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("Bonus", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("ESI", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("Uni", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("PT", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("Salary", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                EmployeeHeaderTbl.AddCell(Cell);
                EmployeeDetail = new Paragraph("With", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph(" Employee Name", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                LBLBankName = new Paragraph("Acc / Card No.", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLBankName);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                LBLESI = new Paragraph("DOB", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLESI);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                LBLDayWork = new Paragraph("Day Paid", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLDayWork);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                LBLDayWork = new Paragraph("SL", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLDayWork);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("HRA", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("Conv", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("LeaveEn", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("HRA", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("Conv", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("GWR", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("LeaveEn", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("LWF", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("Fine", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("Ins", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph(" ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                EmployeeHeaderTbl.AddCell(Cell);
                EmployeeDetail = new Paragraph("Stamp", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph(" Father's/Husband Name", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                LBLBankName = new Paragraph("IFSC Code", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLBankName);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                LBLESI = new Paragraph("DOJ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLESI);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                LBLDayWork = new Paragraph(" ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLDayWork);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                LBLDayWork = new Paragraph(" ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLDayWork);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("O.All", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("EduAll", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph(" ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("O.All", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("EduAll", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("Dis/Sen", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph(" ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("CWF", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("O.Ded", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph(" ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph(" ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);
                EmployeeDetail = new Paragraph(" ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph(" Designation", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                LBLBankName = new Paragraph("UAN No", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLBankName);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                LBLESI = new Paragraph("", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLESI);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                LBLDayWork = new Paragraph("", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(LBLDayWork);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("Salary Rate", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph(" ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph(" ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("Gross", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph(" ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph(" ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("ADJ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph("Gross", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("IT", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph(" ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);


                EmployeeDetail = new Paragraph("Total Ded \n\n", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);
                EmployeeDetail = new Paragraph(" ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                EmployeeDetail = new Paragraph(" ", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                Cell = new PdfPCell(EmployeeDetail);
                Cell.Border = 0;
                EmployeeHeaderTbl.AddCell(Cell);

                Cell = new PdfPCell(EmployeeHeaderTbl);
                //Cell.Border = 0;
                EmployeeParentTbl.AddCell(Cell);

                doc.Add(EmployeeParentTbl);

                for (int j = 0; j < rptEmployeeDetails.Rows.Count; j++)
                {
                    DataView dataView = new DataView(rptSalaryTable, "EmployeeID= " + Convert.ToString(rptEmployeeDetails.Rows[j]["EmployeeID"]), "", DataViewRowState.CurrentRows);
                    _DataTable = dataView.ToTable();

                    for (int i = 0; i < _DataTable.Rows.Count; i++)
                    {
                        #region Company Details
                        // 1 Line
                        EmployeeDetail = new Paragraph(" " + Convert.ToString(i + 1), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        LBLBankName = new Paragraph(Convert.ToString(rptEmployeeDetails.Rows[j]["Bank Name"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(LBLBankName);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        LBLESI = new Paragraph(Convert.ToString(rptEmployeeDetails.Rows[j]["PF No"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(LBLESI);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        LBLDayWork = new Paragraph(Convert.ToString(rptEmployeeDetails.Rows[j]["NormalDays"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(LBLDayWork);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(rptEmployeeDetails.Rows[j]["PaidHolidays"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["BA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["WA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

               //         EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["Fixed_WASHING ALLOWANCE"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        EmployeeDetail = new Paragraph(Convert.ToString("Medi"), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["BA_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["WA_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        //EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[0]["WA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        //Cell = new PdfPCell(EmployeeDetail);
                        //Cell.Border = 0;
                        //EmployeeTbl.AddCell(Cell);

             //           EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[0]["WA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        EmployeeDetail = new Paragraph(Convert.ToString("PuncAll"), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString("Medi cal"), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["PF_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["ADV_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["Food_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["NetPayable"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph("", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        //// 2 Line

                        EmployeeDetail = new Paragraph(" " + Convert.ToString(_DataTable.Rows[0]["EmployeeCode"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        LBLBankName = new Paragraph(Convert.ToString("Bank Transfer"), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(LBLBankName);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        LBLESI = new Paragraph(Convert.ToString(rptEmployeeDetails.Rows[j]["ESIC No"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(LBLESI);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        LBLDayWork = new Paragraph(Convert.ToString("LOP"), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(LBLDayWork);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);
                        
                        EmployeeDetail = new Paragraph(Convert.ToString(rptEmployeeDetails.Rows[j]["CL_Availed"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        //EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[0]["BA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        //Cell = new PdfPCell(EmployeeDetail);
                        //Cell.Border = 0;
                        //EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["DA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["SPA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["BNS"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["DA_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["SPA_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString("AttAWD"), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);
                                               
                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["BNS_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["ESIC_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["UNI_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["PT_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph("", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph("", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        // 3 Line

                        EmployeeDetail = new Paragraph(" " + Convert.ToString(rptEmployeeDetails.Rows[j]["FullName"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        LBLBankName = new Paragraph(Convert.ToString(rptEmployeeDetails.Rows[j]["Bank Account No"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(LBLBankName);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        LBLESI = new Paragraph(Convert.ToString(rptEmployeeDetails.Rows[j]["DOB"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(LBLESI);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        LBLDayWork = new Paragraph(Convert.ToString(rptEmployeeDetails.Rows[j]["PaidHolidays"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(LBLDayWork);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(rptEmployeeDetails.Rows[j]["SL_Availed"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["BA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["WA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["WA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["BA_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["BA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["WA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["WA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["BA_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["BA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["WA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString("20560"), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph("", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        // 4 Line

                        EmployeeDetail = new Paragraph(" " + Convert.ToString(rptEmployeeDetails.Rows[j]["FatherHusbandName"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        LBLBankName = new Paragraph(Convert.ToString(rptEmployeeDetails.Rows[j]["IFS Code"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(LBLBankName);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        LBLESI = new Paragraph(Convert.ToString(rptEmployeeDetails.Rows[j]["DOJ"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(LBLESI);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        LBLDayWork = new Paragraph(Convert.ToString(" "), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(LBLDayWork);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(" "), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["HRA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["CON"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString("Leave"), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["HRA_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["CON_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString("GWR"), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString("Leave E"), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["LWF_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["FIN_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString("Ins"), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph("", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph("", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        // 5 Line

                        EmployeeDetail = new Paragraph(" " + Convert.ToString(rptEmployeeDetails.Rows[j]["DesignationName"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        LBLBankName = new Paragraph(Convert.ToString(rptEmployeeDetails.Rows[j]["UAN No"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(LBLBankName);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        LBLESI = new Paragraph("", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(LBLESI);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        LBLDayWork = new Paragraph(Convert.ToString(""), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(LBLDayWork);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(rptEmployeeDetails.Rows[j]["GROSS AMT"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(" "), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(" "), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[i]["TotalEarning"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[0]["BA_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[0]["BA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[0]["WA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[0]["WA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[0]["BA_Cal"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[0]["BA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph(Convert.ToString(_DataTable.Rows[0]["WA"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph("", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        EmployeeDetail = new Paragraph("", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8));
                        Cell = new PdfPCell(EmployeeDetail);
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);

                        Cell = new PdfPCell(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.2F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1))));
                        Cell.Colspan = 17;
                        Cell.Border = 0;
                        EmployeeTbl.AddCell(Cell);
                        #endregion
                    }

                }

                #endregion


                #endregion
                doc.Add(EmployeeTbl);
                if (doc.IsOpen())
                {
                    doc.Close();
                }
            }
            catch (Exception _Exception)
            {
                if (!doc.IsOpen())
                {
                    doc.Open();
                }
                FullCompanyName = new Paragraph();
                FullCompanyName.Add(new Chunk(_Exception.Message.ToString(), FontFactory.GetFont(FontFactory.COURIER_BOLD, 9)));
                doc.Add(FullCompanyName);
            }
            finally
            {
                if (doc.IsOpen())
                {
                    doc.Close();
                }
            }
            return FileName;
        }
        public string GenerateEmployeeWageSlip(GeneratePdf_Report _Report, DataSet PaySlipData, string strFilePath, string strServerPath, string strCompanyLogoPath)
        {
            doc = new Document(PageSize.A5.Rotate(), 30f, 30f, 15f, 10f);

            string FileName = _Report.Str_Narration;
            //decimal TotalEarning=0, TotalDeduction=0, GrossAmount = 0;
            try
            {
                DataTable rptEmployeeDetails, rptCompanyTable, rptSalaryTable;

                if (PaySlipData != null)
                {
                    if (PaySlipData.Tables[0] != null)
                    {
                        if (PaySlipData.Tables[0].Rows.Count > 0)
                        {
                            rptCompanyTable = PaySlipData.Tables[0];
                            rptEmployeeDetails = PaySlipData.Tables[1];
                            rptSalaryTable = PaySlipData.Tables[2];
                        }
                        else
                        {
                            rptEmployeeDetails = null; return "";
                        }
                    }
                    else
                    {
                        _DataTable = null; return "";
                    }
                }
                else
                {
                    return "";
                }
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(strFilePath + FileName, FileMode.Create));

                PdfPTable EmployeeEarning;
                PdfPTable EmployeeDeduction;
                PdfPCell EmployeeDaysCell;
                float[] HeaderTblCellWidth;
                float TotalAmount = 0f;
                float TotalEarnAmount = 0f;
                float TotalDedAmount = 0f;
                string TwoDecimalOnlyFirstValue = "";
                string TwoDecimalOnlySecondValue = "";
                if (!doc.IsOpen())
                {
                    doc.Open();
                }

                for (int i = 0; i < rptEmployeeDetails.Rows.Count; i++)
                {
                    #region Header Details
                    PdfPTable HeaderTbl = new PdfPTable(2);
                    HeaderTblCellWidth = new float[] { 20, 80 };
                    HeaderTbl.SetWidths(HeaderTblCellWidth);
                    HeaderTbl.WidthPercentage = 100;
                    PdfPCell HeaderTblCell = null;

                    PdfPTable EmployeeTbl = new PdfPTable(3);
                    float[] EmployeeTblCellWidth = new float[] { 40, 30, 30 };
                    EmployeeTbl.SetWidths(EmployeeTblCellWidth);
                    EmployeeTbl.DefaultCell.Border = 0;
                    EmployeeTbl.WidthPercentage = 100;
                    EmployeeTbl.KeepTogether = true;
                    PdfPCell EmployeeTblCell = null;

                    EmployeeEarning = new PdfPTable(5);
                    HeaderTblCellWidth = new float[] { 35, 15, 15, 20, 15 };
                    EmployeeEarning.SetWidths(HeaderTblCellWidth);
                    EmployeeEarning.WidthPercentage = 100;
                    TotalAmount = 0f;
                    TotalEarnAmount = 0f;
                    TotalDedAmount = 0f;
                    //if (Convert.ToString(rptCompanyTable.Rows[0]["Client Logo"]) != "")
                    //{
                    string imageURL = _Report.Str_LocalFilePathTwo;// + "Jay.jpg";
                    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
                    jpg.ScaleAbsolute(80f, 55f);
                    jpg.SpacingBefore = 0f;
                    jpg.SpacingAfter = 1f;
                    jpg.Alignment = Element.ALIGN_LEFT;
                    HeaderTblCell = new PdfPCell(jpg);
                    //}
                    //else
                    //{
                    //    HeaderTblCell = new PdfPCell(new Phrase(new Chunk(" ")));
                    //}

                    HeaderTblCell.Border = 0;
                    HeaderTbl.AddCell(HeaderTblCell);

                    Phrase FullCompanyName = null;
                    FullCompanyName = new Phrase();
                    FullCompanyName.Add(new Chunk(Convert.ToString(rptEmployeeDetails.Rows[i]["ClientName"]) + "\n", FontFactory.GetFont(FontFactory.COURIER, 14)));
                    FullCompanyName.Add(new Chunk(Convert.ToString(rptEmployeeDetails.Rows[i]["BranchName"]) + "\n", FontFactory.GetFont(FontFactory.COURIER, 8)));
                    FullCompanyName.Add(new Chunk(Convert.ToString(rptEmployeeDetails.Rows[i]["SiteName"]) + "\n\n", FontFactory.GetFont(FontFactory.COURIER_BOLD, 10)));


                    HeaderTblCell = new PdfPCell(FullCompanyName);
                    HeaderTblCell.Border = 0;
                    HeaderTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    HeaderTblCell.PaddingLeft = 0;
                    HeaderTbl.AddCell(HeaderTblCell);
                    doc.Add(HeaderTbl);

                    Paragraph _ParaMonth = new Paragraph(new Chunk(new Chunk("Wages Slip  " + Convert.ToString(rptEmployeeDetails.Rows[i]["MonthName"]) + " " + Convert.ToString(rptEmployeeDetails.Rows[i]["YearName"]), FontFactory.GetFont(FontFactory.COURIER_BOLD, 8))));
                    _ParaMonth.Alignment = Element.ALIGN_CENTER;
                    doc.Add(_ParaMonth);
                    Paragraph Line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.5F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    Line.PaddingTop = 0;
                    doc.Add(Line);
                    #endregion

                    #region Text Name
                    Paragraph LblEmpCode = new Paragraph("Emp Code : " + Convert.ToString(rptEmployeeDetails.Rows[i]["EmployeeCode"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblDateOfJoining = new Paragraph("Date Of Joining : " + Convert.ToString(rptEmployeeDetails.Rows[i]["DOJ"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblMonth = new Paragraph("Month : " + Convert.ToString(rptEmployeeDetails.Rows[i]["MonthName"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblESICNo = new Paragraph("ESIC No. : " + Convert.ToString(rptEmployeeDetails.Rows[i]["ESIC No"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblPFNo = new Paragraph("PF No. : " + Convert.ToString(rptEmployeeDetails.Rows[i]["PF No"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblEmpName = new Paragraph("Emp Name : " + Convert.ToString(rptEmployeeDetails.Rows[i]["FullName"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblDepartment = new Paragraph("Department : " + Convert.ToString(rptEmployeeDetails.Rows[i]["DesignationName"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblDesignation = new Paragraph("Designation : " + Convert.ToString(rptEmployeeDetails.Rows[i]["DesignationName"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblBranch = new Paragraph("Branch : " + Convert.ToString(rptEmployeeDetails.Rows[i]["BranchName"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblSite = new Paragraph("Site Name : " + Convert.ToString(rptEmployeeDetails.Rows[i]["SiteName"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblPANNo = new Paragraph("PAN No. : " + Convert.ToString(rptEmployeeDetails.Rows[i]["PanCard"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblUANNo = new Paragraph("UAN No. : " + Convert.ToString(rptEmployeeDetails.Rows[i]["UAN No"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblMonthDays = new Paragraph("Month Days : " + Convert.ToString(rptEmployeeDetails.Rows[i]["MonthDays"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblPayableDays = new Paragraph("Payable Days : " + Convert.ToString(rptEmployeeDetails.Rows[i]["NormalDays"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblDOB = new Paragraph("Date Of Birth : " + Convert.ToString(rptEmployeeDetails.Rows[i]["DOB"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblAbsentDays = new Paragraph("Absent Days : " + Convert.ToString(rptEmployeeDetails.Rows[i]["NormalDays"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblWeeklyOffs = new Paragraph("Weekly Offs : " + Convert.ToString(rptEmployeeDetails.Rows[i]["WeeklyOff"]), FontFactory.GetFont(FontFactory.COURIER, 8)); //Convert.ToString("UANNo"), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblPaidLeave = new Paragraph("Paid Leave : " + Convert.ToString(rptEmployeeDetails.Rows[i]["PL_Availed"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblFixedBasicDA = new Paragraph("Fixed Basic DA : " + Convert.ToString(rptEmployeeDetails.Rows[i]["BranchName"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblPaidHolidays = new Paragraph("Paid Holidays : " + Convert.ToString(rptEmployeeDetails.Rows[i]["NormalDays"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblWorkingDays = new Paragraph("Working Days  : " + Convert.ToString(rptEmployeeDetails.Rows[i]["NormalDays"]), FontFactory.GetFont(FontFactory.COURIER, 8));
                    Paragraph LblAadharNo = new Paragraph("Aadhar No.  : " + Convert.ToString(rptEmployeeDetails.Rows[i]["AadharCard"]), FontFactory.GetFont(FontFactory.COURIER, 8));


                    EmployeeTblCell = new PdfPCell(LblEmpName);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(LblEmpCode);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(LblDOB);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(LblDateOfJoining);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);


                    EmployeeTblCell = new PdfPCell(LblMonth);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(LblDesignation);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);
                    //EmployeeTblCell = new PdfPCell(LblBranch);

                    //EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //EmployeeTblCell.PaddingLeft = 0;
                    //EmployeeTblCell.Border = 0;
                    //EmployeeTbl.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(LblSite);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.Colspan = 3;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);
                    //EmployeeTblCell = new PdfPCell(LblDepartment);
                    //EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //EmployeeTblCell.PaddingLeft = 0;
                    //EmployeeTblCell.Border = 0;
                    //EmployeeTbl.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(LblPANNo);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(LblAadharNo);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);
                    EmployeeTblCell = new PdfPCell(LblUANNo);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);
                    EmployeeTblCell = new PdfPCell(LblPayableDays);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(LblPaidHolidays);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell); EmployeeTblCell = new PdfPCell(LblPFNo);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);



                    EmployeeTblCell = new PdfPCell(LblWeeklyOffs);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(LblPaidLeave);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);
                    EmployeeTblCell = new PdfPCell(LblESICNo);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(LblAbsentDays);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(LblFixedBasicDA);
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(new Chunk(" ")));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeTblCell.PaddingLeft = 0;
                    EmployeeTblCell.Border = 0;
                    EmployeeTbl.AddCell(EmployeeTblCell);

                    doc.Add(EmployeeTbl);
                    #endregion

                    #region Earning Table
                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(" Earning"), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString("Payable  "), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString("Earned  "), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(" Deductions"), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString("Amount  "), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    #region DataBind
                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(" Basic"), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(rptSalaryTable.Rows[i]["BA"]), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(rptSalaryTable.Rows[i]["BA_CAL"]), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeEarning.AddCell(EmployeeTblCell);
                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString("PT"), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeEarning.AddCell(EmployeeTblCell);
                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(rptSalaryTable.Rows[i]["PT_CAL"]), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(" DA"), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(rptSalaryTable.Rows[i]["DA"]), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(rptSalaryTable.Rows[i]["DA_CAL"]), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeEarning.AddCell(EmployeeTblCell);
                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString("ESIC"), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeEarning.AddCell(EmployeeTblCell);
                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(rptSalaryTable.Rows[i]["ESIC_CAL"]), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeEarning.AddCell(EmployeeTblCell);


                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(" HRA"), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(rptSalaryTable.Rows[i]["HRA"]), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(rptSalaryTable.Rows[i]["HRA_CAL"]), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(" "), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.Colspan = 2;
                    EmployeeEarning.AddCell(EmployeeTblCell);


                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(" "), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.Colspan = 3;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(" "), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.Colspan = 2;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    //EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(" "), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    //EmployeeTblCell.Colspan = 3;
                    //EmployeeEarning.AddCell(EmployeeTblCell);

                    //EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(" "), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    //EmployeeTblCell.Colspan = 2;
                    //EmployeeEarning.AddCell(EmployeeTblCell);
                    //EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(" "), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    //EmployeeTblCell.Colspan = 3;
                    //EmployeeEarning.AddCell(EmployeeTblCell);

                    //EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(" "), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    //EmployeeTblCell.Colspan = 2;
                    //EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString("Total Earning "), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeEarning.AddCell(EmployeeTblCell);


                    //EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString("1234560 "), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    //EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    //EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(rptSalaryTable.Rows[i]["TotalEarning"]), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeTblCell.Colspan = 2;
                    EmployeeEarning.AddCell(EmployeeTblCell);


                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString("Total Deduction"), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(rptSalaryTable.Rows[i]["TotalDeduction"]), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString("Net Payable"), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeTblCell.Colspan = 4;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    EmployeeTblCell = new PdfPCell(new Paragraph(Convert.ToString(rptSalaryTable.Rows[i]["NetPayable"]), FontFactory.GetFont(FontFactory.COURIER, 8)));
                    EmployeeTblCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    EmployeeEarning.AddCell(EmployeeTblCell);

                    #endregion
                    doc.Add(EmployeeEarning);
                    //Paragraph Lines = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.2F, 100.0F, BaseColor.WHITE, Element.ALIGN_LEFT, 1)));
                    //Lines.PaddingTop = 0;
                    //doc.Add(Lines);
                    Paragraph Note = new Paragraph("COMPUTER GENERATED DOCUMENT. NO SIGNATURE REQUIRED.", FontFactory.GetFont(FontFactory.COURIER, 6));
                    Note.Alignment = Element.ALIGN_LEFT;
                    Note.PaddingTop = 0;
                    doc.Add(Note);
                    #endregion
                    doc.NewPage();
                }
                if (doc.IsOpen())
                {
                    doc.Close();
                }
                //  }
            }
            catch (Exception _Exception)
            {
                if (!doc.IsOpen())
                {
                    doc.Open();
                }
                FullCompanyName = new Paragraph();
                FullCompanyName.Add(new Chunk(_Exception.Message.ToString(), FontFactory.GetFont(FontFactory.COURIER_BOLD, 9)));
                doc.Add(FullCompanyName);
            }
            finally
            {
                if (doc.IsOpen())
                {
                    doc.Close();
                }
            }
            return FileName;
        }
    }
}