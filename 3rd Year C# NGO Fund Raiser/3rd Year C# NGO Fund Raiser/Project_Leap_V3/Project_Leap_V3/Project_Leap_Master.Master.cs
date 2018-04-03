using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Project_Leap_V3
{
    public partial class Project_Leap_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            menu_statistics.Visible = false;
            menu_dashboard.Visible = false;
            menu_home.Visible = false;
            menu_login.Visible = false;
            menu_register.Visible = false;
            menu_user_list.Visible = false;
            menu_login.Attributes.Remove("class");
            menu_home.Attributes.Remove("class");
            menu_register.Attributes.Remove("class");
            menu_faq.Attributes.Remove("class");
            menu_dashboard.Attributes.Remove("class");

            if (index.onPage)
            {
                menu_home.Attributes.Add("class", "current");
                
                menu_statistics.Visible = true;
            }
            if (login.onPage)
            {
                menu_login.Attributes.Add("class", "current");
            }
            if (RegisterPage.onPage)
            {
                menu_register.Attributes.Add("class", "current");
            }
            if (HelpPage.onPage)
            {
                menu_faq.Attributes.Add("class", "current");
            }
            if (DashboardPage.onPage)
            {
                menu_dashboard.Attributes.Add("class", "current");
            }
            if (UserListPage.onPage)
            {
                menu_user_list.Attributes.Add("class", "current");
            }
            if (ReportPage.onPage)
            {

            }
            if (HttpContext.Current.Session["User_lvl"] != null)
            {
                logo.HRef = "DashboardPage.aspx";
                menu_dashboard.Visible = true;
                menu_user_list.Visible = true;
                userPic.Visible = true;

                ServiceReference1.UserDetail u = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                viewProfile.HRef = "UserPage.aspx?userId=" + u.userValue.UserID;

                if (HttpContext.Current.Session["User_FistName"] == null)
                {
                    userNameP.InnerHtml = "Guest";
                }
                else
                {
                    userNameP.InnerHtml = (String)HttpContext.Current.Session["User_FistName"];
                }
            }
            else
            {
                logo.HRef = "HomePage.aspx";

                menu_home.Visible = true;
                menu_login.Visible = true;
                menu_register.Visible = true;
                userPic.Visible = false;
            }

            try
            {
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                ServiceReference1.FileClass file = serv.getUserImage(user.userValue.UserID);
                MemoryStream ms = new MemoryStream(file.FileBytes, 0, file.FileBytes.Length);
                imgPP.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(file.FileBytes);
            }
            catch (Exception ex)
            {
                imgPP.ImageUrl = "images/avatar1.png";
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.RemoveAll();
            Response.Redirect("LoginPage.aspx");
        }
    }
}