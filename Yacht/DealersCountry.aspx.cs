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
    public partial class DealersCountry : System.Web.UI.Page
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

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //1.連線資料庫
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            //2.sql語法
            string sql = "INSERT INTO Country (country) VALUES(@countryName)";
            //3.創建command物件
            SqlCommand command = new SqlCommand(sql, connection);
            //4.參數化避免攻擊
            command.Parameters.AddWithValue("@countryName", Addcountry.Text);
            //5.資料庫連線開啟
            connection.Open();
            //6.執行sql (新增刪除修改)
            command.ExecuteNonQuery(); //無回傳值
            //7.資料庫關閉
            connection.Close();
            //畫面渲染
            GridView1.DataBind();
         
            //清空輸入欄位
            Addcountry.Text = "";
        }



        protected string ConvertToRelativePath(string absolutePath)
        {
            if (string.IsNullOrEmpty(absolutePath))
                return "";

            // Replace the server's absolute path with a relative path. Adjust as needed.
            return absolutePath.Replace(Server.MapPath("~/"), "~/").Replace(@"\", "/");
        }

    
    }
}