using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASR_PayMax.Masters
{
    public partial class DesignationCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SkillName", typeof(string)));
            DataRow dr;
            dr = dt.NewRow();
            dr["SkillName"] = "Un Skilled";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["SkillName"] = "Semi Skilled";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["SkillName"] = "Skilled";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["SkillName"] = "Highly Skilled";
            dt.Rows.Add(dr);
            GridSkill.DataSource = dt;
            GridSkill.DataBind();
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}