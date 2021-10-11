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
    public partial class EmployeeLogin : System.Web.UI.Page
    {
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Restaurant.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        SqlDataReader theReader;

        protected void Page_Load(object sender, EventArgs e)
        {
            //master page control
            LinkButton linkHome = (LinkButton)Page.Master.FindControl("home");
            linkHome.Visible = false;
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
            linkReport.Visible = false;

            LinkButton linkIn = (LinkButton)Page.Master.FindControl("login");
            linkIn.Visible = false;
            LinkButton linkUp = (LinkButton)Page.Master.FindControl("signup");
            linkUp.Visible = true;

            LinkButton linkLogout = (LinkButton)Page.Master.FindControl("linkLogout");
            linkLogout.Visible = false;
            //

            HttpCookie employeeCookie = Request.Cookies["EmpInfo"];
            if (!IsPostBack)
            {
                if (employeeCookie != null)
                {

                    Response.Redirect("Home.aspx");
                }

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            checkInfo();
        }

        private void checkInfo()
        {

            conn = new SqlConnection(conStr);
            try
            {
                HttpCookie employeeCookie = new HttpCookie("employeeInfo");
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = $"SELECT employeeId,password FROM TableEmployees WHERE email = '{txtEmail.Text}'";

                comm = new SqlCommand(sql, conn);

                theReader = comm.ExecuteReader();

                if (theReader.Read())
                {
                    string id = theReader.GetValue(0).ToString();
                    employeeCookie["employeeId"] = id;
                    Response.Cookies.Add(employeeCookie);

                    string tempPassword = theReader.GetValue(1).ToString();

                    string enteredPassword = txtPassword.Text;

                    if (String.Compare(tempPassword, enteredPassword) == 0)
                    {
                        if (cbRememberMe.Checked)
                        {
                            employeeCookie.Expires = DateTime.Now.AddDays(2);
                        }
                        Response.Redirect("Home.aspx", false);
                    }
                    else
                    {

                        lblError.Text = "Invalid Password";

                    }
                }
                else
                {

                    lblError.Text = "Invalid Email";

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