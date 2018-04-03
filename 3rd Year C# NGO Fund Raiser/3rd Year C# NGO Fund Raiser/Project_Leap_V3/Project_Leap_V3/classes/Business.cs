using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Leap_V3
{
    /// <summary>
    /// This is the Business class which is inherited from the Organisation class
    /// </summary>
    public class Business : Organisation
    {
        /// <summary>
        /// This is the no-args constructor for the Business class
        /// </summary>
        public Business()
        { }

        /// <summary>
        /// This is the parameterised constructor for the Business class
        /// </summary>
        /// <param name="number">Assigns number to OrganisationNumber</param>
        /// <param name="name">Assigns name to OrganisationName</param>
        public Business(long number, string name)
        {
            OrganisationName = name;
            OrganisationNumber = number;
        }

        /*Incomplete Void

        public void ReadNewsFeed(NewsFeed feed)
        {

        }
         **/
    }
}