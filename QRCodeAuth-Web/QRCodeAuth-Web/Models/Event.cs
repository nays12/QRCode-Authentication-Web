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
		public int EventId { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public EventType EventType { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string Description { get; set; }
		public List<CredentialType> CredentialsRequired { get; set; }

		// Foreign Keys
		public virtual WebAccount Owner { get; set; }
		public virtual List<MobileAccount> Attendees { get; set; }
	}
}