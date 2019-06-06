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
using System.Collections.Generic;


public partial class LL_Query : System.Web.UI.Page
{

    string strsql = "select  pl_prod_line,pl_desc from Paperless_pl_mstr ";
    //string strsql1 = "select pt_part as pt_group_part,pt_part,pt_desc1,pt_desc2,pt_um,round(sum(ld_qty_oh),2) as ld_qty_oh,pt_domain,pt_sfty_stk from pub.pt_mstr left join pub.ld_det on ld_part=pt_part  and ld_domain=pt_domain where 1=1 and pt_prod_line='4010' AND (LEFT(ld_loc,2)<>'KM' and LEFT(ld_loc,2)<>'SM' )  ";
    string strsql3 = "select pt_part,pt_desc1,pt_desc2,pt_um, CASE WHEN ld_qty_oh IS NULL THEN  0  ELSE ROUND(CAST(ld_qty_oh AS DECIMAL(18,2)),2) END as ld_qty_oh,pt_domain,pt_sfty_stk from pub.pt_mstr left  join pub.ld_det on ld_part=pt_part  and ld_domain=pt_domain AND (LEFT(ld_loc,2)<>'KM' and LEFT(ld_loc,2)<>'SM' ) where 1=1 ";
    DJ DJ = new DJ();
    Car car = new Car();
    Function_Admin Function_Admin = new Function_Admin();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["dt"] = null;
        string uid = "";

        if (Session["UserLoginName"] == null)
        {
            Response.Redirect("~/Source1/Login.aspx");
            Response.End();


            return;
        }
        uid = Session["UserLoginName"].ToString();
        if (!IsPostBack)
        {
            DataTable dt1 =SQLHelper.reDs(strsql).Tables[0];
            this.DropDownList2.DataSource = dt1;
            this.DropDownList2.DataValueField = "pl_prod_line";
            this.DropDownList2.DataTextField = "pl_desc";
            this.DropDownList2.DataBind();

            DataTable dt = Function_Admin.User_Login(6, uid, "", "");
            Function_Admin.initDrop(DropDownList3, dt, "comp");
            Function_Admin.initDrop(DropDownList4, dt, "comp");
        }

        if (DropDownList2.SelectedItem.Text == "辅料-刀具类")
        {
            Panel2.Visible = true;
            Panel3.Visible = false;
        }
        else
        {
            Panel2.Visible = false;
            Panel3.Visible = true;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        /*加入人员部门判断：工程人员可以选择没有刀具清单的刀具物料号领用，生产部只能选择有刀具清单的物料号*/
        StringBuilder sql = new StringBuilder();
        sql.Append(" select top 1 dept.UNITNAME from [ehr_db].dbo.ORGStdStruct OG join  [ehr_db].dbo.psnaccount PS ON ps.BRANCHID=unitid ");
        sql.Append(" left join [ehr_db].dbo.ORGSTDSTRUCT dept on left(OG.UNITCODE,8)=dept.UNITCODE");
        sql.Append(" where  DIMISSIONDATE='' and employeeid='" + Session["UserLoginName"].ToString() + "'");
        DataSet ds = SQLHelper.reDs(sql.ToString());
        string IsGC = "N";
        ViewState["ISGC"] = IsGC;
        if (txt_ljh.Text == ""  && txt_cpmc.Text=="")
        {
            if (!ds.Tables[0].Rows[0][0].ToString().Contains("工程"))
            {
                Response.Write("<script>javascript:alert('产品名称或项目号必须输入！')</script>");
                return;
            }
            else
            {
                IsGC = "Y";
                if (txt_djzjbm.Text == "" )
                {
                    Response.Write("<script>javascript:alert('请输入要领用的子件编码！')</script>");
                    return;
                }
            }
        }
        ViewState["ISGC"] = IsGC;
        if (txt_djzjbm.Text!="" &&  txt_djzjbm.Text.Substring(0, 1).ToUpper() != "Z")
        {
        //刀具领用时
         DataTable dt = GetDate(DropDownList2.SelectedValue, txt_djzjbm.Text, DropDownList3.SelectedValue, txt_djzjgg.Text);
         Button6.Visible = false;
         Button1.Visible = false;
         Button5.Visible = true;
         GridView1.DataSource = dt;
         GridView1.DataBind();
         Panel2.Visible = true;
         GridView2.Visible = false;
         GridView1.Visible = true;
        }   else {GetDate_DJ(IsGC);}
       
       
        
       
    }

