﻿using QRCodeAuth_Web.Data;
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
				CredentialOwner = txtIssueTo.Text,
				CredentialIssuer = "8220423"
			};
			CredentialsRepo.AddCredential(cred);
		}

	}

}