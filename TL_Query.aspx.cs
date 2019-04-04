using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class TL_Query : System.Web.UI.Page
{
    Car car = new Car();
    Function_Admin Function_Admin = new Function_Admin();

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
        dt = car.TL_Query(1, part, txt_cpmc.Text, txt_wlxh.Text, DropDownList5.SelectedValue, Session["UserLoginName"].ToString(), txtly_date3.Text, txtly_date4.Text);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        int lnindex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
       
        string lldh = "";
        int num=0;
        lldh = GridView1.Rows[lnindex].Cells[0].Text.ToString();
        num=int.Parse(GridView1.Rows[lnindex].Cells[5].Text.ToString());
        Response.Write("<script>window.open('User_Confirm/TL_Input.aspx?lydh=" + lldh + "&num="+num+"','_blank','height=200,width=300,scrollbars=no')</script>");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
     
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string lldh = e.Row.Cells[0].Text;
            int llnum = int.Parse(e.Row.Cells[5].Text);

             DataTable dt = new DataTable();
             dt = car.TL_IsOK(1, lldh, llnum, Session["UserLoginName"].ToString());
             if (dt.Rows.Count > 0)
             {
                 if (dt.Rows[0][0].ToString() == "N")
                 {
                     ((Button)(e.Row.FindControl("Button3"))).Enabled = false;
                 }
             }
            e.Row.Attributes.Add("onmouseover", "javascript:currentcolor=this.style.backgroundColor;this.style.backgroundColor='#DFE7DF';");
            e.Row.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor=currentcolor;");

        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.SelectedIndex = -1;
        GridView1.PageIndex = e.NewPageIndex;
        GetData();
    }
}