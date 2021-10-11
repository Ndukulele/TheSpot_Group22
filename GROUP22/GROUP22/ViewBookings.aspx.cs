using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TheSpotGroup22
{
    public partial class ViewBookings : System.Web.UI.Page
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
            LinkButton linkHome = (LinkButton)Page.Master.FindControl("home");
            linkHome.Visible = true;
            LinkButton linkMenu = (LinkButton)Page.Master.FindControl("menu");
            linkMenu.Visible = false;
            LinkButton linkProduct = (LinkButton)Page.Master.FindControl("product");
            linkProduct.Visible = false;
            LinkButton linkOrder = (LinkButton)Page.Master.FindControl("order");
            linkOrder.Visible = true;
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
            linkLogout.Visible = true;
            //

            HttpCookie employeeCookie = Request.Cookies["EmployeeInfo"];
            if (!IsPostBack)
            {
                if (employeeCookie != null)
                {

                    fill();
                }
                else
                {
                    Response.Redirect("EmployeeLogin.aspx");
                }

            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvBookings.DataKeys[e.RowIndex].Value.ToString());

            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "DELETE From TableBookTable WHERE bookId = '" + id + "'";
                comm = new SqlCommand(sql, conn);
                int t = comm.ExecuteNonQuery();

                if (t > 0)
                {
                    gvBookings.EditIndex = -1;
                    fill();

                }

                conn.Close();
            }
            catch (Exception error)
            {
                
            }
        }

        public void fill()
        {

            string sql = "SELECT * From TableBookTable";
            comm = new SqlCommand(sql, conn);

            adapt = new SqlDataAdapter();
            ds = new DataSet();
            adapt.SelectCommand = comm;
            adapt.Fill(ds);

            gvBookings.DataSource = ds;
            gvBookings.DataBind();
        }
    }
}