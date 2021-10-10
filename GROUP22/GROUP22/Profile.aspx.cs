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
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\CMPG 223\TheSpot\TheSpotGroup22\TheSpotGroup22\App_Data\Restaurant.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        SqlDataReader theReader;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserInfo"];

            Control btnSignIn = Page.Master.FindControl("userLogin");
            Control btnSignUp = Page.Master.FindControl("signUp");
            Control btnELogin = Page.Master.FindControl("employeeLogin");
            Control btnESignUp = Page.Master.FindControl("EmployeeRegistraction");

            if (btnSignIn != null && btnSignUp != null && btnELogin != null && btnESignUp != null)
            {
                btnSignIn.Visible = false;
                btnSignUp.Visible = false;
                btnESignUp.Visible = false;
                btnELogin.Visible = false;
            }

            conn = new SqlConnection(constr);
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
                    
                    
                    string sql = $"SELECT customerName, customerSurname, password, phoneNumber,email, dateOfBirth FROM tblCustomerDetails WHERE customerId = '" + int.Parse(userCookie["customerId"]) + "'";

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

        }
    }
}