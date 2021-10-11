<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="TheSpotGroup22.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
        }
    </style>
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
                                        <img width="100px" src="img/prof.png" />
                                    </centre>
                                 </div>
                        </div>

                        <div class="row">
                                <div class="col">
                                    <centre>
                                        <h3>Customer Registration</h3>
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

                                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtFirstName" CssClass="auto-style1" ErrorMessage="Required"></asp:RequiredFieldValidator>

                                    </h2>
                                    
                                </div>

                                <div class="col-md-6">
                                    <label> Surname </label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtSurname" runat="server" placeholder="Surname"></asp:TextBox>
                                        </div>
                                    <h2>

                                        <asp:RequiredFieldValidator ID="rfvSurname" runat="server" ControlToValidate="txtSurname" CssClass="auto-style1" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

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

                                        <asp:RequiredFieldValidator ID="rfvDob" runat="server" ControlToValidate="txtDateOfBirth" CssClass="auto-style1" ErrorMessage="Required"></asp:RequiredFieldValidator>

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

                                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhoneNumber" CssClass="auto-style1" ErrorMessage="Required"></asp:RequiredFieldValidator>

                                    </h2>
                                    
                                </div>
                                  
                        </div>

                        <div class="row">
                                

                                <div class="col-md-6">
                                    <label> Email Address</label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtEmailAddress" runat="server" placeholder="Email Address" TextMode="Email"></asp:TextBox>
                                        </div>
                                    <h2>

                                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmailAddress" CssClass="auto-style1" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailAddress" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

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

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCreatePassword" CssClass="auto-style1" ErrorMessage="Required"></asp:RequiredFieldValidator>

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

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtConfirmPassword" CssClass="auto-style1" ErrorMessage="Required"></asp:RequiredFieldValidator>
&nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match" ControlToCompare="txtCreatePassword" ControlToValidate="txtConfirmPassword" CssClass="auto-style1"></asp:CompareValidator>

                                    </h2>
                                    
                                 </div>
                                  
                        </div>

                        <div class="row">
                                <div class="col">
                                    
                                    
                                    
                                    <div class="form-group d-grid g-2">
                                        <asp:Button class="btn btn-primary btn-block" ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" />
                                    </div>
                                    
                                    <h2>

                                    </h2>
                                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label><br />
                                    <br />
                                 </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
