using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Data 的摘要说明
/// </summary>
public class Data
{
    SqlConnection Conn = new SqlConnection();

	public Data()
	{
        Conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString.ToString();
	}

    public DataSet ReadDB(string cmd, string tablename)
    {
        using (Conn)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd, Conn);
            da.Fill(ds, tablename);
            return ds;
        }
    }

    #region 过滤字符
    public string FilterStr(string Str)
    {
        Str = Str.Trim();
        Str = Str.Replace("*", "");
        Str = Str.Replace("=", "");
        Str = Str.Replace("/", "");
        Str = Str.Replace("$", "");
        Str = Str.Replace("#", "");
        Str = Str.Replace("@", "");
        Str = Str.Replace("&", "");
        return Str;
    }
    #endregion
}