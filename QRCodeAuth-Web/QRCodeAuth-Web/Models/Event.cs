﻿using System;
using System.Collections.Generic;

namespace QRCodeAuth_Web.Models
{
	public class Event
	{
		public Event()
		{
		}

		// Primary Key
		public int EventId { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public EventType EventType { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string Description { get; set; }
		public List<CredentialType> CredentialsNeeded { get; set; }

		// Foreign Keys
		public string Owner { get; set; }
	}
}