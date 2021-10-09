<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeSite.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TheSpotGroup22.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class ="row">
            <div class="col-md-15 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                                <div class="col-md-6" style="background-color:aqua; text-align:center"  >
                                    <label> Orders </label>
                                    <div class="form-group">
                                        <asp:Label ID="lblOrders" runat="server" Text="0"></asp:Label>
                                    </div>
                                    <h2>

                                    </h2>
                                    
                                </div>

                                <div class="col-md-6" style="background-color:chartreuse; text-align:center">
                                    <label> Products</label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:Label ID="lblProduct" runat="server" Text="0"></asp:Label>
                                    </div>
                                    <h2>

                                    </h2>
                                    
                                 </div>
                                  
                        </div>

                        <div class="row">
                                <div class="col-md-6" style="background-color:chocolate; text-align:center"">
                                    <label> Customers </label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:Label ID="lblCustomers" runat="server" Text="0"></asp:Label>
                                    </div>
                                    <h2>

                                    </h2>
                                    
                                </div>

                                <div class="col-md-6" style="background-color:crimson; text-align:center"">
                                    <label> Employees</label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:Label ID="lblEployees" runat="server" Text="0"></asp:Label>
                                    </div>
                                    <h2>

                                    </h2>
                                    
                                 </div>
                                  
                        </div>
                        <div class="row">
                                <div class="col-md-6" style="background-color:gold; text-align:center"">
                                    <label> Enquiries </label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:Label ID="lblEnquiries" runat="server" Text="0"></asp:Label>
                                    </div>
                                    <h2>

                                    </h2>
                                    
                                </div>

                                <div class="col-md-6" style="background-color:olive; text-align:center">
                                    <label> Bookings</label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:Label ID="lblBookings" runat="server" Text="0"></asp:Label>
                                    </div>
                                    <h2>

                                    </h2>
                                    
                                 </div>
                                  
                        </div>
                    </div>
                </div>
            </div>
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
