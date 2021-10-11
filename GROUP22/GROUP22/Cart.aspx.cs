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
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Restaurant.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            //master page control
            ImageButton imgProfile = (ImageButton)Page.Master.FindControl("imgProfile");
            imgProfile.Visible = false;

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

                    conn = new SqlConnection(conStr);
                    try
                    {
                        conn.Open();
                        adapt = new SqlDataAdapter();
                        ds = new DataSet();

                        fill();
                        totalAmount();

                        conn.Close();
                    }
                    catch (Exception error)
                    {
                        lblError.Text = error.Message;
                    }
                }
            }
        }

        public void fill()
        {
            HttpCookie userCookie = Request.Cookies["UserInfo"];
            string id;
            if(userCookie != null)
            {
                id = userCookie["customerId"];
            }
            else
            {
                id = Session["customerId"].ToString();
            }

            string sql = "SELECT productId, productImage, productName, productPrice, productQuantity, totalPrice From TableOrderDetails WHERE customerId = '" + int.Parse(id) + "'";
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
            string id;
            if (userCookie != null)
            {
                id = userCookie["customerId"];
            }
            else
            {
                id = Session["customerId"].ToString();
            }

            string sql = "SELECT SUM(totalPrice) From TableOrderDetails WHERE customerId = '" + int.Parse(id) + "'";
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
                Session["total"] = lblTotalAmount.Text;
            }
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerOrderInquiry.aspx");
        }

        protected void gvSCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvSCart.DataKeys[e.RowIndex].Value.ToString());

            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "DELETE From TableOrderDetails WHERE productId = '" + id + "'";
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