using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRCodeAuth_Web.Models
{
	public class Credential
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Account Issuer { get; set; }
		public Account Owner { get; set; }
		public DateTime IssueDate { get; set; }
		public DateTime ExpirationDate { get; set; }
		public string Value { get; set; }
		public bool IsValid { get; set; }
	}

}