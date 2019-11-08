using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;
using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models;


namespace QRCodeAuth_Web
{
	public partial class db_EF_test : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//using (var dbconn = new WebSystemData())
			//{
			//	// insert
			//	//User info = new User
			//	//{
			//	//    UserId = "7865293",
			//	//    FirstName = "MARRY",
			//	//    LastName = "KIM",
			//	//    group = "CS"
			//	//};
			//	//dbconn.Users.Add(info);
			//	//dbconn.SaveChanges();

			//	//selected
			//	//Users info = context.System_user.FirstOrDefault(i => i.UserId == "1195191");
			//	//Response.Write("the selected is: " + info.UserId + " ; " + info.FirstName + " " + info.LastName);

			//	//update
			//	//User info = dbconn.Users.FirstOrDefault(i => i.UserId == "1195191");
			//	//info.FirstName = "zhimin";
			//	//dbconn.SaveChanges();

			//	//remove
			//	//Users info = dbconn.Users.FirstOrDefault(i => i.UserId == "1453678");
			//	//dbconn.Users.Remove(info);

			//	//dbconn.SaveChanges();
			//}

			// Create events to test EventsController
			//using (var dbconn = new WebSystemData())
			//{
			//	// create list of credentials
			//	List<CredentialType> credentials = new List<CredentialType>();
			//	credentials.Add(CredentialType.Email);
			//	credentials.Add(CredentialType.Major);

			//	// create list of attendees
			//	List<Account> eventAttendees = new List<Account>();

			//	Event e1 = new Event
			//	{
			//		Name = "Delta Waffle Day",
			//		Location = "Delta Building Lobby",
			//		Type = EventType.Campus,
			//		Description = "Free Waffles at the Delta building!",
			//		StartTime = Convert.ToDateTime("10/30/2019 02:30pm"),
			//		EndTime = Convert.ToDateTime("10/30/2019 06:30pm"),
			//		Owner = null,
			//		CredentialsRequired = credentials,
			//		Attendees = eventAttendees
			//	};

			//	Event e2 = new Event
			//	{
			//		Name = "Trick or Treat at the Rec",
			//		Location = "Recreation and Wellness Center",
			//		Type = EventType.Campus,
			//		Description = "reat yourself to spooky treats, fun activities and more at UHCL's first Trick or Treat at The Rec!",
			//		StartTime = Convert.ToDateTime("10/31/2019 04:00pm"),
			//		EndTime = Convert.ToDateTime("10/31/2019 09:00pm"),
			//		Owner = null,
			//		CredentialsRequired = credentials,
			//		Attendees = eventAttendees
			//	};

			//	dbconn.Events.Add(e1);
			//	dbconn.Events.Add(e2);
			//	dbconn.SaveChanges();
			//}

			//// How to add a new user object
			//using (var dbconn = new WebSystemData())
			//{

			//	User u1 = new User
			//	{
			//		UserId = "0984302",
			//		LastName = "Smith",
			//		FirstName = "John",
			//		Group = UserType.Student
			//	};

			//	dbconn.Users.Add(u1);
			//	dbconn.SaveChanges();
			//}
		}
	}
}