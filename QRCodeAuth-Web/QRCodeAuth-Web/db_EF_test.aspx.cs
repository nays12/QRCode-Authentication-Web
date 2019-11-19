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
			//UsersCRUD();
			//MobileAccountsCRUD();
			//WebAccountsCRUD()
			//EventsCRUD();
			//CredentialsCRUD();
		}

		//protected void UsersCRUD()
		//{
		//	Creates a User object and inserts it into the database
		//   User u1 = new User
		//   {
		//	   UserId = "8764710",
		//	   LastName = "Li",
		//	   FirstName = "Timothy",
		//	   UserType = UserType.Student
		//   };

		//	UsersRepo.AddNewUser(u1);
		//	System.Diagnostics.Debug.WriteLine(UsersRepo.StatusMessage);

		//	// Finds a user by their ID
		//	info = dbconn.Users.Find("1195191");
		//	Response.Write("the selected is: " + info.UserId + " ; " + info.FirstName + " " + info.LastName);

		//	// Finds a user by thier ID and then updates their first name
		//	info = dbconn.Users.Find("1195191");
		//	info.FirstName = "zhimin";
		//	dbconn.SaveChanges();

		//	// Finds a user by thier ID and then deletes them from the database
		//	info = dbconn.Users.Find("1453678");
		//	dbconn.Users.Remove(info);

		//	dbconn.SaveChanges(); // updates the changes in the database

		//}

		//protected void MobileAccountsCRUD()
		//{
		//	// create list of events
		//	List<Event> eventsOwned = new List<Event>();
		//	List<Credential> credentialsOwned = new List<Credential>();

		//	// get Users to be account owner
		//	User accountOwner1 = UsersRepo.FindUserById("1646825");

		//	Account acc1 = new Account
		//	{
		//		AccountId = "1646825",
		//		AccountType = AccountType.Web,
		//		Department = "College of Science and Engineering",
		//		IsActive = true,
		//		IsCredentialAuthority = false,
		//		IsAttendanceManager = true,
		//		IsInformationCollector = false,
		//		Owner = accountOwner1,
		//		EventsOwned = eventsOwned,
		//		CredentialsOwned = credentialsOwned
		//	};
		//	AccountsRepo.AddAccount(acc1);
		//	System.Diagnostics.Debug.WriteLine(AccountsRepo.StatusMessage);

		//	//// get Users to be account owner
		//	//User accountOwner2 = UsersRepo.FindUserById("2496678");

		//	//Account acc2 = new Account
		//	//{
		//	//	AccountType = AccountType.Mobile,
		//	//	Department = "Delta 205 Lab",
		//	//	IsActive = true,
		//	//	IsCredentialAuthority = false,
		//	//	IsAttendanceManager = false,
		//	//	IsInformationCollector = true,
		//	//	Owner = accountOwner2,
		//	//	EventsOwned = eventsOwned,
		//	//	CredentialsOwned = credentialsOwned
		//	//};

		//	//AccountsRepo.AddAccount(acc2);
		//	//System.Diagnostics.Debug.WriteLine(AccountsRepo.StatusMessage);

		//	//// get Users to be account owner
		//	//User accountOwner3 = UsersRepo.FindUserById("2496678");

		//	//Account acc3 = new Account
		//	//{
		//	//	AccountType = AccountType.Mobile,
		//	//	Department = "College of Science and Engineering",
		//	//	IsActive = true,
		//	//	IsCredentialAuthority = false,
		//	//	IsAttendanceManager = false,
		//	//	IsInformationCollector = false,
		//	//	Owner = accountOwner3,
		//	//	EventsOwned = eventsOwned,
		//	//	CredentialsOwned = credentialsOwned
		//	//};

		//	//AccountsRepo.AddAccount(acc3);
		//	//System.Diagnostics.Debug.WriteLine(AccountsRepo.StatusMessage);

		//}

		//protected void EventsCRUD()
		//{
		//	// create list of credentials
		//	List<CredentialType> credentials1 = new List<CredentialType>();
		//	credentials1.Add(CredentialType.Name);

		//	List<CredentialType> credentials2 = new List<CredentialType>();
		//	credentials2.Add(CredentialType.Name);
		//	credentials2.Add(CredentialType.IdNumber);

		//	List<CredentialType> credentials3 = new List<CredentialType>();
		//	credentials3.Add(CredentialType.Name);
		//	credentials3.Add(CredentialType.IdNumber);

		//	// get Accounts to be Event owner
		//	Account eventOwner1 = AccountsRepo.FindAccountByPK("8764710", AccountType.Web);
		//	Account eventOwner2 = AccountsRepo.FindAccountByPK("4582055", AccountType.Web);
		//	Account eventOwner3 = AccountsRepo.FindAccountByPK("0646825", AccountType.Web);

		//	// create list of attendees
		//	List<Account> eventAttendees1 = new List<Account>();
		//	eventAttendees1.Add(AccountsRepo.FindAccountByPK("1304693", AccountType.Mobile));
		//	eventAttendees1.Add(AccountsRepo.FindAccountByPK("2496678", AccountType.Mobile));
		//	eventAttendees1.Add(AccountsRepo.FindAccountByPK("6247868", AccountType.Mobile));

		//	List<Account> eventAttendees2 = new List<Account>();
		//	List<Account> eventAttendees3 = new List<Account>();

		//	// Create event object
		//	Event e1 = new Event
		//	{
		//		Name = "Delta Waffle Day",
		//		Location = "Delta Building Lobby",
		//		EventType = EventType.Campus,
		//		Description = "Free Waffles at the Delta building!",
		//		StartTime = Convert.ToDateTime("10/30/2019 02:30pm"),
		//		EndTime = Convert.ToDateTime("10/30/2019 06:30pm"),
		//		Owner = eventOwner1,
		//		CredentialsRequired = credentials1,
		//		Attendees = eventAttendees1
		//	};

		//	Event e2 = new Event
		//	{
		//		Name = "Study PAWS",
		//		Location = "Neumann Library Main Floor",
		//		EventType = EventType.Campus,
		//		Description = "Pet Away Worry and Stress (PAWS) during your studies for mid-terms at this Neumann Library fall event.",
		//		StartTime = Convert.ToDateTime("11/20/2019 03:00pm"),
		//		EndTime = Convert.ToDateTime("11/20/2019 04:30pm"),
		//		Owner = eventOwner2,
		//		CredentialsRequired = credentials2,
		//		Attendees = eventAttendees2
		//	};

		//	Event e3 = new Event
		//	{
		//		Name = "Senior Projects Seminar Lecture",
		//		Location = "Delta 242",
		//		EventType = EventType.Lecture,
		//		Description = "Your Test Plans are due along with your presentations, Thank you.",
		//		StartTime = Convert.ToDateTime("11/20/2019 07:00pm"),
		//		EndTime = Convert.ToDateTime("11/20/2019 09:50pm"),
		//		Owner = eventOwner3,
		//		CredentialsRequired = credentials3,
		//		Attendees = eventAttendees3
		//	};

		//	EventsRepo.AddEvent(e1);
		//	EventsRepo.AddEvent(e2);
		//	EventsRepo.AddEvent(e3);
		//}

		//protected void CredentialsCRUD()
		//{
		//	// get Accounts to be credential owner or issuer
		//	Account credentialIssuer = new Account();
		//	credentialIssuer = AccountsRepo.FindAccountByPK("dd", AccountType.Web);

		//	Account credentialOwner = new Account();
		//	credentialOwner = AccountsRepo.FindAccountByPK("dd", AccountType.Mobile);

		//	Credential cred = new Credential
		//	{
		//		Name = "Naomi's Gmail",
		//		CredentialType = CredentialType.Email,
		//		Issuer = credentialIssuer,
		//		Owner = credentialOwner,
		//		IssueDate = Convert.ToDateTime("01/15/2016"),
		//		ExpirationDate = Convert.ToDateTime("12/21/2019"),
		//		Value = "naomiwiggins08@gmail.com",
		//		IsValid = true
		//	};

		//	CredentialsRepo.AddCredential(cred);

		//}

	}
}