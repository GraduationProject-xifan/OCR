<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoomList.aspx.cs" Inherits="RoomList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
    <title>选择聊天室</title>
    <style>
        #gdv {
            margin-top:30px;
            margin-left:35%;
        }
    </style>
</head>
<body background="Image/chat9.png">
    <form id="form1" runat="server">
        <div>
            &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStr %>" SelectCommand="SELECT [rid], [r_count], [r_max] FROM [croom]"></asp:SqlDataSource>

            <div id="gdv">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="rid" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Horizontal" Width="366px" style="text-align: center">
                <Columns>
                    <asp:TemplateField HeaderText="聊天室" InsertVisible="False" ShowHeader="False" SortExpression="rid">
                        <EditItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("rid") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("rid") %>'></asp:Label>
                            号聊天室
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="当前人数" ShowHeader="False" SortExpression="r_count">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("r_count") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            当前人数<asp:Label ID="Label2" runat="server" Text='<%# Bind("r_count") %>'></asp:Label>
                            /<asp:Label ID="Label3" runat="server" Text='<%# Eval("r_max") %>'></asp:Label>
                            <asp:Image ID="Image1" runat="server" Visible='<%# showhot(Convert.ToInt32(Eval("r_count"))) %>' ImageUrl="~/Image/hot.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="enterButton" runat="server" OnClick="enterButton_Click" Text="进入" CommandArgument='<%# Eval("rid") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
            </div>
            

        </div>
    </form>
</body>
</html>
