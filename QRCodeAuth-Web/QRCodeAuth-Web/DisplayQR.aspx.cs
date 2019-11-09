/*
 * Purpose: Generates and displays QR codes from Event data that is passed in
 * 
 * Algorithm: 
 * Generate QRCode from test data
 * Load QR into image control for display
 */

using System;
using ZXing;

namespace QRCodeAuth_Web
{
	public partial class DisplayQR : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void generateQR_Click(object sender, EventArgs e)
		{
			// get current path
			string path = AppDomain.CurrentDomain.BaseDirectory;

			// create barcode writer that creates QR Code
			BarcodeWriter writer = new BarcodeWriter();
			writer.Format = BarcodeFormat.QR_CODE;

			// encode this text into the qr code and save it to the specified path 
			writer.Write("This is a test").Save(path + @"Images\QRCodes\generatedQR.jpg");

			// load genered qr image into QR image control
			Image1.ImageUrl = path + @"Images\QRCodes\generatedQR.jpg";
		}
	}
}