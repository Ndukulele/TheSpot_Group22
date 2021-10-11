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
    public partial class TableBookings : System.Web.UI.Page
    {
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Restaurant.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;
        SqlDataReader theReader;

        protected void Page_Load(object sender, EventArgs e)
        {
            //master page control
            ImageButton imgProfile = (ImageButton)Page.Master.FindControl("imgProfile");
            imgProfile.Visible = true;

            LinkButton linkMenu = (LinkButton)Page.Master.FindControl("linkMenu");
            linkMenu.Visible = true;
            LinkButton linkBook = (LinkButton)Page.Master.FindControl("linkBookTable");
            linkBook.Visible = false;
            LinkButton linkBookings = (LinkButton)Page.Master.FindControl("linkBookings");
            linkBookings.Visible = true;
            LinkButton linkOrders = (LinkButton)Page.Master.FindControl("linkOrders");
            linkOrders.Visible = true;
            LinkButton linkCart = (LinkButton)Page.Master.FindControl("linkCart");
            linkCart.Visible = false;

            LinkButton linkLogin = (LinkButton)Page.Master.FindControl("linkUserLogin");
            linkLogin.Visible = false;
            LinkButton linkSignUp = (LinkButton)Page.Master.FindControl("linkSignUp");
            linkSignUp.Visible = false;
            Label linkHello = (Label)Page.Master.FindControl("lblHelloUser");
            linkHello.Visible = true;

            LinkButton linkLogout = (LinkButton)Page.Master.FindControl("linkLogout");
            linkLogout.Visible = true;

            LinkButton linkEmpLog = (LinkButton)Page.Master.FindControl("linkEmployeeLogin");
            linkEmpLog.Visible = false;
            LinkButton linkEmpReg = (LinkButton)Page.Master.FindControl("linkEmployeeRegistration");
            linkEmpReg.Visible = false;
            //

            if (!IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Now.Date;

                if (Session["customerId"] == null)
                {
                    HttpCookie userCookie = Request.Cookies["UserInfo"];
                    if (userCookie != null)
                    {
                        linkHello = (Label)Page.Master.FindControl("lblHelloUser");
                        linkHello.Visible = true;

                        Session["customerId"] = userCookie["customerId"];
                        Session["customerName"] = userCookie["customerName"];
                        linkHello.Text = "Welcome " + Session["customerName"];
                    }
                    else
                    {
                        Response.Redirect("UserLogin.aspx", false);
                    }
                }
                else
                {
                    linkHello = (Label)Page.Master.FindControl("lblHelloUser");
                    linkHello.Visible = true;

                    linkHello.Text = "Welcome " + Session["customerName"];
                }
            }
        }

        protected void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            findAvaliableTable();
            btnSubmitBooking.Enabled = true;
            rblTableNum.Visible = true;
        }

        public void findAvaliableTable()
        {
            string sDate = Calendar1.SelectedDate.Year + "-" + Calendar1.SelectedDate.Month + "-" + Calendar1.SelectedDate.Day;
            string selectedTimeIn = ((ddlTimeIn.SelectedItem.ToString()).Substring(1, 5)) + ":00";
            string selectedTimeOut = ((ddlTimeOut.SelectedItem.ToString()).Substring(1, 5)) + ":00";

            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = $"SELECT DISTINCT tableNo from TableBookTable where (bookingDate = '" + Calendar1.SelectedDate + "' and ((timeIn between '" + selectedTimeIn + "' and '" + selectedTimeOut + "') or (timeOut between '" + selectedTimeIn + "' and '" + selectedTimeOut + "')))";
                comm = new SqlCommand(sql, conn);

                adapt.SelectCommand = comm;
                adapt.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Text = "Available Tables are given below";
                    lblDate.Text = sDate;

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        rblTableNum.Items.Remove(rblTableNum.Items.FindByValue(dr["tableNo"].ToString()));
                    }

                    if (rblTableNum.Items.Count == 0)
                    {
                        lblMessage.Text = "No Table Available to Book";
                    }
                }
                else
                {
                    lblMessage.Text = "Available Tables are given below";
                    lblDate.Text = sDate;
                    
                }

                conn.Close();
            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
            }
        }

        protected void btnSubmitBooking_Click(object sender, EventArgs e)
        {
            bookTable();
        }

        public void bookTable()
        {
            string sDate = Calendar1.SelectedDate.Year + "-" + Calendar1.SelectedDate.Month + "-" + Calendar1.SelectedDate.Day;
            HttpCookie userCookie = Request.Cookies["UserInfo"];
            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                if (userCookie != null)
                {
                    string sql = $"INSERT INTO TableBookTable(tableNo, customerId, totalPeople, bookingDate, timeIn, timeOut) VALUES(@tableNo, @customerId, @totPeople, @date, @in, @out)";

                    comm = new SqlCommand(sql, conn);
                    comm.Parameters.AddWithValue("@tableNo", rblTableNum.SelectedItem.ToString());
                    comm.Parameters.AddWithValue("@customerId", int.Parse(userCookie["customerId"]));
                    comm.Parameters.AddWithValue("@date", Calendar1.SelectedDate.ToString());
                    comm.Parameters.AddWithValue("@totPeople", int.Parse(txtNumOfPeople.Text));
                    comm.Parameters.AddWithValue("@in", ddlTimeIn.SelectedItem.ToString());
                    comm.Parameters.AddWithValue("@out", ddlTimeOut.SelectedItem.ToString());


                    comm.ExecuteNonQuery();
                    conn.Close();

                    lblMessage.BackColor = System.Drawing.ColorTranslator.FromHtml("Green");
                    lblMessage.Text = "Table No " + rblTableNum.SelectedItem.Text + " Has been booked on the " + sDate + " from " + ddlTimeIn.SelectedItem.ToString() + " to " + ddlTimeOut.SelectedItem.ToString() + ". <br/> We are looking forward to having you in our restaurant.";
                }
                else
                {
                    Response.Redirect("UserLogin.aspx",false);
                }
            }
            catch (Exception error)
            {
                lblError.Text = error.Message;

            }
        }
    }
}