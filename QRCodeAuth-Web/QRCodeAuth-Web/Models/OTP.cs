using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRCodeAuth_Web.Models
{
    public class OTP
    {

        public OTP()
        {

        }

        public static string generateOTP()
        {
            string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            Random randrom = new Random((int)DateTime.Now.Ticks);

            string str = "";
            for (int i = 0; i < 10; i++)
            {
                str += chars[randrom.Next(chars.Length)];
            }

            return str;
        }
    }
}