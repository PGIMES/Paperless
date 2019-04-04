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
using System.IO;

public partial class Report_DJList_Query : System.Web.UI.Page
{
    Car Car = new Car();
    protected void Page_Load(object sender, EventArgs e)
    {
               //if (this.Session.Count <= 0)
        //{

        //    Response.Redirect("~/Source1/Login.aspx");

        //}
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        GetList();
    }
    private void GetList()
    {
        DataTable dt = Car.GetList_DJ(1, this.txt_pgixmh.Text.ToString(), this.txt_group_part.Text.ToString(), this.txt_gxh.Text.ToString(), this.txt_group_ms.Text.ToString(), this.DropDownList5.SelectedValue, this.txt_bb.Text, txt_part.Text, DropVersion.SelectedValue);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        DataTable dt1 = Car.GetList_DJ(2, this.txt_pgixmh.Text.ToString(), this.txt_group_part.Text.ToString(), this.txt_gxh.Text.ToString(), this.txt_group_ms.Text.ToString(), this.DropDownList5.SelectedValue, this.txt_bb.Text, txt_part.Text, DropVersion.SelectedValue);
        GridView2.DataSource = dt1;
        GridView2.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.SelectedIndex = -1;
        GridView1.PageIndex = e.NewPageIndex;
        GetList();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string xmh = "";
        int lnindex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
        xmh = ((LinkButton)this.GridView2.Rows[lnindex].FindControl("LinkButton1")).Text;
        DataTable dt = Car.GetList_DJ(1, xmh, "", "", "", this.DropDownList5.SelectedValue, "", "", DropVersion.SelectedValue);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        DataTable dt1 = Car.GetList_DJ(2, this.txt_pgixmh.Text.ToString(), this.txt_group_part.Text.ToString(), this.txt_gxh.Text.ToString(), this.txt_group_ms.Text.ToString(), this.DropDownList5.SelectedValue, this.txt_bb.Text, this.txt_part.Text, DropVersion.SelectedValue);
        GridView2.DataSource = dt1;
        GridView2.DataBind();
        this.GridView2.Rows[lnindex].BackColor = System.Drawing.Color.Yellow;
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.SelectedIndex = -1;
        GridView2.PageIndex = e.NewPageIndex;
        GetList();

    }
    protected void Button6_Click(object sender, EventArgs e)
    {

        DataTable ldt = Car.GetList_DJ(1, this.txt_pgixmh.Text.ToString(), this.txt_group_part.Text.ToString(), this.txt_gxh.Text.ToString(), this.txt_group_ms.Text.ToString(), this.DropDownList5.SelectedValue, this.txt_bb.Text, txt_part.Text, DropVersion.SelectedValue);


        ldt.Columns["xmh"].ColumnName = "项目号";
        ldt.Columns["bb"].ColumnName = "版本号";
        ldt.Columns["cpcz"].ColumnName = "产品材质";
        ldt.Columns["xzgxh"].ColumnName = "工序号";
        ldt.Columns["gxmc"].ColumnName = "工序名称";
        ldt.Columns["dh"].ColumnName = "刀号";
        ldt.Columns["xzdjgroupbh"].ColumnName = "刀具群组号";
        ldt.Columns["group_pt_desc1"].ColumnName = "刀具群组描述1";
        ldt.Columns["group_pt_desc2"].ColumnName = "刀具群组描述2";
        ldt.Columns["xzdjbh"].ColumnName = "子件编码";
        ldt.Columns["ms1"].ColumnName = "子件编码描述1";
        ldt.Columns["ms2"].ColumnName = "子件编码描述2";
        ldt.Columns["zjsl"].ColumnName = "子件数量";
        ldt.Columns["dc"].ColumnName = "刀长";
        ldt.Columns["aqkc"].ColumnName = "安全库存";
        ldt.Columns["sm"].ColumnName = "寿命";
        ldt.Columns["PP"].ColumnName = "品牌";
        ldt.Columns["VD1"].ColumnName = "厂商";
        ldt.Columns["domain"].ColumnName = "公司";
        ldt.Columns["xmcs"].ColumnName = "修磨次数";
        ldt.Columns["djjs"].ColumnName = "角数";
        ldt.Columns["TD"].ColumnName = "是否替代";
        ldt.Columns["xs"].ColumnName = "系数";
        DtToExcel(ldt, "刀具清单明细.xls");
    }


    public static void DtToExcel(DataTable table, string name)
    {
        try
        {
            MemoryStream ms = ExportDataTableToExcel(table, "sheet1") as MemoryStream;
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(name, System.Text.Encoding.UTF8));
            HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            HttpContext.Current.Response.End();
            ms.Close();
            ms = null;
        }
        catch (Exception ex)
        {

            HttpContext.Current.Response.Write(ex);
        }

    }
    private static Stream ExportDataTableToExcel(DataTable sourceTable, string sheetName)
    {

        NPOI.HSSF.UserModel.HSSFWorkbook workbook = new NPOI.HSSF.UserModel.HSSFWorkbook();
        MemoryStream ms = new MemoryStream();
        NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet(sheetName);
        NPOI.SS.UserModel.IRow headerRow = sheet.CreateRow(0);
        foreach (DataColumn column in sourceTable.Columns)
        {
            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
        }
        int rowIndex = 1;

        foreach (DataRow row in sourceTable.Rows)
        {
            NPOI.SS.UserModel.IRow dataRow = sheet.CreateRow(rowIndex);

            foreach (DataColumn column in sourceTable.Columns)
            {
                dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
            }

            rowIndex++;
        }

        workbook.Write(ms);
        ms.Flush();
        ms.Position = 0;

        sheet = null;
        headerRow = null;
        workbook = null;

        return ms;
    }
}