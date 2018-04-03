using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// This class handles the posting of news feeds on the system
    /// </summary>
    public partial class PostNewsFeed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This method is called and executed when the btnPostNewsFeed button is clicked.
        /// The new news feed that is entered is stored and posted on the system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPostNewsFeed_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 1)
            {
                ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
                NPOManager npoManager = new NPOManager(user.userValue.UserID, user.userValue.FirstName, user.userValue.Email);
                NewsFeed feed = new NewsFeed();
                feed.Title1 = txtTitle.Text;
                feed.Body1 = txtBody.Text;

                NPO npo = new NPO();
                npo.ID1 = service.getNPOWithManager(npoManager.ID1);

                npoManager.Npo = npo;

                npoManager.PostNewsFeed(feed);

                lblReply.Text = npoManager.Npo.FeedAdded;
            }
        }
    }
}