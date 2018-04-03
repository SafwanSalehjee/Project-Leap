using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.reports.mixed
{
    public partial class MostSuppportedNPOIndustry : System.Web.UI.Page
    {
        public string[] name;
        public double[] amount;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();

            string[] npoTypes = service.getNPOTypes();

            name = new string[npoTypes.Length];
            amount = new double[npoTypes.Length];

            for (int a = 0; a < npoTypes.Length; a++)
            {
                ServiceReference1.Support tmp = service.MostSupportByType(npoTypes[a]);

                name[a] = tmp.type;
                amount[a] = tmp.supportValue;
            }
        }
    }
}