﻿using System;
using System.Collections.Generic;
using System.Web;

namespace QRCodeAuth_Web.Models.Logic
{
	public class Event
	{
		public string Id { get; set; }
		public virtual Account Owner { get; set; }
		public string Name { get; set; }
		public EventType Type { get; set; }
		public string Description { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public List<CredentialType> CredentialsRequired { get; set; }
		public virtual List<Account> Attendees { get; set; }

		public Event(string iD, Account owner, string name, EventType type, string description, DateTime startTime, DateTime endTime, List<CredentialType> credentialsRequired, List<Account> attendees)
		{
			Id = iD;
			Owner = owner;
			Name = name;
			Type = type;
			Description = description;
			StartTime = startTime;
			EndTime = endTime;
			CredentialsRequired = credentialsRequired;
			Attendees = attendees;
		}
		public override string ToString()
		{
			return base.ToString();
		}
	}
}