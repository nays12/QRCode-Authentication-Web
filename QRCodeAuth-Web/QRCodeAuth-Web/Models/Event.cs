using System;
using System.Collections.Generic;

namespace QRCodeAuth_Web.Models
{
	public class Event
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public EventType Type { get; set; }
		public string Description { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public Account Owner { get; set; }
		public List<CredentialType> CredentialsRequired { get; set; }
		public List<Account> Attendees { get; set; }

		public Event()
		{

		}

		public Event(int id, string name, string location, EventType type, string description, DateTime startTime, DateTime endTime, Account owner, List<CredentialType> credentialsRequired, List<Account> attendees)
		{
			Id = id;
			Name = name;
			Location = location;
			Type = type;
			Description = description;
			StartTime = startTime;
			EndTime = endTime;
			Owner = owner;
			CredentialsRequired = credentialsRequired;
			Attendees = attendees;
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}