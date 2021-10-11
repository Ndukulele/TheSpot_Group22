<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="TheSpotGroup22.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Menu.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="centre">
        <h3>Food Menu
        </h3>
    </div>
    <table id="tables" style="margin-left: 0%; margin-right: 0%">
        <td>
            <div id="orderDetailsDiv">
                <table>
                    </table>
                            <asp:Label ID="lblNoOfItems" Font-Bold="True" runat="server"></asp:Label>
            </div>
        </td>
        <tr>
            <td colspan="2" align="centre">
                <br />
                <br />
                <br />
                <div id="menuDiv">
                    <asp:Label ID="Label1" runat="server" Text="Search: "></asp:Label>
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    <br />
                <br />
                    <table>
                        <tr>
                            <th style="text-align: center">Our Menu
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:Repeater ID="rpt" runat="server" OnItemCommand="rpt_ItemCommand">
                                    <ItemTemplate>
                                        <table id="InLine">
                                            <tr>
                                                <td>
                                                    <a href="FoodItems.aspx?id=<%# Eval("productId") %>">
                                                        <img alt="" height="100px" width="100px" src='<%# Eval("productImage") %>' /></a>

                                                </td>
                                                <td>
                                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("productName") %>'></asp:Label><br />
                                                    R<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("productPrice") %>'></asp:Label><br />


                                                </td>

                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
