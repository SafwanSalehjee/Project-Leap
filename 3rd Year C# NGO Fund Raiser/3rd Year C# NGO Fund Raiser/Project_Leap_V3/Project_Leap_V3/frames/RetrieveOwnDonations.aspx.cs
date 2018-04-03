using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// This class handles the retrieval of donations made to a specific user.
    /// </summary>
    public partial class RetrieveOwnDonations : System.Web.UI.Page
    {
        private static int pageCount = 1;
        private int numOfDons = 0;
        private static string searchStr = "";

        private static int pageCountOld = 1;
        private int numOfDonsOld = 0;
        private static string searchStrOld = "";

        public string donationCSV;
        /// <summary>
        /// This method is called and executed when the page is loaded.
        /// This method retrieves and displays the donations that are specific to a user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 1 || (int)HttpContext.Current.Session["User_lvl"] == 2)
            {
                ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
                ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                ServiceReference1.DonationRequester[] donations = service.getAllNDonationRequest(service.getNPOWithManager(user.userValue.UserID));

                DonationsTable.InnerHtml = "";
                DonationsTable.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'><tr style='border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th style='text-align: left; margin-right: 10px'>Type</th><th style='text-align: left; margin-right: 10px'>Amount</th><th style='text-align: left; margin-right: 10px'>Description</th><th style='text-align: left; margin-right: 10px; width: 100px;'>Donation request date</th></tr>";

                DonationsTableOld.InnerHtml = "";
                DonationsTableOld.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'><tr style='border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th style='text-align: left; margin-right: 10px'>Type</th><th style='text-align: left; margin-right: 10px'>Amount</th><th style='text-align: left; margin-right: 10px'>Description</th><th style='text-align: left; margin-right: 10px; width: 100px;'>Donation request date</th></tr>";

                numOfDons = 0;
                numOfDonsOld = 0;

                foreach(ServiceReference1.DonationRequester r in donations)
                {
                    if(r.Inprogress)
                        numOfDonsOld++;
                    else
                        numOfDons++;
                }

                ServiceReference1.DonationRequester[] donationsNew = new ServiceReference1.DonationRequester[numOfDons];
                ServiceReference1.DonationRequester[] donationsOld = new ServiceReference1.DonationRequester[numOfDonsOld];
                int oldCount = 0;
                int newCount = 0;

                foreach(ServiceReference1.DonationRequester r in donations)
                {
                    if (r.Inprogress)
                    {
                        donationsOld[oldCount] = r;
                        oldCount++;
                    }
                    else
                    {
                        donationsNew[newCount] = r;
                        newCount++;
                    }
                }

                for (int a = 0; a < donations.Count(); a++)
                {
                    if (donations[a].Inprogress)
                    {
                        donationCSV += donations[a].Date.ToShortDateString() + "," + donations[a].Discription + "," + donations[a].Amount + "\n";
                    }
                }

                for (int a = (pageCount - 1) * 8; a < pageCount * 8; a++)
                {
                    if (a >= numOfDons)
                    {
                        break;
                    }

                    string type = "";

                    if (donationsNew[a].Donate.Type == 1)
                    {
                        type = "Monetary donation";
                    }
                    else if (donationsNew[a].Donate.Type == 2)
                    {
                        type = "Equipment donation";
                    }

                    if (!donationsNew[a].Inprogress)
                    {
                        if (searchStr.Equals(""))
                        {
                            DonationsTable.InnerHtml += "<tr><th style='text-align: left; margin-right: 10px;'>" + type + "</th><th style='text-align: right; padding-right: 10px;'>R " + donationsNew[a].Donate.Amount + "</th><th style='text-align: left; margin-right: 10px;'>" + donationsNew[a].Donate.Description + "</th><th style='text-align: left; margin-right: 10px;'>" + donationsNew[a].Donate.DonationDate.Value.ToShortDateString() + "</th></tr>";
                        }
                        else
                        {
                            int numOfDonsAdded = 0;
                            for (int b = 0; b < numOfDons; b++)
                            {
                                if (numOfDonsAdded > 7)
                                {
                                    break;
                                }
                                if (donationsNew[b].Donate.Description.Contains(searchStr))
                                {
                                    if (!donationsNew[b].Inprogress)
                                    {
                                        DonationsTable.InnerHtml += "<tr><th style='text-align: left; margin-right: 10px;'>" + type + "</th><th style='text-align: right; padding-right: 10px;'>R " + donationsNew[b].Donate.Amount + "</th><th style='text-align: left; margin-right: 10px;'>" + donationsNew[b].Donate.Description + "</th><th style='text-align: left; margin-right: 10px;'>" + donationsNew[b].Donate.DonationDate.Value.ToShortDateString() + "</th></tr>";
                                        numOfDonsAdded++;
                                    }                           
                                }
                            }

                            searchStr = "";
                            txtSearch.Text = "";
                            break;
                        }
                    }      
                }

                DonationsTable.InnerHtml += "</table>";

                for (int a = (pageCountOld - 1) * 8; a < pageCountOld * 8; a++)
                {
                    if (a >= numOfDonsOld)
                    {
                        break;
                    }

                    string type = "";

                    if (donationsOld[a].Donate.Type == 1)
                    {
                        type = "Monetary donation";
                    }
                    else if (donationsOld[a].Donate.Type == 2)
                    {
                        type = "Equipment donation";
                    }

                    if (donationsOld[a].Inprogress)
                    {
                        if (searchStrOld.Equals(""))
                        {
                            DonationsTableOld.InnerHtml += "<tr><th style='text-align: left; margin-right: 10px;'>" + type + "</th><th style='text-align: right; padding-right: 10px;'>R " + donationsOld[a].Donate.Amount + "</th><th style='text-align: left; margin-right: 10px;'>" + donationsOld[a].Donate.Description + "</th><th style='text-align: left; margin-right: 10px;'>" + donationsOld[a].Donate.DonationDate.Value.ToShortDateString() + "</th></tr>";
                        }
                        else
                        {
                            int numOfDonsAdded = 0;
                            for (int b = 0; b < numOfDonsOld; b++)
                            {
                                if (numOfDonsAdded > 7)
                                {
                                    break;
                                }
                                if (donationsOld[b].Donate.Description.Contains(searchStrOld))
                                {
                                    if (donationsOld[b].Inprogress)
                                    {
                                        DonationsTableOld.InnerHtml += "<tr><th style='text-align: left; margin-right: 10px;'>" + type + "</th><th style='text-align: right; padding-right: 10px;'>R " + donationsOld[b].Donate.Amount + "</th><th style='text-align: left; margin-right: 10px;'>" + donationsOld[b].Donate.Description + "</th><th style='text-align: left; margin-right: 10px;'>" + donationsOld[b].Donate.DonationDate.Value.ToShortDateString() + "</th></tr>";
                                        numOfDonsAdded++;
                                    }                           
                                }
                            }

                            searchStrOld = "";
                            txtSearchOld.Text = "";
                            break;
                        }
                    }      
                }

                DonationsTableOld.InnerHtml += "</table>";
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
            if (pageCount * 8 < numOfDons)
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
            if (pageCountOld * 8 < numOfDonsOld)
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