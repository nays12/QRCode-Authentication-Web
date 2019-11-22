using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models;

namespace QRCodeAuth_Web
{
	public partial class UpdateCredential : System.Web.UI.Page
	{
		public static List<Credential> credentials = new List<Credential>(); // stores the issued credentials that will be fetched by API
		protected void Page_Load(object sender, EventArgs e)
		{
			ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
		}

		protected void btnGetCredentials_Click(object sender, EventArgs e)
		{
			string userId = txtMobileId.Text;
			credentials = CredentialsRepo.GetOwnerCredentials(userId);
			GridView1.DataSource = credentials;
			GridView1.DataBind();
		}

	}
}