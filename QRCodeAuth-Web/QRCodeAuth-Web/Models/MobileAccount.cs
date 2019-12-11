/*
 * Purpose: 
 * This is a model class for a MobileAccount object
 * 
 * Contributors: 
 * Naomi Wiggins 
 * 
 */

namespace QRCodeAuth_Web.Models
{
	public class MobileAccount
	{
		public MobileAccount()
		{
		}

		// Primary Key
		public string MobileId { get; set; }
		public string Department { get; set; }
		public bool IsActive { get; set; }
	}
}