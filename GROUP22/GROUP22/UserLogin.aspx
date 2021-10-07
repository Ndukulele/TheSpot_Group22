<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="GROUP22.UserLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class ="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                                <div class="col">
                                    <centre>
                                        <img width="150px" src="img/prof.png" />
                                    </centre>
                                 </div>
                        </div>

                        <div class="row">
                                <div class="col">
                                    <centre>
                                        <h3>Customer Login</h3>
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
                                    <label> Email Address</label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtEmail" runat="server" placeholder="Email Address" TextMode="Email"></asp:TextBox>
                                    </div>
                                    <h2>

                                    </h2>
                                    <label> Password</label>
                                    <h2>

                                    </h2>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <h2>

                                    </h2>
                                    
                                    <div class="form-group d-grid g-2">
                                        <asp:Button class="btn btn-primary btn-block" ID="btnLogin" runat="server" Text="Login" />
                                    </div>
                                    <div class="form-group">
                                        <asp:CheckBox ID="cbRememberMe" runat="server" />
                                        <label>Remember Me</label>
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
