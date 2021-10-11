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
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Restaurant.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);

            //master page control
            ImageButton imgProfile = (ImageButton)Page.Master.FindControl("imgProfile");
            imgProfile.Visible = false;

            LinkButton linkMenu = (LinkButton)Page.Master.FindControl("linkMenu");
            linkMenu.Visible = false;
            LinkButton linkBook = (LinkButton)Page.Master.FindControl("linkBookTable");
            linkBook.Visible = false;
            LinkButton linkBookings = (LinkButton)Page.Master.FindControl("linkBookings");
            linkBookings.Visible = false;
            LinkButton linkOrders = (LinkButton)Page.Master.FindControl("linkOrders");
            linkOrders.Visible = false;
            LinkButton linkCart = (LinkButton)Page.Master.FindControl("linkCart");
            linkCart.Visible = false;

            LinkButton linkLogin = (LinkButton)Page.Master.FindControl("linkUserLogin");
            linkLogin.Visible = true;
            LinkButton linkSignUp = (LinkButton)Page.Master.FindControl("linkSignUp");
            linkSignUp.Visible = false;
            Label linkHello = (Label)Page.Master.FindControl("lblHelloUser");
            linkHello.Visible = false;
            LinkButton linkLogout = (LinkButton)Page.Master.FindControl("linkLogout");
            linkLogout.Visible = false;

            LinkButton linkEmpLog = (LinkButton)Page.Master.FindControl("linkEmployeeLogin");
            linkEmpLog.Visible = true;
            LinkButton linkEmpReg = (LinkButton)Page.Master.FindControl("linkEmployeeRegistration");
            linkEmpReg.Visible = true;
            //

            HttpCookie userCookie = Request.Cookies["UserInfo"];
            if (userCookie != null)
            {
                if (!IsPostBack)
                {

                }

                Response.Redirect("Menu.aspx");
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "SELECT count(*) FROM TableCustomers WHERE email = '" + txtEmailAddress.Text + "'";
                comm = new SqlCommand(sql, conn);

                conn.Open();

                string email = comm.ExecuteScalar().ToString();

                if (email == "1")
                {
                    lblError.Text = "The EMAIL ADDRESS already exists in our system";
                }
                else
                {
                    register();
                    Response.Redirect("RegistrationNotification.aspx");
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
            string sql = "INSERT INTO TableCustomers(customerName, customerSurname, password, phoneNumber, email, dateOfBirth) VALUES(@customerName, @customerSurname, @password, @phoneNumber, @email, @dateOfBirth)";

            comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@customerName", txtFirstName.Text);
            comm.Parameters.AddWithValue("@customerSurname", txtSurname.Text);
            comm.Parameters.AddWithValue("@password", txtConfirmPassword.Text);
            comm.Parameters.AddWithValue("@phoneNumber", txtPhoneNumber.Text);
            comm.Parameters.AddWithValue("@email", txtEmailAddress.Text);
            comm.Parameters.AddWithValue("@dateOfBirth", txtDateOfBirth.Text);

            comm.ExecuteNonQuery();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }
    }
}