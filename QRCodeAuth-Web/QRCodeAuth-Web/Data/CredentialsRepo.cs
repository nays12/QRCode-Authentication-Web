﻿using System;
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

		public static Credential AddCredential(Credential cred)
		{
			try
			{
				db.Credentials.Add(cred);
				db.SaveChanges();
				
				StatusMessage = string.Format("Success! Added Credential '{0}' to Mobile Account belonging to {1}.", cred.Name, cred.Owner);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
				return cred;
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failure. Could not add Credential '{0}' to Mobile Account belonging to  {1}. Error: {2}", cred.Name, cred.Owner, ex.Message);
				return null;
			}
		}

		public static void DeleteCredentialById(int id)
		{
			Credential cred = new Credential();
			try
			{			
				cred = db.Credentials.Find(id);
				db.Credentials.Remove(cred);
				db.SaveChanges();

				StatusMessage = string.Format("Success! Deleted Credential '{0}' in Mobile Account belonging to {1}.", cred.Name, cred.Owner);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failure. Could not find Credential '{0}' to Mobile Account belonging to {1} for deletion. Error: {2}", cred.Name, cred.Owner, ex.Message);
			}
		}

		public static void UpdateCredential(int id, Credential newCredential)
		{
			Credential oldCredential = new Credential();
			try
			{
				oldCredential = db.Credentials.Find(id); // find the credential

				// Update old credential with new credential values
				oldCredential.CredentialId = newCredential.CredentialId;
				oldCredential.Name = newCredential.Name;
				oldCredential.CredentialType = newCredential.CredentialType;
				oldCredential.IssueDate = newCredential.IssueDate;
				oldCredential.ExpirationDate = newCredential.ExpirationDate;
				oldCredential.Value = newCredential.Value;
				oldCredential.IsValid = newCredential.IsValid;
				oldCredential.Owner = newCredential.Owner;
				oldCredential.Issuer = newCredential.Issuer;

				db.SaveChanges(); // save the changes

				StatusMessage = string.Format("Success! Credential '{0}' in Mobile Account belonging to {1} was updated.", oldCredential.Name, oldCredential.Owner);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failure. Could not update Credential '{0}' to Mobile Account belonging to {1}. Error: {2}", oldCredential.Name, oldCredential.Owner, ex.Message);
			}
		}

		public static List<Credential> GetOwnerCredentials(string ownerId)
		{
			List<Credential> credentials = new List<Credential>();

				var query = db.Credentials
				.Where(c => c.Owner == ownerId)
				.Select(c => new
				{ 
					CredentialId = c.CredentialId,
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
						CredentialId = c.CredentialId,
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