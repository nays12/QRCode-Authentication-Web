
using System;

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
		//public string Issuer_Id { get; set; }
		//public CredentialType Issuer_Type { get; set; }
		//public string Owner_Id { get; set; }
		//public CredentialType Owner_Type { get; set; }

		// Navigation Properties
		public virtual WebAccount Issuer { get; set; }
		public virtual MobileAccount Owner { get; set; }
	}
}