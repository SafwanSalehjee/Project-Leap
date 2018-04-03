using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3
{
    /// <summary>
    /// Login page
    /// </summary>
    public partial class login : System.Web.UI.Page
    {
        public static bool onPage;
        private ServiceReference1.Service1Client serv;

        /// <summary>
        /// Makes sure that appropriate pages are accesable from this page. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                onPage = true;
                index.onPage = false;
                RegisterPage.onPage = false;
                HelpPage.onPage = false;
                DashboardPage.onPage = false;
            }
        }

        /// <summary>
        /// Login Functionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            serv = new ServiceReference1.Service1Client();

            var i = serv.CheckDetails(txtUsername.Text, Security.Encrypt(txtPassword.Text));
            if (i.AccessLvl > -1)
            {
                HttpContext.Current.Session["User_lvl"] = i.AccessLvl;
                HttpContext.Current.Session["User_FistName"] = i.FirstNameValue;
                HttpContext.Current.Session["User"] = i;
                HttpContext.Current.Session.Timeout = 120;
                Response.Redirect("DashboardPage.aspx");
            }
            else
            {
                lblLoginFailed.Visible = true;
                lblLoginFailed.Text = i.FirstNameValue;
            }
        }

    }
}