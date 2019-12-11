/*
 * Purpose: 
 * This is a Data Repository Class that is responsible for handling all the database operations invloving the
 * WebAccounts Table in the Azure SQL Database
 * 
 * Contributions: 
 * Naomi Wiggins 
 * 
 */

using QRCodeAuth_Web.Models;
using System;

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
				StatusMessage = string.Format("Success! Added new Web Account for User {0}.", w.WebId);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failure. Could not add Web Account for User {0}. Error: {1}", w.WebId, ex.Message);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
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
				StatusMessage = string.Format("Success! Found Web Account belonging to User {0}.", w.WebId);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
				return w;
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failure. Could not find Web Account for User {0}. Error: {1}", id, ex.Message);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
				return null;
			}
		}
	}
}