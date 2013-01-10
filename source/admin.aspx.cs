using System;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.loggedPanel.Visible = false;
            this.unlogPanel.Visible = true;
            this.Button1.Enabled = true;
            this.opframe.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.TextBox1.Text != "" && this.TextBox2.Text != "")
        {
            if (this.TextBox1.Text == "admin" && this.TextBox2.Text == "admin")
            {
                this.unlogPanel.Visible = false;
                this.loggedPanel.Visible = true;
                this.Button1.Enabled = false;
            }
            else
            {
                this.Label1.Text = "输入有误！请重新输入！";
            }
        }
        else
        {
            this.Label1.Text = "请先输入！";
        }
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ListBox1.SelectedValue == "0")
        {
            this.opframe.Visible = true;
            this.opframe.Src = "RoomManage.aspx?t=0";
        }
        else if (this.ListBox1.SelectedValue == "1")
        {
            this.opframe.Visible = true;
            this.opframe.Src = "RoomManage.aspx?t=1";
        }
        else
        {
            this.opframe.Visible = false;
        }
    }
}