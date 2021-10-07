<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="GROUP22.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Menu.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="centre">
        <h3>
            Food Menu
        </h3>
    </div>
    <table id="tables" style="margin-left:0%; margin-right: 0%">
        <td>
            <div id="orderDetailsDiv">
                <table>
                    <tr>
                        <th style="text-align:center">
                            Other Information
                        </th>
                    </tr>
                    <tr>
                        <td>
                            Number of items added:&nbsp; <asp:Label ID="lblNoOfItems" Font-Bold="true" runat="server" Text="0"></asp:Label>&nbsp
                            items <br />
                            Total Price: &nbsp; <b>R</b>
                            <asp:Label ID="lblTotalPrice" runat="server" Font-Bold="true" Text="0"></asp:Label>
                            <asp:Button ID="btnViewMyOrder" runat="server" Text="View my order" />
                        </td>
                    </tr>
                </table>
            </div>
        </td>
        <tr>
            <td colspan="2" align="centre">
                <br /><br /><br />
                <div id="menuDiv">
                    <table>
                        <tr>
                            <th style="text-align:center">
                                Our Menu
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:Repeater ID="rpt" runat="server">
                                    <ItemTemplate>
                                        <table id="InLine">
                                            <tr>
                                                <td>
                                                    <a href="Meal.aspx?id=<%# Eval("productId") %>">
                                                    <img alt="" height="100px" width="100px" src='<%# Eval("image") %>' /></a>
                                                    
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
