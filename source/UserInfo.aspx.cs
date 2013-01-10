using System;

public partial class UserInfo : System.Web.UI.Page
{
    UserBLL ub = new UserBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        string uname = Request["uname"].ToString();
        string uid=ub.CheckLogin(uname);
        UserModel um = ub.GetUserInfo(uid);
        //载入用户信息
        if (DateTime.Now.Second % 2 == 0)
        {
            this.avatorImage.ImageUrl = "~/Image/ficon.jpg";
            this.intrLable.Text = "当你做对的时候，没有人会记得；当你做错的时候，连呼吸都是错。 ";
        }
        else
        {
            this.avatorImage.ImageUrl = "~/Image/micon.jpg";
            this.intrLable.Text = "个人简介";
        }
        this.unLable.Text = um.uname;
        this.emailLable.Text = um.email;
        this.statusLable.Text = um.status+"号聊天室";
        if (um.utype == "1")
            this.vipImage.ImageUrl = "~/Image/vip.png";
        else
            this.vipImage.ImageUrl = "~/Image/nvip.png";

         
    }
}