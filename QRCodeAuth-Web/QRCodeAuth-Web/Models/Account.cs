
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRCodeAuth_Web.Models
{
	public class Account
	{
		public Account()
		{
			this.CredentialsOwned = new List<Credential>();
			this.EventsOwned = new List<Event>();
		}

		// Composite Primary Key
		public string AccountId { get; set; }
		public AccountType AccountType { get; set; }

		public string Department { get; set; }
		public bool IsActive { get; set; }
		public bool IsCredentialAuthority { get; set; }
		public bool IsAttendanceManager { get; set; }
		public bool IsInformationCollector { get; set; }

		// Foreign Keys
		public string Owner_Id { get; set; }
		public AccountType Owner_Type { get; set; }

		// Navigation Properties
		public virtual User AccountOwner { get; set; }
		public virtual List<Credential> CredentialsOwned { get; set; }
		public virtual List<Event> EventsOwned { get; set; }
	}
}