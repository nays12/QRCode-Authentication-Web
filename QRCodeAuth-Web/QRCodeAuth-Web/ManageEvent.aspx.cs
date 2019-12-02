using QRCodeAuth_Web.Models;
using QRCodeAuth_Web.Data;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using ZXing;
using System.Web.UI.WebControls;

namespace QRCodeAuth_Web
{
	public partial class ManageEvent : System.Web.UI.Page
	{
		protected WebAccount activeWebAccount = new WebAccount();
		protected List<Event> activeEvents = new List<Event>();
		protected static List<Credential> fetchedCreds = new List<Credential>();

		protected void Page_Load(object sender, EventArgs e)
		{
			GetLoggedInUserInfo();
			getActiveEvents();
			gvCreds.DataBind();
		}

		public static void GetNewCredentials(List<Credential> creds)
		{
			foreach (Credential c in creds)
			{
				fetchedCreds.Add(c);
			}
		}

		protected void getActiveEvents()
		{
			// Get Web Account's events that have not passed
			activeEvents = EventsRepo.GetActiveEvents(activeWebAccount.WebId);
			if (activeEvents != null && activeEvents.Count > 0)
			{
				lblOptions.Text = "Please select the event you would like to manage.";
				ddlActiveEvents.DataSource = activeEvents;
				ddlActiveEvents.AppendDataBoundItems = true;
				ddlActiveEvents.DataTextField = "Name";
				ddlActiveEvents.DataBind();
			}
			else
			{
				lblOptions.Text = "You do not have any upcoming events to manage. Go to the Create Event page to create one!";
				btnSelect.Visible = false;
				ddlActiveEvents.Visible = false;
			}
		}

		protected void btnSelect_Click(object sender, EventArgs e)
		{
			int eventIndex = ddlActiveEvents.SelectedIndex;
			Event ev = activeEvents[eventIndex];

			System.Diagnostics.Debug.WriteLine(eventIndex);
			System.Diagnostics.Debug.WriteLine(ev.Name);

			GetEventInfo(ev);
		}

		protected void GetEventInfo(Event ev)
		{
			ddlActiveEvents.Visible = false;
			btnSelect.Visible = false;
			lblOptions.Text = "Here are the details of your Event:";

			lblName.Text = string.Format("Name:	{0}", ev.Name);
			lblLocation.Text = string.Format("Location: {0}", ev.Location);
			lblDate.Text = string.Format("Date: {0}", ev.Date.ToShortDateString());
			lblStartTime.Text = string.Format("Start Time: {0}", ev.StartTime.ToShortTimeString());
			lblEndTime.Text = string.Format("End Time: {0}", ev.EndTime.ToShortTimeString());
			lblDescription.Text = string.Format("Description: {0}", ev.Description);

			// load genered qr image into QR image control		
			string path = AppDomain.CurrentDomain.BaseDirectory; // get current path
			imgEventQr.ImageUrl = path + @"Images\QRCodes\" + ev.Name + ".jpg";
			imgEventQr.Visible = true;

			CreateCredentialsView();
		}

		protected void CreateCredentialsView()
		{
			lblInstr.Text = "Here are the credentials of your Event attendees. Please refresh the page to update the table.";
			gvCreds.DataSource = fetchedCreds;
			gvCreds.DataBind();
		}

		protected void GetLoggedInUserInfo()
		{
			activeWebAccount = (WebAccount)Session["ActiveWebAccount"];
		}

		protected void btnDone_Click(object sender, EventArgs e)
		{
			fetchedCreds.Clear();
			Response.Redirect("Home.aspx");
		}
	}
}