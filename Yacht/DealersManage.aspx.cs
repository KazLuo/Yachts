using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;

namespace Yacht
{
    public partial class DealersManage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showDealer();
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

      

        protected void showDealer()
        {
            //依下拉選單選取國家的值 (id) 取得地區分類
            string selCountry_id = DropDownList1.SelectedValue;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            string sql = "SELECT Dealers.id, Country.country, Dealers.city, Dealers.name, Dealers.company, Dealers.address, Dealers.tel, Dealers.fax, Dealers.mail, Dealers.graphpath FROM Dealers JOIN Country ON Country.id = Dealers.country";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            GridView2.DataSource = reader;
            GridView2.DataBind();
            connection.Close();
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //關閉編輯模式
            //GridView2.EditIndex = -1;
            GridView2.EditIndex = e.NewEditIndex;
            // 獲取所選代理商的ID
            int selectedDealerID = Convert.ToInt32(GridView2.DataKeys[e.NewEditIndex].Value);
           //將id傳到hiddenfield供給其他方法使用
            HiddenFieldDealerID.Value = selectedDealerID.ToString();
            //當按下GridView2的編輯按鈕時，將hdnOperationMode設為"Edit"。
            hdnOperationMode.Value = "Edit";
            hdnSelectedDealerID.Value = selectedDealerID.ToString();
            // 使用ADO.NET連接到數據庫，擷取所選代理商的詳細資訊
            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Dealers WHERE id = @dealerID";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@dealerID", selectedDealerID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        // 獲取詳細資訊
                        string country = reader["country"].ToString();
                        string city = reader["city"].ToString();
                        string name = reader["name"].ToString();
                        string company = reader["company"].ToString();
                        string graphpath = reader["graphpath"].ToString();
                        string address = reader["address"].ToString();
                        string tel = reader["tel"].ToString();
                        string fax = reader["fax"].ToString();
                        string mail = reader["mail"].ToString();
                        string website = reader["website"].ToString();

                        string countryname = GetCountryName(country);
                        // 將資料填充到"Add Dealers"表單的相應控制項中，以展示詳細資訊
                        DropDownList1.SelectedValue = countryname;

                        //string countryId = GetCountryId(country);
                        //將資料填充到"Add Dealers"表單的相應控制項中，以展示詳細資訊
                        //DropDownList1.SelectedValue = countryId;
                        
                        cityTB.Text = city;
                        nameTB.Text = name;
                        companyTB.Text = company;
                        addressTB.Text = address;
                        telTB.Text = tel;
                        faxTB.Text = fax;
                        websiteTB.Text = website;
                        mailTB.Text = mail;
                        graphpathTB.Text = graphpath;
                     
                        // 根據你的需求填充其他控制項

                        // 這將展示詳細資訊，而不是導航到新的頁面
                    }
                }
            }
            //重要!重新綁定資訊並顯示，以免出現編輯模式(可以拿掉體驗看看)
            showDealer();
        }



        private string GetCountryName(string countryName)
        {
            

            // 使用ADO.NET連接到數據庫，查詢 Country 資料表，根據 countryName 獲取對應的國家ID
            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT country FROM Country WHERE country = @countryName";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@countryName", countryName);

                // 執行查詢，獲取國家ID
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    countryName = result.ToString();
                }
            }

            return countryName;
        }



        

        protected void Button2_Click(object sender, EventArgs e)
        {
            string savePath = Server.MapPath("~/Upload/Dealers/");

            if (FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName;
                savePath = savePath + fileName;
                FileUpload1.SaveAs(savePath);
                Label2.Text = " 上傳成功，檔名 ---- " + fileName;

                // 更新到資料庫中
                UpdateGraphPathToDatabase(savePath);
            }
            else
            {
                Label2.Text = " 請先挑選檔案之後，再來上傳 ";
            }
            graphpathTB.Text = savePath;
            showDealer();
        }

        private void UpdateGraphPathToDatabase(string graphPath)
        {
            int dealerID = Convert.ToInt32(HiddenFieldDealerID.Value);
            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "UPDATE Dealers SET graphpath = @graphPath WHERE id = @dealerID";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@graphPath", graphPath);
                command.Parameters.AddWithValue("@dealerID", dealerID);
                command.ExecuteNonQuery();
            }
        }

        //protected string ConvertToRelativePath(string absolutePath)
        //{
        //    if (string.IsNullOrEmpty(absolutePath))
        //        return "";

        //    // Replace the server's absolute path with a relative path. Adjust as needed.
        //    return absolutePath.Replace(Server.MapPath("~/"), "~/").Replace(@"\", "/");
        //}

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

        protected void BtnAddOrUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (hdnOperationMode.Value == "Add")
                {
                    // 執行新增操作
                    string insertSQL = "INSERT INTO Dealers (country, city, name, company, graphpath, address, tel, fax, mail, website) VALUES (@country, @city, @name, @company, @graphpath, @address, @tel, @fax, @mail, @website)";

                    using (SqlCommand cmd = new SqlCommand(insertSQL, connection))
                    {
                        cmd.Parameters.AddWithValue("@country", DropDownList1.SelectedValue);
                        cmd.Parameters.AddWithValue("@city", cityTB.Text);
                        cmd.Parameters.AddWithValue("@name", nameTB.Text);
                        cmd.Parameters.AddWithValue("@company", companyTB.Text);
                        cmd.Parameters.AddWithValue("@graphpath", graphpathTB.Text);
                        cmd.Parameters.AddWithValue("@address", addressTB.Text);
                        cmd.Parameters.AddWithValue("@tel", telTB.Text);
                        cmd.Parameters.AddWithValue("@fax", faxTB.Text);
                        cmd.Parameters.AddWithValue("@mail", mailTB.Text);
                        cmd.Parameters.AddWithValue("@website", websiteTB.Text);
                        cmd.ExecuteNonQuery();
                       
                      
                    }
                }
                else if (hdnOperationMode.Value == "Edit")
                {
                    // 獲取ID
                    int dealerID = Convert.ToInt32(hdnSelectedDealerID.Value);

                    // 執行編輯操作
                    string updateSQL = "UPDATE Dealers SET country = @country, city = @city, name = @name, company = @company, graphpath = @graphpath, address = @address, tel = @tel, fax = @fax, mail = @mail, website = @website WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(updateSQL, connection))
                    {
                        cmd.Parameters.AddWithValue("@country", DropDownList1.SelectedValue);
                        cmd.Parameters.AddWithValue("@city", cityTB.Text);
                        cmd.Parameters.AddWithValue("@name", nameTB.Text);
                        cmd.Parameters.AddWithValue("@company", companyTB.Text);
                        cmd.Parameters.AddWithValue("@graphpath", graphpathTB.Text);
                        cmd.Parameters.AddWithValue("@address", addressTB.Text);
                        cmd.Parameters.AddWithValue("@tel", telTB.Text);
                        cmd.Parameters.AddWithValue("@fax", faxTB.Text);
                        cmd.Parameters.AddWithValue("@mail", mailTB.Text);
                        cmd.Parameters.AddWithValue("@website", websiteTB.Text);
                        cmd.Parameters.AddWithValue("@id", dealerID);

                        cmd.ExecuteNonQuery();
                    }
                }

                connection.Close();
                Response.Redirect("DealersManage.aspx");
            }

            // 重新綁定 GridView 來顯示更新的數據
            showDealer();

            // 重設隱藏字段的值和其他界面元素
            hdnOperationMode.Value = "Add";
            hdnSelectedDealerID.Value = "";
            //ClearAddDealerForm(); // 假設您有一個清空"Add Dealers"表單的方法
        }

        private void ClearAddDealerForm()
        {
            // 清空所有的輸入控制項，例如：
            DropDownList1.SelectedIndex = -1;
            cityTB.Text = "";
            nameTB.Text = "";
            companyTB.Text = "";
            addressTB.Text = "";
            telTB.Text = "";
            faxTB.Text = "";
            websiteTB.Text = "";
            mailTB.Text = "";
            graphpathTB.Text = "";
            // ... 其他需要清空的控制項
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // 獲取要刪除的代理商的ID
            int selectedDealerID = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);

            // 連接到數據庫
            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 構建 SQL 查詢，假設 Dealers 表格中的主鍵是 id
                string deleteSQL = "DELETE FROM Dealers WHERE id = @dealerID";

                // 創建 SqlCommand 對象
                using (SqlCommand cmd = new SqlCommand(deleteSQL, connection))
                {
                    // 添加參數，以便在 SQL 查詢中使用
                    cmd.Parameters.AddWithValue("@dealerID", selectedDealerID);

                    // 執行 SQL 查詢
                    cmd.ExecuteNonQuery();
                }

                // 關閉數據庫連接
                connection.Close();
            }

            // 執行完刪除操作後，您可以重新綁定 GridView 來刷新數據
            showDealer();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Find delete button using CommandName property
                LinkButton deleteButton = e.Row.Cells[0].Controls.OfType<LinkButton>().FirstOrDefault(l => l.CommandName == "Delete");
                
                if (deleteButton != null)
                {
                    // Add JavaScript confirmation box to its OnClientClick property
                    deleteButton.OnClientClick = "return confirm('確定要刪除?');";
                }
            }
        }
    }

    }



