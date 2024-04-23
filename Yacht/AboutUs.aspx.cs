using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Yacht
{
    public partial class Company : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                File_DB();
            }
        }

        protected void File_DB()
        {
            string sqlstring = "SELECT AboutUs FROM AboutUs;";
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString))
            {
                //con.Open();
                //SqlCommand sqlcom = new SqlCommand(sqlstring, con);
                ////sqlcom.ExecuteNonQuery();
                //SqlDataReader reader = sqlcom.ExecuteReader();
                //Literal1.Text = reader.ToString();

                con.Open();
                SqlCommand sqlcom = new SqlCommand(sqlstring, con);
                SqlDataReader reader = sqlcom.ExecuteReader();

                
                if (reader.Read())
                {
                    // 第一行讀取 AboutUs 列的值，放到 Literal1.Text 中
                    Literal1.Text = reader["AboutUs"].ToString();
                }
                else
                {
                   //第一行如果沒資料
                    Literal1.Text = "No data found";
                }
            }

        }
    }
}