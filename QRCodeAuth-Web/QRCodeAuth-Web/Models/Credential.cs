/******************************************************************************\
 * Contributing Programmers: Naomi, {add name here if you work on this class}
 *
 * Purpose:
 * 
 * Preconditions/Assumptions:
 * 
 * Notes:
 *
 * Algorithm:
 * 
 * 
 \*******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRCodeAuth_Web.Models
{
	public class Credential
	{

		private MobileAccount owner { get; set; }
		private WebAccount issuer { get; set; }
		private string name { get; set; }
		private string value { get; set; }
		private DateTime issueDate { get; set; }
		private DateTime expirationDate { get; set; }
		private bool isValid { get; set; }

		public Credential()
		{
		}

		public Credential(MobileAccount owner, WebAccount issuer, string name, string value, DateTime issueDate, DateTime expirationDate, bool isValid)
		{
			this.owner = owner;
			this.issuer = issuer;
			this.name = name;
			this.value = value;
			this.issueDate = issueDate;
			this.expirationDate = expirationDate;
			this.isValid = isValid;
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}