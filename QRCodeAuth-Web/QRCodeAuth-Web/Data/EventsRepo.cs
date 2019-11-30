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

		public static Event GetEventById(int id)
		{
			try
			{
				Event ev = db.Events.Find(id);
				StatusMessage = string.Format("Success! Found Event '{0}'.", ev.Name);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
				return ev;
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failure. Could not find the Event. Error: {0}", ex.Message);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
				return null;
			}
		}

		public static List<Event> GetActiveEvents(string id)
		{
			List<Event> activeEvents = new List<Event>();
			try
			{
				var query = db.Events
					.Where(ev => ev.Owner == id)
					.Where(ev => ev.IsPassed == false)
					.Select(ev => new
					{
						EventId = ev.EventId,
						Name = ev.Name,
						Location = ev.Location,
						EventType = ev.EventType,
						StartTime = ev.StartTime,
						EndTime = ev.EndTime,
						Description = ev.Description,
						IsPassed = ev.IsPassed
					});

				foreach (var ev in query)
				{
					Event event1 = new Event
					{
						EventId = ev.EventId,
						Name = ev.Name,
						Location = ev.Location,
						EventType = ev.EventType,
						StartTime = ev.StartTime,
						EndTime = ev.EndTime,
						Description = ev.Description,
						IsPassed = ev.IsPassed
					};
					activeEvents.Add(event1);
					StatusMessage = string.Format("Success! Retrieved active Event '{0}'.", event1.Name);
					System.Diagnostics.Debug.WriteLine(StatusMessage);					
				}
				return activeEvents;
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failure. Could not retrieve active events. Error: {0}", ex.Message);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
				return null;
			}
		}




	



	}
}