    #region 取费用类物料数据
    public DataTable   GetDate( string djtype,string wlbm,string comp,string wlgg)
    {
        DataTable NewTable = new DataTable();
        NewTable.Columns.Add("pt_part", typeof(string));
        NewTable.Columns.Add("pt_desc1", typeof(string));
        NewTable.Columns.Add("pt_desc2", typeof(string));
        NewTable.Columns.Add("pt_um", typeof(string));
        NewTable.Columns.Add("ld_qty_oh", typeof(Int32));
        NewTable.Columns.Add("domain", typeof(string));
        NewTable.Columns.Add("pt_sfty_stk", typeof(Int32));
        NewTable.Columns.Add("loc", typeof(string));

        //取已签核完成的PO单料号和物料类型(刀具类)  paperless_NoMaterial_Qty记录已经领用的数量
        string sqlstr = "";
        if (djtype=="4000")//费用服务类
        {
            sqlstr = @"select qad_pono+'_'+cast(po_dtl.rowid as varchar) as wlh,wlmc,wlms,'4000' line,isnull(rec_Quantity,0)rec_Quantity
                                      from [172.16.5.26].mes.dbo.PUR_PO_Dtl_Form  po_dtl join [172.16.5.26].mes.dbo.PUR_PR_Dtl_Form pr_dtl on  po_dtl.PRNo=pr_dtl.PRNo and po_dtl.PRRowId=pr_dtl.rowid
                                     left join paperless_NoMaterial_Qty  nom on qad_pono+'_'+cast(po_dtl.rowid as varchar)=nom.part
                                      where  isnull(wlh,'')='' and flag_qad='是'   and isnull(po_dtl.qad_pono,'')<>''";
        }
        else//无料号（刀具类、非刀具辅料类、原材料）
        {
            sqlstr = @"select qad_pono+'_'+cast(po_dtl.rowid as varchar) as wlh,wlmc,wlms,substring(wltype,1,charindex('-',wltype)-1)line,isnull(rec_Quantity,0)rec_Quantity
                                      from [172.16.5.26].mes.dbo.PUR_PO_Dtl_Form  po_dtl join [172.16.5.26].mes.dbo.PUR_PR_Dtl_Form pr_dtl on  po_dtl.PRNo=pr_dtl.PRNo and po_dtl.PRRowId=pr_dtl.rowid
                                     left join paperless_NoMaterial_Qty  nom on qad_pono+'_'+cast(po_dtl.rowid as varchar)=nom.part
                                      where  isnull(wlh,'')='无' and  substring(wltype,1,charindex('-',wltype)-1)='" + djtype + "'   and charindex('-',wltype)>0 and flag_qad='是'   and isnull(po_dtl.qad_pono,'')<>''";
        }
        DataTable xt_dt = SQLHelper.reDs(sqlstr.ToString()).Tables[0];
        try
        {
            DataTable qad_dt = new DataTable();
            //查询QAD中采购订单状态浏览(NEW)中的收货量
            string IsSQL = @" select pod_part  as pt_part,pod_vpart as pt_desc1,pod_desc   as pt_desc2 ,cast(pod_qty_rcvd as int) as ld_qty_oh,
                                                 pod_site from pub.pod_det where pod_type='M'  
                                                 and pod_part like '%{0}%' and pod_site='{1}' and (pod_desc  like '%{2}%' OR pod_vpart like '%{2}%') ";
            string sql_str = string.Format(IsSQL, txt_djzjbm.Text, DropDownList3.SelectedValue, txt_djzjgg.Text);
            qad_dt = QAD_ODBC.Pub.GetODBCRows(sql_str);

            List<int> lstbRowsIndex = new List<int>();
            foreach (DataRow rowa in xt_dt.Rows)
            {
                //bool matchFlag = false;
                for (int i = 0; i < qad_dt.Rows.Count; i++)
                {
                    if (lstbRowsIndex.Contains(i)) continue;

                    DataRow rowb = qad_dt.Rows[i];
                    //以物料号作为合并的比较项
                    if (rowa["wlh"].ToString() == rowb["pt_part"].ToString() && (int.Parse(rowb["ld_qty_oh"].ToString()) - int.Parse(rowa["rec_Quantity"].ToString()))>0)
                    {
                        lstbRowsIndex.Add(i);
                        //part在两表中都存在时
                        NewTable.Rows.Add(rowa["wlh"], rowa["wlmc"], rowa["wlms"], "EA", int.Parse(rowb["ld_qty_oh"].ToString()) - int.Parse(rowa["rec_Quantity"].ToString()), rowb["pod_site"], 0, "");
                        //matchFlag = true;
                        break;
                    }
                }

                //if (!matchFlag)
                //{//采购订单状态中不存在时，默认收货数量为0
                //    NewTable.Rows.Add(rowa["wlh"], rowa["wlmc"], rowa["wlms"], "EA", 0,DropDownList3.SelectedValue, 0, "");
                //}
            }
     
           
        }
           
        catch (Exception error)
        {
        }
       

        return NewTable;
    }

