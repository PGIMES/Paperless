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
using System.Web.UI.DataVisualization.Charting;
using System.Xml;

public partial class Report_Record_Query : System.Web.UI.Page
{
    decimal total1 = 0;
    decimal total1amount = 0;
    decimal total2 = 0;
    decimal total3 = 0;
    decimal total3num = 0;
    decimal total4num = 0;
    Car Car = new Car();
    DJ DJ = new DJ();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //string strsql = "select distinct pl_prod_line,pl_desc from pub.pl_mstr where pl_prod_line between '4010' and '4120'";
        string strsql = "select  pl_prod_line,pl_desc from Paperless_pl_mstr ";
        if (!IsPostBack)
        {
            this.txtyear.DataSource = Car.GetYear("1");
            this.txtyear.DataValueField = "year";
            this.txtyear.DataTextField = "year";
            this.txtyear.DataBind();

            //DataTable dt = ConnectionODBC.GetODBCRows(strsql);
            DataTable dt = SQLHelper.reDs(strsql).Tables[0];
            this.lylx.DataSource = dt;
            this.lylx.DataValueField = "pl_prod_line";
            this.lylx.DataTextField = "pl_desc";
            this.lylx.DataBind();
            this.lylx.Items.Insert(0, new ListItem("ALL", ""));


            DataTable dt1 = new DataTable();
            DataTable dt3=new DataTable();
            string lx = this.lylx.SelectedItem.Value;
            dt1 = Car.Query_by_date(this.txtyear.Text, this.txttype.Text, this.txtfactory.SelectedItem.Value, "", "", "",txtllr.Text);
            GetSum1(dt1);
            this.SetMap(dt1);
            gv1.DataSource = dt1;
            gv1.DataBind();
            
            
             DataTable dt2 = null;
             if (dt1.Rows.Count > 0)
             {
                 string value = dt1.Rows[0]["date"].ToString();
                 //dt2 = Car.Query_by_DJljh(this.txtyear.Text, this.txttype.Text, this.txtfactory.SelectedItem.Value, "", "", value, txtllr.Text);
                 //GetSum2(dt2);
                 //gv2.DataSource = dt2;
                 //gv2.DataBind();


                 dt3 = Car.Query_by_DJdetaildate(this.txtyear.Text, this.txttype.Text, this.txtfactory.SelectedItem.Value, this.lylx.Text, "", value, txtllr.Text);
                 this.GetSum3(dt3);
                 gv3.DataSource = dt3;
                 gv3.DataBind();
                 this.gv1.Rows[0].BackColor = System.Drawing.Color.Yellow;
                 this.Div2.Style.Add("display", "none");
                 this.Div1.Style.Add("display", "none");
             }

           
           
            
        }


    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (this.lylx.SelectedItem.Text == "辅料-机床备件类")
        {
            this.Div4.Style.Add("display", "block");
            this.Div1.Style.Add("display", "none");
            this.Div7.Style.Add("display", "block");
            this.Div2.Style.Add("display", "block");
        }
        else if (this.lylx.SelectedItem.Text == "辅料-刀具类")
        {
            this.Div4.Style.Add("display", "block");
            this.Div1.Style.Add("display", "block");
            this.Div7.Style.Add("display", "block");
            this.Div2.Style.Add("display", "none");
        }
        else
        {
            this.Div4.Style.Add("display", "block");
            this.Div1.Style.Add("display", "none");
            this.Div7.Style.Add("display", "block");
            this.Div2.Style.Add("display", "none");
        }
        DataTable dt1 = new DataTable();
        dt1 = Car.Query_by_date(this.txtyear.Text, this.txttype.Text, this.txtfactory.SelectedItem.Value, this.lylx.Text, "", "", txtllr.Text);
        GetSum1(dt1);
        this.SetMap(dt1);
        gv1.DataSource = dt1;
        gv1.DataBind();
       
     
        DataTable dt2 = null;
        int flag=int.Parse(txttype.SelectedValue);
        if (dt1.Rows.Count > 0)
        {
            this.gv1.Rows[0].BackColor = System.Drawing.Color.Yellow;
            string value = dt1.Rows[0]["date"].ToString();
            if (this.lylx.SelectedItem.Text != "辅料-机床备件类")
            {
                dt2 = Car.Query_by_DJljh(this.txtyear.Text, this.txttype.Text, this.txtfactory.SelectedItem.Value, this.lylx.Text, "", value, this.txtllr.Text);
                dt2.Columns.Add("scsl", Type.GetType("System.Decimal"));
                dt2.Columns.Add("djcb", Type.GetType("System.Decimal"));
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    string ljh = dt2.Rows[i]["LJH"].ToString();
                   DataTable newtable= Car.Cal_slcb(flag, ljh, value);
                   if (newtable ==null || newtable.Rows.Count<=0 || newtable.Rows[0][0].ToString()=="")
                   {
                       dt2.Rows[i]["scsl"] = 0;
                       dt2.Rows[i]["djcb"] = 0;
                   }
                   else
                   {
                       dt2.Rows[i]["scsl"] = newtable.Rows[0]["num"];
                       if (dt2.Rows[i]["scsl"].ToString() == "0.00")
                       {
                           dt2.Rows[i]["djcb"] = 0;
                       }
                       else
                       {
                           dt2.Rows[i]["djcb"] = Math.Round(Convert.ToDecimal(dt2.Rows[i]["totalamount"]) / Convert.ToDecimal(dt2.Rows[i]["scsl"]), 4);
                       }
                   }
                }


               GetSum2(dt2);
                gv2.DataSource = dt2;
                gv2.DataBind();
                
            }
            else
            {
                DataTable dtt = Car.Query_by_sbdate(this.txtyear.Text, this.txttype.Text, this.txtfactory.SelectedItem.Value, this.lylx.Text, "", value, this.txtllr.Text);
                GetSum4(dtt);
                gv6.DataSource = dtt;
                gv6.DataBind();
                

            }

