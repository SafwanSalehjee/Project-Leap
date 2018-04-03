using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Project_Leap_Web_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    /// <summary>
    /// Provides the interface for all API calls
    /// </summary>
    [ServiceContract]
    public interface IService1
    {
        /// <summary>
        /// Add a user to the database
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <param name="password">The user's password</param>
        /// <param name="Type">The user's access level on the system</param>
        /// <param name="OrgNumber">Determines the user's organition or lack there of</param>
        /// <returns>returns bool if the user was added succesfully</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool registerIndividual(String email, String password, int Type, int OrgNumber);

        /// <summary>
        /// It gets number of times a province is repeated in a given table
        /// </summary>
        /// <param name="table">The table that is searched upon</param>
        /// <param name="province">The province looked for</param>
        /// <returns>The amount of times provience is repeated in the givrn table</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        int NumberOfTimes(String table, String province);
        /// <summary>
        /// Adds an organisation to the database
        /// </summary>
        /// <param name="OrgNumber">The organisation's identification number</param>
        /// <param name="OrgName">The name of the organisation</param>
        /// <param name="Street">The street address of the organisation</param>
        /// <param name="Suburb">The suburb of the organisation</param>
        /// <param name="Province">The province of the organisation</param>
        /// <param name="Country">The country of the organisation</param>
        /// <param name="ContactNum">The organisation's contact number</param>
        /// <param name="Industry">The organisation's industry of operation</param>
        /// <param name="OrgType">The type of organisation registering to the system</param>
        /// <returns>returns bool if the organisation was added succesfully</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool addOrganisation(long OrgNumber, string OrgName, string Street, string Suburb, string Province, string Country, string ContactNum, string Industry, int OrgType);

        /// <summary>
        /// Checks the login details of the user
        /// </summary>
        /// <param name="Email">The user's login email</param>
        /// <param name="Password">The user's login password</param>
        /// <returns>returns UserDetail the user details if the user logged in succesfully</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "CheckDetails/?email={Email}&pass={Password}")]
        UserDetail CheckDetails(String Email, String Password);

        /// <summary>
        /// Used to get all users regested on the system
        /// </summary>
        /// <returns>returns User an array of the users on the system</returns>
        [OperationContract]
        [WebGet(UriTemplate = "getUsers")]
        User[] getUsers();

        /// <summary>
        /// Gets all the users from the database
        /// </summary>
        /// <returns>returns Organisation array which is array of organisation</returns>
        [OperationContract]
        Orga[] getOrganisations();

        /// <summary>
        /// Used to get a specific user
        /// </summary>
        /// <param name="UserID">The user's identification on the system</param>
        /// <returns>returns User a single user on the system</returns>
        [OperationContract]
        User getUser(int UserID);

        /// <summary>
        /// Deletes an user off of the system
        /// </summary>
        /// <param name="UserID">The user's identification on the system</param>
        /// <returns>returns bool to determine if the user has been removed</returns>
        [OperationContract]
        bool deleteUser(int UserID);

        /// <summary>
        /// Deletes an organisation off of the system
        /// </summary>
        /// <param name="ordID">The organisation's identification on the system</param>
        /// <returns>returns bool to determine if the organisation has been removed</returns>
        [OperationContract]
        bool deleteOrg(int ordID);

        /// <summary>
        /// Updates the user profile on the system
        /// </summary>
        /// <param name="user">The user's details as a UserDetail</param>
        /// <returns>returns bool to determine if the user has been removed</returns>
        [OperationContract]
        bool UpdateProfile(UserDetail user);

        /// <summary>
        /// Verified the user email to determine if it is in the system
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <returns>returns bool to determine if the email exists</returns>
        [OperationContract]
        bool verifyEmail(string email);

        /// <summary>
        /// Adds news feeds to the system
        /// </summary>
        /// <param name="npoID">The NPO's id on the system</param>
        /// <param name="title">The new feed's title</param>
        /// <param name="body">THe content of the news feed</param>
        /// <returns>returns a string to determine if the news feed has been added</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        String addNewsFeed(int npoID, string title, string body);

        /// <summary>
        /// Used to get all the news feed stored on the system
        /// </summary>
        /// <returns>returns NewF array with all the news feeds that the NPOs have submited</returns>
        [OperationContract]
        NewsF[] GetFeeds();

        /// <summary>
        /// Used to get the NPO's identification in the database
        /// </summary>
        /// <param name="NPOManagerID">The NPO Manager's ID on the system</param>
        /// <returns>returns int the identification of the organisation that the NPO Mangare is controls</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getNPOWithManager/?npoManID={NPOManagerID}")]
        int getNPOWithManager(int NPOManagerID);

        /// <summary>
        /// Used to get the an event with an ID
        /// </summary>
        /// <param name="eventID">The ID of the event on the system</param>
        /// <returns>returns Eve the event details of the event</returns>
        [OperationContract]
        Eve getEvent(int eventID);

        /// <summary>
        /// Gets all the events in the system
        /// </summary>
        /// <param name="UserID">The user's identification on the system</param>
        /// <returns>returns Eve array which contains all events</returns>
        [OperationContract]
        Eve[] getEvents(int userID);

        /// <summary>
        /// Gets all events for a specific NPO
        /// </summary>
        /// <param name="npoID">The NPO's id on the system</param>
        /// <returns>returns Eve array which is all the NPO's events</returns>
        [OperationContract]
        Eve[] getNEvents(int npoID);

        /// <summary>
        /// Adds an event to the system
        /// </summary>
        /// <param name="e">The NPO event</param>
        /// <param name="orgID">The NPO's id on the system</param>
        /// <returns>returns bool to determine if the event was added succesfully</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool addEvent(Eve e, int orgID);

        /// <summary>
        /// Adds a donation request to the system
        /// </summary>
        /// <param name="d">A donation requester which contains donation data</param>
        /// <returns>returns bool to determine if the donation has been added succesfully</returns>
        [OperationContract]
        bool addDonationRequest(DonationRequester d);

        /// <summary>
        /// Gets all donation requests on the system
        /// </summary>
        /// <param name="userID">The user's ID on the system</param>
        /// <returns>returns DonationRequester array which contains all donations</returns>
        [OperationContract]
        DonationRequester[] getAllDonationRequest(int userID);

        /// <summary>
        /// Gets all donations for a specific NPO
        /// </summary>
        /// <param name="npoID">The NPO's id on the system</param>
        /// <returns>returns DonationRequester array which contains all donations of a specific NPO</returns>
        [OperationContract]
        DonationRequester[] getAllNDonationRequest(int npoID);

        /// <summary>
        /// Used to check if a specific donation request received exists
        /// </summary>
        /// <param name="donationRequID">The dontaion request's ID on the system</param>
        /// <returns>returns bool if the request has been received or not</returns>
        [OperationContract]
        bool hasDonatatedReq(int donationRequID);

        /// <summary>
        /// Update a users password
        /// </summary>
        /// <param name="password">The user's new password</param>
        /// <param name="User_ID">The user's ID on the system</param>
        /// <returns>returns bool if the update was successfull</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool UpdatePassword(String password, int User_ID);

        /// <summary>
        /// Get the user's ID using their email address
        /// </summary>
        /// <param name="email">The email address on the system</param>
        /// <returns>returns int the ID of the user</returns>
        [OperationContract]
        int getUserID(string email);

        /// <summary>
        /// Making a dontaion to an NPO
        /// </summary>
        /// <param name="UserId">The user that makes the donation's ID</param>
        /// <param name="donation">The donation request that the user is donating</param>
        /// <returns>returns bool if the donation was successfull</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool addDonation(int UserId, DonationRequester donation);

        /// <summary>
        /// Get a donation request in the system
        /// </summary>
        /// <param name="donationID">The ID of a dontaion in the system</param>
        /// <returns></returns>
        [OperationContract]
        DonationRequester getDonation(int donationID);

        /// <summary>
        /// Gets the donations a user made
        /// </summary>
        /// <param name="userID">The user's id in the system</param>
        /// <returns>returns DonationUser array which contains all donations made by the specific user</returns>
        [OperationContract]
        DonationUser[] getDonationUser(int userID);

        /// <summary>
        /// Gets an organistion from the system
        /// </summary>
        /// <param name="oID"></param>
        /// <returns>returns Organistion which contains an organisation</returns>
        [OperationContract]
        Organisation getOrg(int oID);

        /// <summary>
        /// Gets all users email address's who donated
        /// </summary>
        /// <param name="orgID">The organisation's id number on the system</param>
        /// <returns>returns string array containing email addresses</returns>
        [OperationContract]
        string[] getDonorEmails(int orgID);

        /// <summary>
        /// Add a RSVP to an event
        /// </summary>
        /// <param name="rsvp">The details of the RSVP</param>
        /// <returns>returns bool if the RSVP was successful</returns>
        [OperationContract]
        bool setRSVP(RSVPEvent rsvp);

        /// <summary>
        /// For a user to get the events that they have RSVP
        /// </summary>
        /// <param name="userID">The ID on the user</param>
        /// <returns>returns RSVPEvent array of all the RSVP made by the user</returns>
        [OperationContract]
        RSVPEvent[] getEventUser(int userID);

        /// <summary>
        /// Get the RSVP that an NPO have set
        /// </summary>
        /// <param name="npoID">The NPO of ID on the system</param>
        /// <returns>returns RSVPEvent array of all the RSVP to an NPO's events</returns>
        [OperationContract]
        RSVPEvent[] getGetRSVPList(int npoID);

        /// <summary>
        /// Adds a volunteer to the NPO
        /// </summary>
        /// <param name="vol">The details of the volunteer event</param>
        /// <returns>returns bool to determine is the user volunteered successfully</returns>
        [OperationContract]
        bool setVolunteer(EventVolunteer vol);

        /// <summary>
        /// Gets all NPOs which the user volunteered at
        /// </summary>
        /// <param name="userID">The user's id on the system</param>
        /// <returns>returns EventVolunteer array with all the events the user volunteered at</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getVolunteerUser/?userID={userID}")]
        EventVolunteer[] getVolunteerUser(int userID);

        /// <summary>
        /// Gets all volunteers who volunteered at an organisation
        /// </summary>
        /// <param name="npoID">The NPO's id</param>
        /// <returns>returns EventVolunteer array containing the volunteer details</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getVolunteers/?orgID={npoID}")]
        EventVolunteer[] getVolunteers(int npoID);

        /// <summary>
        /// Allows NPO to comment on volunteer's work
        /// </summary>
        /// <param name="volunteer">The volunteer's details</param>
        /// <returns>returns bool which says that volunteer was successful</returns>
        [OperationContract]
        bool CommentOnVolunteer(EventVolunteer volunteer);
        /// <summary>
        /// Adds a new Fundraising Campaign, Checking if same is not added again.
        /// </summary>
        /// <param name="newFC"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddNewFundraisingCamp(cFundraisingCampaign newFC);

        /// <summary>
        /// getting a specific Fundraising campaign
        /// </summary>
        /// <param name="FC_id">The Id of the fundraising event that the user is looking for</param>
        /// <returns></returns>
        [OperationContract]
        cFundraisingCampaign getFundRaisingCampaign(int FC_id);
        /// <summary>
        /// Uses the addDonation methods to donate to a fund rasing event.
        /// </summary>
        /// <param name="FC_ID">The ID of the Fund raising Campaign donating to</param>
        /// <param name="Doner_ID">The user that is Donating's ID</param>
        /// <param name="Amount">The amount of donation made</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool DonateFC(int FC_ID, int Doner_ID, double Amount);

        /// <summary>
        /// This method calculates and returns the total amount of money generated by the system
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        double getAmountSystemGenerated();

        /// <summary>
        /// Gets an organisations verification status
        /// </summary>
        /// <param name="orgNum">The organisations id number on the system</param>
        /// <returns>returns bool showing if the organisation is verified</returns>
        [OperationContract]
        bool getVerificationStatus(int orgNum);

        /// <summary>
        /// Gets the individuals points
        /// </summary>
        /// <param name="indID">The individuals id on the system</param>
        /// <returns>returns int which is the individuals point</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "PointsInd/?userID={indID}")]
        int getPointsInd(int indID);

        /// <summary>
        /// Gets the businesses points
        /// </summary>
        /// <param name="indID">The businesses id on the system</param>
        /// <returns>returns int which is the businesses point</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "PointsOrg/?OrgID={orgID}")]
        int getPointsOrg(int orgID);

        /// <summary>
        /// Get all fundraising campaigns 
        /// </summary>
        /// <param name="userID">user id on system</param>
        /// <returns>returns cFundraisingCampaign array of all the fundraising Campaigns </returns>
        [OperationContract]
        cFundraisingCampaign[] getAllFundRaisingCampaign(int userID);

        /// <summary>
        /// Get all fundraising campaigns of a specific NPO
        /// </summary>
        /// <param name="NPOID">The NPO's id on the system</param>
        /// <returns>returns cFundraisingCampaign array which contains all the NPO's fundraising campaigns</returns>
        [OperationContract]
        cFundraisingCampaign[] getOwnFundraisingCampaigns(int NPOID);

        /// <summary>
        /// Gets the NPO types to allow the business to filter them
        /// </summary>
        /// <returns>returns string array with the NPO types</returns>
        [OperationContract]
        string[] getNPOTypes();

        /// <summary>
        /// Gets NPOs of the type specified
        /// </summary>
        /// <param name="type">The NPO type</param>
        /// <returns>returns Orga array a list of NPOs of the specified type</returns>
        [OperationContract]
        Orga[] getNPOofType(string type);

        /// <summary>
        /// Sets the FeedBack of an Organisation if the user qualify to review/Rate
        /// </summary>
        /// <param name="Rate"></param>
        /// <param name="Review"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool SetFeedback(int Rate, string Review, int UserID, int OrgID);
        /// <summary>
        /// Gets and displays the average rating of each NPO 
        /// </summary>
        /// <param name="Id_NPO">ID of NPO</param>
        /// <returns>Avg the average rating of the NPO</returns>
        [OperationContract]
        double getAverageRating(int Id_NPO);
        /// <summary>
        /// Add Files to the server side
        /// </summary>
        /// <param name="clientFile">class incapsulating the file</param>
        /// <returns>return bool if the add was successfull</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool setFile(FileClass clientFile, string loc);

        /// <summary>
        /// Add user profile image
        /// </summary>
        /// <param name="userImage"> the user's image</param>
        /// <param name="userID">user id on system</param>
        /// <returns>return bool on succession</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool addUserImage(FileClass userImage, int userID);

        /// <summary>
        /// Add organisation image
        /// </summary>
        /// <param name="orgImage">the organistion's image</param>
        /// <param name="orgID">organisation id on system</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool addOrgImage(FileClass orgImage, int orgNum);

        /// <summary>
        /// Add organisation file for verification
        /// </summary>
        /// <param name="orgFile">organisation's file</param>
        /// <param name="orgID">organisation id</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool addOrgFile(FileClass orgFile, int ogNum);

        /// <summary>
        /// Get user profile image
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns>returns FileClass the image</returns>
        [OperationContract]
        FileClass getUserImage(int userID);

        /// <summary>
        /// Gets the organisation's logo or verification file
        /// </summary>
        /// <param name="orgID">The organisation's id on the system</param>
        /// <param name="Image">If the organisation logo is selected</param>
        /// <returns>returns FileClass which contains a file</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        FileClass getFile(int orgID, bool Image);

        /// <summary>
        /// Verifies the organisation
        /// </summary>
        /// <param name="orgID">The organisation's id on the system</param>
        /// <param name="Image">If the organisation  is verified</param>
        /// <returns>returns bool which determines if the organisation is verified</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool verifyOrg(int OrgID, bool verify);

        /// <summary>
        /// Gets the total recieved from donations
        /// </summary>
        /// <param name="OrgID">The organisation's id on the system</param>
        /// <returns>returns double which is the total amount from donations</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "TotalRecievedFromDonations/?orgID={OrgID}")]
        double TotalRecievedFromDonations(int OrgID);

        /// <summary>
        /// Gets the total donated
        /// </summary>
        /// <param name="UserID">The user's id on the system</param>
        /// <returns>returns double which is the total amount from donations</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "TotalDonated/?userID={UserID}")]
        double TotalDonated(int UserID);

        /// <summary>
        /// Gets the next upcoming event
        /// </summary>
        /// <param name="OrgID">The organisation's id on the system</param>
        /// <returns>returns mobileEve which is the next upcoming event</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetNextEvent/?orgID={OrgID}")]
        mobileEve GetNextEvent(int OrgID);

        /// <summary>
        /// Gets the total fundraising campaign progress
        /// </summary>
        /// <param name="OrgID">The organisation's id on the system</param>
        /// <returns>returns mobileFC which is the fundraising campaign</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetTotalFCProgress/?orgID={OrgID}")]
        mobileFC GetTotalFCProgress(int OrgID);

        /// <summary>
        /// Gets the events for the NPO
        /// </summary>
        /// <param name="OrgID">The organisation's id on the system</param>
        /// <returns>returns mobileEve array which is an array of events</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetMobileEvents/?orgID={OrgID}")]
        mobileEve[] GetMobileEvents(int OrgID);

        /// <summary>
        /// Gets the next volunteer event
        /// </summary>
        /// <param name="OrgID">the users id</param>
        /// <returns>returns VolunteerEvent which is the next volunteer</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getNextVolunteer/?userID={UserID}")]
        EventVolunteer getNextVolunteer(int UserID);

        /// <summary>
        /// Gets the next NPO event the business manager is attending
        /// </summary>
        /// <param name="OrgID">the users id</param>
        /// <returns>returns Eve which is the next event</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getNextNPOEvent/?userID={UserID}")]
        mobileEve getNextNPOEvent(int UserID);

        /// <summary>
        /// Gets the events the nusiness manager is attending
        /// </summary>
        /// <param name="OrgID">the users id</param>
        /// <returns>returns mobileEve array which is an array of events</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetMobileEventsAtt/?UserID={userID}")]
        mobileEve[] GetMobileEventsAtt(int userID);

        /// <summary>
        /// Capture the volunteer data from the mobile app
        /// </summary>
        /// <param name="volID">The volunteer event ID</param>
        /// <param name="hours">The hours volunteered</param>
        /// <param name="comment">Comment on volunteer</param>
        /// <returns>returns bool determining is the capturing was successful</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "CaptureVolTimeMobile/?VolID={volID}&Hours={hours}&Comment={comment}")]
        bool CaptureVolTimeMobile(int volID, int hours, string comment);

        /// <summary>
        /// Check for badge and update if badge have been acheived
        /// </summary>
        /// <param name="userID">the users id</param>
        /// <param name="BadgeID">the badge id</param>
        /// <returns>returns bool which determines if the user has the badege</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool checkBadge(int userID, int BadgeID);

        /// <summary>
        /// Gets the number of badges the user earned
        /// </summary>
        /// <param name="UserID">the users id</param>
        /// <returns>returns int which is the number of user badges</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getNumOfBadgesEarned/?userID={UserID}")]
        int getNumOfBadgesEarned(int UserID);

        /// <summary>
        /// Gets the daily donations for reports for NPOs
        /// </summary>
        /// <param name="orgID">the organisations id</param>
        /// <returns>returns reportDonation[] array which is donations for reports</returns>
        [OperationContract]
        reportDonation[] getAllDailyDonations(int orgID);

        /// <summary>
        /// Gets the daily donations for reports for donors
        /// </summary>
        /// <param name="userID">the users id</param>
        /// <returns>returns reportDonation[] array which is donations for reports</returns>
        [OperationContract]
        reportDonation[] getAllDailyDonationsUser(int userID);

        /// <summary>
        /// Gets all the volunteers ordered by provinces
        /// </summary>
        /// <returns>returns reportVolunteers array which has all volunteers according to province</returns>
        [OperationContract]
        reportVolunteers[] getVolunteersByProvince();

        /// <summary>
        /// Get the amount the system made from dinations
        /// </summary>
        /// <returns>returns reportDonation the date and amount per date</returns>
        [OperationContract]
        reportDonation[] getSystemFund();

        /// <summary>
        /// Gets the top 10 donating businesses
        /// </summary>
        /// <returns>returns reportBusDon array which contains the busineeses</returns>
        [OperationContract]
        reportBusDon[] getTopBusDon();

        /// <summary>
        /// Gets the fundraising campaigns completion currently held
        /// </summary>
        /// <param name="orgID">the organisations id</param>
        /// <returns>returns reportFC array which contains the fundraising campaigns details</returns>
        [OperationContract]
        reportFC[] getFCReports(int orgID);

        /// <summary>
        /// Gets the volunteers that have showed up versus not showed up for a specific NPO
        /// </summary>
        /// <param name="orgID">the organisations id</param>
        /// <returns>returns Double which is the amount of volunteers that have showed up</returns>
        [OperationContract]
        double getVolsShowingUp(int orgID);

        /// <summary>
        /// Gets the fundraising campaigns success rate for a specific NPO
        /// </summary>
        /// <param name="orgID">the organisations id</param>
        /// <returns>returns Double which is the percentage successfull fundraising campaigns</returns>
        [OperationContract]
        double getFCSuccessRate(int orgID);

        /// <summary>
        ///  Calculates the total activity(# events + # dontaion requests + # fc) over all the NPOs
        /// </summary>
        /// <returns>the activity of the npos</returns>
        [OperationContract]
        activity[] getNPOActivity();

        
        /// <summary>
        /// Report on the Most Active User using points
        /// </summary>
        /// <returns>returns reportBusDon array</returns>
        [OperationContract]
        reportBusDon[] MostActiveUser();

        /// <summary>
        /// Targets the user to show donations of NPOs they like to support
        /// </summary>
        /// <param name="userID">the users id</param>
        /// <returns>returns string representing the NPOs industry</returns>
        [OperationContract]
        string targetedDonations(int userID);

        /// <summary>
        /// Type of NPO
        /// </summary>
        /// <param name="Province">The NPOs province</param>
        /// <returns>returns Support</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Support TypeMostSupportInArea(string Province);

        /// <summary>
        /// Which Supportted in the Type category
        /// </summary>
        /// <param name="Type">The NPO type</param>
        /// <returns>returns Support</returns>
        [OperationContract]
        Support MostSupportByType(string Type);

        /// <summary>
        /// All NPOs return with a type in the parameter
        /// </summary>
        /// <param name="Type">The NPO type</param>
        /// <returns>returns Support array</returns>
        [OperationContract]
        Support[] MostSupportInType(string Type);

        /// <summary>
        /// How many Organisation are there in a specific industry
        /// </summary>
        /// <param name="Industry">he NPO industry</param>
        /// <returns>returns Integer</returns>
        [OperationContract]
        int NumOfOrgByIndustry(string Industry);

        /// <summary>
        /// Report on Number of Users registered per day
        /// </summary>
        /// <returns>returns reportDonation array</returns>
        [OperationContract]
        reportDonation[] getDailyUserRegistration();

        /// <summary>
        /// Report on Number of organisation registered per day
        /// </summary>
        /// <returns>returns reportDonation array</returns>
        [OperationContract]
        reportDonation[] getDailyOrganisationRegistration();

        /// <summary>
        /// Report which counts each users badges recieved
        /// </summary>
        /// <returns>returns badgesReport array which contains the user's name and number of badges</returns>
        [OperationContract]
        badgesReport[] getUserBadgesCount();

        /// <summary>
        /// Gets the count of all ratings of a specific value
        /// </summary>
        /// <param name="orgID">the organisations id</param>
        /// <returns>returns ratingsReport array which contains the rating value and the count at that value</returns>
        [OperationContract]
        ratingsReport[] getNPORatingReport(int orgID);

        /// <summary>
        /// Gets the donations recieved and sorts them by month or year
        /// </summary>
        /// <param name="orgID">the organisations id</param>
        /// <param name="sortBy">the soprting value</param>
        /// <returns>returns reportDonation array</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        reportDonation[] getDonationsForComparison(int orgID, string sortBy);

        /// <summary>
        /// Determines if there was any new donation income recieved
        /// </summary>
        /// <param name="orgID">the organisations id</param>
        /// <param name="lastOnline">last time the user was on the system</param>
        /// <returns>returns boolean to determine if the NPO received a donation</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool chechForNewDonations(int orgID, DateTime lastOnline);
    }

    /// <summary>
    /// Encapsulates all details to report on NPO ratings
    /// </summary>
    [DataContract]
    public class ratingsReport
    {
        string value;
        int count;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int Count
        {
            get { return count; }
            set { count = value; }
        }


    }

    /// <summary>
    /// Encapsulates all details to report on Badges
    /// </summary>
    [DataContract]
    public class badgesReport
    {
        string name;
        int number;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int Number
        {
            get { return number; }
            set { number = value; }
        }


    }

    /// <summary>
    /// Encapsulates all details to report on an NPOs support
    /// </summary>
    [DataContract]
    public class Support
    {
        int Donationvalue;
        int VolunteerValue;
        int SupportValue;
        string Type;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int donationvalue
        {
            get { return Donationvalue; }
            set { Donationvalue = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string type
        {
            get { return Type; }
            set { Type = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int volunteerValue
        {
            get { return VolunteerValue; }
            set { VolunteerValue = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int supportValue
        {
            get { return SupportValue; }
            set { SupportValue = value; }
        }

    }

    /// <summary>
    /// Encapsulates all details to report on Activity
    /// </summary>
    [DataContract]
    public class activity
    {
        int total;
        int first;
        int second;
        int third;
        string sValue;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string SValue
        {
            set { sValue = value; }
            get { return sValue; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int First
        {
            set { first = value; }
            get { return first; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int Second
        {
            set { second = value; }
            get { return second; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int Third
        {
            set { third = value; }
            get { return third; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int Total
        {
            set { total = first + second + third; }
            get { return total; }
        }

    }

    /// <summary>
    /// Encapsulates all details to report on Fundraising campaigns
    /// </summary>  
    [DataContract]
    public class reportFC
    {
        string title;
        double precentage;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public double Precentage
        {
            get { return precentage; }
            set { precentage = value; }
        }
    }

    /// <summary>
    /// Encapsulates all details to report on Donation businesses
    /// </summary>
    [DataContract]
    public class reportBusDon
    {
        string name;
        double amount;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }

    /// <summary>
    /// Encapsulates all details to report on Volunteers
    /// </summary>
    [DataContract]
    public class reportVolunteers
    {
        int volAmounts;
        string province;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int VolAmounts
        {
            get { return volAmounts; }
            set { volAmounts = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Province
        {
            get { return province; }
            set { province = value; }
        }
    }

    /// <summary>
    /// Encapsulates all details to report on donations
    /// </summary>
    [DataContract]
    public class reportDonation
    {
        double amount;
        string date;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
    }

    /// <summary>
    /// Encapsulates all details to mobile fundraising campaign
    /// </summary>
    [DataContract]
    public class mobileFC
    {
        double current;
        double target;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public double Current
        {
            get { return current; }
            set { current = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public double Target
        {
            get { return target; }
            set { target = value; }
        }
    }

    /// <summary>
    /// Encapsulates all details to mobile event
    /// </summary>
    [DataContract]
    public class mobileEve
    {
        string name;
        string date;
        string time;
        string location;
        string npoName;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string NpoName
        {
            get { return npoName; }
            set { npoName = value; }
        }
    }

    /// <summary>
    /// Encapsulates all details to file
    /// </summary>
    [DataContract]
    public class FileClass
    {
        string filePath;
        byte[] fileBytes;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string FilePath
        {
            set { filePath = value; }
            get { return filePath; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public byte[] FileBytes
        {
            set { fileBytes = value; }
            get { return fileBytes; }
        }
    }

    /// <summary>
    /// Encapsulates all details to volunteer
    /// </summary>
    [DataContract]
    public class EventVolunteer
    {
        int userID;
        int orgID;
        int volunteerID;
        string ornName;
        string userEmail;
        string userFN;
        string userLN;
        DateTime volDate;
        int hours;
        string comment;
        string shortDate;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int OrgID
        {
            get { return orgID; }
            set { orgID = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int VolunteerID
        {
            get { return volunteerID; }
            set { volunteerID = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public DateTime VolDate
        {
            get { return volDate; }
            set { volDate = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string OrnName
        {
            get { return ornName; }
            set { ornName = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string UserEmail
        {
            get { return userEmail; }
            set { userEmail = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string UserFN
        {
            get { return userFN; }
            set { userFN = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string UserLN
        {
            get { return userLN; }
            set { userLN = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string ShortDate
        {
            get { return shortDate; }
            set { shortDate = value; }
        }
    }

    /// <summary>
    /// Encupsulates all details to make RSVP
    /// </summary>
    [DataContract]
    public class RSVPEvent
    {
        int user;
        int eventID;
        private string attendance;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int User
        {
            get { return user; }
            set { user = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int EventID
        {
            get { return eventID; }
            set { eventID = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Attendance
        {
            get { return attendance; }
            set { attendance = value; }
        }
    }

    /// <summary>
    /// Contains the amount of a donaiton as well as the date the donations was made and the NPO name that receives the donation
    /// </summary>
    [DataContract]
    public class DonationUser
    {
        double amount;
        DateTime date;
        string npoName;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string NpoName
        {
            get { return npoName; }
            set { npoName = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }

    /// <summary>
    /// Encupsulates all details required to make donations
    /// </summary>
    [DataContract]
    public class MakeDonation
    {
        int userID;
        int orgID;
        int regNumber;
        double amount;
        DateTime date;
        int quantity;
        string discription;
        int type;
        string equipmentName;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int OrgID
        {
            get { return orgID; }
            set { orgID = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int RegNumber
        {
            get { return regNumber; }
            set { regNumber = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Discription
        {
            get { return discription; }
            set { discription = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string EquipmentName
        {
            get { return equipmentName; }
            set { equipmentName = value; }
        }
    }

    /// <summary>
    ///  Encupsulates all details for a Donation Request
    /// </summary>
    [DataContract]
    public class DonationRequester
    {
        DonationRequest donate;
        int orgID;
        string discription;
        int type;
        double amount;
        DateTime date;
        string npoName;
        int ReqNum;
        bool inprogress;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public bool Inprogress
        {
            get { return inprogress; }
            set { inprogress = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int ReqNum1
        {
            get { return ReqNum; }
            set { ReqNum = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string NpoName
        {
            get { return npoName; }
            set { npoName = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int OrgID
        {
            get { return orgID; }
            set { orgID = value; }

        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Discription
        {
            get { return discription; }
            set { discription = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public DonationRequest Donate
        {
            get { return donate; }
            set { donate = value; }
        }

    }

    /// <summary>
    /// Encupsulates all details for the Event class
    /// </summary>
    [DataContract]
    public class Eve
    {
        Event eve;
        int orgID;
        string name;
        string location;
        DateTime date;
        string host;
        string description;
        string time;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public Event EventValue
        {
            get { return eve; }
            set { eve = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int OrgID
        {
            get { return orgID; }
            set { orgID = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public DateTime DateValue
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
    }

    /// <summary>
    /// Encupsulates all details of the organisation
    /// </summary>
    [DataContract]
    public class Orga
    {
        int orgID;
        int orgNum;
        string orgName;
        string street;
        string suburb;
        string province;
        int type;
        string contactNum;
        string industry;
        bool verified;
        bool banned;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public bool Banned
        {
            set { banned = value; }
            get { return banned; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int OrgID
        {
            get { return orgID; }
            set { orgID = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int OrgNum
        {
            get { return orgNum; }
            set { orgNum = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string OrgName
        {
            get { return orgName; }
            set { orgName = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Suburb
        {
            get { return suburb; }
            set { suburb = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Province
        {
            get { return province; }
            set { province = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string ContactNum
        {
            get { return contactNum; }
            set { contactNum = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Industry
        {
            get { return industry; }
            set { industry = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public bool Verified
        {
            get { return verified; }
            set { verified = value; }
        }
    }

    /// <summary>
    /// Encupsulates all details of the user
    /// </summary>
    [DataContract]
    public class UserDetail
    {
        int accessLvl;
        String Email;
        String FirstName;
        SystemUser user;
        bool banned;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public bool Banned
        {
            set { banned = value; }
            get { return banned; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public String EmailValue
        {
            get { return Email; }
            set { Email = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public String FirstNameValue
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int AccessLvl
        {
            get { return accessLvl; }
            set { accessLvl = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public SystemUser userValue
        {
            get { return user; }
            set
            {
                user = value;
                user.Password = null;
            }
        }

    }

    /// <summary>
    /// Encupsulates all details of a user to be listed
    /// </summary>
    [DataContract]
    public class User
    {

        int ID;
        String FirstName;
        String LastName;
        String Email;
        int Type; 
        bool Banned;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int IDValue
        {
            get { return ID; }
            set { ID = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public String FirstNameValue
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public String LastNameValue
        {
            get { return LastName; }
            set { LastName = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public String EmailValue
        {
            get { return Email; }
            set { Email = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int TypeValue
        {
            get { return Type; }
            set { Type = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public bool BannedValue
        {
            get { return Banned; }
            set { Banned = value; }
        }
    }
    /// <summary>
    /// Encupsulates all details of a FundraisingCampaigns in Database
    /// </summary>
    [DataContract]
    public class cFundraisingCampaign
    {
        Orga vOrganisation;
        int OrgID;
        string vTitle;
        string vDescription;
        double vCurrentAmount;
        double vTotalAmount;
        int idF;

        /// <summary>
        /// Accessor and Mutators
        /// </summary>
        [DataMember]
        public int IDF
        {
            set { idF = value; }
            get { return idF; }
        }

        /// <summary>
        /// Accessor and Mutators
        /// </summary>
        [DataMember]
        public Orga VOrganisation
        {
            get { return vOrganisation; }
            set { vOrganisation = value; }
        }
        /// <summary>
        /// Accessor and Mutators
        /// </summary>
        [DataMember]
        public int OrgID1
        {
            get { return OrgID; }
            set { OrgID = value; }
        }
        /// <summary>
        /// Accessor and Mutators
        /// </summary>
        [DataMember]
        public string VTitle
        {
            get { return vTitle; }
            set { vTitle = value; }
        }
        /// <summary>
        /// Accessor and Mutators
        /// </summary>
        [DataMember]
        public string VDescription
        {
            get { return vDescription; }
            set { vDescription = value; }
        }

        /// <summary>
        /// Accessor and Mutators
        /// </summary>
        [DataMember]
        public double VCurrentAmount
        {
            get { return vCurrentAmount; }
            set { vCurrentAmount = value; }
        }

        /// <summary>
        /// Accessor and Mutators
        /// </summary>
        [DataMember]
        public double VTotalAmount
        {
            get { return vTotalAmount; }
            set { vTotalAmount = value; }
        }

    }
    
    /// <summary>
    /// Encupsulates all details
    /// </summary>
    [DataContract]
    public class NewsF
    {
        int OrgID;
        string OrgName;
        string title;
        string body;

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public int OrgID1
        {
            get { return OrgID; }
            set { OrgID = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string OrgName1
        {
            get { return OrgName; }
            set { OrgName = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Title1
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// Accessor and Mutator
        /// </summary>
        [DataMember]
        public string Body1
        {
            get { return body; }
            set { body = value; }
        }
    }
}
