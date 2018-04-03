using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// This class handles the retrieval and display of all events.
    /// </summary>
    public partial class ViewEvents : System.Web.UI.Page
    {
        private static int pageCount = 1;
        private int numOfEves = 0;
        private static string searchStr = "";

        private static int pageCountOld = 1;
        private int numOfEvesOld = 0;
        private static string searchStrOld = "";

        /// <summary>
        /// This method is called and executed when the page is loaded.
        /// A list of all events are retrieved and displayed when the page is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            NPOPastEvents.Visible = false;
            ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
            ServiceReference1.Eve[] events = null;
            ServiceReference1.UserDetail u = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

            if ((int)HttpContext.Current.Session["User_lvl"] == 1)
            {
                NPOPastEvents.Visible = true;
                events = serv.getNEvents(serv.getNPOWithManager(u.userValue.UserID));
            }
            else if ((int)HttpContext.Current.Session["User_lvl"] == 3)
            {
                events = serv.getEvents(u.userValue.UserID);
            }

            divEventsTable.InnerHtml = "";
            divEventsTable.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'>";
            divEventsTable.InnerHtml += "<tr style='width: 100%; border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th style='text-align: left; margin-right: 10px'>Name</th><th style='text-align: left; margin-right: 10px'>Venue</th><th style='text-align: left; margin-right: 10px'>Date</th><th style='text-align: left; margin-right: 10px'>Time</th></tr>";

            divEventsTableOld.InnerHtml = "";
            divEventsTableOld.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'>";
            divEventsTableOld.InnerHtml += "<tr style='width: 100%; border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th style='text-align: left; margin-right: 10px'>Name</th><th style='text-align: left; margin-right: 10px'>Venue</th><th style='text-align: left; margin-right: 10px'>Date</th><th style='text-align: left; margin-right: 10px'>Time</th></tr>";

            numOfEvesOld = 0;
            numOfEves = 0;

            foreach (ServiceReference1.Eve ev in events)
            {
                if (Convert.ToDateTime(ev.EventValue.DateOfEvent) < DateTime.Today)
                    numOfEvesOld++;
                else
                    numOfEves++;
            }

            ServiceReference1.Eve[] eventsNew = new ServiceReference1.Eve[numOfEves];
            ServiceReference1.Eve[] eventsOld = new ServiceReference1.Eve[numOfEvesOld];
            int oldCount = 0;
            int newCount = 0;

            foreach (ServiceReference1.Eve ev in events)
            {
                if (Convert.ToDateTime(ev.EventValue.DateOfEvent) < DateTime.Today)
                {
                    eventsOld[oldCount] = ev;
                    oldCount++;
                }
                else
                {
                    eventsNew[newCount] = ev;
                    newCount++;
                }
            }

            for (int a = (pageCount - 1) * 8; a < pageCount * 8; a++)
            {
                if (a >= numOfEves)
                {
                    break;
                }

                if (searchStr.Equals(""))
                {
                    divEventsTable.InnerHtml += "<tr><td><a href ='EventDetails.aspx?id=" + eventsNew[a].EventValue.EventID + "'>" + eventsNew[a].EventValue.Name + "</a></td><td>" + eventsNew[a].EventValue.Location + "</td><td>" + Convert.ToDateTime(eventsNew[a].EventValue.DateOfEvent).ToShortDateString() + "</td><td>" + eventsNew[a].Time + "</td></tr>";
                }
                else
                {
                    int numOfEvesAdded = 0;
                    for (int b = 0; b < numOfEves; b++)
                    {
                        if (numOfEvesAdded > 7)
                        {
                            break;
                        }
                        if (eventsNew[b].EventValue.Name.Contains(searchStr))
                        {
                            divEventsTable.InnerHtml += "<tr><td><a href ='EventDetails.aspx?id=" + eventsNew[b].EventValue.EventID + "'>" + eventsNew[b].EventValue.Name + "</a></td><td>" + eventsNew[b].EventValue.Location + "</td><td>" + Convert.ToDateTime(eventsNew[b].EventValue.DateOfEvent).ToShortDateString() + "</td><td>" + eventsNew[a].Time + "</td></tr>";
                            numOfEvesAdded++;
                        }
                    }

                    searchStr = "";
                    txtSearch.Text = "";
                    break;
                }
            }

            divEventsTable.InnerHtml += "</table>";

            for (int a = (pageCountOld - 1) * 8; a < pageCountOld * 8; a++)
            {
                if (a >= numOfEvesOld)
                {
                    break;
                }

                if (searchStrOld.Equals(""))
                {
                    divEventsTableOld.InnerHtml += "<tr><td><a href ='EventDetails.aspx?id=" + eventsOld[a].EventValue.EventID + "'>" + eventsOld[a].EventValue.Name + "</a></td><td>" + eventsOld[a].EventValue.Location + "</td><td>" + Convert.ToDateTime(eventsOld[a].EventValue.DateOfEvent).ToShortDateString() + "</td><td>" + eventsOld[a].Time + "</td></tr>";
                }
                else
                {
                    int numOfEvesAdded = 0;
                    for (int b = 0; b < numOfEvesOld; b++)
                    {
                        if (numOfEvesAdded > 7)
                        {
                            break;
                        }
                        if (eventsOld[b].EventValue.Name.Contains(searchStrOld))
                        {
                            divEventsTableOld.InnerHtml += "<tr><td><a href ='EventDetails.aspx?id=" + eventsOld[b].EventValue.EventID + "'>" + eventsOld[b].EventValue.Name + "</a></td><td>" + eventsOld[b].EventValue.Location + "</td><td>" + Convert.ToDateTime(eventsOld[b].EventValue.DateOfEvent).ToShortDateString() + "</td><td>" + eventsOld[a].Time + "</td></tr>";
                            numOfEvesAdded++;
                        }
                    }

                    searchStrOld = "";
                    txtSearchOld.Text = "";
                    break;
                }
            }

            divEventsTableOld.InnerHtml += "</table>";
        }

        protected void btnPrevs_Click(object sender, EventArgs e)
        {
            if (pageCount > 1)
            {
                pageCount--;
                Page_Load(sender, e);
            }
        }

        protected void btnNexts_Click(object sender, EventArgs e)
        {
            if (pageCount * 8 < numOfEves)
            {
                pageCount++;
                Page_Load(sender, e);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            searchStr = txtSearch.Text;
            Page_Load(sender, e);
        }

        protected void btnPrevsOld_Click(object sender, EventArgs e)
        {
            if (pageCountOld > 1)
            {
                pageCountOld--;
                Page_Load(sender, e);
            }
        }

        protected void btnNextsOld_Click(object sender, EventArgs e)
        {
            if (pageCountOld * 8 < numOfEvesOld)
            {
                pageCountOld++;
                Page_Load(sender, e);
            }
        }

        protected void btnSearchOld_Click(object sender, EventArgs e)
        {
            searchStrOld = txtSearchOld.Text;
            Page_Load(sender, e);
        }
    }
}