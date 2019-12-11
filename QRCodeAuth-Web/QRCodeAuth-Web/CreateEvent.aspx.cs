/*
 * Purpose: Enables an Web Account user to create an event in which they collect the 
 * digital credentials of its attendees.
 * 
 * Contributors: 
 * Naomi Wiggins
 */

using System;
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
			GetLoggedInUserInfo();
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

			var startT = txtDate.Text + " " + txtStartTime.Text;
			var endT = txtDate.Text + " " + txtEndTime.Text;

			Event ev = new Event
			{
				Name = txtName.Text,
				Location = txtLocation.Text,
				EventType = type,
				Date = DateTime.Parse(txtDate.Text),
				StartTime = DateTime.Parse(startT),
				EndTime = DateTime.Parse(endT),
				Description = txtDescription.Text,
				Owner = activeWebAccount.WebId
			};

			EventsRepo.AddEvent(ev);
			lblStatus.Text = string.Format("Success! You have created the new Event: {0}.", ev.Name);
		}

		protected void GetLoggedInUserInfo()
		{
			activeWebAccount = (WebAccount)Session["ActiveWebAccount"];
		}

		protected void btnManage_Click(object sender, EventArgs e)
		{
			Response.Redirect("ManageEvent.aspx");
		}

		protected void btnDone_Click(object sender, EventArgs e)
		{
			Response.Redirect("Home.aspx");
		}
	}
}