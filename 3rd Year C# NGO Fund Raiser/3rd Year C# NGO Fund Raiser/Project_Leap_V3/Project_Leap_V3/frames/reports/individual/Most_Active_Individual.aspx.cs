using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.reports.individual
{
    public partial class Most_Active_Individual : System.Web.UI.Page
    {
        public string[] name;
        public double[] amount;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();

            ServiceReference1.reportBusDon[] Actives = service.MostActiveUser();

            name = new string[Actives.Count()];
            amount = new double[Actives.Count()];

            for (int a = 0; a < Actives.Count(); a++)
            {
                name[a] = Actives[a].Name;
                amount[a] = Actives[a].Amount;
            }
        }
    }
}