using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// This class handles the retrieval of news feeds
    /// </summary>
    public partial class RetrieveNewsFeeds : System.Web.UI.Page
    {
        /// <summary>
        /// Private variable declaration
        /// </summary>
        private ServiceReference1.Service1Client serv;
        private static int pageCount = 1;
        private int numOfNFs = 0;

        /// <summary>
        /// This method is called and executed when the page is loaded.
        /// All news feeds are retrieved and displayed when the page is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] > 0 && (int)HttpContext.Current.Session["User_lvl"] < 8)
            {
                serv = new ServiceReference1.Service1Client();

                ServiceReference1.NewsF[] feedlist = serv.GetFeeds();

                if (numOfNFs < feedlist.Count())
                {
                    numOfNFs = feedlist.Count();
                }

                Retrive.InnerHtml = "";

                for (int a = (pageCount - 1) * 5; a < pageCount * 5; a++)
                {
                    if (a >= numOfNFs)
                    {
                        break;
                    }
                    Retrive.InnerHtml += "<blockquote class='testimonial no-after'>" + feedlist[a].Title1 + ":</br>" + feedlist[a].Body1 + "<cite><a target='_blank' href='../UserPage.aspx?orgId=" + feedlist[a].OrgID1 + "'>" + feedlist[a].OrgName1 + "</a></cite></blockquote>";
                }
            }
        }

        protected void btnPrevs_Click(object sender, EventArgs e)
        {
            if (pageCount > 1)
            {
                pageCount--;
                Page_Load(sender, e);
            }
        }

        protected void btnNexts_Click(object sender, EventArgs e)
        {
            if (pageCount * 5 < numOfNFs)
            {
                pageCount++;
                Page_Load(sender, e);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Page_Load(sender, e);
        }
    }
}