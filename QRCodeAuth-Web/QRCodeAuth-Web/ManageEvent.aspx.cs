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
			getActiveEvents();
			eventQR.Visible = false;
			gvCredentials.DataBind();
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
			lblOptions.Text = "Please select the event you would like to manage.";

			// Get Web Account's events that have not passed
			//List<Event> events = EventsRepo.GetActiveEvents(activeWebAccount.WebId);
			activeEvents = EventsRepo.GetActiveEvents("4582055");

			gvEvents.DataSource = activeEvents;
		}

		protected void gvEvents_SelectedRow(object sender, EventArgs e)
		{
			int eventIndex = gvEvents.SelectedIndex;	
			Event ev = activeEvents[eventIndex];
			gvCredentials.DataSource = fetchedCreds;
			gvCredentials.DataBind();

			GetEventInfo(ev);
		}

		protected void GetEventInfo(Event ev)
		{
			gvEvents.Visible = false;
			lblOptions.Text = "Here are the details of your Event:";

			lblName.Text = string.Format("Name:	{0}", ev.Name);
			lblLocation.Text = string.Format("Location: {0}", ev.Location);
			lblStartTime.Text = string.Format("Start Time: {0}", ev.StartTime);
			lblEndTime.Text = string.Format("End Time: {0}", ev.EndTime);
			lblDescription.Text = string.Format("Description: {0}", ev.Description);

			GenerateQR(ev);
		}

		protected void GenerateQR(Event ev)
		{
			// Convert string to event
			string eventString = JsonConvert.SerializeObject(ev);

			// get current path
			string path = AppDomain.CurrentDomain.BaseDirectory;

			// create barcode writer that creates QR Code
			BarcodeWriter writer = new BarcodeWriter();
			writer.Format = BarcodeFormat.QR_CODE;

			// encode this text into the qr code and save it to the specified path 
			writer.Write(eventString).Save(path + @"Images\QRCodes\generatedQR.jpg");

			// load generated qr image into QR image control
			eventQR.ImageUrl = path + @"Images\QRCodes\generatedQR.jpg";
			eventQR.Visible = true;
		}

		protected void GetLoggedInUserInfo()
		{
			activeWebAccount = (WebAccount)Session["ActiveWebAccount"];
		}
	}
}