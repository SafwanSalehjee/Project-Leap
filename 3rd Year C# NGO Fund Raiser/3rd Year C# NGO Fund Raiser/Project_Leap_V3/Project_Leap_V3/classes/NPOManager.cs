using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Leap_V3
{
    /// <summary>
    /// This is the NPOManager class that is inherited from the NPOFinancialManager class
    /// </summary>
    public class NPOManager : NPOFinancialManager
    {
        /*
         * FundraisingCampaign, Event Donation
         */
        /// <summary>
        /// Private variable declaration
        /// </summary>
        private bool added;

        /// <summary>
        /// This is the no-args constructor for the NPOManager class
        /// </summary>
        public NPOManager() { }

        /// <summary>
        /// This is the parameterized constructor for the NPOManager class
        /// </summary>
        /// <param name="id">ID of NPO Manager</param>
        /// <param name="firstname">First name of NPO Manager</param>
        /// <param name="email">email address of NPO Manager</param>
        public NPOManager(int id, string firstname, string email)
        {
            ID = id;
            FirstName = firstname;
            Email = email;
        }

        /// <summary>
        /// Accessor method of Added
        /// </summary>
        public bool Added
        {
            get { return added; }
        }

        /// <summary>
        /// This method starts the donation request
        /// </summary>
        public void StartDonationRequest()
        { 
            //TODO
        }

        /// <summary>
        /// This method starts an event
        /// </summary>
        public void StartEvent() 
        { 
            //TODO
        }

        /*
         * StartFundraisingCampaign
         */

        /// <summary>
        /// This method adds a Financial Manager Staff Member
        /// </summary>
        public void AddFMStaff(/*NPOFinMan*/) 
        { 
            //TODO
        }

        /// <summary>
        /// This method adds a Manager staff member
        /// </summary>
        public void ADDManagerStaff(/*NPOMan*/) 
        { 
            //TODO
        }

        /// <summary>
        /// This method sends a progress report
        /// </summary>
        public void SendProgressReport(/*PregressReport*/) 
        { 
            //TODO
        }

        /// <summary>
        /// This method posts a news feed
        /// </summary>
        /// <param name="feed">the news feed to be posted</param>
        public void PostNewsFeed(NewsFeed feed) 
        {
            npo.PostNewsFeed(feed);
        }
    }
}