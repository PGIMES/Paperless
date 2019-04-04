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

public partial class LL_Record : System.Web.UI.Page
{
    Car Car = new Car();
    Function_Admin Function_Admin = new Function_Admin();
    protected void Page_Load(object sender, EventArgs e)
    {
       // if (Session["UserLoginName"].ToString() == null)
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
            GetData();
        }
       
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string llda = "";

        int lnindex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        llda = GridView1.Rows[lnindex].Cells[1].Text.ToString();
        int i = Car.usp_llr_close(1, llda, Session["UserLoginName"].ToString());
        if (i >= 1)
        {
            Response.Write("<script>javascript:alert('成功关闭！')</script>");
            GetData();
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        GetData();
    }
    private void GetData()
    {
        string part = "";
        //string groupid = "";
        //if (txt_djzhh.Text != "")
        //{
        //    groupid = txt_djzhh.Text.ToString();
        //}
        if (txt_wlbm.Text != "")
        {
            part = txt_wlbm.Text.ToString();
        }
        DataTable dt = new DataTable();
        dt = Car.LL_Confirm(1, "",part, txt_cpmc.Text, txt_wlxh.Text, DropDownList5.SelectedValue, Session["UserLoginName"].ToString(), txtly_date3.Text, txtly_date4.Text, DropDownList6.SelectedValue);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataTable dt =new DataTable();
        dt = Car.LL_Confirm(1, "", txt_wlbm.Text.ToString(), txt_cpmc.Text, txt_wlxh.Text, DropDownList5.SelectedValue, Session["UserLoginName"].ToString(), txtly_date3.Text, txtly_date4.Text, DropDownList6.SelectedValue);       
         if (e.Row.RowIndex != -1)
            {
                int indexID = this.GridView1.PageIndex * this.GridView1.PageSize + e.Row.RowIndex + 1;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DropDownList6.SelectedValue == "Y" || dt.Rows[indexID-1]["closed"].ToString()=="Y")
                    {
                        ((Button)(e.Row.FindControl("Button3"))).Enabled = false;
                        ((CheckBox)(e.Row.FindControl("chkSelect"))).Checked = true;
                        ((CheckBox)(e.Row.FindControl("chkSelect"))).Enabled = false;

                    }
                }
            
           
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.SelectedIndex = -1;
        GridView1.PageIndex = e.NewPageIndex;
        GetData();
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        int a = 0;
        int result = 0;
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {

            CheckBox chk = (CheckBox)this.GridView1.Rows[i].FindControl("chkSelect");
            if (chk.Checked == true)
            {
                a = 1;
                //int lnindex = ((GridViewRow)((CheckBox)sender).NamingContainer).RowIndex;
                string llda = GridView1.Rows[i].Cells[1].Text.ToString();
                 result = Car.usp_llr_close(1, llda, Session["UserLoginName"].ToString());
            }
        }
        if (a == 0)
        {
            Response.Write("<script>javascript:alert('请选择一行记录')</script>");
        }
        if (result > 0)
        {

            Response.Write("<script>javascript:alert('成功关闭！')</script>");
            GetData();
        }
    }
}