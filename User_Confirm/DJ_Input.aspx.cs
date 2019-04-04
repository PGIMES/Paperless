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

public partial class User_Confirm_DJ_Input : System.Web.UI.Page
{
    Car Car = new Car();
    DJ DJ = new DJ();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session["UserLoginName"] == null)
        {
            Response.Redirect("~/Source1/Login.aspx");
            Response.End();

            
            return;
        }
        if (!IsPostBack)
        {
           

            this.txtyjly_date.Text = System.DateTime.Now.ToShortDateString();
            string ljh = "";
            string xmh = "";
            string domain = "";
            string gxh = "";
            string IsGc = "";
            string isyf = "";

            DataTable dt;
            dt = (DataTable)Session["dt"];
            if (Request["ljh"] != null)
            {
                ljh = Request["ljh"];
                txt_ljh.Text = ljh;
            }

            if (Request["IsGc"] != null)
            {
                IsGc = Request["IsGc"];
                if (IsGc == "Y")
                {
                    txt_lycp_tz.Visible = true;
                    lb_gc.Visible = true;
                }
            }
            if (Request["domain"] != null)
            {
                domain = Request["domain"];
                
            }
            if (Request["gxh"] != null)
            {
                gxh = Request["gxh"];
                
            }
            if (Request["xmh"] != null)
            {
                xmh = Request["xmh"];
                txt_lycp.Text = xmh;
               // string sql = "select pt_part from qad_pt_mstr WHERE  pt_prod_line LIKE '3%' and  pt_part like '%" + txt_lycp.Text.TrimEnd() + "%' ";
                StringBuilder sql = new StringBuilder();
                 sql.Append(" SELECT * FROM (select pt_part from qad_pt_mstr WHERE  pt_prod_line LIKE '3%'  ");
                 sql.Append(" UNION select  dt.pgi_no FROM [172.16.5.26].MES.DBO.PGI_BASE_DAOJU_DT  dt JOIN [172.16.5.26].MES.[dbo].[PGI_BASE_DAOJU] dm on dt.daoju_id=dm.id where b_flag=1 )A");
                 sql.Append(" where pt_part like '%" + txt_lycp.Text.TrimEnd() + "%'");
                
                 DataSet ds = SQLHelper.reDs(sql.ToString());
               
                this.drop_lycp.DataSource = ds.Tables[0];
                this.drop_lycp.DataValueField = "pt_part";
                this.drop_lycp.DataTextField = "pt_part";
                this.drop_lycp.DataBind();
                this.drop_lycp.Items.Insert(0, new ListItem("", ""));
                this.drop_lycp.SelectedItem.Text = ds.Tables[0].Rows.Count == 1 ? ds.Tables[0].Rows[0]["pt_part"].ToString() : "";

                DataTable api = DJ.Get_MO_Code(1, gxh.TrimEnd(), domain.TrimEnd(), xmh.TrimEnd());
                this.ddlposition.DataSource = api;
                this.ddlposition.DataTextField = "mo_code_key";
                this.ddlposition.DataValueField = "mo_code_key";
                this.ddlposition.DataBind();
                this.ddlposition.Items.Insert(0, new ListItem("", ""));
                if (drop_lycp.SelectedItem.Text != "")
                {
                    Getyfcode(drop_lycp.SelectedItem.Text);
                }
            }
            
        }
        
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlposition.SelectedValue == "" || drop_lycp.SelectedItem.Text=="")
        {
            Response.Write("<script>javascript:alert('领用位置和产品必须选择！')</script>");
            return;
        }
        string group_part = "";
        string part = "";
        string desc1 = "";
        string desc2 = "";
        string ljh="";
        string unit = "";
        string comp = Getcomp().Rows[0][1].ToString();
        int sftnum = 0;
        int quantity = 0;
        string bb = "";
        string gxh = "";
        bool flag = false;
        string loc="";
        //string lycp = txt_lycp.Text.ToString();
        string lycp = drop_lycp.SelectedItem.Text;
        ljh = txt_ljh.Text.ToString();
        string pgixmh = "";
        string position = ddlposition.SelectedValue;
        string yjlyrq = txtyjly_date.Text;
        string type = DropDownList1.SelectedValue;
        string yfxm = txt_yfxm.Text;
        string status = txt_status.Text;
         string dept = Getcomp().Rows[0][0].ToString();
        //lycp = txt_lycp_tz.Text != "" ? txt_lycp_tz.Text : lycp;
        string tz_ljh = "";
        if (txt_lycp_tz.Text != "")
        {
            lycp = txt_lycp_tz.Text;
            //StringBuilder sql = new StringBuilder();
            //sql.Append(" SELECT TOP 1 pt_desc1,PT_STATUS,pt_prod_line FROM qad_pt_mstr WHERE  pt_prod_line LIKE '3%'   ");
            //sql.Append(" and pt_part = '" + txt_lycp_tz.Text.TrimEnd() + "' AND pt_prod_line IN ( select cpline from [paperless_yfxm] )");
            //DataSet ds = SQLHelper.reDs(sql.ToString());
            string strsql = "select A.*,pt_status,PT.pt_desc1 from (";
            strsql += "    select '" + lycp + "' as pt_part,'" + comp + "' AS domain,* from [dbo].[paperless_yfxm]  WHERE cpline=(select pt_prod_line from Qad_pt_mstr where pt_part ='" + lycp + "' and domain='" + comp + "' ))A";
            strsql += "    join Qad_pt_mstr pt on a.pt_part=pt.pt_part and a.domain=pt.domain";
            //DataTable dt = SQLHelper.reDs(strsql).Tables[0];
            DataSet ds = SQLHelper.reDs(strsql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                tz_ljh = ds.Tables[0].Rows[0][6].ToString();
                status = ds.Tables[0].Rows[0][5].ToString();
               // yfxm = ds.Tables[0].Rows[0][3].ToString();
                if ((dept.Contains("工程") || dept.Contains("压铸技术部")) && status.ToUpper() == "SAMPLE" && comp=="200")
                {
                    yfxm = ds.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    yfxm = "";
                }
            }
            else
            {
                Response.Write("<script>javascript:alert('请填写正确项目号！')</script>");
                return;
            }

        }
       DataTable  dt = (DataTable)Session["dt"];
       for (int i = 0; i < dt.Rows.Count; i++)
       {
           group_part =txt_lycp_tz.Text != ""?"": dt.Rows[i]["pt_group_part"].ToString();
           part = dt.Rows[i]["pt_part"].ToString();
           desc1 = dt.Rows[i]["pt_desc1"].ToString();
           desc2 = dt.Rows[i]["pt_desc2"].ToString();
           ljh =tz_ljh!=""?tz_ljh: dt.Rows[i]["LJH"].ToString();
           unit = dt.Rows[i]["pt_um"].ToString();
           comp = dt.Rows[i]["pt_domain"].ToString();
           sftnum = int.Parse(dt.Rows[i]["pt_sfty_stk"].ToString());
           quantity = int.Parse(dt.Rows[i]["ld_qty_oh"].ToString());
           bb = dt.Rows[i]["bb"].ToString();
           gxh = dt.Rows[i]["xzgxh"].ToString();
           loc = dt.Rows[i]["loc"].ToString().Replace("&nbsp;", "");
           int j = Car.ADD_TOCar(1, group_part, part, desc1, desc2, ljh, gxh, "", unit, 1, Session["UserLoginName"].ToString(), comp, sftnum, lycp.ToUpper(), type, position, bb, yjlyrq, quantity, loc,yfxm,status,"4010");
           flag = true; 


       }
       if (flag)
       {
           
           Response.Write("<script>javascript:alert('加入领料车成功，请至领料车查看！')</script>");
           StringBuilder scriptString = new StringBuilder();
           scriptString.Append("<script language = javascript>");
           //scriptString.Append("window.opener.refresh();");

           //scriptString.Append(" window.focus();");
           //scriptString.Append(" window.opener=null;");
           scriptString.Append(" window.close(); ");

           scriptString.Append("</" + "script>");
           Response.Write(scriptString.ToString());
       }
    }
    public DataTable Getcomp()
    {
        string sql = @"select dept.UNITNAME,case when left(dept.UNITCODE,2)='02' then '200' else '100' end as comp
	                             from [ehr_db].dbo.psnaccount
	                             left join [eHR_DB].dbo.ORGSTDSTRUCT on PSNACCOUNT.BRANCHID=ORGSTDSTRUCT.UNITID
                                  left join [eHR_DB].dbo.ORGSTDSTRUCT dept on left(ORGSTDSTRUCT.UNITCODE,8)=dept.UNITCODE and dept.ISTEMPUNIT=0
                                  where PSNACCOUNT.accessionstate in(1,2,6) and  EMPLOYEEID='" + Session["UserLoginName"].ToString() + "'";
        DataTable dt = SQLHelper.reDs(sql).Tables[0];
        return dt;

    }

    protected void drop_lycp_SelectedIndexChanged(object sender, EventArgs e)
    {
        Getyfcode(drop_lycp.SelectedValue);
    }
    protected void Getyfcode(string lycp)
    {
        string comp = Getcomp().Rows[0][1].ToString();
        string dept = Getcomp().Rows[0][0].ToString();
        string strsql = "select A.*,pt_status from (";
        strsql += "    select '" + lycp + "' as pt_part,'" + comp + "' AS domain,* from [dbo].[paperless_yfxm]  WHERE cpline=(select pt_prod_line from Qad_pt_mstr where pt_part ='" + lycp + "' and domain='" + comp + "' ))A";
        strsql += "    join Qad_pt_mstr pt on a.pt_part=pt.pt_part and a.domain=pt.domain";
        DataTable dt = SQLHelper.reDs(strsql).Tables[0];
        if ((dt.Rows.Count > 0 && (dept.Contains("工程") || dept.Contains("压铸技术部"))) && dt.Rows[0][5].ToString().ToUpper() == "SAMPLE" && comp=="200" )
        {
            txt_yfxm.Text = dt.Rows[0][3].ToString();
        }
        else
        {
            txt_yfxm.Text = "";
        }
        txt_status.Text = dt.Rows.Count == 0 ? "" : dt.Rows[0][5].ToString();
    }
}