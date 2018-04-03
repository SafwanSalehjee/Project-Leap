using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.reports.mixed
{
    public partial class MostSupportedIndustryArea : System.Web.UI.Page
    {
        ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
        ServiceReference1.Support sup = new ServiceReference1.Support();

        public string[] arrC;
        public string[] arrP;
        public string[] arrT;
        public int[] arrV;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            arrC = new string[9];
            arrP = new string[9];
            arrV = new int[9];
            arrT = new string[9];

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

             
            sup =  serv.TypeMostSupportInArea("Eastern Cape");
            arrV[0] = sup.supportValue;
            arrT[0] = sup.type;
            sup = serv.TypeMostSupportInArea("Free State");
            arrV[1] = sup.supportValue;
            arrT[1] = sup.type;
            sup = serv.TypeMostSupportInArea("Gauteng");
            arrV[2] = sup.supportValue;
            arrT[2] = sup.type;
            sup = serv.TypeMostSupportInArea("KwaZulu-Natal");
            arrV[3] = sup.supportValue;
            arrT[3] = sup.type;
            sup = serv.TypeMostSupportInArea("Limpopo");
            arrV[4] = sup.supportValue;
            arrT[4] = sup.type;
            sup = serv.TypeMostSupportInArea("Mpumalanga");
            arrV[5] = sup.supportValue;
            arrT[5] = sup.type;
            sup = serv.TypeMostSupportInArea("Northern Cape");
            arrV[6] = sup.supportValue;
            arrT[6] = sup.type;
            sup = serv.TypeMostSupportInArea("North West");
            arrV[7] = sup.supportValue;
            arrT[7] = sup.type;
            sup = serv.TypeMostSupportInArea("Western Cape");
            arrV[8] = sup.supportValue;
            arrT[8] = sup.type;
            
        }
    }
}