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
			
		}

		protected void UsersCRUD()
		{
			using (var dbconn = new WebSystemData())
			{
				// Creates a User object and inserts it into the database
				User info = new User
				{
					UserId = "4093722",
					FirstName = "Shirley",
					LastName = "Schultz",
					Group = UserType.Staff
				};

				User u2 = new User
				{
					UserId = "8220423",
					FirstName = "Reina",
					LastName = "Reyes",
					Group = UserType.Staff
				};

				dbconn.Users.Add(info);
				dbconn.Users.Add(u2);
				dbconn.SaveChanges();

				// Finds a user by their ID
				info = dbconn.Users.Find("1195191");
				Response.Write("the selected is: " + info.UserId + " ; " + info.FirstName + " " + info.LastName);

				// Finds a user by thier ID and then updates their first name
				info = dbconn.Users.Find("1195191");
				info.FirstName = "zhimin";
				dbconn.SaveChanges();

				// Finds a user by thier ID and then deletes them from the database
				info = dbconn.Users.Find("1453678");
				dbconn.Users.Remove(info);

				dbconn.SaveChanges(); // updates the changes in the database
			}
		}

		protected void EventsCRUD()
		{
			// Create events to test EventsController
			using (var dbconn = new WebSystemData())
			{
				// create list of credentials
				List<CredentialType> credentials = new List<CredentialType>();
				credentials.Add(CredentialType.Email);
				credentials.Add(CredentialType.Major);

				// create list of attendees
				List<Account> eventAttendees = new List<Account>();

				// Create event object
				Event e1 = new Event
				{
					Name = "Delta Waffle Day",
					Location = "Delta Building Lobby",
					Type = EventType.Campus,
					Description = "Free Waffles at the Delta building!",
					StartTime = Convert.ToDateTime("10/30/2019 02:30pm"),
					EndTime = Convert.ToDateTime("10/30/2019 06:30pm"),
					Owner = null,
					CredentialsRequired = credentials,
					Attendees = eventAttendees
				};

				Event e2 = new Event
				{
					Name = "Trick or Treat at the Rec",
					Location = "Recreation and Wellness Center",
					Type = EventType.Campus,
					Description = "reat yourself to spooky treats, fun activities and more at UHCL's first Trick or Treat at The Rec!",
					StartTime = Convert.ToDateTime("10/31/2019 04:00pm"),
					EndTime = Convert.ToDateTime("10/31/2019 09:00pm"),
					Owner = null,
					CredentialsRequired = credentials,
					Attendees = eventAttendees
				};

				dbconn.Events.Add(e1);
				dbconn.Events.Add(e2);
				dbconn.SaveChanges();
			}
		}

		protected void AccountCRUD()
		{
			using (var dbconn = new WebSystemData())
			{
				// create list of events
				List<Event> eventsOwned = new List<Event>();
				List<Credential> credentialsOwned = new List<Credential>();

				// get Users to be account owner
				User accountOwner1 = new User();
				accountOwner1 = dbconn.Users.Find("1304693");

				Account acc1 = new Account
				{
					AccountType = AccountType.Mobile,
					Department = "College of Science and Engineering",
					IsActive = true,
					IsCredentialAuthority = false,
					IsAttendanceManager = false,
					IsInformationCollector = false,
					Owner = accountOwner1,
					EventsOwned = eventsOwned,
					CredentialsOwned = credentialsOwned
				};

				dbconn.Accounts.Add(acc1);
				dbconn.SaveChanges();
			}
		}

		protected void CredentialsCRUD()
		{
			using (var dbconn = new WebSystemData())
			{

				// get Users to be credential owner or issuer
				Account credentialIssuer = new Account();
				credentialIssuer = dbconn.Accounts.Find(3);

				Account credentialOwner = new Account();
				credentialOwner = dbconn.Accounts.Find(5);

				Credential cred = new Credential
				{
					Name = "Naomi's Gmail",
					CredentialType = CredentialType.Email,
					Issuer = credentialIssuer,
					Owner = credentialOwner,
					IssueDate = Convert.ToDateTime("01/15/2016"),
					ExpirationDate = Convert.ToDateTime("12/21/2019"),
					Value = "naomiwiggins08@gmail.com",
					IsValid = true
				};

				dbconn.Credentials.Add(cred);
				dbconn.SaveChanges();
			}
		}


	}
}