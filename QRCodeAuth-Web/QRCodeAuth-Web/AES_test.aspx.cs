using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QRCodeAuth_Web
{
    public partial class AES_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string original = "We need to encrypt!";
            string k = "1111111111111111";
            string en_res = "";
            string de_res = "";

            Response.Write("original string: " + original);  //ouput the org string
            Response.Write("</br>");

            AESHelper aes = new AESHelper();    //start encryption
            en_res = aes.AesEncrypt(original, k);

            Response.Write("After encrypt: " + en_res);  //output the encryption
            Response.Write("</br>");

            de_res = aes.AesDecrypt(en_res, k);     //start Decryption
            Response.Write("After decrypt: " + de_res);  //output the encryption
            Response.Write("</br>");




        }
        

    }
}