            DataTable dt3 = null;
            dt3 = Car.Query_by_DJdetaildate(this.txtyear.Text, this.txttype.Text, "", this.lylx.Text, "", value, txtllr.Text);
            GetSum3(dt3);
            gv3.DataSource = dt3;
            gv3.DataBind();
            //(gv3).Columns[0].Visible = false;
        }
        else
        {
            gv3.DataSource = null;
            gv3.DataBind();
            gv2.DataSource = null;
            gv2.DataBind();
            gv6.DataSource = null;
            gv6.DataBind();

        }
       // gv6.Visible = true;
       //// gv2.Visible = false;
       // this.Div5.Style.Add("display", "none");
       // this.Div5.Style.Add("display", "none");
       

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int lnindex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
        DataTable dt1 = new DataTable();
        dt1 = Car.Query_by_date(this.txtyear.Text, this.txttype.Text, this.txtfactory.Text, this.lylx.Text,"","", this.txtllr.Text.ToString());
       
        this.SetMap(dt1);
        int flag=int.Parse(txttype.SelectedValue);
        string value = dt1.Rows[0]["date"].ToString();
        if (this.lylx.SelectedItem.Text == "辅料-刀具类")
        {
            DataTable dt2 = Car.Query_by_DJljh(this.txtyear.Text, this.txttype.Text, this.txtfactory.SelectedItem.Value, this.lylx.Text, "", ((LinkButton)sender).Text, this.txtllr.Text);
            dt2.Columns.Add("scsl", Type.GetType("System.Decimal"));
            dt2.Columns.Add("djcb", Type.GetType("System.Decimal"));
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                string ljh = dt2.Rows[i]["LJH"].ToString();
                DataTable newtable = Car.Cal_slcb(flag, ljh, value);
                if (newtable == null || newtable.Rows.Count <= 0 || newtable.Rows[0][0].ToString() == "")
                {
                    dt2.Rows[i]["scsl"] = 0;
                    dt2.Rows[i]["djcb"] = 0;
                }
                else
                {
                    dt2.Rows[i]["scsl"] = newtable.Rows[0]["num"];
                    dt2.Rows[i]["djcb"] = Math.Round(Convert.ToDecimal(dt2.Rows[i]["totalamount"]) / Convert.ToDecimal(dt2.Rows[i]["scsl"]), 4);
                }
            }


            GetSum2(dt2);
            gv2.DataSource = dt2;
            gv2.DataBind();
        }


        DataTable dt3 = Car.Query_by_DJdetaildate(this.txtyear.Text, this.txttype.Text, this.txtfactory.Text, this.lylx.Text, "", ((LinkButton)sender).Text, txtllr.Text);
       this.GetSum3(dt3);
       this.gv3.DataSource = dt3;
       this.gv3.DataBind();
       DataTable dtt = Car.Query_by_sbdate(this.txtyear.Text, this.txttype.Text, this.txtfactory.SelectedItem.Value, this.lylx.Text, "", ((LinkButton)sender).Text, this.txtllr.Text);
       GetSum4(dtt);
       gv6.DataSource = dtt;
       gv6.DataBind();
        this.gv1.Rows[lnindex].BackColor = System.Drawing.Color.Yellow;
        for (int i = 0; i < this.gv1.Rows.Count; i++)
        {
            if (i != lnindex)
            {
                this.gv1.Rows[i].BackColor = System.Drawing.Color.FromName("#ffffff");

            }
        }
        this.GetSum1(dt1);
        this.gv1.DataSource = dt1;
        this.gv1.DataBind();
        this.gv1.Rows[lnindex].BackColor = System.Drawing.Color.Yellow;
        SetMap(dt1);
        
    }
    private void SetMap(DataTable dt)
    {
      
        DataTable dt2 = new DataTable();
        if (dt.Rows.Count > 0)
        {
            DataView ldv = dt.DefaultView;
            ldv.Sort = "date desc";
            dt2 = ldv.ToTable();
        }
        if (this.txttype.Text == "日")
        {
            this.C1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            this.C1.ChartAreas[0].AxisX.Interval = 2;
            this.C2.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            this.C2.ChartAreas[0].AxisX.Interval = 2;
        }
        else if (this.txttype.Text == "周")
        {
            this.C1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            this.C1.ChartAreas[0].AxisX.Interval = 2;
            this.C2.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            this.C2.ChartAreas[0].AxisX.Interval = 2;
        }
        else
        {
            this.C1.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
            this.C1.ChartAreas[0].AxisX.Interval = 1;
            this.C2.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
            this.C2.ChartAreas[0].AxisX.Interval = 1;

        }
        
        this.C1.Series["Series1"].XValueMember = "date";
        this.C1.Series["Series1"].YValueMembers = "quantity";
        this.C2.Series["Series1"].XValueMember = "date";
        this.C2.Series["Series1"].YValueMembers = "totalamount";
        this.C1.DataSource = dt2;
        this.C1.DataBind();
        this.C2.DataSource = dt2;
        this.C2.DataBind();
        
        
        
    }
    private void GetSum1(DataTable dt)
    {
        
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total1 += Convert.ToDecimal(dt.Rows[i]["quantity"]);
                if (!string.IsNullOrEmpty(dt.Rows[i]["totalamount"].ToString()))
                {
                    total1amount += Convert.ToDecimal(dt.Rows[i]["totalamount"]);
                }
            }
        }
    }
    private void GetSum2(DataTable dt)
    {

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total2 += Convert.ToDecimal(dt.Rows[i]["quantity"]);
            }
        }
    }
    private void GetSum3(DataTable dt)
    {

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(dt.Rows[i]["totalamount"].ToString()))
                {
                    total3 += Convert.ToDecimal(dt.Rows[i]["totalamount"]);
                }
                total3num += Convert.ToDecimal(dt.Rows[i]["quantity"]);
            }
        }
    }

    private void GetSum4(DataTable dt)
    {

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total4num += Convert.ToDecimal(dt.Rows[i]["quantity"]);
            }
        }
    }

    protected void gv1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计";
            e.Row.Cells[1].Text = this.total1.ToString();
            e.Row.Cells[2].Text = this.total1amount.ToString();
        }
    }

    protected void gv2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "合计";
            e.Row.Cells[3].Text = this.total2.ToString();
        }
    }
    protected void gv3_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "合计";
            e.Row.Cells[7].Text = this.total3.ToString();
            e.Row.Cells[3].Text = this.total3num.ToString();
        }
        
    }
    protected void gv6_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "合计";
            e.Row.Cells[2].Text = this.total4num.ToString();
            
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        int lnindex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
        string date = "";
        string position = "";
        for (int i = 0; i < this.gv1.Rows.Count; i++)
        {
            if (this.gv1.Rows[i].BackColor.Name == "Yellow")
            {
                date = ((LinkButton)this.gv1.Rows[i].FindControl("LinkButton1")).Text;


            }
        }
       position= this.gv2.Rows[lnindex].Cells[3].Text;
        DataTable dt3 = Car.Query_by_DJdetaildate(this.txtyear.Text, this.txttype.Text, this.txtfactory.Text, this.lylx.Text, "", date, txtllr.Text);
        DataTable newtable = GetNewTable(dt3, "lycp='" + ((LinkButton)sender).Text + "' and position='" + position + "'");
       this.GetSum3(newtable);
       gv3.DataSource = newtable;
       gv3.DataBind();
       DataTable dt1 = Car.Query_by_date(this.txtyear.Text, this.txttype.Text, this.txtfactory.SelectedItem.Value, this.lylx.Text, "", date, txtllr.Text);
       GetSum1(dt1);
       this.gv1.DataSource = dt1;
       this.gv1.DataBind();
       this.SetMap(dt1);
       DataTable dt2 = Car.Query_by_DJdate(this.txtyear.Text, this.txttype.Text, this.txtfactory.Text, this.lylx.Text, "", date, txtllr.Text);
       this.GetSum2(dt2);
       this.gv2.DataSource = dt2;
       this.gv2.DataBind();
       this.gv2.Rows[lnindex].BackColor = System.Drawing.Color.Yellow;
       for (int i = 0; i < this.gv1.Rows.Count; i++)
       {
           if (((LinkButton)this.gv1.Rows[i].FindControl("LinkButton1")).Text == date)
           {
               this.gv1.Rows[i].BackColor = System.Drawing.Color.Yellow;
           }
       }
    }
    public DataTable GetNewTable(DataTable dt, string filter)
    {
        
        DataTable newTable = dt.Clone();
        DataRow[] drs = dt.Select(filter);
        foreach (DataRow dr in drs)
        {
            object[] arr = dr.ItemArray;
            DataRow newrow = newTable.NewRow();
            for (int i = 0; i < arr.Length; i++)
                newrow[i] = arr[i];
            newTable.Rows.Add(newrow);
        }
        return newTable;
       
    }

    protected void gv1_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression.ToString();           
       
        string sortDirection = "DESC";
        if (sortExpression == this.gv1.Attributes["SortExpression"])         
        {
            sortDirection = (this.gv1.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");
        }

        this.gv1.Attributes["SortExpression"] = sortExpression;
        this.gv1.Attributes["SortDirection"] = sortDirection;          
        //this.BindGridView(); 
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        int lnindex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
        string date = "";
        string lycp = "";
        string position = "";
        for (int i = 0; i < this.gv1.Rows.Count; i++)
        {
            if (this.gv1.Rows[i].BackColor.Name == "Yellow")
            {
                date = ((LinkButton)this.gv1.Rows[i].FindControl("LinkButton1")).Text;


            }
        }
        lycp = ((LinkButton)this.gv2.Rows[lnindex].FindControl("LinkButton2")).Text;
        position = this.gv2.Rows[lnindex].Cells[3].Text;
        DataTable dt3 = Car.Query_by_DJdetaildate(this.txtyear.Text, this.txttype.Text, this.txtfactory.Text, this.lylx.Text, "", date, txtllr.Text);
        DataTable newtable = GetNewTable(dt3, "lycp='" + lycp + "' and position='" + position + "'");
        this.GetSum3(newtable);
        gv3.DataSource = newtable;
        gv3.DataBind();
        DataTable dt1 = Car.Query_by_date(this.txtyear.Text, this.txttype.Text, this.txtfactory.SelectedItem.Value, this.lylx.Text, "", date, txtllr.Text);
        GetSum1(dt1);
        this.gv1.DataSource = dt1;
        this.gv1.DataBind();
        this.SetMap(dt1);
        DataTable dt2 = Car.Query_by_DJdate(this.txtyear.Text, this.txttype.Text, this.txtfactory.Text, this.lylx.Text, "", date, txtllr.Text);
        this.GetSum2(dt2);
        this.gv2.DataSource = dt2;
        this.gv2.DataBind();
        this.gv2.Rows[lnindex].BackColor = System.Drawing.Color.Yellow;
        for (int i = 0; i < this.gv1.Rows.Count; i++)
        {
            if (((LinkButton)this.gv1.Rows[i].FindControl("LinkButton1")).Text == date)
            {
                this.gv1.Rows[i].BackColor = System.Drawing.Color.Yellow;
            }
        }
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        int lnindex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
        string date = "";
        string jqh = "";
        string gdh = "";
        //string position = "";
         DataTable dt1 = Car.Query_by_date(this.txtyear.Text, this.txttype.Text, this.txtfactory.SelectedItem.Value, this.lylx.Text, "", date, txtllr.Text);
        //GetSum1(dt1);
        //this.gv1.DataSource = dt1;
        //this.gv1.DataBind();
        this.SetMap(dt1);
        for (int i = 0; i < this.gv1.Rows.Count; i++)
        {
            if (this.gv1.Rows[i].BackColor.Name == "Yellow")
            {
                date = ((LinkButton)this.gv1.Rows[i].FindControl("LinkButton1")).Text;


            }
        }
        jqh = ((LinkButton)this.gv6.Rows[lnindex].FindControl("LinkButton4")).Text;
       
        //position = this.gv2.Rows[lnindex].Cells[3].Text;
        DataTable GetJQH = DJ.Get_jqh(int.Parse(txttype.SelectedValue), date, jqh);
        for (int i = 0; i < GetJQH.Rows.Count; i++)
        {
            gdh = gdh + GetJQH.Rows[i]["gdh"].ToString() + ",";
        }
        gdh = gdh.Substring(0, gdh.Length - 1).Replace(",", "','");
        DataTable dt3 = Car.Query_by_DJdetaildate(this.txtyear.Text, this.txttype.Text, this.txtfactory.Text, this.lylx.Text, "", date, txtllr.Text);
        DataTable newtable = GetNewTable(dt3, "gdh in ('" + gdh + "') ");
        GetSum3(newtable);
        gv3.DataSource = newtable;
        gv3.DataBind();
       
        DataTable dt2 = Car.Query_by_DJdate(this.txtyear.Text, this.txttype.Text, this.txtfactory.Text, this.lylx.Text, "", date, txtllr.Text);
        this.GetSum2(dt2);
        this.gv2.DataSource = dt2;
        this.gv2.DataBind();
        this.gv6.Rows[lnindex].BackColor = System.Drawing.Color.Yellow;
        DataTable dtt = Car.Query_by_sbdate(this.txtyear.Text, this.txttype.Text, this.txtfactory.SelectedItem.Value, this.lylx.Text, "", date, this.txtllr.Text);
        GetSum4(dtt);
        gv6.DataSource = dtt;
        gv6.DataBind();
        this.gv6.Rows[lnindex].BackColor = System.Drawing.Color.Yellow;
    }
}