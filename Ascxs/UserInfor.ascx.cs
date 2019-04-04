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

public partial class Ascxs_UserInfor : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
        //if (Session["UserLoginName"].ToString() == "")
        //{
        //    Response.Redirect("Login.aspx");
        //    return;
           
        //}
        //this.labuserid.Text = Session["UserLoginName"].ToString();
        //this.labusername .Text = HttpContext.Current.User.Identity.Name;
    }
}
