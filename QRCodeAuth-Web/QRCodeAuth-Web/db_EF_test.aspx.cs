﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;


namespace QRCodeAuth_Web
{
    public partial class db_EF_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (web_applicationEntities context = new web_applicationEntities()) {
                // insert
                //System_user info = new System_user
                //{
                //    Id = "7865293",
                //    First_name = "MARRY",
                //    Last_name = "KIM",
                //    Group = "CS"
                //};
                //context.System_user.Add(info);
                //context.SaveChanges();

                //selected
                //System_user info = context.System_user.FirstOrDefault(i => i.Id == "1195191");
                //Response.Write("the selected is: " + info.Id + " ; " + info.First_name + " " + info.Last_name);

                //update
                System_user info = context.System_user.FirstOrDefault(i => i.Id == "1195191");
                info.First_name = "zhimin";
                context.SaveChanges();

                //remove
                //System_user info = context.System_user.FirstOrDefault(i => i.Id == "1453678");
                //context.System_user.Remove(info);

                //context.SaveChanges();


            }
        }
    }
}