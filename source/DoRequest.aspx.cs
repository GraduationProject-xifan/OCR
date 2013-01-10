using System;

public partial class DoRequest : System.Web.UI.Page
{
    
    AdminBLL admin = new AdminBLL();
    UserBLL user = new UserBLL();
    public string vip { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        switch (Request["mod"])
        {
            case "banuser": Banuser(); break;
            case "pm":Sendpm();break;
            case "info": GetInfo(); break;
            case "ajax": AjaxOperater(Request["func"]); break;
            default:Response.Write("error");break;
        }
    }

    private void AjaxOperater(string func)
    {
        switch (func)
        {
            case "gmsg":GetMsg();break;
            case "gann": GetAnnounce(); break;
            case "glst": GetList(); break;
            case "gol": GetOnline(); break;
            case "sms": SendMsg(Request["msg"].ToString(),Request["vip"].ToString()); break;
            default:break;
        }
    }

    private void SendMsg(string msg,string isvip)
    {
        vip = isvip;
        string aid = "chat" + Session["rid"];//获得当前聊天室频道
        msg = filterchat(msg);//过滤聊天内容
        if (Session["pmid"]!= null)//发送PM
        {
            Application.Lock();
            Application["pm" + Session["rid"]] += GetPmStyle(msg, Session["pmid"].ToString());
                Application[aid] += Application["pm" + Session["rid"]].ToString();
            Application.UnLock();
            
        }
        else//公共聊天
        {
            Application.Lock();
                Application[aid] += GetChatStyle(msg);
            Application.UnLock();
        }
        Response.Write("ok");
    }

    private void Sendpm()
    {
        string fname = Request["fname"].ToString();
        if (fname == Session["uname"].ToString())
        {
            Response.Write("error");
            Response.End();
        }
        else
        {
            Session["pmid"] = fname;
            Response.Write("ok");
            Response.End();
        }
    }


    private void GetOnline()
    {
        Response.Write(user.GetRoomCount(Session["rid"].ToString()));
        Response.End();
    }

    private void GetList()
    {
        string cid = "guest" + Session["rid"].ToString();
        string list = Application["users"].ToString();//获取登录用户列表
        if (!list.Contains(Application[cid].ToString()))
            list += Application[cid].ToString();//从服务端获取匿名用户列表
        Response.Write(list);
        Response.End();
    }


    private void GetAnnounce()
    {
        string t=user.GetAnnounce(Session["rid"].ToString());
         Response.Write(t);
         Response.End();
    }

    private void GetMsg()
    {
        string message = Application["chat" + Session["rid"].ToString()].ToString();
        string str = "<a href=# onclick=newpm(this,'" + vip + "')>" + Session["uname"] + "</a>";
        if (message.Contains(str))
        {
            message = message.Replace(str, "你");
        }
        Response.Write(message);
        Response.End();
    }

    private void GetInfo()
    {
        string uname = Request["get"].ToString();
        Response.Write("<iframe runat=server id=infoframe style='height:300px;border:none;width:auto;text-align:center;' scrolling=no src=UserInfo.aspx?uname=" + uname + "></iframe>");
        Response.End();
    }

    private void Banuser()
    {
        if (admin.BanUser(Request["n"].ToString()))
        {
            Response.Write("<script>alert('禁止成功！');window.location.href='RoomManage.aspx?t=1';</script>");
        }
        else
        {
            Response.Write("<script>alert('禁止失败！');window.location.href='RoomManage.aspx?t=1';</script>");
        }
    }


    /// <summary>
    /// 设置聊天语句样式
    /// </summary>
    /// <param name="str"></param>
    /// <param name="isuser"></param>
    /// <returns></returns>
    private string GetChatStyle(string str)
    {
        bool isuser = false; ;
        int cc = Convert.ToInt32(Application["chatcount"]);
        string uname = null;
        string color = Request["color"].ToString();
        switch (color)
        {
            case "black": str = "<span style=color:black>" + str + "</span>"; break;
            case "red": str = "<span style=color:red>" + str + "</span>"; break;
            case "blue": str = "<span style=color:blue>" + str + "</span>"; break;
            case "green": str = "<span style=color:green>" + str + "</span>"; break;
            case "yellow": str = "<span style=color:yellow>" + str + "</span>"; break;
            case "gray": str = "<span style=color:gray>" + str + "</span>"; break;
        }

        if (Session["uname"].ToString() != "游客" + Session["uid"].ToString())
        {
            isuser = true;
            uname = "<a href=# onclick=newpm(this,'" + vip + "')>" + Session["uname"] + "</a>";
        }
        else
            isuser = false;
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
        Application["chatcount"] = cc + 1;
        return str;
    }

    private string GetPmStyle(string str, string fname)
    {
        str = str.Replace("对" + fname + "说：", "");
        int cc = Convert.ToInt32(Application["chatcount"]);
        string mstr = "<a href=# onclick=newpm(this,'" + vip + "')>" + Session["uname"] + "</a>";
        string fstr = "<a href=# onclick=newpm(this,'" + vip + "')>" + fname + "</a>";
        string msg = string.Format("[悄悄话] {0} 对 {1} 说：<br>{2}<br>", mstr, fstr, str);

        Session["pmid"] = null;//确保下次正确显示用户

        if (cc % 2 == 0)
            str = string.Format("<div style='padding: 10px;'>{0}</div>", msg);
        else
            str = string.Format("<div style='background-color: #EFEFEF; padding: 10px;'>{0}</div>", msg);

        Application["chatcount"] = cc + 1;
        return str;
    }

    private string filterchat(string message)
    {
        if (message.Contains("|"))
        {
            string temp = "";
            for (int i = 0; i <= 106; i++)
            {
                temp = i.ToString().PadLeft(3, '0');
                if (message.Contains("|" + temp + "|"))
                {
                    message = message.Replace("|" + temp + "|", "<img src=Image/bq/f" + temp + ".gif loop=-1 id=" + temp + " onclick=GetBq(this) />");
                }
            }
        }//发送表情

        string filter = Application["filter"].ToString();
        string[] filters = filter.Split(',');
        if (filters[0] != "" && filters.Length >= 1)
        {
            for (int i = 0; i < filters.Length; i++)
            {
                message = message.Replace(filters[i], "***");
            }
        }//根据管理员设置的关键字进行过滤

        return message;
    }

}