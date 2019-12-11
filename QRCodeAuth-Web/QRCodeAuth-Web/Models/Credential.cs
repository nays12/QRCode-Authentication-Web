/*
 * Purpose: 
 * This is a model class for a Credential object
 * 
 * Contributions: 
 * Naomi Wiggins 
 * 
 */

using System;

namespace QRCodeAuth_Web.Models
{
	public class Credential
	{
		public Credential()
		{
		}

		// Primary Key
		public int CredentialId { get; set; }
		public string Name { get; set; }
		public CredentialType CredentialType { get; set; }
		public DateTime IssueDate { get; set; }
		public DateTime ExpirationDate { get; set; }
		public string Value { get; set; }
		public bool IsValid { get; set; }

		// Foreign Keys
		public string Owner { get; set; }
		public string Issuer { get; set; }
	}
}