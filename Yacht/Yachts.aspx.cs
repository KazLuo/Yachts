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
    public partial class Yachts : System.Web.UI.Page
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

            //依 country id 取得代理商資料
            StringBuilder YachtsHtml = new StringBuilder();
            string sqltitle = "SELECT * FROM Yachts WHERE id = @YachtsIDStr";
            SqlCommand commandArea = new SqlCommand(sqltitle, connection);
            commandArea.Parameters.AddWithValue("@YachtsIDStr", YachtsIDStr);
            connection.Open();
            var readerNews = commandArea.ExecuteReader();
            while (readerNews.Read())
            {

                string modelAndType = readerNews["model"].ToString() + " " + readerNews["type"].ToString();
                string content = readerNews["overview"].ToString();
                string dimensions = readerNews["dimensions"].ToString();
                YachtsHtml.Append("<li><div class='box3'><ul><li class='list02li02'><span>");
                //YachtsHtml.Append(modelAndType);
                YachtsHtml.Append("</span><br /></li></ul></div></li>");
                if (!string.IsNullOrEmpty(content))
                {
                    YachtsHtml.Append($"{content}<br />");
                }
                if (!string.IsNullOrEmpty(dimensions))
                {
                
                    YachtsHtml.Append($"{dimensions}<br />");
                }
            }
            connection.Close();

            //渲染畫面
            YachtsContent.Text = YachtsHtml.ToString();

        }
    }
}