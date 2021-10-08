<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order Notification.aspx.cs" Inherits="MYGUI.Order_Notification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Size="Larger" Text="Welcome to the order notification page."></asp:Label>
        </div>
        <p>
            <asp:Label ID="Label376" runat="server" ForeColor="#3333CC" Text="Your order has been received by the resturant and your order number is 1976. "></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Font-Size="Larger" ForeColor="Black" Text="Thank you for using THE SPOT food service."></asp:Label>
        </p>
        <asp:Button ID="Button1" runat="server" BackColor="Yellow" ForeColor="Black" Height="37px" Text="Log-out" Width="85px" OnClick="Button1_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="height: 26px" Text="Done" BackColor="#009900" />
    </form>
</body>
</html>
