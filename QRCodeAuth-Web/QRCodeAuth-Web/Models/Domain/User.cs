using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QRCodeAuth_Web.Models
{
	public class User
	{
		[Key]
		public string ID { get; set; }
		public string SchoolID { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public UserType Group { get; set; }
		public List<Account> Accounts { get; set; }

		public User()
		{

		}


	}


}