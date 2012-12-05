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
    private string connstr;
	public Data()
	{
        connstr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString.ToString();
	}

    public DataSet ReadDB(string cmd, string tablename)
    {
        using (SqlConnection Conn = new SqlConnection(connstr))
        {
            string a = Conn.State.ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd, Conn);
            da.Fill(ds, tablename);
            return ds;
            
        }
    }

    
}