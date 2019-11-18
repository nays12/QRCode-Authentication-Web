using QRCodeAuth_Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace QRCodeAuth_Web.Data
{
	public class CredentialRepo
	{ 
		public static string StatusMessage { get; set; }

		public static void AddCredential(Credential cred)
		{
			using (var dbconn = new WebSystemData())
			{
				dbconn.Credentials.Add(cred);
				dbconn.SaveChanges();
			}
			StatusMessage = string.Format("Success! Added credential {0}.", cred.Name);
			System.Diagnostics.Debug.WriteLine(StatusMessage);

		}
	}
}