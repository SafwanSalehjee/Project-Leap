using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Leap_V3
{
    /// <summary>
    /// News Feed is handled
    /// </summary>
    public class NewsFeed
    {
        /// <summary>
        /// private variables
        /// </summary>
        private string Title;
        private string Body;

        /// <summary>
        /// Accessor and Mutator of title
        /// </summary>
        public string Title1
        {
            get { return Title; }
            set { Title = value; }
        }

        /// <summary>
        /// Accessor and Mutator of body
        /// </summary>
        public string Body1
        {
            get { return Body; }
            set { Body = value; }
        }

        /// <summary>
        /// checks for new updates
        /// </summary>
        /// <param name="ttl"> the new title</param>
        /// <param name="body">the new newsfeed's body</param>
        public void updateNewsFeed(string ttl, string body) {
            Title = ttl;
            Body = body;
        }
    }
}