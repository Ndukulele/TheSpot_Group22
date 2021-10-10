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
    public partial class AddProduct : System.Web.UI.Page
    {
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\CMPG 223\TheSpot\TheSpotGroup22\TheSpotGroup22\App_Data\Restaurant.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
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
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(constr);
            try
            {
                String filename = flPic.PostedFile.FileName;
                String filepath = "img/" + flPic.FileName;
                flPic.PostedFile.SaveAs(Server.MapPath("~/img/") + filename);
                conn.Open();
                adapt = new SqlDataAdapter();

                string sql = $"INSERT INTO tblMenu(productName, productPrice, productDescription, image) VALUES(@name, @price, @description, @image)";

                comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@name", txtItemName.Text);
                comm.Parameters.AddWithValue("@price", txtItemPrice.Text);
                comm.Parameters.AddWithValue("@description", txtIncredients.Text);
                comm.Parameters.AddWithValue("@image", filepath);


                comm.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception error)
            {
                lblError.Text = error.Message;

            }
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}