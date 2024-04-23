using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace Yacht
{
    public partial class Certificat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                certcontent_DB();
                certgraph_DB();
            }
        }

        protected void certcontent_DB()
        {
            string sqlcomm = "SELECT CertificatContent FROM AboutUs;";
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlCommand sqlcom = new SqlCommand(sqlcomm, conn);
                SqlDataReader reader = sqlcom.ExecuteReader();

                // 检查是否有行数据
                if (reader.Read())
                {
                    // 从第一行中读取 AboutUs 列的值，并设置到 Literal1.Text 中
                    Label1.Text = reader["CertificatContent"].ToString();
                }
                else
                {
                    // 如果没有数据，可以设置一个默认值或处理其他逻辑
                    Label1.Text = "No data found";
                }
            }

        }
        protected void certgraph_DB()
        {
            string sqlcomm = "SELECT certfilepath FROM Cert;";
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlCommand sqlcom = new SqlCommand(sqlcomm, conn);
                SqlDataReader reader = sqlcom.ExecuteReader();
                
                //取得資料源
                //GridView1.DataSource = reader;
                ListView1.DataSource = reader;
                //取得ID下的所有資料
                //GridView1.DataKeyNames = new string[] { "id" };
                //用於綁定資料
                //GridView1.DataBind();
                ListView1.DataBind();

                sqlcom.Cancel();
                reader.Close();
                conn.Close();
            }
        }
    }
}