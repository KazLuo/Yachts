using CKFinder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht
{
    public partial class NewsViewManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                abtloadContent();
                FileBrowser fileBrowser = new FileBrowser();
                fileBrowser.BasePath = "/ckfinder";
                fileBrowser.SetupCKEditor(CKEditorControl1);
            }
        }

        protected void UploadAboutUsBtn_Click(object sender, EventArgs e)
        {
            abtupdateContent();
        }

        private void abtloadContent()
        {
            string newsIDstr = Request.QueryString["id"];
            //從資料庫取資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            string sqlCountry = "SELECT content From News Where id = @newsIDstr";
            
            SqlCommand command = new SqlCommand(sqlCountry, connection);
            command.Parameters.AddWithValue("@newsIDstr", newsIDstr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //渲染畫面
                CKEditorControl1.Text = HttpUtility.HtmlDecode(reader["content"].ToString());
            }
            command.Cancel();
            connection.Close();
        }

        private void abtupdateContent()
        {
            string newsIDstr = Request.QueryString["id"];
            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlCountry = "UPDATE News SET content = @Content WHERE id = @newsIDstr";
                    SqlCommand command = new SqlCommand(sqlCountry, connection);
                    command.Parameters.AddWithValue("@Content", CKEditorControl1.Text);
                    command.Parameters.AddWithValue("@newsIDstr", newsIDstr);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Response.Write("更新異常");
            }
        }
    }
}