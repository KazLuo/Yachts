using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using Konscious.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Data;

namespace ApplyLayout2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string uname = TextBox1.Text;
        //    string pw = TextBox2.Text;
        //    string sqlStr = $"select COUNT (*)  From account where uname='{uname}' and pw ='{pw}';";
        //    using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["LayoutAccountConnectionString"].ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand(sqlStr, conn);
        //        conn.Open();
        //        //SqlDataReader dr = cmd.ExecuteReader();
        //        int count = (int)cmd.ExecuteScalar(); // 獲取結果的單個值
        //        if (count >= 1)
        //        {
        //            Session["IsLoggedIn"] = true;
        //            Session["uname"] = TextBox1.Text;
        //        }
        //        else
        //        {
        //            Session["IsLoggedIn"] = false;
        //        }
        //    };

        //    if (Session["IsLoggedIn"] != null && (bool)Session["IsLoggedIn"])
        //    {


        //        string sqlString = $"SELECT Permission From account where uname='{uname}' and pw ='{pw}';";
        //        using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["LayoutAccountConnectionString"].ConnectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand(sqlString, conn);
        //            conn.Open();
        //            //SqlDataReader dr = cmd.ExecuteReader();
        //            int permissionNum = (int)cmd.ExecuteScalar(); // 獲取結果的單個值
        //            switch (permissionNum)
        //            {
        //                case 1:
        //                    Session["Permission"] = 1;
        //                    break;
        //                case 2:
        //                    Session["Permission"] = 2;
        //                    break;
        //                case 3:
        //                    Session["Permission"] = 3;
        //                    break;

        //                default:
        //                    break;
        //            }
        //        };
        //        Response.Redirect("CompanyManage.aspx");

        //    }
        //    else
        //    {
        //        Label1.Text = "帳號密碼輸入錯誤";
        //        Label1.ForeColor = System.Drawing.Color.Red;

        //    }
        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string password = TextBox2.Text;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["LayoutAccountConnectionString"].ConnectionString))
        //        {
        //            string sql = "SELECT * FROM account WHERE uname = @uname";
        //            SqlCommand command = new SqlCommand(sql, connection);
        //            command.Parameters.AddWithValue("@uname", TextBox1.Text);
        //            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
        //            DataTable dataTable = new DataTable();
        //            dataAdapter.Fill(dataTable);

        //            if (dataTable.Rows.Count > 0)
        //            {
        //                byte[] hash = Convert.FromBase64String(dataTable.Rows[0]["pw"].ToString());
        //                byte[] salt = Convert.FromBase64String(dataTable.Rows[0]["salt"].ToString());

        //                bool success = VerifyHash(password, salt, hash);

        //                if (success)
        //                {
        //                    string userData = dataTable.Rows[0]["permission"].ToString() + ";" + dataTable.Rows[0]["uname"].ToString() + ";" + dataTable.Rows[0]["mail"].ToString();
        //                    SetAuthenTicket(userData, TextBox1.Text);
        //                    Response.Redirect("Manage.aspx");
        //                }
        //                else
        //                {
        //                    Label1.Text = "Login failed!";
        //                    Label1.Visible = true;
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                Label1.Text = "Login failed!";
        //                Label1.Visible = true;
        //                return;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception and show a generic error message
        //        Label1.Text = "An error occurred. Please try again later.";
        //        Label1.Visible = true;
        //    }
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            string password = TextBox2.Text;
            try
            {
                using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["LayoutAccountConnectionString"].ConnectionString))
                {
                    string sql = "SELECT * FROM account WHERE uname = @uname";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@uname", TextBox1.Text);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        byte[] hash = Convert.FromBase64String(dataTable.Rows[0]["pw"].ToString());
                        byte[] salt = Convert.FromBase64String(dataTable.Rows[0]["salt"].ToString());

                        bool success = VerifyHash(password, salt, hash);

                        if (success)
                        {
                            // Set session variables
                            Session["IsLoggedIn"] = true;
                            Session["uname"] = dataTable.Rows[0]["uname"].ToString();

                            int permissionNum = Convert.ToInt32(dataTable.Rows[0]["permission"].ToString());
                            Session["Permission"] = permissionNum;

                            Response.Redirect("Manage.aspx");
                        }
                        else
                        {
                            Label1.Text = "Login failed!";
                            Label1.Visible = true;
                        }
                    }
                    else
                    {
                        Label1.Text = "Login failed!";
                        Label1.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "An error occurred. Please try again later.";
                Label1.Visible = true;
            }
        }



        private byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            //底下這些數字會影響運算時間，而且驗證時要用一樣的值
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; // 4 核心就設成 8
            argon2.Iterations = 4; //迭代運算次數
            argon2.MemorySize = 1024 * 1024; // 1 GB

            return argon2.GetBytes(16);
        }
        //驗證
        private bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash); // LINEQ
        }

        private void SetAuthenTicket(string userData, string userId)
        {
            //宣告一個驗證票 //需額外引入 using System.Web.Security;
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userId, DateTime.Now, DateTime.Now.AddHours(3), false, userData);
            //加密驗證票
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            //建立 Cookie
            HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            //將 Cookie 寫入回應
            Response.Cookies.Add(authenticationCookie);
        }
    }
}