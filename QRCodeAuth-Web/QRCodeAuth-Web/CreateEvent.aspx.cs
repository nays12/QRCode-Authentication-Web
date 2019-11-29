/*
 * Purpose: Enables an Web Account user to create an event in which they collect the 
 * digital credentials of its attendees.
 * 
 * Algorithm: 
 */

using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models;

namespace QRCodeAuth_Web
{
	public partial class CreateEvent : System.Web.UI.Page
	{
		protected WebAccount activeWebAccount = new WebAccount();
		private static Event createdEvent = new Event();
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public static Event getCreatedEvent()
		{
			return createdEvent;
		}

		protected void btnCreate_Click(object sender, EventArgs e)
		{
			CreateNewEvent();
		}

		protected void CreateNewEvent()
		{
			// Get Event Type
			var selection = ddlEventType.SelectedIndex;
			EventType type = (EventType)selection;

			//Get Required Credentials
			List<CredentialType> creds = GetRequiredCredentials();

			Event ev = new Event
			{
				Name = txtName.Text,
				Location = txtLocation.Text,
				EventType = type,
				StartTime = Convert.ToDateTime(txtStartTime.Text),
				EndTime = Convert.ToDateTime(txtEndTime.Text),
				Description = txtDescription.Text,
				CredentialsNeeded = creds,
				Owner = activeWebAccount.WebId
			};

			var databaseEvent = EventsRepo.AddEvent(ev);
			createdEvent = databaseEvent;
			lblStatus.Text = string.Format("Success! You have creted the new Event: {0}.\n Now generate a QR Code for your attendees to scan!", ev.Name);
		}

		protected List<CredentialType> GetRequiredCredentials()
		{
			List<CredentialType> creds = new List<CredentialType>();

			foreach (ListItem item in cblCredentialsNeeded.Items)
			{
				if (item.Selected) 
				{
					var selctedCred = (CredentialType)(Enum.Parse(typeof(CredentialType), item.Value));
					creds.Add(selctedCred);							
				}
			}
			return creds;
		}

		protected void GetLoggedInUserInfo()
		{
			activeWebAccount = (WebAccount)Session["ActiveWebAccount"];
		}
	}
}