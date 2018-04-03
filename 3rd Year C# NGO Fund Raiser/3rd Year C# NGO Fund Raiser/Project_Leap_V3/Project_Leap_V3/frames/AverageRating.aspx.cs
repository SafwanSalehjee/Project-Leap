using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// This page displays the average rating of each NPO
    /// </summary>
    public partial class AverageRating : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] > 0 || (int)HttpContext.Current.Session["User_lvl"] < 8)
            {
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                ServiceReference1.UserDetail u = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

                double value = 0;

                if (Request.QueryString["orgId"] != null)
                {
                    value = serv.getAverageRating(int.Parse(Request.QueryString["orgId"].ToString()));
                }
                else
                {
                    value = serv.getAverageRating(serv.getNPOWithManager(u.userValue.UserID));
                }

                lblRR.Text = "" + value + "/10";
            }
            else
            {
                lblRR.Text = "Rating</br></br>not</br></br>available";
            }
        }
    }
}