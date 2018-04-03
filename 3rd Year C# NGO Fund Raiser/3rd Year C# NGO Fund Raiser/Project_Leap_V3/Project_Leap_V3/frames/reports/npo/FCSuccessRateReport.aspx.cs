using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.reports.npo
{
    public partial class FCSuccessRateReport : System.Web.UI.Page
    {
        public double successful = 0;
        public double notSuccessful = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

            if (user.AccessLvl == 1)
            {
                successful = service.getFCSuccessRate(service.getNPOWithManager(user.userValue.UserID));
                notSuccessful = 100 - successful;
            }
        }
    }
}