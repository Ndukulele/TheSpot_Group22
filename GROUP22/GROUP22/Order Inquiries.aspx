<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order Inquiries.aspx.cs" Inherits="MYGUI.Order_Inquiries" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 32px;
        }
        .auto-style2 {
            margin-left: 161px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Size="Larger" Text="Welcome to the Order Inquiries  page."></asp:Label>
            <br />
            <br />
        </div>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" ForeColor="Blue" Text="Order number : "></asp:Label>
&nbsp;
        </p>
        <asp:ListBox ID="ListBox1" runat="server" CssClass="auto-style2" Height="195px" Width="257px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
            <asp:ListItem>Employee: Your order is being processed</asp:ListItem>
        </asp:ListBox>
        <asp:Button ID="Button2" runat="server" BackColor="#009900" CssClass="auto-style1" ForeColor="Black" Text="Refresh" OnClick="Button2_Click" />
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
