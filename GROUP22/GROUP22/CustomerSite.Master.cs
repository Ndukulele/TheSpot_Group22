using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheSpotGroup22
{
    public partial class CustomerSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void userLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void signUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void logOut_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserInfo"];

            userCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(userCookie);

            Response.Redirect("UserLogin.aspx");
        }

        protected void helloUser_Click(object sender, EventArgs e)
        {

        }

        protected void employeeLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeLogin.aspx");
        }

        protected void EmployeeRegistraction_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeSignUp.aspx");
        }
    }
}