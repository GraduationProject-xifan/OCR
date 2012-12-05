<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Chat.aspx.cs" Inherits="Chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MyChat聊天室</title>
    <script src="Scripts/jquery-1.8.3.min.js"></script>
    <script>
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="flst">

            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

            <br />

            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />

        </div>
        <div id="rlst">

        </div>
        <div id="content">

        </div>
        <div id="sendc">

        </div>
    </form>
</body>
</html>
