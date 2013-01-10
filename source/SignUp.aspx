<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>快速注册到MyChat</title>
    <style type="text/css">
        .auto-style1
        { background-color:Silver;
            width: 85%;
            height: 585px;
            background-image: url('Image/登陆2.jpg');
            text-align:center;
            margin-top:50px;
            margin-left: 0px;
            margin-right: 0px;
        }
        .auto-style2
        {
            text-align: left;
            width: 319px;
            height: 460px;
        }
    </style>
</head>
<body style="background-image: url('Image/chat9.png')">
    <form id="form1" runat="server">
    <div align="center">
    
        <table align="center" cellpadding="0" cellspacing="0" class="auto-style1">
            <tr>
                <td>
                    <div style="float:right; width: 321px;" >
                    <asp:Panel ID="Panel1" style="margin-top:10px; margin-right:18px;" runat="server" CssClass="auto-style2" Height="520px" Width="297px" BackColor="Silver" >
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        &nbsp;&nbsp;
                        用户&nbsp;&nbsp;
                        <asp:TextBox ID="unTextBox" runat="server" Width="150px" ></asp:TextBox>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="unTextBox">请输入用户名</asp:RequiredFieldValidator>
                        <br />
                        <br />
                        &nbsp;&nbsp;
                        密码&nbsp;&nbsp;
                        <asp:TextBox ID="pwTextBox" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="pwTextBox">请输入密码</asp:RequiredFieldValidator>
                        <br />
                        <br />
                    
                        重复密码&nbsp;
                        <asp:TextBox ID="vpwTextbox" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="vpwTextbox">请再次输入密码</asp:RequiredFieldValidator>
                        <br />
                    
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="vpwTextbox" ControlToValidate="pwTextBox">两次密码输入不一致</asp:CompareValidator>
                        <br />
               
                        &nbsp;&nbsp;
                        邮箱&nbsp;&nbsp;
                        <asp:TextBox ID="emailTextBox" runat="server" Width="150px"></asp:TextBox>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="emailTextBox">请输入邮箱</asp:RequiredFieldValidator>
                        <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="signButton" runat="server" OnClick="signButton_Click" Text="注册" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="isvipCheckBox" runat="server" Text="升级为vip！" ToolTip="成为vip，享受更多特权" />
                    </asp:Panel>
                         </div>
                </td>
            </tr>
        </table>
    
    </div>
      
    </form>
</body>
</html>
