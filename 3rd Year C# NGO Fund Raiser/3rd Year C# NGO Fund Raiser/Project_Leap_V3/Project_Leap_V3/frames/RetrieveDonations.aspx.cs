using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// This class handles the retrieval of all donations.
    /// </summary>
    public partial class RetrieveDonations : System.Web.UI.Page
    {
        private static int pageCount = 1;
        private int numOfDons = 0;
        private static string searchStr = "";

        private static int pageCountNew = 1;
        private int numOfDonsNew = 0;
        private static string searchStrNew = "";
        /// <summary>
        /// This method is called and executed when the page is loaded.
        /// All donations are retrieved and displayed on the page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            NewDons.Visible = false;
            if ((int)HttpContext.Current.Session["User_lvl"] == 3 || (int)HttpContext.Current.Session["User_lvl"] == 5)
            {
                ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
                ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                ServiceReference1.DonationRequester[] donations = service.getAllDonationRequest(user.userValue.UserID);

                DonationsTable.InnerHtml = "";
                DonationsTable.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'><tr style='border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th style='text-align: left; margin-right: 10px;'>NPO</th><th style='text-align: left; margin-right: 10px;'>Amount</th><th style='text-align: left; margin-right: 10px;'>Description</th><th style='text-align: left; margin-right: 10px;'>Donate</th></tr>";

                DonationsTableNew.InnerHtml = "";
                DonationsTableNew.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'><tr style='border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th style='text-align: left; margin-right: 10px;'>NPO</th><th style='text-align: left; margin-right: 10px;'>Amount</th><th style='text-align: left; margin-right: 10px;'>Description</th><th style='text-align: left; margin-right: 10px;'>Donate</th></tr>";


                int countDons = 0;

                ArrayList availableDons = new ArrayList();

                for (int a = 0; a < donations.Count(); a++)
                {
                    ServiceReference1.Organisation org = service.getOrg(donations[a].OrgID);

                    if ((bool)org.Verified)
                    {
                        if (!donations[a].Inprogress)
                        {
                            availableDons.Add(donations[a]); 
                        }
                    }
                }

                ServiceReference1.DonationRequester[] avDons = (ServiceReference1.DonationRequester[])availableDons.ToArray(typeof(ServiceReference1.DonationRequester));
                numOfDonsNew = 0;
                numOfDons = 0;

                foreach (ServiceReference1.DonationRequester d in avDons)
                {
                    if (DashboardPage.lastOnline <= d.Donate.DonationDate)
                    {
                        numOfDonsNew++;
                    }
                    else
                    {
                        numOfDons++;
                    }
                }

                ServiceReference1.DonationRequester[] avDonsNew = new ServiceReference1.DonationRequester[numOfDonsNew];
                ServiceReference1.DonationRequester[] avDonsOld = new ServiceReference1.DonationRequester[numOfDons];

                int oldCount = 0;
                int newCount = 0;

                foreach (ServiceReference1.DonationRequester d in avDons)
                {
                    if (DashboardPage.lastOnline <= d.Donate.DonationDate)
                    {
                        avDonsNew[newCount] = d;
                        newCount++;
                    }
                    else
                    {
                        avDonsOld[oldCount] = d;
                        oldCount++;
                    }
                }

                if (numOfDonsNew > 0)
                {
                    NewDons.Visible = true;

                    for (int a = (pageCountNew - 1) * 4; a < pageCountNew * 4; a++)
                    {
                        if (a >= numOfDonsNew)
                        {
                            break;
                        }

                        if (searchStrNew.Equals(""))
                        {
                            DonationsTableNew.InnerHtml += "<tr><th style='text-align: left; margin-right: 10px;'>" + avDonsNew[a].NpoName + "</th><th style='text-align: right; padding-right: 10px;'>R " + avDonsNew[a].Donate.Amount + "</th><th style='text-align: left; margin-right: 10px;'>" + avDonsNew[a].Donate.Description + "</th><th style='text-align: left;'><a href='PaymentForm.aspx?donationID=" + avDonsOld[a].Donate.RequestIDNumber + "' class='button'>Donate now</a></th></tr>";

                            countDons++;
                        }
                        else
                        {
                            int numOfDonsAdded = 0;
                            for (int b = 0; b < numOfDons; b++)
                            {
                                if (numOfDonsAdded > 3)
                                {
                                    break;
                                }
                                if (avDons[b].Discription.Contains(searchStr))
                                {
                                    DonationsTableNew.InnerHtml += "<tr><th style='text-align: left; margin-right: 10px;'>" + avDonsNew[b].NpoName + "</th><th style='text-align: right; padding-right: 10px;'>R " + avDonsNew[b].Donate.Amount + "</th><th style='text-align: left; margin-right: 10px;'>" + avDonsNew[b].Donate.Description + "</th><th style='text-align: left;'><a href='PaymentForm.aspx?donationID=" + avDonsOld[b].Donate.RequestIDNumber + "' class='button'>Donate now</a></th></tr>";

                                    numOfDonsAdded++;
                                }
                            }

                            searchStrNew = "";
                            txtSearchNew.Text = "";
                            break;
                        }
                    }

                    DonationsTableNew.InnerHtml += "</table>";
                }

                countDons = 0;

                for (int a = (pageCount - 1) * 4; a < pageCount * 4; a++)
                {
                    if (a >= numOfDons)
                    {
                        break;
                    }

                    if (searchStr.Equals(""))
                    {
                        DonationsTable.InnerHtml += "<tr><th style='text-align: left; margin-right: 10px;'>" + avDonsOld[a].NpoName + "</th><th style='text-align: right; padding-right: 10px;'>R " + avDonsOld[a].Donate.Amount + "</th><th style='text-align: left; margin-right: 10px;'>" + avDonsOld[a].Donate.Description + "</th><th style='text-align: left;'><a href='PaymentForm.aspx?donationID=" + avDonsOld[a].Donate.RequestIDNumber + "' class='button'>Donate now</a></th></tr>";

                        countDons++;
                    }
                    else
                    {
                        int numOfDonsAdded = 0;
                        for (int b = 0; b < numOfDons; b++)
                        {
                            if (numOfDonsAdded > 3)
                            {
                                break;
                            }
                            if (avDons[b].Discription.Contains(searchStr))
                            {
                                DonationsTable.InnerHtml += "<tr><th style='text-align: left; margin-right: 10px;'>" + avDonsOld[b].NpoName + "</th><th style='text-align: right; padding-right: 10px;'>R " + avDonsOld[b].Donate.Amount + "</th><th style='text-align: left; margin-right: 10px;'>" + avDonsOld[b].Donate.Description + "</th><th style='text-align: left;'><a href='PaymentForm.aspx?donationID=" + avDonsOld[b].Donate.RequestIDNumber + "' class='button'>Donate now</a></th></tr>";

                                numOfDonsAdded++;
                            }
                        }

                        searchStr = "";
                        txtSearch.Text = "";
                        break;
                    }
                }

                DonationsTable.InnerHtml += "</table>";
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
            if (pageCount * 4 < numOfDons)
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
            if (pageCountNew * 4 < numOfDonsNew)
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