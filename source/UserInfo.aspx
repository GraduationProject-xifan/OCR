<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        #avator {
            float:left;
            margin-top:13px;
        }
        #uname {
            margin-left:110px;
            margin-bottom:10px;
            width:auto;
        }
        #uinfo {
            float:right;
            margin-left:10px;
        }
        #info {
            float:right;
            margin-left:1px;
            margin-top:25px;
        }
        .name1 {
            margin-left:-5px;
        }
        .custom1 {
        margin-left:10px;
        
        }
    </style>
</head>
<body style="width:auto;height:auto">
    <form id="form1" runat="server">
    <div style="width:auto">
        <div id="avator">
            <asp:Image ID="avatorImage" runat="server" Width="100px" Height="100px" />
        </div>
        
        <div id="uname">
            <asp:Label ID="unLable" runat="server" Text="Label" Font-Size="50pt" Font-Names="Lao UI" CssClass="name1"></asp:Label>
            <asp:Image ID="vipImage" runat="server" CssClass="vipimage" />
            <br />
            <asp:Label ID="emailLable" runat="server" Text="null" Font-Size="small"></asp:Label><asp:Label ID="statusLable" runat="server" Text="null" ForeColor="GrayText" CssClass="custom1"></asp:Label>
            
        </div>
            <br />
            <asp:Label ID="intrLable" runat="server" Text="null" Font-Bold="True" Font-Names="Microsoft YaHei UI"></asp:Label>
    </div>
    </form>
</body>
</html>
