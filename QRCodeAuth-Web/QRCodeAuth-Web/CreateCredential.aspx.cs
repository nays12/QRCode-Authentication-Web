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
		public static List<Credential> issuedCreds = new List<Credential>(); // stores the issued credentials that will be fetched by API
		protected void Page_Load(object sender, EventArgs e)
		{
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;         
        }

		public static List<Credential> getIssuedCredentials()
		{
			return issuedCreds;
		}

		protected void btnCreate_Click(object sender, EventArgs e)
		{
			CreateNewCredential();
        }

        protected void CreateNewCredential()
		{
			var selection = ddlCredentialType.SelectedIndex;
			CredentialType type = (CredentialType)selection;

			Credential cred = new Credential
			{
				Name = txtCredentialName.Text,
				CredentialType = type,
				IssueDate = DateTime.UtcNow,
                ExpirationDate = Convert.ToDateTime(txtExpDate.Text),
                Value = txtValue.Text,
				IsValid = true,
				Owner = txtIssueTo.Text,
				Issuer = "8220423"
			};

			var databaseCred = CredentialsRepo.AddCredential(cred);
			issuedCreds.Add(databaseCred);
		}

		protected void ResetPage()
		{
			txtCredentialName.Text = "";
			txtExpDate.Text = "";
			txtValue.Text = "";
			txtIssueTo.Text = "";
		}

		protected void btnDone_Click(object sender, EventArgs e)
		{
			issuedCreds.Clear();
			Response.Redirect("Home.aspx");
		}
	}

}