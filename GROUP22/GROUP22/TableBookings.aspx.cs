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
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\CMPG 223\TheSpot\TheSpotGroup22\TheSpotGroup22\App_Data\Restaurant.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;
        SqlDataReader theReader;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Now.Date;
                
            }
        }

        protected void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            findAvaliableTable();
            rblTableNum.Visible = true;
        }

        public void findAvaliableTable()
        {
            string sDate = Calendar1.SelectedDate.Year + "-" + Calendar1.SelectedDate.Month + "-" + Calendar1.SelectedDate.Day;
            string selectedTimeIn = ((ddlTimeIn.SelectedItem.ToString()).Substring(1, 5)) + ":00";
            string selectedTimeOut = ((ddlTimeOut.SelectedItem.ToString()).Substring(1, 5)) + ":00";

            conn = new SqlConnection(constr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = $"SELECT DISTINCT tableNo from tblBookingDetails where (BookingDate = '" + Calendar1.SelectedDate + "' and ((timeIn between '" + selectedTimeIn + "' and '" + selectedTimeOut + "') or (timeOut between '" + selectedTimeIn + "' and '" + selectedTimeOut + "')))";
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
            conn = new SqlConnection(constr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                if (userCookie != null)
                {
                    string sql = $"INSERT INTO tblBookingDetails(tableNo, customerId, totalPeople, bookingDate, timeIn, timeOut) VALUES(@tableNo, @customerId, @totPeople, @date, @in, @out)";

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