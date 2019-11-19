
using System;
using System.Collections.Generic;

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
		public virtual MobileAccount Owner { get; set; }
		public int Owner_FK { get; set; }
		public virtual WebAccount Issuer { get; set; }
		public int Issuer_FK { get; set; }
	}
}