/*
 * Purpose: 
 * This is a model class for a WebAccount object
 * 
 * Contributions: 
 * Naomi Wiggins 
 * 
 */

namespace QRCodeAuth_Web.Models
{
	public class WebAccount
	{
		public WebAccount()
		{
		}

		// Primary Key
		public string WebId { get; set; }
		public string Department { get; set; }
		public bool IsActive { get; set; }
		public bool IsCredentialAuthority { get; set; }
		public bool IsAttendanceManager { get; set; }
		public bool IsInformationCollector { get; set; }
	}
}