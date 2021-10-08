using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GROUP22
{
    public partial class Order_Notification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label376.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int num = r.Next();
            Response.Write(num.ToString());
            Label376.Text = "Your order has been received by the resturant and your order number is " + num.ToString() ;

        }
    }
}