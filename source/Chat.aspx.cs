﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        UserBLL login = new UserBLL();
        if (login.CheckLogin(this.TextBox1.Text, this.TextBox2.Text))
            this.Label1.Text = "yes";
        else
            this.Label1.Text = "no";
    }
}