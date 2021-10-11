<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="RegistrationNotification.aspx.cs" Inherits="GROUP22.RegistrationNotification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
            <asp:Label ID="lblWelcome" runat="server" Font-Size="Larger" Text="Welcome to the registration notification page."></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
            <asp:Label ID="lblRegistrationMessage" runat="server" ForeColor="#3333CC" Text="You have successfully registered an account."></asp:Label>
                <br />
            <asp:Button ID="btnLogin" runat="server" BackColor="#0066FF" CssClass="auto-style1" Height="38px" Text="Login" Width="145px" OnClick="Button1_Click" />
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
