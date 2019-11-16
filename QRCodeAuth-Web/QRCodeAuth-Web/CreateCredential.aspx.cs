using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QRCodeAuth_Web
{
	public partial class CreateCredential : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnCreate_Click(object sender, EventArgs e)
		{

		}

		protected void CreateNewCredential()
		{
			var type = ddlCredentialType.SelectedItem;


			using (var dbconn = new WebSystemData())
			{
				Account credentialIssuer = new Account();
				credentialIssuer = dbconn.Accounts.Find(3);

				Account credentialOwner = new Account();
				credentialOwner = dbconn.Accounts.Find(5);

				Credential cred = new Credential
				{
					Name = txtCredentialName.ToString(),
					CredentialType = CredentialType.Email,
					Issuer = credentialIssuer,
					Owner = credentialOwner,
					IssueDate = Convert.ToDateTime("01/15/2016"),
					ExpirationDate = Convert.ToDateTime("12/21/2019"),
					Value = "naomiwiggins08@gmail.com",
					IsValid = true
				};
			}
		}
	}
}