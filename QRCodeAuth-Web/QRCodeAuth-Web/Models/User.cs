using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace QRCodeAuth_Web.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		public string SchoolIdNumber { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public UserType Group { get; set; }
		public virtual List<Account> Accounts { get; set; }

		public User()
		{

		}
		public User(string schoolID, string lastName, string firstName, UserType group, List<Account> accounts)
		{
			SchoolIdNumber = schoolID;
			LastName = lastName;
			FirstName = firstName;
			Group = group;
			Accounts = accounts;
		}
		public override string ToString()
		{
			return base.ToString();
		}
	}


}