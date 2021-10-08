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
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source= (LocalDB)\ MSSQLLocalDB;AttachDbFilename = C:\Users\Dell\Documents\CMPG223\Project\MasterMind\MasterMind\App_Data\Restuarant.mdf;Integrated Security = True");
        protected void Page_Load(object sender, EventArgs e)
        {
            rgtrconflabel.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            rgtrconflabel.Visible = true;
            rgtrconflabel.Text = "Your account has been succesfully registered";


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into tblCustomerDetails (@CustomerName, @CustomerSurname, @password, @phoneNumber, @email, @dateOfBirth ", con);
            //cmd.Parameters.Add("@password", txtPassword.Text);
            //cmd.Parameters.Add("@email", txtEmail.Text);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i != 0)
            {
                rgtrconflabel.Text = "Password saved";

            }
            else
            {
                rgtrconflabel.Text = "Error while registering";
            }
         
        }
    }
}