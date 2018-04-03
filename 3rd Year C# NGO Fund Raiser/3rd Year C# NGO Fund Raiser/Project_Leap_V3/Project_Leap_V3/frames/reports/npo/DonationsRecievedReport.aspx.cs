using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.reports.npo
{
    public partial class DonationsRecievedReport : System.Web.UI.Page
    {
        public string[] dates;
        public double[] amounts;
        public int npoID;

        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

            if (user.AccessLvl == 1)
            {
                npoID = service.getNPOWithManager(user.userValue.UserID);
                ServiceReference1.reportDonation[] donations = service.getAllDailyDonations(service.getNPOWithManager(user.userValue.UserID));

                dates = new string[donations.Count()];
                amounts = new double[donations.Count()];

                for (int a = 0; a < dates.Count(); a++)
                {
                    dates[a] = donations[a].Date;
                    amounts[a] = donations[a].Amount;
                }
            }
        }
    }
}