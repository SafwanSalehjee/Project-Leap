using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Leap_V3
{
    /// <summary>
    /// This is the NPOFinancialManager class inherited from the User class
    /// </summary>
    public class NPOFinancialManager : User
    {
        /// <summary>
        /// Private variable declaration
        /// </summary>
        protected NPO npo;

        /// <summary>
        /// This is the no-args constructor for NPOFinancialManager
        /// </summary>
        public NPOFinancialManager() { }

        /// <summary>
        /// This is the parameterized constructor for NPOFinancialManager
        /// </summary>
        /// <param name="id">ID of the NPO Financial Manager</param>
        /// <param name="firstname">First name of the NPO Financial Manager</param>
        /// <param name="email">Email address of NPO Financial Manager</param>
        public NPOFinancialManager(int id, string firstname, string email)
        {
            ID = id;
            FirstName = firstname;
            Email = email;
        }

        /// <summary>
        /// Accessor and Mutator methods of NPO 
        /// </summary>
        public NPO Npo
        {
            get { return npo; }
            set { npo = value; }
        }
    }
}