using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// The list of users that have RSVPed for an specific event.
    /// </summary>
    public partial class npoRSVPlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 1)
            {
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                ServiceReference1.RSVPEvent[] Events;
                int OrgID = Convert.ToInt32(Request.QueryString["OrgID"]);
                int EventID = Convert.ToInt32(Request.QueryString["EventID"]);

                Events = serv.getGetRSVPList(OrgID);
                TableList.InnerHtml = "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'><tr><td>User : </td><td>Status: </td></tr>";
                foreach (ServiceReference1.RSVPEvent eve in Events)
                {
                    if (eve.EventID == EventID)
                    {
                        TableList.InnerHtml += "<tr><td>" + serv.getUser(eve.User).EmailValue + "</td><td>" + eve.Attendance + "</td></tr>";


                    }
                }
                TableList.InnerHtml += "</table>";
            }
        }
    }
}