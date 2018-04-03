using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.reports.npo
{
    public partial class ComparableDons : System.Web.UI.Page
    {
        public string[] dates;
        public double[] amount;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlUpdateChart.Items.Add("Group by month");
                ddlUpdateChart.Items.Add("Group by year");
            }

            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

            if (user.AccessLvl == 1)
            {
                ServiceReference1.reportDonation[] repDons = null;

                if (ddlUpdateChart.SelectedValue.Equals("Group by month"))
                {
                    repDons = service.getDonationsForComparison(31, "M");
                }
                else if (ddlUpdateChart.SelectedValue.Equals("Group by year"))
                {
                    repDons = service.getDonationsForComparison(31, "Y");
                }

                dates = new string[repDons.Count()];
                amount = new double[repDons.Count()];

                for (int a = 0; a < repDons.Count(); a++)
                {
                    dates[a] = repDons[a].Date;
                    amount[a] = repDons[a].Amount;
                }
            }
        }
    }
}