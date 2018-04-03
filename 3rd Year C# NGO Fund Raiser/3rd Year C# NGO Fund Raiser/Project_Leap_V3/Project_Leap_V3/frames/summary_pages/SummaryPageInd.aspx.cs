using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.summary_pages
{
    public partial class SummaryPageInd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

            if (user.AccessLvl == 5)
            {
                totalDons.InnerText = "R " + service.TotalDonated(user.userValue.UserID);
                ServiceReference1.EventVolunteer vol = service.getNextVolunteer(user.userValue.UserID);
                if (vol == null)
                {
                    nextEvent.InnerText = "No upcoming volunteering";
                }
                else
                {
                    nextEvent.InnerText = vol.OrnName + " on the " + vol.ShortDate;
                }

                numOfBadges.InnerText = "" + service.getNumOfBadgesEarned(user.userValue.UserID);
            }
        }
    }
}