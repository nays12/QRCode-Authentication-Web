
using System.Collections.Generic;

namespace QRCodeAuth_Web.Models
{
	public class Account
	{
		public int Id { get; set; }
		public AccountType AccountType { get; set; }
		public string DepartmentName { get; set; }
		public bool IsActive { get; set; }
		public bool IsCredentialAuthority { get; set; }
		public bool IsAttendanceManager { get; set; }
		public bool IsInformationCollector { get; set; }
		public User Owner { get; set; }
		public List<Event> EventsOwned { get; set; }

		public Account()
		{

		}

		public Account(int id, AccountType type, string departmentName, bool isActive, bool isCredentialAuthority, bool isAttendanceManager, bool isInformationCollector, User owner, List<Event> eventsOwned)
		{
			Id = id;
			AccountType = type;
			DepartmentName = departmentName;
			IsActive = isActive;
			IsCredentialAuthority = isCredentialAuthority;
			IsAttendanceManager = isAttendanceManager;
			IsInformationCollector = isInformationCollector;
			Owner = owner;
			EventsOwned = eventsOwned;
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}