using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace ApplyLayout2
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text!="" || TextBox2.Text != "" || TextBox3.Text != "")
            {
                

                string username = TextBox1.Text;
               
                string sqlStr = $"select COUNT (*)  From account where uname='{username}';";
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["LayoutAccountConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    conn.Open();
                    //SqlDataReader dr = cmd.ExecuteReader();
                    int count = (int)cmd.ExecuteScalar(); // 獲取結果的單個值
                    if (count > 1)
                    {
                        Label1.Text = "帳號名稱重複請重新輸入";
                        Label1.ForeColor = System.Drawing.Color.Orange;
                    }
                    else
                    {
                        string Sqlcom = "INSERT INTO account (uname, mail, pw,permission) VALUES(@uname, @mail, @pw,4);";
                        using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["LayoutAccountConnectionString"].ConnectionString))
                        {
                            SqlCommand command = new SqlCommand(Sqlcom, con);
                            con.Open();
                            command.Parameters.AddWithValue("@uname", TextBox1.Text);
                            command.Parameters.AddWithValue("@mail", TextBox2.Text);
                            command.Parameters.AddWithValue("@pw", TextBox3.Text);
                            command.ExecuteNonQuery();
                            command.Cancel();
                            con.Close();
                        }
                        Label1.Text = "註冊成功!";
                        Label1.ForeColor = System.Drawing.Color.Green;
                    }
                };

            }
            else
            {

                Label1.Text = "註冊資訊錯誤請重新輸入";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
           
            
        }
    }
}