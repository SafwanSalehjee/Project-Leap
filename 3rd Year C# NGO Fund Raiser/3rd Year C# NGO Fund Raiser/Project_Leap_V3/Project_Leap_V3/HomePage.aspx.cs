using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3
{
    /// <summary>
    /// Home page which advertises the system to new visitors.
    /// </summary>
    public partial class index : System.Web.UI.Page
    {
        public static bool onPage;

        /// <summary>
        /// makes sure that it is only accessable when no one is logged in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                onPage = true;
                login.onPage = false;
                RegisterPage.onPage = false;
                HelpPage.onPage = false;
                DashboardPage.onPage = false;

                if (HttpContext.Current.Session["User_lvl"] != null)
                {
                    Response.Redirect("DashboardPage.aspx");
                }
            }
        }
    }
}