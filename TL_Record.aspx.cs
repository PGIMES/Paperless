using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

public partial class TL_Record : System.Web.UI.Page
{
    Car Car = new Car();
    Function_Admin Function_Admin = new Function_Admin();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (this.Session.Count <= 0)
        //{

        //    Response.Redirect("~/Source1/Login.aspx");

        //}
        if (Session["UserLoginName"] == null)
        {
            Response.Redirect("~/Source1/Login.aspx");
            Response.End();


            return;
        }
        if (!Page.IsPostBack)
        {
            string uid = Session["UserLoginName"].ToString();
            DataTable dtcomp = Function_Admin.User_Login(6, uid, "", "");
            Function_Admin.initDrop(DropDownList5, dtcomp, "comp");
        }

       

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
       
        GetData();
    }
    private void GetData()
    {
        string part = "";
        //if (txt_djzhh.Text != "")
        //{
        //    part = txt_djzhh.Text.ToString();
        //}
        if (txt_wlbm.Text != "")
        {
            part = txt_wlbm.Text.ToString();
        }
        DataTable dt = new DataTable();
        dt = Car.TL_Confirm(1, part, txt_cpmc.Text, txt_wlxh.Text, DropDownList5.SelectedValue, Session["UserLoginName"].ToString(), txtly_date3.Text, txtly_date4.Text, DropDownList6.SelectedValue);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string tldh = "";

        int lnindex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        tldh = GridView1.Rows[lnindex].Cells[0].Text.ToString();
        int i = Car.usp_llr_close(4, tldh, Session["UserLoginName"].ToString());
        if (i >= 1)
        {
            Response.Write("<script>javascript:alert('成功关闭！')</script>");
            GetData();
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (DropDownList6.SelectedValue == "Y")
            {
                ((Button)(e.Row.FindControl("Button3"))).Enabled = false;

            }
        }
    }
}