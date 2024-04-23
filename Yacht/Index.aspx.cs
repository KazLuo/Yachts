using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBanner();
                loadNews();
            }
            
        }

        private void loadBanner()
        {
            List<ImagePath> savePathList = new List<ImagePath>();

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            string sqlLoad = "SELECT * FROM Yachts ORDER BY id DESC";
            SqlCommand command = new SqlCommand(sqlLoad, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder bannerHtml = new StringBuilder();
            while (reader.Read())
            {
                string imgNameStr = reader["bannerImgPath"].ToString();

                string model = reader["model"].ToString();
                string type = reader["type"].ToString();

                string isNewDesignStr = reader["newDesign"].ToString();
                string isNewBuildingStr = reader["newBuild"].ToString();

                string newTagStr = ""; // 標籤檔名用
                string displayNewStr = "0"; // value 預設為 0 不顯示標籤
                if (isNewDesignStr.Equals("True"))
                {
                    displayNewStr = "1";
                    newTagStr = "images/new02.png";
                }
                else if (isNewBuildingStr.Equals("True"))
                {
                    displayNewStr = "1";
                    newTagStr = "images/new01.png";
                }

                bannerHtml.Append($"<li class='info' style='border-radius: 5px;height: 424px;width: 978px;'><a href='' target='_blank'><img src='{imgNameStr}' style='width: 978px;height: 424px;border-radius: 5px;'/></a><div class='wordtitle'>{model} <span>{type}</span><br /><p>SPECIFICATION SHEET</p></div><div class='new' style='display: none;overflow: hidden;border-radius:10px;'><img src='{newTagStr}' alt='new' /></div><input type='hidden' value='{displayNewStr}' /></li>");
            }
            connection.Close();

            LitBanner.Text = bannerHtml.ToString();
            LitBannerNum.Text = bannerHtml.ToString(); // 不顯示但影響輪播圖片數量計算
        }

        // 輪播圖資料
        public class ImagePath
        {
            public string SavePath { get; set; }
        }

        private void loadNews()
        {
            DateTime nowTime = DateTime.Now;
            string nowDate = nowTime.ToString("yyyy-MM-dd");
            int startDate = -1;
            DateTime limitTime = nowTime.AddMonths(startDate);
            string limitDate = limitTime.ToString("yyyy-MM-dd");

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            string sql = "SELECT COUNT(id) FROM News WHERE postDate >= @limitDate AND postDate <= @nowDate";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@nowDate", nowDate);
            command.Parameters.AddWithValue("@limitDate", limitDate);
            connection.Open();
            int newsNum = Convert.ToInt32(command.ExecuteScalar());
            while (newsNum < 3)
            {
                startDate--;
                limitTime = nowTime.AddDays(startDate);
                limitDate = limitTime.ToString("yyyy-MM-dd");
                SqlCommand command2 = new SqlCommand(sql, connection);
                command2.Parameters.AddWithValue("@nowDate", nowDate);
                command2.Parameters.AddWithValue("@limitDate", limitDate);
                newsNum = Convert.ToInt32(command2.ExecuteScalar());
            }
            connection.Close();

            connection.Open();
            string sql2 = "SELECT TOP 3 * FROM News WHERE postDate >= @limitDate AND postDate <= @nowDate ORDER BY [top] DESC, postDate DESC";
            SqlCommand command3 = new SqlCommand(sql2, connection);
            command3.Parameters.AddWithValue("@nowDate", nowDate);
            command3.Parameters.AddWithValue("@limitDate", limitDate);
            SqlDataReader reader = command3.ExecuteReader();
            int count = 1;
            while (reader.Read())
            {
                string isTopStr = reader["top"].ToString();
                string guidStr = reader["id"].ToString(); // 使用 id 作為識別。
                string newsImg = reader["graphpath"].ToString();
                DateTime dateTimeTitle = DateTime.Parse(reader["postDate"].ToString());
                string newsTitle = reader["title"].ToString();

                if (count == 1)
                {
                    LiteralNewsImg1.Text = $"<img id='thumbnail_Image1' src='{ConvertToRelativePath(newsImg)}' style='border-width: 0px;' />";
                    LabNewsDate1.Text = dateTimeTitle.ToString("yyyy/M/d");
                    HLinkNews1.Text = newsTitle;
                    HLinkNews1.NavigateUrl = $"NewsContent.aspx?id={guidStr}";
                    ImgIsTop1.Visible = isTopStr.Equals("True");
                }
                else if (count == 2)
                {
                    LiteralNewsImg2.Text = $"<img id='thumbnail_Image2' src='{ConvertToRelativePath(newsImg)}' style='border-width: 0px;' />";
                    LabNewsDate2.Text = dateTimeTitle.ToString("yyyy/M/d");
                    HLinkNews2.Text = newsTitle;
                    HLinkNews2.NavigateUrl = $"NewsContent.aspx?id={guidStr}";
                    ImgIsTop2.Visible = isTopStr.Equals("True");
                }
                else if (count == 3)
                {
                    LiteralNewsImg3.Text = $"<img id='thumbnail_Image3' src='{ConvertToRelativePath(newsImg)}' style='border-width: 0px;' />";
                    LabNewsDate3.Text = dateTimeTitle.ToString("yyyy/M/d");
                    HLinkNews3.Text = newsTitle;
                    HLinkNews3.NavigateUrl = $"NewsContent.aspx?id={guidStr}";
                    ImgIsTop3.Visible = isTopStr.Equals("True");
                }
                count++;
            }
            connection.Close();
        }

        protected string ConvertToRelativePath(string absolutePath)
        {
            // 如果 absolutePath 是空的或沒有內容，直接返回空字串
            if (string.IsNullOrEmpty(absolutePath))
                return "";

            // 檢查 absolutePath 是否以 "~/"" 開始
            if (absolutePath.StartsWith("~/"))
            {
                // 如果是，則返回原始字串，因為它已經是相對路徑
                return absolutePath;
            }
            else
            {
                // 否則，將絕對路徑轉換為相對路徑
                // 通過移除伺服器的絕對路徑
                string appRootPath = Server.MapPath("~/");

                // 在擷取子字串之前，確保 absolutePath 的長度大於 appRootPath 的長度
                if (absolutePath.Length > appRootPath.Length)
                {
                    return "../" + absolutePath.Substring(appRootPath.Length).Replace(@"\", "/");
                }
                else
                {
                    // 如果 absolutePath 的長度小於或等於 appRootPath 的長度，返回原始的 absolutePath
                    return absolutePath;
                }
            }
        }




    }
}