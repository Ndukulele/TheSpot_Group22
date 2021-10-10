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
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\CMPG 223\TheSpot\TheSpotGroup22\TheSpotGroup22\App_Data\Restaurant.mdf;Integrated Security=True";
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

            if (!IsPostBack)
            {
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

                string sql = "SELECT * FROM tblMenu";
                comm = new SqlCommand(sql, conn);
                adapt.SelectCommand = comm;
                adapt.Fill(ds);

                rpt.DataSource = ds;
                rpt.DataBind();


            }
            catch (Exception error)
            {
                lblError.Text = error.Message;

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

                string sql = "SELECT * FROM tblMenu WHERE productName LIKE '%" + txtSearch.Text + "%'";
                comm = new SqlCommand(sql, conn);
                adapt.SelectCommand = comm;
                adapt.Fill(ds);

                rpt.DataSource = ds;
                rpt.DataBind();


            }
            catch (Exception error)
            {
                lblError.Text = error.Message;

            }
        }
    }
}