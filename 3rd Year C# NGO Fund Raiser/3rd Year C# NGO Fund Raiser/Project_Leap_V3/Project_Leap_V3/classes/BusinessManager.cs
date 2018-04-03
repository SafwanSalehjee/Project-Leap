using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Leap_V3
{
    /// <summary>
    /// This is the BusinessManager class which is inherited from the BusinessFinancialManager class
    /// </summary>
    public class BusinessManager : BusinessFinancialManager
    {
        /*
         * RateNPO and Donate
         */
        /// <summary>
        /// This is a private variable
        /// </summary>
        private bool added;

        /// <summary>
        /// This is the no-args constructor for the BusinessManager class
        /// </summary>
        public BusinessManager() { }

        /// <summary>
        /// This is the parameterised constructor for the BusinessManager class
        /// </summary>
        /// <param name="id">Assigns id to ID</param>
        /// <param name="firstname">Assigns firstname to FirstName</param>
        /// <param name="email">Assigns email to Email</param>
        public BusinessManager(int id, string firstname, string email)
        {
            ID = id;
            FirstName = firstname;
            Email = email;
        }

        /// <summary>
        /// This is an Accessor and Mutator method for Added
        /// </summary>
        public bool Added
        {
            get { return added; }
            set { added = value; }
        }
        
        /// <summary>
        /// This gives an NPO Event a rating
        /// </summary>
        public void GiveNPOEventRating() 
        { 
            //TODO
        }

        /// <summary>
        /// This gives an NPO a rating
        /// </summary>
        public void GiveNPORating() 
        { 
            //TODO
        }

        /// <summary>
        /// This method donates money to an NPO
        /// </summary>
        /// <param name="amount">This is the amount that will be donated</param>
        public void DonateMoney(double amount /*NPO*/)
        {
            //TODO
        }

        /// <summary>
        /// This method donates equipment to an NPO
        /// </summary>
        /// <param name="equipmentName">This is the name of the equipment that will be donated</param>
        /// <param name="equipmentValue">This is the amount of particular items to be donated</param>
        public void DonateEquipment(string equipmentName, double equipmentValue /*NPO*/) 
        {
            //TODO
        }

        /// <summary>
        /// This method will be called when a user RSVPs to an Event
        /// </summary>
        /// <param name="eventNum">This is the ID of the event</param>
        public void RSVPEvent(int eventNum) 
        { 
            //TODO
        }

        /// <summary>
        /// This method adds a Financial Manager staff member
        /// </summary>
        public void AddFMStaff(/*BusFinMan*/)
        {
            //TODO
        }

        /// <summary>
        /// This method adds a Manager staff member
        /// </summary>
        public void ADDManagerStaff(/*BusMan*/)
        {
            //TODO
        }
    }
}