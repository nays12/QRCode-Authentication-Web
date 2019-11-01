using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;
using QRCodeAuth_Web.Models.Data;


namespace QRCodeAuth_Web
{
    public partial class db_EF_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var dbconn  = new WebSystemData()) {
				// insert
				//User info = new System_user
				//{
				//    school_id_number = "7865293",
				//    first_name = "MARRY",
				//    last_name = "KIM",
				//    group = "CS"
				//};
				//dbconn.Users.Add(info);
				//dbconn.SaveChanges();

				//selected
				//Users info = context.System_user.FirstOrDefault(i => i.school_id_number == "1195191");
				//Response.Write("the selected is: " + info.school_id_number + " ; " + info.first_name + " " + info.last_name);

				//update
				User info = dbconn.Users.FirstOrDefault(i => i.school_id_number == "1195191");
                info.first_name = "zhimin";
				dbconn.SaveChanges();

				//remove
				//Users info = dbconn.Users.FirstOrDefault(i => i.school_id_number == "1453678");
				//dbconn.Users.Remove(info);

				//dbconn.SaveChanges();


			}
		}
    }
}