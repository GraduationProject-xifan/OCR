<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoomManage.aspx.cs" Inherits="RoomManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
    <title></title>
    <script>
        function a(str)
        {
            document.getElementById("<%=TextBox6.ClientID%>").innerText = str;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox6" runat="server" Visible="False"></asp:TextBox>
            <div id="room" runat="server">
                ����������<br />
                ������������<asp:TextBox ID="TextBox5" runat="server" Width="57px"></asp:TextBox>
                ������200�� 
        <asp:Button ID="Button1" runat="server" Text="�ύ" OnClick="Button1_Click" />
                <br />
                <br />
                ɾ��������<br />
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
                &nbsp;<asp:Button ID="Button2" runat="server" Text="�ύ" OnClick="Button2_Click" />
                <br />
                <br />
                ���������ҹ���<br />
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
                &nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:Button ID="Button4" runat="server" Text="�ύ" OnClick="Button4_Click" />
                <br />
                <br />
                �������������ݣ���Ӣ�Ķ��Ÿ�����<br />
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                <asp:Button ID="Button6" runat="server" Text="�ύ" OnClick="Button6_Click" />
                <br />
                <br />
                <br />
            </div>
            <div id="user" runat="server">
                �����û�<br />
                ��ֹ�û�<br />
                �û���<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <asp:Button ID="Button5" runat="server" Text="�ύ" OnClick="Button5_Click" />
                <br />
                <br />�����û�<br />
                �û���<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="Button3" runat="server" Text="�ύ" OnClick="Button3_Click" />
            </div>

        </div>
    </form>
</body>
</html>
