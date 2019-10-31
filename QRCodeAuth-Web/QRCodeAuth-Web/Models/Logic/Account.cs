using System;
using System.Collections.Generic;
using System.Web;

namespace QRCodeAuth_Web.Models.Logic
{
	public class Account
	{
		public string ID { get; set; }
		public virtual User Owner { get; set; }
		public string Type { get; set; }
		public string DepartmentID { get; set; }
		public string DepartmentName { get; set; }
		public bool IsActive { get; set; }
		public bool IsCredentialAuthority { get; set; }
		public bool IsAttendanceManager { get; set; }
		public bool IsInformationCollector { get; set; }
		public virtual List<Event> events { get; set; }

		public Account(string iD, User owner, string type, string departmentID, string departmentName, bool isActive, bool isCredentialAuthority, bool isAttendanceManager, bool isInformationCollector, List<Event> events)
		{
			ID = iD;
			Owner = owner;
			Type = type;
			DepartmentID = departmentID;
			DepartmentName = departmentName;
			IsActive = isActive;
			IsCredentialAuthority = isCredentialAuthority;
			IsAttendanceManager = isAttendanceManager;
			IsInformationCollector = isInformationCollector;
			this.events = events;
		}
		public override string ToString()
		{
			return base.ToString();
		}
	}
}