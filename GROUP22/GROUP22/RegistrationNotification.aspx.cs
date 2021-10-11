using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GROUP22
{
    public partial class RegistrationNotification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //master page control
            ImageButton imgProfile = (ImageButton)Page.Master.FindControl("imgProfile");
            imgProfile.Visible = false;

            LinkButton linkMenu = (LinkButton)Page.Master.FindControl("linkMenu");
            linkMenu.Visible = false;
            LinkButton linkBook = (LinkButton)Page.Master.FindControl("linkBookTable");
            linkBook.Visible = false;
            LinkButton linkBookings = (LinkButton)Page.Master.FindControl("linkBookings");
            linkBookings.Visible = false;
            LinkButton linkOrders = (LinkButton)Page.Master.FindControl("linkOrders");
            linkOrders.Visible = false;
            LinkButton linkCart = (LinkButton)Page.Master.FindControl("linkCart");
            linkCart.Visible = false;

            LinkButton linkLogin = (LinkButton)Page.Master.FindControl("linkUserLogin");
            linkLogin.Visible = true;
            LinkButton linkSignUp = (LinkButton)Page.Master.FindControl("linkSignUp");
            linkSignUp.Visible = true;
            Label linkHello = (Label)Page.Master.FindControl("lblHelloUser");
            linkHello.Visible = false;
            LinkButton linkLogout = (LinkButton)Page.Master.FindControl("linkLogout");
            linkLogout.Visible = false;

            LinkButton linkEmpLog = (LinkButton)Page.Master.FindControl("linkEmployeeLogin");
            linkEmpLog.Visible = true;
            LinkButton linkEmpReg = (LinkButton)Page.Master.FindControl("linkEmployeeRegistration");
            linkEmpReg.Visible = true;
            //

            HttpCookie userCookie = Request.Cookies["UserInfo"];
            if (userCookie != null)
            {
                if (!IsPostBack)
                {

                }

                Response.Redirect("Menu.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }
    }
}