using System;
using System.Data;
using System.Configuration;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Reflection;
using System.Diagnostics;
using System.Text;

namespace QAD_ODBC
{
    /// <summary>
    /// Pub 的摘要说明
    /// </summary>
    public class Pub
    {
        public static string SQLErrorString;
        public static string ODBCCSRead = "Dsn=mfgprod_read;uid=sysprogress;pwd=sysprogress";

        /// <summary>
        /// 使用ODBC连接查询结果集合返回DataTable
        /// </summary>
        public static System.Data.DataTable GetODBCRows(string sql)
        {
            SQLErrorString = "";
            OdbcConnection _connection = new OdbcConnection(Pub.ODBCCSRead);
            OdbcDataAdapter currDataAdapter = null;
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                currDataAdapter = new OdbcDataAdapter(sql, _connection);
                currDataAdapter.Fill(dt);
                return dt;

            }
            catch (Exception e)
            {
                SQLErrorString = e.Message.ToString();
                return null;
            }
            finally
            {
                currDataAdapter.Dispose();
                _connection.Close();
                _connection = null;
            }
        }

     
       


    }

}
