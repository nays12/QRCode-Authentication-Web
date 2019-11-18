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
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

		protected void btnCreate_Click(object sender, EventArgs e)
		{
			CreateNewCredential();
		}

		protected void CreateNewCredential()
		{
			var selection = ddlCredentialType.SelectedIndex;
			CredentialType type = (CredentialType)selection;


			using (var dbconn = new WebSystemData())
			{
				Account credentialIssuer = new Account();
				credentialIssuer = dbconn.Accounts.Find("8220423", AccountType.Web);

				Account credentialOwner = new Account();
				credentialOwner = dbconn.Accounts.Find(txtIssueTo.Text, AccountType.Mobile);

				Credential cred = new Credential
				{
					Name = txtCredentialName.Text,
					CredentialType = type,
					CredentialIssuer = credentialIssuer,
					CredentialOwner = credentialOwner,
					IssueDate = DateTime.UtcNow,
					ExpirationDate = Convert.ToDateTime(txtExpDate.Text),
					Value = txtValue.Text,
					IsValid = true
				};

				dbconn.Credentials.Add(cred);
				dbconn.SaveChanges();
			}
		}
	}
}