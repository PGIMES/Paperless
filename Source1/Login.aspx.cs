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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Object.Equals(Request.Cookies["UserName"], null))
            {
                HttpCookie readcookie = Request.Cookies["UserName"];
                this.txtUserName.Text = readcookie.Value;
            }
        }  

    }
    protected void OKButton_Click(object sender, ImageClickEventArgs e)
    {
        string uid = "";
        string pwd = "";
        uid = txtUserName.Text.ToString();
        pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.ToString(), "MD5");
        if (uid.Equals("") || pwd.Equals(""))
        {
            Response.Write("<script language=javascript>alert('用户名和密码不能为空！')</script>");
            return;
        }
        Function_Admin Function_Admin = new Function_Admin();
        DataTable dt = new DataTable();
        dt = Function_Admin.User_Login(3, uid, pwd,"");
        if (dt.Rows.Count != 0)
        {
            Session["UserLoginName"] = this.txtUserName.Text;
            Response.Redirect("~/Source1/Index.aspx?&uid=" + Session["UserLoginName"] .ToString()+ "");
        }
        else
        {
            Response.Write("<script>alert('登录失败！请返回查找原因');location='Login.aspx'</script>");
        }
    }
    private void CreateCookie()
    {
        
        HttpCookie cookie = new HttpCookie("UserName");
      
        if (this.chkRememberPwd.Checked)
        {
           
            cookie.Value = this.txtUserName.Text;
        }
        
        cookie.Expires = DateTime.MaxValue;
       
        Response.AppendCookie(cookie);
    }
    protected void ReLoginButton_Click(object sender, ImageClickEventArgs e)
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
    }
}