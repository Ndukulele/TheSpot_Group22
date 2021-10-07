<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="TableBookings.aspx.cs" Inherits="GROUP22.TableBookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Menu.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>
            Table Booking
        </h3>
    </div>
    <table id="tables" style="border: 1px solid #ddd; margin-left: auto; margin-right: auto">
        <tr>
            <td valign="top" style="border: 1px solid #ddd; width:50%">
                <table style="height: 100%; width: 100%">
                    <tr>
                        <th align="centre">
                            <b>
                                Available Times
                            </b>
                        </th>
                    </tr>
                    <tr>
                        <td align="centre">
                            <asp:Label ID="lblMessage" runat="server" Text="Bookings"></asp:Label>
                            <asp:Label ID="lblDate" runat="server" Font-Bold="true"></asp:Label>
                            <asp:Label ID="lblTable" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="centre">
                            <<asp:RadioButtonList ID="rblTableNum" runat="server" Visible="False">
                                <asp:ListItem>Table No 1</asp:ListItem>
                                <asp:ListItem>Table No 2</asp:ListItem>
                                <asp:ListItem>Table No 3</asp:ListItem>
                                <asp:ListItem>Table No 4</asp:ListItem>
                                <asp:ListItem>Table No 5</asp:ListItem>
                                <asp:ListItem>Table No 6</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                                <asp:Button ID="btnSubmitBooking" runat="server" Text="Book" BackColor="Lavender"
                                Style="border: solid 1px #ddd" Height="40px" Width="200px" >
                        </td>
                    </tr>
                </table>
            </td>
            <td valign ="top" style="width: 50%">
                <table>
                    <tr>
                        <th align="centre" colspan="2">
                            <b>
                                Make Bookings
                            </b>

                        </th>
                    </tr>
                    <tr style="border-bottom: solid 1px #ddd">
                        <td>
                            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                        </td>

                        <td valign="top">
                            Time in:<br />
                            <asp:DropDownList ID="ddlTimeIn" Width="250px" BackColor="Purple" ForeColor="Orange" Height="35px" runat="server">
                                <asp:ListItem Value="-1"> Select Time You gonna arrive at The Spot </asp:ListItem>
                                <asp:ListItem Value="0"> 09:00 am </asp:ListItem>
                                <asp:ListItem Value="1"> 10:00 am </asp:ListItem>
                                <asp:ListItem Value="2"> 11:00 am </asp:ListItem>
                                <asp:ListItem Value="3"> 12:00 pm </asp:ListItem>
                                <asp:ListItem Value="4"> 13:00 pm </asp:ListItem>
                                <asp:ListItem Value="5"> 14:00 pm </asp:ListItem>
                                <asp:ListItem Value="6"> 15:00 pm </asp:ListItem>
                                <asp:ListItem Value="7"> 16:00 pm </asp:ListItem>
                                <asp:ListItem Value="8"> 17:00 pm </asp:ListItem>
                                <asp:ListItem Value="9"> 18:00 pm </asp:ListItem>
                                <asp:ListItem Value="10"> 19:00 pm </asp:ListItem>

                            </asp:DropDownList>

                            <br /><br /><br />

                            Time Out:<br />
                            <asp:DropDownList ID="ddlTimeOut" Width="250px" BackColor="Purple" ForeColor="Orange" Height="35px" runat="server">
                                <asp:ListItem Value="-1"> Select Time You gonna leave The Spot </asp:ListItem>
                                <asp:ListItem Value="0"> 09:00 am </asp:ListItem>
                                <asp:ListItem Value="1"> 10:00 am </asp:ListItem>
                                <asp:ListItem Value="2"> 11:00 am </asp:ListItem>
                                <asp:ListItem Value="3"> 12:00 pm </asp:ListItem>
                                <asp:ListItem Value="4"> 13:00 pm </asp:ListItem>
                                <asp:ListItem Value="5"> 14:00 pm </asp:ListItem>
                                <asp:ListItem Value="6"> 15:00 pm </asp:ListItem>
                                <asp:ListItem Value="7"> 16:00 pm </asp:ListItem>
                                <asp:ListItem Value="8"> 17:00 pm </asp:ListItem>
                                <asp:ListItem Value="9"> 18:00 pm </asp:ListItem>
                                <asp:ListItem Value="10"> 19:00 pm </asp:ListItem>

                            </asp:DropDownList>


                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <br />
                            <asp:Label ID="Label1" runat="server" Text="No. of People: "></asp:Label>
                            <asp:TextBox ID="txtNumOfPeople" runat="server" TextMode="Number" Text ="1"></asp:TextBox>
                            <br /><br />

                            <div style="width: 450px">
                                <asp:Button ID="btnCheckAvailability" runat="server" Text="Check availability" BackColor="Lavender"
                                Style="border: solid 1px #ddd" Height="40px" Width="200px"/>

                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </tr>
    </table>
</asp:Content>
