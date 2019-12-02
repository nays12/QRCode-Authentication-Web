/*
 * Purpose: Startup page for the web application that requres authentication code from 
 * mobile device to login
 * 
 * Algorithm: 
 * 
 */

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models;
using QRCodeAuth_Web.Controllers;

namespace QRCodeAuth_Web
{
    public partial class Default : System.Web.UI.Page
    {
		protected static int generatedCode; // stores the generated code from the API call
		protected static User activeUser = new User(); // stores recieved user from API call

		protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
			ResetPage();
		}
		public static int GetGenCode()
		{		
			int code = generateCode();
			generatedCode = code;
			System.Diagnostics.Debug.WriteLine(code);
			return code;
		}

		public static void GetUserFromMobile(User u)
		{
			activeUser = u;
			System.Diagnostics.Debug.WriteLine(activeUser.UserId);
		}

		// Generate random 6 digit number;
		public static int generateCode()
		{
			// specifying the range for the generated number
			int min = 100000;
			int max = 999999;

			Random ran = new Random();
			int code = ran.Next(min, max);

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
			lblValidCode.Text = "";
			if (IsPostBack)
			{
				if (Page.IsValid)
				{
					int userCode = Convert.ToInt32(txtCode.Text); // get user's code form text input
					bool isCodeValid = validateCode(generatedCode, userCode); // check equality
					bool isUserFound = GetAccountInfo();

					if (isCodeValid)
					{
						if (isUserFound)
						{
							Response.Redirect("Home.aspx");
						}
						else
						{
							lblStatus.Text = "You do not have an active Web Account. Please go to your Credential Authority to set one up.";
						}
					}
					else
					{
						lblStatus.Text = "Your Web Account was found. Please use your Mobile Account to get the correct login code.";
						lblValidCode.Text = "The code entered is incorrect.";
					}
				}
			}
		}

		protected bool GetAccountInfo() // Gets user info and puts it in session state
		{
		
			// Get user's Web Account info
			WebAccount wa = new WebAccount();
			wa = WebAccountsRepo.FindAccountById(activeUser.UserId);

			// Check to see if the information could be found
			if (wa != null)
			{
				Session["ActiveUser"] = activeUser;
				Session["ActiveWebAccount"] = wa;
				return true;
			}
			else
			{
				lblStatus.Text = "You do not have an active Web Account. Please go to your Credential Authority to set one up.";
				return false;
			}
		}

		protected void ResetPage()
		{
			lblStatus.Text = "";
			lblValidCode.Text = "";
		}

	}
}