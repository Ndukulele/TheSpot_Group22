<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="EmployeeSignUp.aspx.cs" Inherits="TheSpotGroup22.EmployeeSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class ="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                                <div class="col">
                                    <centre>
                                        <img width="100px" src="img/employee.png" />
                                    </centre>
                                 </div>
                        </div>

                        <div class="row">
                                <div class="col">
                                    <centre>
                                        <h3>Employee Registration</h3>
                                    </centre>
                                 </div>
                        </div>

                        <div class="row">
                                <div class="col">
                                    <hr />
                                 </div>
                        </div>

                        <div class="row">
                                <div class="col-md-6">
                                    <label> First Name </label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtFirstName" runat="server" placeholder="First Name"></asp:TextBox>
                                    </div>
                                    <h2>

                                    </h2>
                                    
                                </div>

                                <div class="col-md-6">
                                    <label> Surname </label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtSurname" runat="server" placeholder="Surname Name"></asp:TextBox>
                                    </div>
                                    <h2>

                                    </h2>
                                    
                                </div>

                                <div class="col-md-6">
                                    <label> Date of Birth</label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtDateOfBirth" runat="server" placeholder="dd-mm-yyyy" TextMode="Date"></asp:TextBox>
                                    </div>
                                    <h2>

                                    </h2>
                                    
                                 </div>
                                 <div class="col-md-6">
                                    <label> Phone Number </label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtPhoneNumber" runat="server" placeholder="Phone Number" TextMode="Number"></asp:TextBox>
                                    </div>
                                    <h2>

                                    </h2>
                                    
                                </div>
                                  
                        </div>

                        <div class="row">
                                

                                <div class="col-md-6">
                                    <label> Email Address</label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtEmailAdress" runat="server" placeholder="Email Address" TextMode="Email"></asp:TextBox>
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
                                  
                        </div>
                        <div class="row">
                                

                                <div class="col-md-6">
                                    <label> Confirm Password</label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtConfirmPassword" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <h2>

                                    </h2>
                                    
                                 </div>
                                  
                        </div>

                        <div class="row">
                                <div class="col">
                                    
                                    <div class="form-group d-grid g-2">
                                        <asp:Button class="btn btn-primary btn-block" ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click"  />
                                    </div>
                                    
                                    <h2>

                                    </h2>
                                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                    
                                 </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
