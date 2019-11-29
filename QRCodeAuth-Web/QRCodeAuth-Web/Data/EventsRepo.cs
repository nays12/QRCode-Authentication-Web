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
		private static WebSystemData db = new WebSystemData();

		public static Event AddEvent(Event ev)
		{
			try
			{
				db.Events.Add(ev);
				db.SaveChanges();

				StatusMessage = string.Format("Success! Added new Event '{0}'.", ev.Name);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
				return ev;
			}	
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failure. Could not add Event {0}. Error: {1}", ev.Name, ex.Message);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
				return null;
			} 
		}



	}
}