using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRCodeAuth_Web.Models;

namespace QRCodeAuth_Web.Data
{
	public class CredentialsRepo
	{
		public static string StatusMessage { get; set; }

		//public static void AddCredential(Credential cred)
		//{
		//	try
		//	{
		//		using (var dbconn = new WebSystemData())
		//		{
		//			dbconn.Credentials.Add(cred);
		//			dbconn.SaveChanges();
		//		}
		//		StatusMessage = string.Format("Success! Added Credential {0} to Mobile Account belonging to {1}.", cred.Name, cred.Owner_Id);
		//		System.Diagnostics.Debug.WriteLine(StatusMessage);
		//	}
		//	catch (Exception ex)
		//	{
		//		StatusMessage = string.Format("Failure. Could not add Credential {0} to Mobile Account belonging to  {1}. Error: {2}", cred.Name, cred.Owner_Id, ex.Message);
		//		StatusMessage = ex.Message;
		//	}
		//}


	}
}