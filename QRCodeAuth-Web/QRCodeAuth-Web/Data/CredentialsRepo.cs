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
		private static WebSystemData db = new WebSystemData();

		public static void AddCredential(Credential cred)
		{
			try
			{
				db.Credentials.Add(cred);
				db.SaveChanges();
				
				StatusMessage = string.Format("Success! Added Credential '{0}' to Mobile Account belonging to {1}.", cred.Name, cred.Owner);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failure. Could not add Credential '{0}' to Mobile Account belonging to  {1}. Error: {2}", cred.Name, cred.Owner, ex.Message);
				StatusMessage = ex.Message;
			}
		}

		public static List<Credential> GetOwnerCredentials(string ownerId)
		{
			List<Credential> credentials = new List<Credential>();

				var query = db.Credentials
				.Where(c => c.Owner == ownerId)
				.Select(c => new
				{ 
					Name = c.Name,
					CredentialType = c.CredentialType,
					IssueDate = c.IssueDate,
					ExpirationDate = c.ExpirationDate,
					Value = c.Value,
					IsValid = c.IsValid,
					Owner = c.Owner,
					Issuer = c.Issuer

				});

				foreach (var c in query)
				{
					Credential cred = new Credential
					{
						Name = c.Name,
						CredentialType = c.CredentialType,
						IssueDate = c.IssueDate,
						ExpirationDate = c.ExpirationDate,
						Value = c.Value,
						IsValid = c.IsValid,
						Owner = c.Owner,
						Issuer = c.Issuer
					};

					credentials.Add(cred);
				}

			return credentials;
		}


	}
}