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
    public partial class Cart : System.Web.UI.Page
    {
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\CMPG 223\TheSpot\TheSpotGroup22\TheSpotGroup22\App_Data\Restaurant.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserInfo"];
            if (!IsPostBack)
            {
                conn = new SqlConnection(constr);
                try
                {
                    if (userCookie != null)
                    {
                        conn.Open();
                        adapt = new SqlDataAdapter();
                        ds = new DataSet();

                        fill();
                        totalAmount();

                        conn.Close();
                    }
                    else
                    {
                        Response.Redirect("UserLogin.aspx");
                    }
                }
                catch (Exception error)
                {
                    lblError.Text = error.Message;
                }
            }
        }

        public void fill()
        {
            HttpCookie userCookie = Request.Cookies["UserInfo"];

            string sql = "SELECT productId, image, productName, productPrice, quantity, totalPrice From tblCart WHERE customerId = '" + int.Parse(userCookie["customerId"]) + "'";
            comm = new SqlCommand(sql, conn);

            comm = new SqlCommand(sql, conn);
            adapt.SelectCommand = comm;
            adapt.Fill(ds);

            gvSCart.DataSource = ds;
            gvSCart.DataBind();
        }

        public void totalAmount()
        {
            HttpCookie userCookie = Request.Cookies["UserInfo"];

            string sql = "SELECT SUM(totalPrice) From tblCart WHERE customerId = '" + int.Parse(userCookie["customerId"]) + "'";
            comm = new SqlCommand(sql, conn);
            string amount = comm.ExecuteScalar().ToString();

            if (amount != "")
            {
                decimal totalAmount = decimal.Parse(amount);
                lblTotalAmount.Text = totalAmount.ToString("c");
            }
            else
            {
                lblTotalAmount.Text = 0.ToString("c");
            }
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {

        }

        protected void gvSCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvSCart.DataKeys[e.RowIndex].Value.ToString());

            conn = new SqlConnection(constr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "DELETE From tblCart WHERE productId = '" + id + "'";
                comm = new SqlCommand(sql, conn);
                int t = comm.ExecuteNonQuery();

                if (t > 0)
                {
                    gvSCart.EditIndex = -1;
                    fill();
                    totalAmount();
                }

                conn.Close();
            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
            }
        }
    }
}