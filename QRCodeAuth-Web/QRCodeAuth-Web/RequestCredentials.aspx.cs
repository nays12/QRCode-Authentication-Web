/*
 * Purpose: Allows users to request digital credentials from a Mobile User's account 
 */

using System;
using QRCodeAuth_Web.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using ZXing;

namespace QRCodeAuth_Web
{
	public partial class RequestCredentials : System.Web.UI.Page
	{

        protected User activeUser = new User();
        protected WebAccount activeWebAccount = new WebAccount();


        protected void Page_Load(object sender, EventArgs e)
		{
            //TESTING - DELETE LATER
            giveValueToAccounts();
			imageQRCode.Visible = false;

			//GetLoggedInUserInfo();
		}

        //If confirm butoon is clicked direct user to the QRCode page to display their QRCode. 
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
			string shareCredentialObject = getShareCredentialObject();
			generateQRCode(shareCredentialObject);

			btnCancel.Text = "Done";
			btnConfirm.Visible = false;
        }

        //If cancel button is clicked redirect user back to home page. 
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

		//Will return a list of the requested credential types selected by information collector. 
		public List<CredentialType> getRequestedCredentialTypes()
		{
			List<CredentialType> types = new List<CredentialType>();

			foreach (ListItem item in cblRequestedCredentials.Items)
			{
				if (item.Selected)
				{
					string selection = item.Value;
					System.Diagnostics.Debug.WriteLine(selection);

					switch (selection)
					{
						case "Name":
							types.Add(CredentialType.Name);
							break;
						case "Email":
							types.Add(CredentialType.Email);
							break;
						case "ID Number":
							types.Add(CredentialType.IdNumber);
							break;
						case "Date of Birth":
							types.Add(CredentialType.Birthdate);
							break;
						case "Address":
							types.Add(CredentialType.Address);
							break;
						case "PhoneNumber":
							types.Add(CredentialType.PhoneNumber);
							break;
						case "Major":
							types.Add(CredentialType.Major);
							break;
						case "Classification":
							types.Add(CredentialType.Classification);
							break;
						case "Work Title":
							types.Add(CredentialType.WorkTitle);
							break;
					}
				}
			}
			cblRequestedCredentials.Visible = false;
			return types;
		}

		//Wil return the object that will be encoded into QRCode. 
		public string getShareCredentialObject()
        {
			// Anonymous object
            var credentialRequest = new
            {
                informationCollector = activeUser.FirstName + " " + activeUser.LastName,
                department = activeWebAccount.Department,
                requestedCredentials = getRequestedCredentialTypes(),
            };

            var result = JsonConvert.SerializeObject(credentialRequest);

            return result;
        }

		protected void generateQRCode(string qrCodeString)
		{
			//get currentPath
			string path = AppDomain.CurrentDomain.BaseDirectory;

			//Create barcode writer 
			BarcodeWriter writer = new BarcodeWriter();
			writer.Format = BarcodeFormat.QR_CODE;

			//Save the QRCode 
			writer.Write(qrCodeString).Save(path + @"Images\QRCodes\credentialQR.jpg");

			//Dispaly QRCode
			imageQRCode.ImageUrl = path + @"Images\QRCodes\credentialQR.jpg";
			imageQRCode.Visible = true;
		}

        //TESTING - DELETE LATER AND USE SESSION USER AND WEB LOG IN INFO.
        public void giveValueToAccounts()
        {
            activeUser.FirstName = "Barbara";
            activeUser.LastName = "McNeal";
            activeWebAccount.Department = "School of Science and Engineering";
        }

		// Retrieve User info from session state
		protected void GetLoggedInUserInfo()
		{
			activeUser = (User)Session["ActiveUser"];
			activeWebAccount = (WebAccount)Session["ActiveWebAccount"];
		}


	}
}