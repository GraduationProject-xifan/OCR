using System;

public partial class SignUp : System.Web.UI.Page
{
    UserBLL myuser = new UserBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["rid"] != null)
        {
            string uid = myuser.CheckLogin(Session["uid"].ToString());
            string s = myuser.GetUserInfo(uid).status;
            if (Convert.ToInt32(s) < 0)
            {
                Response.Write("<script>alert('你的账号已被禁止，请勿重复注册！');window.location.back();</script>");
            }
        }
    }
    protected void signButton_Click(object sender, EventArgs e)
    {
        
        int vip = 0;
        if (this.isvipCheckBox.Checked)
            vip = 1;
        if (myuser.SignUp(this.unTextBox.Text, this.pwTextBox.Text, this.emailTextBox.Text, vip))
        {
            //注册成功，转到聊天室列表
            Response.Write("<script>alert('注册成功！')</script>");
            string uid = myuser.CheckLogin(this.unTextBox.Text);
            if (uid != "null")
            {
                Session["uname"] = this.unTextBox.Text;
                Session["uid"] = uid;
                Response.Redirect("~/RoomList.aspx");
            }
            else
            {
                Response.Redirect("~/Error.aspx");
            }
        }
        else
        {
            Response.Redirect("~/Error.aspx");
        }
    }
}