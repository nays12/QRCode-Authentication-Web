/******************************************************************************\
 * Contributing Programmers: Naomi, {add name here if you work on this class}
 *
 * Purpose:
 * 
 * Preconditions/Assumptions:
 * 
 * Notes:
 * - will definately work on finding a better way to list credentials and event objects here. - Naomi
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
	public class MobileAccount
	{
		private User accountOwner { get; set; }
		private ArrayList credentials { get; set; } 
		private ArrayList pastEvents { get; set; }


		// Default constructor
		public MobileAccount()
		{

		}

		// full constructor
		public MobileAccount(User accountOwner, ArrayList credentials, ArrayList pastEvents)
		{
			this.accountOwner = accountOwner;
			this.credentials = credentials;
			this.pastEvents = pastEvents;
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}


}