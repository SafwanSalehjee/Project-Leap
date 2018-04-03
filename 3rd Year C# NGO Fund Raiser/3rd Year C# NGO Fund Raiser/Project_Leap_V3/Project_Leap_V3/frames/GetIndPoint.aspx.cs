using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// The frame handle the retrieval of the individuals points
    /// </summary>
    public partial class GetIndPoint : System.Web.UI.Page
    {
        /// <summary>
        /// This method is called and executed when the page is loaded.
        /// The Page_Load handle the retrieval of the individuals points 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 5)
            {
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();

                ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

                int points = serv.getPointsInd(user.userValue.UserID);

                lblPoints.Text = "" + points;
            }
        }
    }
}