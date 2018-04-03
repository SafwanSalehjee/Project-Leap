using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.reports.mixed
{
    public partial class MostNPOs_Registered : System.Web.UI.Page
    {
        ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();

        public string[] arrC;
        public string[] arrP;
        public int[] arrV;

        protected void Page_Load(object sender, EventArgs e)
        {
            arrC = new string[9];
            arrP = new string[9];
            arrV = new int[9];

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
            arrP[7] = "North-West";
            arrP[8] = "Western Cape";

            arrV[0] = serv.NumberOfTimes("Organisation", "Eastern Cape");
            arrV[1] = serv.NumberOfTimes("Organisation", "Free State");
            arrV[2] = serv.NumberOfTimes("Organisation", "Gauteng");
            arrV[3] = serv.NumberOfTimes("Organisation", "KwaZulu-Natal");
            arrV[4] = serv.NumberOfTimes("Organisation", "Limpopo");
            arrV[5] = serv.NumberOfTimes("Organisation", "Mpumalanga");
            arrV[6] = serv.NumberOfTimes("Organisation", "Northern Cape");
            arrV[7] = serv.NumberOfTimes("Organisation", "North West");
            arrV[8] = serv.NumberOfTimes("Organisation", "Western Cape");
        }
    }
}