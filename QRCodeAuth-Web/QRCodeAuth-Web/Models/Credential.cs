
using System;

namespace QRCodeAuth_Web.Models
{
	public class Credential
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public CredentialType CredentialType { get; set; }
		public Account Issuer { get; set; }
		public Account Owner { get; set; }
		public DateTime IssueDate { get; set; }
		public DateTime ExpirationDate { get; set; }
		public string Value { get; set; }
		public bool IsValid { get; set; }

		public Credential()
		{
		}

		public Credential(int id, string name, CredentialType credentialType, Account issuer, Account owner, DateTime issueDate, DateTime expirationDate, string value, bool isValid)
		{
			Id = id;
			Name = name;
			CredentialType = credentialType;
			Issuer = issuer;
			Owner = owner;
			IssueDate = issueDate;
			ExpirationDate = expirationDate;
			Value = value;
			IsValid = isValid;
		}
		public override string ToString()
		{
			return base.ToString();
		}
	}

}