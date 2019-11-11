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
using System.Text.RegularExpressions;
using System.Web.UI;

namespace QRCodeAuth_Web
{
    public partial class Default : System.Web.UI.Page
    {
		protected static int generatedCode; // stores the generated code from the API call
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        }
		public static int getGenCode()
		{
			int code = generateCode();
			generatedCode = code;
			System.Diagnostics.Debug.WriteLine(code);
			return code;
		}

		// Generate random 6 digit number;
		public static int generateCode()
		{
			int min = 100000;
			int max = 999999;

			Random ran = new Random();
			int code = ran.Next(min, max);

			// see generated code
			

			return code;
		}

		// Check to see if generated number matched entered number
		public bool validateCode(int code1, int code2)
		{
			if (code1 == code2)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
            if(Page.IsValid)
            {
                int userCode = Convert.ToInt32(txtCode.Text); // get user's code form text input
                bool isCodeValid = validateCode(generatedCode, userCode); // check validity
                lblValidCode.Text = isCodeValid.ToString();

                if (isCodeValid)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblValidCode.Text = "* The code you entered is incorrect. Please Try Again";
                }
            }
 
		}

		public string generateOTP()
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