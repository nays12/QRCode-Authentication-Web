using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRCodeAuth_Web.Models
{
	public class MobileAccount
	{
		public MobileAccount()
		{
		}

		public string AccountId { get; set; }
		public string Department { get; set; }
		public bool IsActive { get; set; }

		// Navigation Properties
		public virtual User Owner { get; set; }
		public virtual List<Credential> CredentialsOwned { get; set; }
	}
}