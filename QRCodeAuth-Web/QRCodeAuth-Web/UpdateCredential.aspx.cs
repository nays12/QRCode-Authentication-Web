﻿/*
 * Purpose: Allows a User to retrieve, modify, or delete the Credentials of a Mobile Account.
 * 
 * Contributors: 
 * Naomi Wiggins
 */

using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models;

namespace QRCodeAuth_Web
{
	public partial class UpdateCredential : System.Web.UI.Page
	{
		protected static List<Credential> credentials = new List<Credential>(); // stores the credentials from database that are being shown in the GridView
		protected static List<Credential> mobileCredentials = new List<Credential>(); // stores the updated credentials that will be fetched by the mobile app
		protected static string userId;
		protected static int deleteCredentialId;
		protected void Page_Load(object sender, EventArgs e)
		{
			ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
			if (!IsPostBack) { BindGrid(); }
		}

		public static List<Credential> getUpdatedCredentials()
		{
			return mobileCredentials;
		}
		public static int GetCredentialIdToDelete()
		{
			return deleteCredentialId;
		}
		protected void btnGetCredentials_Click(object sender, EventArgs e)
		{
			userId = txtMobileId.Text;
			credentials = CredentialsRepo.GetOwnerCredentials(userId);
			BindGrid();
		}

		private void BindGrid()
		{		
			GridView1.DataSource = credentials;
			GridView1.DataBind();
		}

		protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
		{
			GridView1.EditIndex = e.NewEditIndex;
			BindGrid();
		}

		protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			GridView1.EditIndex = -1;
			BindGrid();
		}

		protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];

			// Get values from DataGrid and convert them to Credential Object types 
			int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["CredentialId"]);
			// Convert to enum from string representation of enum
			CredentialType type = (CredentialType)Enum.Parse(typeof(CredentialType), Convert.ToString(e.NewValues["CredentialType"])); 
			string name = Convert.ToString(e.NewValues["Name"]);
			string value = Convert.ToString(e.NewValues["Value"]);
			DateTime issueDate = Convert.ToDateTime(e.NewValues["IssueDate"]);
			DateTime expDate = Convert.ToDateTime(e.NewValues["ExpirationDate"]);
			bool valid = Convert.ToBoolean(e.NewValues["IsValid"]);
			string issuer = Convert.ToString(e.NewValues["Issuer"]);

			// Create new Credential
			Credential cred = new Credential
			{
				CredentialId = id,
				Name = name,
				CredentialType = type, 
				IssueDate = issueDate,
				ExpirationDate = expDate,
				Value = value,
				IsValid = valid,
				Owner = userId,
				Issuer = issuer
			};

			mobileCredentials.Add(cred);
			CredentialsRepo.UpdateCredential(id, cred);
			credentials = CredentialsRepo.GetOwnerCredentials(userId);
			lblStatus.Text = CredentialsRepo.StatusMessage;
			GridView1.EditIndex = -1;
			BindGrid();
		}

		protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["CredentialId"]);

			deleteCredentialId = id;
			CredentialsRepo.DeleteCredentialById(id);		
			credentials = CredentialsRepo.GetOwnerCredentials(userId);
			lblStatus.Text = CredentialsRepo.StatusMessage;

			BindGrid();
		}

		protected void btnDone_Click(object sender, EventArgs e)
		{
			mobileCredentials.Clear();
			credentials.Clear();
			deleteCredentialId = 0;
			userId = "";
			Response.Redirect("Home.aspx");
		}
	}
}