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
using System.Text;


public partial class User_Confirm_Confirm_LLR : System.Web.UI.Page
{
    Car Car = new Car();
     string lydh = "";
     string wlbh = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (this.Session.Count <= 0)
        {

            Response.Redirect("~/Source1/Login.aspx");

        }

        if (Request["lydh"] != null)
        {
            lydh = Request["lydh"];

        }
        if (Request["wlbh"] != null)
        {
            wlbh = Request["wlbh"];

        }
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        string uid = "";
        string pwd = "";
        uid = txt_uid.Text.ToString();
        DataTable dt1 = new DataTable();
        
        if(wlbh.Substring(0,2)!="Z01")
        {
            dt1 = Car.usp_llr_Confirm(5, lydh, Session["UserLoginName"].ToString());
            if (dt1.Rows[0]["create_uid"].ToString() != uid)
            {
                Response.Write("<script language=javascript>alert('当前确认领料人必须和领料申请人一致！')</script>");
                return;
            }
        }
        pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txt_pwd.Text.ToString(), "MD5");
        if (uid.Equals("") || pwd.Equals(""))
        {
            Response.Write("<script language=javascript>alert('工号和密码不能为空！')</script>");
            return;
        }
        Function_Admin Function_Admin = new Function_Admin();
        DataTable dt = new DataTable();
        dt = Function_Admin.User_Login(1, uid, pwd,"");
        if (dt == null || dt.Rows.Count <= 0)
        {
            Response.Write("<script language=javascript>alert('工号和密码输入不正确！')</script>");
            return;
        }
        else
        {
            Response.Write("<script language=javascript>alert('领料成功！')</script>");
            //Response.Write("<script>window.opener=null;window.close();</script>");
            Car.usp_llr_close(2, lydh, Session["UserLoginName"].ToString());
            //Response.Write("<script>window.opener.location.href=window.opener.location.href;window.location.reload</script>");
            //Response.Write("<script>window.close()</script>");
            StringBuilder scriptString = new StringBuilder();
            scriptString.Append("<script language = javascript>");
            scriptString.Append("window.opener.refresh();");

            scriptString.Append(" window.focus();");
            scriptString.Append(" window.opener=null;");
            scriptString.Append(" window.close(); ");

            scriptString.Append("</" + "script>");
            Response.Write(scriptString.ToString());


        }
    }
  
}