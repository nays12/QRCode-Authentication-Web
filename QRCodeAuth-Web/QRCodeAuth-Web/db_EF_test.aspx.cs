using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;
using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models.Logic;


namespace QRCodeAuth_Web
{
	public partial class db_EF_test : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			using (var dbconn = new WebSystemData())
			{
				// insert
				//User info = new User
				//{
				//    SchoolIdNumber = "7865293",
				//    FirstName = "MARRY",
				//    LastName = "KIM",
				//    group = "CS"
				//};
				//dbconn.Users.Add(info);
				//dbconn.SaveChanges();

				//selected
				//Users info = context.System_user.FirstOrDefault(i => i.SchoolIdNumber == "1195191");
				//Response.Write("the selected is: " + info.SchoolIdNumber + " ; " + info.FirstName + " " + info.LastName);

				//update
				User info = dbconn.Users.FirstOrDefault(i => i.SchoolIdNumber == "1195191");
				info.FirstName = "zhimin";
				dbconn.SaveChanges();

				//remove
				//Users info = dbconn.Users.FirstOrDefault(i => i.SchoolIdNumber == "1453678");
				//dbconn.Users.Remove(info);

				//dbconn.SaveChanges();
			}
			// Create events to test EventsController
			//using (var dbconn = new WebSystemData())
			//{
			//	Event e1 = new Event
			//	{ 
			//		name = "Delta Waffle Day",
			//		type = eventType
			//	};
			//}
		}
	}
}