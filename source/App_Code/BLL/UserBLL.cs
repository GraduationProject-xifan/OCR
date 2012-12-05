using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// UserBLL 的摘要说明
/// </summary>
public class UserBLL
{
    private string tablename = "";
    Data mydata = new Data();
	public UserBLL()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    #region 检查用户名密码是否存在并验证
    /// <summary>
    /// 检查用户名或者用户名与密码是否存在并对其进行验证
    /// </summary>
    /// <param name="uname">用户名字符串</param>
    /// <param name="upwd">密码字符串</param>
    /// <returns></returns>
    public bool CheckLogin(string uname, string upwd)
    {
        tablename = "myuser";      //当前方法对myuser表进行操作
        DataSet ds = new DataSet();
        ds = mydata.ReadDB(string.Format("select uid from {0} where uname='{1}' and passwd='{2}'", tablename, FilterStr(uname), FilterStr(upwd)), tablename);
        try
        {
            if (ds.Tables[tablename].Rows[0]["uid"].ToString() != "")
                return true;
            else
                return false;
        }
        catch
        {
            return false;
        }
        
    }

    /// <summary>
    /// 检查用户名是否存在
    /// </summary>
    /// <param name="uname">用户名字符串</param>
    /// <returns>true为存在</returns>
    public bool CheckLogin(string uname)
    {
        tablename = "myuser";      //当前方法对myuser表进行操作
        DataSet ds = new DataSet();
        ds = mydata.ReadDB(string.Format(@"select uid from {0} where uname='{1}'", tablename, FilterStr(uname)), tablename);
        try
        {
            if (ds != null && ds.Tables[tablename].Rows[0]["uid"].ToString() != "")
                return true;
            else
                return false;
        }
        catch
        {
            return false;
        }
        
    }
    #endregion

    #region 过滤字符
    public string FilterStr(string Str)
    {
        Str = Str.Trim();
        //删除脚本
        Str = Regex.Replace(Str, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        //删除HTML
        Str = Regex.Replace(Str, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, @"-->", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, @"<!--.*", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, @"&#(\d+);", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "xp_cmdshell", "", RegexOptions.IgnoreCase);

        //删除与数据库相关的词
        Str = Regex.Replace(Str, "select", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "insert", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "delete from", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "count''", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "drop table", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "truncate", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "asc", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "mid", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "char", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "xp_cmdshell", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "exec master", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "net localgroup administrators", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "and", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "net user", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "or", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "net", "", RegexOptions.IgnoreCase);
        //Htmlstring = Regex.Replace(Htmlstring, "*", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "-", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "delete", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "drop", "", RegexOptions.IgnoreCase);
        Str = Regex.Replace(Str, "script", "", RegexOptions.IgnoreCase);

        //特殊的字符
        Str = Str.Replace("<", "");
        Str = Str.Replace(">", "");
        Str = Str.Replace("*", "");
        Str = Str.Replace("-", "");
        Str = Str.Replace("?", "");
        Str = Str.Replace("'", "''");
        Str = Str.Replace(",", "");
        Str = Str.Replace("/", "");
        Str = Str.Replace(";", "");
        Str = Str.Replace("*/", "");
        Str = Str.Replace("\r\n", "");
        Str = HttpContext.Current.Server.HtmlEncode(Str).Trim();
        return Str;
    }
    #endregion
}