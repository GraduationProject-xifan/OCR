<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
    <title></title>
    <style type="text/css">
        #opframe {
            height: 414px;
            width: 600px;
            float:right;
        }

        .unlog {
            MARGIN-RIGHT: auto;
            MARGIN-LEFT: auto;
            height: 200px;
            width: 700px;
            vertical-align: middle;
            line-height: 200px;
        }
        .lst {
        }
    </style>
</head>
<body style="background:url('Image/ad.jpg') no-repeat 50% 0;">
    <form id="form1" runat="server" >
        <asp:Panel ID="loggedPanel" runat="server">
            <div id="lst">
                <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Height="141px" Width="145px">
                    <asp:ListItem Selected="True">请选择</asp:ListItem>
                    <asp:ListItem Value="0">管理聊天室</asp:ListItem>
                    <asp:ListItem Value="1">管理用户</asp:ListItem>
                </asp:ListBox>


            </div>
            <div id="func">
                <iframe id="opframe" runat="server" src="" style="border-style:none; background-color:transparent; margin-left:35%">

                </iframe>
            </div>
        </asp:Panel>
        <asp:Panel ID="unlogPanel" runat="server" CssClass="unlog">
            请先登陆
            管理员账号：
         
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            管理员密码：<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </asp:Panel>
    </form>
</body>
</html>
