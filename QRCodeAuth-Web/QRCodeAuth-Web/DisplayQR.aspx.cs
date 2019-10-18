using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace QRCodeAuth_Web
{
	public partial class DisplayQR : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void generateQR_Click(object sender, EventArgs e)
		{
			string path = AppDomain.CurrentDomain.BaseDirectory;

			BarcodeWriter writer = new BarcodeWriter();
			writer.Format = BarcodeFormat.QR_CODE;


			writer.Write("another test")
					.Save(path + @"Images\QRCodes\geneatedQR.bmp");

		}
	}
}