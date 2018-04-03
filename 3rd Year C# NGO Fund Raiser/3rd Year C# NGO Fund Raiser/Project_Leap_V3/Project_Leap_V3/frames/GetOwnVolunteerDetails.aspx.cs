using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// This method is called and executed when the page is loaded.
    /// A list of all the events that the volunteer volunteered for are retrieved and displayed when the page is loaded.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public partial class GetOwnVolunteerDetails : System.Web.UI.Page
    {
        private static int pageCount = 1;
        private int numOfVols = 0;
        private static string searchStr = "";

        private static int pageCountNew = 1;
        private int numOfVolsNew = 0;
        private static string searchStrNew = "";

        public string donationCSV;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 5)
            {
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();

                ServiceReference1.UserDetail u = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

                ServiceReference1.EventVolunteer[] volunteers = serv.getVolunteerUser(u.userValue.UserID);

                divVolunteeredTable.InnerHtml = "";
                divVolunteeredTable.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'>";
                divVolunteeredTable.InnerHtml += "<tr style='width: 100%; border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th style='text-align: left; margin-right: 10px'>Volunteer Date</th><th style='text-align: left; margin-right: 10px'>NPO Name</th><th style='text-align: left; margin-right: 10px'>Hours</th><th style='text-align: left; margin-right: 10px'>Comment</th></tr>";

                divVolunteeredTableNew.InnerHtml = "";
                divVolunteeredTableNew.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'>";
                divVolunteeredTableNew.InnerHtml += "<tr style='width: 100%; border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th style='text-align: left; margin-right: 10px'>Volunteer Date</th><th style='text-align: left; margin-right: 10px'>NPO Name</th><th style='text-align: left; margin-right: 10px'>Hours</th><th style='text-align: left; margin-right: 10px'>Comment</th></tr>";

                numOfVolsNew = 0;
                numOfVols = 0;

                foreach(ServiceReference1.EventVolunteer vol in volunteers)
                {
                    if (vol.VolDate >= DateTime.Today)
                        numOfVolsNew++;
                    else
                        numOfVols++;
                }

                ServiceReference1.EventVolunteer[] newVols = new ServiceReference1.EventVolunteer[numOfVolsNew];
                ServiceReference1.EventVolunteer[] oldVols = new ServiceReference1.EventVolunteer[numOfVols];

                int oldCount = 0;
                int newCount = 0;

                foreach (ServiceReference1.EventVolunteer vols in volunteers)
                {
                    if (vols.VolDate >= DateTime.Today)
                    {
                        newVols[newCount] = vols;
                        newCount++;
                    }
                    else
                    {
                        oldVols[oldCount] = vols;
                        oldCount++;
                    }
                }

                for (int a = 0; a < volunteers.Count(); a++)
                {
                    donationCSV += volunteers[a].VolDate.ToShortDateString() + "," + volunteers[a].OrnName + "," + volunteers[a].Hours + "\n";
                }

                for (int a = (pageCount - 1) * 10; a < pageCount * 10; a++)
                {
                    if (a >= numOfVols)
                    {
                        break;
                    }

                    if (searchStr.Equals(""))
                    {
                        divVolunteeredTable.InnerHtml += "<tr><td>" + oldVols[a].VolDate.ToShortDateString() + "</td><td>" + oldVols[a].OrnName + "</td><td>" + oldVols[a].Hours + "</td><td>" + oldVols[a].Comment + "</td></tr>";
                    }
                    else
                    {
                        int numOfEvesAdded = 0;
                        for (int b = 0; b < numOfVols; b++)
                        {
                            if (numOfEvesAdded > 9)
                            {
                                break;
                            }
                            if (oldVols[b].OrnName.Contains(searchStr))
                            {
                                divVolunteeredTable.InnerHtml += "<tr><td>" + oldVols[b].VolDate.ToShortDateString() + "</td><td>" + oldVols[b].OrnName + "</td><td>" + oldVols[b].Hours + "</td><td>" + oldVols[b].Comment + "</td></tr>";
                                numOfEvesAdded++;
                            }
                        }

                        searchStr = "";
                        txtSearch.Text = "";
                        break;
                    }
                }

                divVolunteeredTable.InnerHtml += "</table>";

                for (int a = (pageCountNew - 1) * 10; a < pageCountNew * 10; a++)
                {
                    if (a >= numOfVolsNew)
                    {
                        break;
                    }

                    if (searchStrNew.Equals(""))
                    {
                        divVolunteeredTableNew.InnerHtml += "<tr><td>" + newVols[a].VolDate.ToShortDateString() + "</td><td>" + newVols[a].OrnName + "</td><td>" + newVols[a].Hours + "</td><td>" + newVols[a].Comment + "</td></tr>";
                    }
                    else
                    {
                        int numOfEvesAdded = 0;
                        for (int b = 0; b < numOfVolsNew; b++)
                        {
                            if (numOfEvesAdded > 9)
                            {
                                break;
                            }
                            if (newVols[b].OrnName.Contains(searchStrNew))
                            {
                                divVolunteeredTableNew.InnerHtml += "<tr><td>" + newVols[b].VolDate.ToShortDateString() + "</td><td>" + newVols[b].OrnName + "</td><td>" + newVols[b].Hours + "</td><td>" + newVols[b].Comment + "</td></tr>";
                                numOfEvesAdded++;
                            }
                        }

                        searchStrNew = "";
                        txtSearchNew.Text = "";
                        break;
                    }
                }

                divVolunteeredTableNew.InnerHtml += "</table>";
            }
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
            if (pageCount * 10 < numOfVols)
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

        protected void btnPrevsNew_Click(object sender, EventArgs e)
        {
            if (pageCountNew > 1)
            {
                pageCountNew--;
                Page_Load(sender, e);
            }
        }

        protected void btnNextsNew_Click(object sender, EventArgs e)
        {
            if (pageCountNew * 10 < numOfVolsNew)
            {
                pageCountNew++;
                Page_Load(sender, e);
            }
        }

        protected void btnSearchNew_Click(object sender, EventArgs e)
        {
            searchStrNew = txtSearchNew.Text;
            Page_Load(sender, e);
        }
    }
}