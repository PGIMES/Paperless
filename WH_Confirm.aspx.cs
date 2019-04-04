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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Data.OleDb;

public partial class WH_Confirm : System.Web.UI.Page
{
    decimal heji = 0;
    Car Car = new Car();
    Function_Admin Function_Admin = new Function_Admin();
    protected void Page_Load(object sender, EventArgs e)
    {
       // if (Session["UserLoginName"].ToString() == null)
        if (Session["UserLoginName"] == null)
        {
            Response.Redirect("~/Source1/Login.aspx");
            Response.End();


            return;
        }
     
        string uid = Session["UserLoginName"].ToString();
        DataTable dt = new DataTable();
        //dt = Function_Admin.User_Login(2, Session["UserLoginName"].ToString(), "", "仓库");
        //if (dt.Rows.Count<=0)
        //{
        //    Response.Write("<script>javascript:alert('您没仓库确认的权限')</script>");

        //    return;
        //}
        if (!Page.IsPostBack)
        {
            //txtly_date3.Text = DateTime.Now.ToString("MM/dd/yyyy");
            //txtly_date4.Text = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
            DataTable dtcomp = Function_Admin.User_Login(6, uid, "", "");
            Function_Admin.initDrop(DropDownList5, dtcomp, "comp");

            DataTable dtcode = new DataTable();
            dtcode = Car.usp_llr_Confirm(9, "", "");
            ddl_code.DataSource = dtcode;
            ddl_code.DataTextField = "describ";
            ddl_code.DataValueField = "describ";
            ddl_code.DataBind();
            ddl_code.Items.Insert(0, new ListItem("", ""));
            GetData();
            DisplayGrid();
          

        }
        
        
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string tldh = "";
        int lnindex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        tldh = GridView1.Rows[lnindex].Cells[1].Text.ToString();



       // Response.Write("<script>window.open('User_Confirm/Confirm_WH.aspx?tldh=" + tldh + "','_blank','height=230,width=300,scrollbars=no')</script>");
        Response.Write("<script language=javascript>alert('确认退料成功！')</script>");
        Car.usp_llr_close(3, tldh, Session["UserLoginName"].ToString());
        GetData();

    }
    protected void Button5_Click(object sender, EventArgs e)
    {

        //DataTable dt = new DataTable();
        //dt = Function_Admin.User_Login(2, Session["UserLoginName"].ToString(), "", "仓库");
        //if (dt.Rows.Count<=0)
        //{
        //    //Response.Write("<script>javascript:alert('您没仓库确认的权限')</script>");

        //    return;
        //}
        
        DisplayGrid();
        GetData();
       
    }
    public void GetData()
    {
        string part = "";
        string gdh = "";
        if (txt_gdh.Text != "")
        {
            gdh =txt_gdh.Text.ToString();
        }

        if (txt_wlbm.Text != "")
        {
            part = txt_wlbm.Text.ToString();
        }
        DataTable dt = new DataTable();
        dt = Car.WH_Confirm(1, gdh, part, txt_cpmc.Text, txt_wlxh.Text, DropDownList5.SelectedValue, txt_llr.Text, txtly_date3.Text, txtly_date4.Text, DropDownList6.SelectedValue,DropDownList7.SelectedValue,txt_lydh.Text,txt_tldh.Text,ddl_code.SelectedValue);
        Getsum(dt);
        if (DropDownList6.SelectedValue == "1")
        {
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        else
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
            //int indexID = this.GridView1.PageIndex * this.GridView1.PageSize + e.Row.RowIndex + 1;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                    
                if (DropDownList6.SelectedValue == "2")
                {
                    ((Button)(e.Row.FindControl("Button3"))).Visible = true;
                   // ((Button)(e.Row.FindControl("btn_type"))).Visible = false;


                }

                    if (DropDownList6.SelectedValue == "3")
                    {
                        ((Button)(e.Row.FindControl("Button3"))).Visible = false;
                        //((Button)(e.Row.FindControl("btn_type"))).Visible = false;
                        

                    }
                    else if (DropDownList6.SelectedValue == "0")
                    {
                        ((Button)(e.Row.FindControl("Button3"))).Visible = false;
                        ((Button)(e.Row.FindControl("Button6"))).Visible = true;
                        //((Button)(e.Row.FindControl("btn_type"))).Visible = false;

                    }
                  


            }
                
            
        }



       

        
       
   
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string lldh = "";
        string gh = "";
        int lnindex = ((GridViewRow)((ImageButton)sender).NamingContainer).RowIndex;
        lldh = GridView1.Rows[lnindex].Cells[12].Text.ToString();
        TextBox txt_gh = (TextBox)GridView1.Rows[lnindex].FindControl("txt_gh");
        gh = txt_gh.Text.ToString();
        if (gh == "")
        {
            Response.Write("<script language=javascript>alert('操作人工号必填！')</script>");
            return;
        }
       int i=  Car.usp_whqr_maint(1, lldh,gh);
       ((TextBox)GridView1.Rows[lnindex].FindControl("txt_gh")).Enabled = false;
       ((ImageButton)GridView1.Rows[lnindex].FindControl("ImageButton1")).Visible = false;

    }
    protected void DisplayGrid()
    {
         if (DropDownList6.SelectedValue == "0")
            {
                GridView2.Visible = false;
                GridView1.Visible = true;
                (GridView1).Columns[0].Visible = true;
                (GridView1).Columns[1].Visible = false;
                (GridView1).Columns[24].Visible = false;
                (GridView1).Columns[10].Visible = true;
                (GridView1).Columns[9].HeaderText = "申请数量";
                (GridView1).Columns[10].HeaderText = "申请人";
                (GridView1).Columns[11].HeaderText = "申请日期";
                (GridView1).Columns[12].Visible = false;
                (GridView1).Columns[13].Visible = false;
                (GridView1).Columns[22].Visible = true;
                (GridView1).Columns[22].HeaderText = "操作";
                (GridView1).Columns[25].Visible = false;


            }
            else if (DropDownList6.SelectedValue == "1")
            {

                //(GridView1).Columns[0].Visible = true;
                //(GridView1).Columns[1].Visible = false;
                //(GridView1).Columns[22].Visible = true;
                //(GridView1).Columns[10].Visible = false;
                //(GridView1).Columns[22].HeaderText = "QAD<br>操作人工号";
                //(GridView1).Columns[9].HeaderText = "申请数量";
                //(GridView1).Columns[10].HeaderText = "申请人";
                //(GridView1).Columns[11].HeaderText = "申请日期";
                //(GridView1).Columns[12].Visible = true;
                //(GridView1).Columns[13].Visible = true;
                //(GridView1).Columns[25].Visible = true;
                //(GridView1).Columns[24].Visible = true;
                GridView2.Visible = true;
                GridView1.Visible = false;
       
           
             }
            else if (DropDownList6.SelectedValue == "2")
             {
                 GridView2.Visible = false;
                 GridView1.Visible = true;
                 (GridView1).Columns[0].Visible = true;
                 (GridView1).Columns[1].Visible = true;
                 (GridView1).Columns[22].HeaderText = "操作";
                 (GridView1).Columns[22].Visible = true;
                 (GridView1).Columns[8].Visible = true;
                 (GridView1).Columns[10].Visible = false;
                 (GridView1).Columns[9].HeaderText = "退料<br>数量";
                 (GridView1).Columns[10].HeaderText = "退料人";
                 (GridView1).Columns[11].HeaderText = "退料日期";
                 (GridView1).Columns[12].Visible = true;
                 (GridView1).Columns[13].Visible = true;
                 (GridView1).Columns[18].Visible = true;
                 (GridView1).Columns[25].Visible = false;
                 (GridView1).Columns[24].Visible = true;
             }
              else
                {
                    GridView2.Visible = false;
                    GridView1.Visible = true;
                    (GridView1).Columns[1].Visible = true;
                    (GridView1).Columns[0].Visible = true;
                    (GridView1).Columns[22].HeaderText = "操作";
                    (GridView1).Columns[9].HeaderText = "退料<br>数量";
                    (GridView1).Columns[10].HeaderText = "退料人";
                    (GridView1).Columns[11].HeaderText = "退料日期";
                    (GridView1).Columns[22].Visible = false;
                    (GridView1).Columns[12].Visible = true;
                    (GridView1).Columns[13].Visible = true;
                    (GridView1).Columns[25].Visible = false;
                    (GridView1).Columns[24].Visible = true;
                    
                }

            
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.SelectedIndex = -1;
        GridView1.PageIndex = e.NewPageIndex;
        DisplayGrid();
        GetData();
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        int index = ((GridViewRow)(chk.NamingContainer)).RowIndex;
        string lldh =GridView2.Rows[index].Cells[1].Text.Trim();   

        if (chk.Checked)
        {
            chk.Enabled = false;
            Car.usp_llr_close(6, lldh, Session["UserLoginName"].ToString());
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        string lldh = "";
        int lnindex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        lldh = GridView1.Rows[lnindex].Cells[0].Text.ToString();
         Response.Write("<script>window.open('User_Confirm/Confirm_WH.aspx?lldh=" + lldh + "','_blank','height=230,width=300,scrollbars=no')</script>");
        GetData();
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
                e.Row.Cells[8].Text = "合计:";
                e.Row.Cells[9].Text = this.heji.ToString();
        }
    }

    private void Getsum(DataTable ldt)
    {
        for (int i = 0; i <= ldt.Rows.Count-1; i++)
        {
            if (ldt.Rows[i]["quantity"].ToString() != "")
            {
                this.heji += Convert.ToDecimal(ldt.Rows[i]["quantity"].ToString());
            }


        }
    }
    protected void btn_type_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int index = ((GridViewRow)(btn.NamingContainer)).RowIndex;
        string lldh = GridView2.Rows[index].Cells[1].Text.Trim();

        btn.Enabled = false;
        Car.usp_llr_close(8, lldh, Session["UserLoginName"].ToString());
        DisplayGrid();
        GetData();
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        string part = "";
        string gdh = "";
        if (txt_gdh.Text != "")
        {
            gdh = txt_gdh.Text.ToString();
        }

        if (txt_wlbm.Text != "")
        {
            part = txt_wlbm.Text.ToString();
        }
        DataTable dt = new DataTable();
        dt = Car.WH_Confirm_export(1, gdh, part, txt_cpmc.Text, txt_wlxh.Text, DropDownList5.SelectedValue, txt_llr.Text, txtly_date3.Text, txtly_date4.Text, DropDownList6.SelectedValue, DropDownList7.SelectedValue, txt_lydh.Text, txt_tldh.Text, ddl_code.SelectedValue);

        if (DropDownList6.SelectedValue == "1")
        {
            string fileName = DropDownList6.SelectedItem.Text + ".xls";
            //获取Execl文件所在路径
            string excelName = Server.MapPath(fileName);
            //通过模板复制一个Execl文件
            File.Copy(Server.MapPath("刀具领用记录.xlsx"), excelName, true);
            //创建连接Execl文件字符串
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelName + ";Extended Properties='Excel 12.0;'";
            OleDbConnection con = new OleDbConnection(strConn);
            con.Open();

            //通过遍历将表中信息添加到Excel文件中
           foreach (DataRow dr in dt.Rows)
            {
                string strInsert = "insert into [Sheet3$] values('" + dr[0] + "','" + dr[1] + "','" + dr[2] + "','" + dr[3] + "','" + dr[4] + "','" + dr[5] + "','" + dr[6] + "','" + dr[7] + "','" + dr[8] + "','" + dr[9] + "','" + dr[10] + "','" + dr[11] + "','" + dr[12] + "','" + dr[13] + "')";
                OleDbCommand cmd = new OleDbCommand(strInsert, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            System.IO.FileStream Reader = System.IO.File.OpenRead(excelName);
            //文件传送的剩余字节数：初始值为文件的总大小
            long Length = Reader.Length;
            Response.Buffer = false;
            Response.AddHeader("Connection", "Keep-Alive");
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(fileName));
            Response.AddHeader("Content-Length", Length.ToString());
            //存放欲发送数据的缓冲区
            byte[] Buffer = new Byte[10000];
            //每次实际读取的字节数
            int ByteToRead;
            while (Length > 0)
            {
                //剩余字节数不为零，继续传送
                if (Response.IsClientConnected)
                {
                    //客户端浏览器还打开着，继续传送
                    //往缓冲区读入数据
                    ByteToRead = Reader.Read(Buffer, 0, 10000);
                    //把缓冲区的数据写入客户端浏览器
                    Response.OutputStream.Write(Buffer, 0, ByteToRead);
                    //立即写入客户端
                    Response.Flush();
                    //剩余字节数减少
                    Length -= ByteToRead;
                }
                else
                {
                    //客户端浏览器已经断开，阻止继续循环
                    Length = -1;
                }
            }
            //关闭该文件
            Reader.Close();
            //删除该Excel文件
            File.Delete(excelName);
        }
        else
        {
            DataTableToExcel(dt, "xls", DropDownList6.SelectedItem.Text, "1");
        }
    }

 

    public void DataTableToExcel(DataTable dt, string FileType, string FileName, string b_head)
    {
        System.Web.HttpContext.Current.Response.Clear();
        System.Web.HttpContext.Current.Response.Charset = "UTF-8";
        System.Web.HttpContext.Current.Response.Buffer = true;
        System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls\"");
        System.Web.HttpContext.Current.Response.ContentType = FileType;
        string colHeaders = string.Empty;



        string ls_item = string.Empty;
        DataRow[] myRow = dt.Select();
        int i = 0;
        int cl = dt.Columns.Count;
        if (b_head == "1")
        {
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                ls_item += dt.Columns[j].ColumnName + "\t";
            }
        }
        ls_item += "\n";
        foreach (DataRow row in myRow)
        {
            for (i = 0; i < cl; i++)
            {
                if (i == (cl - 1))
                {
                    ls_item += row[i].ToString() + "\n";
                }
                else
                {
                    ls_item += row[i].ToString() + "\t";
                }
            }
            System.Web.HttpContext.Current.Response.Output.Write(ls_item);
            ls_item = string.Empty;
        }

        System.Web.HttpContext.Current.Response.Output.Flush();
        System.Web.HttpContext.Current.Response.End();
    }
    protected void ck_by_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        int index = ((GridViewRow)(chk.NamingContainer)).RowIndex;
        string lldh = GridView2.Rows[index].Cells[1].Text.Trim();

        if (chk.Checked)
        {
            chk.Enabled = false;
            Car.usp_llr_close(9, lldh, Session["UserLoginName"].ToString());
        }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.SelectedIndex = -1;
        GridView2.PageIndex = e.NewPageIndex;
        DisplayGrid();
        GetData();
    }
    protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[8].Text = "合计:";
            e.Row.Cells[9].Text = this.heji.ToString();
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            if (DropDownList6.SelectedValue == "1")
            {
                string part = e.Row.Cells[4].Text.Substring(0, 5).ToString();
                DataTable dt = new DataTable();
                if (((TextBox)(e.Row.FindControl("txt_gh"))).Text == "")
                {
                    ((TextBox)(e.Row.FindControl("txt_gh"))).Visible = false;
                }
                else
                {
                    ((TextBox)(e.Row.FindControl("txt_gh"))).Visible = true;
                }
                ((TextBox)(e.Row.FindControl("txt_gh"))).Enabled = false;
                ((CheckBox)(e.Row.FindControl("CheckBox1"))).Visible = true;
                ((CheckBox)(e.Row.FindControl("ck_by"))).Visible = false;


                CheckBox CK = e.Row.Cells[0].FindControl("checkbox1") as CheckBox;
                CheckBox byzt = e.Row.Cells[25].FindControl("ck_by") as CheckBox;
                Button btn = e.Row.Cells[25].FindControl("btn_type") as Button;

                string isok = e.Row.Cells[24].Text.ToString();
                string byvalue = e.Row.Cells[26].Text.ToString();
                DateTime dtime = Convert.ToDateTime(e.Row.Cells[20].Text.ToString());
                DateTime dtnow = System.DateTime.Now;
                TimeSpan timediff = dtnow - dtime;
                double time = timediff.TotalMinutes;
                string type = e.Row.Cells[18].Text.ToString().Replace("&nbsp;", "");
                if (isok == "N" || isok == "")
                {
                    CK.Enabled = true;

                }
                else
                {
                    CK.Enabled = false;
                    CK.Checked = true;
                }
                if (byvalue == "Y")
                {
                    byzt.Checked = true;
                    byzt.Enabled = false;
                }
                else
                {
                    byzt.Enabled = true;
                }

                if (type == "以旧换新")
                {
                    byzt.Visible = true;
                    if (((TextBox)(e.Row.FindControl("txt_qrly"))).Text == "Y")
                    {
                        ((Button)(e.Row.FindControl("btn_type"))).Text = "已归还";
                        ((Button)(e.Row.FindControl("btn_type"))).Visible = true;
                        ((Button)(e.Row.FindControl("btn_type"))).Enabled = false;
                    }
                    else if (((TextBox)(e.Row.FindControl("txt_qrly"))).Text == "Yellow")
                    {
                        ((Button)(e.Row.FindControl("btn_type"))).Text = "已归还";
                        ((Button)(e.Row.FindControl("btn_type"))).Visible = true;
                        ((Button)(e.Row.FindControl("btn_type"))).Enabled = false;
                        btn.BackColor = System.Drawing.Color.Yellow;
                    }
                    else
                    {
                        ((Button)(e.Row.FindControl("btn_type"))).Text = "归还";
                        ((Button)(e.Row.FindControl("btn_type"))).Visible = true;
                        ((Button)(e.Row.FindControl("btn_type"))).Enabled = true;
                        if (time > 30)
                        {
                            btn.BackColor = System.Drawing.Color.Red;
                        }
                    }
                }
                else
                {

                    ((Button)(e.Row.FindControl("btn_type"))).Visible = false;
                    if (type == "新刀领用" || part.ToUpper() == "Z0106")
                    {
                        byzt.Visible = true;
                    }
                }
            }
        }
                       
                      
                         
    }
}