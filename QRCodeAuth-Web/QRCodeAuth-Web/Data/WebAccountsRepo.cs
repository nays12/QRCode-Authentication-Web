using QRCodeAuth_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRCodeAuth_Web.Data
{
	public class WebAccountsRepo
	{
		public static string StatusMessage { get; set; }
		public static void AddAccount(WebAccount w)
		{
			try
			{
				using (var dbconn = new WebSystemData())
				{
					dbconn.WebAccounts.Add(w);
					dbconn.SaveChanges();
				}
				StatusMessage = string.Format("Success! Added new Mobile Account for User {0}.", w.WebId);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failure. Could not add Mobile Account for User {0}. Error: {1}", w.WebId, ex.Message);
				StatusMessage = ex.Message;
			}
		}
		public static WebAccount FindAccountById(string id)
		{
			WebAccount w = new WebAccount();

			try
			{
				using (var dbconn = new WebSystemData())
				{
					w = dbconn.WebAccounts.Find(id);
				}
				StatusMessage = string.Format("Success! Found Mobile Account belonging to User {0}.", w.WebId);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
				return w;
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failure. Could not find Mobile Account for User {0}. Error: {1}", w.WebId, ex.Message);
				return null;
			}
		}
	}
}