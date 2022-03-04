using ASR_PayMax.GlobalProjectClass;
using ASR_PayMaxLogic.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASR_PayMax.Transactions
{
    public partial class AttendanceEmployee : System.Web.UI.Page
    {
        ASR_PayMaxParameters _Parameters;
        ASR_Common _Common;
        DataSet _DataSet;

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox _TextBox;
            Label _Label;
            try
            {
                if (!IsPostBack)
                {
                    ClearBox();
                }

              
            }
            catch (Exception _Exception)
            {
                _Exception.Message.ToString();
            }
        }

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_Clear_Click(object sender, EventArgs e)
        {

        }

        private void ClearBox()
        {
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
                _Parameters.Str_SelectID = "13";
                _Parameters.Str_LoginID = UserDetails.Str_LoginID;

                _Parameters.Str_ApiUrl = ConfigurationManager.AppSettings["ApiPayMax"].ToString() + "/GetPayMaxDetails/GetMstBank";
                _Common.BindGrid(this, GridMonthAttendance, _Parameters);

                for (int i = 0; i < GridMonthAttendance.Rows.Count; i++)
                {
                    for (int j = 0; j < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); j++)
                    {
                        (GridMonthAttendance.Rows[i].Cells[j + 4].FindControl("txtD" + (j + 1)) as TextBox).Enabled = true;
                        (GridMonthAttendance.Rows[i].Cells[j + 4].FindControl("txtD" + (j + 1) + "OT") as TextBox).Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                UsersSession.GetMessages(this, "Failure", ex.Message.ToString());
            }
        }

      }
}
