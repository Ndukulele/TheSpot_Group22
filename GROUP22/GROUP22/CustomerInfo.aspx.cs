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
    public partial class CustomerInfo : System.Web.UI.Page
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
            linkReport.Visible = true;

            LinkButton linkIn = (LinkButton)Page.Master.FindControl("login");
            linkIn.Visible = false;
            LinkButton linkUp = (LinkButton)Page.Master.FindControl("signup");
            linkUp.Visible = false;

            LinkButton linkLogout = (LinkButton)Page.Master.FindControl("linkLogout");
            linkLogout.Visible = true;
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

            fill();
        }

        public void fill()
        {

            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "SELECT customerId, customerName, customerSurname, phoneNumber, email, dateOfBirth From TableCustomers";
                comm = new SqlCommand(sql, conn);

                comm = new SqlCommand(sql, conn);
                adapt.SelectCommand = comm;
                adapt.Fill(ds);

                gvSCustomerInfo.DataSource = ds;
                gvSCustomerInfo.DataBind();

                conn.Close();
            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
            }
        }

        protected void gvSCustomerInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvSCustomerInfo.DataKeys[e.RowIndex].Value.ToString());

            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "DELETE From TableCustomers WHERE customerId = '" + id + "'";
                comm = new SqlCommand(sql, conn);
                int t = comm.ExecuteNonQuery();

                if (t > 0)
                {
                    gvSCustomerInfo.EditIndex = -1;
                    fill();

                }

                conn.Close();
            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "SELECT * FROM TableCustomers WHERE email LIKE '%" + txtSearch.Text + "%'";
                comm = new SqlCommand(sql, conn);
                adapt.SelectCommand = comm;
                adapt.Fill(ds);

                gvSCustomerInfo.DataSource = ds;
                gvSCustomerInfo.DataBind();


            }
            catch (Exception error)
            {
                lblError.Text = error.Message;

            }
        }
    }
}