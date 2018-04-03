using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Project_Leap_Web_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        Project_Leap_LinQDataContext dbObjects = new Project_Leap_LinQDataContext();

        public bool registerIndividual(String email, String password, int Type, int OrgNumber)
        {
            bool RegisterSuccessful = false;

            try
            {
                var c = from b in dbObjects.SystemUsers select b;
                bool regIndFlag = false;

                foreach (SystemUser a in c)
                {
                    if (a.Email.Equals(email))
                    {
                        regIndFlag = true;
                    }
                }

                if (regIndFlag == false)
                {
                    SystemUser newUser = new SystemUser();
                    newUser.Email = email;
                    newUser.Password = password;
                    newUser.AccessLevel = Type;
                    newUser.Country = "South Africa";
                    newUser.Continent = "Africa";
                    newUser.RegistrationDate = Convert.ToDateTime(System.DateTime.Today.ToString());
                    newUser.Banned = false;
                    dbObjects.SystemUsers.InsertOnSubmit(newUser);
                    dbObjects.SubmitChanges();

                    RegisterSuccessful = true;
                }

                var z = from b in dbObjects.SystemUsers select b;

                if (OrgNumber > 0)
                {
                    foreach (SystemUser u in z)
                    {
                        if (u.Email.Equals(email))
                        {
                            var orgs = from b in dbObjects.Organisations select b;

                            foreach (Organisation o in orgs)
                            {
                                if (o.OrganisationNumber == OrgNumber)
                                {
                                    Manager newManager = new Manager();
                                    newManager.UserID = u.UserID;
                                    newManager.OrganisationID = o.OrganisationID;
                                    dbObjects.Managers.InsertOnSubmit(newManager);
                                    dbObjects.SubmitChanges();
                                    break;
                                }
                            }

                            break;
                        }
                    }
                }
                else
                {
                    foreach (SystemUser u in z)
                    {
                        if (u.AccessLevel == 5)
                        {
                            if (u.Email.Equals(email))
                            {
                                Individual newInd = new Individual();
                                newInd.UserID = u.UserID;
                                newInd.Point = 0;
                                dbObjects.Individuals.InsertOnSubmit(newInd);
                                dbObjects.SubmitChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RegisterSuccessful = false;
            }
            return RegisterSuccessful;
        }

        public int NumberOfTimes(String table, String province)
        {
            int NumProInOrg = 0;
            if (table == "Organisation")
            {
                var c = from b in dbObjects.Organisations select b;
                
                foreach (Organisation a in c)
                {
                    if (a.Province.Equals(province))
                    {
                        NumProInOrg++;
                    }
                }
            }

            else if (table == "SystemUser")
            {
                var c = from b in dbObjects.SystemUsers select b;

                foreach (SystemUser a in c)
                {
                    if (a.Province.Equals(province))
                    {
                        NumProInOrg++;
                    }
                }
            }
            return NumProInOrg;
        }

        public bool addOrganisation(long OrgNumber, string OrgName, string Street, string Suburb, string Province, string Country, string ContactNum, string Industry, int OrgType)
        {
            bool RegisterSuccessful = false;

            try
            {
                var c = from b in dbObjects.Organisations select b;
                bool regOrgFlag = false;

                foreach (Organisation a in c)
                {
                    if (a.OrganisationNumber == (int)OrgNumber)
                    {
                        regOrgFlag = true;
                    }
                }

                if (regOrgFlag == false)
                {
                    Organisation newOrganisation = new Organisation();
                    newOrganisation.OrganisationNumber = (int)OrgNumber;
                    newOrganisation.OrganisationName = OrgName;
                    newOrganisation.Street = Street;
                    newOrganisation.Suburb = Suburb;
                    newOrganisation.Province = Province;
                    newOrganisation.ContactNumber = ContactNum;
                    newOrganisation.Country = Country;
                    newOrganisation.Continent = "Africa";
                    newOrganisation.Industry = Industry;
                    newOrganisation.OrganisationType = OrgType;
                    newOrganisation.RegistrationDate = Convert.ToDateTime(System.DateTime.Today.ToString());
                    newOrganisation.Verified = false;
                    newOrganisation.Banned = false;
                    dbObjects.Organisations.InsertOnSubmit(newOrganisation);
                    dbObjects.SubmitChanges();
                    RegisterSuccessful = true;

                    if (OrgType == 2)
                    {
                        var org = from o in dbObjects.Organisations where o.OrganisationNumber == OrgNumber select o;
                        BusinessPoint newPoint = new BusinessPoint();
                        newPoint.OrganisationID = org.FirstOrDefault().OrganisationID;
                        newPoint.Point = 0;
                        dbObjects.BusinessPoints.InsertOnSubmit(newPoint);
                        dbObjects.SubmitChanges();

                        RegisterSuccessful = true;
                    }
                }
            }
            catch (Exception ex)
            {
                RegisterSuccessful = false;
            }
            return RegisterSuccessful;
        }

        public bool hasDonatatedReq(int donationRequID)
        {
            var d = from don in dbObjects.Donations where don.RequestIDNumber.Equals(donationRequID) select don;
            if (d.Count() > 0)
                return true;
            return false;
        }

        public DonationRequester[] getAllDonationRequest(int userID)
        {
            string tmpInd = targetedDonations(userID);

            var n = from o in dbObjects.DonationRequests where o.Organisation.Industry.Equals(tmpInd) select o;
            var n2 = from o in dbObjects.DonationRequests where !o.Organisation.Industry.Equals(tmpInd) select o;

            DonationRequester[] d = Dconvert(n.ToArray());
            DonationRequester[] d2 = Dconvert(n2.ToArray());
            for (int i = 0; i < d.Length; i++)
            {
                d[i].Inprogress = hasDonatatedReq(d[i].Donate.RequestIDNumber);
            }

            for (int i = 0; i < d2.Length; i++)
            {
                d2[i].Inprogress = hasDonatatedReq(d2[i].Donate.RequestIDNumber);
            }

            DonationRequester[] newArray = new DonationRequester[d.Length + d2.Length];
            d.CopyTo(newArray, 0);
            d2.CopyTo(newArray, d.Length);

            return newArray;
        }

        public DonationRequester[] getAllNDonationRequest(int npoID)
        {
            var n = from o in dbObjects.DonationRequests where o.OrganisationID.Equals(npoID) select o;
            DonationRequester[] d = Dconvert(n.ToArray());
            for (int i = 0; i < d.Length; i++)
            {
                d[i].Inprogress = hasDonatatedReq(d[i].Donate.RequestIDNumber);
            }
            return d;
        }

        private DonationRequester[] Dconvert(DonationRequest[] d)
        {
            int size = d.Count();
            DonationRequester[] don = new DonationRequester[size];
            for (int i = 0; i < size; i++)
            {
                don[i] = Dconvert(d[i]);
            }
            return don;
        }

        public Organisation getOrg(int oID)
        {
            var np = from o in dbObjects.Organisations where o.OrganisationID.Equals(oID) select o;
            Organisation npo = np.FirstOrDefault();
            Organisation n = new Organisation();
            n.OrganisationID = npo.OrganisationID;
            n.OrganisationName = npo.OrganisationName;
            n.OrganisationNumber = npo.OrganisationNumber;
            n.OrganisationType = npo.OrganisationType;
            n.Street = npo.Street;
            n.Suburb = npo.Suburb;
            n.Province = npo.Province;
            n.ContactNumber = npo.ContactNumber;
            n.Industry = npo.Industry;
            n.Verified = npo.Verified;
            n.Banned = (bool)npo.Banned;
            return n;
        }

        private DonationRequester Dconvert(DonationRequest d)
        {
            DonationRequester don = new DonationRequester();
            don.Amount = (double)d.Amount;
            don.Discription = d.Description;
            don.OrgID = d.OrganisationID;
            don.ReqNum1 = d.RequestIDNumber;
            don.Type = (int)d.Type;
            don.Donate = new DonationRequest();
            don.Donate.RequestIDNumber = d.RequestIDNumber;
            don.Donate.Amount = d.Amount;
            don.Donate.Description = d.Description;
            don.Donate.OrganisationID = d.OrganisationID;
            don.Donate.Type = d.Type;
            don.NpoName = getOrg(d.OrganisationID).OrganisationName;
            don.Donate.DonationDate = d.DonationDate;
            return don;
        }

        public bool addDonationRequest(DonationRequester d)
        {
            try
            {
                var n = from o in dbObjects.Organisations where o.OrganisationID.Equals(d.OrgID) select o;
                var n1 = n.Count();
                if (n1 > 0)
                {
                    DonationRequest don = new DonationRequest();
                    don.OrganisationID = d.OrgID;
                    don.Amount = (decimal)d.Amount;
                    don.Description = d.Discription;
                    don.DonationDate = d.Date;
                    don.Type = d.Type;

                    dbObjects.DonationRequests.InsertOnSubmit(don);
                    dbObjects.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public UserDetail CheckDetails(String Email, String Password)
        {
            var u = from userList in dbObjects.SystemUsers select userList;
            UserDetail user = new UserDetail();
            user.userValue = new SystemUser();
            foreach (SystemUser ind in u)
            {
                if (ind.Email.Equals(Email) && ind.Password.Equals(Password))
                {
                    if(ind.Banned == false)
                    {
                        user = Uconvert(ind);
                        break;
                    }
                }
                user.EmailValue = "NULL";
                user.FirstNameValue = "Your usename, password combination is incorrect!";
                user.AccessLvl = -1;
            }
            return user;
        }

        public User[] getUsers()
        {
            var u = from userList in dbObjects.SystemUsers select userList;
            User[] usersList = new User[u.Count()];
            int count = 0;
            foreach (SystemUser ind in u)
            {
                User tmp = new User();
                tmp.IDValue = ind.UserID;
                tmp.FirstNameValue = ind.FirstName;
                tmp.LastNameValue = ind.LastName;
                tmp.EmailValue = ind.Email;
                tmp.BannedValue = (bool)ind.Banned;
                tmp.TypeValue = (int)ind.AccessLevel;
                usersList[count] = tmp;
                count++;
            }
            return usersList;
        }

        public Orga[] getOrganisations()
        {
            var o = from orgList in dbObjects.Organisations select orgList;
            Orga[] orgaList = new Orga[o.Count()];

            int count = 0;

            foreach (Organisation org in o)
            {
                Orga tmp = new Orga();
                tmp.OrgID = org.OrganisationID;
                tmp.OrgNum = (int)org.OrganisationNumber;
                tmp.OrgName = org.OrganisationName;
                tmp.Street = org.Street;
                tmp.Suburb = org.Suburb;
                tmp.Province = org.Province;
                tmp.Industry = org.Industry;
                tmp.Type = (int)org.OrganisationType;
                tmp.ContactNum = org.ContactNumber;
                tmp.Verified = (bool)org.Verified;
                tmp.Banned = (bool)org.Banned;
                orgaList[count] = tmp;
                count++;
            }
            return orgaList;
        }

        public bool addEvent(Eve e, int orgID)
        {
            try
            {
                bool added = false;

                dbObjects = new Project_Leap_LinQDataContext();

                var orgList = from o in dbObjects.Organisations select o;

                foreach (Organisation o in orgList)
                {
                    if (o.OrganisationID == orgID)
                    {
                        Event eve = new Event();
                        eve.OrganisationID = orgID;
                        eve.Name = e.Name;
                        eve.Host = e.Host;
                        eve.Location = e.Location;
                        eve.Description = e.Description;
                        eve.DateOfEvent = e.DateValue;
                        eve.TimeOfEvent = e.Time;

                        dbObjects.Events.InsertOnSubmit(eve);
                        dbObjects.SubmitChanges();

                        added = true;
                    }
                }
                return added;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public User getUser(int UserID)
        {
            var u = from userList in dbObjects.SystemUsers select userList;
            foreach (SystemUser ind in u)
            {
                if (ind.UserID == UserID)
                {
                    User tmpUser = new User();
                    tmpUser.IDValue = ind.UserID;
                    tmpUser.FirstNameValue = ind.FirstName;
                    tmpUser.LastNameValue = ind.LastName;
                    tmpUser.EmailValue = ind.Email;
                    return tmpUser;
                }
            }
            return null;
        }

        public bool deleteUser(int UserID)
        {
            bool isDelete = false;

            var u = from userList in dbObjects.SystemUsers select userList;

            foreach (SystemUser ind in u)
            {
                if (ind.UserID == UserID)
                {
                    ind.Banned = true;

                    try
                    {
                        dbObjects.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    isDelete = true;
                }
            }
            return isDelete;
        }

        public bool deleteOrg(int ordID)
        {
            bool isDelete = false;

            var o = from orgList in dbObjects.Organisations select orgList;

            foreach (Organisation org in o)
            {
                if (org.OrganisationID == ordID)
                {
                    
                    var manager = from m in dbObjects.Managers where m.OrganisationID == org.OrganisationID select m;

                    foreach (Manager man in manager)
                    {
                        var user = from u in dbObjects.SystemUsers where man.UserID == u.UserID select u;
                        user.FirstOrDefault().Banned = true;
                    }

                    org.Banned = true;

                    try
                    {
                        dbObjects.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    isDelete = true;
                }
            }
            return isDelete;
        }

        public Boolean UpdateProfile(UserDetail user)
        {
            try
            {
                dbObjects = new Project_Leap_LinQDataContext();
                var u = from userList in dbObjects.SystemUsers select userList;
                foreach (SystemUser ind in u)
                {
                    if (user.userValue.UserID == ind.UserID)
                    {
                        if (user.userValue.FirstName != null && user.userValue.FirstName != "")
                        {
                            ind.FirstName = user.userValue.FirstName;
                        }
                        if (user.userValue.LastName != null && user.userValue.LastName != "")
                        {
                            ind.LastName = user.userValue.LastName;
                        }
                        if (user.userValue.Gender != null && user.userValue.Gender != ' ')
                        {
                            ind.Gender = user.userValue.Gender;
                        }
                        if (user.userValue.Title != null && user.userValue.Title != "")
                        {
                            ind.Title = user.userValue.Title;
                        }
                        if (user.userValue.DateOfBirth != null)
                        {
                            ind.DateOfBirth = user.userValue.DateOfBirth;
                        }
                        if (user.userValue.Province != null && user.userValue.Province != "")
                        {
                            ind.Province = user.userValue.Province;
                        }

                        dbObjects.SubmitChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private UserDetail Uconvert(SystemUser u)
        {
            UserDetail use = new UserDetail();
            use.userValue = new SystemUser();
            use.FirstNameValue = u.FirstName;
            use.AccessLvl = (int)u.AccessLevel;
            use.userValue.UserID = u.UserID;
            use.userValue.FirstName = u.FirstName;
            use.userValue.LastName = u.LastName;
            use.userValue.Gender = u.Gender;
            use.userValue.Title = u.Title;
            use.userValue.DateOfBirth = u.DateOfBirth;
            use.userValue.Province = u.Province;
            use.userValue.Country = u.Country;
            use.userValue.Continent = u.Continent;
            use.userValue.AccessLevel = u.AccessLevel;
            use.userValue.RegistrationDate = u.RegistrationDate;
            use.userValue.ProfilePictureURL = u.ProfilePictureURL;
            use.EmailValue = u.Email;
            use.Banned = (bool)u.Banned;
            return use;
        }

        private UserDetail[] Uconvert(SystemUser[] u)
        {
            int size = u.Count();
            UserDetail[] use = new UserDetail[size];
            for (int i = 0; i < size; i++)
            {
                use[i] = Uconvert(u[i]);
            }
            return use;
        }

        private Eve Econvert(Event e)
        {
            Eve ev = new Eve();
            ev.EventValue = new Event();
            ev.EventValue.EventID = e.EventID;
            ev.EventValue.OrganisationID = e.OrganisationID;
            ev.EventValue.Name = e.Name;
            ev.EventValue.Location = e.Location;
            ev.EventValue.Host = e.Host;
            ev.EventValue.Description = e.Description;
            ev.EventValue.DateOfEvent = e.DateOfEvent;
            ev.Time = e.TimeOfEvent;
            return ev;
        }

        private Eve[] Econvert(Event[] e)
        {
            int size = e.Count();
            Eve[] ev = new Eve[size];
            for (int i = 0; i < size; i++)
            {
                ev[i] = Econvert(e[i]);
            }
            return ev;
        }

        public Eve getEvent(int eventID)
        {
            var e = from events in dbObjects.Events where events.EventID.Equals(eventID) select events;
            return Econvert(e.FirstOrDefault());
        }

        public Eve[] getEvents(int userID)
        {
            string tmpInd = targetedDonations(userID);

            var e = from events in dbObjects.Events where events.Organisation.Industry.Equals(tmpInd) & events.DateOfEvent >= DateTime.Today select events;
            var e2 = from events in dbObjects.Events where !events.Organisation.Industry.Equals(tmpInd) & events.DateOfEvent >= DateTime.Today select events;

            Eve[] eves = new Eve[e.Count() + e2.Count()];
            Econvert(e.ToArray()).CopyTo(eves, 0);
            Econvert(e2.ToArray()).CopyTo(eves, Econvert(e.ToArray()).Length);

            return eves;
        }

        public Eve[] getNEvents(int npoID)
        {
            var e = from events in dbObjects.Events where events.OrganisationID.Equals(npoID) select events;
            return Econvert(e.ToArray());
        }

        public Boolean verifyEmail(string email)
        {
            var u = from userList in dbObjects.SystemUsers select userList;

            foreach (SystemUser ind in u)
            {
                if (ind.Email.Equals(email))
                {
                    return true;
                }
            }
            return false;
        }

        public String addNewsFeed(int npoID, string title, string body)
        {
            string feedAdded;
            try
            {
                try
                {
                    NewsFeed newFeed = new NewsFeed();

                    newFeed.OrganisationID = npoID;
                    newFeed.Title = title;
                    newFeed.Body = body;
                    dbObjects.NewsFeeds.InsertOnSubmit(newFeed);
                    dbObjects.SubmitChanges();
                    feedAdded = "News feed added successfully.";
                }
                catch (Exception ex)
                {
                    feedAdded = "An error occured when adding the feed. Please try again later!";
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                feedAdded = "An error occured when adding the feed. Please try again later!";
            }
            return feedAdded; ;
        }

        public NewsF[] GetFeeds()
        {
            var u = from feedList in dbObjects.NewsFeeds select feedList;
            NewsF[] feedsList = new NewsF[u.Count()];
            int count = 0;
            foreach (NewsFeed feed in u)
            {
                NewsF tmp = new NewsF();
                tmp.OrgID1 = feed.OrganisationID;
                tmp.Body1 = feed.Body;
                tmp.Title1 = feed.Title;

                var p = from orgList in dbObjects.Organisations select orgList;

                foreach (Organisation org in p)
                {
                    if (org.OrganisationID == feed.OrganisationID)
                    {
                        tmp.OrgName1 = org.OrganisationName;
                    }
                }
                feedsList[count] = tmp;
                count++;
            }
            return feedsList;
        }

        public int getNPOWithManager(int NPOManagerID)
        {
            var c = from managers in dbObjects.Managers select managers;
            int organisationID = 0;

            foreach (Manager m in c)
            {
                if (m.UserID == NPOManagerID)
                {
                    organisationID = m.OrganisationID;
                    break;
                }
            }
            return organisationID;
        }

        public bool UpdatePassword(String password, int User_ID)
        {
            try
            {
                bool IsUpdated = false;

                var d = from users in dbObjects.SystemUsers select users;

                foreach (SystemUser user in d)
                {
                    if (user.UserID == User_ID)
                    {
                        user.Password = password;
                        dbObjects.SubmitChanges();
                        IsUpdated = true;
                        break;
                    }
                }
                return IsUpdated;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int getUserID(string email)
        {
            int ID = 0;
            var U = from user in dbObjects.SystemUsers select user;
            foreach (SystemUser user in U)
            {
                if (user.Email.Equals(email))
                {
                    ID = user.UserID;
                }
            }
            return ID;
        }

        private double percent(double amount)
        {
            double per = 0;
            var pers = from t in dbObjects.TransactionPercentages orderby t.AmountBracket ascending select t;
            TransactionPercentage[] perss = pers.ToArray();
            int i = 0;
            for (i = 0; i < perss.Length - 1; i++)
            {
                if (perss[i].AmountBracket <= amount && perss[i + 1].AmountBracket > amount)
                {
                    per = Convert.ToDouble(perss[i].Percentage);
                    return per;
                }
            }
            if (amount >= perss[i].AmountBracket)
            {
                per = Convert.ToDouble(perss.Last().Percentage);
                return per;
            }
            return 0;
        }

        private decimal calculation(double amount)
        {
            return Convert.ToDecimal((amount / 100) * percent(amount));
        }

        public bool addDonation(int UserId, DonationRequester donation)
        {
            //try
            //{
                Donation donate = new Donation();
                donate.Description = donation.Discription;
                donate.DonationDate = DateTime.Today;
                donate.OrganisationID = donation.OrgID;
                donate.UserID = UserId;
                if (donation.ReqNum1 > 0)
                    donate.RequestIDNumber = donation.ReqNum1;

                dbObjects.Donations.InsertOnSubmit(donate);
                dbObjects.SubmitChanges();

                var d = from don in dbObjects.Donations
                        where don.Description.Equals(donation.Discription) &&
                        don.OrganisationID.Equals(donation.OrgID) &&
                        don.UserID.Equals(UserId)
                        orderby don.DonationID descending
                        select don;

                if (donation.Type == 1)
                {
                    MoneyDonation money = new MoneyDonation();
                    money.DonationID = d.FirstOrDefault().DonationID;
                    money.Amount = Convert.ToDecimal(donation.Amount);
                    money.TransactionPercentage = Convert.ToDecimal(percent((double)donation.Amount));
                    money.TransactionAmount = calculation((double)donation.Amount);

                    if (getNPOWithManager((int)donate.UserID) > 0)
                    {
                        var bus = from b in dbObjects.BusinessPoints where getNPOWithManager((int)donate.UserID) == b.OrganisationID select b;
                        bus.SingleOrDefault().Point = bus.SingleOrDefault().Point + (int)money.Amount;
                    }
                    else
                    {
                        var ind = from i in dbObjects.Individuals where donate.UserID == i.UserID select i;
                        ind.SingleOrDefault().Point = ind.SingleOrDefault().Point + (int)money.Amount;
                    }

                    dbObjects.MoneyDonations.InsertOnSubmit(money);
                    dbObjects.SubmitChanges();
                }
                return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
            //else
            //{
            //    EquipmentDonation equip = new EquipmentDonation();
            //    equip.DonationID = d.FirstOrDefault().DonationID;
            //    equip.Quantity = donation.Donate.;
            //    equip.EquipmentName = m.EquipmentName;
            //    dbObjects.EquipmentDonations.InsertOnSubmit(equip);
            //    dbObjects.SubmitChanges();
            //}
        }

        public DonationRequester getDonation(int donationID)
        {
            var c = from d in dbObjects.DonationRequests where d.RequestIDNumber.Equals(donationID) select d;
            DonationRequester don = Dconvert(c.FirstOrDefault());
            return don;
        }

        public DonationUser[] getDonationUser(int userID)
        {
            var user = from u in dbObjects.SystemUsers where u.UserID == userID select u;

            if(user.SingleOrDefault().AccessLevel == 4)
            {
                var man = from m1 in dbObjects.Managers where m1.UserID == userID select m1;
                var man2 = from m2 in dbObjects.Managers where m2.OrganisationID == man.FirstOrDefault().OrganisationID && m2.UserID != userID select m2;
                userID = man2.FirstOrDefault().UserID;
            }

            var d = from don in dbObjects.Donations where don.UserID.Equals(userID) select don;
            var m = from mon in dbObjects.MoneyDonations select mon;
            DonationUser[] donation = new DonationUser[d.Count()];
            int index = 0;
            foreach (Donation dona in d)
            {
                foreach (var mony in m)
                {
                    if (mony.DonationID == dona.DonationID)
                    {
                        donation[index] = new DonationUser();
                        donation[index].Amount = Convert.ToDouble(mony.Amount);
                        donation[index].Date = Convert.ToDateTime(dona.DonationDate);
                        donation[index].NpoName = getOrg((int)dona.OrganisationID).OrganisationName;
                        index++;
                    }
                }
            }
            return donation;
            //var e = from eq in dbObjects.EquipmentDonations select eq;
        }

        public string[] getDonorEmails(int orgID)
        {
            var don = from user in dbObjects.Donations select user;

            ArrayList emails = new ArrayList();

            int count = 0;

            bool isCopy = false;

            foreach (Donation d in don)
            {
                var users = from u in dbObjects.SystemUsers select u;

                foreach (SystemUser u in users)
                {
                    if (u.UserID == d.UserID)
                    {
                        for (int a = 0; a < emails.Count; a++)
                        {
                            if (emails[a].Equals(u.Email))
                            {
                                isCopy = true;
                                break;
                            }
                        }

                        if (!isCopy)
                        {
                            emails.Add((String)u.Email);
                        }
                        isCopy = false;
                    }
                }
                count++;
            }
            String[] emailsArray = (String[])emails.ToArray(typeof(string));

            return emailsArray;
        }

        private RSVPEvent RConvert(EventRSVP rsvp)
        {
            RSVPEvent r = new RSVPEvent();
            r.User = (int)rsvp.UserID;
            r.EventID = (int)rsvp.EventID;
            r.Attendance = rsvp.Attendence;
            return r;
        }

        private EventVolunteer VConvert(VolunteerEvent vol)
        {
            EventVolunteer v = new EventVolunteer();
            v.UserID = vol.UserID;
            v.OrgID = vol.OrganisationID;
            v.VolunteerID = vol.VolunteerID;
            v.OrnName = vol.Organisation.OrganisationName;
            v.UserEmail = vol.Individual.SystemUser.Email;
            v.UserFN = vol.Individual.SystemUser.FirstName;
            v.UserLN = vol.Individual.SystemUser.LastName;
            v.Hours = (int)vol.HoursVolunteered;
            v.Comment = vol.Comment;
            v.VolDate = (DateTime)vol.VolunteerDate;
            v.ShortDate = v.VolDate.ToShortDateString();

            return v;
        }

        private RSVPEvent[] RConvert(EventRSVP[] rsvp)
        {
            int size = rsvp.Length;
            RSVPEvent[] r = new RSVPEvent[size];
            for (int i = 0; i < size; i++)
                r[i] = RConvert(rsvp[i]);
            return r;
        }

        private EventVolunteer[] VConvert(VolunteerEvent[] vol)
        {
            int size = vol.Length;
            EventVolunteer[] v = new EventVolunteer[size];
            for (int i = 0; i < size; i++)
                v[i] = VConvert(vol[i]);
            return v;
        }

        private cFundraisingCampaign FCConvert(FundraisingCampaign val)
        {
            cFundraisingCampaign temp = new cFundraisingCampaign();
            temp.IDF = val.FundraisingCampaignID;
            temp.OrgID1 = val.OrganisationID;
            temp.VTitle = val.Title;
            temp.VDescription = val.Description;
            temp.VCurrentAmount = Convert.ToDouble(val.CurrentAmount);
            temp.VTotalAmount = Convert.ToDouble(val.TotalAmount);
            return temp;
        }

        private cFundraisingCampaign[] FCConvert(FundraisingCampaign[] val)
        {
            int size = val.Length;
            cFundraisingCampaign[] temp = new cFundraisingCampaign[size];
            for (int i = 0; i < size; i++)
            {
                temp[i] = FCConvert(val[i]);
            }
            return temp;
        }

        private RSVPEvent[] ARConvert(EventRSVP[] rsvp, RSVPEvent[] r)
        {
            int size = rsvp.Length + r.Length, index = 0;
            RSVPEvent[] br = new RSVPEvent[size];
            for (int i = 0; i < r.Length; i++)
            {
                br[index] = r[i];
                index++;
            }
            for (int i = 0; i < rsvp.Length; i++)
            {
                br[index] = RConvert(rsvp[i]);
                index++;
            }
            return br;
        }

        public bool setRSVP(RSVPEvent rsvp)
        {
            try
            {
                Event evet = dbObjects.Events.Single(e => e.EventID == rsvp.EventID);
                EventRSVP eventRSVP = new EventRSVP();
                eventRSVP.Attendence = rsvp.Attendance;
                eventRSVP.EventID = rsvp.EventID;
                eventRSVP.UserID = rsvp.User;

                var rsvpE = from e in dbObjects.EventRSVPs where e.UserID == eventRSVP.UserID && e.EventID == eventRSVP.EventID select e;

                if (rsvpE.Count() > 0)
                {
                    rsvpE.FirstOrDefault().Attendence = rsvp.Attendance;
                }
                else
                {
                    evet.EventRSVPs.Add(eventRSVP);
                }

                dbObjects.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public RSVPEvent[] getEventUser(int userID)
        {
            var e = from r in dbObjects.EventRSVPs where r.UserID == userID select r;
            RSVPEvent[] rsvp = RConvert(e.ToArray());
            return rsvp;
        }

        public RSVPEvent[] getGetRSVPList(int npoID)
        {
            var n = from o in dbObjects.Events where o.OrganisationID.Equals(npoID) select o;
            RSVPEvent[] rsvp = new RSVPEvent[0];
            foreach (var npo in n)
            {
                rsvp = ARConvert(npo.EventRSVPs.ToArray(), rsvp);
            }
            return rsvp;
        }

        public bool setVolunteer(EventVolunteer vol)
        {
            bool added = false;

            try
            {
                VolunteerEvent volunteer = new VolunteerEvent();
                volunteer.UserID = vol.UserID;
                volunteer.OrganisationID = vol.OrgID;
                volunteer.VolunteerDate = Convert.ToDateTime(vol.VolDate);
                volunteer.HoursVolunteered = 0;
                dbObjects.VolunteerEvents.InsertOnSubmit(volunteer);
                dbObjects.SubmitChanges();
                added = true;
            }
            catch (Exception e)
            {
                added = false;
            }

            return added;
        }

        public EventVolunteer[] getVolunteerUser(int userID)
        {
            var vols = from vol in dbObjects.VolunteerEvents where userID == vol.UserID select vol;
            EventVolunteer[] volun = VConvert(vols.ToArray());
            return volun;
        }

        public EventVolunteer[] getVolunteers(int npoID)
        {
            var n = from o in dbObjects.VolunteerEvents where o.OrganisationID == npoID select o;
            EventVolunteer[] vols = VConvert(n.ToArray());
            return vols;
        }

        public bool CommentOnVolunteer(EventVolunteer volunteer)
        {
            bool added = false;

            try
            {
                var vol = from o in dbObjects.VolunteerEvents where volunteer.VolunteerID == o.VolunteerID select o;
                vol.SingleOrDefault().Comment = volunteer.Comment;
                vol.SingleOrDefault().HoursVolunteered = volunteer.Hours;
                var ind = from i in dbObjects.Individuals where vol.SingleOrDefault().UserID == i.UserID select i;
                ind.SingleOrDefault().Point = ind.SingleOrDefault().Point + (vol.SingleOrDefault().HoursVolunteered * 50);
                dbObjects.SubmitChanges();
                added = true;
            }
            catch (Exception e)
            {
                added = false;
            }
            return added;
        }

        public bool AddNewFundraisingCamp(cFundraisingCampaign newFC)
        {
            bool isAdded = false;

            try
            {
                var c = from b in dbObjects.FundraisingCampaigns select b;
                bool regIndFlag = false;

                foreach (FundraisingCampaign a in c)
                {
                    if (a.Title.Equals(newFC.VTitle))
                    {
                        regIndFlag = true;
                    }
                }
                if (regIndFlag == false)
                {
                    FundraisingCampaign dbFC = new FundraisingCampaign();
                    dbFC.OrganisationID = newFC.OrgID1;
                    dbFC.Title = newFC.VTitle;
                    dbFC.Description = newFC.VDescription;
                    dbFC.CurrentAmount = Convert.ToDecimal(newFC.VCurrentAmount);
                    dbFC.TotalAmount = Convert.ToDecimal(newFC.VTotalAmount);
                    dbObjects.FundraisingCampaigns.InsertOnSubmit(dbFC);
                    dbObjects.SubmitChanges();
                    isAdded = true;
                }
            }
            catch (Exception ex)
            {
                isAdded = false;
            }
            return isAdded;
        }

        public cFundraisingCampaign getFundRaisingCampaign(int FC_id)
        {
            var f = from FC in dbObjects.FundraisingCampaigns where FC.FundraisingCampaignID == FC_id select FC;
            return FCConvert(f.FirstOrDefault());
        }

        public bool DonateFC(int FC_ID, int Doner_ID, double Amount)
        {
            bool isDonate = false;
            var f = from FC in dbObjects.FundraisingCampaigns where FC.FundraisingCampaignID == FC_ID select FC;
            var doub = Convert.ToDouble(f.FirstOrDefault().CurrentAmount);
            doub += Amount;
            var fun = f.FirstOrDefault();
            fun.CurrentAmount = Convert.ToDecimal(doub);
            DonationRequester donateTemp = new DonationRequester();
            donateTemp.Amount = Amount;
            donateTemp.Discription = fun.Description;
            donateTemp.Type = 1;
            donateTemp.ReqNum1 = 0;
            donateTemp.OrgID = fun.OrganisationID;
            isDonate = addDonation(Doner_ID, donateTemp);
            return isDonate;
        }

        public double getAmountSystemGenerated()
        {
            double totalSystemGenerated = 0;
            var a = from MoneyDonation in dbObjects.MoneyDonations select MoneyDonation;
            foreach (MoneyDonation m in a)
            {
                totalSystemGenerated += (double)m.TransactionAmount;
            }
            return totalSystemGenerated;
        }

        public bool getVerificationStatus(int orgNum)
        {
            bool verified = false;
            var org = from o in dbObjects.Organisations where o.OrganisationID == orgNum select o;
            verified = (bool)org.FirstOrDefault().Verified;
            return verified;
        }

        public int getPointsInd(int indID)
        {
            var ind = from i in dbObjects.Individuals where indID == i.UserID select i;
            return (int)ind.FirstOrDefault().Point;
        }

        public int getPointsOrg(int orgID)
        {
            var bus = from b in dbObjects.BusinessPoints where orgID == b.OrganisationID select b;
            return (int)bus.FirstOrDefault().Point;
        }

        public cFundraisingCampaign[] getAllFundRaisingCampaign(int userID)
        {
            string tmpInd = targetedDonations(userID);

            var f = from fun in dbObjects.FundraisingCampaigns where fun.Organisation.Industry.Equals(tmpInd) select fun;
            var f2 = from fun in dbObjects.FundraisingCampaigns where !fun.Organisation.Industry.Equals(tmpInd) select fun;

            cFundraisingCampaign[] camps = new cFundraisingCampaign[f.Count() + f2.Count()];
            FCConvert(f.ToArray()).CopyTo(camps, 0);
            FCConvert(f2.ToArray()).CopyTo(camps, FCConvert(f.ToArray()).Length);

            return camps;
        }

        public cFundraisingCampaign[] getOwnFundraisingCampaigns(int NPOID)
        {
            var f = from fun in dbObjects.FundraisingCampaigns where fun.OrganisationID == NPOID select fun;
            return FCConvert(f.ToArray());
        }

        public string[] getNPOTypes()
        {
            ArrayList npoTypes = new ArrayList();
            var org = from o in dbObjects.Organisations select o;
            bool alreadyAdded = false;

            foreach (Organisation o in org)
            {
                if (o.OrganisationType == 1)
                {
                    for (int a = 0; a < npoTypes.Count; a++)
                    {
                        if (npoTypes[a].Equals(o.Industry))
                        {
                            alreadyAdded = true;
                        }
                    }

                    if (!alreadyAdded)
                    {
                        npoTypes.Add(o.Industry);
                    }

                    alreadyAdded = false;
                }
            }

            return (string[])npoTypes.ToArray(typeof(String));
        }

        public Orga[] getNPOofType(string type)
        {
            var o = from or in dbObjects.Organisations where type.Equals(or.Industry) select or;
            Orga[] orgaList = new Orga[o.Count()];
            int count = 0;

            foreach (Organisation org in o)
            {
                Orga tmp = new Orga();
                tmp.OrgID = org.OrganisationID;
                tmp.OrgNum = (int)org.OrganisationNumber;
                tmp.OrgName = org.OrganisationName;
                tmp.Street = org.Street;
                tmp.Suburb = org.Suburb;
                tmp.Province = org.Province;
                tmp.Industry = org.Industry;
                tmp.Type = (int)org.OrganisationType;
                tmp.ContactNum = org.ContactNumber;
                tmp.Verified = (bool)org.Verified;
                tmp.Banned = (bool)org.Banned;
                orgaList[count] = tmp;
                count++;
            }
            return orgaList;
        }

        public bool SetFeedback(int Rate, string Review, int UserID, int OrgID)
        {
            bool isFeedback = false;

            try
            {
                var c = from b in dbObjects.NPORatings select b;
                bool isFeedbackAgain = false;
                foreach (NPORating tempR in c)
                {
                    if (tempR.UserID == UserID && tempR.OrganisationID == OrgID)
                    {
                        isFeedbackAgain = true;
                        tempR.Rating = Rate;
                        //Review is coming soon..

                        dbObjects.SubmitChanges();
                    }
                }

                if (isFeedbackAgain == true)
                {
                    isFeedback = true;
                }
                else if (isFeedbackAgain == false)
                {
                    bool IsAllowed = false;

                    var Volunteers = from b in dbObjects.VolunteerEvents select b;
                    foreach (VolunteerEvent V in Volunteers)
                    {
                        if (V.UserID == UserID && V.OrganisationID == OrgID)
                        {
                            IsAllowed = true;
                        }
                    }
                    if (IsAllowed == false)
                    {
                        var Attendance = from b in dbObjects.EventRSVPs select b;
                        var Events = from e in dbObjects.Events where e.OrganisationID == OrgID select e;
                        int eventID = Events.FirstOrDefault().EventID;
                        int ComDate = 0;
                        foreach (EventRSVP ATDeve in Attendance)
                        {
                            foreach (Event eve in Events) //goes thru the events of the same organisation
                            {
                                eventID = eve.EventID;
                                DateTime i = (DateTime)eve.DateOfEvent;
                                ComDate = DateTime.Compare(i, DateTime.Now);
                                if (ATDeve.UserID == UserID && ATDeve.EventID == eventID && ComDate < 0 && ATDeve.Attendence == "Yes")
                                {
                                    IsAllowed = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (IsAllowed == true)
                    {
                        NPORating newRate = new NPORating();
                        newRate.UserID = UserID;
                        newRate.OrganisationID = OrgID;
                        newRate.Rating = Rate;
                        //Review Coming soon..
                        dbObjects.NPORatings.InsertOnSubmit(newRate);
                        dbObjects.SubmitChanges();

                        isFeedback = true;
                    }
                }


            }
            catch (Exception ex)
            {
                isFeedback = false;
            }
            return isFeedback;
        }

        public double getAverageRating(int Id_NPO)
        {
            var Ratings = from b in dbObjects.NPORatings select b;
            int count = 0;
            int total = 0;
            foreach (NPORating rate in Ratings)
            {
                if (rate.OrganisationID == Id_NPO)
                {
                    count++;
                    total = total + (int)rate.Rating;
                }
            }

            if (count == 0)
            {
                return 0.0;
            }
            decimal Avg = decimal.Round((total / count), 2);

            return (double)Avg;
        }

        public bool setFile(FileClass clientFile, string loc)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + @"files\" + loc + @"\" + clientFile.FilePath;
            System.IO.File.WriteAllBytes(filePath, clientFile.FileBytes);
            System.IO.FileInfo fInfo = new System.IO.FileInfo(filePath);
            if (!fInfo.Exists)
                return false;
            return true;
        }

        public bool addUserImage(FileClass userImage, int userID)
        {
            try
            {
                var u = from user in dbObjects.SystemUsers where user.UserID.Equals(userID) select user;
                var us = u.FirstOrDefault();
                if (setFile(userImage, "UserImage"))
                {
                    us.ProfilePictureURL = userImage.FilePath;
                    dbObjects.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool addOrgImage(FileClass orgImage, int orgNum)
        {
            try
            {
                var o = from org in dbObjects.Organisations where org.OrganisationNumber.Equals(orgNum) select org;
                var or = o.FirstOrDefault();
                if (setFile(orgImage, "OrgImage"))
                {
                    or.LogoURL = orgImage.FilePath;
                    dbObjects.SubmitChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool addOrgFile(FileClass orgFile, int orgNum)
        {
            try
            {
                var o = from org in dbObjects.Organisations where org.OrganisationNumber.Equals(orgNum) select org;
                var or = o.FirstOrDefault();
                if (setFile(orgFile, "OrgFile"))
                {
                    or.FilePath = orgFile.FilePath;
                    dbObjects.SubmitChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private FileClass getFile(string loc, string fName)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + @"files\" + loc + @"\" + fName;
            FileClass fileCl = new FileClass();
            System.IO.FileInfo fInfo = new System.IO.FileInfo(filePath);
            if (fInfo.Exists)
            {
                fileCl.FilePath = filePath;
                fileCl.FileBytes = System.IO.File.ReadAllBytes(fileCl.FilePath);
                return fileCl;
            }
            return null;
        }

        public FileClass getUserImage(int userID)
        {
            var u = from user in dbObjects.SystemUsers where user.UserID.Equals(userID) select user;
            var us = u.FirstOrDefault();
            FileClass userImage = getFile("UserImage", us.ProfilePictureURL);
            return userImage;
        }

        public FileClass getFile(int orgID, bool Image)
        {
            var o = from org in dbObjects.Organisations where org.OrganisationID.Equals(orgID) select org;
            var or = o.FirstOrDefault();
            FileClass Logo;
            if (Image)
            {
                Logo = getFile("OrgImage", or.LogoURL);
                return Logo;
            }
            else
            {
                Logo = getFile("OrgFile", or.FilePath);
                return Logo;
            }
        }

        public bool verifyOrg(int OrgID, bool verify)
        {
            bool ver = false;
            var org = from o in dbObjects.Organisations where o.OrganisationID == OrgID select o;
            if (org.Count() == 0)
                return ver = false;

            org.FirstOrDefault().Verified = verify;
            dbObjects.SubmitChanges();
            ver = true;

            return ver;
        }

        public double TotalRecievedFromDonations(int OrgID)
        {
            var dons = from dr in dbObjects.Donations where dr.OrganisationID == OrgID select dr;

            double total = 0;

            foreach(Donation don in dons)
            {
                var donsReq = from dr in dbObjects.DonationRequests where dr.RequestIDNumber == don.RequestIDNumber select dr;
                total += (double)donsReq.FirstOrDefault().Amount;
            }

            return total;
        }

        public double TotalDonated(int UserID)
        {
            var dons = from dr in dbObjects.Donations where dr.UserID == UserID select dr;

            double total = 0;

            foreach (Donation don in dons)
            {
                var donsReq = from dr in dbObjects.DonationRequests where dr.RequestIDNumber == don.RequestIDNumber select dr;
                total += (double)donsReq.FirstOrDefault().Amount;
            }

            return total;
        }

        public mobileEve GetNextEvent(int OrgID)
        {
            var eves = from e in dbObjects.Events where e.OrganisationID == OrgID & e.DateOfEvent > DateTime.Today select e;

            Event ev = eves.FirstOrDefault();

            foreach(Event even in eves)
            {
                if(even.DateOfEvent < ev.DateOfEvent)
                {
                    ev = even;
                }
            }

            mobileEve eve = new mobileEve();
            if(ev != null)
            {
                eve.Name = ev.Name;
                eve.Date = ev.DateOfEvent.Value.ToShortDateString();
            }
            
            return eve;
        }

        public mobileFC GetTotalFCProgress(int OrgID)
        {
            var fundCamp = from f in dbObjects.FundraisingCampaigns where f.OrganisationID == OrgID select f;

            mobileFC fc = new mobileFC();

            foreach(FundraisingCampaign fund in fundCamp)
            {
                fc.Current += (double)fund.CurrentAmount;
                fc.Target += (double)fund.TotalAmount;
            }

            return fc;
        }

        public mobileEve[] GetMobileEvents(int OrgID)
        {
            var e = from events in dbObjects.Events where events.OrganisationID == OrgID select events;
            mobileEve[] mEve = new mobileEve[e.Count()];

            int counter = 0;
            foreach(Event eve in e)
            {
                mobileEve tmp = new mobileEve();
                tmp.Name = eve.Name;
                tmp.Date = eve.DateOfEvent.Value.ToShortDateString();
                tmp.Location = eve.Location;
                tmp.Time = eve.TimeOfEvent;
                mEve[counter] = tmp;
                counter++;
            }

            return mEve;
        }

        public EventVolunteer getNextVolunteer(int UserID)
        {
            var vol = from v in dbObjects.VolunteerEvents where v.UserID == UserID & v.VolunteerDate > DateTime.Today select v;

            VolunteerEvent ve = vol.FirstOrDefault();

            foreach(VolunteerEvent v in vol)
            {
                if(v.VolunteerDate < ve.VolunteerDate)
                {
                    ve = v;
                }
            }
            EventVolunteer ev = null;
            
            if(ve != null)
            {
                ev = VConvert(ve);
            }

            return ev;
        }

        public mobileEve getNextNPOEvent(int UserID)
        {
            var eRSVP = from e in dbObjects.EventRSVPs where UserID == e.UserID & e.Event.DateOfEvent > DateTime.Today select e;
            EventRSVP tmp = eRSVP.FirstOrDefault();

            foreach(EventRSVP r in eRSVP)
            {
                if(r.Event.DateOfEvent < tmp.Event.DateOfEvent)
                {
                    if(r.Attendence.Equals("Yes"))
                    {
                        tmp = r;
                    }
                }
            }

            mobileEve eve = new mobileEve();

            if(tmp != null)
            {
                eve.Name = tmp.Event.Name;
                eve.Date = tmp.Event.DateOfEvent.Value.ToShortDateString();
                eve.Location = tmp.Event.Location;
                eve.Time = tmp.Event.TimeOfEvent;
                eve.NpoName = tmp.Event.Organisation.OrganisationName;
            }
            
            return eve;
        }

        public mobileEve[] GetMobileEventsAtt(int userID)
        {
            var e = from events in dbObjects.EventRSVPs where events.UserID == userID & events.Attendence.Equals("Yes") select events;
            mobileEve[] mEve = new mobileEve[e.Count()];

            int counter = 0;
            foreach (EventRSVP eve in e)
            {
                mobileEve tmp = new mobileEve();
                tmp.Name = eve.Event.Name;
                tmp.Date = eve.Event.DateOfEvent.Value.ToShortDateString();
                tmp.Location = eve.Event.Location;
                tmp.Time = eve.Event.TimeOfEvent;
                tmp.NpoName = eve.Event.Organisation.OrganisationName;
                mEve[counter] = tmp;
                counter++;
            }

            return mEve;
        }

        public bool CaptureVolTimeMobile(int volID, int hours, string comment)
        {
            var volE = from v in dbObjects.VolunteerEvents where volID == v.VolunteerID select v;
            EventVolunteer volunteer = new EventVolunteer();
            volunteer.VolunteerID = volID;
            volunteer.Hours = hours;
            volunteer.Comment = comment;

            return CommentOnVolunteer(volunteer);
        }

        public bool checkBadge(int userID, int badgeID)
        {
            var b = from bad in dbObjects.UserBadges where bad.BadgeID == badgeID && bad.UserID == userID select bad;
            var badg = from ba in dbObjects.Badges where ba.Id == badgeID select ba;
            var badge = badg.FirstOrDefault();
            bool flage = false;
            if (b.ToArray().Length > 0)
            {
                return true;
            }
            switch (Convert.ToInt32(badge.Type))
            {
                case 0:
                    var amo = from a in dbObjects.MoneyDonations
                              where a.Donation.UserID == userID
                              group a by a.Donation.UserID into g
                              let am = g.Sum(ar => ar.Amount)
                              select new { am };
                    decimal check = 0;
                    if (amo.FirstOrDefault() != null)
                        check = Convert.ToDecimal(amo.FirstOrDefault().am);
                    if (check > Convert.ToDecimal(badge.Condition))
                    {
                        flage = true;
                    }
                    break;
                case 1:
                    var u = from use in dbObjects.VolunteerEvents
                            where use.UserID == userID
                            group use by use.UserID into g
                            let hour = g.Sum(us => us.HoursVolunteered)
                            select new { hour };
                    int check1 = 0;
                    if (u.FirstOrDefault() != null)
                        check1 = Convert.ToInt32(u.FirstOrDefault().hour);
                    if (check1 > badge.Condition)
                    {
                        flage = true;
                    }
                    break;
                case 2:
                    var point = from s in dbObjects.Individuals where s.UserID == userID select s;
                    int upoint = 0;
                    if (point.FirstOrDefault() != null)
                        upoint = Convert.ToInt32(point.FirstOrDefault().Point);
                    if (upoint > badge.Condition)
                    {
                        flage = true;
                    }
                    break;
                case 3:
                    var rat = from r in dbObjects.NPORatings where r.UserID == userID select r;
                    int rateNum = rat.ToArray().Length;
                    if (rateNum > badge.Condition)
                    {
                        flage = true;
                    }
                    break;
                default:
                    return false;
            }
            if (flage)
            {
                UserBadge userB = new UserBadge();
                userB.UserID = userID;
                userB.BadgeID = badge.Id;
                dbObjects.UserBadges.InsertOnSubmit(userB);
                dbObjects.SubmitChanges();
                return true;
            }
            return false;
        }

        public int getNumOfBadgesEarned(int UserID)
        {
            var badges = from b in dbObjects.UserBadges where b.UserID == UserID select b;
            return badges.Count();
        }

        public reportDonation[] getAllDailyDonations(int orgID)
        {
            var amo = from a in dbObjects.Donations
                      where a.OrganisationID == orgID
                      group a by a.DonationDate into g
                      let am = g.Sum(ar => ar.DonationRequest.Amount)
                      select new { am, date = g.Key };
            reportDonation[] ret = new reportDonation[amo.Count()];
            int index = 0;
            foreach (var a in amo)
            {
                ret[index] = new reportDonation();
                ret[index].Date = Convert.ToDateTime(a.date).ToShortDateString();
                ret[index].Amount = Convert.ToDouble(a.am);
                index++;
            }
            return ret;
        }

        public reportDonation[] getAllDailyDonationsUser(int userID)
        {
            var amo = from a in dbObjects.Donations
                      where a.UserID == userID
                      group a by a.DonationDate into g
                      let am = g.Sum(ar => ar.DonationRequest.Amount)
                      select new { am, date = g.Key };
            reportDonation[] ret = new reportDonation[amo.Count()];
            int index = 0;
            foreach (var a in amo)
            {
                ret[index] = new reportDonation();
                ret[index].Date = Convert.ToDateTime(a.date).ToShortDateString();
                ret[index].Amount = Convert.ToDouble(a.am);
                index++;
            }
            return ret;
        }

        public reportVolunteers[] getVolunteersByProvince()
        {
            var vols = from a in dbObjects.VolunteerEvents
                      where a.HoursVolunteered > 0
                      group a by a.Individual.SystemUser.Province into g
                      let am = g.Count()
                      select new { am, prov = g.Key };
            reportVolunteers[] volsRep = new reportVolunteers[vols.Count()];
            int index = 0;
            foreach (var a in vols)
            {
                volsRep[index] = new reportVolunteers();
                volsRep[index].Province = a.prov;
                volsRep[index].VolAmounts = a.am;
                index++;
            }
            return volsRep;
        }
        public reportDonation[] getSystemFund()
        {
            var amo = from a in dbObjects.MoneyDonations
                     group a by a.Donation.DonationDate into g
                     let am = g.Sum(ar => ar.TransactionAmount)
                     select new { am, date = g.Key };
            reportDonation[] ret = new reportDonation[amo.Count()];
            int index = 0;
            foreach (var a in amo)
            {
                ret[index] = new reportDonation();
                ret[index].Date = Convert.ToDateTime(a.date).ToShortDateString();
                ret[index].Amount = Convert.ToDouble(a.am);
                index++;
            }
            return ret;
        }

        public reportBusDon[] getTopBusDon()
        {
            var topTenBus = from b in dbObjects.Donations
                            where b.SystemUser.AccessLevel == 3
                            group b by b.UserID into g
                            let am = g.Sum(ar => ar.DonationRequest.Amount)
                            orderby am descending
                            select new { am, uID = g.Key};
            reportBusDon[] ret = new reportBusDon[topTenBus.Count()];
            int index = 0;
            foreach (var a in topTenBus)
            { 
                ret[index] = new reportBusDon();
                ret[index].Amount = Convert.ToDouble(a.am);
                var bus = from b in dbObjects.Organisations where b.OrganisationID == getNPOWithManager((int)a.uID) select b;
                ret[index].Name = bus.FirstOrDefault().OrganisationName;
                index++;
            }

            return ret;
        }

        public reportFC[] getFCReports(int orgID)
        {
            var fcs = from f in dbObjects.FundraisingCampaigns
                      where f.OrganisationID == orgID
                      select f;

            reportFC[] fundC = new reportFC[fcs.Count()];
            int index = 0;

            foreach (FundraisingCampaign f in fcs)
            {
                double per = Convert.ToDouble(f.CurrentAmount) / Convert.ToDouble(f.TotalAmount) * 100;
                fundC[index] = new reportFC();
                fundC[index].Title = f.Title;
                fundC[index].Precentage = per;
                index++;
            }

            return fundC;
        }

        public double getVolsShowingUp(int orgID)
        {
            var vols = from v in dbObjects.VolunteerEvents 
                       where v.OrganisationID == orgID & v.VolunteerDate < DateTime.Today
                       select v;

            double total = vols.Count();
            double showedUp = 0;
            double per = 0;

            foreach (VolunteerEvent v in vols)
            {
                if (v.HoursVolunteered >= 1)
                    showedUp++;
            }

            if (total > 0)
                per = showedUp / total * 100;

            return per;
        }

        public double getFCSuccessRate(int orgID)
        {
            var fcs = from f in dbObjects.FundraisingCampaigns
                      where f.OrganisationID == orgID
                      select f;
            double fcTotalCount = fcs.Count();
            double fcSucces = 0;
            double per = 0;

            foreach (FundraisingCampaign f in fcs)
            {
                if (f.TotalAmount <= f.CurrentAmount)
                    fcSucces++;
            }

            if (fcTotalCount > 0)
                per = fcSucces / fcTotalCount * 100;

            return per;
        }

        public string targetedDonations(int userID)
        {
            var pastDons = from ds in dbObjects.Donations
                           where userID == ds.UserID
                           group ds by ds.Organisation.Industry into g
                           let am = g.Count()
                           select new { am, ind = g.Key };
            int tmpMax = 0;
            string tmpInd = "";
            foreach (var t in pastDons)
            {
                if (t.am > tmpMax)
                {
                    tmpMax = t.am;
                    tmpInd = t.ind;
                }
            }

            return tmpInd;
        }
        public activity[] getNPOActivity()
        {
            var o = from org in dbObjects.Organisations
                    where org.OrganisationType == 1
                    select org;
            activity[] ret = new activity[o.Count()];
            int index = 0;
            foreach (var a in o)
            {
                ret[index] = new activity();
                ret[index].First = a.Events.Count();
                ret[index].Second = a.FundraisingCampaigns.Count();
                ret[index].Third = a.DonationRequests.Count();
                ret[index].Total = 0;
                ret[index].SValue = a.OrganisationName;
                index++;
            }
            return ret;
        }
   
        public reportBusDon[] MostActiveUser()
        {
            var topTenUser = from b in dbObjects.Individuals
                             where b.SystemUser.AccessLevel == 5
                             group b by b.UserID into g
                             let am = g.Sum(ar => ar.Point)
                             orderby am descending
                             select new { am, uID = g.Key };
            reportBusDon[] TopActiveUser = new reportBusDon[topTenUser.Count()];
            int index = 0;
            foreach (var a in topTenUser)
            {
                TopActiveUser[index] = new reportBusDon();
                TopActiveUser[index].Amount = Convert.ToDouble(a.am);
                var Ind = from b in dbObjects.SystemUsers where b.UserID == a.uID select b;
                TopActiveUser[index].Name = Ind.FirstOrDefault().FirstName;
                index++;
            }

            return TopActiveUser;

        }
        public reportDonation[] getDailyUserRegistration()
        {
            var temp = from b in dbObjects.SystemUsers
                       group b by b.RegistrationDate into g
                       let am = g.Count()
                       select new { am, g = g.Key };

            reportDonation[] DailyRegistration = new reportDonation[temp.Count()];
            int index = 0;
            foreach (var a in temp)
            {

                DailyRegistration[index] = new reportDonation();

                DailyRegistration[index].Date = Convert.ToDateTime(a.g).ToShortDateString();
                DailyRegistration[index].Amount = a.am;

                index++;
            }
            return DailyRegistration;
        }

        public reportDonation[] getDailyOrganisationRegistration()
        {
            var temp = from b in dbObjects.Organisations
                       group b by b.RegistrationDate into g
                       let am = g.Count()
                       select new { am, g = g.Key };

            reportDonation[] DailyRegistration = new reportDonation[temp.Count()];
            int index = 0;
            foreach (var a in temp)
            {

                DailyRegistration[index] = new reportDonation();

                DailyRegistration[index].Date = Convert.ToDateTime(a.g).ToShortDateString();
                DailyRegistration[index].Amount = a.am;

                index++;
            }
            return DailyRegistration;

        }
        public Support[] MostSupportInType(string Type)
        {

            var tempNPO = from b in dbObjects.Organisations
                          where b.OrganisationType == 1
                          select b;

            var tempType = from c in dbObjects.Organisations
                           where c.Industry == Type
                           select c;
            Support[] arr = null;
            int NumOfOrg = NumOfOrgByIndustry(Type);

            arr = new Support[NumOfOrg];
            for (int i = 0; i < NumOfOrg; i++)
            {
                arr[i] = new Support();
            }

            int index = -1;
            foreach (var e in tempType)
            {
                foreach (var a in tempNPO)
                {
                    if (e.OrganisationID == a.OrganisationID)
                    {
                        index++;
                        //NB: Using Type as a Name here:
                        arr[index].type = a.OrganisationName;
                        var tempDonation = from c in dbObjects.Donations
                                           where c.OrganisationID == a.OrganisationID
                                           select c;
                        foreach (var tD in tempDonation)
                        {
                            arr[index].donationvalue++;

                        }
                        var tempVolunteer = from c in dbObjects.VolunteerEvents
                                            where c.OrganisationID == a.OrganisationID
                                            select c;
                        foreach (var tV in tempVolunteer)
                        {
                            arr[index].volunteerValue++;
                        }
                    }
                }
            }
            for (int i = 0; i < NumOfOrg; i++)
            {
                arr[i].supportValue = arr[i].volunteerValue + arr[i].donationvalue;
            }

            return arr;

        }
        public int NumOfOrgByIndustry(string Industry)
        {
            int NumOfOrg = 0;

            var tempIndus = from b in dbObjects.Organisations
                            where b.Industry == Industry
                            select b;

            foreach (var a in tempIndus)
            {
                NumOfOrg++;
            }
            return NumOfOrg;
        }
        public Support MostSupportByType(string Type)
        {

            var tempNPO = from b in dbObjects.Organisations
                          where b.OrganisationType == 1
                          select b;

            var tempType = from c in dbObjects.Organisations
                           where c.Industry == Type
                           select c;
            Support arr = null;
            arr = new Support();
            arr.type = Type;



            foreach (var e in tempType)
            {
                foreach (var a in tempNPO)
                {
                    if (e.OrganisationID == a.OrganisationID)
                    {
                        var tempDonation = from c in dbObjects.Donations
                                           where c.OrganisationID == a.OrganisationID
                                           select c;
                        foreach (var tD in tempDonation)
                        {
                            arr.donationvalue++;

                        }
                        var tempVolunteer = from c in dbObjects.VolunteerEvents
                                            where c.OrganisationID == a.OrganisationID
                                            select c;
                        foreach (var tV in tempVolunteer)
                        {
                            arr.volunteerValue++;
                        }
                    }
                }
            }

            arr.supportValue = arr.volunteerValue + arr.donationvalue;


            return arr;
        }
        public Support TypeMostSupportInArea(string Province)
        {

            var tempNPO = from b in dbObjects.Organisations
                          where b.OrganisationType == 1
                          select b;

            var tempProvience = from c in dbObjects.Organisations
                                where c.Province == Province
                                select c;
            Support[] arr = null;
            arr = new Support[6];
            arr[1] = new Support();
            arr[1].type = "Community";
            arr[2] = new Support();
            arr[2].type = "Environmental protection";
            arr[3] = new Support();
            arr[3].type = "Educational";
            arr[4] = new Support();
            arr[4].type = "Animal protection";
            arr[5] = new Support();
            arr[5].type = "Child care";



            foreach (var e in tempProvience)
            {
                foreach (var a in tempNPO)
                {
                    if (e.OrganisationID == a.OrganisationID)
                    {
                        var tempDonation = from c in dbObjects.Donations
                                           where c.OrganisationID == a.OrganisationID
                                           select c;
                        foreach (var tD in tempDonation)
                        {
                            if (e.Industry == "Community")
                            {
                                arr[1].donationvalue++;
                            }
                            else if (e.Industry == "Environmental protection")
                            {
                                arr[2].donationvalue++;
                            }
                            else if (e.Industry == "Educational")
                            {
                                arr[3].donationvalue++;
                            }
                            else if (e.Industry == "Animal protection")
                            {
                                arr[4].donationvalue++;
                            }
                            else if (e.Industry == "Child care")
                            {
                                arr[5].donationvalue++;
                            }

                        }
                        var tempVolunteer = from c in dbObjects.VolunteerEvents
                                            where c.OrganisationID == a.OrganisationID
                                            select c;
                        foreach (var tV in tempVolunteer)
                        {
                            if (e.Industry == "Community")
                            {
                                arr[1].volunteerValue++;
                            }
                            else if (e.Industry == "Environmental protection")
                            {
                                arr[2].volunteerValue++;
                            }
                            else if (e.Industry == "Educational")
                            {
                                arr[3].volunteerValue++;
                            }
                            else if (e.Industry == "Animal protection")
                            {
                                arr[4].volunteerValue++;
                            }
                            else if (e.Industry == "Child care")
                            {
                                arr[5].volunteerValue++;
                            }
                        }
                    }
                }
            }
            for (int i = 1; i < 6; i++)
            {
                arr[i].supportValue = arr[i].volunteerValue + arr[i].donationvalue;
            }
            int Largest = arr[1].supportValue;
            int index = 1;
            for (int i = 2; i < 6; i++)
            {
                if (arr[i].supportValue > Largest)
                {
                    Largest = arr[i].supportValue;
                    index = i;
                }

            }
            return arr[index];
        }

        public badgesReport[] getUserBadgesCount()
        {
            var badgesUsers = from b in dbObjects.UserBadges
                              group b by b.UserID into g
                              let am = g.Count()
                              select new { am, uID = g.Key };

            badgesReport[] rep = new badgesReport[badgesUsers.Count()];
            int index = 0;
            
            foreach(var badge in badgesUsers)
            {
                var user = from u in dbObjects.SystemUsers where u.UserID == badge.uID select u;
                rep[index] = new badgesReport();
                rep[index].Name = user.FirstOrDefault().FirstName;
                rep[index].Number = badge.am;
                index++;
            }

            return rep;
        }

        public ratingsReport[] getNPORatingReport(int orgID)
        {
            var ratings = from r in dbObjects.NPORatings
                          where r.OrganisationID == orgID
                          group r by r.Rating into g
                          let am = g.Count()
                          select new { am, rat = g.Key };

            ratingsReport[] rep = new ratingsReport[ratings.Count()];
            int index = 0;

            foreach (var rating in ratings)
            {
                rep[index] = new ratingsReport();
                rep[index].Value = "" + rating.rat;
                rep[index].Count = rating.am;
                index++;
            }

            return rep;
        }

        public reportDonation[] getDonationsForComparison(int orgID, string sortBy)
        {
            if (sortBy.Equals("Y"))
            {
                var amo = from a in dbObjects.Donations
                          where a.OrganisationID == orgID
                          group a by a.DonationDate.Value.Year into g
                          let am = g.Sum(ar => ar.DonationRequest.Amount)
                          select new { am, date = g.Key };
                reportDonation[] ret = new reportDonation[amo.Count()];
                int index = 0;
                foreach (var a in amo)
                {
                    ret[index] = new reportDonation();
                    ret[index].Date = a.date.ToString();
                    ret[index].Amount = Convert.ToDouble(a.am);
                    index++;
                }
                return ret;
            }
            else if (sortBy.Equals("M"))
            {
                var amo = from a in dbObjects.Donations
                          where a.OrganisationID == orgID
                          group a by new {a.DonationDate.Value.Month, a.DonationDate.Value.Year} into g
                          let am = g.Sum(ar => ar.DonationRequest.Amount)
                          select new { am, date = g.Key };
                reportDonation[] ret = new reportDonation[amo.Count()];
                int index = 0;
                foreach (var a in amo)
                {
                    ret[index] = new reportDonation();
                    ret[index].Date = a.date.Month + "/" + a.date.Year;
                    ret[index].Amount = Convert.ToDouble(a.am);
                    index++;
                }
                return ret;
            }

            return null;
        }

        public bool chechForNewDonations(int orgID, DateTime lastOnline)
        {
            var dons = from d in dbObjects.Donations where d.OrganisationID == orgID select d;

            foreach (Donation don in dons)
            {
                if (don.DonationDate.Value >= lastOnline)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
