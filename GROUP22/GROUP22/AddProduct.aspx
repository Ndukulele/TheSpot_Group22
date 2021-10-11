<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="TheSpotGroup22.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .newStyle1 {
            color: #41464B;
        }
        .newStyle2 {
            color: #3DD5F3;
        }
        .newStyle3 {
            color: #3DD5F3;
        }
        .newStyle4 {
            padding: inherit;
            margin: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col" style="text-align:center">
        <centre>

            <h3>Edit Menu</h3>
        </centre>
    </div>
    <div class="container-fluid">
        <div class ="row">
            <div class="col-md-15 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                                <div class="col-md-10" style="text-align:center">
                                    <div class="col" style="text-align:center;">
                                        <centre>

                                            <h2 style="fon"><span class="newStyle2">Add New Item</span></h2>
                                        </centre>
                                 </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblItemName" runat="server" Text="Item Name:"></asp:Label>
                                        <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>
                                        <h2>

                                        </h2>
                                        <p>

                                        </p>
                                        <asp:Label ID="lblItemPrice" runat="server" Text="Item Price:"></asp:Label>
                                        <asp:TextBox ID="txtItemPrice" runat="server"></asp:TextBox>
                                        <h2>

                                        </h2>
                                        <p>

                                        </p>
                                        <asp:Label ID="lblInvre" runat="server" Text="Item Incredients:"></asp:Label>
                                        <asp:TextBox ID="txtIncredients" runat="server"></asp:TextBox>
                                        <br />
                                        <h2>

                                        </h2>
                                        <asp:Label ID="lblPic" runat="server" Text="Item Picture:"></asp:Label>
                                        <asp:FileUpload ID="flPic" BackColor="GreenYellow" runat="server" />
                                        <asp:Label ID="lblAdded" runat="server"></asp:Label>
                                        <h2>

                                        </h2>
                                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                        <h2>

                                        </h2>
                                        <p>

                                        </p>
                                        <asp:Button ID="btnAdd" style="background-color:crimson" runat="server" Text="Add" Height="35px" Width="157px" OnClick="btnAdd_Click"  />
                                        <h2>

                                        </h2>
                                        <p>

                                        </p>
                                        <asp:Button ID="btnDone" style="background-color:yellow" runat="server" Text="Done" Height="37px" Width="76px" OnClick="btnDone_Click" />

                                    </div>
                                    <h2>

                                    </h2>
                                    
                                </div>
   
                                 </div>
                                  
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
