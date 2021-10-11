<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="GROUP22.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="reportId" DataSourceID="SqlDataSource2" OnRowDeleting="gdRowDeleting">
        <Columns>
            <asp:BoundField DataField="reportId" HeaderText="reportId" InsertVisible="False" ReadOnly="True" SortExpression="reportId" />
            <asp:BoundField DataField="orderId" HeaderText="orderId" SortExpression="orderId" />
            <asp:BoundField DataField="productId" HeaderText="productId" SortExpression="productId" />
            <asp:BoundField DataField="customerId" HeaderText="customerId" SortExpression="customerId" />
            <asp:BoundField DataField="employeeId" HeaderText="employeeId" SortExpression="employeeId" />
            <asp:BoundField DataField="productName" HeaderText="productName" SortExpression="productName" />
            <asp:BoundField DataField="productPrice" HeaderText="productPrice" SortExpression="productPrice" />
            <asp:BoundField DataField="productQuantity" HeaderText="productQuantity" SortExpression="productQuantity" />
            <asp:BoundField DataField="totalPrice" HeaderText="totalPrice" SortExpression="totalPrice" />
            <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
            <asp:BoundField DataField="dateOfOrder" HeaderText="dateOfOrder" SortExpression="dateOfOrder" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TableReports]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM TableReports WHERE (reportId = @original_reportId) AND (orderId = @original_orderId OR orderId IS NULL AND @original_orderId IS NULL) AND (productId = @original_productId OR productId IS NULL AND @original_productId IS NULL) AND (customerId = @original_customerId OR customerId IS NULL AND @original_customerId IS NULL) AND (employeeId = @original_employeeId OR employeeId IS NULL AND @original_employeeId IS NULL) AND (productName = @original_productName OR productName IS NULL AND @original_productName IS NULL) AND (productPrice = @original_productPrice OR productPrice IS NULL AND @original_productPrice IS NULL) AND (productImage = @original_productImage OR productImage IS NULL AND @original_productImage IS NULL) AND (productQuantity = @original_productQuantity OR productQuantity IS NULL AND @original_productQuantity IS NULL) AND (totalPrice = @original_totalPrice OR totalPrice IS NULL AND @original_totalPrice IS NULL) AND (status = @original_status OR status IS NULL AND @original_status IS NULL) AND (dateOfOrder = @original_dateOfOrder OR dateOfOrder IS NULL AND @original_dateOfOrder IS NULL)" InsertCommand="INSERT INTO [TableReports] ([orderId], [productId], [customerId], [employeeId], [productName], [productPrice], [productImage], [productQuantity], [totalPrice], [status], [dateOfOrder]) VALUES (@orderId, @productId, @customerId, @employeeId, @productName, @productPrice, @productImage, @productQuantity, @totalPrice, @status, @dateOfOrder)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [TableReports] SET [orderId] = @orderId, [productId] = @productId, [customerId] = @customerId, [employeeId] = @employeeId, [productName] = @productName, [productPrice] = @productPrice, [productImage] = @productImage, [productQuantity] = @productQuantity, [totalPrice] = @totalPrice, [status] = @status, [dateOfOrder] = @dateOfOrder WHERE [reportId] = @original_reportId AND (([orderId] = @original_orderId) OR ([orderId] IS NULL AND @original_orderId IS NULL)) AND (([productId] = @original_productId) OR ([productId] IS NULL AND @original_productId IS NULL)) AND (([customerId] = @original_customerId) OR ([customerId] IS NULL AND @original_customerId IS NULL)) AND (([employeeId] = @original_employeeId) OR ([employeeId] IS NULL AND @original_employeeId IS NULL)) AND (([productName] = @original_productName) OR ([productName] IS NULL AND @original_productName IS NULL)) AND (([productPrice] = @original_productPrice) OR ([productPrice] IS NULL AND @original_productPrice IS NULL)) AND (([productImage] = @original_productImage) OR ([productImage] IS NULL AND @original_productImage IS NULL)) AND (([productQuantity] = @original_productQuantity) OR ([productQuantity] IS NULL AND @original_productQuantity IS NULL)) AND (([totalPrice] = @original_totalPrice) OR ([totalPrice] IS NULL AND @original_totalPrice IS NULL)) AND (([status] = @original_status) OR ([status] IS NULL AND @original_status IS NULL)) AND (([dateOfOrder] = @original_dateOfOrder) OR ([dateOfOrder] IS NULL AND @original_dateOfOrder IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_reportId" Type="Int32" />
            <asp:Parameter Name="original_orderId" Type="Int32" />
            <asp:Parameter Name="original_productId" Type="Int32" />
            <asp:Parameter Name="original_customerId" Type="Int32" />
            <asp:Parameter Name="original_employeeId" Type="Int32" />
            <asp:Parameter Name="original_productName" Type="String" />
            <asp:Parameter Name="original_productPrice" Type="Decimal" />
            <asp:Parameter Name="original_productImage" Type="Object" />
            <asp:Parameter Name="original_productQuantity" Type="Int32" />
            <asp:Parameter Name="original_totalPrice" Type="Decimal" />
            <asp:Parameter Name="original_status" Type="String" />
            <asp:Parameter DbType="Date" Name="original_dateOfOrder" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="orderId" Type="Int32" />
            <asp:Parameter Name="productId" Type="Int32" />
            <asp:Parameter Name="customerId" Type="Int32" />
            <asp:Parameter Name="employeeId" Type="Int32" />
            <asp:Parameter Name="productName" Type="String" />
            <asp:Parameter Name="productPrice" Type="Decimal" />
            <asp:Parameter Name="productImage" Type="Object" />
            <asp:Parameter Name="productQuantity" Type="Int32" />
            <asp:Parameter Name="totalPrice" Type="Decimal" />
            <asp:Parameter Name="status" Type="String" />
            <asp:Parameter DbType="Date" Name="dateOfOrder" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="orderId" Type="Int32" />
            <asp:Parameter Name="productId" Type="Int32" />
            <asp:Parameter Name="customerId" Type="Int32" />
            <asp:Parameter Name="employeeId" Type="Int32" />
            <asp:Parameter Name="productName" Type="String" />
            <asp:Parameter Name="productPrice" Type="Decimal" />
            <asp:Parameter Name="productImage" Type="Object" />
            <asp:Parameter Name="productQuantity" Type="Int32" />
            <asp:Parameter Name="totalPrice" Type="Decimal" />
            <asp:Parameter Name="status" Type="String" />
            <asp:Parameter DbType="Date" Name="dateOfOrder" />
            <asp:Parameter Name="original_reportId" Type="Int32" />
            <asp:Parameter Name="original_orderId" Type="Int32" />
            <asp:Parameter Name="original_productId" Type="Int32" />
            <asp:Parameter Name="original_customerId" Type="Int32" />
            <asp:Parameter Name="original_employeeId" Type="Int32" />
            <asp:Parameter Name="original_productName" Type="String" />
            <asp:Parameter Name="original_productPrice" Type="Decimal" />
            <asp:Parameter Name="original_productImage" Type="Object" />
            <asp:Parameter Name="original_productQuantity" Type="Int32" />
            <asp:Parameter Name="original_totalPrice" Type="Decimal" />
            <asp:Parameter Name="original_status" Type="String" />
            <asp:Parameter DbType="Date" Name="original_dateOfOrder" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
