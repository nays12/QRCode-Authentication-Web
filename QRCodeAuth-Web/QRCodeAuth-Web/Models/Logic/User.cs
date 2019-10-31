using System;
using System.Collections.Generic;
using System.Web;

namespace QRCodeAuth_Web.Models.Logic
{
	public class User
	{
		public string ID { get; set; }
		public string SchoolID { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public UserType Group { get; set; }
		public virtual List<Account> Accounts { get; set; }

		public User()
		{

		}
		public User(string iD, string schoolID, string lastName, string firstName, UserType group, List<Account> accounts)
		{
			ID = iD;
			SchoolID = schoolID;
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