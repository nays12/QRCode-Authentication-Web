/*
 * Purpose: Startup page for the web application that requres authentication code from 
 * mobile device to login
 * 
 * Algorithm: 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QRCodeAuth_Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            Random randrom = new Random((int)DateTime.Now.Ticks);

            string str = "";
            for (int i = 0; i <=5; i++)
            {
                str += chars[randrom.Next(chars.Length)];
            }

            //test random number
            Response.Write(str);
            //Console.Read();
        }
    }

}