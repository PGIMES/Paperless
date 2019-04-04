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

public partial class LL_Confirm : System.Web.UI.Page
{
    Car Car = new Car();
    Function_Admin Function_Admin = new Function_Admin();
    string part = "";
    string groupid = "";
  
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["UserLoginName"].ToString() == null)
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
    public void GetData()
    {
        string uid = Session["UserLoginName"].ToString();
        //if (txt_djzhh.Text != "")
        //{
        //    groupid = txt_djzhh.Text.ToString();
        //}
        if (txt_wlbm.Text != "")
        {
            part = txt_wlbm.Text.ToString();
        }
        DataTable dt = new DataTable();
        //if (txt_llr.Text == "")
        //{
        //    uid = Session["UserLoginName"].ToString();
        //}
        //else
        //{
        //    uid = txt_llr.Text.ToString();
        //}
        dt = Car.LL_Confirm(2,"", part, txt_cpmc.Text, txt_wlxh.Text, DropDownList5.SelectedValue, uid, txtly_date3.Text, txtly_date4.Text,DropDownList6.SelectedValue);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string llda = "";
        string wlbh = "";
        int lnindex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        llda = GridView1.Rows[lnindex].Cells[0].Text.ToString();
        wlbh = GridView1.Rows[lnindex].Cells[1].Text.ToString();

        Response.Write("<script language=javascript>alert('领料成功！')</script>");
        Car.usp_llr_close(2, llda, Session["UserLoginName"].ToString());
      //  Response.Write("<script>window.open('User_Confirm/Confirm_LLR.aspx?lydh=" + llda + "&wlbh=" + wlbh + "','_blank','height=230,width=300,scrollbars=no')</script>");
        GetData();
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (DropDownList6.SelectedValue == "Y")
            {
                ((Button)(e.Row.FindControl("Button3"))).Enabled = false;
                
            }
            e.Row.Attributes.Add("onmouseover", "javascript:currentcolor=this.style.backgroundColor;this.style.backgroundColor='#DFE7DF';");
            e.Row.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor=currentcolor;");

        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        GetData();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.SelectedIndex = -1;
        GridView1.PageIndex = e.NewPageIndex;
        GetData();
    }
}