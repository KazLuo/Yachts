using CKFinder;
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
    public partial class YachtsCreate : System.Web.UI.Page
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
                FileBrowser fileBrowser = new FileBrowser();
                fileBrowser.BasePath = "/ckfinder";
                fileBrowser.SetupCKEditor(CKEditorControl1);
                string YachtsIDstr = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(YachtsIDstr))
                {
                    LoadYachtsData(YachtsIDstr);
                    litHeader.Text = "Yachts Edit";
                    Button3.Text = "Edit";


                }
                else
                {
                    litHeader.Text = "Yachts Create";
                    Button3.Text = "Create";
                }
            }
        }

        private void LoadYachtsData(string id)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               
                string sql = "SELECT Yachts.*, yachtsLayout.layout1, yachtsLayout.layout2 FROM Yachts LEFT JOIN yachtsLayout ON Yachts.id = yachtsLayout.yachtsID WHERE Yachts.id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    if (reader["top"] != DBNull.Value)
                    {
                        isTopTB.Checked = Convert.ToBoolean(reader["top"]);
                    }
                    else
                    {
                        isTopTB.Checked = false; // 或任何你想賦予的默認值
                    }
                    if (reader["newBuild"] != DBNull.Value)
                    {
                        isNewBuildTB.Checked = Convert.ToBoolean(reader["newBuild"]);
                    }
                    else
                    {
                        isNewBuildTB.Checked = false; // 或任何你想賦予的默認值
                    }
                    if (reader["newDesign"] != DBNull.Value)
                    {
                        isNewDesignTB.Checked = Convert.ToBoolean(reader["newDesign"]);
                    }
                    else
                    {
                        isNewDesignTB.Checked = false; // 或任何你想賦予的默認值
                    }
                    modelTB.Text = reader["model"].ToString();
                    typeTB.Text = reader["type"].ToString();
                    CKEditorControl1.Text = reader["overview"].ToString();
                    CKEditorControl2.Text = reader["dimensions"].ToString();
                    CKEditorControl3.Text = reader["spec"].ToString();
                    layouttopTB.Text = reader["layout1"].ToString();
                    layoutbottomTB.Text = reader["layout2"].ToString();
                    bannerpathTB.Text = reader["bannerImgPath"].ToString();

                }
                connection.Close();
            }
            string newsIDstr = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(newsIDstr))
            {
                BtnDelete.Visible = true;
            }
            else
            {

            }
        }


        protected void layouttop_Click(object sender, EventArgs e)
        {
            string savePath = Server.MapPath("~/Upload/");

            if (FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName;
                savePath = savePath + fileName;
                FileUpload1.SaveAs(savePath);
                Label2.Text = " 上傳成功，檔名 ---- " + fileName;

                // 更新到資料庫中

            }
            else
            {
                Label2.Text = " 請先挑選檔案之後，再來上傳 ";
            }
            layouttopTB.Text = savePath;
        }

        protected void layoutbottom_Click(object sender, EventArgs e)
        {
            string savePath = Server.MapPath("~/Upload/");

            if (FileUpload2.HasFile)
            {
                string fileName = FileUpload2.FileName;
                savePath = savePath + fileName;
                FileUpload2.SaveAs(savePath);
                Label2.Text = " 上傳成功，檔名 ---- " + fileName;

                // 更新到資料庫中

            }
            else
            {
                Label2.Text = " 請先挑選檔案之後，再來上傳 ";
            }
            layoutbottomTB.Text = savePath;
        }




        protected void BtnAddOrUpdate_Click(object sender, EventArgs e)
        {
            string YachtsIDstr = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(YachtsIDstr))
            {
                UpdateYachts(YachtsIDstr);  // 如果有ID，則進行更新操作
                Response.Redirect("YachtsManage.aspx");
            }
            else
            {
                InsertYachts();  // 否則執行新增操作
                Response.Redirect("YachtsManage.aspx");
            }
        }


        private void UpdateYachts(string id)
        {
            bool isTop = isTopTB.Checked;
            bool isNewBuild = isNewBuildTB.Checked;
            bool isNewDesign = isNewDesignTB.Checked;
            string model = modelTB.Text;
            string type = typeTB.Text;
            string overviewContenttent = CKEditorControl1.Text;
            string dimensions = CKEditorControl2.Text;
            string spec = CKEditorControl3.Text;
            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlUpdate = "UPDATE Yachts SET [top] = @IsTop, newBuild = @IsNewBuild, newDesign = @IsNewDesign, model = @model,spec = @spec, type = @type, overview = @overviewCont, dimensions =@dimensions, bannerImgPath=@bannerImgPath  WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(sqlUpdate, connection))
                {
                    cmd.Parameters.AddWithValue("@IsTop", isTop);
                    cmd.Parameters.AddWithValue("@IsNewBuild", isNewBuild);
                    cmd.Parameters.AddWithValue("@IsNewDesign", isNewDesign);
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@overviewCont", overviewContenttent);
                    cmd.Parameters.AddWithValue("@dimensions", dimensions);
                    cmd.Parameters.AddWithValue("@spec", spec);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@bannerImgPath", bannerpathTB.Text);
                    cmd.ExecuteNonQuery();
                }

                // 檢查是否已經有layout資料
                string sqlCheckLayout = "SELECT COUNT(*) FROM yachtsLayout WHERE yachtsID = @id";
                int existingLayoutCount = 0;
                using (SqlCommand cmdLayoutCheck = new SqlCommand(sqlCheckLayout, connection))
                {
                    cmdLayoutCheck.Parameters.AddWithValue("@id", id);
                    existingLayoutCount = (int)cmdLayoutCheck.ExecuteScalar();
                }

                if (existingLayoutCount > 0)
                {
                    // 更新路徑
                    string sqlUpdateLayout = "UPDATE yachtsLayout SET layout1 = @LayoutTopPath, layout2 = @LayoutBottomPath WHERE yachtsID = @id";
                    using (SqlCommand cmdLayout = new SqlCommand(sqlUpdateLayout, connection))
                    {
                        cmdLayout.Parameters.AddWithValue("@LayoutTopPath", layouttopTB.Text);
                        cmdLayout.Parameters.AddWithValue("@LayoutBottomPath", layoutbottomTB.Text);
                        cmdLayout.Parameters.AddWithValue("@id", id);
                        cmdLayout.ExecuteNonQuery();
                    }
                }
                else
                {
                    // 插入路徑
                    string sqlInsertLayout = "INSERT INTO yachtsLayout (yachtsID, layout1, layout2) VALUES (@id, @LayoutTopPath, @LayoutBottomPath)";
                    using (SqlCommand cmdLayoutInsert = new SqlCommand(sqlInsertLayout, connection))
                    {
                        cmdLayoutInsert.Parameters.AddWithValue("@LayoutTopPath", layouttopTB.Text);
                        cmdLayoutInsert.Parameters.AddWithValue("@LayoutBottomPath", layoutbottomTB.Text);
                        cmdLayoutInsert.Parameters.AddWithValue("@id", id);
                        cmdLayoutInsert.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }




        private void InsertYachts()
        {
            bool isTop = isTopTB.Checked;
            bool isNewBuild = isNewDesignTB.Checked;
            bool isNewDesign = isNewDesignTB.Checked;
            string model = modelTB.Text;
            string type = typeTB.Text;
            string overviewContenttent = CKEditorControl1.Text;
            string dimensions = CKEditorControl2.Text;
            string spec = CKEditorControl3.Text;

            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the model and type combination already exists
                string sqlCheck = "SELECT COUNT(*) FROM Yachts WHERE model = @model AND type = @type ";
                using (SqlCommand cmd = new SqlCommand(sqlCheck, connection))
                {
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@type", type);

                    int existingCount = (int)cmd.ExecuteScalar();
                    if (existingCount > 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "DuplicateError", "alert('The model and type combination already exists.');", true);
                        return;
                    }
                }
                //OUTPUT INSERTED.ID是SQL Server的功能，用於獲取被插入記錄的ID
                string sqlInsert = "INSERT INTO Yachts (model,type,overview,dimensions,newBuild,newDesign,[top],spec,bannerImgPath) OUTPUT INSERTED.ID VALUES (@model,@type,@overviewCont,@dimensions,@IsNewBuild,@IsNewDesign,@IsTop,@spec,@bannerImgPath)";
                using (SqlCommand cmd = new SqlCommand(sqlInsert, connection))
                {
                    cmd.Parameters.AddWithValue("@IsTop", isTop);
                    cmd.Parameters.AddWithValue("@IsNewBuild", isNewBuild);
                    cmd.Parameters.AddWithValue("@IsNewDesign", isNewDesign);
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@overviewCont", overviewContenttent);
                    cmd.Parameters.AddWithValue("@dimensions", dimensions);
                    cmd.Parameters.AddWithValue("@spec", spec);
                    cmd.Parameters.AddWithValue("@bannerImgPath", bannerpathTB.Text);
                    //獲取第一段sql新增指令後的的ID,cmd.ExecuteScalar() 是ADO.NET中的一個方法，用於執行查詢並返回查詢的第一行第一列的值。
                    int newYachtID = Convert.ToInt32(cmd.ExecuteScalar());

                    string sqlInsertLayout = "INSERT INTO yachtsLayout (yachtsID, layout1, layout2) VALUES (@YachtID, @LayoutTopPath, @LayoutBottomPath)";
                    using (SqlCommand cmdLayout = new SqlCommand(sqlInsertLayout, connection))
                    {
                        cmdLayout.Parameters.AddWithValue("@YachtID", newYachtID);
                        cmdLayout.Parameters.AddWithValue("@LayoutTopPath", layouttopTB.Text);
                        cmdLayout.Parameters.AddWithValue("@LayoutBottomPath", layoutbottomTB.Text);
                        cmdLayout.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }



        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string YatchsIDstr = Request.QueryString["id"];  //假設你的URL有包含id作為querystring

            if (string.IsNullOrEmpty(YatchsIDstr))
            {
                Response.Write("ID錯誤");
                return;
            }

            string connectionString = WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlDelete = "DELETE FROM Yachts WHERE id = @YatchsIDstr";
                    SqlCommand command = new SqlCommand(sqlDelete, connection);
                    command.Parameters.AddWithValue("@YatchsIDstr", YatchsIDstr);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        Response.Write("成功刪除");
                        Response.Redirect("YachtsManage.aspx");
                    }
                    else
                    {
                        Response.Write("刪除失敗");
                    }
                }
            }
            catch (SqlException ex)
            {
                Response.Write("資料庫操作異常: " + ex.Message);
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("YachtsManage.aspx");
        }

        protected void UploadBanner_Click(object sender, EventArgs e)
        {
            string savePath = Server.MapPath("~/Upload/");

            if (FileUpload3.HasFile)
            {
                string fileName = FileUpload3.FileName;
                savePath = savePath + fileName;
                FileUpload3.SaveAs(savePath);
                bannerpathTB.Text = "Upload/" + fileName;  //更新textbox的值來顯示上傳的路徑。
            }
            else
            {
                // 您可以在這裡添加一個Label來顯示錯誤訊息或簡單地使用Response.Write。
                Response.Write("請先挑選檔案之後，再來上傳");
            }
        }
    }
}