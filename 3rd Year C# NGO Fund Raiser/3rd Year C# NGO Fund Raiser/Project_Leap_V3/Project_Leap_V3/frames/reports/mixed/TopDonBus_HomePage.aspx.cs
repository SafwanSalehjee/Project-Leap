using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.reports.mixed
{
    public partial class TopDonBus_HomePage : System.Web.UI.Page
    {
        public string[] name;
        public double[] amount;

        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();

            ServiceReference1.reportBusDon[] dons = service.getTopBusDon();

            name = new string[dons.Count()];
            amount = new double[dons.Count()];

            for (int a = 0; a < dons.Count(); a++)
            {
                name[a] = dons[a].Name;
                amount[a] = dons[a].Amount;
            }
        }
    }
}