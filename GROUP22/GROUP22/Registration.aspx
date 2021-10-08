<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="GROUP22.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 133px;
        }
        .auto-style2 {
            margin-left: 46px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Size="Larger" Text="Welcome to the registration notification page."></asp:Label>
        </div>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label2" runat="server" ForeColor="#3333CC" Text="You have successfully registered your account. Save password? "></asp:Label>
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" BackColor="#009900" Text="Yes" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" BackColor="Yellow" CssClass="auto-style2" Text="No" Width="50px" Height="27px" OnClick="Button3_Click" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button1" runat="server" BackColor="#0066FF" CssClass="auto-style1" Height="53px" Text="Don't have an account? Create." Width="194px" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="rgtrconflabel" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
