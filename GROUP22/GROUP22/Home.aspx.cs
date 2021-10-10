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
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\CMPG 223\TheSpot\TheSpotGroup22\TheSpotGroup22\App_Data\Restaurant.mdf;Integrated Security=True";
       
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            Control myCustomerLogin = Page.Master.FindControl("customerLogin");
            Control myCustomerSignUp = Page.Master.FindControl("customerRegistraction");


            if (myCustomerLogin != null && myCustomerSignUp != null)
            {

                myCustomerLogin.Visible = false;
                myCustomerSignUp.Visible = false;

            }

            noCustomers();
            noEmployees();
            noBoookings();
        }

        public void noCustomers()
        {
            conn = new SqlConnection(constr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "SELECT count(customerId) From tblCustomerDetails";
                comm = new SqlCommand(sql, conn);

                string customers = comm.ExecuteScalar().ToString();

                lblCustomers.Text = customers;

                conn.Close();



            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
            }
        }

        public void noEmployees()
        {
            conn = new SqlConnection(constr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "SELECT count(employeeId) From tblEmployeeDetails";
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
            conn = new SqlConnection(constr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "SELECT count(bookingId) From tblBookingDetails";
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
    }
}