
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRCodeAuth_Web.Models
{
	public class Credential
	{
		public Credential()
		{

		}

		// Primary Key
		public int Id { get; set; }

		public string Name { get; set; }
		public CredentialType CredentialType { get; set; }
		public DateTime IssueDate { get; set; }
		public DateTime ExpirationDate { get; set; }
		public string Value { get; set; }
		public bool IsValid { get; set; }

		// Foreign Keys
		public string CredentialIssuer_Id { get; set; }
		public CredentialType CredentialIssuer_Type { get; set; }
		public string CredentialOwner_Id { get; set; }
		public CredentialType CredentialOwner_Type { get; set; }

		// Navigation Properties
		public virtual Account CredentialIssuer { get; set; }
	
		public virtual Account CredentialOwner { get; set; }
	}
}