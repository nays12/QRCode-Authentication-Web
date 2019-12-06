﻿using QRCodeAuth_Web.Models;
using QRCodeAuth_Web.Data;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using ZXing;
using System.Web.UI.WebControls;
using System.Web.Hosting;

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

		protected void btnGetCreds_Click(object sender, EventArgs e)
		{
			lblInstr.Text = "Here are the credentials of your Event attendees.";
			gvCreds.DataSource = fetchedCreds;
			gvCreds.DataBind();
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
			//lblDate.Text = string.Format("Date: {0}", ev.Date);
			lblDate.Text = string.Format("Date: {0}", "12/6/2019");
			lblStartTime.Text = string.Format("Start Time: {0}", ev.StartTime.ToShortTimeString());
			lblEndTime.Text = string.Format("End Time: {0}", ev.EndTime.ToShortTimeString());
			lblDescription.Text = string.Format("Description: {0}", ev.Description);

			GenerateQR(ev);
		}

		protected void GenerateQR(Event ev)
		{
			// Convert string to event
			string eventString = JsonConvert.SerializeObject(ev);

			string hostingPath = HostingEnvironment.MapPath("~/");

			// Get random number for QRName
			string num = Convert.ToString(generateRandomNum());
			string qrName = ev.Name + num + ".jpg";

			//Create barcode writer 
			BarcodeWriter writer = new BarcodeWriter();
			writer.Format = BarcodeFormat.QR_CODE;
			writer.Write(eventString).Save(hostingPath + @"Images\" + qrName);

			//Dispaly QRCode
			imgEventQr.Visible = true;
			imgEventQr.ImageUrl = "https://qrcodemobileauthenticationweb.azurewebsites.net/Images/" + qrName;

		}
		public static int generateRandomNum()
		{
			// specifying the range for the generated number
			int min = 10000;
			int max = 99999;

			Random ran = new Random();
			int code = ran.Next(min, max);

			return code;
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