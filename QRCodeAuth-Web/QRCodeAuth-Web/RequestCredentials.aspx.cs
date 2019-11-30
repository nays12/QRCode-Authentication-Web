/*
 * Purpose: Allows users to request digital credentials from a Mobile User's account 
 */

using System;
using QRCodeAuth_Web.Models;

namespace QRCodeAuth_Web
{
	public partial class RequestCredentials : System.Web.UI.Page
	{
        protected User activeUser = new User();
        protected WebAccount activeWebAccount = new WebAccount();


        protected void Page_Load(object sender, EventArgs e)
		{
            GetLoggedInUserInfo();

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Response.Redirect("DisplayQR.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        // Retrieve User info from session state
        protected void GetLoggedInUserInfo()
        {
            activeUser = (User)Session["ActiveUser"];
            activeWebAccount = (WebAccount)Session["ActiveWebAccount"];
        }
    }
}