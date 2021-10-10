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
    public partial class Bookings : System.Web.UI.Page
    {
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\CMPG 223\TheSpot\TheSpotGroup22\TheSpotGroup22\App_Data\Restaurant.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserInfo"];

            Control btnSignIn = Page.Master.FindControl("userLogin");
            Control btnSignUp = Page.Master.FindControl("signUp");
            Control btnELogin = Page.Master.FindControl("employeeLogin");
            Control btnESignUp = Page.Master.FindControl("EmployeeRegistraction");

            if (btnSignIn != null && btnSignUp != null && btnELogin != null && btnESignUp != null)
            {
                btnSignIn.Visible = false;
                btnSignUp.Visible = false;
                btnESignUp.Visible = false;
                btnELogin.Visible = false;
            }

            if (!IsPostBack)
            {
                if (userCookie != null)
                {
                    fillMenu();
                }
                else
                {
                    Response.Redirect("UserLogin.aspx", false);
                }
            }
        }

        public void fillMenu()
        {
            HttpCookie userCookie = Request.Cookies["UserInfo"];
            conn = new SqlConnection(conStr);
            try
            {

                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "SELECT bookingId, tableNo, totalPeople, bookingDate, timeIn, timeOut FROM tblBookingDetails WHERE customerId ='" + int.Parse(userCookie["customerId"]) + "'";
                comm = new SqlCommand(sql, conn);
                adapt.SelectCommand = comm;
                adapt.Fill(ds);

                gvBookings.DataSource = ds;
                gvBookings.DataBind();

                conn.Close();

            }
            catch (Exception error)
            {
                lblError.Text = error.Message;

            }
        }

        protected void gvBookings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}