using QRCodeAuth_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRCodeAuth_Web.Data
{
	public class AccountsRepo
	{
		public static string StatusMessage { get; set; }

		public static Account FindAccountByPK(string id, AccountType type)
		{
			Account acc = new Account();
			using (var dbconn = new WebSystemData())
			{
				acc = dbconn.Accounts.Find(id, type);
			}
			StatusMessage = string.Format("Success! Found Account {0}.", acc.AccountId);
			System.Diagnostics.Debug.WriteLine(StatusMessage);
			return acc;
		}
	}
}