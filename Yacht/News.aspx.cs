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
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //getNewsID(); 
                
                loadDealerList();
            }
        }

        private void getNewsID()
        {
            //取得網址傳值的 id 內容
            string urlIDStr = Request.QueryString["id"];

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            //如果是用短網址連入則用短網址 shortUrl 參數內容的國家名稱來判斷 ID
            if (Page.RouteData.Values.Count > 0)
            {
                //取得短網址參數內容的國家名稱
                string urlCountryStr = Page.RouteData.Values["shortUrl"].ToString();
                string sqlID = "SELECT id FROM Country WHERE country = @urlCountryStr";
                SqlCommand commandID = new SqlCommand(sqlID, connection);
                commandID.Parameters.AddWithValue("@urlCountryStr", urlCountryStr);
                connection.Open();
                SqlDataReader readerID = commandID.ExecuteReader();
                if (readerID.Read())
                {
                    urlIDStr = readerID["id"].ToString();
                }
                connection.Close();
            }

        }

        private void loadDealerList()
        {
            ////取得 Session 儲存 id，Session 物件需轉回字串
            //string NewsIDStr = Session["id"].ToString();

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);

            //依 country id 取得代理商資料
            StringBuilder dealerListHtml = new StringBuilder();
            string sqltitle = "SELECT * FROM News ORDER BY [top] DESC, postDate DESC";
            SqlCommand commandArea = new SqlCommand(sqltitle, connection);
            //commandArea.Parameters.AddWithValue("@countryIDStr", countryIDStr);
            connection.Open();
            SqlDataReader readerNews = commandArea.ExecuteReader();
            while (readerNews.Read())
            {
                
                string idStr = readerNews["id"].ToString();
                string title = readerNews["title"].ToString();
                string titleContent = readerNews["titleContent"].ToString();
                string graphpathStr = readerNews["graphpath"].ToString();
                DateTime postDateTime = Convert.ToDateTime(readerNews["postDate"]);
                string pstStr = postDateTime.ToString("yyyy-MM-dd");
                dealerListHtml.Append("<li><div class='list02'><ul><li class='list02li'><div>" +
            $"<p><img id='Image{idStr}' src='{ConvertToRelativePath(graphpathStr)}' style='border-width:0px;' Width='209px' /> </p></div></li>" +
            $"<li class='list02li02'> <span>{pstStr}</span><br />");
                //if (!string.IsNullOrEmpty(pstStr))
                //{
                //    dealerListHtml.Append($"{pstStr}<br />");
                //}
                if (!string.IsNullOrEmpty(title))
                {
                    dealerListHtml.Append($"<a href='NewsContent.aspx?id={idStr}'>{title}</a><br />");
                }
                if (!string.IsNullOrEmpty(titleContent))
                {
                    dealerListHtml.Append($"{titleContent}<br />");
                }
                dealerListHtml.Append("</li></ul></div></li>");
            }
            connection.Close();

            //渲染畫面
            newList.Text = dealerListHtml.ToString();
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