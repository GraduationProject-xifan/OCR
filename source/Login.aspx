<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MyChat聊天室</title>
    <style type="text/css">
        .style1
        {  background-color:Silver;
            width: 85%;
            height: 585px;
            background-image: url('Image/登陆1.jpg');
            text-align:center;
            margin-top:50px;
            margin-left: 0px;
            margin-right: 0px;
        }
        .style2
        {
            text-align: left;
            width: 319px;
            height: 430px;
        }
        .style6
        {
            color: #FFFFFF;
            font-size: medium;
            font-weight: bold;
        }
        .style7
        {
            color: #FFFFCC;
            font-size: medium;
            font-weight: bold;
        }
        .style8
        {
            width: 1142px;
            text-align: center;
        }
        .auto-style1
        {
            color: #000000;
            font-size: medium;
            font-weight: bold;
        }
    </style>
</head>
<body  style="background-image:url('Image/chat9.png')">
    <form id="form1" runat="server">
    <div align="center">
    
        <table cellpadding="0" cellspacing="0" class="style1" align="center">
            <tr>
                <td class="style8"  >
                    &nbsp;
                   <div style="float:right; width: 362px;" >
                    <asp:Panel ID="Panel1" runat="server" Height="515px" style="margin-top:0px; margin-right:50px;" 
                        Width="297px" BackColor="#E0D3B8" >
                        &nbsp;<div class="style2">
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                            <br />
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                            <br />
                            <br />
                            &nbsp;&nbsp;
                            <span class="auto-style1">用户：</span><asp:TextBox ID="userTextBox" runat="server" Width="150px"></asp:TextBox>
                           
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                            &nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="unRequiredFieldValidator" runat="server" ControlToValidate="userTextBox">用户名不能为空！</asp:RequiredFieldValidator>
                            <br />
                            <br />
                            &nbsp;&nbsp; <span class="auto-style1">密码：</span><asp:TextBox ID="pwdTextBox" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                            &nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="pdRequiredFieldValidator" runat="server" ControlToValidate="pwdTextBox">密码不能为空！</asp:RequiredFieldValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
                            <br />
                            &nbsp;&nbsp;
                            <asp:Button ID="loginButton" runat="server" BackColor="#FFFFCC" BorderColor="#999966" OnClick="loginButton_Click" Text="登陆" />
                            &nbsp;&nbsp;
                            <asp:HyperLink ID="signupHyperLink" runat="server" BackColor="#FF9A00" 
                                NavigateUrl="~/SignUp.aspx" style="background-color: #99CC00">立即注册</asp:HyperLink>
                            &nbsp;&nbsp;
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/RoomList.aspx?t=1" 
                                style="color: #000066; font-weight: 700; background-color: #FFFFFF">游客登陆</asp:HyperLink>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </div>
                    </asp:Panel>
                    </div>
                    &nbsp;
                    </td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>
</html>