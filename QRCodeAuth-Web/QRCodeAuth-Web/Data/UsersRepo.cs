using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using QRCodeAuth_Web.Models;

namespace QRCodeAuth_Web.Data
{
	public class UsersRepo
	{
		public static string StatusMessage { get; set; }

		public static void AddNewUser(User u)
		{
			try
			{
				using (var dbconn = new WebSystemData())
				{
					dbconn.Users.Add(u);
					dbconn.SaveChanges();
				}
				StatusMessage = string.Format("Success! Added new User {0} {1} with Id {2}.", u.FirstName, u.LastName, u.UserId);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed. Could add User {0} {1} with Id {2}. Error: {3}", u.FirstName, u.LastName, u.UserId, ex.Message);			
			}
		}

		public static User FindUserById(string id)
		{
			User u = new User();

			try
			{
				using (var dbconn = new WebSystemData())
				{
					u = dbconn.Users.Find(id);
				}
				StatusMessage = string.Format("Success! Found User {0} {1} with Id Number: {2}.", u.FirstName, u.LastName, u.UserId);
				return u;
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed. Could not find User {0} {1} with Id Number: {2}. Error: {3}", u.FirstName, u.LastName, u.UserId, ex.Message);
				return null;
			}
		}
	}
}