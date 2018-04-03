using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Leap_V3
{
    /// <summary>
    /// This is the NPO class that is inherited from the Organisation class
    /// </summary>
    public class NPO : Organisation
    {
        /// <summary>
        /// Private variable declarations
        /// </summary>
        private int ID;
        private string feedAdded;

        /// <summary>
        /// This is the no-args constructor for the NPO class
        /// </summary>
        public NPO()
        { }
        
        /// <summary>
        /// This is the parameterized constructor for the NPO class
        /// </summary>
        /// <param name="number">ID of the NPO</param>
        /// <param name="name">Name of the NPO</param>
        public NPO(long number, string name)
        {
            OrganisationNumber = number;
            OrganisationName = name;
        }

        /// <summary>
        /// Accessor and Mutator methods of ID 
        /// </summary>
        public int ID1
        {
            get { return ID; }
            set { ID = value; }
        }

        /// <summary>
        /// Accessor and Mutator methods of FeedAdded 
        /// </summary>
        public string FeedAdded
        {
            get { return feedAdded; }
            set { feedAdded = value; }
        }

        /// <summary>
        /// This method posts the news feed 
        /// </summary>
        /// <param name="feed">the news feed</param>
        public void PostNewsFeed(NewsFeed feed) 
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            feedAdded = service.addNewsFeed(ID, feed.Title1, feed.Body1);
        }

        //Incomplete Functions
        //public void SendProgressReport(ProgressReport PReport);
    }
}