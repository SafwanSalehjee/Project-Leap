using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Project_Leap_V3.frames
{
    public partial class ViewVolunteers : System.Web.UI.Page
    {
        private static int pageCount = 1;
        private int numOfVols = 0;
        private static string searchStr = "";

        private static int pageCountOld = 1;
        private int numOfVolsOld = 0;
        private static string searchStrOld = "";

        /// <summary>
        /// This method is called and executed when the page is loaded.
        /// A list of all volunteers are retrieved and displayed when the page is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 1)
            {
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();

                ServiceReference1.UserDetail u = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

                ServiceReference1.EventVolunteer[] volunteers = serv.getVolunteers(serv.getNPOWithManager(u.userValue.UserID));

                divVolunteersTable.InnerHtml = "";
                divVolunteersTable.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'>";
                divVolunteersTable.InnerHtml += "<tr style='width: 100%; border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th style='text-align: left; margin-right: 10px'>Email</th><th style='text-align: left; margin-right: 10px'>Name</th><th style='text-align: left; margin-right: 10px'>Surname</th><th style='text-align: left; margin-right: 10px'>Volunteer Date</th></tr>";

                divVolunteersTableOld.InnerHtml = "";
                divVolunteersTableOld.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'>";
                divVolunteersTableOld.InnerHtml += "<tr style='width: 100%; border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th style='text-align: left; margin-right: 10px'>Email</th><th style='text-align: left; margin-right: 10px'>Name</th><th style='text-align: left; margin-right: 10px'>Surname</th><th style='text-align: left; margin-right: 10px'>Volunteer Date</th></tr>";

                numOfVols = 0;
                numOfVolsOld = 0;

                foreach (ServiceReference1.EventVolunteer vols in volunteers)
                {
                    if (DateTime.Today >= vols.VolDate)
                        numOfVolsOld++;
                    else
                        numOfVols++;
                }

                ServiceReference1.EventVolunteer[] volunteersNew = new ServiceReference1.EventVolunteer[numOfVols];
                ServiceReference1.EventVolunteer[] volunteersOld = new ServiceReference1.EventVolunteer[numOfVolsOld];
                int oldCount = 0;
                int newCount = 0;

                foreach (ServiceReference1.EventVolunteer vols in volunteers)
                {
                    if (vols.VolDate >= DateTime.Today)
                    {
                        volunteersNew[newCount] = vols;
                        newCount++;
                    }
                    else
                    {
                        volunteersOld[oldCount] = vols;
                        oldCount++;
                    }
                }

                for (int a = (pageCount - 1) * 10; a < pageCount * 10; a++)
                {
                    if (a >= numOfVols)
                    {
                        break;
                    }

                    if (searchStr.Equals(""))
                    {
                        divVolunteersTable.InnerHtml += "<tr><td>" + volunteersNew[a].UserEmail + "</td><td>" + volunteersNew[a].UserFN + "</td><td>" + volunteersNew[a].UserLN + "</td><td>" + volunteersNew[a].VolDate.ToShortDateString() + "</td></tr>";
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
                            if (volunteersNew[b].UserEmail.Contains(searchStr))
                            {
                                divVolunteersTable.InnerHtml += "<tr><td>" + volunteersNew[b].UserEmail + "</td><td>" + volunteersNew[b].UserFN + "</td><td>" + volunteersNew[b].UserLN + "</td><td>" + volunteersNew[b].VolDate.ToShortDateString() + "</td></tr>";
                                numOfEvesAdded++;
                            }
                        }

                        searchStr = "";
                        txtSearch.Text = "";
                        break;
                    }
                }

                divVolunteersTable.InnerHtml += "</table>";

                for (int a = (pageCountOld - 1) * 10; a < pageCountOld * 10; a++)
                {
                    if (a >= numOfVolsOld)
                    {
                        break;
                    }

                    if (searchStrOld.Equals(""))
                    {
                        divVolunteersTableOld.InnerHtml += "<tr><td><a href='/frames/LogVolunteer.aspx?Volunteer_ID=" + volunteersOld[a].VolunteerID + "'>" + volunteersOld[a].UserEmail + "</a></td><td>" + volunteersOld[a].UserFN + "</td><td>" + volunteersOld[a].UserLN + "</td><td>" + volunteersOld[a].VolDate.ToShortDateString() + "</td></tr>";
                    }
                    else
                    {
                        int numOfEvesAdded = 0;
                        for (int b = 0; b < numOfVolsOld; b++)
                        {
                            if (numOfEvesAdded > 9)
                            {
                                break;
                            }
                            if (volunteersOld[b].UserEmail.Contains(searchStrOld))
                            {
                                divVolunteersTableOld.InnerHtml += "<tr><td><a href='/frames/LogVolunteer.aspx?Volunteer_ID=" + volunteersOld[b].VolunteerID + "'>" + volunteersOld[b].UserEmail + "</a></td><td>" + volunteersOld[b].UserFN + "</td><td>" + volunteersOld[b].UserLN + "</td><td>" + volunteersOld[b].VolDate.ToShortDateString() + "</td></tr>";
                                numOfEvesAdded++;
                            }
                        }

                        searchStrOld = "";
                        txtSearchOld.Text = "";
                        break;
                    }
                }

                divVolunteersTableOld.InnerHtml += "</table>";

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
            if (pageCountOld * 10 < numOfVolsOld)
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