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

		protected void EntityCRUDTest()
		{
			using (var dbconn = new WebSystemData())
			{
				// Creates a User object and inserts it into the database
				User info = new User
				{
					UserId = "7865293",
					FirstName = "MARRY",
					LastName = "KIM",
					Group = UserType.Student
				};
				dbconn.Users.Add(info);
				dbconn.SaveChanges();

				// Finds a user by their ID
				info = dbconn.Users.Find(info.UserId == "1195191");
				Response.Write("the selected is: " + info.UserId + " ; " + info.FirstName + " " + info.LastName);

				// Finds a user by thier ID and then updates their first name
				info = dbconn.Users.Find(info.UserId == "1195191");
				info.FirstName = "zhimin";
				dbconn.SaveChanges();

				// Finds a user by thier ID and then deletes them from the database
				info = dbconn.Users.Find(info.UserId == "1453678");
				dbconn.Users.Remove(info);

				dbconn.SaveChanges(); // updates the changes in the database
			}
		}

		protected void EventsControllerTest()
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
	}
}