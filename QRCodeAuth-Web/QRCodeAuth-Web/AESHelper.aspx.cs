/*
 * Purpose: 
 * This class using symmetric key cryptography to take an input and encrypt/decrypt it
 * 
 * Contributors: 
 * Zhihao Gao 
 * 
 */

using System;
using System.Text;
using System.Security.Cryptography;

namespace QRCodeAuth_Web
{
    public partial class AESHelper : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string AesEncrypt(string str, string key)
        {
            if (string.IsNullOrEmpty(str)) return null;  //no string sent handle
            Byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);

            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray);

        }


        public string AesDecrypt(string str, string key)
        {
            if (string.IsNullOrEmpty(str)) return null;  //no string sent handle
            Byte[] toEncryptArray = Convert.FromBase64String(str);

            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateDecryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Encoding.UTF8.GetString(resultArray);

        }

    }
}