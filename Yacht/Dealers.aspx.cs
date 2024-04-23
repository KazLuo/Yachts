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
    public partial class Dealers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getCountryID(); //取得國家 id
                loadLeftMenu();
                loadDealerList();
            }
        }

        private void getCountryID()
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

            //如無網址傳值則設為第一筆國家名稱 id
            if (string.IsNullOrEmpty(urlIDStr))
            {
                string sql = "SELECT TOP 1 id FROM Country";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    urlIDStr = reader["id"].ToString();
                }
                connection.Close();
            }

            //將 id 存入 Session 使用
            Session["id"] = urlIDStr;
        }

        private void loadDealerList()
        {
            //取得 Session 儲存 id，Session 物件需轉回字串
            string countryIDStr = Session["id"].ToString();

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            string sql = "SELECT country FROM Country WHERE id = @countryIDStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@countryIDStr", countryIDStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string countryStr = reader["country"].ToString();
                LabLink.InnerText = countryStr;
                LitTitle.InnerText = countryStr;
            }
            connection.Close();

            //依 country id 取得代理商資料
            StringBuilder dealerListHtml = new StringBuilder();
            string sqlArea = "SELECT * FROM Dealers WHERE country = @countryIDStr";
            SqlCommand commandArea = new SqlCommand(sqlArea, connection);
            commandArea.Parameters.AddWithValue("@countryIDStr", countryIDStr);
            connection.Open();
            SqlDataReader readerArea = commandArea.ExecuteReader();
            while (readerArea.Read())
            {
                string idStr = readerArea["id"].ToString();
                string countryStr = readerArea["country"].ToString();
                string cityStr = readerArea["city"].ToString();
                string graphpathStr = readerArea["graphpath"].ToString();
                string companyStr = readerArea["company"].ToString();
                string nameStr = readerArea["name"].ToString();
                string addressStr = readerArea["address"].ToString();
                string telStr = readerArea["tel"].ToString();
                string faxStr = readerArea["fax"].ToString();
                string emailStr = readerArea["mail"].ToString();
                string websiteStr = readerArea["website"].ToString();
                
                dealerListHtml.Append("<li><div class='list02'><ul><li class='list02li'><div>" +
            $"<p><img id='Image{idStr}' src='{ConvertToRelativePath(graphpathStr)}' style='border-width:0px;' Width='209px' /> </p></div></li>" +
            $"<li class='list02li02'> <span>{cityStr}</span><br />");
                if (!string.IsNullOrEmpty(companyStr))
                {
                    dealerListHtml.Append($"{companyStr}<br />");
                }
                if (!string.IsNullOrEmpty(nameStr))
                {
                    dealerListHtml.Append($"Contact：{nameStr}<br />");
                }
                if (!string.IsNullOrEmpty(addressStr))
                {
                    dealerListHtml.Append($"Address：{addressStr}<br />");
                }
                if (!string.IsNullOrEmpty(telStr))
                {
                    dealerListHtml.Append($"TEL：{telStr}<br />");
                }
                if (!string.IsNullOrEmpty(faxStr))
                {
                    dealerListHtml.Append($"FAX：{faxStr}<br />");
                }
                if (!string.IsNullOrEmpty(emailStr))
                {
                    dealerListHtml.Append($"E-Mail：{emailStr}<br />");
                }
                if (!string.IsNullOrEmpty(websiteStr))
                {
                    dealerListHtml.Append($"<a href='{websiteStr}' target='_blank'>{websiteStr}</a>");
                }
                dealerListHtml.Append("</li></ul></div></li>");
            }
            connection.Close();

            //渲染畫面
            DealerList.Text = dealerListHtml.ToString();
        }

        private string GetCountryName(string countryName)
        {


            // 使用ADO.NET連接到數據庫，查詢 Country 資料表，根據 countryName 獲取對應的國家ID
            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT country FROM Country WHERE country = @countryName";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@countryName", countryName);

                // 執行查詢，獲取國家ID
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    countryName = result.ToString();
                }
            }

            return countryName;
        }

        private void loadLeftMenu()
        {
            //反覆變更字串的值建議用 StringBuilder 效能較好
            StringBuilder leftMenuHtml = new StringBuilder();

            //取得國家分類
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            string sqlCountry = "SELECT * FROM country";
            SqlCommand commandCountry = new SqlCommand(sqlCountry, connection);
            connection.Open();
            SqlDataReader readerCountry = commandCountry.ExecuteReader();
            while (readerCountry.Read())
            {
                string idStr = readerCountry["id"].ToString();
                string countryStr = readerCountry["country"].ToString();
                // StringBuilder 用 Append 加入字串內容
                leftMenuHtml.Append($"<li><a href='dealers.aspx?id={idStr}'> {countryStr} </a></li>");
            }
            connection.Close();

            //渲染畫面
            LeftMenu.Text = leftMenuHtml.ToString();
        }

        protected string ConvertToRelativePath(string absolutePath)
        {
            if (string.IsNullOrEmpty(absolutePath))
                return "";

            // Check if the absolutePath starts with "~/"
            if (absolutePath.StartsWith("~/"))
            {
                // If it does, return it as is since it's already a relative path
                return absolutePath;
            }
            else
            {
                // Otherwise, convert the absolute path to a relative path
                // by removing the server's absolute path
                string appRootPath = Server.MapPath("~/");
                return "../" + absolutePath.Substring(appRootPath.Length).Replace(@"\", "/");
            }
        }
    }
}