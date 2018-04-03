using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Leap_V3
{
    public class Predict
    {
        private static double setGradiant(ServiceReference1.reportDonation first, ServiceReference1.reportDonation last)
        {
            DateTime d1 = Convert.ToDateTime(first.Date), d2 = Convert.ToDateTime(last.Date);
            TimeSpan t = d2 - d1;
            return t.TotalDays / (last.Amount - first.Amount);
        }

        public static ServiceReference1.reportDonation[] prodictValue(ServiceReference1.reportDonation[] values, int numD)
        {
            int total = values.Count() + numD;
            ServiceReference1.reportDonation[] ret = new ServiceReference1.reportDonation[total];
            for (int i = 0; i < values.Count(); i++)
            {
                ret[i] = new ServiceReference1.reportDonation();
                ret[i].Amount = values[i].Amount;
                ret[i].Date = values[i].Date;
            }

            for (int i = values.Count() ; i < total; i++)
            {
                ServiceReference1.reportDonation pd = ret[i - 1];
                DateTime d = Convert.ToDateTime(pd.Date);
                ret[i] = new ServiceReference1.reportDonation();
                double pwer = Math.Pow(1 + setGradiant(ret[i - values.Count()], ret[1 + (i - values.Count())]), i);
                ret[i].Amount = ret[0].Amount * pwer;
                d = d.AddDays(3);
                ret[i].Date = d.ToShortDateString();
            }
            return ret;
        }
    }
}