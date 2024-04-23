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
    public partial class YachtsSpec : System.Web.UI.Page
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
                string spec = readerNews["spec"].ToString();
                if (!string.IsNullOrEmpty(spec))
                {
                    YachtsHtml.Append($"{spec}<br />");
                }
            }
            connection.Close();

            //渲染畫面
            Literal1.Text = YachtsHtml.ToString();

        }

    }
}