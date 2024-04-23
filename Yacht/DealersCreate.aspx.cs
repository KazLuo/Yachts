using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace Yacht
{
    public partial class DealersCreate : System.Web.UI.Page
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            string savePath = Server.MapPath("~/Upload/Dealers/");

            if (FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName;
                savePath += fileName;
                FileUpload1.SaveAs(savePath);
                Label2.Text = "上傳成功，檔名 ---- " + fileName;
                graphpathTB.Text = savePath;
            }
            else
            {
                Label2.Text = "請先挑選檔案之後，再來上傳";
            }
        }

        protected string ConvertToRelativePath(string absolutePath)
        {
            if (string.IsNullOrEmpty(absolutePath))
                return "";

            if (absolutePath.StartsWith("~/"))
            {
                return absolutePath;
            }
            else
            {
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

                connection.Close();
                Response.Redirect("DealersManage.aspx");
            }
        }

        private void ClearAddDealerForm()
        {
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
        }
    }
}
