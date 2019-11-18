using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRCodeAuth_Web.Models
{
	public class Event
	{
		public Event()
		{
			this.Attendees = new List<Account>();
			this.CredentialsRequired = new List<CredentialType>();
		}

		// Primary Key
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public EventType EventType { get; set; }
		public string Description { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		// Foreign Key
		public string Owner_Id { get; set; }
		public CredentialType Owner_Type { get; set; }

		// Navigation properties
		public virtual Account EventOwner { get; set; }
		public virtual List<Account> Attendees { get; set; }
		public virtual List<CredentialType> CredentialsRequired { get; set; }
	}
}