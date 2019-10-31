using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QRCodeAuth_Web.Models.Logic
{
	public class Account
	{
		[Key]
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

	}
}