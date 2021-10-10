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
    public partial class FoodItems : System.Web.UI.Page
    {
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\CMPG 223\TheSpot\TheSpotGroup22\TheSpotGroup22\App_Data\Restaurant.mdf;Integrated Security=True";

        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
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

            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Menu.aspx");
            }
            else
            {
                fillMeal();


            }
        }

        public void fillMeal()
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            conn = new SqlConnection(conStr);

            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "SELECT * From tblMenu WHERE productId = '" + id + "'";
                comm = new SqlCommand(sql, conn);

                comm = new SqlCommand(sql, conn);
                adapt.SelectCommand = comm;
                adapt.Fill(ds);

                rptFill.DataSource = ds;
                rptFill.DataBind();

                conn.Close();
            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserInfo"];
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            conn = new SqlConnection(conStr);
            try
            {
                if (userCookie != null)
                {
                    conn.Open();
                    adapt = new SqlDataAdapter();
                    ds = new DataSet();

                    string sql = "SELECT productId From tblMenu WHERE productId = '" + id + "'";
                    comm = new SqlCommand(sql, conn);
                    string productID = comm.ExecuteScalar().ToString();


                    string sql1 = "SELECT productName From tblMenu WHERE productId = '" + id + "'";
                    comm = new SqlCommand(sql1, conn);
                    string name = comm.ExecuteScalar().ToString();


                    string sql2 = "SELECT productPrice From tblMenu WHERE productId = '" + id + "'";
                    comm = new SqlCommand(sql2, conn);
                    string price = comm.ExecuteScalar().ToString();


                    string sql3 = "SELECT image From tblMenu WHERE productId = '" + id + "'";
                    comm = new SqlCommand(sql3, conn);
                    string img = comm.ExecuteScalar().ToString();

                    addToCart(productID, name, price, img);

                    conn.Close();

                    Response.Redirect("Cart.aspx");
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

        public void addToCart(string productID, string name, string price, string img)
        {
            HttpCookie userCookie = Request.Cookies["UserInfo"];

            double quantity = double.Parse(txtQuantity.Text);
            double pPrice = double.Parse(price);
            double totalPrice = quantity * pPrice;

            
            string sql = $"INSERT INTO tblCart(productId, image, productName, productPrice, quantity, totalPrice, customerId) VALUES(@id, @image, @name, @price, @quantity, @totalPrice, @customerId)";

            comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@id", int.Parse(productID));
            comm.Parameters.AddWithValue("@image", img);
            comm.Parameters.AddWithValue("@name", name);
            comm.Parameters.AddWithValue("@price", pPrice);
            comm.Parameters.AddWithValue("@quantity", quantity);
            comm.Parameters.AddWithValue("@totalPrice", totalPrice);
            comm.Parameters.AddWithValue("@customerId", int.Parse(userCookie["customerId"]));


            comm.ExecuteNonQuery();
        }
    }
}
