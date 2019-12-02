using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;

namespace QRCodeAuth_Web
{
    public partial class QRCodePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imageQRCode.Visible = false;

            string str = Session["QRString"].ToString();
            generateQRCode(str);
        }

        protected void generateQRCode(string qrCodeString)
        {
            //get currentPath
            string path = AppDomain.CurrentDomain.BaseDirectory;

            //Create barcode writer 
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;

            //Save the QRCode 
            writer.Write(qrCodeString).Save(path + @"Images\QRCodes\generatedQR.jpg");

            //Dispaly QRCode
            imageQRCode.ImageUrl = path + @"Images\QRCodes\generatedQR.jpg";
            imageQRCode.Visible = true;
        }


        // If button done is clicked remove the session state for the QRstring. 
        protected void btnDone_Click(object sender, EventArgs e)
        {
            Session.Remove("QRString");
            Response.Redirect("Home.aspx");
        }
    }

}