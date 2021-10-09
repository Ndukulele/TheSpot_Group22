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
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\CMPG 223\TheSpot\TheSpotGroup22\TheSpotGroup22\App_Data\Restaurant.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapt;
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                conn = new SqlConnection(constr);
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

        public void fill()
        {
            
            string sql = "SELECT productId, image, productName, productPrice, productDescription From tblMenu";
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

            conn = new SqlConnection(constr);
            try
            {
                conn.Open();
                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "DELETE From tblMenu WHERE productId = '" + id + "'";
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
            conn = new SqlConnection(constr);
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

                conn = new SqlConnection(constr);
                conn.Open();

                adapt = new SqlDataAdapter();
                ds = new DataSet();

                string sql = "UPDATE tblMenu set productName = '" + name + "', productPrice = '" + decimal.Parse(price) + "', productDescription = '" + description + "' where productId = '" + id + "'";
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
            conn = new SqlConnection(constr);
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