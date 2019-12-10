using System;

namespace QRCodeAuth_Web.Models
{
	public class MobileAccount
	{
		public MobileAccount()
		{
		}
		public string MobileId { get; set; }
		public string Department { get; set; }
		public bool IsActive { get; set; }
	}
}