using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace _4_9_Task2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (!Directory.Exists(Server.MapPath("Images")))
            {
                Directory.CreateDirectory(Server.MapPath("Images"));
            }
            string imageurl = (Server.MapPath("Images") + "\\" + FileUpload1.FileName);
            string dppathimg = "~/Images/" + FileUpload1.FileName;
            FileUpload1.SaveAs(imageurl);

            SqlCommand cmd = new SqlCommand("insert into ProductMaster (ProductImage) values (@ProductImage)", con);
            cmd.Parameters.AddWithValue("@ProductImage", dppathimg);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}