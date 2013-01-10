using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// 用户层
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

    /// <summary>
    /// 执行注册
    /// </summary>
    /// <param name="uname">用户名</param>
    /// <param name="upwd">密码</param>
    /// <param name="email">邮箱</param>
    /// <param name="isvip">vip为1，非vip为0，游客为2</param>
    /// <returns>是否成功</returns>
    public bool SignUp(string uname,string upwd,string email,int isvip)
    {
        uname=FilterStr(uname);
        string cmd = string.Format("insert into myuser values(N'{0}','{1}','{2}',{3},0)", uname, FilterStr(upwd), FilterStr(email), isvip);
        if (mydata.ExcCmd(cmd) > 0)
        {
            string newid = CheckLogin(uname);
            string cmd1 = string.Format("update myuser set uname=N'{0}' where uid={1}", uname, Convert.ToInt32(newid));
            mydata.ExcCmd(cmd1);//再次插值防止乱码
            return true;
        }
            
        else
            return false;
    }

    /// <summary>
    /// 进入聊天室更新数据
    /// </summary>
    /// <param name="rid">聊天室id</param>
    /// <param name="uid">用户id</param>
    /// <param name="r_count">聊天室人数</param>
    /// <returns>true为成功，false为失败</returns>
    public bool EnterRoom(int rid,int uid,int r_count)
    {
        if (r_count < 50)
            r_count += 1;
        else
            return false;
        string cmd = string.Format("update croom set r_count={0} where rid={1}", r_count, rid);
        string cmd1 = string.Format("update myuser set status={0} where uid={1}", rid, uid);
        int test = 0;
        test=mydata.ExcCmd(cmd);
        test += mydata.ExcCmd(cmd1);
        if (test > 1)
            return true;//如果两条命令都执行成功，则返回true
        else
            return false;//否则返回false
    }

    /// <summary>
    /// 游客通道，进入聊天室更新数据
    /// </summary>
    /// <param name="rid">聊天室id</param>
    /// <param name="r_count">聊天室人数</param>
    /// <returns>true为成功，false为失败</returns>
    public bool EnterRoom(int rid, int r_count)
    {
        if (r_count < 50)
            r_count += 1;
        else
            return false;
        string cmd = string.Format("update croom set r_count={0} where rid={1}", r_count, rid);
        if (mydata.ExcCmd(cmd) > 0)
            return true;//如果两条命令都执行成功，则返回true
        else
            return false;//否则返回false
    }

    public int GetRoomCount(string roomid)
    {
        string cmd = string.Format("select r_count from croom where rid={0}",Convert.ToInt32(roomid));
        SqlDataReader dr = mydata.ReadDB(cmd);
        if (dr.Read())
        {
            int rcount = Convert.ToInt32(dr["r_count"]);
            dr.Close();
            return rcount;
        }
        else
            return -1;
    }

    public SqlDataReader GetUserList(string rid)
    {
        string cmd = string.Format("select uid from myuser where status={0}", rid);
        SqlDataReader reader = mydata.ReadDB(cmd);
            return reader;
    }

    /// <summary>
    /// 清除当前用户状态
    /// </summary>
    /// <param name="rid"></param>
    /// <param name="uid"></param>
    /// <returns></returns>
    public bool ClearList(string rid,string uid)
    {
        int rcount=GetRoomCount(rid);
        if (rcount > 0)
            rcount -= 1;
        else
            return false;
        string cmd = string.Format("update croom set r_count={0} where rid={1}", rcount, Convert.ToInt32(rid));
        string cmd1 = string.Format("update myuser set status=0 where uid={0}", Convert.ToInt32(uid));
        int test = 0;
        test = mydata.ExcCmd(cmd);
        test += mydata.ExcCmd(cmd1);
        if (test>1)
            return true;
        else
            return false;
    }

    /// <summary>
    /// 清除游客状态
    /// </summary>
    /// <param name="rid"></param>
    /// <returns></returns>
    public bool ClearList(string rid)
    {
        int rcount = GetRoomCount(rid);
        if (rcount > 0)
            rcount -= 1;
        else
            return false;
        string cmd = string.Format("update croom set r_count={0} where rid={1}", rcount, Convert.ToInt32(rid));
        if (mydata.ExcCmd(cmd) > 1)
            return true;
        else
            return false;
    }

    public UserModel GetUserInfo(string uid)
    {
        UserModel info = new UserModel();
        string cmd = string.Format("select * from myuser where uid={0}", Convert.ToInt32(uid));
        SqlDataReader dr = mydata.ReadDB(cmd);
        if (dr.Read())
        {
            info.uname = dr["uname"].ToString();
            info.upwd = dr["passwd"].ToString();
            info.email = dr["umail"].ToString();
            info.utype = dr["utype"].ToString();
            info.status = dr["status"].ToString();
        }
        info.uid = uid;
        dr.Close();
        string cmd2 = string.Format("select * from myinfo where uid={0}", Convert.ToInt32(uid));
        SqlDataReader dr2 = mydata.ReadDB(cmd2);
        if (dr2.Read())
        {
            info.uinfo = dr2["uinfo"].ToString();
            info.sex = dr2["sex"].ToString();
            info.avatorurl = dr2["avator"].ToString();
        }
        else
        {
            info.uinfo = "";
            info.sex = "";
            info.avatorurl = "";
        }
        dr2.Close();
        return info;
    }

    #region 检查用户名密码是否存在并验证
    /// <summary>
    /// 检查用户名或者用户名与密码是否存在并对其进行验证
    /// </summary>
    /// <param name="uname">用户名字符串</param>
    /// <param name="upwd">密码字符串</param>
    /// <returns>返回用户id</returns>
    public string CheckLogin(string uname, string upwd)
    {
        tablename = "myuser";      //当前方法对myuser表进行操作
        SqlDataReader dr = mydata.ReadDB(string.Format("select uid from {0} where uname=N'{1}' and passwd='{2}'", tablename, FilterStr(uname), FilterStr(upwd)));
        if (dr.Read())
        {
            if (dr["uid"].ToString() != "")
            {
                string uid = dr["uid"].ToString();
                dr.Close();
                return uid;
            }

            else
            {
                dr.Close();
                return "null";
            }
                
        }
        else
        {
            dr.Close();
            return "null";
        }
        
        
    }

    /// <summary>
    /// 检查用户名是否存在
    /// </summary>
    /// <param name="uname">用户名字符串</param>
    /// <returns>返回用户id</returns>
    public string CheckLogin(string uname)
    {
        tablename = "myuser";      //当前方法对myuser表进行操作
        SqlDataReader dr = mydata.ReadDB(string.Format("select uid from {0} where uname=N'{1}'", tablename, FilterStr(uname)));
        if (dr.Read())
        {
            if (dr["uid"].ToString() != "")
            {
                string uid = dr["uid"].ToString();
                dr.Close();
                return uid;//用户名已存在
            }

            else
            {
                dr.Close();
                return "null";//用户名不存在
            }

        }
        else
        {
            dr.Close();
            return "null";
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

    public string GetAnnounce(string rid)
    {
        string cmd = "select r_announce from croom where rid=" + Convert.ToInt32(rid);
        SqlDataReader dr = mydata.ReadDB(cmd);
        string an = "";
        if (dr.Read())
            an = dr["r_announce"].ToString();
        else
            an = "";
        dr.Close();
        return an;
    }


    public bool CheckFrd(string me, string friend)
    {
        string cmd = "select fid from myfrd where uid=" + Convert.ToInt32(me);
        SqlDataReader dr = mydata.ReadDB(cmd);
        if (dr.Read())
        {
            if (dr["fid"].ToString() == friend)
            {
                dr.Close();
                return true;
            }
            else
            {
                dr.Close();
                return false;
            }
        }
        else
        {
            dr.Close();
            return false;
        }
    }

    public bool AddFriend(string me, string frd)
    {
        string cmd = string.Format("insert into myfrd values({0},{1})", Convert.ToInt32(me), Convert.ToInt32(frd));
        if (mydata.ExcCmd(cmd) > 0)
            return true;
        else
            return false;
    }
}