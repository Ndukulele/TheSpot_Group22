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
    public partial class EmployeeSignUp : System.Web.UI.Page
    {
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\CMPG 223\TheSpot\TheSpotGroup22\TheSpotGroup22\App_Data\Restaurant.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            Control myHome = Page.Master.FindControl("home");
            Control myAddPRoduct = Page.Master.FindControl("addProduct");
            Control myEditMenu = Page.Master.FindControl("editMenu");
            Control myViewOrders = Page.Master.FindControl("viewOrders");
            Control myViewBookings = Page.Master.FindControl("viewBookings");
            Control myCustomerInfo = Page.Master.FindControl("customerInfo");
            Control myReports = Page.Master.FindControl("reports");

            Control btnLogout = Page.Master.FindControl("logOut");

            if (myHome != null && myAddPRoduct != null && myEditMenu != null && myViewOrders != null && myViewBookings != null && myCustomerInfo != null && myReports != null && btnLogout != null)
            {
                myHome.Visible = false;
                myAddPRoduct.Visible = false;
                myEditMenu.Visible = false;
                myViewOrders.Visible = false;
                myViewBookings.Visible = false;
                myCustomerInfo.Visible = false;
                myReports.Visible = false;

                btnLogout.Visible = false;
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "SELECT count(*) From tblEmployeeDetails WHERE email = '" + txtEmailAdress.Text + "'";
                comm = new SqlCommand(sql, conn);
                string email = comm.ExecuteScalar().ToString();

                if (email == "1")
                {
                    lblError.Text = "The EMAIL ADDRESS already exists in our system";
                }
                else
                {
                    register();
                    Response.Redirect("EmployeeLogin.aspx");
                }

                conn.Close();
            }
            catch (Exception error)
            {
                lblError.Text = error.Message;

            }
        }

        public void register()
        {

            string sql = "INSERT INTO tblEmployeeDetails(employeeName, employeeSurname, password, phoneNumber, email, dateOfBirth) VALUES(@firstName, @surname, @password, @phoneNumber, @email, @dateOfBirth)";

            comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@firstName", txtFirstName.Text);
            comm.Parameters.AddWithValue("@surname", txtSurname.Text);
            comm.Parameters.AddWithValue("@password", txtConfirmPassword.Text);
            comm.Parameters.AddWithValue("@phoneNumber", txtPhoneNumber.Text);
            comm.Parameters.AddWithValue("@email", txtEmailAdress.Text);
            comm.Parameters.AddWithValue("@dateOfBirth", txtDateOfBirth.Text);

            comm.ExecuteNonQuery();

        }
    }
}