    #endregion
    protected void Button3_Click(object sender, EventArgs e)
    {
        getdate_sb();
        Panel2.Visible = false;
        Panel3.Visible = true;
        GridView1.Visible = true;
    }

    private void GetDate_DJ(string IsGC)
    {
        
        string gxh = "";
        string djzzh = "";
        string cpmc = "";
        string djexists = "";
        if (txt_gxh.Text != "")
        {
            gxh = txt_gxh.Text;
        }
        if (txt_cpmc.Text != "")
        {
            cpmc = txt_cpmc.Text;
        }
        DJ DJ = new DJ();
       
       
        DataSet ds = new DataSet();
        djzzh = txt_djzhh.Text;
        ds = DJ.DJ_Query(1, djzzh, cpmc, gxh, txt_djzjbm.Text, txt_djzjgg.Text, DropDownList3.SelectedValue,txt_ljh.Text,IsGC);
        djexists = ds.Tables[0].Rows[0][0].ToString();
       
       if (ds.Tables[1].Rows.Count > 0 && djexists=="Y") //存在刀具清单，按刀具清单显示
       {
           Button6.Visible = true;
           Button1.Visible = true;
           GridView2.DataSource = ds.Tables[1];
           GridView2.DataBind();
           Panel3.Visible = false;
           GridView1.Visible = false;
           GridView2.Visible = true;
           Button5.Visible = false;
       }
       else if (ds.Tables[1].Rows.Count > 0 && djexists == "N")//不存在刀具清单，按刀具辅件的格式显示
       {
           Button6.Visible = false;
           Button1.Visible = false;
           Button5.Visible = true;
           GridView1.DataSource = ds.Tables[1];
           GridView1.DataBind();
           Panel2.Visible = true;
           GridView2.Visible = false;
           GridView1.Visible = true;
       }
       else
       {
           Button6.Visible = false;
           Button1.Visible = false;
           GridView1.Visible = false;
           GridView2.Visible = false;
           Button6.Visible = false;
           Button1.Visible = false;
           Button5.Visible = false;
       }


      

      
    }
  
