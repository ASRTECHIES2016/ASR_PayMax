using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace ASR_PayMax.GlobalProjectClass
{
    public class GenerateExcel_Report
    {
        public void ExportExcel(Page _Page, DataTable dt, string FileName)
        {
            try
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
            catch (ThreadAbortException _Exception)
            {
            _Exception.Message.ToString();
            }
        }
    }
}