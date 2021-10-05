<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="CustomerOrderInquiry.aspx.cs" Inherits="GROUP22.CustomerOrderInquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }
        .auto-style2 {
            height: 21px;
            width: 235px;
        }
        .auto-style3 {
            width: 235px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style2">Order Inquiries</td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style3">Your Orders<br />
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
                <asp:ListBox ID="lsOrdersStatus" runat="server" Height="307px" Width="327px"></asp:ListBox>
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" />
                <br />
                <asp:TextBox ID="txtInquiry" runat="server" Height="70px" TextMode="MultiLine" Width="325px"></asp:TextBox>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit inquiry" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
