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
    public partial class NewsCreat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IsLoggedIn"] == null || !(bool)Session["IsLoggedIn"])
                {
                    contentPlaceHolder.Visible = false;
                }
                else
                {
                    contentPlaceHolder.Visible = true;
                }
                FileBrowser fileBrowser = new FileBrowser();
                fileBrowser.BasePath = "/ckfinder";
                fileBrowser.SetupCKEditor(CKEditorControl1);
                string newsIDstr = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(newsIDstr))
                {
                    LoadNewsData(newsIDstr);
                    litHeader.Text = "News Edit";
                    Button3.Text = "Edit";


                }
                else
                {
                    litHeader.Text = "News Create";
                    Button3.Text = "Create";
                }
            }
        }

        private void LoadNewsData(string id)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM News WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    
                    if (reader["top"] != DBNull.Value)
                    {
                        isTopTB.Checked = Convert.ToBoolean(reader["top"]);
                    }
                    else
                    {
                        isTopTB.Checked = false; // 或任何你想賦予的默認值
                    }
                    pstDateTB.Text = Convert.ToDateTime(reader["postDate"]).ToString("yyyy-MM-dd");
                    titleTB.Text = reader["title"].ToString();
                    titleContentTB.Text = reader["titlecontent"].ToString();
                    CKEditorControl1.Text = reader["content"].ToString();
                    graphpathTB.Text = reader["graphpath"].ToString();
                }
                connection.Close();
            }
            string newsIDstr = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(newsIDstr))
            {
                BtnDelete.Visible = true;
            }
            else
            {
              
            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            string savePath = Server.MapPath("~/Upload/");

            if (FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName;
                savePath = savePath + fileName;
                FileUpload1.SaveAs(savePath);
                Label2.Text = " 上傳成功，檔名 ---- " + fileName;

                // 更新到資料庫中
               
            }
            else
            {
                Label2.Text = " 請先挑選檔案之後，再來上傳 ";
            }
            graphpathTB.Text = savePath;
        }




        protected void BtnAddOrUpdate_Click(object sender, EventArgs e)
        {
            string newsIDstr = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(newsIDstr))
            {
                UpdateNews(newsIDstr);  // 如果有ID，則進行更新操作
                Response.Redirect("News Manage.aspx");
            }
            else
            {
                InsertNews();  // 否則執行新增操作
                Response.Redirect("News Manage.aspx");
            }
        }

        private void UpdateNews(string id)
        {
            bool isTop = isTopTB.Checked;
            string pstdate = pstDateTB.Text;
            string title = titleTB.Text;
            string titleContent = titleContentTB.Text;
            string content = CKEditorControl1.Text;
            string cover = graphpathTB.Text;

            DateTime postDateTime = Convert.ToDateTime(pstdate);
            string pstStr = postDateTime.ToString("yyyy-MM-dd");

            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlUpdate = "UPDATE News SET postDate = @postDate, title = @title, titlecontent = @titleContent, content = @content, [top] = @Istop, graphpath = @graphpath WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(sqlUpdate, connection))
                {
                    cmd.Parameters.AddWithValue("@IsTop", isTop);
                    cmd.Parameters.AddWithValue("@postDate", pstStr);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@titlecontent", titleContent);
                    cmd.Parameters.AddWithValue("@content", content);
                    cmd.Parameters.AddWithValue("@graphpath", cover);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        private void InsertNews()
        {


            bool isTop = isTopTB.Checked;  // Check the state of the checkbox
            string pstdate = pstDateTB.Text;
            string title = titleTB.Text;
            string titleContent = titleContentTB.Text;
            string content = CKEditorControl1.Text;
            string cover = graphpathTB.Text;

            DateTime postDateTime = Convert.ToDateTime(pstdate);
            string pstStr = postDateTime.ToString("yyyy-MM-dd");


            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlInsert = "INSERT INTO News (postDate,title,titlecontent,content,[top],graphpath) VALUES (@postDate, @title, @titleContent, @content,@Istop,@graphpath)";
                using (SqlCommand cmd = new SqlCommand(sqlInsert, connection))
                {
                    cmd.Parameters.AddWithValue("@IsTop", isTop);
                    cmd.Parameters.AddWithValue("@postDate", pstStr);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@titlecontent", titleContent);
                    cmd.Parameters.AddWithValue("@content", content);
                    cmd.Parameters.AddWithValue("@graphpath", cover);
                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }
            
        }


        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string newsIDstr = Request.QueryString["id"];  //假設你的URL有包含id作為querystring

            if (string.IsNullOrEmpty(newsIDstr))
            {
                Response.Write("ID錯誤");
                return;
            }

            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlDelete = "DELETE FROM News WHERE id = @newsIDstr";
                    SqlCommand command = new SqlCommand(sqlDelete, connection);
                    command.Parameters.AddWithValue("@newsIDstr", newsIDstr);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        Response.Write("成功刪除");
                        // 如果你希望刪除後重定向到某個頁面
                        // Response.Redirect("YourRedirectPage.aspx");
                    }
                    else
                    {
                        Response.Write("刪除失敗");
                    }
                    Response.Redirect("News Manage.aspx");
                }
            }
            catch (SqlException ex)
            {
                Response.Write("資料庫操作異常: " + ex.Message);
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("News Manage.aspx");
        }
    }

        
}