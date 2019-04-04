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

public partial class Source1_Modify_Pwd : System.Web.UI.Page
{
    Function_Admin Function_Admin = new Function_Admin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLoginName"] == null)
        {
            Response.Redirect("~/Source1/Login.aspx");
            Response.End();


            return;
        }

    }
    protected void OKButton_Click(object sender, ImageClickEventArgs e)
    {
        string uid = Session["UserLoginName"].ToString();
        string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword_Old.Text.ToString(), "MD5");
        DataTable  dt = Function_Admin.User_Login(3, uid, pwd, "");
        if (dt == null || dt.Rows.Count <= 0)
        {
            Response.Write("<script language=javascript>alert('旧密码输入有误！')</script>");
            return;
        }
        else
        {
            string newpwd= FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword_Confirm.Text.ToString(), "MD5");
            int result = Function_Admin.User_Login_insert(5, uid, newpwd, "");
            if (result >= 1)
            {
                Response.Write("<script>alert('密码更新成功！');location='Index.aspx'</script>");
            }
        }
    }
    protected void ReturnButton_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Source1/Index.aspx");
    }
}