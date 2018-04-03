using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Leap_V3
{
    /// <summary>
    /// This is the BusinessFinancialManager class which is inherited from the User class
    /// </summary>
    public class BusinessFinancialManager : User
    {
        /*
         * Business
         */
        /// <summary>
        /// This is the no-args constructor for the BusinessFinancialManager class
        /// </summary>
        public BusinessFinancialManager() { }

        /// <summary>
        /// This is the parameterized constructor for the BusinessFinancialManager class
        /// </summary>
        /// <param name="id">Assigns id to ID</param>
        /// <param name="firstname">Assigns firstname to FirstName</param>
        /// <param name="email">Assigns email to Email</param>
        public BusinessFinancialManager(int id, string firstname, string email)
        {
            ID = id;
            FirstName = firstname;
            Email = email;
        }
    }
}