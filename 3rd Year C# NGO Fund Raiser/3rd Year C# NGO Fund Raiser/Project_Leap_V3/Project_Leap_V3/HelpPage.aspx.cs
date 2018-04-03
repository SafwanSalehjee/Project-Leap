using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3
{
    /// <summary>
    /// A help page with useful information
    /// </summary>
    public partial class HelpPage : System.Web.UI.Page
    {
        public static bool onPage;
        public static bool dashPage = false;

        /// <summary>
        /// Makes sure that appropriate pages are accesable from this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                onPage = true;
                if (DashboardPage.onPage)
                {
                    dashPage = true;
                }
                login.onPage = false;
                RegisterPage.onPage = false;
                index.onPage = false;
                DashboardPage.onPage = false;
            }
        }
    }
}