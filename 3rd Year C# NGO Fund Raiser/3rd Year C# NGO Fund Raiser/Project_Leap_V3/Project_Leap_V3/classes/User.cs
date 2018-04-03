using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Leap_V3
{
    /// <summary>
    /// This is the User class
    /// </summary>
    public class User
    {
        /// <summary>
        /// Private variable declarations
        /// </summary>
        protected int ID;
        protected string FirstName;   
        private string LastName;
        private string Gender;
        private string Title;
        protected string Email;
        private DateTime DateOfBirth;
        private const string COUNTRY = "South Africa";
        private int AccessLvl;
        /*
         * EmailSender
         */

        /// <summary>
        /// This is the no-args constructor for the User class
        /// </summary>
        public User(){}

        /// <summary>
        /// This is the parameterized constructor for the User class
        /// </summary>
        /// <param name="id">ID of User</param>
        /// <param name="firstname">First name of User</param>
        /// <param name="email">Email of User</param>
        public User(int id, string firstname, string email)
        {
            ID = id;
            FirstName = firstname;
            Email = email;
        }

        /// <summary>
        /// Accessor and Mutator of FirstName1
        /// </summary>
        public string FirstName1
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        /// <summary>
        /// Accessor and Mutator of LastName1
        /// </summary>
        public string LastName1
        {
            get { return LastName; }
            set { LastName = value; }
        }

        /// <summary>
        /// Accessor and Mutator of Gender1
        /// </summary>
        public string Gender1
        {
            get { return Gender; }
            set { Gender = value; }
        }
        /// <summary>
        /// Accessor and Mutator of Title1
        /// </summary>
        public string Title1
        {
            get { return Title; }
            set { Title = value; }
        }

        /// <summary>
        /// Accessor and Mutator of Email1
        /// </summary>
        public string Email1
        {
            get { return Email; }
            set { Email = value; }
        }

        /// <summary>
        /// Accessor and Mutator of ID1
        /// </summary>
        public int ID1
        {
            get { return ID; }
            set { ID = value; }
        }
        /// <summary>
        /// Accessor and Mutator of DateOfBirth1
        /// </summary>
        public DateTime DateOfBirth1
        {
            get { return DateOfBirth; }
            set { DateOfBirth = value; }
        }

        /// <summary>
        /// Accessor of COUNTRY1
        /// </summary>
        public string COUNTRY1
        {
            get { return COUNTRY; }
        }

        /// <summary>
        /// Accessor and Mutator of AccessLvl1
        /// </summary>
        public int AccessLvl1
        {
            get { return AccessLvl; }
            set { AccessLvl = value; }
        }
    }
}