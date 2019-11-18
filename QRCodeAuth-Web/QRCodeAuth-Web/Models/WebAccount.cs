using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRCodeAuth_Web.Models
{
	public class WebAccount
	{
		public WebAccount()
		{
			this.EventsOwned = new List<Event>();
		}
		public string AccountId { get; set; }
		public string Department { get; set; }
		public bool IsActive { get; set; }
		public bool IsCredentialAuthority { get; set; }
		public bool IsAttendanceManager { get; set; }
		public bool IsInformationCollector { get; set; }

		// Navigation Properties
		public virtual User Owner { get; set; }
		public virtual List<Event> EventsOwned { get; set; }
	}
}