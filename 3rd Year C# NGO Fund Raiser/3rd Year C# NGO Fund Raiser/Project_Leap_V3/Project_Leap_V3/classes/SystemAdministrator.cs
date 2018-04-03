using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Leap_V3
{
    /// <summary>
    /// Inherits the User Class
    /// </summary>
    public class SystemAdministrator : User
    {
        /// <summary>
        /// No arg constructor
        /// </summary>
        public SystemAdministrator() { }
        
        /// <summary>
        /// parameterized constructor.
        /// </summary>
        /// <param name="id">System Administrator's ID</param>
        /// <param name="firstname">System Administrator's First name</param>
        /// <param name="email">System Administrator's Email</param>
        public SystemAdministrator(int id, string firstname, string email)
        {
            ID = id;
            FirstName = firstname;
            Email = email;
        }

        /// <summary>
        /// Adds a new Systtem Manager
        /// </summary>
        public void AddSystemManager(/*SysMan*/)
        { 
            //TODO
        }

        /// <summary>
        /// Adds a new System Admistrator
        /// </summary>
        public void AddSystemAdmin(/*SysADM*/)
        {
            //TODO
        }
        /// <summary>
        /// removes a User from the system
        /// </summary>
        public void RemoveUser(/*UserID*/)
        {
            //TODO
        }
    }
}