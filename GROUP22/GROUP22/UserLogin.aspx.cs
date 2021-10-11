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
    public partial class UserLogin : System.Web.UI.Page
    {
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Restaurant.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        SqlDataReader theReader;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);

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
            linkSignUp.Visible = true;
            Label linkHello = (Label)Page.Master.FindControl("lblHelloUser");
            linkHello.Visible = false;
            LinkButton linkLogout = (LinkButton)Page.Master.FindControl("linkLogout");
            linkLogout.Visible = false;

            LinkButton linkEmpLog = (LinkButton)Page.Master.FindControl("linkEmployeeLogin");
            linkEmpLog.Visible = true;
            LinkButton linkEmpReg = (LinkButton)Page.Master.FindControl("linkEmployeeRegistration");
            linkEmpReg.Visible = true;
            //

            HttpCookie userCookie = Request.Cookies["UserInfo"];
            if (userCookie != null)
            {
                if (!IsPostBack)
                {

                }

                Response.Redirect("Menu.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            checkInfo(txtEmail.Text, txtPassword.Text);
        }

        private void checkInfo(string emailLogin, string passLogin)
        {
            try
            {
                HttpCookie userCookie = new HttpCookie("UserInfo");

                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = $"SELECT customerId,customerName,email,password FROM TableCustomers WHERE email = '{emailLogin}'";

                comm = new SqlCommand(sql, conn);

                theReader = comm.ExecuteReader();

                if (theReader.Read())
                {
                    string id = theReader.GetValue(0).ToString();
                    string name = theReader.GetValue(1).ToString();
                    string tempEmail = theReader.GetValue(2).ToString();
                    string tempPassword = theReader.GetValue(3).ToString();

                    if (String.Compare(tempPassword, passLogin) == 0)
                    {
                        userCookie["customerName"] = name;
                        userCookie["email"] = tempEmail;
                        userCookie["pass"] = tempPassword;
                        Response.Cookies.Add(userCookie);
                        userCookie["customerId"] = id;

                        if (cbRememberMe.Checked)
                        {
                            userCookie.Expires = DateTime.Now.AddDays(2);
                        }

                        Session["customerId"] = id;
                        Session["customerName"] = name;
                        Response.Redirect("Menu.aspx", false);
                    }
                    else
                    {
                        lblError.Text = "Invalid Password";
                    }
                }
                else
                {
                    lblError.Text = "User account not found for " + emailLogin;
                }

                conn.Close();
            }
            catch (Exception error)
            {
                lblError.Text = "There was an error accessing the database, more info: " + error.Message;
            }
        }

    }
    
}