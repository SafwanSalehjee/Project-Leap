using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames.reports.npo
{
    public partial class VolunteersShowingUp : System.Web.UI.Page
    {
        public double showUp = 0;
        public double notShowUp = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

            if (user.AccessLvl == 1)
            {
                showUp = service.getVolsShowingUp(service.getNPOWithManager(user.userValue.UserID));
                notShowUp = 100 - showUp;
            }
        }
    }
}