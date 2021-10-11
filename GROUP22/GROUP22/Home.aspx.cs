using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace TheSpotGroup22
{
    public partial class Home : System.Web.UI.Page
    {
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Restaurant.mdf;Integrated Security=True";
       
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            //master page control
            LinkButton linkHome = (LinkButton)Page.Master.FindControl("home");
            linkHome.Visible = false;
            LinkButton linkMenu = (LinkButton)Page.Master.FindControl("menu");
            linkMenu.Visible = true;
            LinkButton linkProduct = (LinkButton)Page.Master.FindControl("product");
            linkProduct.Visible = true;
            LinkButton linkOrder = (LinkButton)Page.Master.FindControl("order");
            linkOrder.Visible = true;
            LinkButton linkBook = (LinkButton)Page.Master.FindControl("booking");
            linkBook.Visible = true;
            LinkButton linkAccount = (LinkButton)Page.Master.FindControl("account");
            linkAccount.Visible = true;
            LinkButton linkReport = (LinkButton)Page.Master.FindControl("report");
            linkReport.Visible = true;

            LinkButton linkIn = (LinkButton)Page.Master.FindControl("login");
            linkIn.Visible = false;
            LinkButton linkUp = (LinkButton)Page.Master.FindControl("signup");
            linkUp.Visible = false;

            LinkButton linkLogout = (LinkButton)Page.Master.FindControl("linkLogout");
            linkLogout.Visible = true;
            //

            HttpCookie employeeCookie = Request.Cookies["employeeInfo"];
            if (!IsPostBack)
            {
                if (employeeCookie == null)
                {

                    Response.Redirect("EmployeeLogin.aspx");
                }

            }

            noOf("customerId", "customer", "TableCustomers");
            noOf("employeeId", "employee", "TableEmployees");
            noOf("productId", "product", "TableMenu");
            noOf("orderId", "order", "TableOrderDetails");
            noOf("bookId", "book", "TableBookTable");
        }

        public void noOf(string Of, string label, string table)
        {
            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = $"SELECT count({Of}) From {table}";
                comm = new SqlCommand(sql, conn);

                string result = comm.ExecuteScalar().ToString();

                if(label == "customer")
                {
                    lblCustomers.Text = result;
                }
                else if (label == "employee")
                {
                    lblEployees.Text = result;
                }
                else if (label == "product")
                {
                    lblProduct.Text = result;
                }
                else if (label == "order")
                {
                    lblOrders.Text = result;
                }
                else if (label == "book")
                {
                    lblBookings.Text = result;
                }


                conn.Close();



            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
            }
        }

        public void noEmployees()
        {
            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "SELECT count(employeeId) From TableEmployees";
                comm = new SqlCommand(sql, conn);

                string employees = comm.ExecuteScalar().ToString();

                lblEployees.Text = employees;

                conn.Close();

            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
            }
        }

        public void noBoookings()
        {
            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "SELECT count(bookId) From TableBookTable";
                comm = new SqlCommand(sql, conn);

                string bookings = comm.ExecuteScalar().ToString();

                lblBookings.Text = bookings;

                conn.Close();

            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
            }
        }

        public void noProducts()
        {
            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "SELECT count(productId) From TableBookTable";
                comm = new SqlCommand(sql, conn);

                string customers = comm.ExecuteScalar().ToString();

                lblBookings.Text = customers;

                conn.Close();

            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
            }
        }
    }
}