    private void getdate_sb()
    {
        DataTable dt = new DataTable();
        //区分费用类领用
        if (txt_sbwlbm.Text != "" && txt_sbwlbm.Text.Substring(0, 1) != "Z")
        {
            dt = GetDate(DropDownList2.SelectedValue, txt_sbwlbm.Text, DropDownList4.SelectedValue, txt_sbwlmc.Text);
        }
        else
        {
            dt = car.sb_query(1, DropDownList2.SelectedItem.Value, txt_sbwlbm.Text, txt_sbwlmc.Text, DropDownList4.SelectedValue, txt_sbggxh.Text);
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
        if (dt.Rows.Count > 0)
        {
            Button5.Visible = true;
        }
        else
        {
            Button5.Visible = false ;
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DropDownList2.SelectedItem.Text == "辅料-刀具类")
        {
            Panel3.Visible = false;
            Panel2.Visible = true;
            GridView1.Visible = false;
            GridView2.Visible = false;
            Button5.Visible = false;
            Button1.Visible = false;
            Button6.Visible = false;


        }
        else
        {
            Panel3.Visible = true;
            Panel2.Visible = false;
            GridView1.Visible = false;
            GridView2.Visible = false;
            Button5.Visible = false;
            Button1.Visible = false;
            Button6.Visible = false;

        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        string type = DropDownList2.SelectedItem.Value;
        string lytext = DropDownList2.SelectedItem.Text;
        Response.Write("<script language='javascript'>window.open(encodeURI('My_Car.aspx?mode=query&type=" + type + "&lxtext=" + lytext + "'),'null','toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=0,top=50,left=100,width=1400,height=700')</script>");

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        
       int lnindex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        //int num = 0;
        string part = "";
        string wlmc = "";
        string ggxh = "";
        string unit = "";
        string comp = "";
        int sftnum =0;
        decimal quantity = 0;
        string loc = "";
        part = GridView1.Rows[lnindex].Cells[0].Text.ToString();
        wlmc = GridView1.Rows[lnindex].Cells[1].Text.ToString();
        ggxh = GridView1.Rows[lnindex].Cells[2].Text.ToString();
        unit = GridView1.Rows[lnindex].Cells[3].Text.ToString();
        comp = GridView1.Rows[lnindex].Cells[5].Text.ToString();
        sftnum =int.Parse( GridView1.Rows[lnindex].Cells[6].Text.ToString());
        quantity =decimal.Parse(GridView1.Rows[lnindex].Cells[4].Text.ToString());
        loc = GridView1.Rows[lnindex].Cells[7].Text.ToString();
        Car Car = new Car();
        if (quantity == 0)
        {
            Response.Write("<script>javascript:alert('库存数量为0，无法领料！')</script>");
            return;
        }
        int i = Car.ADD_TOCar(1, "", part, wlmc, ggxh, "", "", "", unit, 1, Session["UserLoginName"].ToString(), comp, sftnum, "", "", "", "", "", quantity, loc,"","",DropDownList2.SelectedValue);
        if (i >= 1)
        {
            Response.Write("<script>javascript:alert('加入领料车成功！')</script>");
            //((Image)this.GridView1.Rows[lnindex].FindControl("Image1")).Visible = true;
        }

    }
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
        
    //}
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.SelectedIndex = -1;
        GridView1.PageIndex = e.NewPageIndex;
        getdate_sb();
        
       
    
    }


    protected void Button6_Click(object sender, EventArgs e)
    {

        bool flag = false;
        string ljh = "";
        string xmh="";
        string compljh = "";
        string domain = "";
        string gxh="";
        string ISGC = (string)ViewState["ISGC"];
        DataTable dt = new DataTable();
        dt.Columns.Add("pt_group_part", Type.GetType("System.String"));
        dt.Columns.Add("pt_part", Type.GetType("System.String"));
        dt.Columns.Add("pt_desc1", Type.GetType("System.String"));
        dt.Columns.Add("pt_desc2", Type.GetType("System.String"));
        dt.Columns.Add("LJH", Type.GetType("System.String"));
        dt.Columns.Add("pgixmh", Type.GetType("System.String"));
        dt.Columns.Add("pt_um", Type.GetType("System.String"));
        dt.Columns.Add("ld_qty_oh", Type.GetType("System.Decimal"));
        dt.Columns.Add("pt_sfty_stk", Type.GetType("System.Decimal"));
        dt.Columns.Add("pt_domain", Type.GetType("System.String"));
        dt.Columns.Add("bb", Type.GetType("System.String"));
        dt.Columns.Add("xzgxh", Type.GetType("System.String"));
        dt.Columns.Add("loc", Type.GetType("System.String"));
       
       
       
        for (int i = 0; i < this.GridView2.Rows.Count; i++)
        {
            
            CheckBox chk = (CheckBox)this.GridView2.Rows[i].FindControl("chkSelect");
            if (chk.Checked == true)
            {
                  ljh = this.GridView2.Rows[i].Cells[5].Text.ToString();
                  for (int j = i+1; j < this.GridView2.Rows.Count-1; j++)
                  {
                      CheckBox chkc = (CheckBox)this.GridView2.Rows[j].FindControl("chkSelect");
                      if (chkc.Checked == true)
                         
                      {
                          compljh = this.GridView2.Rows[j].Cells[5].Text.ToString();
                          if (ljh != compljh)
                          {
                              Response.Write("<script>javascript:alert('产品名称需一致！')</script>");
                              return;
                          }
                      }
                  }
                    xmh = this.GridView2.Rows[i].Cells[6].Text.ToString();
                    string pt_group_part = this.GridView2.Rows[i].Cells[1].Text.ToString();
                    string XX = pt_group_part.Substring(0, 1);
                    int quantity = Convert.ToInt16(this.GridView2.Rows[i].Cells[8].Text);
                     domain = this.GridView2.Rows[i].Cells[9].Text.ToString();
                    gxh=this.GridView2.Rows[i].Cells[12].Text.ToString();
                    if (quantity == 0 && pt_group_part.Substring(0,1)!="P")
                    {
                        Response.Write("<script>javascript:alert('库存数量为0，无法领料！')</script>");
                        return;
                    }
                    flag = true;
                    DataRow dr = dt.NewRow();
                    dr["pt_group_part"] = this.GridView2.Rows[i].Cells[1].Text.ToString();
                    dr["pt_part"] = this.GridView2.Rows[i].Cells[2].Text.ToString().Replace("&nbsp;", "");
                    dr["pt_desc1"] = this.GridView2.Rows[i].Cells[3].Text.ToString();
                    dr["pt_desc2"] = this.GridView2.Rows[i].Cells[4].Text.ToString();
                    dr["LJH"] = this.GridView2.Rows[i].Cells[5].Text.ToString();
                    dr["pgixmh"] = this.GridView2.Rows[i].Cells[6].Text.ToString();
                    dr["pt_um"] = this.GridView2.Rows[i].Cells[7].Text.ToString();
                    dr["ld_qty_oh"] = this.GridView2.Rows[i].Cells[8].Text.ToString();
                    dr["pt_sfty_stk"] = this.GridView2.Rows[i].Cells[10].Text.ToString();
                    dr["pt_domain"] = this.GridView2.Rows[i].Cells[9].Text.ToString();
                    dr["bb"] = this.GridView2.Rows[i].Cells[11].Text.ToString();
                    dr["xzgxh"] = this.GridView2.Rows[i].Cells[12].Text.ToString();
                    dr["loc"] = this.GridView2.Rows[i].Cells[14].Text.ToString().Replace("&nbsp;", "");
                    dt.Rows.Add(dr);
                   
              
            }
            
        }
        if (flag)
        {
            Session["dt"] = dt;
            Response.Write("<script>window.open('User_Confirm/DJ_Input.aspx?ljh=" + ljh + "&gxh=" + gxh + " &xmh=" + xmh + " &domain=" + domain + "&IsGc=" + ISGC + "','_blank','height=400,width=520,scrollbars=no')</script>");
            GetDate_DJ(ISGC);
            Button1.Visible = true;
            

        }
        if (!flag )
        {
            
        Response.Write("<script>javascript:alert('请选择物料号！')</script>");
        return;
            
        }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.SelectedIndex = -1;
        GridView2.PageIndex = e.NewPageIndex;
        string IsGC = (string)ViewState["ISGC"];
        GetDate_DJ(IsGC);
        
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language='javascript'>window.open(encodeURI('Report/WL_Query.aspx'),'null','toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=0,top=10,left=0,width=650,height=350')</script>");
    }
}