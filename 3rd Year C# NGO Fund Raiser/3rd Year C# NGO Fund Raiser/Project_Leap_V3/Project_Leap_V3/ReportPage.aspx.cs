using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3
{
    /// <summary>
    /// This class handles the display of the Reports
    /// </summary>
    public partial class ReportPage : System.Web.UI.Page
    {
        public static bool onPage;
        protected void Page_Load(object sender, EventArgs e)
        {
            onPage = true;
            login.onPage = false;
            RegisterPage.onPage = false;
            HelpPage.onPage = false;
            DashboardPage.onPage = false;
            index.onPage = false;
        }
    }
}