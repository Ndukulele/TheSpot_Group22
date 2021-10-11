<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="CustomerInfo.aspx.cs" Inherits="TheSpotGroup22.CustomerInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2 style="text-align:center">
            Customer Information   
        </h2>
        
        <br /><br />
        <asp:Label ID="Label1" runat="server" Text="Search: "></asp:Label>
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        <br /><br />
        <asp:GridView ID="gvSCustomerInfo" runat="server" AutoGenerateColumns="False" BackColor="#FF3300" Font-Bold="True" Height="70px" ShowFooter="True" Width="1100px" EmptyDataText="No Data" DataKeyNames="customerId" OnRowDeleting="gvSCustomerInfo_RowDeleting">
            <Columns>
                <asp:BoundField DataField="customerId" HeaderText="customerID">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="customerName" HeaderText="Name">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="customerSurname" HeaderText="Surname">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="phoneNumber" HeaderText="Phone Number">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="email" HeaderText="Email Address">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="dateOfBirth" HeaderText="Date Of Birth">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField DeleteText="Delete" ShowDeleteButton="True">
                <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>
            </Columns>
            <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#660066" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle Width="50px" />
        </asp:GridView>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
