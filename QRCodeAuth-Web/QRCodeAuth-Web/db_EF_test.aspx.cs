/*
 * Purpose: Test page that allows the developers to test operations on the database as well 
 * review query syntax.
 * 
 * Algorithm: 
 * EntityCRUDTEST
 * EventControllerTest
 */

using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models;
using System;
using System.Collections.Generic;

namespace QRCodeAuth_Web
{
	public partial class db_EF_test : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			CredentialsRepo.GetOwnerCredentials("1304693");
			//UsersCRUD();
			//MobileAccountsCRUD();
			//WebAccountsCRUD();
			//EventsCRUD();
			//CredentialsCRUD();
		}

		protected void UsersCRUD()
		{
			//Creates a User object and inserts it into the database
			User u1 = new User
			{
				UserId = "1646825",
				LastName = "Perez-Davila",
				FirstName = "Alfredo",
				UserType = UserType.Faculty
			};

			UsersRepo.AddNewUser(u1);
			System.Diagnostics.Debug.WriteLine(UsersRepo.StatusMessage);

			//// Finds a user by their ID
			//info = dbconn.Users.Find("1195191");
			//Response.Write("the selected is: " + info.UserId + " ; " + info.FirstName + " " + info.LastName);

			//// Finds a user by thier ID and then updates their first name
			//info = dbconn.Users.Find("1195191");
			//info.FirstName = "zhimin";
			//dbconn.SaveChanges();

			//// Finds a user by thier ID and then deletes them from the database
			//info = dbconn.Users.Find("1453678");
			//dbconn.Users.Remove(info);

			//dbconn.SaveChanges(); // updates the changes in the database

		}

		protected void MobileAccountsCRUD()
		{
			//get Users to be account owner
			User accountOwner1 = UsersRepo.FindUserById("1304693");

			MobileAccount acc1 = new MobileAccount
			{
				MobileId = accountOwner1.UserId,
				Department = "College of Science and Engineering",
				IsActive = true
			};
			MobileAccountsRepo.AddAccount(acc1);
			System.Diagnostics.Debug.WriteLine(MobileAccountsRepo.StatusMessage);
		}

		protected void WebAccountsCRUD()
		{
			//get Users to be account owner
			User accountOwner1 = UsersRepo.FindUserById("1646825");

			WebAccount w = new WebAccount
			{
				WebId = accountOwner1.UserId,
				Department = "College of Science and Engineering",
				IsActive = true,
				IsCredentialAuthority = false,
				IsAttendanceManager = true,
				IsInformationCollector = false
			};
			WebAccountsRepo.AddAccount(w);
			System.Diagnostics.Debug.WriteLine(WebAccountsRepo.StatusMessage);
		}

		protected void EventsCRUD()
		{
			// Create event object
			Event e1 = new Event
			{
				Name = "Delta Waffle Day",
				Location = "Delta Building Lobby",
				EventType = EventType.Campus,
				Description = "Free Waffles at the Delta building!",
				StartTime = Convert.ToDateTime("10/30/2019 02:30pm"),
				EndTime = Convert.ToDateTime("10/30/2019 06:30pm"),
				Owner = "8764710"
			};
			EventsRepo.AddEvent(e1);
			System.Diagnostics.Debug.WriteLine(EventsRepo.StatusMessage);
		}

		protected void CredentialsCRUD()
		{
			Credential cred = new Credential
			{
				Name = "Student Full Name",
				CredentialType = CredentialType.Name,
				IssueDate = Convert.ToDateTime("01/15/2016"),
				ExpirationDate = Convert.ToDateTime("12/21/2019"),
				Value = "Naomi S. Wiggins",
				IsValid = true,
				Owner = "1304693",
				Issuer = "8220423"
			};
			CredentialsRepo.AddCredential(cred);
		}

	}
}