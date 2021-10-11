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
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Restaurant.mdf;Integrated Security=True";

        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            //master page control
            ImageButton imgProfile = (ImageButton)Page.Master.FindControl("imgProfile");
            imgProfile.Visible = true;

            LinkButton linkMenu = (LinkButton)Page.Master.FindControl("linkMenu");
            linkMenu.Visible = true;
            LinkButton linkBook = (LinkButton)Page.Master.FindControl("linkBookTable");
            linkBook.Visible = true;
            LinkButton linkBookings = (LinkButton)Page.Master.FindControl("linkBookings");
            linkBookings.Visible = true;
            LinkButton linkOrders = (LinkButton)Page.Master.FindControl("linkOrders");
            linkOrders.Visible = true;
            LinkButton linkCart = (LinkButton)Page.Master.FindControl("linkCart");
            linkCart.Visible = true;

            LinkButton linkLogin = (LinkButton)Page.Master.FindControl("linkUserLogin");
            linkLogin.Visible = false;
            LinkButton linkSignUp = (LinkButton)Page.Master.FindControl("linkSignUp");
            linkSignUp.Visible = false;
            Label linkHello = (Label)Page.Master.FindControl("lblHelloUser");
            linkHello.Visible = false;

            LinkButton linkLogout = (LinkButton)Page.Master.FindControl("linkLogout");
            linkLogout.Visible = true;

            LinkButton linkEmpLog = (LinkButton)Page.Master.FindControl("linkEmployeeLogin");
            linkEmpLog.Visible = false;
            LinkButton linkEmpReg = (LinkButton)Page.Master.FindControl("linkEmployeeRegistration");
            linkEmpReg.Visible = false;
            //

            if (!IsPostBack)
            {
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

                string sql = "SELECT * From TableMenu WHERE productId = '" + id + "'";
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

                    string sql = "SELECT productId From TableMenu WHERE productId = '" + id + "'";
                    comm = new SqlCommand(sql, conn);
                    string productID = comm.ExecuteScalar().ToString();


                    string sql1 = "SELECT productName From TableMenu WHERE productId = '" + id + "'";
                    comm = new SqlCommand(sql1, conn);
                    string name = comm.ExecuteScalar().ToString();


                    string sql2 = "SELECT productPrice From TableMenu WHERE productId = '" + id + "'";
                    comm = new SqlCommand(sql2, conn);
                    string price = comm.ExecuteScalar().ToString();


                    string sql3 = "SELECT productImage From TableMenu WHERE productId = '" + id + "'";
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

            
            string sql = $"INSERT INTO TableOrderDetails(productId, productImage, productName, productPrice, productQuantity, totalPrice, customerId, status, dateOfOrder) VALUES(@id, @image, @name, @price, @quantity, @totalPrice, @customerId, @status, @date)";

            comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@id", int.Parse(productID));
            comm.Parameters.AddWithValue("@image", img);
            comm.Parameters.AddWithValue("@name", name);
            comm.Parameters.AddWithValue("@price", pPrice);
            comm.Parameters.AddWithValue("@quantity", quantity);
            comm.Parameters.AddWithValue("@totalPrice", totalPrice);
            comm.Parameters.AddWithValue("@customerId", int.Parse(userCookie["customerId"]));
            comm.Parameters.AddWithValue("@status", "Placed");
            comm.Parameters.AddWithValue("@date", DateTime.Now);


            comm.ExecuteNonQuery();
        }
    }
}
