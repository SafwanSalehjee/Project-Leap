using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// Display the History of RSVPs the current user has done.
    /// </summary>
    public partial class UserRSVPList : System.Web.UI.Page
    {
        /// <summary>
        /// Displays the list of rsvp done by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 1)
            {
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                ServiceReference1.RSVPEvent[] Events;


                ServiceReference1.UserDetail u = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

                Events = serv.getEventUser(u.userValue.UserID);

                HeaderDiv.InnerHtml = "<h2>" + u.userValue.FirstName + "'s RSVP list:</h2>";

                TableList.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'><tr><td>Organisation: </td><td>Event: </td><td>Date: </td><td>Status: </td></tr>";
                int orgID;
                foreach (ServiceReference1.RSVPEvent eve in Events)
                {
                    var ev = serv.getEvent(eve.EventID);
                    orgID = ev.EventValue.OrganisationID;
                    TableList.InnerHtml += "<tr><td>" + serv.getOrg(orgID).OrganisationName + "</td><td>" + ev.EventValue.Name + "</td><td>" + Convert.ToDateTime(ev.EventValue.DateOfEvent).ToShortDateString() + "</td><td>" + eve.Attendance + "</td></tr>";
                }
                TableList.InnerHtml += "</table>";
            }
        }
    }
}