<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="EmployeeOrdersSite.aspx.cs" Inherits="GROUP22.EmployeeOrdersSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 17px;
    }
    .auto-style3 {
        width: 214px;
    }
        .auto-style4 {
            width: 185px;
        }
        .auto-style5 {
            width: 185px;
            font-size: xx-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style5"><strong>Order Site</strong></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style4"><strong>Orders</strong><br />
                Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Order Number<br />
                <asp:ListBox ID="lsOrders" runat="server" Height="334px" Width="221px" AutoPostBack="True" OnSelectedIndexChanged="lsOrders_SelectedIndexChanged">
                </asp:ListBox>
                <br />
                <asp:Button ID="btnCancelOrder" runat="server" Text="Cancel order" OnClick="btnCancelOrder_Click" />
            </td>
            <td class="auto-style3"><strong>Order queries</strong><br />
                Order number:
                <asp:Label ID="lblOrderNo" runat="server" Text="lblOrderNo"></asp:Label>
                <br />
                Customer name:
                <asp:Label ID="lblCustomerName" runat="server" Text="lblCustomerName"></asp:Label>
                <br />
                <asp:GridView ID="gdOrderStatus" runat="server">
                </asp:GridView>
                <br />
                <asp:Button ID="btnOrderProcessing" runat="server" Text="Processing" OnClick="btnOrderProcessing_Click" />
                <br />
                <br />
                <asp:Button ID="btnOrderReady" runat="server" Text="Ready" Height="29px" OnClick="btnOrderReady_Click" Width="99px" />
                <br />
                <br />
                <asp:Button ID="btnOrderFulfilled" runat="server" Text="Fulfilled" Width="99px" Height="29px" OnClick="btnOrderFulfilled_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
