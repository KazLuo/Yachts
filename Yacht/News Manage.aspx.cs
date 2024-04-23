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
    public partial class News_Manage : System.Web.UI.Page
    {
        public object DropDownList1 { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showNews();
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

        protected void showNews()
        {
            //依下拉選單選取國家的值 (id) 取得地區分類
            
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            string sql = "SELECT id,postDate,title,graphpath FROM News";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                // 直接從 CommandArgument 獲取 ID
                string id = e.CommandArgument.ToString();

                // 重新導向到新的頁面並在 QueryString 中附加 ID
                Response.Redirect("NewsCreate.aspx?id=" + id);
            }
        }



    }
}