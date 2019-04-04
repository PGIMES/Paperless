using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Text;
using System.Data.SqlClient;
using System.Collections;


/// <summary>
///Function_Admin 的摘要说明
/// </summary>
public class Function_Admin
{
	public Function_Admin()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    SQLHelper SQLHelper = new SQLHelper();
    public DataTable User_Login(int flag, string userid, string pwd,string role)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@userid",userid),
            new SqlParameter("@pwd",pwd),
            new SqlParameter("@role",role)
        };
        return SQLHelper.GetDataTable("usp_login",param);
    }
    public int User_Login_insert(int flag, string userid, string pwd,string role)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@userid",userid),
            new SqlParameter("@pwd",pwd),
            new SqlParameter("@role",role)
        };
        return SQLHelper.ExecuteNonQuery("usp_login", param);
    }

    public void initDrop(DropDownList drop,DataTable dt,string value)
    {
        
        drop.DataSource = dt;
        drop.DataValueField = value;
        drop.DataTextField = value;
        drop.DataBind();
    }

}