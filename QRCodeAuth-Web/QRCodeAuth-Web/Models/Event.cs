/******************************************************************************\
 * Contributing Programmers: Naomi, {add name here if you work on this class}
 *
 * Purpose:
 * 
 * Preconditions/Assumptions:
 * 
 * Notes:
 *
 * Algorithm:
 * 
 * 
 \*******************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRCodeAuth_Web.Models
{
	public class Event
	{
		private User owner { get; set; }
		private string iD { get; set; }
		private string name { get; set; }
		private EventType type { get; set; }
		private string details { get; set; }
		private DateTime startTime { get; set; }
		private DateTime endTime { get; set; }
		private ArrayList credentialsNeeded { get; set; }

		public Event()
		{
		}

		public Event(User owner, string iD, string name, EventType type, string details, DateTime startTime, DateTime endTime, ArrayList credentialsNeeded)
		{
			this.owner = owner;
			this.iD = iD;
			this.name = name;
			this.type = type;
			this.details = details;
			this.startTime = startTime;
			this.endTime = endTime;
			this.credentialsNeeded = credentialsNeeded;
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}