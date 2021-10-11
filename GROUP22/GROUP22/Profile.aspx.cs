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
    public partial class Profile : System.Web.UI.Page
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
            linkMenu.Visible = true;
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

            HttpCookie userCookie = Request.Cookies["UserInfo"];
            if (userCookie != null)
            {
                Session["customerId"] = userCookie["customerId"];
                Session["customerName"] = userCookie["customerName"];

                if (!IsPostBack)
                {
                    
                }
            }
            else
            {
                Response.Redirect("UserLogin.aspx", false);
            }

            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                if (userCookie == null)
                {
                    Response.Redirect("UserLogin.aspx", false);
                }
                else
                {
                    string sql = $"SELECT customerName, customerSurname, password, phoneNumber,email, FORMAT(dateOfBirth, " +
                        $"'dd-MM-yyyy') FROM TableCustomers WHERE customerId = '" + int.Parse(userCookie["customerId"]) + "'";

                    comm = new SqlCommand(sql, conn);

                    theReader = comm.ExecuteReader();

                    if (theReader.Read())
                    {
                        txtFName.Text = theReader.GetValue(0).ToString();

                        txtSurname.Text = theReader.GetValue(1).ToString();

                        txtpassWord.Text = theReader.GetValue(2).ToString();

                        TxtPNumber.Text = theReader.GetValue(3).ToString();

                        txtEmail.Text = theReader.GetValue(4).ToString();

                        txtDBirth.Text = theReader.GetValue(5).ToString();
                    }
                    else
                    {
                        lblError.Text = "Record NOT found";
                    }

                    conn.Close();
                }
            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = null;
            HttpCookie userCookie = Request.Cookies["UserInfo"];
            if(userCookie != null)
            {
                id = userCookie["customerId"];
            }

            if (String.Compare(txtCreatePassword.Text, txtConfirmPassword.Text) == 0)
            {
                string sql = "UPDATE TableCustomers SET password = '" + txtConfirmPassword.Text + "' WHERE customerId = '" + id + "'";

                conn.Open();
                comm = new SqlCommand(sql, conn);
                adapt.UpdateCommand = comm;
                adapt.UpdateCommand.ExecuteNonQuery();
                conn.Close();

                lblError.Text = "Password changed successfully";
            }
            else
            {
                lblError.Text = "password do not match";
            }
            
        }
    }
}