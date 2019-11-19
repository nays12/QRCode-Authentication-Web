using System;

namespace QRCodeAuth_Web.Models
{
	public class WebAccount
	{
		public WebAccount()
		{

		}
		public string WebId { get; set; }
		public string Department { get; set; }
		public bool IsActive { get; set; }
		public bool IsCredentialAuthority { get; set; }
		public bool IsAttendanceManager { get; set; }
		public bool IsInformationCollector { get; set; }
	}
}