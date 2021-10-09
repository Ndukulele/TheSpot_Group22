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
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\CMPG 223\TheSpot\TheSpotGroup22\TheSpotGroup22\App_Data\Restaurant.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        SqlDataReader theReader;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserInfo"];
            if (!IsPostBack)
            {
                if (userCookie != null)
                {
                    
                    Response.Redirect("Menu.aspx");
                }
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            checkInfo();
        }

        private void checkInfo()
        {
            
            conn = new SqlConnection(constr);
            try
            {
                HttpCookie userCookie = new HttpCookie("UserInfo");
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = $"SELECT customerId,password FROM tblCustomerDetails WHERE email = '{txtEmail.Text}'";

                comm = new SqlCommand(sql, conn);

                theReader = comm.ExecuteReader();

                if (theReader.Read())
                {
                    string id = theReader.GetValue(0).ToString();
                    userCookie["customerId"] = id;
                    Response.Cookies.Add(userCookie);

                    string tempPassword = theReader.GetValue(1).ToString();

                    string enteredPassword = txtPassword.Text;

                    if (String.Compare(tempPassword, enteredPassword) == 0)
                    {
                        if (cbRememberMe.Checked)
                        {
                            userCookie.Expires = DateTime.Now.AddDays(2);
                        }
                        Response.Redirect("Menu.aspx", false);
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