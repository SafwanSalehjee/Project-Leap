using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// This class handles the retrieval of donations made.
    /// </summary>
    public partial class RetrieveDonationsMade : System.Web.UI.Page
    {
        private static int pageCount = 1;
        private int numOfDons = 0;
        private static string searchStr = "";
        public string donationCSV;
        /// <summary>
        /// This method is called and executed when the page is loaded.
        /// It retrieves and displays all donations that are made.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 3 || (int)HttpContext.Current.Session["User_lvl"] == 4 || (int)HttpContext.Current.Session["User_lvl"] == 5)
            {
                ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
                ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                ServiceReference1.DonationUser[] donations = service.getDonationUser(user.userValue.UserID);

                DonationsTable.InnerHtml = "";
                DonationsTable.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'><tr style='border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th style='text-align: left;'>Date</th><th style='text-align: left;'>NPO</th><th style='text-align: left;'>Amount</th></tr>";

                if (numOfDons < donations.Count())
                {
                    numOfDons = donations.Count();
                }

                for (int a = 0; a < donations.Count(); a++)
                {
                    donationCSV += donations[a].Date.ToShortDateString() + "," + donations[a].NpoName + "," + donations[a].Amount + "\n";
                }

                for (int a = (pageCount - 1) * 8; a < pageCount * 8; a++)
                {
                    if (a >= numOfDons)
                    {
                        break;
                    }

                    if (searchStr.Equals(""))
                    {
                        DonationsTable.InnerHtml += "<tr><th style='text-align: left; margin-right: 10px;'>" + donations[a].Date.ToShortDateString() + "</th><th style='text-align: left; margin-right: 10px;'>" + donations[a].NpoName + "</th><th style='text-align: right; padding-right: 10px;'>R " + donations[a].Amount + "</th></tr>";
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
                            if (donations[b].NpoName.Contains(searchStr))
                            {
                                DonationsTable.InnerHtml += "<tr><th style='text-align: left; margin-right: 10px;'>" + donations[b].Date.ToShortDateString() + "</th><th style='text-align: left; margin-right: 10px;'>" + donations[b].NpoName + "</th><th style='text-align: right; padding-right: 10px;'>R " + donations[b].Amount + "</th></tr>";
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
    }
}