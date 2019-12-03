﻿/*
 * Purpose: Allows users to request digital credentials from a Mobile User's account 
 */

using System;
using QRCodeAuth_Web.Models;
using QRCodeAuth_Web.Data;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using ZXing;
using System.Net;
using System.IO;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.Hosting;

namespace QRCodeAuth_Web
{
	public partial class RequestCredentials : System.Web.UI.Page
	{

        protected User activeUser = new User();
        protected WebAccount activeWebAccount = new WebAccount();

		protected static string credentialOwnerId;
		protected static List<Credential> fetchedCreds = new List<Credential>();
		protected void Page_Load(object sender, EventArgs e)
		{
            //TESTING - DELETE LATER
            giveValueToAccounts();
			gvCreds.DataBind();
			imgQRCode.Visible = false;
			btnGetCreds.Visible = false;
			string path = HostingEnvironment.MapPath("~/");
			lblTest.Text = path;
			//GetLoggedInUserInfo();

		}

		public static void GetNewCredentials(List<Credential> creds)
		{
			foreach (Credential c in creds)
			{
				fetchedCreds.Add(c);
				credentialOwnerId = c.Owner;
			}
		}

		protected void btnConfirm_Click(object sender, EventArgs e)
        {
			CreateCredentialsObject();

			btnCancel.Text = "Done";
			btnConfirm.Visible = false;
			btnGetCreds.Visible = true;
			lblSubtitle.Text = "Instruct the user to scan the QR Code";
		}

		protected void btnGetCreds_Click(object sender, EventArgs e)
		{
			if (credentialOwnerId != null)
			{
				lblSubtitle.Text = "Here are the user's credentials";

				User u = UsersRepo.FindUserById(credentialOwnerId);
				lblOwnerId.Text = string.Format("UserId: {0}", u.UserId);
				lblOwnerName.Text = string.Format("Name: {0} {1}", u.FirstName, u.LastName);
				lblOwnerType.Text = string.Format("Group: {0}", u.UserType);

				gvCreds.DataSource = fetchedCreds;
				gvCreds.DataBind();
			}
			else
			{
				lblSubtitle.Text = "No credentials found";
				lblOwnerId.Text = "Make sure the User properly scanned the QR code and sent their credentials in their Mobile Token Account";

			}
		}

		// If cancel button is clicked redirect user back to home page. 
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
		public void CreateCredentialsObject()
        {
			// Anonymous object
            var credentialRequest = new
            {
                informationCollector = activeUser.FirstName + " " + activeUser.LastName,
                department = activeWebAccount.Department,
                requestedCredentials = getRequestedCredentialTypes(),
            };

            var result = JsonConvert.SerializeObject(credentialRequest);

			generateQRCode(result);
        }

		protected void generateQRCode(string qrCodeString)
		{
			//string serverPath = HttpContext.Current.Server.MapPath("~/");
			string path = HostingEnvironment.MapPath(".");
			//string imagePath = "~/Images/QRCodes/credentialQR.jpg";
			string imagePath = "/Images/QRCodes";

			//Create barcode writer 
			BarcodeWriter writer = new BarcodeWriter();
			writer.Format = BarcodeFormat.QR_CODE;
			writer.Write(qrCodeString).Save(path+ imagePath + "/qr2.jpg",);
			//var barcodeBitmap = new Bitmap(qrCode);
			 
			//FileStream fs = new FileStream(	serverPath,
			//image = Image.FromFile(openFileDialog1.FileName);
			//image.Save(ftpStream, System.Drawing.Imaging.ImageFormat.Png);
			//using (MemoryStream memory = new MemoryStream())
			//{
			//	using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("~/"), FileMode.Append))
			//	{
			//		barcodeBitmap.Save(memory, ImageFormat.Jpeg);
			//		byte[] bytes = memory.ToArray();
			//		fs.Write(bytes, 0, bytes.Length);
			//	}
			//}

			//Dispaly QRCode
			imgQRCode.Visible = true;
			//imgQRCode.ImageUrl = userDesktopPath;


			// Upload generated QR to azure web app storage
			string storageConn = "DefaultEndpointsProtocol=https;AccountName=qrcodeauthwebfiles;AccountKey=xVEiGT04ojCHS0YPUMUUxesstHpGTy7+FERwq8Vm7yuGLjoBYHTGsOMxu/SfRGbd5Z/y8NffaA/XlO0tT/ZhtA==;EndpointSuffix=core.windows.net";
			CloudStorageAccount storageAcc = CloudStorageAccount.Parse(storageConn);

			//reference Azure blob
			CloudBlobClient bobClient = storageAcc.CreateCloudBlobClient();

			// get container
			CloudBlobContainer container = bobClient.GetContainerReference("qr-codes");
			container.CreateIfNotExists();

			// upload file to container
			CloudBlockBlob blockBlob = container.GetBlockBlobReference("QRBlob2");

			//using (var filestream = File.OpenRead(qrCode.))
			//{
			//	qrCode.Save("https://qrcodeauthwebfiles.blob.core.windows.net/qr-codes/QRBlob/credQR.jpg");
			//	//blockBlob.UploadFromStream(filestream);
			//}

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