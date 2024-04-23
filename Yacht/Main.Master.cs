using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplyLayout2
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IsLoggedIn"] != null && (bool)Session["IsLoggedIn"])
                {
                    usernameSpan.InnerText = Session["uname"].ToString();
                    if (Session["Permission"].ToString() == "1")
                    {
                        liCompanyManage.Visible = true;
                        liDealersCountry.Visible = true;
                        liDealersCreate.Visible = true;
                        liDealersManage.Visible = true;
                        liNewsCreate.Visible = true;
                        liNewsManage.Visible = true;
                        liYachtsCreate.Visible = true;
                        liYachtsManage.Visible = true;
                        manageItem.Visible = true;
                       

                    }
                    else
                    {
                        liCompanyManage.Visible = false;
                        liDealersCountry.Visible = false;
                        liDealersCreate.Visible = false;
                        liDealersManage.Visible = false;
                        liNewsCreate.Visible = false;
                        liNewsManage.Visible = false;
                        liYachtsCreate.Visible = false;
                        liYachtsManage.Visible = false;
                        manageItem.Visible = false;
                    }
                }
                else
                {
                    liCompanyManage.Visible = false;
                    liDealersCountry.Visible = false;
                    liDealersCreate.Visible = false;
                    liDealersManage.Visible = false;
                    liNewsCreate.Visible = false;
                    liNewsManage.Visible = false;
                    liYachtsCreate.Visible = false;
                    liYachtsManage.Visible = false;
                    manageItem.Visible = false;
                }
            }

           
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (Session["IsLoggedIn"] != null && (bool)Session["IsLoggedIn"] && Session["Permission"]!=null)
            {
                Session.Remove("IsLoggedIn");
                Session.Remove("Permission");
            }
            Response.Redirect("Login.aspx");
        }


    }
}