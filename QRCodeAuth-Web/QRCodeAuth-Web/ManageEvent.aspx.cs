using QRCodeAuth_Web.Models;
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
		protected User activeUser = new User();
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
			gvCreds.Visible = true;
			gvCreds.DataSource = fetchedCreds;
			gvCreds.DataBind();
		}

		protected void getActiveEvents()
		{
			// Get Web Account's events that have not passed
			activeEvents = EventsRepo.GetActiveEvents(activeWebAccount.WebId);
			if (activeEvents != null && activeEvents.Count > 0)
			{
				lblOptions.Text = "Please select the event you would like to manage and the Credentials you would like to collect during the event.";
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
			CreateEventObject(ev);
			btnGetCreds.Visible = true;
			btnDone.Text = "Done";
		}

		public void CreateEventObject(Event ev)
		{
			// Anonymous object
			var eventAttendance = new
			{
				attendaceManager = activeUser.FirstName + " " + activeUser.LastName,
				department = activeWebAccount.Department,
				eventName = ev.Name,
				eventLocation = ev.Location,
				eventDate = ev.Date,
				eventStart = ev.StartTime,
				eventEnd = ev.EndTime,
				evDescription = ev.Description,
				requestedCredentials = getRequestedCredentialTypes(),
			};

			var result = JsonConvert.SerializeObject(eventAttendance);

			GenerateQRCode(result);
		}

		protected void GetEventInfo(Event ev)
		{
			ddlActiveEvents.Visible = false;
			btnSelect.Visible = false;
			cblRequestedCredentials.Visible = false;
			lblOptions.Text = "";

			lblName.Text = string.Format("Name:	{0}", ev.Name);
			lblLocation.Text = string.Format("Location: {0}", ev.Location);
			//lblDate.Text = string.Format("Date: {0}", ev.Date);
			lblDate.Text = string.Format("Date: {0}", "12/6/2019");
			lblStartTime.Text = string.Format("Start Time: {0}", ev.StartTime.ToShortTimeString());
			lblEndTime.Text = string.Format("End Time: {0}", ev.EndTime.ToShortTimeString());
			lblDescription.Text = string.Format("Description: {0}", ev.Description);
		}

		public List<CredentialType> getRequestedCredentialTypes()
		{
			List<CredentialType> types = new List<CredentialType>();

			foreach (ListItem item in cblRequestedCredentials.Items)
			{
				if (item.Selected)
				{
					string selection = item.Value;
					System.Diagnostics.Debug.WriteLine(selection);

					switch (selection)
					{
						case "Name":
							types.Add(CredentialType.Name);
							break;
						case "Email":
							types.Add(CredentialType.Email);
							break;
						case "ID Number":
							types.Add(CredentialType.IdNumber);
							break;
						case "Date of Birth":
							types.Add(CredentialType.Birthdate);
							break;
						case "Address":
							types.Add(CredentialType.Address);
							break;
						case "PhoneNumber":
							types.Add(CredentialType.PhoneNumber);
							break;
						case "Major":
							types.Add(CredentialType.Major);
							break;
						case "Classification":
							types.Add(CredentialType.Classification);
							break;
						case "Work Title":
							types.Add(CredentialType.WorkTitle);
							break;
					}
				}
			}
			cblRequestedCredentials.Visible = false;
			return types;
		}

		protected void GenerateQRCode(string qrCodeString)
		{
			string hostingPath = HostingEnvironment.MapPath("~/");

			// Get random number for QRName
			string num = Convert.ToString(generateRandomNum());
			string qrName = "eventQR" + num + ".jpg";

			//Create barcode writer 
			BarcodeWriter writer = new BarcodeWriter();
			writer.Format = BarcodeFormat.QR_CODE;
			writer.Write(qrCodeString).Save(hostingPath + @"Images\" + qrName);

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
			activeUser = (User)Session["ActiveUser"];
			activeWebAccount = (WebAccount)Session["ActiveWebAccount"];
		}

		protected void btnDone_Click(object sender, EventArgs e)
		{
			fetchedCreds.Clear();
			Response.Redirect("Home.aspx");
		}

	}
}