using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class RoomManage : System.Web.UI.Page
{

    AdminBLL admin = new AdminBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        #region visible
        if (Request["t"] == "0")
        {
            this.room.Visible = true;
            this.user.Visible = false;
        }
        else if (Request["t"] == "1")
        {
            this.room.Visible = false;
            this.user.Visible = true;
        }
        else
        {
            this.room.Visible = false;
            this.user.Visible = false;
        }
        #endregion
        if (!IsPostBack)
        {
            ListItem it = new ListItem("请选择", "0");
            this.DropDownList1.Items.Insert(0, it);
            this.DropDownList2.Items.Insert(0, it);//添加默认选项

            SqlDataReader dr = admin.GetRoomList();
            while (dr.Read())
            {
                this.DropDownList1.Items.Add(dr["rid"].ToString());
                this.DropDownList2.Items.Add(dr["rid"].ToString());
            }
            dr.Close();//手动添加从数据库获得的rid
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.TextBox5.Text != ""&&Convert.ToInt32(this.TextBox5.Text)<200)
        {
            if (admin.AddRoom(Convert.ToInt32(this.TextBox5.Text)))
                Response.Write("<script>alert('添加成功！')</script>");
            else
                Response.Write("<script>alert('添加失败！')</script>");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (this.DropDownList1.SelectedValue != "0")
        {
            if (admin.DelRoom(Convert.ToInt32(this.DropDownList1.SelectedValue.ToString())))
                Response.Write("<script>alert('删除成功！')</script>");
            else
                Response.Write("<script>alert('删除失败！')</script>");
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (this.DropDownList2.SelectedValue != "0"&&this.TextBox2.Text!="")
        {
            if (admin.UpdateAnnounce(Convert.ToInt32(this.DropDownList2.SelectedValue.ToString()), this.TextBox2.Text))
                Response.Write("<script>alert('设置成功！')</script>");
            else
                Response.Write("<script>alert('设置失败！')</script>");
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        if (this.TextBox4.Text != "")
        {
            UserBLL ub = new UserBLL();
            Application.Lock();
            Application["filter"] = this.TextBox4.Text;
            Application.UnLock();
            Response.Write("<script>alert('设置成功！')</script>");
        }
        else
        {
            Response.Write("<script>alert('请输入关键字！')</script>");
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (this.TextBox3.Text != "")
        {
            UserBLL user = new UserBLL();
            string ustatus="";
            string uid = user.CheckLogin(this.TextBox3.Text);
            UserModel model = user.GetUserInfo(uid);
            if (Convert.ToInt32(model.status)>0)
                ustatus=model.status+"号聊天室";
            else if (Convert.ToInt32(model.status)==0)
                ustatus="不在线";
            else if (Convert.ToInt32(model.status)<0)
                ustatus="被禁止";
            Response.Write("<script>var chard='" + ustatus + "';if (chard!='被禁止'){ var s=confirm('用户id：" + model.uid + "\\n用户名：" + model.uname + "\\n状态：" + ustatus + "\\n是否禁止？');if (s){window.location.href='DoRequest.aspx?mod=banuser&n=" + model.uname + "';}}else{alert('当前用户已被禁止！无需再禁止');}</script>");

        }
        else 
        {
            Response.Write("<script>alert('请输入id！')</script>");
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (this.TextBox1.Text != "")
        {
            if (admin.ActUser(this.TextBox1.Text))
                Response.Write("<script>alert('已激活！')</script>");
            else
                Response.Write("<script>alert('激活失败！请检查用户是否被禁止')</script>");
        }
        else
        {
            Response.Write("<script>alert('请输入id！')</script>");
        }
    }
}