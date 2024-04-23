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
    public partial class YachtsManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showYachts();
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

        protected void showYachts()
        {
            //依下拉選單選取國家的值 (id) 取得地區分類

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            string sql = "SELECT [id], [model], [type], [newBuild],[newDesign], [top] FROM [Yachts]";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            connection.Close();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                // 直接從 CommandArgument 獲取 ID
                string id = e.CommandArgument.ToString();

                // 重新導向到新的頁面並在 QueryString 中附加 ID
                Response.Redirect("YachtsCreate.aspx?id=" + id);
            }
        }
    }

    
}