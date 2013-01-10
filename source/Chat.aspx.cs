using System;
using System.Data.SqlClient;

public partial class Chat : System.Web.UI.Page
{
    UserBLL myuser = new UserBLL();
    UserModel um;
    public bool isvip=false;
    public int t = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request["t"] == "1")
            {
                t = 1;
                isvip = false;
            }
            string rid = Session["rid"].ToString();
            string aid = "chat" + rid;
            this.Page.Title = "欢迎来到" + rid + "号聊天室！";//显示标题
            GetUserList(rid);//获取用户列表
            GetUserList(rid);//获取用户列表
            this.roomLable.Text = Session["rid"].ToString();
            Application.Lock();
            Application["users"] = this.flstLiteral.Text;
            Application.UnLock();
            this.countLable.Text = myuser.GetRoomCount(rid).ToString();
            // 获取在线人数
        }
        catch// (Exception ex)
        {
            Response.Write("<script>alert('当前用户已注销！即将返回登录界面');window.location.href='Login.aspx'</script>");
        }
    }


    private void GetUserList(string rid)
    {
        this.flstLiteral.Text = "";//清空在线列表
        string cid = "guest" + Session["rid"].ToString();
        string str = "";
        string lst = Application[cid].ToString();

        SqlDataReader reader = myuser.GetUserList(rid);//优先处理登陆用户
        while (reader.Read())
        {
            this.flstLiteral.Text += GetStyle(myuser.GetUserInfo(reader["uid"].ToString()).uname);//获取并格式化从数据库获取的用户列表
        }//从数据库更新在线列表
        reader.Close();

        if (Request["t"] != "1")
        {
            um = myuser.GetUserInfo(Session["uid"].ToString());//非游客则将当前用户信息存入模型层
            if (um.utype == "1")
                isvip = true;//判断当前用户类型
        }
        else
        {
            Application.Lock();
            str = "游客" + Session["uid"].ToString() + "<br>";
            if (!lst.Contains(str))
                Application[cid] += str; //判断当前用户是否已经添加，同时添加到服务器
            Application.UnLock();
        }//如果当前用户为游客，则只添加名字到用户列表

        if (!this.flstLiteral.Text.Contains(lst))
            this.flstLiteral.Text += lst;//从服务端获取匿名用户列表
    }
    /// <summary>
    /// 设置聊天语句样式
    /// </summary>
    /// <param name="str"></param>
    /// <param name="isuser"></param>
    /// <returns></returns>
    private string GetChatStyle(string str, bool isuser)
    {
        int cc = Convert.ToInt32(Session["chatcount"]);
        string uname = null;
        if (um != null)
            uname = "<a href=# onclick=newpm(this,'" + isvip + "')>" + um.uname + "</a>";
        if (cc % 2 == 0)
        {
            if (isuser)
                str = string.Format("<div style='padding: 10px;'>{0}说:<br>{1}<br></div>", uname, str);
            else
                str = string.Format("<div style='padding: 10px;'>游客{0}说:<br>{1}<br></div>", Session["uid"].ToString(), str);
        }
        else
        {
            if (isuser)
                str = string.Format("<div style='background-color: #EFEFEF; padding:10px;'>{0}说:<br>{1}<br></div>", uname, str);
            else
                str = string.Format("<div style='background-color: #EFEFEF; padding: 10px;'>游客{0}说:<br>{1}<br></div>", Session["uid"].ToString(), str);
        }
        Session["chatcount"] = cc + 1;
        return str;
    }

    private string GetPmStyle(string str, string fname)
    {
        str = str.Replace("对" + fname + "说：", "");
        int cc = Convert.ToInt32(Session["chatcount"]);
        string mstr = "<a href=# onclick=newpm(this)>" + um.uname + "</a>";
        string fstr = "<a href=# onclick=newpm(this)>" + fname + "</a>";
        string msg = string.Format("[悄悄话] {0} 对 {1} 说：<br>{2}<br>", mstr, fstr, str);

        Session["pmid"] = "";//确保下次正确显示用户

        if (cc % 2 == 0)
            str = string.Format("<div style='padding: 10px;'>{0}</div>", msg);
        else
            str = string.Format("<div style='background-color: #EFEFEF; padding: 10px;'>{0}</div>", msg);
        return str;
    }

    /// <summary>
    /// 设置在线用户样式
    /// </summary>
    /// <param name="uname"></param>
    /// <returns></returns>
    private string GetStyle(string uname)
    {
        string uicon = "";//头像
        
        if (uname == Session["uname"].ToString())
        {
            uname = uicon + "<b>" + uname + "</b><br>";
        }
        else
        {
            uname = uicon + uname + "<br>";
        }
        if (uname != Session["uname"].ToString() + Session["uid"].ToString())
        {
            uname = "<a href=javascript:void(0) onclick=getinfo(this)>" + uname + "</a>";
            return uname;
        }
        else
        {
            return uname;
        }

    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        if (Request["t"] == "1")
        {
            //myuser.ClearList(Session["rid"].ToString());
            string str = Application["guest" + Session["rid"].ToString()].ToString();
            str=str.Replace("游客" + Session["uid"].ToString() + "<br>", "");
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            //myuser.ClearList(Session["rid"].ToString(), Session["uid"].ToString());
            Response.Redirect("~/Login.aspx");
        }
    }
}