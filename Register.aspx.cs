using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void OKButton_Click(object sender, ImageClickEventArgs e)
    {
        string password;
        string username;
        bool flag = false;
        string MdPswdStr = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.ToString(), "MD5");
        username = txtUserName.Text.ToString();
        password = MdPswdStr;
        if (username.Equals("") || password.Equals(""))
        {
            Response.Write("<script language=javascript>alert('用户名和密码不能为空！')</script>");
            return;
        }
        Function_Admin Function_Admin = new Function_Admin();
        DataTable dt = new DataTable();
        dt = Function_Admin.User_Login(2, username, password,"");
        if (dt.Rows.Count > 0)
        {
            Response.Write("<script language=javascript>alert('对不起，该用户已经注册！');location='Register.aspx'</script>");
            return;
        }
        else
        {
             Function_Admin.User_Login_insert(3, username, password,DropDownList1.SelectedValue);
             flag = true; 
           
        }
        if (flag)
        {
            Response.Write("<script language=javascript>alert('注册用户成功!'); location='Source1/Index.aspx'</script>");
        }
    }
}