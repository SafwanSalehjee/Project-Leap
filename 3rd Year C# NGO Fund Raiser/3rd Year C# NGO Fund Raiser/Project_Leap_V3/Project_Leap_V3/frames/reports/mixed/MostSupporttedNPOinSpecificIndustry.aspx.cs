using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.reports.mixed
{
    public partial class MostSupporttedNPOinSpecificIndustry : System.Web.UI.Page
    {
        public string[] name;
        public double[] amount;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();

            ServiceReference1.Support[] Sup = null;
            
            ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
            string Type = service.targetedDonations(user.userValue.UserID);
            int numOfOrg = service.NumOfOrgByIndustry(Type);

           
            Sup = service.MostSupportInType(Type);

            name = new string[numOfOrg];
            amount = new double[numOfOrg];


            for (int i = 0; i < numOfOrg; i++)
            {
                name[i] = Sup[i].type;
                amount[i] = Sup[i].supportValue;
            }
            
            
    }
    }
}