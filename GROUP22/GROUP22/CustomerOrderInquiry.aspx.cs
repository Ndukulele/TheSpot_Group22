using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace GROUP22
{
    public partial class customerOrderInquiry : System.Web.UI.Page
    {
        public string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Restaurant.mdf;Integrated Security=True";
        public SqlConnection conn;
        public SqlCommand comm;
        public SqlDataReader dr;
        public SqlDataAdapter da;
        public DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connStr);

            //master page control
            ImageButton imgProfile = (ImageButton)Page.Master.FindControl("imgProfile");
            imgProfile.Visible = false;

            LinkButton linkMenu = (LinkButton)Page.Master.FindControl("linkMenu");
            linkMenu.Visible = false;
            LinkButton linkBook = (LinkButton)Page.Master.FindControl("linkBookTable");
            linkBook.Visible = false;
            LinkButton linkBookings = (LinkButton)Page.Master.FindControl("linkBookings");
            linkBookings.Visible = false;
            LinkButton linkOrders = (LinkButton)Page.Master.FindControl("linkOrders");
            linkOrders.Visible = false;
            LinkButton linkCart = (LinkButton)Page.Master.FindControl("linkCart");
            linkCart.Visible = false;

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
                        

                        Session["customerId"] = userCookie["customerId"];
                        Session["customerName"] = userCookie["customerName"];
                        
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

                    if (gdOrderStatus.Rows.Count == 0)
                    {
                        sqlQueries("SELECT orderId as 'Order ID', productName as 'Product Name'" +
                            ", productPrice as 'Product Price', productQuantity as 'QTY', totalPrice as 'Total Price', status as 'Status of Order'",
                            "FROM TableOrderDetails WHERE customerId = '" + Session["customerId"] + "'", "gridView");
                    }

                    if(gdOrderStatus.Rows.Count == 0)
                    {
                        lblmessage.Text = "There are no placed orders";
                    }
                }
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            sqlQueries("SELECT orderId as 'Order ID', productName as 'Product Name'" +
                            ", productPrice as 'Product Price', productQuantity as 'QTY', totalPrice as 'Total Price', status as 'Status of Order'",
                            "FROM TableOrderDetails WHERE customerId = '" + Session["customerId"] + "'", "gridView");

            if (gdOrderStatus.Rows.Count == 0)
            {
                lblmessage.Text = "There are no placed orders";
            }
        }

        //universal sql statements begin
        public void sqlQueries(string query, string condition, string action)
        {
            conn.Open();

            string sql = $"{query} {condition}";

            comm = new SqlCommand(sql, conn);

            sqlActions(action);

            conn.Close();
        }

        public void sqlActions(string action)
        {
            if (action == "gridView") //if gridview
            {
                da = new SqlDataAdapter();
                ds = new DataSet();

                da.SelectCommand = comm;
                da.Fill(ds);

                gdOrderStatus.DataSource = ds;
                gdOrderStatus.DataBind();
            }
            else if (action == "delete")
            {
                da = new SqlDataAdapter();

                da.DeleteCommand = comm;
                da.DeleteCommand.ExecuteNonQuery();
            }
        }
        //universal sql statements end
    }
}