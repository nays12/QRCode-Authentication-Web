﻿using System.Collections.Generic;

namespace QRCodeAuth_Web.Models
{
	public class User
	{
		public string UserId { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public UserType UserType { get; set; }
		public List<Account> Accounts { get; set; }

		public User()
		{

		}

		public User(string userid, string lastName, string firstName, UserType userType, List<Account> accounts)
		{
			UserId = userid;
			LastName = lastName;
			FirstName = firstName;
			UserType = userType;
			Accounts = accounts;
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}