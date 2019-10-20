using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace QRCodeAuth_Web
{
    public partial class database_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strconn = "server=localhost;uid=sa;pwd=123;database=web_application";
            SqlConnection conn = new SqlConnection(strconn);   //create conn
            string sql = "select * from [system_user]";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);      //run select 
            Response.Write("success!");
            SqlDataReader dr = cmd.ExecuteReader();          //final return
            if (dr.Read())
            {
                //利用dr[索引]对数据库表进行操作，dr[]返回object；
                //可以用字段做索引，也可用列号0,1..做索引
                Response.Write("<br>"+ dr[0].ToString() + "<br>");
            }

            // this.Lab.Text = "suc";
        }
    }
}