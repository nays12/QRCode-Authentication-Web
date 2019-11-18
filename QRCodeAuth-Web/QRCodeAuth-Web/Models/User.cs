using System.Collections.Generic;

namespace QRCodeAuth_Web.Models
{
	public class User
	{
		public User()
		{
			this.AccountsOwned = new List<Account>();
		}

		// Primary Key
		public string UserId { get; set; }

		public string LastName { get; set; }
		public string FirstName { get; set; }
		public UserType UserType { get; set; }

		// Navigation properties
		public virtual List<Account> AccountsOwned { get; set; }
	}
}