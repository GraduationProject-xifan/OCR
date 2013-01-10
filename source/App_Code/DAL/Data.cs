using System.Data.SqlClient;
using System.Configuration;
using System.Data;

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

    public SqlDataReader ReadDB(string cmd)
    {
        SqlConnection Conn = new SqlConnection(connstr);
        Conn.Open();
        SqlCommand sqlcmd = new SqlCommand(cmd, Conn);
        SqlDataReader dr = sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);
        return dr;
    }

    public int ExcCmd(string cmd)
    {
        using (SqlConnection Conn=new SqlConnection(connstr))
        {
            Conn.Open();
            SqlCommand sqlcmd = new SqlCommand(cmd, Conn);
            return sqlcmd.ExecuteNonQuery();
        }
    }

    
}