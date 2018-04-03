using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Leap_V3
{
    /// <summary>
    /// Individual class inherited from user
    /// </summary>
    public class Individual : User
    {
        /*
         * Donation, RateNPO, NewsFeed
         */

        /// <summary>
        /// The no arg constructor
        /// </summary>
        public Individual() { }

        /// <summary>
        /// The paramterized constructor that assigns private variables
        /// </summary>
        /// <param name="id">ID of individual</param>
        /// <param name="firstname">First name of Individual</param>
        /// <param name="email">email of Individual</param>
        public Individual(int id, string firstname, string email)
        {
            ID = id;
            FirstName = firstname;
            Email = email;
        }

        /// <summary>
        /// rating of the NPO
        /// </summary>
        /// <param name="rate">rate between 1 - 10</param>
        public void GiveNPORating(int rate) 
        { 
            //TODO
        }
        /// <summary>
        /// Individual donates money
        /// </summary>
        /// <param name="amount">The amount donated</param>
        public void DonateMoney(double amount /*NPO*/)
        {
            //TODO
        }
        /// <summary>
        /// individual volunteers
        /// </summary>
        public void Volunteer(/*NPO*/)
        {
            //TODO
        }
    }
}