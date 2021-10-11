<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="Bookings.aspx.cs" Inherits="TheSpotGroup22.Bookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2 style="text-align:center">
            Bookings   
        </h2>
        
        <br /><br />
        
        <asp:GridView ID="gvBookings" runat="server" AutoGenerateColumns="False" BackColor="#FF3300" Font-Bold="True" Height="70px" ShowFooter="True" Width="1100px" EmptyDataText="No Data" DataKeyNames="bookId" OnSelectedIndexChanged="gvBookings_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="bookId" HeaderText="Booking ID">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="tableNo" HeaderText="Table Number">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="totalPeople" HeaderText=" Number of People">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="bookingDate" HeaderText="Booked Date" DataFormatString = "{0:dd/MM/yyyy}">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="timeIn" HeaderText="Time In">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="timeOut" HeaderText="Time Out">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#660066" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle Width="50px" />
        </asp:GridView>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        <br /><br />
        <br /><br />
    </div>
</asp:Content>
