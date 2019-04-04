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
///Car 的摘要说明
/// </summary>
public class Car
{
	
    SQLHelper SQLHelper = new SQLHelper();
    public DataTable MyCar(int flag, string part,string desc1,string desc2,string gxh,string zjbm,string uid,int num,string unit,string comp,int sftnum)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@part",part),
            new SqlParameter("@desc1",desc1),
            new SqlParameter("@desc2",desc2),
            new SqlParameter("@gxh",gxh),
            new SqlParameter("@zjbm",zjbm),
            new SqlParameter("@uid",uid),
            new SqlParameter("@num",num),
            new SqlParameter("@unit",unit),
            new SqlParameter("@comp",comp),
            new SqlParameter("@sftnum",sftnum)
          
           
        };
        return SQLHelper.GetDataTable("usp_mycar", param);
    }
    public DataTable MyCar_Query(int flag, string part, string desc1, string desc2, string gxh, string zjbm, string uid, int num, string unit, string comp, int sftnum,string lx)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@part",part),
            new SqlParameter("@desc1",desc1),
            new SqlParameter("@desc2",desc2),
            new SqlParameter("@gxh",gxh),
            new SqlParameter("@zjbm",zjbm),
            new SqlParameter("@uid",uid),
            new SqlParameter("@num",num),
            new SqlParameter("@unit",unit),
            new SqlParameter("@comp",comp),
            new SqlParameter("@sftnum",sftnum),
            new SqlParameter("@lx",lx)
          
           
        };
        return SQLHelper.GetDataTable("usp_Mycar_Query", param);
    }

    public int update_llcnum(int flag, string group_part, string part, string desc1, string desc2,string ljh, string gxh, string zjbm, string uid, int num, string unit, string comp, int sftnum, string xmh, string type, string position, string bb)
    {

        SqlParameter[] param = new SqlParameter[]
           {
            new SqlParameter("@flag",flag),
            new SqlParameter("@group_part",group_part),
            new SqlParameter("@part",part),
            new SqlParameter("@desc1",desc1),
            new SqlParameter("@desc2",desc2),
            new SqlParameter("@ljh",ljh),
            new SqlParameter("@gxh",gxh),
            new SqlParameter("@zjbm",zjbm),
            new SqlParameter("@uid",uid),
            new SqlParameter("@num",num),
            new SqlParameter("@unit",unit),
            new SqlParameter("@comp",comp),
            new SqlParameter("@sftnum",sftnum),
            new SqlParameter("@xmh",xmh),
            new SqlParameter("@type",type),
            new SqlParameter("@position",position),
            new SqlParameter("@bb",bb)
            

           };
        //string strsql = "update Paperless_Mycar set quantity=quantity-1 where part='" + part + "' and create_uid='"+create_uid+"'";
        return SQLHelper.ExecuteNonQuery("usp_mycar", param);
    }

    public int MyCar_Record(int flag,string group_part, string part, string desc1, string desc2,string unit,string position,string type,int quantity, string comp,string version,string dlr,
        string xmh,int sftnum,string ljh,string gxh, string gdh,  string create_uid,string yjlydate,string code,string loc,string remark,string selxmh,string yfcode,string status)
    {

        SqlParameter[] param = new SqlParameter[]
           {
               new SqlParameter("@flag",flag),
               new SqlParameter("@group_part",group_part),
               new SqlParameter("@part",part),
               new SqlParameter("@desc1",desc1),
               new SqlParameter("@desc2",desc2),
               new SqlParameter("@unit",unit),
               new SqlParameter("@position",position),
               new SqlParameter("@type",type),
               new SqlParameter("@quantity",quantity),
               new SqlParameter("@comp",comp),
               new SqlParameter("@version",version),
               new SqlParameter("@dlr",dlr),
               new SqlParameter("@xmh",xmh),
               new SqlParameter("@sftnum",sftnum),
               new SqlParameter("@ljh",ljh),
               new SqlParameter("@gxh",gxh),
               new SqlParameter("@gdh",gdh),
               new SqlParameter("@uid",create_uid),
               new SqlParameter("@yjlydate",yjlydate),
               new SqlParameter("@code",code),
               new SqlParameter("@loc",loc),
               new SqlParameter("@ly_remark",remark),
               new SqlParameter("@selxmh",selxmh),
               new SqlParameter("@yfcode",yfcode),
               new SqlParameter("@status",status)

           };
        //string strsql = "update Paperless_Mycar set quantity=quantity-1 where part='" + part + "' and create_uid='"+create_uid+"'";
        return SQLHelper.ExecuteNonQuery("usp_MyCar_Record", param);
    }
    public int MyCar_Insert(int flag, string group_part, string part, string desc1, string desc2, string ljh, string gxh, string zjbm, string unit, int num, string uid, string comp, int sftnum, string xmh, string type, string position, string bb)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@group_part",group_part),
            new SqlParameter("@part",part),
            new SqlParameter("@desc1",desc1),
            new SqlParameter("@desc2",desc2),
            new SqlParameter("@ljh",ljh),
            new SqlParameter("@gxh",gxh),
            new SqlParameter("@zjbm",zjbm),
            new SqlParameter("@unit",unit),
            new SqlParameter("@num",num),
            new SqlParameter("@uid",uid),
            new SqlParameter("@comp",comp),
            new SqlParameter("@sftnum",sftnum),
            new SqlParameter("@xmh",xmh),
            new SqlParameter("@type",type),
            new SqlParameter("@position",position),
            new SqlParameter("@bb",bb)
           
            
           
        };
        return SQLHelper.ExecuteNonQuery("usp_mycar", param);
    }
    public int ADD_TOCar(int flag, string group_part, string part, string desc1, string desc2, string ljh, string gxh, string zjbm, string unit, int num, string uid, string comp, int sftnum, string xmh, string type, string position, string bb,string yjlydate,decimal currentkc,string loc,string yfxm,string status,string typeid)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@group_part",group_part),
            new SqlParameter("@part",part),
            new SqlParameter("@desc1",desc1),
            new SqlParameter("@desc2",desc2),
            new SqlParameter("@ljh",ljh),
            new SqlParameter("@gxh",gxh),
            new SqlParameter("@zjbm",zjbm),
            new SqlParameter("@unit",unit),
            new SqlParameter("@num",num),
            new SqlParameter("@uid",uid),
            new SqlParameter("@comp",comp),
            new SqlParameter("@sftnum",sftnum),
            new SqlParameter("@xmh",xmh),
            new SqlParameter("@type",type),
            new SqlParameter("@position",position),
            new SqlParameter("@bb",bb),
            new SqlParameter("@yjlydate",yjlydate),
            new SqlParameter("@currentkc",currentkc),
            new SqlParameter("@loc",loc),
            new SqlParameter("@yfxm",yfxm),
            new SqlParameter("@status",status),
             new SqlParameter("@typeid",typeid)
           
            
           
        };
        return SQLHelper.ExecuteNonQuery("usp_Add_ToCar", param);
    }
    public int DJ_Insert(int flag, string part, string desc1, string desc2, string gxh, string zjbm, string unit, int num, string uid, string comp, int sftnum,string xmh)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@part",part),
            new SqlParameter("@desc1",desc1),
            new SqlParameter("@desc2",desc2),
            new SqlParameter("@gxh",gxh),
            new SqlParameter("@zjbm",zjbm),
            new SqlParameter("@unit",unit),
            new SqlParameter("@num",num),
            new SqlParameter("@uid",uid),
            new SqlParameter("@comp",comp),
            new SqlParameter("@sftnum",sftnum),
            new SqlParameter("@xmh",xmh)
           
            
           
        };
        return SQLHelper.ExecuteNonQuery("usp_DJInsert", param);
    }

    public DataTable LL_Confirm(int flag,string groupid, string part, string desc1, string desc2,string comp, string uid, string start1,string start2,string status)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
             new SqlParameter("@groupid",groupid),
            new SqlParameter("@part",part),
            new SqlParameter("@desc1",desc1),
            new SqlParameter("@desc2",desc2),
            new SqlParameter("@comp",comp),
            new SqlParameter("@uid",uid),
            new SqlParameter("@start1",start1),
            new SqlParameter("@start2",start2),
            new SqlParameter("@status",status)
           
        };
        return SQLHelper.GetDataTable("usp_LL_Confirm", param);
    }
    public DataTable TL_Confirm(int flag, string part, string desc1, string desc2, string comp, string uid, string start1, string start2, string status)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@part",part),
            new SqlParameter("@desc1",desc1),
            new SqlParameter("@desc2",desc2),
            new SqlParameter("@comp",comp),
            new SqlParameter("@uid",uid),
            new SqlParameter("@start1",start1),
            new SqlParameter("@start2",start2),
            new SqlParameter("@status",status)
           
        };
        return SQLHelper.GetDataTable("usp_TL_Confirm", param);
    }
    public DataTable WH_Confirm(int flag, string gdh,string part, string desc1, string desc2, string comp, string uid, string start1, string start2, string status,string boolqad,string lydh,string tldh,string code)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@gdh",gdh),
            new SqlParameter("@part",part),
            new SqlParameter("@desc1",desc1),
            new SqlParameter("@desc2",desc2),
            new SqlParameter("@comp",comp),
            new SqlParameter("@uid",uid),
            new SqlParameter("@start1",start1),
            new SqlParameter("@start2",start2),
            new SqlParameter("@status",status),
            new SqlParameter("@boolqad",boolqad),
            new SqlParameter("@lydh",lydh),
            new SqlParameter("@tldh",tldh),
             new SqlParameter("@code",code)
           
        };
        return SQLHelper.GetDataTable("usp_WH_Confirm", param);
    }



    public DataTable WH_Confirm_export(int flag, string gdh, string part, string desc1, string desc2, string comp, string uid, string start1, string start2, string status, string boolqad, string lydh, string tldh,string code)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@gdh",gdh),
            new SqlParameter("@part",part),
            new SqlParameter("@desc1",desc1),
            new SqlParameter("@desc2",desc2),
            new SqlParameter("@comp",comp),
            new SqlParameter("@uid",uid),
            new SqlParameter("@start1",start1),
            new SqlParameter("@start2",start2),
            new SqlParameter("@status",status),
            new SqlParameter("@boolqad",boolqad),
            new SqlParameter("@lydh",lydh),
            new SqlParameter("@tldh",tldh),
            new SqlParameter("@code",code)
           
        };
        return SQLHelper.GetDataTable("usp_WH_Confirm_export", param);
    }


    public int  usp_llr_close(int flag,string lldh,string uid)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@llda",lldh),
            new SqlParameter("@uid",uid)
          
           
            
           
        };
        return SQLHelper.ExecuteNonQuery("usp_llr_close", param);
    }
    public DataTable usp_llr_Confirm(int flag, string lldh,string uid)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@llda",lldh),
            new SqlParameter("@uid",uid)
          
           
            
           
        };
        return SQLHelper.GetDataTable("usp_llr_close", param);
    }
    public DataTable TL_Query(int flag, string part, string desc1, string desc2, string comp, string uid, string start1, string start2)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@part",part),
            new SqlParameter("@desc1",desc1),
            new SqlParameter("@desc2",desc2),
            new SqlParameter("@comp",comp),
            new SqlParameter("@uid",uid),
            new SqlParameter("@start1",start1),
            new SqlParameter("@start2",start2)
           
           
        };
        return SQLHelper.GetDataTable("usp_TL_Query", param);
    }

    public int TL_Input(int flag,string llda, int num, string uid)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@llda",llda),
            new SqlParameter("@num",num),
             new SqlParameter("@tlr",uid)
     
           
        };
        return SQLHelper.ExecuteNonQuery("usp_TL_Input", param);
    }
    public DataTable TL_IsOK(int flag, string llda, int num, string uid)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@llda",llda),
            new SqlParameter("@num",num),
             new SqlParameter("@tlr",uid)
     
           
        };
        return SQLHelper.GetDataTable("usp_TL_Input", param);
    }
    public DataSet GetYear(string flag)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            
           
        };
        return SQLHelper.GetDataSet("usp_GetYear", param);
    }
    public int usp_whqr_maint(int flag, string lldh, string qrgh)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@llda",lldh),
            new SqlParameter("@qrgh",qrgh)
          
           
            
           
        };
        return SQLHelper.ExecuteNonQuery("usp_whqr_maint", param);
    }
    public DataTable Query_by_date(string year, string date, string comp, string lylx, string lylb, string value,string lyr)
    {
        SqlParameter[] param = new SqlParameter[]
        {
             new SqlParameter("@year",year),
            new SqlParameter("@date",date),
            new SqlParameter("@comp",comp),
             new SqlParameter("@lylx",lylx),
             new SqlParameter("@lylb",lylb),
             new SqlParameter("@value",value),
             new SqlParameter("@lyr",lyr)
     
           
        };
        return SQLHelper.GetDataTable("usp_DJ_Report_1", param);
    }

    public DataTable Query_by_DJdate(string year, string date, string comp, string lylx, string lylb,string value,string llr)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@year",year),
            new SqlParameter("@date",date),
            new SqlParameter("@comp",comp),
             new SqlParameter("@lylx",lylx),
             new SqlParameter("@lylb",lylb),
             new SqlParameter("@value",value),
             new SqlParameter("@llr",llr)
     
           
        };
        return SQLHelper.GetDataTable("usp_Get_ALL_BYDJ", param);
    }
    public DataTable Query_by_DJljh(string year, string date, string comp, string lylx, string lylb, string value, string llr)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@year",year),
            new SqlParameter("@date",date),
            new SqlParameter("@comp",comp),
             new SqlParameter("@lylx",lylx),
             new SqlParameter("@lylb",lylb),
             new SqlParameter("@value",value),
             new SqlParameter("@lyr",llr)
     
           
        };
        return SQLHelper.GetDataTable("usp_DJ_Report_Byljh", param);
    }

    public DataTable Query_by_sbdate(string year, string date, string comp, string lylx, string lylb, string value, string llr)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@year",year),
            new SqlParameter("@date",date),
            new SqlParameter("@comp",comp),
             new SqlParameter("@lylx",lylx),
             new SqlParameter("@lylb",lylb),
             new SqlParameter("@value",value),
             new SqlParameter("@llr",llr)
     
           
        };
        return SQLHelper.GetDataTable("usp_Get_ALL_BYsb", param);
    }

    public DataTable Cal_slcb(int date,string ljh,string value)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@date",date),
            new SqlParameter("@ljh",ljh),
            new SqlParameter("@value",value),
            
     
           
        };
        return SQLHelper.GetDataTable("usp_cal_slcb", param);
    }
    public DataTable Query_by_DJdetaildate(string year, string date, string comp, string lylx, string lylb, string value,string llr)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@year",year),
            new SqlParameter("@date",date),
            new SqlParameter("@comp",comp),
             new SqlParameter("@lylx",lylx),
             new SqlParameter("@lylb",lylb),
             new SqlParameter("@value",value),
             new SqlParameter("@lyr",llr)
     
           
        };
        return SQLHelper.GetDataTable("usp_Get_ALL_BYDJDeatail", param);
    }
    public DataTable GetList_DJ(int flag, string xmh, string group_id, string gxh, string group_ms, string comp, string bb, string part, string djversion)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@xmh",xmh),
            new SqlParameter("@group_id",group_id),
            new SqlParameter("@gxh",gxh),
             new SqlParameter("@group_ms",group_ms),
             new SqlParameter("@comp",comp),
             new SqlParameter("@bb",bb),
             new SqlParameter("@part",part),
              new SqlParameter("@djversion",djversion)
             
             
     
           
        };
        return SQLHelper.GetDataTable("usp_DJList_ReportQuery", param);
    }


    public DataTable usp_Keyin_gdh( string uid, string gdh)
    {
        SqlParameter[] param = new SqlParameter[]
        {
           
             new SqlParameter("@uid",uid),
             new SqlParameter("@gdh",gdh)
             
     
           
        };
        return SQLHelper.GetDataTable("usp_Keyin_gdh", param);
    }

    public DataTable sb_query(int flag, string type, string wlbm,string wlmc,string comp,string ggxh)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@type",type),
            new SqlParameter("@wlbm",wlbm),
            new SqlParameter("@wlmc",wlmc),
            new SqlParameter("@comp",comp),
            new SqlParameter("@ggxh",ggxh),

          
           
            
           
        };
        return SQLHelper.GetDataTable("usp_sb_query", param);
    }
public DataTable sb_carquery(int flag, string type, string wlbm, string wlmc, string comp, string ggxh)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@type",type),
            new SqlParameter("@wlbm",wlbm),
            new SqlParameter("@wlmc",wlmc),
            new SqlParameter("@comp",comp),
            new SqlParameter("@ggxh",ggxh),

          
           
            
           
        };
        return SQLHelper.GetDataTable("usp_sbcar_query", param);
    }
public DataTable MyCar_DylQuery(int flag, string part, string desc1, string desc2, string gxh, string zjbm, string uid, int num, string unit, string comp, int sftnum, string lx)
{
    SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@part",part),
            new SqlParameter("@desc1",desc1),
            new SqlParameter("@desc2",desc2),
            new SqlParameter("@gxh",gxh),
            new SqlParameter("@zjbm",zjbm),
            new SqlParameter("@uid",uid),
            new SqlParameter("@num",num),
            new SqlParameter("@unit",unit),
            new SqlParameter("@comp",comp),
            new SqlParameter("@sftnum",sftnum),
            new SqlParameter("@lx",lx)
          
           
        };
    return SQLHelper.GetDataTable("usp_Mycar_Bydyl_Query", param);
}
}