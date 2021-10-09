<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeSite.Master" AutoEventWireup="true" CodeBehind="EditMenu.aspx.cs" Inherits="TheSpotGroup22.EditMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2 style="text-align:center">
            Edit Menu   
        </h2>
        
        <br /><br />
        <asp:GridView ID="gvSMenu" runat="server" AutoGenerateColumns="False" BackColor="#FF3300" Font-Bold="True" Height="70px" ShowFooter="True" Width="1100px" EmptyDataText="No Data" DataKeyNames="productId" OnRowDeleting="gvSMenu_RowDeleting" OnRowCancelingEdit="gvSMenu_RowCancelingEdit" OnRowEditing="gvSMenu_RowEditing" OnRowUpdating="gvSMenu_RowUpdating">
            <Columns>
                <asp:BoundField DataField="productId" HeaderText="ProductID" ReadOnly="True">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="image" HeaderText="ProductImage" ReadOnly="True">
                    <ControlStyle Height="50px" Width="50px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:ImageField>
                <asp:BoundField DataField="productName" HeaderText="ProductName">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="productPrice" HeaderText="ProductPrice">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="productDescription" HeaderText="ProductIngredients">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField DeleteText="Remove" ShowDeleteButton="True">
                <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
            <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#660066" ForeColor="White" />
        </asp:GridView>
        <br />
        
        
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
