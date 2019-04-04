using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
///DJ 的摘要说明
/// </summary>
public class DJ
{

    SQLHelper SQLHelper = new SQLHelper();
    public DataSet DJ_Query(int flag, string groupid, string cpmc, string gxh, string zjbm, string zjgg, string comp, string ljh, string IsGC)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@groupid",groupid),
            new SqlParameter("@cpmc",cpmc),
            new SqlParameter("@gxh",gxh),
            new SqlParameter("@zjbm",zjbm),
            new SqlParameter("@zjgg",zjgg),
            new SqlParameter("@comp",comp),
            new SqlParameter("@ljh",ljh),
            new SqlParameter("@IsGC",IsGC)
           
        };
        return SQLHelper.GetDataSet("usp_DJ_Query_tz", param);
    }

    public DataTable Get_jqh(int flag, string date,string jqh)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@date",date),
            new SqlParameter("@jqh",jqh)
           
           
        };
        return SQLHelper.GetDataTable("usp_jqh_Query", param);
    }
    public DataTable Get_MO_Code(int flag, string uid, string dept,string part)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@flag",flag),
            new SqlParameter("@uid",uid),
            new SqlParameter("@dept",dept),
            new SqlParameter("@part",part)
           
           
        };
        return SQLHelper.GetDataTable("usp_GetMo_CODE_Query_modify", param);
    }
   
}
