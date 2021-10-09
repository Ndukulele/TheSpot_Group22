using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheSpotGroup22
{
    public partial class EmployeeSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logOut_Click(object sender, EventArgs e)
        {
            HttpCookie employeeCookie = Request.Cookies["employeeInfo"];

            employeeCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(employeeCookie);

            Response.Redirect("EmployeeLogin.aspx");
        }
    }
}