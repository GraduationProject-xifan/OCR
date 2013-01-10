using System;

public partial class Login : System.Web.UI.Page
{
    UserBLL myuser = new UserBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["logout"] != "1")
            {
                if (Session["uid"] != null && Session["rid"] != null)
                {
                    myuser.ClearList(Session["rid"].ToString(), Session["uid"].ToString());
                    Session.RemoveAll();
                    Session.Clear();
                    Session.Abandon();
                    Response.Redirect("Login.aspx?logout=1");
                }
                else if (Session["rid"] != null)
                {
                    myuser.ClearList(Session["rid"].ToString());
                    Session.RemoveAll();
                    Session.Clear();
                    Session.Abandon();
                    Response.Redirect("Login.aspx?logout=1");
                } 
            }
        }
    }
    protected void loginButton_Click(object sender, EventArgs e)
    {
        string uid = myuser.CheckLogin(this.userTextBox.Text, this.pwdTextBox.Text);//检查用户账号
        if (uid != "null")
        {
            UserModel um = myuser.GetUserInfo(uid);//获取用户信息
            if (Convert.ToInt32(um.status) >= 0)
            {
                Session["uname"] = this.userTextBox.Text;
                Session["uid"] = uid;
                Response.Redirect("~/RoomList.aspx");
            }
            else
            {
                Response.Write("<script>alert('对不起！因为你的账号有非法操作被管理员禁止，有任何意见请跟管理员联系，感谢您的支持。')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('用户名密码错误')</script>");
        }
    }
}