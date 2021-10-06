<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="EmployeeOrdersSite.aspx.cs" Inherits="GROUP22.EmployeeOrdersSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style2">Order Site</td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style3">Orders<br />
                Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Order Number<br />
                <asp:ListBox ID="lsOrders" runat="server" Height="334px" Width="221px">
                    <asp:ListItem>9 Sep 2021 #324xxx</asp:ListItem>
                </asp:ListBox>
                <br />
                <asp:Button ID="btnCancelOrder" runat="server" Text="Cancel order" />
            </td>
            <td>Order number:
                <asp:Label ID="Label1" runat="server" Text="lblOrderNo"></asp:Label>
                <br />
                Customer name:
                <asp:Label ID="Label2" runat="server" Text="lblOrderNo"></asp:Label>
                <br />
                <asp:ListBox ID="lsOrdersStatus" runat="server" Height="307px" Width="327px"></asp:ListBox>
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" />
                <br />
                <asp:Button ID="btnSubmit" runat="server" Text="Processing" />
                <br />
                <asp:Button ID="btnSubmit0" runat="server" Text="Ready" />
                <br />
                <asp:Button ID="btnSubmit1" runat="server" Text="Fulfilled" />
                <br />
                <asp:Button ID="btnSubmit2" runat="server" Text="Disregarded" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
