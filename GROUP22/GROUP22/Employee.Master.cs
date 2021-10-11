using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GROUP22
{
    public partial class Employee : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void menu_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditMenu.aspx");
        }

        protected void product_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }

        protected void order_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeOrdersSite.aspx");
        }

        protected void account_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerInfo.aspx");
        }

        protected void booking_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBookings.aspx");
        }

        protected void reports_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports.aspx");
        }

        protected void login_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeLogin.aspx");
        }

        protected void signup_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeSignUp.aspx");
        }

        protected void linkLogout_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["empInfo"];
            if(userCookie != null)
            {
                userCookie.Expires.AddDays(-1);
            }

            Response.Redirect("EmployeeLogin.aspx");
        }
    }
}