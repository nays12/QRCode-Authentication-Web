using System;
using System.Collections.Generic;

namespace QRCodeAuth_Web.Models
{
	public class Event
	{
		public Event()
		{
			this.Attendees = new List<MobileAccount>();
			this.CredentialsRequired = new List<CredentialType>();
		}

		// Primary Key
		public int Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public EventType EventType { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string Description { get; set; }

		// Foreign Key
		//public string Owner_Id { get; set; }
		//public CredentialType Owner_Type { get; set; }

		// Navigation properties
		public virtual WebAccount Owner { get; set; }
		public virtual List<MobileAccount> Attendees { get; set; }
		public virtual List<CredentialType> CredentialsRequired { get; set; }
	}
}