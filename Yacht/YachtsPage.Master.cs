using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadLeftMenu();
        }


        private void loadLeftMenu()
        {
            //反覆變更字串的值建議用 StringBuilder 效能較好
            StringBuilder leftMenuHtml = new StringBuilder();

            //取得國家分類
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            string sqlCountry = "SELECT * FROM Yachts";
            SqlCommand commandCountry = new SqlCommand(sqlCountry, connection);
            connection.Open();
            SqlDataReader readerYachts = commandCountry.ExecuteReader();
            while (readerYachts.Read())
            {
                
                string idStr = readerYachts["id"].ToString();
                string modleyStr = readerYachts["model"].ToString();
                string typeStr = readerYachts["type"].ToString();
                bool isNewBuild = Convert.ToBoolean(readerYachts["newBuild"]);
                bool isNewDesign = Convert.ToBoolean(readerYachts["newDesign"]);
                // StringBuilder 用 Append 加入字串內容
                
                if (isNewBuild) 
                {
                    leftMenuHtml.Append($"<li><a href='Yachts.aspx?id={idStr}'> {modleyStr + " " + typeStr+ " " + " (NewBuild)"} </a></li>");
                }
                else
                {
                    if (isNewDesign)
                    {
                        leftMenuHtml.Append($"<li><a href='Yachts.aspx?id={idStr}'> {modleyStr + " " + typeStr + " " + " (NewDesign)"} </a></li>");
                    }
                    else
                    {
                        leftMenuHtml.Append($"<li><a href='Yachts.aspx?id={idStr}'> {modleyStr + " " + typeStr} </a></li>");
                    }
                }
                
            }
            connection.Close();

            //渲染畫面
            LeftMenu.Text = leftMenuHtml.ToString();
        }




    }
}