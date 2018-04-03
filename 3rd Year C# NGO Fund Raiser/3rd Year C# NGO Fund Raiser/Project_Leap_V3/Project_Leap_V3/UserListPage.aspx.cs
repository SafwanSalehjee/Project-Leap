using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Project_Leap_V3
{
    /// <summary>
    /// The page displays the full list of users
    /// </summary>
    public partial class UserListPage : System.Web.UI.Page
    {
        /// <summary>
        /// Private variable declaration
        /// </summary>
        public static bool onPage;

        private static int pageCountInd = 1;
        private int numOfInd = 0;
        private static string searchStrInd = "";

        private static int pageCountNPO = 1;
        private int numOfNPO = 0;
        private static string searchStrNPO = "";

        private static int pageCountBus = 1;
        private int numOfBus = 0;
        private static string searchStrBus = "";

        /// <summary>
        /// This method is called and executed when the page is loaded.
        /// A list of all the users is generated and displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] > 0 && (int)HttpContext.Current.Session["User_lvl"] < 8)
            {
                divInd.Visible = true;
                divBus.Visible = true;
                divNPO.Visible = true;

                if ((int)HttpContext.Current.Session["User_lvl"] == 1 || (int)HttpContext.Current.Session["User_lvl"] == 2 || (int)HttpContext.Current.Session["User_lvl"] == 3 || (int)HttpContext.Current.Session["User_lvl"] == 4 || (int)HttpContext.Current.Session["User_lvl"] == 5)
                {
                    divInd.Visible = false;
                }

                onPage = true;
                index.onPage = false;
                RegisterPage.onPage = false;
                HelpPage.onPage = false;
                login.onPage = false;
                DashboardPage.onPage = false;

                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                ServiceReference1.User[] usersList = serv.getUsers();

                divIndTable.InnerHtml = "";
                divIndTable.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'>";
                divIndTable.InnerHtml += "<tr style='width: 100%; border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th style='text-align: left; margin-right: 10px;'>Email</th><th style='text-align: left; margin-right: 10px;'>Name</th><th style='text-align: left; margin-right: 10px;'>Surname</th><th style='text-align: left; margin-right: 10px;'>User type</th></tr>";

                if (numOfInd < usersList.Count())
                {
                    numOfInd = usersList.Count();
                }

                for (int a = (pageCountInd - 1) * 10; a < pageCountInd * 10; a++)
                {
                    if (a >= numOfInd)
                    {
                        break;
                    }

                    if (searchStrInd.Equals(""))
                    {
                        if (usersList[a].BannedValue == false)
                        {
                            string type = "";

                            if (usersList[a].TypeValue == 1)
                            {
                                type = "NPO manager";
                            }
                            else if (usersList[a].TypeValue == 2)
                            {
                                type = "NPO financial manager";
                            }
                            else if (usersList[a].TypeValue == 3)
                            {
                                type = "Business manager";
                            }
                            else if (usersList[a].TypeValue == 4)
                            {
                                type = "Business financial manager";
                            }
                            else if (usersList[a].TypeValue == 5)
                            {
                                type = "Independent user";
                            }
                            else if (usersList[a].TypeValue == 6)
                            {
                                type = "System manager";
                            }
                            else if (usersList[a].TypeValue == 7)
                            {
                                type = "System administrator";
                            }

                            divIndTable.InnerHtml += "<tr><td><a href='UserPage.aspx?userId=" + usersList[a].IDValue + "'>" + usersList[a].EmailValue + "</a></td><td>" + usersList[a].FirstNameValue + "</td><td>" + usersList[a].LastNameValue + "</td><td>" + type + "</td></tr>";
                        }
                    }
                    else
                    {
                        int numOfIndsAdded = 0;
                        for (int b = 0; b < numOfInd; b++)
                        {
                            if (numOfIndsAdded > 9)
                            {
                                break;
                            }
                            if (usersList[b].BannedValue == false)
                            {
                                if (usersList[b].FirstNameValue.Contains(searchStrInd))
                                {
                                    string type = "";

                                    if (usersList[b].TypeValue == 1)
                                    {
                                        type = "NPO manager";
                                    }
                                    else if (usersList[b].TypeValue == 2)
                                    {
                                        type = "NPO financial manager";
                                    }
                                    else if (usersList[b].TypeValue == 3)
                                    {
                                        type = "Business manager";
                                    }
                                    else if (usersList[b].TypeValue == 4)
                                    {
                                        type = "Business financial manager";
                                    }
                                    else if (usersList[b].TypeValue == 5)
                                    {
                                        type = "Independent user";
                                    }
                                    else if (usersList[b].TypeValue == 6)
                                    {
                                        type = "System manager";
                                    }
                                    else if (usersList[b].TypeValue == 7)
                                    {
                                        type = "System administrator";
                                    }

                                    divIndTable.InnerHtml += "<tr><td><a href='UserPage.aspx?userId=" + usersList[b].IDValue + "'>" + usersList[b].EmailValue + "</a></td><td>" + usersList[b].FirstNameValue + "</td><td>" + usersList[b].LastNameValue + "</td><td>" + type + "</td></tr>";
                                    numOfIndsAdded++;
                                }
                            }
                        }

                        searchStrInd = "";
                        txtSearchInd.Text = "";
                        break;
                    }
                }

                divIndTable.InnerHtml += "</table>";

                ServiceReference1.Service1Client orgServ = new ServiceReference1.Service1Client();
                ServiceReference1.Orga[] orgList = orgServ.getOrganisations();

                divNPOTable.InnerHtml = "";
                divNPOTable.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'>";
                divNPOTable.InnerHtml += "<tr style='width: 100%; border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th style='text-align: left; margin-right: 10px; width: 150px'>Name</th><th style='text-align: left; margin-right: 10px; width: 150px'>Industry</th><th style='text-align: left; margin-right: 10px; width: 100px'>Contact Number</th><th style='text-align: left; margin-right: 10px; width: 30px'>Verified</th></tr>";

                BusinessDiv.InnerHtml = "";
                BusinessDiv.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'>";
                BusinessDiv.InnerHtml += "<tr style='width: 100%; border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th style='text-align: left; margin-right: 10px; width: 150px'>Name</th><th style='text-align: left; margin-right: 10px; width: 150px'>Industry</th><th style='text-align: left; margin-right: 10px; width: 100px'>Contact Number</th><th style='text-align: left; margin-right: 10px; width: 30px'>Verified</th></tr>";

                ArrayList npoAL = new ArrayList();
                ArrayList busAL = new ArrayList();

                // Depending on the type of organisation, it will be displayed in the correct place on the page
                foreach (ServiceReference1.Orga organisation in orgList)
                {
                    if (organisation.Banned == false)
                    {
                        if (organisation.Type == 1)
                        {
                            npoAL.Add(organisation);
                        }
                        else if (organisation.Type == 2)
                        {
                            busAL.Add(organisation);
                        }
                    }
                }

                ServiceReference1.Orga[] npoAr = (ServiceReference1.Orga[])npoAL.ToArray(typeof(ServiceReference1.Orga));
                ServiceReference1.Orga[] busAr = (ServiceReference1.Orga[])busAL.ToArray(typeof(ServiceReference1.Orga));

                if (numOfNPO < npoAr.Count())
                {
                    numOfNPO = npoAr.Count();
                }

                for (int a = (pageCountNPO - 1) * 8; a < pageCountNPO * 8; a++)
                {
                    if (a >= numOfNPO)
                    {
                        break;
                    }

                    if (searchStrNPO.Equals(""))
                    {

                        string verified = "";

                        if (npoAr[a].Verified)
                        {
                            verified = "Yes";
                        }
                        else
                        {
                            verified = "No";
                        }

                        divNPOTable.InnerHtml += "<tr><td><a href='UserPage.aspx?orgId=" + npoAr[a].OrgID + "'>" + npoAr[a].OrgName + "</a></td><td>" + npoAr[a].Industry + "</td><td>" + npoAr[a].ContactNum + "</td><td>" + verified + "</td></tr>";
                    }
                    else
                    {
                        int numOfNPOAdded = 0;
                        for (int b = 0; b < numOfNPO; b++)
                        {
                            if (numOfNPOAdded > 7)
                            {
                                break;
                            }

                            if (npoAr[b].OrgName.Contains(searchStrNPO))
                            {
                                string verified = "";

                                if (npoAr[b].Verified)
                                {
                                    verified = "Yes";
                                }
                                else
                                {
                                    verified = "No";
                                }

                                divNPOTable.InnerHtml += "<tr><td><a href='UserPage.aspx?orgId=" + npoAr[b].OrgID + "'>" + npoAr[b].OrgName + "</a></td><td>" + npoAr[b].Industry + "</td><td>" + npoAr[b].ContactNum + "</td><td>" + verified + "</td></tr>";

                                numOfNPOAdded++;
                            }
                        }

                        searchStrNPO = "";
                        txtSearchNPO.Text = "";
                        break;
                    }
                }

                if (numOfBus < busAr.Count())
                {
                    numOfBus = busAr.Count();
                }

                for (int a = (pageCountBus - 1) * 8; a < pageCountBus * 8; a++)
                {
                    if (a >= numOfBus)
                    {
                        break;
                    }

                    if (searchStrBus.Equals(""))
                    {

                        string verified = "";

                        if (busAr[a].Verified)
                        {
                            verified = "Yes";
                        }
                        else
                        {
                            verified = "No";
                        }

                        BusinessDiv.InnerHtml += "<tr><td><a href='UserPage.aspx?orgId=" + busAr[a].OrgID + "'>" + busAr[a].OrgName + "</a></td><td>" + busAr[a].Industry + "</td><td>" + busAr[a].ContactNum + "</td><td>" + verified + "</td></tr>";
                    }
                    else
                    {
                        int numOfBusAdded = 0;
                        for (int b = 0; b < numOfBus; b++)
                        {
                            if (numOfBusAdded > 7)
                            {
                                break;
                            }

                            if (busAr[b].OrgName.Contains(searchStrBus))
                            {
                                string verified = "";

                                if (busAr[b].Verified)
                                {
                                    verified = "Yes";
                                }
                                else
                                {
                                    verified = "No";
                                }

                                BusinessDiv.InnerHtml += "<tr><td><a href='UserPage.aspx?orgId=" + busAr[b].OrgID + "'>" + busAr[b].OrgName + "</a></td><td>" + busAr[b].Industry + "</td><td>" + busAr[b].ContactNum + "</td><td>" + verified + "</td></tr>";

                                numOfBusAdded++;
                            }
                        }

                        searchStrBus = "";
                        txtSearchBus.Text = "";
                        break;
                    }
                }

                divNPOTable.InnerHtml += "</table>";
                BusinessDiv.InnerHtml += "</table>";

                //String[] types = serv.getNPOTypes();

                //ddlFilter.Items.Add("Select type of NPO");

                //for (int i = 0; i < types.Length; i++)
                //{
                //    ddlFilter.Items.Add(types[i]);
                //}



                //if (ddlFilter.SelectedIndex > 0)
                //{
                //    String selectedType = ddlFilter.SelectedItem.ToString();

                //    //ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                //    ServiceReference1.Orga[] orgList2 = serv.getNPOofType(selectedType);
                //    divNPOTable.InnerHtml = "";
                //    divNPOTable.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'>";
                //    divNPOTable.InnerHtml += "<tr style='width: 100%; border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th>Name</th><th>Industry</th><th>Contact Number</th></tr>";

                //    // Depending on the type of organisation, it will be displayed in the correct place on the page
                //    foreach (ServiceReference1.Orga organisation in orgList2)
                //    {
                //        divNPOTable.InnerHtml += "<tr><td><a href='UserPage.aspx?orgId=" + organisation.OrgID + "'>" + organisation.OrgName + "</a></td><td>" + organisation.Industry + "</td><td>" + organisation.ContactNum + "</tr>";
                //    }
                //    divNPOTable.InnerHtml += "</table>";
                //}
                //else
                //{
                //    // ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                //    ServiceReference1.Orga[] orgList2 = serv.getOrganisations();
                //    divNPOTable.InnerHtml = "";
                //    divNPOTable.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'>";
                //    divNPOTable.InnerHtml += "<tr style='width: 100%; border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th>Name</th><th>Industry</th><th>Contact Number</th></tr>";

                //    // Depending on the type of organisation, it will be displayed in the correct place on the page
                //    foreach (ServiceReference1.Orga organisation in orgList2)
                //    {
                //        if (organisation.Type == 1)
                //        {
                //            divNPOTable.InnerHtml += "<tr><td><a href='UserPage.aspx?orgId=" + organisation.OrgID + "'>" + organisation.OrgName + "</a></td><td>" + organisation.Industry + "</td><td>" + organisation.ContactNum + "</tr>";
                //        }
                //    }
                //    divNPOTable.InnerHtml += "</table>";
                //}

            }
        }

        protected void btnSearchInd_Click(object sender, EventArgs e)
        {
            searchStrInd = txtSearchInd.Text;
            Page_Load(sender, e);
        }

        protected void btnSearchNPO_Click(object sender, EventArgs e)
        {
            searchStrNPO = txtSearchNPO.Text;
            Page_Load(sender, e);
        }

        protected void btnSearchBus_Click(object sender, EventArgs e)
        {
            searchStrBus = txtSearchBus.Text;
            Page_Load(sender, e);
        }

        protected void btnPrevsInd_Click(object sender, EventArgs e)
        {
            if (pageCountInd > 1)
            {
                pageCountInd--;
                Page_Load(sender, e);
            }
        }

        protected void btnNextsInd_Click(object sender, EventArgs e)
        {
            if (pageCountInd * 10 < numOfInd)
            {
                pageCountInd++;
                Page_Load(sender, e);
            }
        }

        protected void btnPrevsBus_Click(object sender, EventArgs e)
        {
            if (pageCountBus > 1)
            {
                pageCountBus--;
                Page_Load(sender, e);
            }
        }

        protected void btnNextsBus_Click(object sender, EventArgs e)
        {
            if (pageCountBus * 8 < numOfBus)
            {
                pageCountBus++;
                Page_Load(sender, e);
            }
        }

        protected void btnPrevsNPO_Click(object sender, EventArgs e)
        {
            if (pageCountNPO > 1)
            {
                pageCountNPO--;
                Page_Load(sender, e);
            }
        }

        protected void btnNextsNPO_Click(object sender, EventArgs e)
        {
            if (pageCountNPO * 8 < numOfNPO)
            {
                pageCountNPO++;
                Page_Load(sender, e);
            }
        }
    }
}