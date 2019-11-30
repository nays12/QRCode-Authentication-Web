/*
 * Purpose: Generates and displays QR codes from Event data that is passed in
 * 
 * Algorithm: 
 * Generate QRCode from test data
 * Load QR into image control for display
 */

using Newtonsoft.Json;
using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ZXing;

namespace QRCodeAuth_Web
{
	public partial class DisplayQR : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//makeEventQR();
		}

		protected void generateQR_Click(object sender, EventArgs e)
		{
			// get current path
			string path = AppDomain.CurrentDomain.BaseDirectory;

			// create barcode writer that creates QR Code
			BarcodeWriter writer = new BarcodeWriter();
			writer.Format = BarcodeFormat.QR_CODE;

			// Get event to encode
			string ev = makeEventQR();

			// encode this text into the qr code and save it to the specified path 
			writer.Write(ev).Save(path + @"Images\QRCodes\generatedQR.jpg");

			// load genered qr image into QR image control
			Image1.ImageUrl = path + @"Images\QRCodes\generatedQR.jpg";
		}

		protected void btnReadQR_Click(object sender, EventArgs e)
		{
			// Create Barcode Reader
			BarcodeReader reader = new BarcodeReader();

			try
			{
				var bitmap = ConvertToBitmap(Image1.ImageUrl); // Convert Image to bitmap file

				var data = reader.Decode(bitmap); // Decode data from bitmap QR

				System.Diagnostics.Debug.WriteLine(data); // See decoded data
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message); // See error message
			}
		}

		// Converts image to bitmap file
		public Bitmap ConvertToBitmap(string fileName)
		{
			Bitmap bitmap;
			using (Stream bmpStream = System.IO.File.Open(fileName, System.IO.FileMode.Open))
			{
				Image image = Image.FromStream(bmpStream);

				bitmap = new Bitmap(image);
			}
			return bitmap;
		}

		protected string makeEventQR()
		{
			List<CredentialType> credentialsNeeded = new List<CredentialType>();
			credentialsNeeded.Add(CredentialType.Name);
			credentialsNeeded.Add(CredentialType.Major); 

			Event e1 = new Event
			{
				EventId = 4,
				Name = "Delta Waffle Day",
				Location = "Delta Building Lobby",
				EventType = EventType.Campus,
				Description = "Free Waffles at the Delta building!",
				StartTime = Convert.ToDateTime("10/30/2019 02:30pm"),
				EndTime = Convert.ToDateTime("10/30/2019 06:30pm"),
				CredentialsNeeded = credentialsNeeded,
				Owner = "8764710"
			};

			string dbEvent = JsonConvert.SerializeObject(e1);
			System.Diagnostics.Debug.WriteLine(dbEvent); // See retrieved event
			return dbEvent;
		}

	}
}