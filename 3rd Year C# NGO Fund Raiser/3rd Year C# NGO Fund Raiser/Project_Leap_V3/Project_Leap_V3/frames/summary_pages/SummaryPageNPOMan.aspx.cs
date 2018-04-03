using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.summary_pages
{
    public partial class SummaryPageNPOMan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

            if (user.AccessLvl == 1)
            {
                totalDons.InnerText = "R " + service.TotalRecievedFromDonations(service.getNPOWithManager(user.userValue.UserID));
                ServiceReference1.mobileEve eve = service.GetNextEvent((service.getNPOWithManager(user.userValue.UserID)));
                if (eve == null)
                {
                    nextEvent.InnerText = "No upcoming events";
                }
                else
                {
                    nextEvent.InnerText = eve.Name + " on the " + eve.Date;
                }

                ServiceReference1.mobileFC fc = service.GetTotalFCProgress(((service.getNPOWithManager(user.userValue.UserID))));
                FCProgress.InnerText = "R " + fc.Current + " / R" + fc.Target;
            }
        }
    }
}