using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRCodeAuth_Web.Models;

namespace QRCodeAuth_Web.Data
{
	public class EventsRepo
	{
		public static string StatusMessage { get; set; }

		public static void AddEvent(Event ev)
		{
			//try
			//{
				using (var dbconn = new WebSystemData())
				{
					dbconn.Events.Add(ev);
					dbconn.SaveChanges();
				}
				StatusMessage = string.Format("Success! Added new Event '{0}'.", ev.Name);
			//}
			//catch (Exception ex)
			//{
			//	StatusMessage = string.Format("Failure. Could not add Event {0}. Error: {1}", ev.Name, ex.Message);
			//	StatusMessage = ex.Message;
			//}
		}
	}
}