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

public partial class Ascxs_tophead : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Function_Admin Function_Admin = new Function_Admin();
        DataTable dt = new DataTable();
        dt = Function_Admin.User_Login(2, Session["UserLoginName"].ToString(), "", "IT");
        if (dt.Rows.Count > 0)
        {
            this.div1.Style.Add("display", "block");

        }
        else
        {
            this.div1.Style.Add("display", "none");
        }
    }
   
   
}
