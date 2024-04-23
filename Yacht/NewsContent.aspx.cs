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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadContent();
        }

        private void loadContent()
        {
            string NewsIDStr = Request.QueryString["id"];
            Response.Write(NewsIDStr);
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            //string sql = "SELECT postDate FROM News WHERE id = @NewsIDStr";
            //SqlCommand command = new SqlCommand(sql, connection);
            //command.Parameters.AddWithValue("@NewsIDStr", NewsIDStr);
            //connection.Open();
            //SqlDataReader reader = command.ExecuteReader();
            //if (reader.Read())
            //{
            //    string countryStr = reader["postDate"].ToString();

            //}
            //connection.Close();

            //依 country id 取得代理商資料
            StringBuilder newsHtml = new StringBuilder();
            string sqltitle = "SELECT * FROM News WHERE id = @NewsIDStr";
            SqlCommand commandArea = new SqlCommand(sqltitle, connection);
            commandArea.Parameters.AddWithValue("@NewsIDStr", NewsIDStr);
            connection.Open();
            SqlDataReader readerNews = commandArea.ExecuteReader();
            while (readerNews.Read())
            {

                //newContent.Text = readerNews["content"].ToString();
                //    string idStr = readerNews["id"].ToString();
                string title = readerNews["title"].ToString();
                string content = readerNews["content"].ToString();
                //    string graphpathStr = readerNews["graphpath"].ToString();
                //    //string idStr = readerArea["id"].ToString();
                //    //string countryStr = readerArea["country"].ToString();
                //    //string cityStr = readerArea["city"].ToString();
                string graphpathStr = readerNews["graphpath"].ToString();
                //    //string companyStr = readerArea["company"].ToString();
                //    //string nameStr = readerArea["name"].ToString();
                //    //string addressStr = readerArea["address"].ToString();
                //    //string telStr = readerArea["tel"].ToString();
                //    //string faxStr = readerArea["fax"].ToString();
                //    //string emailStr = readerArea["mail"].ToString();
                //    //string websiteStr = readerArea["website"].ToString();
                //    DateTime postDateTime = Convert.ToDateTime(readerNews["postDate"]);
                //    string pstStr = postDateTime.ToString("yyyy-MM-dd");
                newsHtml.Append("<li><div class='list02'><ul><li class='list02li02'><span>");
                newsHtml.Append(title);
                newsHtml.Append("</span><br /></li></ul></div></li>");
                if (!string.IsNullOrEmpty(content))
                {
                    newsHtml.Append($"{content}<br />");
                }
                //if (!string.IsNullOrEmpty(title))
                //{
                //    dealerListHtml.Append($"<a href='YourTargetPage.aspx?id={idStr}'>{title}</a><br />");
                //}
                //if (!string.IsNullOrEmpty(titleContent))
                //{
                //    dealerListHtml.Append($"{titleContent}<br />");
                //}
                //if (!string.IsNullOrEmpty(telStr))
                //{
                //    dealerListHtml.Append($"TEL：{telStr}<br />");
                //}
                //if (!string.IsNullOrEmpty(faxStr))
                //{
                //    dealerListHtml.Append($"FAX：{faxStr}<br />");
                //}
                //if (!string.IsNullOrEmpty(emailStr))
                //{
                //    dealerListHtml.Append($"E-Mail：{emailStr}<br />");
                //}
                //if (!string.IsNullOrEmpty(websiteStr))
                //{
                //    dealerListHtml.Append($"<a href='{websiteStr}' target='_blank'>{websiteStr}</a>");
                //}

            }
                connection.Close();

            //渲染畫面
            newContent.Text = newsHtml.ToString();
            
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