using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MailKit.Net.Smtp;
using MimeKit;

namespace Yacht
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (String.IsNullOrEmpty(RecaptchaWidget1.Response))
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Captcha cannot be empty.";
            }
            else
            {
                var result = RecaptchaWidget1.Verify();
                if (result.Success)
                {
                    //驗證成功則寄出信件並送出警告提醒
                    sendGmail();
                    Response.Write("<script>alert('Thank you for contacting us!');location.href='Contect.aspx';</script>");
                }
                else
                {
                    lblMessage.Text = "Error(s): ";

                    foreach (var err in result.ErrorCodes)
                    {
                        lblMessage.Text = lblMessage.Text + err;
                    }
                }
            }
        }

        public void sendGmail()
        {
            //宣告使用 MimeMessage
            var message = new MimeMessage();
            //設定發信地址 ("發信人", "發信 email")
            message.From.Add(new MailboxAddress("TayanaYacht", "XXXXXXX@gmail.com"));
            //設定收信地址 ("收信人", "收信 email")
            message.To.Add(new MailboxAddress(Name.Text.Trim(), Email.Text.Trim()));
            //寄件副本email
            message.Cc.Add(new MailboxAddress("收信人名稱", "XXXXXXX@gmail.com"));
            //設定優先權
            //message.Priority = MessagePriority.Normal;
            //信件標題
            message.Subject = "TayanaYacht Auto Email";
            //建立 html 郵件格式
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody =
                "<h1>Thank you for contacting us!</h1>" +
                $"<h3>Name : {Name.Text.Trim()}</h3>" +
                $"<h3>Email : {Email.Text.Trim()}</h3>" +
                $"<h3>Phone : {Phone.Text.Trim()}</h3>" +
                $"<h3>Country : {Country.SelectedValue}</h3>" +
                $"<h3>Type : {Yachts.SelectedValue}</h3>" +
                $"<h3>Comments : </h3>" +
                $"<p>{Comments.Text.Trim()}</p>";
            //設定郵件內容
            message.Body = bodyBuilder.ToMessageBody(); //轉成郵件內容格式

            using (var client = new SmtpClient())
            {
                //有開防毒時需設定 false 關閉檢查
                client.CheckCertificateRevocation = false;
                //設定連線 gmail ("smtp Server", Port, SSL加密) 
                client.Connect("smtp.gmail.com", 587, false); // localhost 測試使用加密需先關閉
                //設定帳號密碼在 Web.config 中並使用 ConfigurationManager.AppSettings["Email"]
                //取得帳號密碼
                string email = ConfigurationManager.AppSettings["Email"];
                string password = ConfigurationManager.AppSettings["Password"];
                client.Authenticate(email, password);
                // Note: only needed if the SMTP server requires authentication
                //發信
                client.Send(message);
                //結束連線
                client.Disconnect(true);
            }
        }
    }
}