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
    public partial class EditMenu : System.Web.UI.Page
    {
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Restaurant.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            //master page control
            LinkButton linkHome = (LinkButton)Page.Master.FindControl("home");
            linkHome.Visible = true;
            LinkButton linkMenu = (LinkButton)Page.Master.FindControl("menu");
            linkMenu.Visible = false;
            LinkButton linkProduct = (LinkButton)Page.Master.FindControl("product");
            linkProduct.Visible = true;
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
            linkUp.Visible = false;

            LinkButton linkLogout = (LinkButton)Page.Master.FindControl("linkLogout");
            linkLogout.Visible = true;
            //

            HttpCookie employeeCookie = Request.Cookies["EmployeeInfo"];

            if (!IsPostBack)
            {
                if (employeeCookie != null)
                {
                    conn = new SqlConnection(conStr);
                    try
                    {
                        conn.Open();
                        adapt = new SqlDataAdapter();
                        ds = new DataSet();

                        fill();


                        conn.Close();
                    }
                    catch (Exception error)
                    {
                        lblError.Text = error.Message;
                    }
                }
                else
                {
                    Response.Redirect("EmployeeLogin.aspx");
                }

            }

            if (!IsPostBack)
            {
                
            }
        }

        public void fill()
        {
            
            string sql = "SELECT productId, productImage, productName, productPrice, productDescription From TableMenu";
            comm = new SqlCommand(sql, conn);

            comm = new SqlCommand(sql, conn);
            adapt.SelectCommand = comm;
            adapt.Fill(ds);

            gvSMenu.DataSource = ds;
            gvSMenu.DataBind();
        }

        protected void gvSMenu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvSMenu.DataKeys[e.RowIndex].Value.ToString());

            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "DELETE From TableMenu WHERE productId = '" + id + "'";
                comm = new SqlCommand(sql, conn);
                int t = comm.ExecuteNonQuery();

                if (t > 0)
                {
                    gvSMenu.EditIndex = -1;
                    fill();
                    
                }

                conn.Close();
            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
            }
        }

        protected void gvSMenu_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSMenu.EditIndex = e.NewEditIndex;
            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                fill();


                conn.Close();
            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
            }
        }

        protected void gvSMenu_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvSMenu.DataKeys[e.RowIndex].Value.ToString());
            try
            {
                string name = ((TextBox)gvSMenu.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
                string price = ((TextBox)gvSMenu.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
                string description = ((TextBox)gvSMenu.Rows[e.RowIndex].Cells[4].Controls[0]).Text;

                conn = new SqlConnection(conStr);
                conn.Open();

                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "UPDATE TableMenu set productName = '" + name + "', productPrice = '" + decimal.Parse(price) + "', productDescription = '" + description + "' where productId = '" + id + "'";
                comm = new SqlCommand(sql, conn);

                int t = comm.ExecuteNonQuery();

                if (t > 0)
                {
                    gvSMenu.EditIndex = -1;
                    fill();

                }

                conn.Close();
            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
            }
        }

        protected void gvSMenu_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSMenu.EditIndex = -1;
            conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                fill();


                conn.Close();
            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
            }
        }
    }
    
}