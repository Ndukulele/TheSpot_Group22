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
    public partial class customerOrderInquiry : System.Web.UI.Page
    {
        public string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|TheSpotDatabase.mdf;Integrated Security=True";
        public SqlConnection conn;
        public SqlCommand comm;
        public SqlDataReader dr;
        public SqlDataAdapter da;
        public DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connStr);

            if(gdOrderStatus.Rows.Count == 0)
            {
                sqlQueries("SELECT orderId, productName, productPrice, productQty, orderTotalPrice, status",
                    "FROM TableOrderDetails WHERE orderId = '28'","gridView");
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            sqlQueries("SELECT orderId, productName, productPrice, productQty, orderTotalPrice, status",
                    "FROM TableOrderDetails WHERE orderId = '28'", "gridView");
        }

        //universal sql statements begin
        public void sqlQueries(string query, string condition, string action)
        {
            conn.Open();

            string sql = $"{query} {condition}";

            comm = new SqlCommand(sql, conn);

            sqlActions(action);

            conn.Close();
        }

        public void sqlActions(string action)
        {
            if (action == "gridView") //if gridview
            {
                da = new SqlDataAdapter();
                ds = new DataSet();

                da.SelectCommand = comm;
                da.Fill(ds);

                gdOrderStatus.DataSource = ds;
                gdOrderStatus.DataBind();
            }
            else if (action == "delete")
            {
                da = new SqlDataAdapter();

                da.DeleteCommand = comm;
                da.DeleteCommand.ExecuteNonQuery();
            }
        }
        //universal sql statements end
    }
}