using System;
using System.Web.UI.WebControls;

public partial class RoomList : System.Web.UI.Page
{

    UserBLL ub = new UserBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        Application["chatcount"] = "0";//供下个页面使用的计数器;
        if (Request["t"] == "1")
        {
            Random r = new Random(Convert.ToInt32(DateTime.Now.Millisecond.ToString()));
            int nid = r.Next(100, 999);
            Session["uname"] = "游客" + nid.ToString();
            Session["uid"] = nid.ToString();
        }
    }

    protected void enterButton_Click(object sender, EventArgs e)
    {
        
        Button bt = sender as Button;
        Session["rid"] = bt.CommandArgument;
        UserBLL myuser=new UserBLL();
        int roomcount = myuser.GetRoomCount(Session["rid"].ToString());
        if (Request["t"] == "1")//游客登陆
        {
            if (ub.EnterRoom(toInt(Session["rid"].ToString()), roomcount))
            {
                Response.Redirect("~/Chat.aspx?t=1");
            }
            else
                Response.Write("<script>alert('房间已满！请进入其他聊天室')</script>");
        }
        else//用户登陆
        {
            if (ub.EnterRoom(toInt(Session["rid"].ToString()), toInt(Session["uid"].ToString()), roomcount))
            {
                Response.Redirect("~/Chat.aspx");
            }
            else
            {
                Response.Write("<script>alert('房间已满！请进入其他聊天室')</script>");
            }
        }
    }

    public bool showhot(int count)
    {
        if (count > 25)
            return true;
        else
            return false;
    }

    private int toInt(string a)
    {
        return Convert.ToInt32(a);
    }
}