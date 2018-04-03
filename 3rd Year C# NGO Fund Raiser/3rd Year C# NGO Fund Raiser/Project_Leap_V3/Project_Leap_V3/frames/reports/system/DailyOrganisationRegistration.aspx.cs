using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.reports.system
{
    public partial class DailyOrganisationRegistration : System.Web.UI.Page
    {
        public string[] dates;
        public double[] amounts;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];


            if (user.AccessLvl == 6)
            {
                ServiceReference1.reportDonation[] OrgRegistration = service.getDailyOrganisationRegistration();
                int size = OrgRegistration.Count();
                dates = new string[size];
                amounts = new double[size];

                for (int a = 0; a < dates.Count(); a++)
                {
                    dates[a] = OrgRegistration[a].Date;
                    amounts[a] = OrgRegistration[a].Amount;
                }
            }

        }
    }
}