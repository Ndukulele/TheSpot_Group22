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
    public partial class AddProduct : System.Web.UI.Page
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
            linkHome.Visible = true;
            LinkButton linkMenu = (LinkButton)Page.Master.FindControl("menu");
            linkMenu.Visible = true;
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
            linkIn.Visible = false;
            LinkButton linkUp = (LinkButton)Page.Master.FindControl("signup");
            linkUp.Visible = false;

            LinkButton linkLogout = (LinkButton)Page.Master.FindControl("linkLogout");
            linkLogout.Visible = false;
            //

            HttpCookie employeeCookie = Request.Cookies["EmployeeInfo"];
            if (!IsPostBack)
            {
                if (employeeCookie != null)
                {


                }
                else
                {
                    Response.Redirect("EmployeeLogin.aspx");
                }

            }

            Control myCustomerLogin = Page.Master.FindControl("customerLogin");
            Control myCustomerSignUp = Page.Master.FindControl("customerRegistration");


            if (myCustomerLogin != null && myCustomerSignUp != null)
            {

                myCustomerLogin.Visible = false;
                myCustomerSignUp.Visible = false;

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            try
            {
                String filename = flPic.PostedFile.FileName;
                String filepath = "img/" + flPic.FileName;
                flPic.PostedFile.SaveAs(Server.MapPath("~/img/") + filename);
                conn.Open();
                adapt = new SqlDataAdapter();

                string sql = $"INSERT INTO TableMenu(productName, productPrice, productDescription, productImage) VALUES(@name, @price, @description, @image)";

                comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@name", txtItemName.Text);
                comm.Parameters.AddWithValue("@price", txtItemPrice.Text);
                comm.Parameters.AddWithValue("@description", txtIncredients.Text);
                comm.Parameters.AddWithValue("@image", filepath);


                comm.ExecuteNonQuery();
                conn.Close();

                lblAdded.Text = "Successfully added";

            }
            catch (Exception error)
            {
                lblError.Text = error.Message;

            }
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}