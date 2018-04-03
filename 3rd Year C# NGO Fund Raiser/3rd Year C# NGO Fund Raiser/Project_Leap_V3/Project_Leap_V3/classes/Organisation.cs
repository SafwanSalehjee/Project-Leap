using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Leap_V3
{
    /// <summary>
    /// This is the Organisation class
    /// </summary>
    public class Organisation
    {
        /// <summary>
        /// Private variable declarations
        /// </summary>
        protected long OrganisationNumber;
        protected string OrganisationName;
        private string Street;
        private string Suburb;
        private string Province;
        private const string COUNTRY = "South Africa";
        private string ContactNumber;
        private string Industry;

        /// <summary>
        /// Accessor and Mutator methods of OrganisationNumber1 
        /// </summary>
        public long OrganisationNumber1
        {
            get { return OrganisationNumber; }
            set { OrganisationNumber = value; }
        }

        /// <summary>
        /// Accessor and Mutator methods of OrganisationName1
        /// </summary>
        public string OrganisationName1
        {
            get { return OrganisationName; }
            set { OrganisationName = value; }
        }

        /// <summary>
        /// Accessor and Mutator methods of Street1
        /// </summary>
        public string Street1
        {
            get { return Street; }
            set { Street = value; }
        }

        /// <summary>
        /// Accessor and Mutator methods of Suburb1
        /// </summary>
        public string Suburb1
        {
            get { return Suburb; }
            set { Suburb = value; }
        }

        /// <summary>
        /// Accessor and Mutator methods of Province1
        /// </summary>
        public string Province1
        {
            get { return Province; }
            set { Province = value; }
        }

        /// <summary>
        /// Accessor method of COUNTRY1
        /// </summary>
        public string COUNTRY1
        {
            get { return COUNTRY; }
        }

        /// <summary>
        /// Accessor and Mutator methods of ContactNumber1
        /// </summary>
        public string ContactNumber1
        {
            get { return ContactNumber; }
            set { ContactNumber = value; }
        }

        /// <summary>
        /// Accessor and Mutator methods of Industry1
        /// </summary>
        public string Industry1
        {
            get { return Industry; }
            set { Industry = value; }
        }
        /*
         * FileReader
         * NewsFeed
         * ProgressReport
         * */
        /// <summary>
        /// Private variable declaration
        /// </summary>
        private int OrganisaionType;

        /// <summary>
        /// Accessor and Mutator methods of OrganisationType1
        /// </summary>
        public int OrganisaionType1
        {
            get { return OrganisaionType; }
            set { OrganisaionType = value; }
        }

        /// <summary>
        /// This is the no-args constructor for the Organisation class 
        /// </summary>
        public Organisation()
        { 
            
        }

        /// <summary>
        /// This is the parameterized constructor of the Organisation class
        /// </summary>
        /// <param name="number">ID of Organisation</param>
        /// <param name="name">Name of Organisation</param>
        public Organisation(long number, string name)
        {
            OrganisationNumber = number;
            OrganisationName = name;

        }
        
    }
}