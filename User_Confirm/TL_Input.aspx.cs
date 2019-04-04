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

public partial class User_Confirm_TL_Input : System.Web.UI.Page
{
    int num = 0;
    string lldh = "";
    Car Car = new Car();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session.Count <= 0)
        {

            Response.Redirect("~/Source1/Login.aspx");

        }
        if (Request["lydh"] != null)
        {
            lldh = Request["lydh"];
        }
        if (Request["num"] != null)
        {
            num = int.Parse(Request["num"]);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int tlnum =int.Parse( txt_tlnum.Text);
        if (tlnum > num)
        {
            Response.Write("<script language=javascript>alert('退料数量大于领料数量，请确认！')</script>");
            return;
        }
        DataTable dt = new DataTable();
        dt = Car.TL_IsOK(1, lldh, tlnum, Session["UserLoginName"].ToString());
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0][1].ToString() == "N")
            {
                Response.Write("<script language=javascript>alert('总退料数量大于领料数量，请确认！')</script>");
                return;
            }
        }
        
        int i=Car.TL_Input(2,lldh, tlnum, Session["UserLoginName"].ToString());
        if (i >= 1)
        {
            //Response.Write("<script language=javascript>alert('已成功退料，笔数为'"+tlnum+"'！')</script>");
            Response.Write("<script language=javascript>alert('退料数量为"+tlnum+",请至仓库确认退料!')</script>");
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