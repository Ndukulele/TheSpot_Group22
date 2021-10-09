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
    public partial class SignUp : System.Web.UI.Page
    {
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\CMPG 223\TheSpot\TheSpotGroup22\TheSpotGroup22\App_Data\Restaurant.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "SELECT count(*) From tblCustomerDetails WHERE email = '" + txtEmailAddress.Text + "'";
                comm = new SqlCommand(sql, conn);
                string email = comm.ExecuteScalar().ToString();

                if (email == "1")
                {
                    lblError.Text = "The EMAIL ADDRESS already exists in our system";
                }
                else
                {
                    register();
                    Response.Redirect("UserLogin.aspx");
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

            string sql = "INSERT INTO tblCustomerDetails(customerName, customerSurname, password, phoneNumber, email, dateOfBirth) VALUES(@firstName, @surname, @password, @phoneNumber, @email, @dateOfBirth)";

            comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@firstName", txtFirstName.Text);
            comm.Parameters.AddWithValue("@surname", txtSurname.Text);
            comm.Parameters.AddWithValue("@password", txtConfirmPassword.Text);
            comm.Parameters.AddWithValue("@phoneNumber", txtPhoneNumber.Text);
            comm.Parameters.AddWithValue("@email", txtEmailAddress.Text);
            comm.Parameters.AddWithValue("@dateOfBirth", txtDateOfBirth.Text);

            comm.ExecuteNonQuery();
           
        }
    }
}