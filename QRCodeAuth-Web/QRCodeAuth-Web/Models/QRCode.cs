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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRCodeAuth_Web.Models
{
	public class QRCode
	{
		private WebAccount owner { get; set; }
		private string id { get; set; }
		private ArrayList credentialsNeeded { get; set; }
		private ArrayList scannedBy { get; set; }

		public QRCode()
		{
		}

		public QRCode(WebAccount owner, string id, ArrayList credentialsNeeded, ArrayList scannedBy)
		{
			this.owner = owner;
			this.id = id;
			this.credentialsNeeded = credentialsNeeded;
			this.scannedBy = scannedBy;
		}

		public override string ToString()
		{
			return base.ToString();
		}

	}
}