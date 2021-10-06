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
        public DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connStr);

            //if empty populate list box
            if (lsOrders.Items.Count == 0)
            {
                sqlSelect("OrderId", "TableOrders", "addList");

                //populate gridview
                lsOrders.SelectedIndex = 0;
                lblOrderNo.Text = lsOrders.SelectedValue.ToString();
                populateGridView();
            }
        }

        protected void lsOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            //assign selected orderNo and customer to management
            lblOrderNo.Text = lsOrders.SelectedValue.ToString();

            populateGridView();
            enableButtons();
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            sqlDeleteOrder($"TableOrders WHERE OrderId = '{lsOrders.SelectedValue.ToString().Substring(6)}'");
            lsOrders.SelectedValue.Remove(0);

            if(lsOrders.Items.Count != 0)
            {
                lsOrders.SelectedIndex = 0;
                populateGridView();
                enableButtons();
            }
        }

        public void enableButtons()
        {
            //gdOrderStatus.SelectedIndex = 0;
            //if(btnOrderProcessing.Enabled == false && gdOrderStatus.SelectedValue != )
            btnOrderProcessing.Enabled = true;
            btnOrderReady.Enabled = true;
            btnOrderFulfilled.Enabled = true;
        }

        protected void btnOrderProcessing_Click(object sender, EventArgs e)
        {
            sqlUpdate("TableOrders", $"Status = 'Processing'" +
                $" WHERE OrderId = '{lsOrders.SelectedValue.ToString().Substring(6)}'");

            populateGridView();
            btnOrderProcessing.Enabled = false;
        }

        protected void btnOrderReady_Click(object sender, EventArgs e)
        {
            sqlUpdate("TableOrders", $"Status = 'Ready'" +
                $" WHERE OrderId = '{lsOrders.SelectedValue.ToString().Substring(6)}'");

            populateGridView();
            btnOrderReady.Enabled = false;
        }

        protected void btnOrderFulfilled_Click(object sender, EventArgs e)
        {
            sqlUpdate("TableOrders", $"Status = 'Fulfilled'" +
                $" WHERE OrderId = '{lsOrders.SelectedValue.ToString().Substring(6)}'");

            populateGridView();
            btnOrderFulfilled.Enabled = false;
        }

        public void sqlSelect(string column, string tableQuery, string action)
        {
            conn.Open();

            string sql = $"SELECT {column} FROM {tableQuery}";

            comm = new SqlCommand(sql, conn);

            if(action == "addList")
            {
                sqlAddListBox(comm);
            }
            else if(action == "gridView")
            {
                sqlGridView(comm);
            }
            
            conn.Close();
        }

        public void sqlAddListBox(SqlCommand comm)
        {
            dr = comm.ExecuteReader();

            while (dr.Read())
            {
                lsOrders.Items.Add("Order#" + dr.GetValue(0).ToString());
            }
        }

        public void sqlGridView(SqlCommand comm)
        {
            da = new SqlDataAdapter();
            ds = new DataSet();

            da.SelectCommand = comm;
            da.Fill(ds);

            gdOrderStatus.DataSource = ds;
            gdOrderStatus.DataBind();
        }

        public void sqlUpdate(string table, string columnQuery)
        {
            conn.Open();

            string sql = $"UPDATE {table} SET {columnQuery}";

            comm = new SqlCommand(sql, conn);
            da = new SqlDataAdapter();

            da.UpdateCommand = comm;
            da.UpdateCommand.ExecuteNonQuery();

            conn.Close();
        }

        public void populateGridView()
        {
            if(lsOrders.SelectedIndex >= 0)
            {
                //populate gridview
                sqlSelect(
                    "Status, " +
                    "TableCustomers.CustomerName as Customer, " +
                    "Format(TableOrders.Date, 'yyyy-MM-dd, hh:mm') as Date",
                    "TableOrders INNER JOIN TableCustomers " +
                    "ON TableOrders.CustomerId = TableCustomers.CustomerId " +
                    $"WHERE OrderId = '{lsOrders.SelectedValue.ToString().Substring(6)}'",
                    "gridView");
            }
        }

        public void sqlDeleteOrder(string tableQuery)
        {
            conn.Open();

            string sql = $"DELETE FROM {tableQuery}";

            comm = new SqlCommand(sql, conn);
            da = new SqlDataAdapter();

            da.DeleteCommand = comm;
            da.DeleteCommand.ExecuteNonQuery();

            conn.Close();
        }
    }
}