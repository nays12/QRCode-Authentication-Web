/*
 * Purpose: 
 * This is a Data Repository Class that is responsible for handling all the database operations invloving the
 * MobileAccounts Table in the Azure SQL Database
 * 
 * Contributions: 
 * Naomi Wiggins 
 * 
 */

using QRCodeAuth_Web.Models;
using System;

namespace QRCodeAuth_Web.Data
{
	public class MobileAccountsRepo
	{
		public static string StatusMessage { get; set; }
		public static void AddAccount(MobileAccount m)
		{
			try
			{
				using (var dbconn = new WebSystemData())
				{
					dbconn.MobileAccounts.Add(m);
					dbconn.SaveChanges();
				}
				StatusMessage = string.Format("Success! Added new Mobile Account for User '{0}'.", m.MobileId);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failure. Could not add Mobile Account for User '{0}'. Error: {1}", m.MobileId, ex.Message);
				StatusMessage = ex.Message;
			}
		}
		public static MobileAccount FindAccountById(string id)
		{
			MobileAccount m = new MobileAccount();

			try
			{
				using (var dbconn = new WebSystemData())
				{
					m = dbconn.MobileAccounts.Find(id);
				}
				StatusMessage = string.Format("Success! Found Mobild Account belonging to User {0}.", m.MobileId);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
				return m;
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failure. Could not find Mobile Account for User {0}. Error: {1}", m.MobileId, ex.Message);
				return null;
			}
		}
	}
}