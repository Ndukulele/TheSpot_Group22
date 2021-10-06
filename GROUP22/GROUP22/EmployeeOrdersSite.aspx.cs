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
    public partial class EmployeeOrdersSite : System.Web.UI.Page
    {
        public string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\143.160.81.13\CTX_Redirected_Data$\32445385\Documents\GitHub\TheSpot_Group22\GROUP22\GROUP22\App_Data\temp.mdf;Integrated Security=True";
        public SqlConnection conn;
        public SqlCommand comm;
        public SqlDataReader dr;
        public SqlDataAdapter da;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connStr);

            if(lsOrders.Items != null)
            {
                sqlSelectListBox("OrderId", "TableOrders");
            }
        }

        protected void lsOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblOrderNo.Text = lsOrders.SelectedValue.ToString();
            lsOrders.Items.Clear();
            sqlSelectListBox("OrderId", "TableOrders");
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnOrderProcessing_Click(object sender, EventArgs e)
        {

        }

        protected void btnOrderReady_Click(object sender, EventArgs e)
        {

        }

        protected void btnOrderFulfilled_Click(object sender, EventArgs e)
        {

        }

        public void sqlSelectListBox(string column, string table)
        {
            conn.Open();

            string sql = $"SELECT {column} FROM {table}";

            comm = new SqlCommand(sql, conn);
            dr = comm.ExecuteReader();

            while (dr.Read())
            {
                lsOrders.Items.Add(dr.GetValue(0).ToString());
            }

            conn.Close();
        }

        public void sqlDeleteListBox(string column, string table, string query)
        {
            conn.Open();

            string sql = $"DELETE {column} FROM {table} WHERE {query}";

            comm = new SqlCommand(sql, conn);
            da = new SqlDataAdapter();

            da.DeleteCommand = comm;
            da.DeleteCommand.ExecuteNonQuery();

            conn.Close();
        }
    }
}