/*
 * Purpose: 
 * This is a model class for a User object
 * 
 * Contributions: 
 * Naomi Wiggins 
 * 
 */

namespace QRCodeAuth_Web.Models
{
	public class User
	{
		public User()
		{
		}

		// Primary Key
		public string UserId { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public UserType UserType { get; set; }
	}
}