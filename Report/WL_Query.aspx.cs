using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Report_WL_Query : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = " select pt_part as 物料号,pl_desc as 类别 from Qad_pt_mstr  join Paperless_pl_mstr on pl_prod_line=pt_prod_line";
        sql += " where pt_part = '"+txt_wlh.Text+"'";
        DataTable dt1 = SQLHelper.reDs(sql).Tables[0];
        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }
}