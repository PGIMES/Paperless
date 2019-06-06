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
using System.Collections.Generic;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;
using System.Reflection;
using System.Linq;
using DevExpress.Web;



public partial class My_Car : System.Web.UI.Page
{
    Car Car = new Car();
    DJ DJ = new DJ();
    public string role = "";
    public string uid_comp = "";

    //string strsql = "select distinct pl_prod_line,pl_desc from pub.pl_mstr where pl_prod_line between '4010' and '4120'";
    string strsql = "select  pl_prod_line,pl_desc from Paperless_pl_mstr ";

    string strsql1 = "select pt_part from pub.pt_mstr where pt_prod_line between '3010' and '3090' ";
    string type = "";
    string lxtext="";
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.GetPostBackEventReference(btn_submit_sb, null);     //这句很关键，有这句才能让客户端执行服务器端事件。 
        btn_submit_sb.Attributes.Add("onclick", "Setdisabled(this);");

        Page.ClientScript.GetPostBackEventReference(btn_submit, null);
        btn_submit.Attributes.Add("onclick", "Setdisabled(this);");

        if (Session["UserLoginName"] == null)
        {
            Response.Redirect("~/Source1/Login.aspx");
            Response.End();


            return;
        }
        uid_comp = Getcomp().Rows[0][1].ToString();
        viscomp.Text = uid_comp;
        visdept.Text = Getcomp().Rows[0][0].ToString();
        DataTable dt_role = SQLHelper.reDs("select unitname from [ehr_db].dbo.ORGStdStruct where unitid in (select BRANCHID from [ehr_db].dbo.psnaccount  where EMPLOYEEID='" + Session["UserLoginName"] + "') ").Tables[0];
        role = dt_role.Rows[0][0].ToString();
        
        if (Request["type"] != null)
        {
            type = Request["type"]; //辅料类型id
        }
         if (Request["lxtext"] != null)
        {
            lxtext = Request["lxtext"];//辅料名称
        }

