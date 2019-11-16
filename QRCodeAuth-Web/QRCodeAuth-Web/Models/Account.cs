
using System.Collections.Generic;

namespace QRCodeAuth_Web.Models
{
	public class Account
	{
		public int Id { get; set; }
		public AccountType AccountType { get; set; }
		public string Department { get; set; }
		public bool IsActive { get; set; }
		public bool IsCredentialAuthority { get; set; }
		public bool IsAttendanceManager { get; set; }
		public bool IsInformationCollector { get; set; }
		public User Owner { get; set; }
		public List<Credential> CredentialsOwned { get; set; }
		public List<Event> EventsOwned { get; set; }
		
		public Account()
		{

		}

		public Account(int id, AccountType type, string department, bool isActive, bool isCredentialAuthority, bool isAttendanceManager, bool isInformationCollector, User owner, List<Credential> credentialsOwned, List<Event> eventsOwned)
		{
			Id = id;
			AccountType = type;
			Department = department;
			IsActive = isActive;
			IsCredentialAuthority = isCredentialAuthority;
			IsAttendanceManager = isAttendanceManager;
			IsInformationCollector = isInformationCollector;
			Owner = owner;
			CredentialsOwned = credentialsOwned;
			EventsOwned = eventsOwned;
			
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}