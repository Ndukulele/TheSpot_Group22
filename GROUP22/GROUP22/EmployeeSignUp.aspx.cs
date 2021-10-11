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
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Restaurant.mdf;Integrated Security=True";
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
            linkMenu.Visible = false;
            LinkButton linkProduct = (LinkButton)Page.Master.FindControl("product");
            linkProduct.Visible = false;
            LinkButton linkOrder = (LinkButton)Page.Master.FindControl("order");
            linkOrder.Visible = false;
            LinkButton linkBook = (LinkButton)Page.Master.FindControl("booking");
            linkBook.Visible = false;
            LinkButton linkAccount = (LinkButton)Page.Master.FindControl("account");
            linkAccount.Visible = false;
            LinkButton linkReport = (LinkButton)Page.Master.FindControl("report");
            linkReport.Visible = false;

            LinkButton linkIn = (LinkButton)Page.Master.FindControl("login");
            linkIn.Visible = true;
            LinkButton linkUp = (LinkButton)Page.Master.FindControl("signup");
            linkUp.Visible = false;

            LinkButton linkLogout = (LinkButton)Page.Master.FindControl("linkLogout");
            linkLogout.Visible = false;
            //

            HttpCookie employeeCookie = Request.Cookies["EmpInfo"];
            if (!IsPostBack)
            {
                if (employeeCookie != null)
                {

                    Response.Redirect("Home.aspx");
                }

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

                string sql = "SELECT count(*) From TableEmployees WHERE email = '" + txtEmailAdress.Text + "'";
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

            string sql = "INSERT INTO TableEmployees(employeeName, employeeSurname, password, phoneNumber, email, dateOfBirth) VALUES(@firstName, @surname, @password, @phoneNumber, @email, @dateOfBirth)";

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