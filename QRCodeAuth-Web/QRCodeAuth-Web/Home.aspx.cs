/*
 * Purpose: Web User's home page which allows them to create an Event or request digital 
 * credentials from Mobile users
 */

using System;

namespace QRCodeAuth_Web
{
	public partial class Home : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

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
	}
}