using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Leap_V3
{
    /// <summary>
    /// Inherits the User Class
    /// </summary>
    public class SystemManager : User
    {
        /// <summary>
        /// No arg constructor
        /// </summary>
        public SystemManager() { }

        /// <summary>
        /// parameterized constructor.
        /// </summary>
        /// <param name="id">System Manager's ID</param>
        /// <param name="firstname">System Manager's First name</param>
        /// <param name="email">System Manager's Email</param>
        public SystemManager(int id, string firstname, string email)
        {
            ID = id;
            FirstName = firstname;
            Email = email;
        }

        /// <summary>
        /// checks if the organisation is legit
        /// </summary>
        /// <returns>bool value indicating the legitimacy of the organisation</returns>
        public bool Verify(/*Organisation*/) 
        { 
            //TODO
            return true;
        }
    }
}