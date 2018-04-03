using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// A page will display the details of the Event selected in ViewEvents
    /// </summary>
    public partial class EventDetails : System.Web.UI.Page
    {
        /// <summary>
        /// reading EventId from the URL paramter and displays the details of that Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 1 || (int)HttpContext.Current.Session["User_lvl"] == 3)
            {
                tblRSVP.Visible = false;
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                ServiceReference1.RSVPEvent rsvp = new ServiceReference1.RSVPEvent();
                ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                int EventID = int.Parse(Request.QueryString["id"].ToString());
                rsvp.EventID = EventID;
                rsvp.User = user.userValue.UserID;

                ServiceReference1.Eve Event = serv.getEvent(EventID);

                string NPOman = "";

                if (user.AccessLvl == 1)
                {
                    divEventsDetailsTable.InnerHtml = "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'><tr><td><h1>Name :</h1></td><td>" + Event.EventValue.Name + "</td></tr><tr><td><h2>Organisation :</h2></td><td>" + serv.getOrg(Event.EventValue.OrganisationID).OrganisationName +
                                                         "</td></tr><tr><td><h2>Location :</h2></td><td>" + Event.EventValue.Location + "</td></tr><tr><td><h2>Date :</h2></td><td>" + Event.EventValue.DateOfEvent + "</td></tr><tr><td><h2>Host :</h2></td><td>" + Event.EventValue.Host + "</td></tr><tr><td><h2>Description :</h2></td><td>" + Event.EventValue.Description + "</td></tr><tr><td><a href='npoRSVPlist.aspx?OrgID=" + serv.getNPOWithManager(rsvp.User) + "&EventID=" + EventID + "'>View All RSVP</a></td></tr></table>";
                }
                else
                {
                    divEventsDetailsTable.InnerHtml = "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'><tr><td><h1>Name :</h1></td><td>" + Event.EventValue.Name + "</td></tr><tr><td><h2>Organisation :</h2></td><td>" + serv.getOrg(Event.EventValue.OrganisationID).OrganisationName +
                                                           "</td></tr><tr><td><h2>Location :</h2></td><td>" + Event.EventValue.Location + "</td></tr><tr><td><h2>Date :</h2></td><td>" + Event.EventValue.DateOfEvent + "</td></tr><tr><td><h2>Host :</h2></td><td>" + Event.EventValue.Host + "</td></tr><tr><td><h2>Description :</h2></td><td>" + Event.EventValue.Description + "</td></tr></table>";
                }

                if (user.AccessLvl == 3)
                {
                    tblRSVP.Visible = true;
                }

                //Upon selecting an radio button 
                if (RBLrsvp.SelectedValue.Equals("1"))
                {
                    rsvp.Attendance = "Yes";
                    serv.setRSVP(rsvp);
                    lblRSVP.Text = "Thank you.";
                    RBLrsvp.Visible = false;

                }
                else if (RBLrsvp.SelectedValue.Equals("2"))
                {
                    rsvp.Attendance = "Maybe";
                    serv.setRSVP(rsvp);
                    lblRSVP.Text = "Thank you.";
                    RBLrsvp.Visible = false;
                }
                else if (RBLrsvp.SelectedValue.Equals("0"))
                {
                    rsvp.Attendance = "No";
                    serv.setRSVP(rsvp);
                    lblRSVP.Text = "Next time..";
                    RBLrsvp.Visible = false;
                }
            }

        }


    }
}