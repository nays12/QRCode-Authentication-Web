/******************************************************************************\
 * Contributing Programmers: Naomi, {add name here if you work on this class}
 *
 * Purpose:
 * 
 * Preconditions/Assumptions:
 * 
 * Notes:
 *
 * Algorithm:
 * 
 * 
 \*******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRCodeAuth_Web.Models
{
	public class User
	{
		private string userId { get; set; }
		private string firstName { get; set; }
		private string lastName { get; set; }
		private UserType userGroup { get; set; }

		public User()
		{
		}

		public User(string userId, string firstName, string lastName, UserType userGroup)
		{
			this.userId = userId;
			this.firstName = firstName;
			this.lastName = lastName;
			this.userGroup = userGroup;
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}