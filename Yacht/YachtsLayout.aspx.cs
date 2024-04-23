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
    public partial class YachtsLayout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadContent();
            }
        }

        private void loadContent()
        {
            string YachtsIDStr = Request.QueryString["id"];
            if (string.IsNullOrEmpty(YachtsIDStr))
            {
                YachtsIDStr = "1";
            }

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            string sqltitle = "SELECT * FROM yachtsLayout WHERE id = @YachtsIDStr";
            SqlCommand commandArea = new SqlCommand(sqltitle, connection);
            commandArea.Parameters.AddWithValue("@YachtsIDStr", YachtsIDStr);
            connection.Open();
            var readerNews = commandArea.ExecuteReader();
            if (readerNews.Read())  //因為我們只期望一條記錄，所以使用if而不是while
            {
                string layout1 = readerNews["layout1"].ToString();
                string layout2 = readerNews["layout2"].ToString();

                if (!string.IsNullOrEmpty(layout1))
                {
                    layout1 = ConvertToRelativePath(layout1);
                    Image1.ImageUrl = layout1;
                }
                if (!string.IsNullOrEmpty(layout2))
                {
                    layout2 = ConvertToRelativePath(layout2);
                    Image2.ImageUrl = layout2;
                }
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