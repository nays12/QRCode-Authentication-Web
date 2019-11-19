using System.Collections.Generic;

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