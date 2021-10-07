<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="GROUP22.Items" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Menu.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
            Food Item
        </h3>
    </div>

    <table id="tables" style="width: 50%; margin-left:auto; margin-right:auto; border:1px solid #ddd">
        <tr>
            <td>
                <asp:Repeater ID="rptFill" runat="server">
                    <ItemTemplate>
                        <table style="width: 100%; padding: 0; margin:0">
                            <tr>
                                <th style="text-align:center;">
                                    <b>
                                        Item Details
                                    </b>
                                </th>
                            </tr>
                            <tr>
                                <td align="centre">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Image ID="image" height="100px" width="100px" runat="server" ImageUrl='<%# Eval("image") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>&nbsp;
                                                <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("productName") %>'></asp:Label>
                                                <br /><br />
                                                
                                                <asp:Label ID="Label2" runat="server" Text="Price: "></asp:Label>&nbsp;
                                                <asp:Label ID="lblProductPrice" runat="server" Text='<%# Eval("productPrice") %>'></asp:Label>
                                                <br /><br />

                                                <asp:Label ID="Label3" runat="server" Text="Description: "></asp:Label>&nbsp;
                                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("productDescription") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Quantity: "></asp:Label>
                            <asp:TextBox ID="txtQuantity" runat="server" TextMode="Number" Text="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" BackColor="OrangeRed" Style="border: solid 1px #ddd" Height="40px" Width="200px" />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblError" runat="server" Text=" "></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
