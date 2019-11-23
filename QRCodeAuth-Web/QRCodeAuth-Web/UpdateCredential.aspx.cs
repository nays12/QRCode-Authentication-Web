using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models;

namespace QRCodeAuth_Web
{
	public partial class UpdateCredential : System.Web.UI.Page
	{
		protected static List<Credential> credentials = new List<Credential>(); // stores the issued credentials that will be fetched by API
		protected static string userId;
		protected void Page_Load(object sender, EventArgs e)
		{
			ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
			BindGrid();
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
			ResetPage();
		}

		protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			GridView1.EditIndex = -1;
			ResetPage();
		}

		protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{

			GridView1.EditIndex = -1;
			ResetPage();
		}

		protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{

			string CredentialId = GridView1.DataKeys[e.RowIndex].Values["CredentialId"].ToString();
			int id = Convert.ToInt32(CredentialId);

			CredentialsRepo.DeleteCredentialById(id);
			credentials = CredentialsRepo.GetOwnerCredentials(userId);
			lblStatus.Text = CredentialsRepo.StatusMessage;

			ResetPage();
		}

		protected void ResetPage()
		{
			BindGrid();
			txtMobileId.Text ="";
		}


	}
}