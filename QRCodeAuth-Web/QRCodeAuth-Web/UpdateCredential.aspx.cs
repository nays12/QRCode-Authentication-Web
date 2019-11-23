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
			BindGrid();
		}

		private void BindGrid()
		{
			credentials = CredentialsRepo.GetOwnerCredentials(userId);
			GridView1.DataSource = credentials;
			GridView1.DataBind();
		}
		protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
		{
			GridView1.EditIndex = e.NewEditIndex;
			BindGrid();
		}

		protected void GridView1_RowCancelingEdit(object sender, GridViewEditEventArgs e)
		{
			GridView1.EditIndex = e.NewEditIndex;
			BindGrid();
		}

		protected void GridView1_RowUpdating(object sender, GridViewEditEventArgs e)
		{

			GridView1.EditIndex = -1;
			BindGrid();
		}

		protected void GridView1_RowDeleting(object sender, GridViewEditEventArgs e)
		{

			GridView1.EditIndex = -1;
			BindGrid();
		}


	}
}