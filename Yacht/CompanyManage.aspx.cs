using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;
using System.Data;
using CKFinder;

namespace ApplyLayout2
{
    public partial class YachtsManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                abtloadContent();
                certloadContent();
                FileBrowser fileBrowser = new FileBrowser();
                fileBrowser.BasePath = "/ckfinder";
                fileBrowser.SetupCKEditor(CKEditorControl1);
                if (Session["IsLoggedIn"] == null || !(bool)Session["IsLoggedIn"])
                {
                    contentPlaceHolder.Visible = false;
                }
                else
                {
                    contentPlaceHolder.Visible = true;
                }
            }
        }

        protected void UploadAboutUsBtn_Click(object sender, EventArgs e)
        {
            abtupdateContent();

        }

        protected void uploadCertificatBtn_Click(object sender, EventArgs e)
        {
            certupdateContent();
        }

        protected void DelVImageBtn_Click(object sender, EventArgs e)
        {

        }

        protected void RadioButtonListV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void UploadVBtn_Click(object sender, EventArgs e)
        {
            //單檔案上傳
            //string savePath = @"C:\Users\Kaz\source\repos\ApplyLayout2\ApplyLayout2\Upload\";

            //    if (imageUploadV.HasFile)
            //    {
            //        // 使用者有點選檔案，才可以上傳。
            //        string fileName = imageUploadV.FileName;
            //        savePath = savePath + fileName;

            //        imageUploadV.SaveAs(savePath); Label1.Text = " 上傳成功，檔名 ---- " + fileName;
            //    }
            //    else
            //    {
            //        Label1.Text = " 請先挑選檔案之後，再來上傳 ";
            //    }

            ////多檔案上傳
            //string savePath = Server.MapPath("~/Upload/");

            //// 檢查是否有選取檔案
            //if (imageUploadV.HasFiles)
            //{
            //    foreach (HttpPostedFile uploadedFile in imageUploadV.PostedFiles)
            //    {
            //        // 生成唯一的檔案名稱以避免衝突
            //        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(uploadedFile.FileName);
            //        string filePath = Path.Combine(savePath, fileName);

            //        // 儲存檔案到伺服器
            //        uploadedFile.SaveAs(filePath);
            //        FileUpload_DB(filePath);
            //    }

            //    Label1.Text = "上傳成功" ;
            //}
            //else
            //{
            //    Label1.Text = "請先選擇檔案然後上傳";
            //}

            //虛擬路徑寫法(可讓listview置正常顯示)
            string savePath = Server.MapPath("~/Upload/");

            // 檢查是否有選取檔案
            if (imageUploadV.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in imageUploadV.PostedFiles)
                {
                    // 生成唯一的檔案名稱以避免衝突
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(uploadedFile.FileName);
                    string filePath = Path.Combine(savePath, fileName);

                    // 儲存檔案到伺服器
                    uploadedFile.SaveAs(filePath);

                    // 將虛擬路徑存儲到資料庫，例如：~/Upload/yourfile.png
                    string virtualPath = "~/Upload/" + fileName;
                    FileUpload_DB(virtualPath);
                    ListView1.DataBind();
                }

                Label1.Text = "上傳成功";
                
            }
            else
            {
                Label1.Text = "請先選擇檔案然後上傳";
            }



        }


        private void abtloadContent()
        {
            //從資料庫取資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            string sqlCountry = "SELECT TOP 1 AboutUs FROM AboutUs";
            SqlCommand command = new SqlCommand(sqlCountry, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //渲染畫面
                CKEditorControl1.Text = HttpUtility.HtmlDecode(reader["AboutUs"].ToString());
            }
            command.Cancel();
            connection.Close();
        }
        private void abtupdateContent()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlCountry = "UPDATE AboutUs SET AboutUs = @AboutUs WHERE id = (SELECT TOP 1 id FROM AboutUs);";
                    SqlCommand command = new SqlCommand(sqlCountry, connection);
                    command.Parameters.AddWithValue("@AboutUs", CKEditorControl1.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Response.Write("更新異常");
            }
        }

        private void certloadContent()
        {
            //從資料庫取資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            string sqlCountry = "SELECT TOP 1 CertificatContent FROM AboutUs";
            SqlCommand command = new SqlCommand(sqlCountry, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //渲染畫面
                certificatTbox.Text = HttpUtility.HtmlDecode(reader["CertificatContent"].ToString());

            }
            command.Cancel();
            connection.Close();
        }
        private void certupdateContent()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlCountry = "UPDATE AboutUs SET CertificatContent = @CertificatContent WHERE id = (SELECT TOP 1 id FROM AboutUs);";
                    SqlCommand command = new SqlCommand(sqlCountry, connection);
                    command.Parameters.AddWithValue("@CertificatContent", certificatTbox.Text);

                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
            catch (SqlException ex)
            {
                Response.Write("更新異常");
            }
        }

        protected int FileUpload_DB(String InputFileName)
        {

            //----連結資料庫----
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);

            //-- 當心資料隱碼（SQL Injection）攻擊。請使用「參數」來做。
            SqlCommand cmd = new SqlCommand("INSERT INTO Cert (certfilepath) VALUES (@filename)", connection);
           
            cmd.Parameters.AddWithValue("@filename", InputFileName);

            int i = 0;

            try     //==== 以下程式，只放「執行期間」的指令！=====================
            {
                //== 第一，連結資料庫。
                connection.Open();   //---- 這時候才連結DB

                //== 第二，執行SQL指令。            
                i = cmd.ExecuteNonQuery();

                //==第三，自由發揮，把執行後的結果呈現到畫面上。

            }
            catch (Exception ex)
            {  //---- 如果程式有錯誤或是例外狀況，將執行這一段
                Response.Write("<b>Error Message----  </b>" + ex.ToString() + "<HR/>");
            }
            finally
            {
                // == 第四，釋放資源、關閉資料庫的連結。
                cmd.Cancel();
                //---- Close the connection when done with it.
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return i;  //-- 傳回值。
        }

    }
}