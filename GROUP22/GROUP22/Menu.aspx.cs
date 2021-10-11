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
    public partial class Menu : System.Web.UI.Page
    {
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Restaurant.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            //master page control
            ImageButton imgProfile = (ImageButton)Page.Master.FindControl("imgProfile");
            imgProfile.Visible = true;

            LinkButton linkMenu = (LinkButton)Page.Master.FindControl("linkMenu");
            linkMenu.Visible = false;
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

                fillMenu();
            }
        }

        public void fillMenu()
        {
            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "SELECT * FROM TableMenu";
                comm = new SqlCommand(sql, conn);
                adapt.SelectCommand = comm;
                adapt.Fill(ds);

                rpt.DataSource = ds;
                rpt.DataBind();


            }
            catch (Exception error)
            {
                lblNoOfItems.Text = error.Message;

            }
        }

        protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "SELECT * FROM TableMenu WHERE productName LIKE '%" + txtSearch.Text + "%'";
                comm = new SqlCommand(sql, conn);
                adapt.SelectCommand = comm;
                adapt.Fill(ds);

                rpt.DataSource = ds;
                rpt.DataBind();


            }
            catch (Exception error)
            {
                lblNoOfItems.Text = error.Message;

            }
        }
    }
}