         if (!IsPostBack)
         {
             //DataTable dt1 = ConnectionODBC.GetODBCRows(strsql);
             DataTable dt1 = SQLHelper.reDs(strsql).Tables[0];
             this.DropDownList2.DataSource = dt1;
             this.DropDownList2.DataValueField = "pl_prod_line";
             this.DropDownList2.DataTextField = "pl_desc";
             this.DropDownList2.DataBind();


             DataTable dtcode = SQLHelper.reDs("select distinct id,LY_DL from Paperless_LYCode").Tables[0];
             this.dropCode.DataSource = dtcode;
             this.dropCode.DataValueField = "LY_DL";
             this.dropCode.DataTextField = "LY_DL";
             this.dropCode.DataBind();
             dropCode.Items.Insert(0, new ListItem("--请选择--", ""));

             DataTable dtothercode = SQLHelper.reDs("select LY_MX from Paperless_LYCode where  ly_dl like '%" + dropCode.SelectedValue + "%'").Tables[0];
             this.dropOthercode.DataSource = dtothercode;
             this.dropOthercode.DataValueField = "LY_MX";
             this.dropOthercode.DataTextField = "LY_MX";
             this.dropOthercode.DataBind();
             dropOthercode.Items.Insert(0, new ListItem("--请选择--", ""));
             if (type != "")
             {
                 DisplayStyle(type, lxtext);
             }
             else
             {
                 DisplayStyle(DropDownList2.SelectedValue,DropDownList2.SelectedItem.Text);
             }
         }
     
    

    }

    public DataTable Getcomp()  //取得人员所在部门、公司
    {
        string sql = @"select dept.UNITNAME,case when left(dept.UNITCODE,2)='02' then '200' else '100' end as comp
	                             from [ehr_db].dbo.psnaccount
	                             left join [eHR_DB].dbo.ORGSTDSTRUCT on PSNACCOUNT.BRANCHID=ORGSTDSTRUCT.UNITID
                                  left join [eHR_DB].dbo.ORGSTDSTRUCT dept on left(ORGSTDSTRUCT.UNITCODE,8)=dept.UNITCODE and dept.ISTEMPUNIT=0
                                  where PSNACCOUNT.accessionstate in(1,2,6) and  EMPLOYEEID='" + Session["UserLoginName"].ToString() + "'";
        DataTable dt = SQLHelper.reDs(sql).Tables[0];
        return dt;

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        lbs_Message.Text = "";
        GridView2.DataSource = null;
        DataTable dt = new DataTable();
        GridView2.Visible = true;
        GridView1.Visible = false;
        string lx = "";
        string xwlh = "";
        string tdwlh = "";
        td_desc.Text = "";
        error_msg.Text = "";
        lx = DropDownList2.SelectedItem.Value;
        dt = Car.MyCar_Query(1, txt_djzhh.Text.ToString(), "", txt_zjgg.Text.ToString(), "", txt_zjbm.Text.ToString(), Session["UserLoginName"].ToString(), 0, "", "", 0,lx);
        DataTable newdt = dt.Clone();
        DataRow[] rows = dt.Select("zt='Y'"); // 从dt 中查询符合条件的记录； 
        foreach (DataRow row in rows)  // 将查询的结果添加到dt中； 
        {
            newdt.Rows.Add(row.ItemArray);
        }
        for (int i = 0; i < newdt.Rows.Count; i++)
        {
            xwlh = newdt.Rows[i]["xwlh"].ToString();
            tdwlh = newdt.Rows[i]["part"].ToString();
            td_desc.Text+= "" + tdwlh + "为" + xwlh + "的替代刀具,请优先领用!"+"<br/>";
        }
        GridView2.DataSource = dt;
        GridView2.DataBind();
       
        if (dt.Rows.Count > 0)
        {
            btn_submit.Visible = true;
        }
        else
        {
            btn_submit.Visible = false;
        }

    }

    protected void DisplayStyle(string typeid,string typename)
    {
        string xwlh = "";
        string tdwlh = "";
       // DataTable djdt;
        //string typeid = "";//定义下拉框辅料类型
        //string typename = "";//定义下拉框辅料名称
        //typeid = type == "" ? DropDownList2.SelectedItem.Value : type;
        // typename = lxtext == "" ? DropDownList2.SelectedItem.Text : lxtext;

         if (typename != "") 
        {
            if (typename == "辅料-刀具类")
            {
                string lx = DropDownList2.SelectedItem.Value;
               DataTable djdt = Car.MyCar_Query(1, txt_djzhh.Text.ToString(), "", txt_zjgg.Text.ToString(), "", txt_zjbm.Text.ToString(), Session["UserLoginName"].ToString(), 0, "", "", 0, lx); 
                DataTable newdt = djdt.Clone();
                DataRow[] rows = djdt.Select("zt='Y'"); // 从dt 中查询符合条件的记录； 
                foreach (DataRow row in rows)  // 将查询的结果添加到dt中； 
                {
                    newdt.Rows.Add(row.ItemArray);
                }
                for (int i = 0; i < newdt.Rows.Count; i++)
                {
                    xwlh = newdt.Rows[i]["xwlh"].ToString();
                    tdwlh = newdt.Rows[i]["part"].ToString();
                    td_desc.Text += "" + tdwlh + "为" + xwlh + "的替代刀具,请优先领用!" + "<br/>";
                }

                Panel2.Visible = true;
                Panel3.Visible = false;
                DataTable dt = new DataTable();
                GridView2.Visible = true;
               // dt = Car.MyCar_Query(1, "", "", "", "", "", Session["UserLoginName"].ToString(), 0, "", "", 0, typeid);
                if (role == "调试组")
                {
                    dt = Car.MyCar_DylQuery(1, txt_djzhh.Text.ToString(), "", txt_zjgg.Text.ToString(), "", txt_zjbm.Text.ToString(), Session["UserLoginName"].ToString(), 0, "", "", 0, lx);
                }
                else
                { dt = Car.MyCar_Query(1, txt_djzhh.Text.ToString(), "", txt_zjgg.Text.ToString(), "", txt_zjbm.Text.ToString(), Session["UserLoginName"].ToString(), 0, "", "", 0, lx); }
                GridView2.DataSource = dt;
                GridView2.DataBind();

                if (dt.Rows.Count > 0)
                {
                    btn_submit.Visible = true;
                }

                DropDownList2.SelectedValue = typeid;

            }
            else if (typename == "辅料-机床备件类")
            {
                Panel2.Visible = false;
                Panel3.Visible = true;
                DataTable dt = new DataTable();
                GridView1.Visible = true;
                dt = Car.MyCar_Query(1, "", "", "", "", "", Session["UserLoginName"].ToString(), 0, "", "", 0, typeid);
                GridView1.DataSource = dt;
                GridView1.Columns[6].Visible = true; //机床备件类
                GridView1.Columns[7].Visible = false;//设备位置
                GridView1.Columns[8].Visible = false;//项目号
                GridView1.Columns[9].Visible = false;//研发项目
                GridView1.Columns[10].Visible = false;//状态
                GridView1.Columns[11].Visible = false;//模具号
                GridView1.Columns[12].Visible = false;//代理人
                GridView1.Columns[13].Visible = true;//领用日期
                GridView1.Columns[14].Visible = true;//领用位置
                GridView1.Columns[15].Visible = false;//领用原因
                GridView1.Columns[16].Visible = false;//领用类型
                if ((visdept.Text.Contains("工程") || visdept.Text.Contains("压铸技术部") || visdept.Text.Contains("项目")) && viscomp.Text=="200")
                {
                    GridView1.Columns[8].Visible = true;
                    GridView1.Columns[9].Visible = true;
                    GridView1.Columns[10].Visible = true;
                }
                if (visdept.Text.Contains("压铸技术部"))
                {
                    GridView1.Columns[14].Visible = false;
                }
                GridView1.DataBind();
                if (dt.Rows.Count > 0)
                {
                    btn_submit_sb.Visible = true;
                }
                DropDownList2.SelectedValue = typeid;
            }
            else if (typename == "辅料-压铸备件类")
            {
                Panel2.Visible = false;
                Panel3.Visible = true;
                DataTable dt = new DataTable();
                GridView1.Visible = true;
                dt = Car.MyCar_Query(1, "", "", "", "", "", Session["UserLoginName"].ToString(), 0, "", "", 0, typeid);
                GridView1.DataSource = dt;
                GridView1.Columns[6].Visible = false; //工单号
                GridView1.Columns[7].HeaderText = "设备位置";
                GridView1.Columns[7].Visible = true;
                GridView1.Columns[8].Visible = false;
                GridView1.Columns[9].Visible = false;
                GridView1.Columns[10].Visible = false;
                GridView1.Columns[11].HeaderText = "模具号";
                GridView1.Columns[11].Visible = true;
                GridView1.Columns[12].Visible = false;//代理人
                GridView1.Columns[13].Visible = true;//领用日期
                GridView1.Columns[14].Visible = false;//领用位置
                GridView1.Columns[15].Visible = false;//领用原因
                GridView1.Columns[16].Visible = true;//领用类型
                if ((visdept.Text.Contains("工程") || visdept.Text.Contains("压铸技术部") || visdept.Text.Contains("项目")) && viscomp.Text=="200")
                {
                    GridView1.Columns[8].Visible = true;
                    GridView1.Columns[9].Visible = true;
                    GridView1.Columns[10].Visible = true;
                }
                GridView1.DataBind();
                if (dt.Rows.Count > 0)
                {
                    btn_submit_sb.Visible = true;
                }
                DropDownList2.SelectedValue = typeid;
            }
            else if (typename == "辅料-模具备件")
            {
                Panel2.Visible = false;
                Panel3.Visible = true;
                DataTable dt = new DataTable();
                GridView1.Visible = true;
                dt = Car.MyCar_Query(1, "", "", "", "", "", Session["UserLoginName"].ToString(), 0, "", "", 0, typeid);
                GridView1.Columns[6].Visible = false;
                GridView1.Columns[7].Visible = false;
                GridView1.Columns[8].Visible = false;
                GridView1.Columns[9].Visible = false;
                GridView1.Columns[10].Visible = false;
                GridView1.Columns[11].Visible = false;
                GridView1.Columns[12].Visible = false;
                GridView1.Columns[13].Visible = true;
                GridView1.Columns[14].Visible = true;
                GridView1.Columns[15].Visible = false;
                GridView1.Columns[16].Visible = true;//领用类型
                if ((visdept.Text.Contains("工程") || visdept.Text.Contains("压铸技术部") || visdept.Text.Contains("项目")) && viscomp.Text=="200")
                {
                    GridView1.Columns[8].Visible = true;
                    GridView1.Columns[9].Visible = true;
                    GridView1.Columns[10].Visible = true;
                }
                if (visdept.Text.Contains("压铸技术部"))
                {
                    GridView1.Columns[14].Visible = false;
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
                if (dt.Rows.Count > 0)
                {
                    btn_submit_sb.Visible = true;
                }
                DropDownList2.SelectedValue = typeid;
            }
            else if (typename == "辅料-刀具辅件类")
            {
                Panel2.Visible = false;
                Panel3.Visible = true;
                DataTable dt = new DataTable();
                GridView1.Visible = true;
                dt = Car.MyCar_Query(1, "", "", "", "", "", Session["UserLoginName"].ToString(), 0, "", "", 0, typeid);
                GridView1.DataSource = dt;
                GridView1.Columns[6].Visible = false;
                GridView1.Columns[7].Visible = false;
                GridView1.Columns[8].Visible = true;
                GridView1.Columns[9].Visible = true;
                GridView1.Columns[10].Visible = true;
                GridView1.Columns[11].Visible = false;
                GridView1.Columns[12].Visible = false;
                GridView1.Columns[13].Visible = true;
                GridView1.Columns[14].Visible = true;//领用位置
                GridView1.Columns[15].Visible = true;//领用原因
                GridView1.Columns[16].Visible = true;//领用类型
                GridView1.DataBind();
                if (dt.Rows.Count > 0)
                {
                    btn_submit_sb.Visible = true;
                }
                DropDownList2.SelectedValue = typeid;
            }

            else
            {
                Panel2.Visible = false;
                Panel3.Visible = true;
                DataTable dt = new DataTable();
                GridView1.Visible = true;
                dt = Car.MyCar_Query(1, "", "", "", "", "", Session["UserLoginName"].ToString(), 0, "", "", 0, typeid);
                GridView1.Columns[6].Visible = false;
                GridView1.Columns[7].Visible = false;
                GridView1.Columns[8].Visible = false;
                GridView1.Columns[9].Visible = false;
                GridView1.Columns[10].Visible = false;
                GridView1.Columns[11].Visible = false;
                GridView1.Columns[12].Visible = false;
                GridView1.Columns[13].Visible = true;
                GridView1.Columns[14].Visible = true;
                GridView1.Columns[15].Visible = false;
                GridView1.Columns[16].Visible = false;
                if ((visdept.Text.Contains("工程") || visdept.Text.Contains("压铸技术部") || visdept.Text.Contains("项目")) && viscomp.Text=="200")
                {
                    GridView1.Columns[8].Visible = true;
                    GridView1.Columns[9].Visible = true;
                    GridView1.Columns[10].Visible = true;
                }
                if (visdept.Text.Contains("压铸技术部"))
                {
                    GridView1.Columns[14].Visible = false;
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
                if (dt.Rows.Count > 0)
                {
                    btn_submit_sb.Visible = true;
                }

                DropDownList2.SelectedValue = typeid;
            }
        }
    }
    
    protected void Button3_Click(object sender, EventArgs e)
    {
        lbs_Message_sb.Text = "";
        DataTable dt = new DataTable();
        GridView1.Visible = true;
        GridView2.Visible = false;
        
        string lx = "";
        string uid = Session["UserLoginName"].ToString();
        lx = DropDownList2.SelectedItem.Value;
        dt = Car.MyCar_Query(1, txt_sbwlbm.Text.ToString(), txt_sbwlmc.Text.ToString(), txt_sbggxh.Text.ToString(), "", "", Session["UserLoginName"].ToString(), 0, "", "", 0, lx);
        DisplayStyle(DropDownList2.SelectedValue,DropDownList2.SelectedItem.Text);
    }
   
    protected void btnRemoveOne_Click(object sender, EventArgs e)
    {
        int lnindex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
        int num = 0;
        string part = "";
        string comp = "";
        int sftnum = 0;
        string position = "";
        string group_part="";
        group_part = GridView2.Rows[lnindex].Cells[1].Text.ToString().Replace("&nbsp;", "");
        part = GridView2.Rows[lnindex].Cells[2].Text.ToString().Replace("&nbsp;", "");
        comp = GridView2.Rows[lnindex].Cells[18].Text.ToString();
        sftnum = int.Parse(GridView2.Rows[lnindex].Cells[19].Text.ToString());
        num = int.Parse(((TextBox)this.GridView2.Rows[lnindex].FindControl("txtCount")).Text);
        position = ((TextBox)this.GridView2.Rows[lnindex].FindControl("txt_position")).Text;
        string lx = DropDownList2.SelectedItem.Value;
        if (num == 1)
        {
            Response.Write("<script language=javascript>alert('数量当前为1,若不需该物料，请点击删除！')</script>");
            return;

        }
        int i = Car.update_llcnum(2,group_part, part, "","", "","","", Session["UserLoginName"].ToString(), num, "", comp, sftnum,"","",position,"");
        DataTable dt = new DataTable();
        if (i >= 1)
        {

            dt = Car.MyCar_Query(1, txt_djzhh.Text.ToString(), "", txt_zjgg.Text.ToString(), "", txt_zjbm.Text.ToString(), Session["UserLoginName"].ToString(), 0, "", comp, 0,lx);
            GridView2.DataSource = dt;
            GridView2.DataBind();
            if (dt.Rows.Count > 0)
            {
                btn_submit.Visible = true;
            }
            else
            {
                btn_submit.Visible = false;
                td_desc.Text = "";
                error_msg.Text = "";
            }
        }


    }
    protected void InsertGrid()
    {
         string group_part = "";
        string version = "";
        string lylx = "";
        string xmh = "";
        decimal currentkc=0;
        string yjlydate = "";
        string code = "";
        string loc = "";
        string remark = "";
        string ly_code = "";
         string part = "";
        string desc1 = "";
        string desc2 = "";
         string unit = "";
         int sftnum = 0;
         string gxh = "";
         int num = 0;
         string dj_positon = "";
         string djdlr = "";
         string ljh = "";
         string lx = DropDownList2.SelectedItem.Value;
         bool flag = false;
         for (int i = 0; i < this.GridView2.Rows.Count; i++)
         {

             CheckBox chk = (CheckBox)this.GridView2.Rows[i].FindControl("chkSelect");
             if (chk.Checked == true)
             {

                 TextBox txtCount = (TextBox)GridView2.Rows[i].FindControl("txtCount");
                 TextBox positon = (TextBox)GridView2.Rows[i].FindControl("txt_position");
                 TextBox txtdlr = (TextBox)GridView2.Rows[i].FindControl("txt_dlr_dj");
                 TextBox txtljh = (TextBox)GridView2.Rows[i].FindControl("txt_ljh");
                 TextBox txtxmh = (TextBox)GridView2.Rows[i].FindControl("txt_xmh");
                 TextBox txtlylx = (TextBox)GridView2.Rows[i].FindControl("txt_lylx");
                 TextBox txtlycode = (TextBox)GridView2.Rows[i].FindControl("txt_ly_code");
                 TextBox yfcode = (TextBox)GridView2.Rows[i].FindControl("txtdj_yfxm");
                 TextBox status = (TextBox)GridView2.Rows[i].FindControl("txtdj_status");
                 group_part = this.GridView2.Rows[i].Cells[1].Text.ToString().Replace("&nbsp;", "");
                 part = this.GridView2.Rows[i].Cells[2].Text.ToString().Replace("&nbsp;", "");
                 desc1 = this.GridView2.Rows[i].Cells[3].Text.ToString();
                 desc2 = this.GridView2.Rows[i].Cells[4].Text.ToString();
                 unit = this.GridView2.Rows[i].Cells[5].Text.ToString();
                 sftnum = int.Parse(this.GridView2.Rows[i].Cells[19].Text.ToString());
                 version = this.GridView2.Rows[i].Cells[20].Text.ToString();
                 gxh = this.GridView2.Rows[i].Cells[21].Text.ToString();
                 //DataTable dt = Car.sb_carquery(1, DropDownList2.SelectedItem.Value, part, "", comp, "");
                 //currentkc = Convert.ToDecimal(dt.Rows[0][3].ToString());
                 yjlydate = this.GridView2.Rows[i].Cells[16].Text.ToString().Replace("&nbsp;", "").Replace("&amp;nbsp;", ""); ;
                 code = ((DropDownList)GridView2.Rows[i].FindControl("ddl_code")).SelectedValue;
                 remark = ((DropDownList)GridView2.Rows[i].FindControl("ly_remark")).SelectedValue;
                 ly_code = ((DropDownList)GridView2.Rows[i].FindControl("ly_code")).SelectedValue;
                 loc = this.GridView2.Rows[i].Cells[23].Text.ToString().Replace("&nbsp;", "").Replace("&amp;nbsp;", "");
                 xmh = txtxmh.Text.ToString();
                 num = int.Parse(txtCount.Text);
                 dj_positon = positon.Text.ToString();
                 djdlr = txtdlr.Text.ToString();
                 ljh = txtljh.Text.ToString();
                 lylx = txtlylx.Text.ToString();

                 if (remark != "")
                 {
                     if (txtlycode.Text != "")
                     {
                         remark = remark + ":" + txtlycode.Text;
                     }
                     else if (ly_code != "")
                     {
                         remark = remark + ":" + ly_code;
                     }
                 }
                 //暂时hidden
                 int j = Car.MyCar_Record(1, group_part, part, desc1, desc2, unit, dj_positon, lylx, num, viscomp.Text, version, djdlr, xmh, sftnum, ljh, gxh, "", Session["UserLoginName"].ToString(), yjlydate, code, loc, remark,"",yfcode.Text,status.Text);
                 flag = true;
             }
           
            
         }
         if (flag)
         {
             lbs_Message.Text = "";
             Response.Write("<script>javascript:alert('领料成功，可至我的领料记录查看')</script>");
             DataTable dt = new DataTable();
             dt = Car.MyCar_Query(1, "", "", "", "", "", Session["UserLoginName"].ToString(), 0, "", "", 0, lx);
             GridView2.DataSource = dt;
             GridView2.DataBind();
             if (dt.Rows.Count > 0)
             {
                 btn_submit.Visible = true;
             }
             else
             {
                 btn_submit.Visible = false;
             }
         }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        string part = "";
        string desc1 = "";
        string desc2 = "";
        string unit = "";
        int num = 0;
        string comp = "";
        string gxh = "";
        int sftnum = 0;
        string group_part = "";
        string version = "";
        decimal currentkc=0;
        string yjlydate = "";
        string code = "";
        string loc = "";
        string remark = "";
        string ly_code = "";
        string lx = DropDownList2.SelectedItem.Value;
        string uid = Session["UserLoginName"].ToString();
        string dept = DJ.Get_MO_Code(2, uid, "","").Rows[0][0].ToString();
        string zt = "";
        string wlh="";
        bool Ischecked=false;
        lbs_Message.Text = "";
       error_msg.Text = "";
        bool isexists = false;
        bool retvalues = false;
        DataTable dt1 = new DataTable();
        dt1.Columns.Add("part");
        dt1.Columns.Add("xwlh");
        dt1.Columns.Add("tdwlh");
        dt1.Columns.Add("kc");
        dt1.Columns.Add("lysl");
         dt1.Columns.Add("zt");
         DataRow row1 = dt1.NewRow();
        /* 刀具领用时提前判断  存在替代刀具的,则提示优先选择替代刀具*/
        for (int i = 0; i < this.GridView2.Rows.Count; i++)
        {
            CheckBox ckchecked = (CheckBox)this.GridView2.Rows[i].FindControl("chkSelect");
            if (ckchecked.Checked == true)
            {
                part = this.GridView2.Rows[i].Cells[2].Text.ToString().Replace("&nbsp;", "").ToString();
                string xwlh = this.GridView2.Rows[i].Cells[25].Text.ToString().Replace("&nbsp;", "").ToString();
                string tdwlh = this.GridView2.Rows[i].Cells[26].Text.ToString().Replace("&nbsp;", "").ToString();
                if (tdwlh != "")
                {
                    DataTable dt_kc = Car.sb_carquery(1, DropDownList2.SelectedItem.Value, tdwlh, "", viscomp.Text, "");
                    currentkc = Convert.ToDecimal(dt_kc.Rows[0][3].ToString());
                    zt = this.GridView2.Rows[i].Cells[24].Text.ToString().Replace("&nbsp;", "").Replace("&amp;nbsp;", "");
                    float lysl = int.Parse(((TextBox)GridView2.Rows[i].FindControl("txtCount")).Text);
                    row1["part"] = part;
                    row1["xwlh"] = xwlh;
                    row1["tdwlh"] = tdwlh;
                    row1["kc"] = currentkc;
                    row1["lysl"] = lysl;
                    row1["zt"] = zt;
                    dt1.Rows.Add(row1.ItemArray);

                }
            }
           
        }
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                if (dt1.Rows[i]["part"].ToString().Contains(dt1.Rows[j]["tdwlh"].ToString()))
                {
                    isexists = true;
                }
            }

            if (isexists == false)
            {
                error_msg.Text += "请勾选替代刀具" + dt1.Rows[i]["tdwlh"].ToString() + "优先领用!" + "<br/>";
                retvalues = true;
                return;
            }
        
            if (dt1.Rows[i]["zt"].ToString() == "Y" && (decimal.Parse(dt1.Rows[i]["kc"].ToString()) < decimal.Parse(dt1.Rows[i]["lysl"].ToString())))//&& decimal.Parse(dt1.Rows[i]["kc"].ToString()) < decimal.Parse(dt1.Rows[i]["lysl"].ToString())
            {
                error_msg.Text += "替代刀具" + dt1.Rows[i]["tdwlh"].ToString() + "领用数量大于库存量,请结合" + dt1.Rows[i]["xwlh"].ToString() + "一起领用!" + "<br/>";
                retvalues = true;
                return;
            }
            if (dt1.Rows[i]["zt"].ToString() == "Y")
            {
                dt1.DefaultView.RowFilter = "part='"+dt1.Rows[i]["tdwlh"]+"'";
                DataTable tddt = dt1.DefaultView.ToTable();
                dt1.DefaultView.RowFilter = "part='" + dt1.Rows[i]["xwlh"] + "'";
                DataTable xdt = dt1.DefaultView.ToTable();
                if (tddt.Rows.Count > 0 && xdt.Rows.Count > 0)
                {
                    if (int.Parse(tddt.Rows[i]["lysl"].ToString()) + int.Parse(xdt.Rows[i]["lysl"].ToString()) <= float.Parse(tddt.Rows[i]["kc"].ToString()))
                    {
                        float kcsl = float.Parse(tddt.Rows[i]["kc"].ToString());
                        error_msg.Text += "替代刀具" + dt1.Rows[i]["tdwlh"].ToString() + "的库存数量为" + kcsl + ",请直接以" + dt1.Rows[i]["tdwlh"].ToString() + "领用!";
                        retvalues = true;
                        return;
                    }
                    if (int.Parse(tddt.Rows[i]["lysl"].ToString()) + int.Parse(xdt.Rows[i]["lysl"].ToString()) > float.Parse(tddt.Rows[i]["kc"].ToString()) && int.Parse(tddt.Rows[i]["lysl"].ToString()) < float.Parse(tddt.Rows[i]["kc"].ToString()))
                    {
                        float kcsl = float.Parse(tddt.Rows[i]["kc"].ToString());
                        error_msg.Text += "替代刀具" + dt1.Rows[i]["tdwlh"].ToString() + "的库存数量为" + kcsl + ",可领用数量为" + kcsl + "!";
                        retvalues = true;
                        return;
                    }
                }
            }

        }
       
            for (int i = 0; i < this.GridView2.Rows.Count; i++)
            {

                CheckBox chk = (CheckBox)this.GridView2.Rows[i].FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    Ischecked = true;
                    TextBox txtCount = (TextBox)GridView2.Rows[i].FindControl("txtCount");
                    TextBox positon = (TextBox)GridView2.Rows[i].FindControl("txt_position");
                    TextBox txtdlr = (TextBox)GridView2.Rows[i].FindControl("txt_dlr_dj");
                    TextBox txtljh = (TextBox)GridView2.Rows[i].FindControl("txt_ljh");
                    TextBox txtxmh = (TextBox)GridView2.Rows[i].FindControl("txt_xmh");
                    TextBox txtlylx = (TextBox)GridView2.Rows[i].FindControl("txt_lylx");
                    TextBox txtlycode = (TextBox)GridView2.Rows[i].FindControl("txt_ly_code");
                    group_part = this.GridView2.Rows[i].Cells[1].Text.ToString().Replace("&nbsp;", "");
                    part = this.GridView2.Rows[i].Cells[2].Text.ToString().Replace("&nbsp;", "");
                    desc1 = this.GridView2.Rows[i].Cells[3].Text.ToString();
                    desc2 = this.GridView2.Rows[i].Cells[4].Text.ToString();
                    unit = this.GridView2.Rows[i].Cells[5].Text.ToString();
                   // comp = this.GridView2.Rows[i].Cells[16].Text.ToString();
                    sftnum = int.Parse(this.GridView2.Rows[i].Cells[19].Text.ToString());
                    version = this.GridView2.Rows[i].Cells[20].Text.ToString();
                    gxh = this.GridView2.Rows[i].Cells[21].Text.ToString();
                    DataTable dt = new DataTable();
                    if (part.Substring(0, 1).ToUpper() != "Z" && part.Substring(0, 1).ToUpper() != "P")
                    {
                        dt = GetDate(part);
                    }
                    else
                    {
                        dt = Car.sb_carquery(1, DropDownList2.SelectedItem.Value, part, "", viscomp.Text, "");
                    }
                    //DataTable dt = Car.sb_carquery(1, DropDownList2.SelectedItem.Value, part, "", viscomp.Text, "");
                    // currentkc = decimal.Parse(this.GridView2.Rows[i].Cells[19].Text.ToString());
                    currentkc = Convert.ToDecimal(dt.Rows[0][3].ToString());
                    yjlydate = this.GridView2.Rows[i].Cells[16].Text.ToString().Replace("&nbsp;", "").Replace("&amp;nbsp;", ""); ;
                    code = ((DropDownList)GridView2.Rows[i].FindControl("ddl_code")).SelectedValue;
                    remark = ((DropDownList)GridView2.Rows[i].FindControl("ly_remark")).SelectedValue;
                    ly_code = ((DropDownList)GridView2.Rows[i].FindControl("ly_code")).SelectedValue;
                    loc = this.GridView2.Rows[i].Cells[23].Text.ToString().Replace("&nbsp;", "").Replace("&amp;nbsp;", "");
                    zt = this.GridView2.Rows[i].Cells[24].Text.ToString().Replace("&nbsp;", "").Replace("&amp;nbsp;", "");
                    wlh = this.GridView2.Rows[i].Cells[25].Text.ToString().Replace("&nbsp;", "").Replace("&amp;nbsp;", "");
                    if (int.TryParse(txtCount.Text, out num) == false)
                    {
                       // Response.Write("<script>javascript:alert('数量必须为整数！')</script>");
                        lbs_Message.Text += "" + part + "领用数量必须为整数!"+"</br>";
                        retvalues = true;
                       // return;
                    }
                    if (int.Parse(txtCount.Text) > currentkc && part.Substring(0, 1) != "P")
                    {
                        int lack_int = int.Parse(txtCount.Text) - decimal.ToInt16(currentkc);
                      //  Response.Write("<script>javascript:alert('" + part + "领用数量大于实际库存量，请确认后再提交！')</script>");
                        lbs_Message.Text += "" + part + "领用数量大于实际库存量,当前库存为" + decimal.ToInt16(currentkc) + ",还欠缺数量"+lack_int+"个!" + "</br>";
                        retvalues = true;
                        //return;
                    }
                    //if (int.Parse(txtCount.Text) == 0)
                    //{
                    //    lbs_Message.Text += "物料号：" + part + "领用数量不可为0!" + "</BR>";
                    //    retvalues = true;
                    //}

                    if (code == "")
                    {
                        lbs_Message.Text += "移动代码必须选择!"+"</BR>";
                        retvalues = true;
                     //   return;
                    }
                    if (remark == "")
                    {
                        lbs_Message.Text += "刀具领用原因必须选择!" + "</BR>";
                        retvalues = true;
                       // return;
                    }
                    else if ((remark == "仓库调整" || remark == "其它") && txtlycode.Text == "")
                    {
                        lbs_Message.Text += "请填写领用原因!" + "</BR>";
                        retvalues = true;
                       // return;
                    }
                    else if ((remark != "仓库调整" && remark != "其它") && ly_code == "")
                    {
                        lbs_Message.Text += "请选择" + remark + "原因!" + "</BR>";
                        retvalues = true;
                        //return;
                    }
                    //if (txtxmh.Text.ToString() == "")
                    //{
                    //    lbs_Message.Text += "请填写完整项目号!" + "</BR>";
                    //    retvalues = true;
                    // //   return;
                    //}
                    string sql = "select top  1 pt_part from Qad_pt_mstr where pt_prod_line like '3%' and pt_part='" + txtxmh.Text + "' ";
                    DataTable dt_xmh = SQLHelper.reDs(sql).Tables[0];
                    if (dt_xmh.Rows.Count == 0)
                    {
                        lbs_Message.Text += "请填写正确项目号!" + "</BR>";
                        retvalues = true;
                     //   return;
                    }
                }
                //else
                //{
                   
                //}
                continue;
               
              
            }
            if (retvalues == false && Ischecked==true)
            {
                InsertGrid();
            }
            if(Ischecked==false)
            {
                 lbs_Message.Visible = true;
                 lbs_Message.Text ="请勾选！";

            }

    }

    #region 取费用类物料的当前库存
    public DataTable GetDate( string wlbm)
    {
        DataTable NewTable = new DataTable();
        NewTable.Columns.Add("pt_part", typeof(string));
        NewTable.Columns.Add("pt_desc1", typeof(string));
        NewTable.Columns.Add("pt_desc2", typeof(string));
        NewTable.Columns.Add("ld_qty_oh", typeof(Int32));
        NewTable.Columns.Add("domain", typeof(string));
        NewTable.Columns.Add("pt_sfty_stk", typeof(Int32));
        NewTable.Columns.Add("loc", typeof(string));

        //取已签核完成的PO单料号和物料类型
        //string sqlstr = @"select qad_pono+'_'+cast(po_dtl.rowid as varchar) as wlh,wlmc,wlms,substring(wltype,1,charindex('-',wltype)-1)line,isnull(rec_Quantity,0)rec_Quantity
        //                              from [172.16.5.26].mes.dbo.PUR_PO_Dtl_Form  po_dtl join [172.16.5.26].mes.dbo.PUR_PR_Dtl_Form pr_dtl on  po_dtl.PRNo=pr_dtl.PRNo and po_dtl.PRRowId=pr_dtl.rowid
        //                             left join paperless_NoMaterial_Qty  nom on qad_pono+'_'+cast(po_dtl.rowid as varchar)=nom.part
        //                              where qad_pono+'_'+cast(po_dtl.rowid as varchar) ='" + wlbm + "'";
        string sqlstr = @"select qad_pono+'_'+cast(po_dtl.rowid as varchar) as wlh,wlmc,wlms
                            ,case when charindex('-',wltype)>0 then substring(wltype,1,charindex('-',wltype)-1) else '4000' end line
                            ,isnull(rec_Quantity,0)rec_Quantity
                        from [172.16.5.26].mes.dbo.PUR_PO_Dtl_Form  po_dtl join [172.16.5.26].mes.dbo.PUR_PR_Dtl_Form pr_dtl on  po_dtl.PRNo=pr_dtl.PRNo and po_dtl.PRRowId=pr_dtl.rowid
                        left join paperless_NoMaterial_Qty  nom on qad_pono+'_'+cast(po_dtl.rowid as varchar)=nom.part
                        where qad_pono+'_'+cast(po_dtl.rowid as varchar) ='" + wlbm + "' and flag_qad='是'   and isnull(po_dtl.qad_pono,'')<>''";
        DataTable xt_dt = SQLHelper.reDs(sqlstr.ToString()).Tables[0];
        try
        {
            DataTable qad_dt = new DataTable();
            //查询QAD中采购订单状态浏览(NEW)中的收货量
            string IsSQL = @" select pod_part as pt_part,pod_part as pt_desc1,pod_vpart   as pt_desc2 ,cast(pod_qty_rcvd as int)  as ld_qty_oh,
                                                 pod_site from pub.pod_det where pod_type='M' 
                                                 and pod_part ='{0}'";
            string sql_str = string.Format(IsSQL, wlbm);
            qad_dt = QAD_ODBC.Pub.GetODBCRows(sql_str);

            List<int> lstbRowsIndex = new List<int>();
            foreach (DataRow rowa in xt_dt.Rows)
            {
                bool matchFlag = false;
                for (int i = 0; i < qad_dt.Rows.Count; i++)
                {
                    if (lstbRowsIndex.Contains(i)) continue;

                    DataRow rowb = qad_dt.Rows[i];
                    //以物料号作为合并的比较项
                    if (rowa["wlh"].ToString() == rowb["pt_part"].ToString())
                    {
                        lstbRowsIndex.Add(i);
                        //part在两表中都存在时
                        NewTable.Rows.Add(rowa["wlh"], rowa["wlmc"], rowa["wlms"],  int.Parse(rowb["ld_qty_oh"].ToString()) - int.Parse(rowa["rec_Quantity"].ToString()), rowb["pod_site"], 0, "");
                        matchFlag = true;
                        break;
                    }
                }

                if (!matchFlag)
                {
                    //采购订单状态中不存在时，默认收货数量为0
                    NewTable.Rows.Add(rowa["wlh"], rowa["wlmc"], rowa["wlms"],  0, "", 0, "");
                }
            }
     

        }

        catch (Exception error)
        {
        }
        return NewTable;
    }

    #endregion



    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbs_Message.Text = "";
        lbs_Message_sb.Text = "";
        td_desc.Text = "";
        error_msg.Text = "";
        if (DropDownList2.SelectedItem.Text == "辅料-刀具类")
        {
            Panel2.Visible = true;
            Panel3.Visible = false;
            GridView1.Visible = false;
            GridView2.Visible = false;
            btn_submit.Visible = false;
            btn_submit_sb.Visible = false;
        }
        else
        {
            Panel2.Visible = false;
            Panel3.Visible = true;
            GridView1.Visible = false;
            GridView2.Visible = false;
            btn_submit.Visible = false;
            btn_submit_sb.Visible = false;
        }
        
    }
    protected void btnAddOne_sb_Click(object sender, EventArgs e)
    {
        //int lnindex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
        //int num = 0;
        //string part = "";
        //string comp = "";
        //string lx = DropDownList2.SelectedItem.Value;
        //part = GridView1.Rows[lnindex].Cells[1].Text.ToString();
        //comp = GridView1.Rows[lnindex].Cells[16].Text.ToString();
        //num = int.Parse(((TextBox)this.GridView1.Rows[lnindex].FindControl("txtCount1")).Text);
        //int i = Car.update_llcnum(3, "", part, "", "", "", "", "", Session["UserLoginName"].ToString(), num, "", comp, 0, "", "", "", "");
        ////int i = Car.update_llcnum(3, part, "", "","","", Session["UserLoginName"].ToString(), num, "",comp,0);
       
        //DataTable dt = new DataTable();
        //if (i >= 1)
        //{
        //    dt = Car.MyCar_Query(1, txt_djzhh.Text.ToString(), "",txt_zjgg.Text.ToString(), "", txt_zjbm.Text.ToString(), Session["UserLoginName"].ToString(), num, "", comp,0,lx);
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();
        //}
    }
    protected void btnRemoveOne_sb_Click(object sender, EventArgs e)
    {
        int lnindex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
        int num = 0;
        string part = "";
        string comp = "";
        string lx = DropDownList2.SelectedItem.Value;
        part = GridView1.Rows[lnindex].Cells[1].Text.ToString();
        comp = GridView1.Rows[lnindex].Cells[16].Text.ToString();
        num = int.Parse(((TextBox)this.GridView1.Rows[lnindex].FindControl("txtCount1")).Text);
        if (num == 1)
        {
            Response.Write("<script language=javascript>alert('数量当前为1,若不需该物料，请点击删除！')</script>");
            return;

        }
        int i = Car.update_llcnum(2, "", part, "", "", "", "", "", Session["UserLoginName"].ToString(), num, "", comp, 0, "", "", "", "");
        DataTable dt = new DataTable();
        if (i >= 1)
        {

            dt = Car.MyCar_Query(1, txt_djzhh.Text.ToString(), "",txt_zjgg.Text.ToString(), "", txt_zjbm.Text.ToString(), Session["UserLoginName"].ToString(), 0, "", comp,0,lx);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            lbs_Message_sb.Visible = false;
            if (dt.Rows.Count > 0)
            {
                btn_submit_sb.Visible = true;
                
            }
            else
            {
                btn_submit_sb.Visible = false;
            }
        }

    }
 
    protected void btn_submit_sb_Click(object sender, EventArgs e)
    {
        string part = "";
        string desc1 = "";
        string desc2 = "";
        string unit = "";
        int num = 0;
        string gdh = "";
        string dj_positon = "";
        string comp = "";
        string code = "";
        string dlr="";
        int sftnum = 0;
        string yjlydate = "";
        string lx = DropDownList2.SelectedItem.Value;
        bool flag = false;
        decimal currentkc = 0;
        string loc = "";
        string sbpos = "";
        string mojuno = "";
        string remark = "";
        string type = "";
        string ddl_lycode = "";
        string ly_desc="";

        lbs_Message_sb.Text = "";
        lbs_Message_sb.Visible = true;
         string uid = Session["UserLoginName"].ToString();
        string dept = DJ.Get_MO_Code(2, uid, "","").Rows[0][0].ToString();
 
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)this.GridView1.Rows[i].FindControl("chkSelect0");
            if (chk.Checked == true)
            {
                TextBox txtCount = (TextBox)GridView1.Rows[i].FindControl("txtCount1"); //领用数量
                TextBox txtyjly = (TextBox)GridView1.Rows[i].FindControl("txtyjly_date");//领用日期
                TextBox txtgdh = (TextBox)GridView1.Rows[i].FindControl("txt_gdh0");//工单号
                TextBox txtdlr = (TextBox)GridView1.Rows[i].FindControl("txt_dlr_sb");//领料代理人
                TextBox txtsbpos = (TextBox)GridView1.Rows[i].FindControl("txt_sbpos");//设备位置
                TextBox txtmjno = (TextBox)GridView1.Rows[i].FindControl("txt_mojuno");//模具号
                TextBox lydesc = (TextBox)GridView1.Rows[i].FindControl("txt_lycode");//领用原因-其他--其他调整
                ASPxComboBox selxmh = (ASPxComboBox)GridView1.Rows[i].FindControl("xmh_select");//项目号
                ASPxTextBox yfxm = (ASPxTextBox)GridView1.Rows[i].FindControl("txt_yfxm");//研发项目
                ASPxTextBox pt_status = (ASPxTextBox)GridView1.Rows[i].FindControl("txt_status");//项目状态
                part = this.GridView1.Rows[i].Cells[1].Text.ToString();
                desc1 = this.GridView1.Rows[i].Cells[2].Text.ToString();
                desc2 = this.GridView1.Rows[i].Cells[3].Text.ToString();
                unit = this.GridView1.Rows[i].Cells[4].Text.ToString();
                comp = this.GridView1.Rows[i].Cells[19].Text.ToString();
                sftnum = int.Parse(this.GridView1.Rows[i].Cells[20].Text.ToString());
                DataTable dt;
            //    DataTable dt = Car.sb_carquery(1, DropDownList2.SelectedItem.Value, part, "", comp, "");
                if (part.Substring(0, 1).ToUpper() != "Z")
                {
                    dt = GetDate(part);
                }
                else
                {
                     dt = Car.sb_carquery(1, DropDownList2.SelectedItem.Value, part, "", comp, "");
                }

                currentkc = Convert.ToDecimal(dt.Rows[0][3].ToString());
                dj_positon = ((DropDownList)GridView1.Rows[i].FindControl("ddlposition")).SelectedValue;//领用位置
                code = ((DropDownList)GridView1.Rows[i].FindControl("ddlcode")).SelectedValue;//移动代码
                remark = ((DropDownList)GridView1.Rows[i].FindControl("ddl_remark")).SelectedValue;//领用原因
                ddl_lycode = ((DropDownList)GridView1.Rows[i].FindControl("ddl_lycode")).SelectedValue;//领用原因
                type = ((DropDownList)GridView1.Rows[i].FindControl("ddl_type")).SelectedValue;//领用类型
                loc = this.GridView1.Rows[i].Cells[22].Text.ToString().Replace("&nbsp;", "").Replace("&amp;nbsp;", ""); 
                if (int.TryParse(txtCount.Text, out num) == false)
                {
                    Response.Write("<script>javascript:alert('数量必须为整数！')</script>");
                    return;
                }
                if (int.Parse(txtCount.Text) > currentkc)
                {
                    Response.Write("<script>javascript:alert('领用数量大于实际库存量，请确认后再提交！')</script>");
                    lbs_Message_sb.Text = "领用数量大于实际库存量";
                    return;
                }
                //if (int.Parse(txtCount.Text) == 0)
                //{
                //    lbs_Message_sb.Text += "物料号：" + part + "领用数量不可为0!" + "</BR>";
                //    return;
                //}
                num = int.Parse(txtCount.Text);
                gdh = txtgdh.Text.ToString();
                dlr = txtdlr.Text.ToString();
                sbpos = txtsbpos.Text.ToString();
                mojuno = txtmjno.Text.ToString();
                //机床备件类工单号必须填写
                if (DropDownList2.SelectedItem.Text == "辅料-机床备件类")
                {
                    //DataTable gdlist = Car.usp_Keyin_gdh(Session["UserLoginName"].ToString(), gdh);
                    DataTable gdlist = Car.usp_Keyin_gdh(Session["UserLoginName"].ToString(), gdh, code, dj_positon);

                    string Iskeyin = gdlist.Rows[0][0].ToString();
                    string isgdh = gdlist.Rows[0][1].ToString();
                    if (Iskeyin == "N" || isgdh == "N")
                    {

                        lbs_Message_sb.Text = "工单号必须填写,且必须存在!";
                        return;
                    }
                }
                if ((visdept.Text.Contains("工程") || visdept.Text.Contains("压铸技术部") || visdept.Text.Contains("项目")) && viscomp.Text=="200")
                {
                    if (selxmh.Text == "")
                    {
                        lbs_Message_sb.Text = "项目号必须选择!";
                        return;
                    }
                }
                //机床备件类&自动化项目类领用位置和移动代码必须选择
                if ((DropDownList2.SelectedItem.Text == "辅料-机床备件类" || DropDownList2.SelectedItem.Text == "辅料-自动化项目类" || DropDownList2.SelectedItem.Text == "辅料-夹具备件" || DropDownList2.SelectedItem.Text == "辅料-五金类") && !visdept.Text.Contains("压铸技术部"))
                {
                    if (code == "" || dj_positon == "") 
                    {
                        lbs_Message_sb.Text = "领用位置和移动代码必须选择!";
                        return;
                    }
                }
               else if (DropDownList2.SelectedItem.Text == "辅料-压铸备件类")
                {
                    if (sbpos == "" || mojuno == "" || type == "" || code == "")
                    {
                        lbs_Message_sb.Text = "设备位置和模具号,领用类型和移动代码必须填写!";
                        return;
                    }
                }
                else if ((DropDownList2.SelectedItem.Text == "辅料-模具备件") && !visdept.Text.Contains("压铸技术部"))
                {
                    if (dj_positon == "" || code == "" || type == "" )
                    {
                        lbs_Message_sb.Text = "领用位置和移动代码,领用类型必须填写!";
                        return;
                    }
                }
                else if (DropDownList2.SelectedItem.Text == "辅料-刀具辅件类")
                {
                    if (remark == "" || type == "" || code == "" || selxmh.Text == "")//ddl_lycode=="" || //20190517 注释
                    {
                        lbs_Message_sb.Text = "项目号、领用位置、领用类型、移动代码必须填写!";//和领用原因
                        return;
                    }
                    if (remark == "其它" || remark == "仓库调整")
                    {
                        if (lydesc.Text == "")
                        {
                            lbs_Message_sb.Text = "请填写领用原因!";
                            lydesc.Focus();
                            return;
                        }
                    }
                    else if (ddl_lycode == "")
                    {
                        lbs_Message_sb.Text = "请选择"+remark+"原因!";
                        return;
                    }
                   
                }
                else if (code == "")
                {
                    lbs_Message_sb.Text = "移动代码必须选择!";
                    return;
                }
           
                if (visdept.Text.Contains("压铸技术部") )
                {
                    if (code == "")
                    {
                        lbs_Message_sb.Text = "移动代码必须选择!";
                        return;
                    }
                    if ((DropDownList2.SelectedItem.Text == "辅料-模具备件") && type == "")
                    {
                        lbs_Message_sb.Text = "领用类型必须选择!";
                        return;
                    }
                }
                yjlydate = txtyjly.Text.ToString();
                if (remark != "")
                {
                    if (lydesc.Text != "")
                    {
                        remark = remark + ":" + lydesc.Text;
                    }
                    else if (ddl_lycode != "")
                    {
                        remark = remark + ":" + ddl_lycode;
                    }
                }
                if (DropDownList2.SelectedItem.Text != "辅料-压铸备件类" && DropDownList2.SelectedItem.Text != "辅料-刀具辅件类")
                {
                    Car.MyCar_Record(1, "", part, desc1, desc2, unit, dj_positon, type, num, comp, "", dlr, "", sftnum, "", "", gdh, Session["UserLoginName"].ToString(), yjlydate, code, loc, remark, selxmh.Text, yfxm.Text, pt_status.Text);
                    flag = true;

                }
                else
                {
                    int II = Car.MyCar_Record(1, "", part, desc1, desc2, unit, sbpos, type, num, comp, "", dlr, mojuno, sftnum, "", "", gdh, Session["UserLoginName"].ToString(), yjlydate, code, loc, remark,selxmh.Text,yfxm.Text,pt_status.Text );
                    flag = true;
                    
                }




            }

            else
            {
                if (chk.Checked == false)
                {
                    lbs_Message_sb.Text = "请勾选!";
                }
                lbs_Message_sb.Text = lbs_Message_sb.Text;

            }
            


        }
        if (flag)
        {
            lbs_Message_sb.Text = "";
            Response.Write("<script>javascript:alert('生成领料单，可至我的领料记录查看')</script>");
            DataTable dt = new DataTable();
            dt = Car.MyCar_Query(1, "", "", "","","", Session["UserLoginName"].ToString(), 0, "","",0,lx);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            if (dt.Rows.Count > 0)
            {
                btn_submit_sb.Visible = true;
            }
            else
            {
                btn_submit_sb.Visible = false;
            }
        }

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.SelectedIndex = -1;
        GridView1.PageIndex = e.NewPageIndex;
        string lx = DropDownList2.SelectedItem.Value;
        DataTable dt = Car.MyCar_Query(1, txt_djzhh.Text.ToString(),"",txt_zjgg.Text.ToString(), "", txt_zjbm.Text.ToString(), Session["UserLoginName"].ToString(), 0, "", "",0,lx);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dt = new DataTable();
        string lx = DropDownList2.SelectedItem.Value;
        dt = Car.MyCar_Query(1, txt_djzhh.Text.ToString(), "",txt_zjgg.Text.ToString(), "", txt_zjbm.Text.ToString(), Session["UserLoginName"].ToString(), 0, "", "",0,lx);
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        int lnindex = ((GridViewRow)((ImageButton)sender).NamingContainer).RowIndex;
        int num = 0;
        string part = "";
        string comp = "";
        string lx = DropDownList2.SelectedItem.Value;
        part = GridView1.Rows[lnindex].Cells[1].Text.ToString();
       
        comp = GridView1.Rows[lnindex].Cells[10].Text.ToString();
       
        if (int.TryParse(((TextBox)this.GridView1.Rows[lnindex].FindControl("txtCount1")).Text, out num) == false)
        {
            Response.Write("<script>javascript:alert('数量必须为整数！')</script>");
            return ;
        }
        num = int.Parse(((TextBox)this.GridView1.Rows[lnindex].FindControl("txtCount1")).Text);
        int i = Car.update_llcnum(4, "", part, "", "", "", "", "", Session["UserLoginName"].ToString(), num, "", comp, 0, "", "", "", "");

        DataTable dt = new DataTable();
        if (i >= 1)
        {
            Response.Write("<script>javascript:alert('删除成功')</script>");
            dt = Car.MyCar_Query(1, txt_djzhh.Text.ToString(), "", txt_zjgg.Text.ToString(), "", txt_zjbm.Text.ToString(), Session["UserLoginName"].ToString(), num, "", comp,0,lx);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            lbs_Message_sb.Visible = false;
        }
        if (dt.Rows.Count > 0)
        {
            btn_submit_sb.Visible = true;
        }
        else
        {
            btn_submit_sb.Visible = false;
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        int lnindex = ((GridViewRow)((ImageButton)sender).NamingContainer).RowIndex;
        int num = 0;
        int i = 0;
        string part = "";
        string comp = "";
        string group_part = "";
        string position = "";
        part = GridView2.Rows[lnindex].Cells[2].Text.ToString().Replace("&nbsp;", "");
        group_part = GridView2.Rows[lnindex].Cells[1].Text.ToString();
        string lx = DropDownList2.SelectedItem.Value;
        if (int.TryParse(((TextBox)this.GridView2.Rows[lnindex].FindControl("txtCount")).Text, out num) == false)
        {
            Response.Write("<script>javascript:alert('数量必须为整数！')</script>");
            return;
        }
        num = int.Parse(((TextBox)this.GridView2.Rows[lnindex].FindControl("txtCount")).Text);
        position = ((TextBox)this.GridView2.Rows[lnindex].FindControl("txt_position")).Text;
        comp = GridView2.Rows[lnindex].Cells[14].Text.ToString();
         i = Car.update_llcnum(4, group_part.Replace("&nbsp;", ""), part, "", "", "", "", "", Session["UserLoginName"].ToString(), num, "", comp, 0, "", "", position, "");
        //增加批量删除功能
        if (((CheckBox)this.GridView2.HeaderRow.FindControl("CheckAll")).Checked == true)
        {
            string sql = @"delete from Paperless_Mycar  where  create_uid='" + Session["UserLoginName"].ToString() + "' and  (part like 'z01%' or group_part like 'P%')";
            i = SQLHelper.ExecuteSql(sql);
        }
        DataTable dt = new DataTable();
        if (i >= 1)
        {
            Response.Write("<script>javascript:alert('删除成功')</script>");
            dt = Car.MyCar_Query(1, txt_djzhh.Text.ToString(), "", txt_zjgg.Text.ToString(), "", txt_zjbm.Text.ToString(), Session["UserLoginName"].ToString(), num, "", comp,0,lx);
            GridView2.DataSource = dt;
            GridView2.DataBind();
            lbs_Message.Visible = false;
        }
        if (dt.Rows.Count >= 1)
        {
            btn_submit.Visible = true;
        }
        else
        {
            btn_submit.Visible = false;
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var lyremark = "";
        var lycode = "";
        var txtcode = "";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string zt = e.Row.Cells[22].Text.ToString();
            if (zt == "Y")
            {
                e.Row.BackColor = System.Drawing.Color.Yellow;
            }
            string uid = Session["UserLoginName"].ToString();
            string part = e.Row.Cells[2].Text.ToString();
            string dept = DJ.Get_MO_Code(2, uid, "", "").Rows[0][0].ToString();
            TextBox status = ((TextBox)e.Row.FindControl("txtdj_status"));
         //  DataTable dtcode = DJ.Get_MO_Code(3, uid, dept, part);
            DataTable dtcode = SQLHelper.Query("exec usp_GetStock_Code '" + Session["UserLoginName"] + "','" + visdept.Text + "','" + part + "','" + viscomp.Text + "','" + status.Text + "'").Tables[0];
            DataTable dtremakr = DJ.Get_MO_Code(4, "", "", "");
            DropDownList ddl = ((DropDownList)e.Row.FindControl("ddl_code"));
            DropDownList remark = ((DropDownList)e.Row.FindControl("ly_remark"));
            DropDownList lymx = ((DropDownList)e.Row.FindControl("ly_code"));
            TextBox othercode = ((TextBox)e.Row.FindControl("txt_ly_code"));
            if (ddl != null)
            {
                if (dtcode.Rows.Count > 1)
                {
                    ddl.DataSource = dtcode;
                    ddl.DataTextField = "describ";
                    ddl.DataValueField = "describ";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("", ""));
                }
                else
                {
                    ddl.DataSource = dtcode;
                    ddl.DataTextField = "describ";
                    ddl.DataValueField = "describ";
                    ddl.DataBind();
                }
            }
            //if (remark != null)
            //{
            //    remark.DataSource = dtremakr;
            //    remark.DataTextField = "remark";
            //    remark.DataValueField = "remark";
            //    remark.DataBind();
            //    remark.Items.Insert(0, new ListItem("", ""));
            //}
            StringBuilder sql = new StringBuilder();
            sql.Append(" select distinct id,LY_DL from Paperless_LYCode  ");

            DataSet ds = SQLHelper.reDs(sql.ToString());

            remark.DataSource = ds.Tables[0];
            remark.DataValueField = "LY_DL";
            remark.DataTextField = "LY_DL";
            remark.DataBind();
            if (((DropDownList)this.FindControl("dropCode")) != null && ((DropDownList)this.FindControl("dropCode")).Text!="")
            {
                lyremark = ((DropDownList)this.FindControl("dropCode")).Text;
                remark.SelectedValue = lyremark;
            }
            else
            {
                remark.Items.Insert(0, new ListItem("请选择", ""));
            }
            DataSet dt_do = SQLHelper.reDs("select * from Paperless_LYCode where  ly_dl like '%" + lyremark + "%'");
            lymx.DataSource = dt_do.Tables[0];
            lymx.DataValueField = "ly_mx";
            lymx.DataTextField = "ly_mx";
            lymx.DataBind();
            if (((DropDownList)this.FindControl("dropOthercode")) != null && ((DropDownList)this.FindControl("dropOthercode")).Text != "")
            {
                lycode = ((DropDownList)this.FindControl("dropOthercode")).Text;
                lymx.SelectedValue= lycode;
            }
            else if (((TextBox)this.FindControl("txt_othercode")) != null && ((TextBox)this.FindControl("txt_othercode")).Text != "")
            {
                othercode.Text = ((TextBox)this.FindControl("txt_othercode")).Text.ToString();
                lymx.Visible = false;
                othercode.Visible = true;
            }
            else
            {
                lymx.Items.Insert(0, new ListItem("请选择", ""));
            }

        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string uid = Session["UserLoginName"].ToString();
                string part = e.Row.Cells[1].Text.ToString();
                string comp = e.Row.Cells[16].Text.ToString();
                string dept = DJ.Get_MO_Code(2, uid, "", "").Rows[0][0].ToString();
                DataTable dtcode = DJ.Get_MO_Code(3, uid, dept, part);
                DataTable api = DJ.Get_MO_Code(1, "", viscomp.Text, "");
                DataTable dtremark = DJ.Get_MO_Code(4, "", "", "");

                ((TextBox)(e.Row.FindControl("txtyjly_date"))).Text = System.DateTime.Now.ToShortDateString();
                DropDownList ddl = ((DropDownList)e.Row.FindControl("ddlcode"));//库存移动代码
                DropDownList type = ((DropDownList)e.Row.FindControl("ddl_type"));
                DropDownList ddlposition = ((DropDownList)e.Row.FindControl("ddlposition"));
                DropDownList remark = ((DropDownList)e.Row.FindControl("ddl_remark"));
                DropDownList ddl_lycode = ((DropDownList)e.Row.FindControl("ddl_lycode"));
                ASPxComboBox xmh = ((ASPxComboBox)e.Row.FindControl("xmh_select"));
                if (DropDownList2.SelectedItem.Text == "辅料-压铸备件类" || DropDownList2.SelectedItem.Text == "辅料-模具备件")
                {
                    type.Items.Clear();
                    type.Items.Insert(0, new ListItem("", ""));
                    type.Items.Insert(1, new ListItem("新品领用", "新品领用"));
                    type.Items.Insert(2, new ListItem("以旧换新", "以旧换新"));
                    type.Items.Insert(3, new ListItem("仓库调整", "仓库调整"));
                }
                if (xmh != null)
                {
                    DataTable dt_xmh = SQLHelper.reDs(" select '' as text,'' as value union select PT_PART+'/'+pt_desc1 AS text,PT_PART as value from Qad_pt_mstr where left(pt_prod_line,1)='3' and pt_status<>'DEAD' and domain='" + uid_comp + "'").Tables[0];
                    xmh.DataSource = dt_xmh;
                    xmh.TextField = "text";
                    xmh.ValueField = "value";
                    xmh.DataBind();
                }
                if (ddl != null)
                {
                    if (dtcode.Rows.Count > 1)
                    {
                        ddl.DataSource = dtcode;
                        ddl.DataTextField = "describ";
                        ddl.DataValueField = "describ";
                        ddl.DataBind();
                        ddl.Items.Insert(0, new ListItem("", ""));
                    }
                    else
                    {
                        ddl.DataSource = dtcode;
                        ddl.DataTextField = "describ";
                        ddl.DataValueField = "describ";
                        ddl.DataBind();
                    }
                }


                if (ddlposition != null)
                {
                    ddlposition.DataSource = api;
                    ddlposition.DataTextField = "mo_code_name";
                    ddlposition.DataValueField = "mo_code_key";
                    ddlposition.DataBind();
                    ddlposition.Items.Insert(0, new ListItem("请选择", ""));
                }
                //if (remark != null)
                //{
                //    remark.DataSource = dtremark;
                //    remark.DataTextField = "remark";
                //    remark.DataValueField = "remark";
                //    remark.DataBind();
                //    remark.Items.Insert(0, new ListItem("", ""));
                //}


                StringBuilder sql = new StringBuilder();
                sql.Append(" select distinct id,LY_DL from Paperless_LYCode  ");
                
                DataSet ds = SQLHelper.reDs(sql.ToString());

                remark.DataSource = ds.Tables[0];
                remark.DataValueField = "LY_DL";
                remark.DataTextField = "LY_DL";
                remark.DataBind();
                remark.Items.Insert(0, new ListItem("请选择", ""));
                ddl_lycode.Items.Insert(0, new ListItem("请选择", ""));
            }

        
    }
    protected void ddl_remark_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList ddl_remark = (DropDownList)sender;
        GridViewRow gvr = (GridViewRow)ddl_remark.NamingContainer;
        TextBox txt_code = (TextBox)gvr.FindControl("txt_lycode");
        DropDownList ddlcode = (DropDownList)gvr.FindControl("ddl_lycode");
        txt_code.Text = "";
        if (ddl_remark.SelectedValue == "其它" || ddl_remark.SelectedValue == "仓库调整")
        {
            txt_code.Visible = true;
            ddlcode.Visible = false;
        }

        else
        {
            txt_code.Visible = false;
            ddlcode.Visible = true;
            string sqlStr = "select * from Paperless_LYCode where  ly_dl='" + ddl_remark.SelectedValue + "'";

            DataSet ds = SQLHelper.reDs(sqlStr.ToString());
            ddlcode.DataSource = ds.Tables[0];
            ddlcode.DataValueField = "ly_mx";
            ddlcode.DataTextField = "ly_mx";
            ddlcode.DataBind();
            ddlcode.Items.Insert(0, new ListItem("请选择", ""));
        }

        

    }
    protected void ly_remark_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ly_remark = (DropDownList)sender;
        GridViewRow gvr = (GridViewRow)ly_remark.NamingContainer;
        TextBox txt_code = (TextBox)gvr.FindControl("txt_ly_code");
        DropDownList ddlcode = (DropDownList)gvr.FindControl("ly_code");
        txt_code.Text = "";
        if (ly_remark.SelectedValue == "其它" || ly_remark.SelectedValue == "仓库调整")
        {
            txt_code.Visible = true;
            ddlcode.Visible = false;
        }

        else
        {
            txt_code.Visible = false;
            ddlcode.Visible = true;
            string sqlStr = "select * from Paperless_LYCode where  ly_dl='" + ly_remark.SelectedValue + "'";

            DataSet ds = SQLHelper.reDs(sqlStr.ToString());
            ddlcode.DataSource = ds.Tables[0];
            ddlcode.DataValueField = "ly_mx";
            ddlcode.DataTextField = "ly_mx";
            ddlcode.DataBind();
            ddlcode.Items.Insert(0, new ListItem("请选择", ""));
        }
    }
    protected void CheckAll0_CheckedChanged(object sender, EventArgs e)
    {
        bool flag = ((CheckBox)this.GridView1.HeaderRow.FindControl("CheckAll0")).Checked;
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            ((CheckBox)GridView1.Rows[i].FindControl("chkSelect0")).Checked = flag;
        }  
    }
    protected void CheckAll_CheckedChanged(object sender, EventArgs e)
    {
        bool flag = ((CheckBox)this.GridView2.HeaderRow.FindControl("CheckAll")).Checked;
        for (int i = 0; i < this.GridView2.Rows.Count; i++)
        {
            ((CheckBox)GridView2.Rows[i].FindControl("chkSelect")).Checked = flag;
        }  
    }

    /*
    protected void ddlcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlcode = (DropDownList)sender;
        GridViewRow gvr = (GridViewRow)ddlcode.NamingContainer;
        int index = gvr.RowIndex;
        string comp = GridView1.Rows[index].Cells[16].Text.ToString().TrimEnd();
        DropDownList code = (DropDownList)gvr.FindControl("ddlcode");
        DropDownList postion = (DropDownList)gvr.FindControl("ddlposition");
        TextBox txt_gdh = (TextBox)gvr.FindControl("txt_gdh0");
        DataTable dt = new DataTable();

        if (ddlcode.SelectedValue == "设备部自动化项目配件领用")
        {
            var sql = string.Format(" select xmbh as mo_code_key ,xmbh+xmms as mo_code_name from [172.16.5.8].ecology.dbo.formtable_main_55_zdhxm");
            dt = SQLHelper.reDs(sql).Tables[0];
        }
        else
        {
            dt = DJ.Get_MO_Code(5, "", comp, "");
            var sqlstr = string.Format(" select wo_key,mo_code_key from [172.16.5.26].api.dbo.Work_Order_Ongoing where wo_key='" + txt_gdh.Text + "'");
            DataTable sb_dt = SQLHelper.reDs(sqlstr).Tables[0];
            if (sb_dt.Rows.Count > 0)
            {
                string sbcode = SQLHelper.reDs(sqlstr).Tables[0].Rows[0][1].ToString();
                postion.SelectedValue = sbcode;
            }
        }

        postion.DataSource = dt;
        postion.DataTextField = "mo_code_name";
        postion.DataValueField = "mo_code_key";
        postion.DataBind();
        postion.Items.Insert(0, new ListItem("请选择", ""));

    }
    */
    protected void ddlcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlcode = (DropDownList)sender;
        GridViewRow gvr = (GridViewRow)ddlcode.NamingContainer;
        int index = gvr.RowIndex;
        DropDownList code = (DropDownList)gvr.FindControl("ddlcode");
        DropDownList postion = (DropDownList)gvr.FindControl("ddlposition");
        TextBox txt_gdh = (TextBox)gvr.FindControl("txt_gdh0");
        DataTable dt = new DataTable();

        dt = DJ.Get_MO_Code(1, "", viscomp.Text, "");

        if (ddlcode.SelectedValue == "设备部自动化项目配件领用")
        {
            var sql = string.Format(" select xmbh as mo_code_key,xmbh+'('+xmms+')' as mo_code_name from [172.16.5.8].ecology.dbo.formtable_main_55_zdhxm order by xmbh");
            DataTable dt_2 = SQLHelper.reDs(sql).Tables[0];

            foreach (DataRow dr in dt_2.Rows)
            {
                dt.ImportRow(dr);
            }
        }
        else
        {
            var sqlstr = string.Format(" select wo_key,mo_code_key from [172.16.5.26].api.dbo.Work_Order_Ongoing where wo_key='" + txt_gdh.Text + "'");
            DataTable sb_dt = SQLHelper.reDs(sqlstr).Tables[0];
            if (sb_dt.Rows.Count > 0)
            {
                string sbcode = SQLHelper.reDs(sqlstr).Tables[0].Rows[0][1].ToString();
                postion.SelectedValue = sbcode;
            }
        }   

        postion.DataSource = dt;
        postion.DataTextField = "mo_code_name";
        postion.DataValueField = "mo_code_key";
        postion.DataBind();
        postion.Items.Insert(0, new ListItem("请选择", ""));
      
    }   

    protected void txt_gdh0_TextChanged(object sender, EventArgs e)
    {
        TextBox gdh = (TextBox)sender;
        GridViewRow gvr = (GridViewRow)gdh.NamingContainer;
        DropDownList postion = (DropDownList)gvr.FindControl("ddlposition");
        DropDownList ddlcode = (DropDownList)gvr.FindControl("ddlcode");
        int index = gvr.RowIndex;
        TextBox txt_gdh = (TextBox)gvr.FindControl("txt_gdh0");
        if (ddlcode.SelectedValue != "设备部自动化项目配件领用")
        {
            var sql = string.Format(" select wo_key,mo_code_key from [172.16.5.26].api.dbo.Work_Order_Ongoing where wo_key='" + gdh .Text+ "'");
           DataTable sb_dt = SQLHelper.reDs(sql).Tables[0];
           if (sb_dt.Rows.Count > 0)
           {
               string code = SQLHelper.reDs(sql).Tables[0].Rows[0][1].ToString();
               postion.SelectedValue = code;
           }
            
        }
    }
    protected void Btn_lycode_Click(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string SetOtherCode(string sel)
    {
        string result = "";
        string ly_value = "";
        var value = SQLHelper.reDs("select LY_MX as text,LY_MX as value from Paperless_LYCode where  ly_dl='" + sel + "'").Tables[0];
        result = Newtonsoft.Json.JsonConvert.SerializeObject(value);
        return result;
    }

    protected void btn_set_Click(object sender, EventArgs e)
    {
        Button4_Click(sender, e);
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        
    }

    //获取研发项目
    [System.Web.Services.WebMethod()]
    public static string Getcode(string code, string comp,string dept)
    {
        string result = "";
        var yfcode="";
        string strsql="select A.*,pt_status from (";
        strsql+="    select '"+code+"' as pt_part,'"+comp+"' AS domain,* from [dbo].[paperless_yfxm]  WHERE cpline=(select pt_prod_line from Qad_pt_mstr where pt_part ='" + code + "' and domain='" + comp + "' ))A";
         strsql += "    join Qad_pt_mstr pt on a.pt_part=pt.pt_part and a.domain=pt.domain";
        DataTable dt = SQLHelper.reDs(strsql).Tables[0];
        if ((dt.Rows.Count > 0 && (dept.Contains("工程") || dept.Contains("压铸"))) && dt.Rows[0][5].ToString().ToUpper()=="SAMPLE" && comp=="200")
        {
            yfcode = dt.Rows[0][3].ToString(); 
        }
      //  var yfcode = dt.Rows.Count == 0 ? "" : dt.Rows[0][3].ToString();
        var status = dt.Rows.Count == 0 ? "" : dt.Rows[0][5].ToString();
        result = "[{\"yfcode\":\"" + yfcode + "\",\"status\":\"" + status + "\"}]";


        return result;

    }


    protected void xmh_select_SelectedIndexChanged(object sender, EventArgs e)
    {
       // int lnindex = ((GridViewRow)((ASPxComboBox)sender).NamingContainer).RowIndex;
        ASPxComboBox sel_xmh = (ASPxComboBox)sender;
        GridViewRow gvr = (GridViewRow)sel_xmh.NamingContainer;
       int index = gvr.RowIndex;
        string wlh = GridView1.Rows[index].Cells[1].Text.ToString().TrimEnd();
        ASPxTextBox pt_status = (ASPxTextBox)gvr.FindControl("txt_status");
        DropDownList ddl = ((DropDownList)gvr.FindControl("ddlcode"));//库存移动代码
        DataTable dt = SQLHelper.Query("exec usp_GetStock_Code '" + Session["UserLoginName"] + "','" + visdept.Text + "','" + wlh + "','" + viscomp.Text + "','" + pt_status.Text + "'").Tables[0];
        if (dt.Rows.Count > 1)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = "describ";
            ddl.DataValueField = "describ";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("", ""));
        }
        else
        {
            ddl.DataSource = dt;
            ddl.DataTextField = "describ";
            ddl.DataValueField = "describ";
            ddl.DataBind();
        }
    }
    protected void txt_xmh_TextChanged(object sender, EventArgs e)
    {
        TextBox XMH = (TextBox)sender;
        GridViewRow gvr = (GridViewRow)XMH.NamingContainer;
        TextBox yfxm = (TextBox)gvr.FindControl("txtdj_yfxm");
        TextBox status = (TextBox)gvr.FindControl("txtdj_status");
        int index = gvr.RowIndex;
        string wlh = GridView2.Rows[index].Cells[2].Text.ToString().TrimEnd();
        string strsql = "select A.*,pt_status,PT.pt_desc1 from (";
        string dept = visdept.Text;
        strsql += "    select '" + XMH.Text + "' as pt_part,'" + viscomp.Text + "' AS domain,* from [dbo].[paperless_yfxm]  WHERE cpline=(select pt_prod_line from Qad_pt_mstr where pt_part ='" + XMH.Text + "' and domain='" + viscomp.Text + "' ))A";
        strsql += "    join Qad_pt_mstr pt on a.pt_part=pt.pt_part and a.domain=pt.domain";
        DataSet ds = SQLHelper.reDs(strsql.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            status.Text = ds.Tables[0].Rows[0][5].ToString();
            if ((dept.Contains("工程") || dept.Contains("压铸技术部")) && status.Text.ToUpper() == "SAMPLE" && viscomp.Text == "200")
            {
                yfxm.Text = ds.Tables[0].Rows[0][3].ToString();
            }
            else
            {
                yfxm.Text = "";
            }
        }
        DropDownList ddl = ((DropDownList)gvr.FindControl("ddl_code"));//库存移动代码
        DataTable dt = SQLHelper.Query("exec usp_GetStock_Code '" + Session["UserLoginName"] + "','" + visdept.Text + "','" + wlh + "','" + viscomp.Text + "','" + status.Text + "'").Tables[0];
        if (dt.Rows.Count > 1)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = "describ";
            ddl.DataValueField = "describ";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("", ""));
        }
        else
        {
            ddl.DataSource = dt;
            ddl.DataTextField = "describ";
            ddl.DataValueField = "describ";
            ddl.DataBind();
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        lbs_Message.Text = "";
        GridView2.DataSource = null;
        DataTable dt = new DataTable();
        GridView2.Visible = true;
        GridView1.Visible = false;
        string lx = "";
        string xwlh = "";
        string tdwlh = "";
        td_desc.Text = "";
        error_msg.Text = "";
        lx = DropDownList2.SelectedItem.Value;
        dt = Car.MyCar_DylQuery(1, txt_djzhh.Text.ToString(), "", txt_zjgg.Text.ToString(), "", txt_zjbm.Text.ToString(), Session["UserLoginName"].ToString(), 0, "", "", 0, lx);
        DataTable newdt = dt.Clone();
        DataRow[] rows = dt.Select("zt='Y'"); // 从dt 中查询符合条件的记录； 
        foreach (DataRow row in rows)  // 将查询的结果添加到dt中； 
        {
            newdt.Rows.Add(row.ItemArray);
        }
        for (int i = 0; i < newdt.Rows.Count; i++)
        {
            xwlh = newdt.Rows[i]["xwlh"].ToString();
            tdwlh = newdt.Rows[i]["part"].ToString();
            td_desc.Text += "" + tdwlh + "为" + xwlh + "的替代刀具,请优先领用!" + "<br/>";
        }
        GridView2.DataSource = dt;
        GridView2.DataBind();

        if (dt.Rows.Count > 0)
        {
            btn_submit.Visible = true;
        }
        else
        {
            btn_submit.Visible = false;
        }
    }
}