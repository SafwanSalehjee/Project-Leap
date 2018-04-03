using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.reports.npo
{
    public partial class VolunteersPerRegion : System.Web.UI.Page
    {
        public string[] arrC;
        public string[] arrP;
        public int[] arrV;

        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

            if (user.AccessLvl == 1)
            {
                arrC = new string[9];
                arrP = new string[9];
                arrV = new int[9];

                ServiceReference1.reportVolunteers[] volunteers = service.getVolunteersByProvince();

                arrC[0] = "ZA-EC";
                arrC[1] = "ZA-FS";
                arrC[2] = "ZA-GT";
                arrC[3] = "ZA-NL";
                arrC[4] = "ZA-LP";
                arrC[5] = "ZA-MP";
                arrC[6] = "ZA-NC";
                arrC[7] = "ZA-NW";
                arrC[8] = "ZA-WC";

                arrP[0] = "Eastern Cape";
                arrP[1] = "Free State";
                arrP[2] = "Gauteng";
                arrP[3] = "KwaZulu-Natal";
                arrP[4] = "Limpopo";
                arrP[5] = "Mpumalanga";
                arrP[6] = "Northern Cape";
                arrP[7] = "North West";
                arrP[8] = "Western Cape";

                arrV[0] = 0;
                arrV[1] = 0;
                arrV[2] = 0;
                arrV[3] = 0;
                arrV[4] = 0;
                arrV[5] = 0;
                arrV[6] = 0;
                arrV[7] = 0;
                arrV[8] = 0;

                for (int a = 0; a < volunteers.Count(); a++)
                {
                    if (volunteers[a].Province.Equals("Eastern Cape"))
                    {
                        arrV[0] = volunteers[a].VolAmounts;
                    }
                    if (volunteers[a].Province.Equals("Free State"))
                    {
                        arrV[1] = volunteers[a].VolAmounts;
                    }
                    if (volunteers[a].Province.Equals("Gauteng"))
                    {
                        arrV[2] = volunteers[a].VolAmounts;
                    }
                    if (volunteers[a].Province.Equals("KwaZulu-Natal"))
                    {
                        arrV[3] = volunteers[a].VolAmounts;
                    }
                    if (volunteers[a].Province.Equals("Limpopo"))
                    {
                        arrV[4] = volunteers[a].VolAmounts;
                    }
                    if (volunteers[a].Province.Equals("Mpumalanga"))
                    {
                        arrV[5] = volunteers[a].VolAmounts;
                    }
                    if (volunteers[a].Province.Equals("Northern Cape"))
                    {
                        arrV[6] = volunteers[a].VolAmounts;
                    }
                    if (volunteers[a].Province.Equals("North West"))
                    {
                        arrV[7] = volunteers[a].VolAmounts;
                    }
                    if (volunteers[a].Province.Equals("Western Cape"))
                    {
                        arrV[8] = volunteers[a].VolAmounts;
                    }
                }
            }
        }
    }
}