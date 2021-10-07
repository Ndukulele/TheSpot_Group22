<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="GROUP22.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2 style="text-align:center">
            You have the following product in your cart   
        </h2>
        <br /><br />
        <a href="Menu.aspx"> Continue to Shop</a>
        <br /><br />
        <asp:GridView ID="gvSCart" runat="server" AutoGenerateColumns="False" BackColor="#FF3300" Font-Bold="True" Height="70px" ShowFooter="True" Width="1100px" EmptyDataText="No Data" DataKeyNames="productId" >
            <Columns>
                <asp:BoundField DataField="productId" HeaderText="ProductID">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="image" HeaderText="ProductImage">
                    <ControlStyle Height="50px" Width="50px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:ImageField>
                <asp:BoundField DataField="productName" HeaderText="ProductName">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="productPrice" HeaderText="ProductPrice">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="quantity" HeaderText="Quantity">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="totalPrice" HeaderText="TotalPrice">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField DeleteText="Remove" ShowDeleteButton="True">
                <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>
            </Columns>
            <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#660066" ForeColor="White" />
        </asp:GridView>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Total Amount: " align="right"></asp:Label>
        <asp:Label ID="lblTotalAmount" runat="server" Text="Label" Width="100px"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnCheckOut" runat="server" BorderColor="#FF9900" BackColor="#CC0099" Font-Bold="True" Text="Check Out" Width="103px" /><br />
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
