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
	public class WebAccount
	{
		private User accountOwner { get; set; }
		private string departmentId { get; set; }
		private string departmentName { get; set; }
		private bool isActive { get; set; }
		private bool isCredentialAuthority { get; set; }
		private bool isAttendanceManager { get; set; }
		private bool isInformationCollector { get; set; }

		public WebAccount()
		{

		}

		public WebAccount(User accountOwner, string departmentId, string departmentName, bool isActive, bool isCredentialAuthority, bool isAttendanceManager, bool isInformationCollector)
		{
			this.accountOwner = accountOwner;
			this.departmentId = departmentId;
			this.departmentName = departmentName;
			this.isActive = isActive;
			this.isCredentialAuthority = isCredentialAuthority;
			this.isAttendanceManager = isAttendanceManager;
			this.isInformationCollector = isInformationCollector;
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}