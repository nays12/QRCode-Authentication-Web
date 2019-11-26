/*
 * Purpose: Web User's home page which allows them to create an Event or request digital 
 * credentials from Mobile users
 */

using QRCodeAuth_Web.Models;
using System;

namespace QRCodeAuth_Web
{
	public partial class Home : System.Web.UI.Page
	{
		protected User activeUser = new User();
		protected WebAccount activeWebAccount = new WebAccount();
		protected void Page_Load(object sender, EventArgs e)
		{
			GetLoggedInUserInfo();
			welcomeUser();
			CheckUserPermissions();
		}

		// Retrieve User info from session state
		protected void GetLoggedInUserInfo()
		{
			activeUser = (User)Session["ActiveUser"];
			activeWebAccount = (WebAccount)Session["ActiveWebAccount"];
		}

		// Welcome the User according to the group they belong to 
		protected void welcomeUser()
		{
			switch (activeUser.UserType)
			{
				case UserType.Faculty:
					lblWelcome.Text = string.Format("Welcome, Dr. {0} {1}!", activeUser.FirstName, activeUser.LastName);
					lbldeptInfo.Text = string.Format("You are logged into your account for the {0}", activeWebAccount.Department);
					lblWelcome2.Text = "What would you like to do?";
					break;

				case UserType.Staff:
					lblWelcome.Text = string.Format("Welcome, {0} {1}!", activeUser.FirstName, activeUser.LastName);
					lbldeptInfo.Text = string.Format("You are logged into your account for the {0}", activeWebAccount.Department);
					lblWelcome2.Text = "What would you like to do?";
					break;

				case UserType.Student:
					lblWelcome.Text = string.Format("Welcome, {0}!", activeUser.FirstName);
					lbldeptInfo.Text = string.Format("You are logged into your account for the {0}", activeWebAccount.Department);
					lblWelcome2.Text = "What would you like to do?";
					break;
			}
		}

		// Make the buttons visibile based on the Account permissions
		protected void CheckUserPermissions()
		{
			if (activeWebAccount.IsCredentialAuthority) { btnCreateCredential.Visible = true; btnUpdateCredential.Visible = true; }
			if (activeWebAccount.IsAttendanceManager) { btnCreateEvent.Visible = true; }
			if (activeWebAccount.IsCredentialAuthority) { btnRequest.Visible = true; }
		}

		protected void btnCreateEvent_Click(object sender, EventArgs e)
		{
			Response.Redirect("CreateEvent.aspx");
		}

		protected void btnRequest_Click(object sender, EventArgs e)
		{
			Response.Redirect("RequestCredentials.aspx");
		}

		protected void btnCreateCredential_Click(object sender, EventArgs e)
		{
			Response.Redirect("CreateCredential.aspx");
		}

		protected void btnUpdateCredential_Click(object sender, EventArgs e)
		{
			Response.Redirect("UpdateCredential.aspx");
		}

		protected void btnLogout_Click(object sender, EventArgs e)
		{
			Session["ActiveUser"] = null;
			Session["ActiveWebAccount"] = null;

			Response.Redirect("Default.aspx");
		}
	}
}