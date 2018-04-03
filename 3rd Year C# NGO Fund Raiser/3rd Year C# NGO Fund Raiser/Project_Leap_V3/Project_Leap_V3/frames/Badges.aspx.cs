using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    public partial class Badges : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
            ServiceReference1.UserDetail u = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];            
            int userID = u.userValue.UserID;

            if (serv.checkBadge(userID, 1) == true)
            {
                badgesContainer.InnerHtml += "<div><h1>Bronze Donor Badge</h1><img style='width:50px;height:50px' src='/images/Badges/don_bronze.png'/></div>";
            }
            if (serv.checkBadge(userID, 2) == true)
            {
                badgesContainer.InnerHtml += "<div><h1>Silver Donor Badge</h1><img style='width:50px;height:50px' src='/images/Badges/don_silver.png'/></div>";
            }
            if (serv.checkBadge(userID, 3) == true)
            {
                badgesContainer.InnerHtml += "<div><h1>Gold Donor Badge</h1><img style='width:50px;height:50px' src='/images/Badges/don_gold.png'/></div>";
            }
            if (serv.checkBadge(userID, 4) == true)
            {
                badgesContainer.InnerHtml += "<div><h1>Bronze Volunteer</h1><img style='width:50px;height:50px' src='/images/Badges/vol_bronze.png'/></div>";
            }
            if (serv.checkBadge(userID, 5) == true)
            {
                badgesContainer.InnerHtml += "<div><h1>Silver Volunteer</h1><img style='width:50px;height:50px' src='/images/Badges/vol_silver.png'/></div>";
            }
            if (serv.checkBadge(userID, 6) == true)
            {
                badgesContainer.InnerHtml += "<div><h1>Gold Volunteer</h1><img style='width:50px;height:50px' src='/images/Badges/vol_gold.png'/></div>";
            }
            if (serv.checkBadge(userID, 7) == true)
            {
                badgesContainer.InnerHtml += "<div><h1>Bronze Points</h1><img style='width:50px;height:50px' src='/images/Badges/points_bronze.png'/></div>";
            }
            if (serv.checkBadge(userID, 8) == true)
            {
                badgesContainer.InnerHtml += "<div><h1>Silver Points</h1><img style='width:50px;height:50px' src='/images/Badges/points_silver.png'/></div>";
            }
            if (serv.checkBadge(userID, 9) == true)
            {
                badgesContainer.InnerHtml += "<div><h1>Gold Points</h1><img style='width:50px;height:50px' src='/images/Badges/points_gold.png'/></div>";
            }
            if (serv.checkBadge(userID, 10) == true)
            {
                badgesContainer.InnerHtml += "<div><h1>Bronze Rater</h1><img style='width:50px;height:50px' src='/images/Badges/rate_bronze.png'/></div>";
            }
            if (serv.checkBadge(userID, 11) == true)
            {
                badgesContainer.InnerHtml += "<div><h1>Silver Rater</h1><img style='width:50px;height:50px' src='/images/Badges/rate_silver.png'/></div>";
            }
            if (serv.checkBadge(userID, 12) == true)
            {
                badgesContainer.InnerHtml += "<div><h1>Gold Rater</h1><img style='width:50px;height:50px' src='/images/Badges/rate_gold.png'/></div>";
            }
        }
    }
}