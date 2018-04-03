using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    public partial class VolunteerPage : System.Web.UI.Page
    {
        /// <summary>
        /// On Page Load; Get today's date and set the necessary labels and textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime today = DateTime.Today;
                calVolDate.TodaysDate = today;
                calVolDate.SelectedDate = calVolDate.TodaysDate;
                lblVolDate.Text = calVolDate.SelectedDate.ToShortDateString();
            }
        }

        /// <summary>
        /// Selected an appropriate date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void calVolDate_SelectionChanged(object sender, EventArgs e)
        {
            lblVolDate.Text = calVolDate.SelectedDate.ToShortDateString();
            calVolDate.Visible = false;
        }

        /// <summary>
        /// When the Calendar icon is clicked, the Calendar must be displayed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCal_Click(object sender, ImageClickEventArgs e)
        {
            calVolDate.Visible = true;
        }

        protected void btnVolunteer_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 5)
            {
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();

                ServiceReference1.EventVolunteer vol = new ServiceReference1.EventVolunteer();
                string[] s;
                DateTime DateOfVolEvent;
                try
                {
                    s = lblVolDate.Text.Split('-');
                    DateOfVolEvent = new DateTime(Convert.ToInt32(s[0]), Convert.ToInt32(s[1]), Convert.ToInt32(s[2]), 0, 0, 0);
                }
                catch (Exception ex)
                {
                    s = lblVolDate.Text.Split('/');
                    DateOfVolEvent = new DateTime(Convert.ToInt32(s[0]), Convert.ToInt32(s[1]), Convert.ToInt32(s[2]), 0, 0, 0);
                }

                vol.VolDate = DateOfVolEvent;

                ServiceReference1.UserDetail u = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                int id = Convert.ToInt32(Request.QueryString["Org_ID"].ToString());
                vol.OrgID = id;
                vol.UserID = u.userValue.UserID;

                bool success = serv.setVolunteer(vol);

                if (success == true)
                {
                    lblSuccessful.Text = "Congratulations! You have successfully volunteered at the NPO";
                }
                else
                {
                    lblSuccessful.ForeColor = System.Drawing.Color.Red;
                    lblSuccessful.Text = "Sorry! You have not been able to register successfully!";
                }
            }

        }
    }
}