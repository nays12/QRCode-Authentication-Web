using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QRCodeAuth_Web.Models.Domain
{
	public class Event
	{
		[Key]
		public string ID { get; set; }
		public Account Owner { get; set; }
		public string Name { get; set; }
		public EventType Type { get; set; }
		public string Description { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string CredentialsRequired { get; set; }
		public List<Account> Attendees { get; set; }
	}
}