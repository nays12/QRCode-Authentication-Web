using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QRCodeAuth_Web.Models
{
	public class Account
	{
		[Key]
		public string ID { get; set; }
		public User Owner { get; set; }
		public string Type { get; set; }
		public string DepartmentID { get; set; }
		public string DepartmentName { get; set; }
		public bool IsActive { get; set; }
		public bool IsCredentialAuthority { get; set; }
		public bool IsAttendanceManager { get; set; }
		public bool IsInformationCollector { get; set; }
		public List<Event> events { get; set; }

	}
}