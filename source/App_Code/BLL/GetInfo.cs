using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// GetInfo 的摘要说明
/// </summary>
public class GetInfo
{
	public GetInfo()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public string Test()
    {
        string tablename="myuser";
        Data mydb = new Data();
        DataSet ds = new DataSet();
        ds = mydb.ReadDB(string.Format("select * from {0}", tablename), tablename);
        return ds.Tables["myuser"].Rows[0]["uname"].ToString();
        UserInfo info=new UserInfo();
        List<UserInfo> infolist = new List<UserInfo>();
        infolist

    }
}