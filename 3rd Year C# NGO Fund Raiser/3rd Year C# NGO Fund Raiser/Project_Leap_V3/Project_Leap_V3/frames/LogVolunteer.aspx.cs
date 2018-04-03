using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// This page allows the NPO manager to add comments about the volunteer and the number of hours that the volunteer actually completed
    /// </summary>
    public partial class LogVolunteer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// This adds the number of hours and comment to the specific volunteer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLV_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 1)
            {
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();

                int volID = Convert.ToInt32(Request.QueryString["Volunteer_ID"].ToString());
                ServiceReference1.EventVolunteer vol = new ServiceReference1.EventVolunteer();
                vol.VolunteerID = volID;
                vol.Comment = txtComment.Text;
                vol.Hours = Convert.ToInt32(txtHours.Text);

                bool successful = serv.CommentOnVolunteer(vol);

                if (successful == true)
                {
                    lblSuccess.Text = "Congratulations! You have successfully commented on the volunteer!";
                }
                else
                {
                    lblSuccess.ForeColor = System.Drawing.Color.Red;
                    lblSuccess.Text = "Sorry! You have not been able to comment on the volunteer successfully!";
                }
            }
        }
    }
}