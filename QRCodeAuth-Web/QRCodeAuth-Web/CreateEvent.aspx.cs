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
using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using ZXing;

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
			List<CredentialType> creds = GetCheckedRequiredCredentials();

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
				CredentialsNeeded = creds,
				Owner = activeWebAccount.WebId
			};

			GenerateQR(ev); // Generate QR from Event

			var databaseEvent = EventsRepo.AddEvent(ev);
			createdEvent = databaseEvent;
			lblStatus.Text = string.Format("Success! You have created the new Event: {0}.\n Your QR Code can be found in the 'QR Codes' folder.", ev.Name);
		}

		protected List<CredentialType> GetCheckedRequiredCredentials()
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
			writer.Write(eventString).Save(path + @"Images\QRCodes\" + ev.Name + ".jpg");

			//// load generated qr image into QR image control
			//eventQR.ImageUrl = path + @"Images\QRCodes\generatedQR.jpg";
			//eventQR.Visible = true;
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