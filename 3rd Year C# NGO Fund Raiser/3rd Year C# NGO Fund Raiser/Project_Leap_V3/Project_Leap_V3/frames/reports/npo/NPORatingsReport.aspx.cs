using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.reports.npo
{
    public partial class NPORatingsReport : System.Web.UI.Page
    {
        public string[] title;
        public double[] percentage;

        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

            if (user.AccessLvl == 1)
            {
                ServiceReference1.ratingsReport[] fcs = service.getNPORatingReport(service.getNPOWithManager(user.userValue.UserID));

                title = new string[fcs.Count()];
                percentage = new double[fcs.Count()];

                for (int a = 0; a < fcs.Count(); a++)
                {
                    title[a] = fcs[a].Value;
                    percentage[a] = fcs[a].Count;
                }
            }
        }
    }
}