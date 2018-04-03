using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.reports.system
{
    public partial class PredictIncome : System.Web.UI.Page
    {

        public string[] dates;
        public double[] amounts;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];


            if (user.AccessLvl == 6)
            {
                ServiceReference1.reportDonation[] donations = service.getSystemFund();
                ServiceReference1.reportDonation[] don = Predict.prodictValue(donations, 6);
                dates = new string[don.Count()];
                amounts = new double[don.Count()];
                for (int i = 0; i < don.Count(); i++)
                {
                    dates[i] = don[i].Date;
                    amounts[i] = don[i].Amount;
                }

            }

        }
    }
}