using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.summary_pages
{
    public partial class SummaryPageBus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

            if (user.AccessLvl == 3)
            {
                totalDons.InnerText = "R " + service.TotalDonated(user.userValue.UserID);
                ServiceReference1.mobileEve eve = service.getNextNPOEvent(user.userValue.UserID);
                if (eve == null)
                {
                    nextEvent.InnerText = "No upcoming events which you are attending";
                }
                else
                {
                    nextEvent.InnerText = eve.Name + " on the " + eve.Date + " at " + eve.Location;
                }
            }
        }
    }
}