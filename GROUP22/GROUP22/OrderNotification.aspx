<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="OrderNotification.aspx.cs" Inherits="GROUP22.OrderNotification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td>
            <asp:Label ID="lblWelcomeToOrderNotification" runat="server" Font-Size="Larger" Text="Welcome to the order notification page."></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
            <asp:Label ID="lblOrderMessage" runat="server" ForeColor="#3333CC" Text="lblMessage"></asp:Label>
                <br />
                <br />
            <asp:Label ID="lblThankYouMessage" runat="server" Font-Size="Larger" ForeColor="Black" Text="Thank you for using THE SPOT food service."></asp:Label>
                <br />
                <br />
        <asp:Button ID="btnDone" runat="server" OnClick="Button2_Click" style="height: 26px" Text="Done" BackColor="#009900" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
