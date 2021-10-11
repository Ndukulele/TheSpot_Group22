using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace GROUP22
{
    public partial class EmployeeOrdersSite : System.Web.UI.Page
    {
        public string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Restaurant.mdf;Integrated Security=True";
        public SqlConnection conn;
        public SqlCommand comm;
        public SqlDataReader dr;
        public SqlDataAdapter da;
        public DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            //session/cookies for login/homepage

            conn = new SqlConnection(connStr);

            //master page control
            LinkButton linkHome = (LinkButton)Page.Master.FindControl("home");
            linkHome.Visible = true;
            LinkButton linkMenu = (LinkButton)Page.Master.FindControl("menu");
            linkMenu.Visible = false;
            LinkButton linkProduct = (LinkButton)Page.Master.FindControl("product");
            linkProduct.Visible = false;
            LinkButton linkOrder = (LinkButton)Page.Master.FindControl("order");
            linkOrder.Visible = false;
            LinkButton linkBook = (LinkButton)Page.Master.FindControl("booking");
            linkBook.Visible = true;
            LinkButton linkAccount = (LinkButton)Page.Master.FindControl("account");
            linkAccount.Visible = false;
            LinkButton linkReport = (LinkButton)Page.Master.FindControl("report");
            linkReport.Visible = false;

            LinkButton linkIn = (LinkButton)Page.Master.FindControl("login");
            linkIn.Visible = false;
            LinkButton linkUp = (LinkButton)Page.Master.FindControl("signup");
            linkUp.Visible = false;

            LinkButton linkLogout = (LinkButton)Page.Master.FindControl("linkLogout");
            linkLogout.Visible = true;
            //

            HttpCookie employeeCookie = Request.Cookies["employeeInfo"];

            if (employeeCookie != null)
            {
                //if empty populate list box
                if (lsOrders.Items.Count == 0)
                {
                    sqlQueries("SELECT orderId", "FROM TableOrderDetails", "listBox");

                    if (lsOrders.Items.Count != 0)
                    {
                        //assign selected orderNo and populate gridview and show buttons/labels
                        lsOrders.SelectedIndex = 0;
                        lblOrderNo.Text = lsOrders.SelectedValue.ToString();
                        lblOrderDetails.Text = "Order details";
                        lblOrderLabel.Visible = true;
                        lblOrderNo.Visible = true;
                        gdOrderStatus.Visible = true;
                        populateGridView();
                        enableButtons();
                    }
                    else
                    {
                        //if there are no orders display message and hide buttons/labels
                        lblOrderDetails.Text = "Seems like no one has placed an order yet";
                        lblOrderLabel.Visible = false;
                        lblOrderNo.Visible = false;
                        gdOrderStatus.Visible = false;
                        enableButtons();
                    }
                }
            }
            else
            {
                Response.Redirect("EmployeeLogin.aspx");
            }
        }

        public void populateGridView() //populate gridview
        {
       
            if (lsOrders.SelectedIndex >= 0)
            {
                sqlQueries(
                    "SELECT status as 'Order status', " +
                    "b.customerName as 'Customer name', " +
                    "FORMAT(dateOfOrder, 'yyyy-MM-dd hh:mm') as 'Date order placed', " +
                    "productName as 'Product name', " +
                    "productPrice as 'Product price', " +
                    "productQuantity as 'Product quantity', " +
                    "totalPrice as 'Total price'",
                    "FROM TableOrderDetails a " +
                    "INNER JOIN TableCustomers b ON a.customerId = b.customerId " +
                    $"WHERE a.orderId = '{lsOrders.SelectedValue.ToString().Substring(6)}'",
                    "gridView");
            }
        }

        public void enableButtons()
        {
            //evaluate order status and show/hide relevant buttons
            if(gdOrderStatus.Rows.Count != 0)
            {
                string status = gdOrderStatus.Rows[0].Cells[1].Text;

                if(status == "Placed")
                {
                    btnOrderProcessing.Enabled = true;
                    btnOrderReady.Enabled = false;
                    btnOrderFulfilled.Enabled = false;
                }
                else if(status == "Processing")
                {
                    btnOrderProcessing.Enabled = false;
                    btnOrderReady.Enabled = true;
                    btnOrderFulfilled.Enabled = false;
                }
                else if (status == "Ready")
                {
                    btnOrderProcessing.Enabled = false;
                    btnOrderReady.Enabled = false;
                    btnOrderFulfilled.Enabled = true;
                }
                else
                {
                    btnOrderProcessing.Enabled = false;
                    btnOrderReady.Enabled = false;
                    btnOrderFulfilled.Enabled = false;
                }
            }
            else
            {
                btnOrderProcessing.Enabled = false;
                btnOrderReady.Enabled = false;
                btnOrderFulfilled.Enabled = false;
            }
        }

        protected void lsOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            //assign selected orderNo and populate gridview and show buttons/labels
            lblOrderNo.Text = lsOrders.SelectedValue.ToString();

            populateGridView();
            enableButtons();
        }

        protected void btnOrderProcessing_Click(object sender, EventArgs e)
        {
            //sql update query
            sqlQueries("UPDATE TableOrderDetails", "SET status = 'Processing'" +
                $" WHERE orderId = '{lsOrders.SelectedValue.ToString().Substring(6)}'", 
                "update");

            populateGridView();
            enableButtons();
        }

        protected void btnOrderReady_Click(object sender, EventArgs e)
        {
            //sql update query
            sqlQueries("UPDATE TableOrderDetails", "SET status = 'Ready'" +
                $" WHERE orderId = '{lsOrders.SelectedValue.ToString().Substring(6)}'",
                "update");

            populateGridView();
            enableButtons();
        }

        protected void btnOrderFulfilled_Click(object sender, EventArgs e)
        {
            //sql update query
            sqlQueries("UPDATE TableOrderDetails", "SET status = 'Fulfilled'" +
                $" WHERE orderId = '{lsOrders.SelectedValue.ToString().Substring(6)}'",
                "update");

            populateGridView();
            enableButtons();

            //sql insert query into reports, sql delete query, update lisbox
            sqlQueries("INSERT INTO TableReports(orderId, customerId, productId, employeeId, status, " +
                "productName, productPrice, productImage, productQuantity, totalPrice, dateOfOrder)",
                "SELECT orderId, customerId, productId, employeeId, status, productName, productPrice, productImage, " +
                "productQuantity, totalPrice, dateOfOrder " +
                "FROM TableOrderDetails " +
                $"WHERE orderId = '{lsOrders.SelectedValue.ToString().Substring(6)}'",
                "insert");

            sqlQueries("DELETE ", 
                $"FROM TableOrderDetails WHERE status = 'Fulfilled'",
                "delete");

            lsOrders.SelectedValue.Remove(0);
            lsOrders.Items.Clear();
            sqlQueries("SELECT orderId", "FROM TableOrderDetails", "listBox");

            //assign selected orderNo and populate gridview and show buttons/labels
            if (lsOrders.Items.Count != 0)
            {
                lsOrders.SelectedIndex = 0;
                lblOrderNo.Text = lsOrders.SelectedValue.ToString();
                populateGridView();
                enableButtons();
            }
            else
            {
                lblOrderDetails.Text = "Seems like there are no more orders";
                lblOrderLabel.Visible = false;
                lblOrderNo.Visible = false;
                gdOrderStatus.Visible = false;
                enableButtons();
            }
        }

        //universal sql statements begin
        public void sqlQueries(string query, string condition, string action)
        {
            conn.Open();

            string sql = $"{query} {condition}";

            comm = new SqlCommand(sql, conn);

            sqlActions(action);

            conn.Close();
        }

        public void sqlActions(string action)
        {
            if (action == "listBox") //if listbox
            {
                dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    lsOrders.Items.Add("Order#" + dr.GetValue(0).ToString());
                }
            }
            else if (action == "gridView") //if gridview
            {
                da = new SqlDataAdapter();
                ds = new DataSet();

                da.SelectCommand = comm;
                da.Fill(ds);

                gdOrderStatus.DataSource = ds;
                gdOrderStatus.DataBind();
            }
            else if(action == "update")
            {
                da = new SqlDataAdapter();

                da.UpdateCommand = comm;
                da.UpdateCommand.ExecuteNonQuery();
            }
            else if(action == "delete")
            {
                da = new SqlDataAdapter();

                da.DeleteCommand = comm;
                da.DeleteCommand.ExecuteNonQuery();
            }
            else if(action == "insert")
            {
                da = new SqlDataAdapter();

                da.InsertCommand = comm;
                da.InsertCommand.ExecuteNonQuery();
            }
        }

        protected void gdOrderStatus_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            sqlQueries("DELETE ",
                $"FROM TableOrderDetails WHERE orderId = '{lsOrders.SelectedValue.ToString().Substring(6)}'",
                "delete");

            lsOrders.SelectedValue.Remove(0);
            lsOrders.Items.Clear();
            sqlQueries("SELECT orderId", "FROM TableOrderDetails", "listBox");

            //assign selected orderNo and populate gridview and show buttons/labels
            if (lsOrders.Items.Count != 0)
            {
                lsOrders.SelectedIndex = 0;
                lblOrderNo.Text = lsOrders.SelectedValue.ToString();
                populateGridView();
                enableButtons();
            }
            else
            {
                lblOrderDetails.Text = "Seems like there are no more orders";
                lblOrderLabel.Visible = false;
                lblOrderNo.Visible = false;
                gdOrderStatus.Visible = false;
                enableButtons();
            }
        }
        //universal sql statements end
    }
}