<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="TheSpotGroup22.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col" style="text-align:center">
        <centre>

            <h3>Profile</h3>
        </centre>
    </div>
     <div class="container">
        <div class ="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                                <div class="col">
                                    <centre>
                                        <h3>Customer Details</h3>
                                    </centre>
                                 </div>
                        </div>

                        <div class="row">
                                <div class="col">
                                    <hr />
                                 </div>
                        </div>

                        <div class="row">
                                <div class="col">
                                    <label> First Name</label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtFName" runat="server" ></asp:TextBox>
                                    </div>
                                    <h2>

                                    </h2>
                                    <label> Surname</label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtSurname" runat="server" ></asp:TextBox>
                                    </div>
                                    <h2>

                                    </h2>
                                    <label> Email Address</label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID= "txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                                    </div>
                                    <h2>

                                    </h2>
                                    <label> Phone Number</label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TxtPNumber" runat="server"  TextMode="Number"></asp:TextBox>
                                    </div>
                                    <h2>

                                    </h2>
                                    <label> Password</label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtpassWord" runat="server"></asp:TextBox>
                                    </div>
                                    <h2>

                                    </h2>
                                    <label> Date of Birth </label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtDBirth" runat="server"></asp:TextBox>
                                    </div>
                                    <h2>

                                    </h2>
                                    
                                    

                                 </div>
                        </div>
                        <div class="row">
                                <div class="col">
                                    <centre>
                                        <h3>Change Passord</h3>
                                    </centre>
                                 </div>
                        </div>
                        <div class="row">
                                <div class="col">
                                    <div class="col-md-6">
                                    <label> Old Password </label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtOldP" runat="server" placeholder="Old Password" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <h2>

                                    </h2>
                                    
                                </div>

                                    <div class="col-md-6">
                                    <label> Create Password </label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtCreatePassword" runat="server" placeholder="Create Password" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <h2>

                                    </h2>
                                    
                                </div>

                                <div class="col-md-6">
                                    <label> Confirm Password</label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtConfirmPassword" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <h2>

                                    </h2>
                                    <div class="form-group d-grid g-2">
                                        <asp:Button class="btn btn-primary btn-block" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                    </div>
                                    <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
                                    
                                 </div>
                                 </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
