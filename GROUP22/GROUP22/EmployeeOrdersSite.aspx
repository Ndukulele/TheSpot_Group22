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
                Order number<br />
                <asp:ListBox ID="lsOrders" runat="server" Height="334px" Width="173px" AutoPostBack="True" OnSelectedIndexChanged="lsOrders_SelectedIndexChanged">
                </asp:ListBox>
            </td>
            <td class="auto-style3">
                <asp:Label ID="lblOrderDetails" runat="server" Text="Order details" Font-Bold="True"></asp:Label>
                <br />
                <asp:Label ID="lblOrderLabel" runat="server" Text="Order number:" Font-Bold="False"></asp:Label>
                &nbsp;<asp:Label ID="lblOrderNo" runat="server" Text="lblOrderNo" Font-Bold="True"></asp:Label>
                <br />
                <asp:GridView ID="gdOrderStatus" runat="server" ShowFooter="True" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" ForeColor="Blue" HorizontalAlign="Center">
                    <AlternatingRowStyle BorderWidth="1px" />
                    <Columns>
                        <asp:CommandField DeleteText="Cancel order" ShowDeleteButton="True" ShowHeader="True" />
                    </Columns>
                    <EditRowStyle BorderStyle="Solid" BorderWidth="1px" />
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BorderStyle="Solid" BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" BorderStyle="Solid" BorderWidth="1px" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
                <br />
                <br />
                <asp:Button ID="btnOrderProcessing" runat="server" Text="Processing" OnClick="btnOrderProcessing_Click" />
                <br />
                <br />
                <asp:Button ID="btnOrderReady" runat="server" Text="Ready" Height="29px" OnClick="btnOrderReady_Click" Width="99px" />
                <br />
                <br />
                <asp:Button ID="btnOrderFulfilled" runat="server" Text="Fulfilled" Width="99px" Height="29px" OnClick="btnOrderFulfilled_Click" />
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
