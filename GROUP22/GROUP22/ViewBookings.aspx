<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="ViewBookings.aspx.cs" Inherits="TheSpotGroup22.ViewBookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="gvBookings" runat="server" AutoGenerateColumns="False" BackColor="#FF3300" Font-Bold="True" Height="70px" ShowFooter="True" Width="1100px" EmptyDataText="No Data" DataKeyNames="bookId" OnRowDeleting="GridView1_RowDeleting">
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
                <asp:CommandField HeaderText="Remove booking" ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#660066" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle Width="50px" />
        </asp:GridView>

</asp:Content>
