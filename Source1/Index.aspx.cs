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
using System.Web.SessionState;

public partial class Source1_Index : System.Web.UI.Page
{
    string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Request["uid"] != null )
        {
            // userid = Request["uid"];
            Session["UserLoginName"] = Request["uid"];
            userid = Request["uid"];
        }
        else
        {
            if (Session["UserLoginName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            
        }
        

              
         
    }
}
