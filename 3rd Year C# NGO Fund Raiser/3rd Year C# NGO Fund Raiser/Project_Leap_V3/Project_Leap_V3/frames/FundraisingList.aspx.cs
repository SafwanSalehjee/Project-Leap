using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Project_Leap_V3.frames
{
    public partial class FundraisingList : System.Web.UI.Page
    {
        private static int pageCount = 1;
        private int numOfFCs = 0;
        private static string searchStr = "";

        private static int pageCountDone = 1;
        private int numOfFCsDone = 0;
        private static string searchStrDone = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] > 0)
            {
                FCDoneNPO.Visible = false;
                ServiceReference1.Service1Client sev = new ServiceReference1.Service1Client();
                ServiceReference1.cFundraisingCampaign[] fcList;
                ServiceReference1.UserDetail u = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

                if ((int)HttpContext.Current.Session["User_lvl"] == 1 || (int)HttpContext.Current.Session["User_lvl"] == 2)
                {
                    FCDoneNPO.Visible = true;
                    fcList = sev.getOwnFundraisingCampaigns(sev.getNPOWithManager(u.userValue.UserID));

                    if (numOfFCs < fcList.Count())
                    {
                        numOfFCs = fcList.Count();
                    }

                    dFClist.InnerHtml = "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'><tr style='width: 100%; border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><td style='text-align: left; margin-right: 10px'>Title</td><td style='text-align: left; margin-right: 10px'>Description</td><td style='text-align: left; margin-right: 10px'>Current Amount</td><td style='text-align: left; margin-right: 10px'>Total Requested</td></tr>";
                    dFClistDone.InnerHtml = "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'><tr style='width: 100%; border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><td style='text-align: left; margin-right: 10px'>Title</td><td style='text-align: left; margin-right: 10px'>Description</td><td style='text-align: left; margin-right: 10px'>Current Amount</td><td style='text-align: left; margin-right: 10px'>Total Requested</td></tr>";

                    numOfFCs = 0;
                    numOfFCsDone = 0;

                    foreach (ServiceReference1.cFundraisingCampaign fc in fcList)
                    {
                        if (fc.VCurrentAmount >= fc.VTotalAmount)
                            numOfFCsDone++;
                        else
                            numOfFCs++;
                    }

                    ServiceReference1.cFundraisingCampaign[] fcNew = new ServiceReference1.cFundraisingCampaign[numOfFCs];
                    ServiceReference1.cFundraisingCampaign[] fcOld = new ServiceReference1.cFundraisingCampaign[numOfFCsDone];
                    int oldCount = 0;
                    int newCount = 0;

                    foreach (ServiceReference1.cFundraisingCampaign fc in fcList)
                    {
                        if (fc.VCurrentAmount >= fc.VTotalAmount)
                        {
                            fcOld[oldCount] = fc;
                            oldCount++;
                        }
                        else
                        {
                            fcNew[newCount] = fc;
                            newCount++;
                        }
                    }

                    for (int a = (pageCount - 1) * 8; a < pageCount * 8; a++)
                    {
                        if (a >= numOfFCs)
                        {
                            break;
                        }

                        if (searchStr.Equals(""))
                        {
                            dFClist.InnerHtml += "<tr><td>" + fcNew[a].VTitle + "</td><td style='text-align: left; margin-right: 10px;'>" + fcNew[a].VDescription + "</td><td style='text-align: right; padding-right: 10px;'>R " + fcNew[a].VCurrentAmount + "</td><td style='text-align: right; padding-right: 10px;'>R " + fcNew[a].VTotalAmount + "</td></tr>";
                        }
                        else
                        {
                            int numOfFCsAdded = 0;
                            for (int b = 0; b < numOfFCs; b++)
                            {
                                if (numOfFCsAdded > 7)
                                {
                                    break;
                                }
                                if (fcNew[b].VDescription.Contains(searchStr))
                                {
                                    if ((fcNew[b].VTotalAmount - fcNew[b].VCurrentAmount) > 0)
                                        dFClist.InnerHtml += "<tr><td>" + fcNew[b].VTitle + "</td><td style='text-align: left; margin-right: 10px;'>" + fcNew[b].VDescription + "</td><td style='text-align: right; padding-right: 10px;'>R " + fcNew[b].VCurrentAmount + "</td><td style='text-align: right; padding-right: 10px;'>R " + fcNew[b].VTotalAmount + "</td></tr>";
                                    numOfFCsAdded++;
                                }
                            }

                            searchStr = "";
                            txtSearch.Text = "";
                            break;
                        }
                    }

                    dFClist.InnerHtml += "</table>";

                    for (int a = (pageCountDone - 1) * 8; a < pageCountDone * 8; a++)
                    {
                        if (a >= numOfFCsDone)
                        {
                            break;
                        }

                        if (searchStrDone.Equals(""))
                        {
                            dFClistDone.InnerHtml += "<tr><td>" + fcOld[a].VTitle + "</td><td style='text-align: left; margin-right: 10px;'>" + fcOld[a].VDescription + "</td><td style='text-align: right; padding-right: 10px;'>R " + fcOld[a].VCurrentAmount + "</td><td style='text-align: right; padding-right: 10px;'>R " + fcOld[a].VTotalAmount + "</td></tr>";
                        }
                        else
                        {
                            int numOfFCsAdded = 0;
                            for (int b = 0; b < numOfFCsDone; b++)
                            {
                                if (numOfFCsAdded > 7)
                                {
                                    break;
                                }
                                if (fcOld[b].VDescription.Contains(searchStrDone))
                                {
                                    dFClistDone.InnerHtml += "<tr><td>" + fcOld[b].VTitle + "</td><td style='text-align: left; margin-right: 10px;'>" + fcOld[b].VDescription + "</td><td style='text-align: right; padding-right: 10px;'>R " + fcOld[b].VCurrentAmount + "</td><td style='text-align: right; padding-right: 10px;'>R " + fcOld[b].VTotalAmount + "</td></tr>";
                                    numOfFCsAdded++;
                                }
                            }

                            searchStrDone = "";
                            txtSearchDone.Text = "";
                            break;
                        }
                    }

                    dFClistDone.InnerHtml += "</table>";
                }
                else
                {
                    fcList = sev.getAllFundRaisingCampaign(u.userValue.UserID);

                    ArrayList fcs = new ArrayList();

                    for (int a = 0; a < fcList.Length; a++)
                    {
                        if ((fcList[a].VTotalAmount - fcList[a].VCurrentAmount) > 0)
                        {
                            ServiceReference1.Organisation org = sev.getOrg(fcList[a].OrgID1);
                            if ((bool)org.Verified)
                            {
                                fcs.Add(fcList[a]);
                            }
                        }
                    }

                    ServiceReference1.cFundraisingCampaign[] avFCs = (ServiceReference1.cFundraisingCampaign[])fcs.ToArray(typeof(ServiceReference1.cFundraisingCampaign));

                    if (numOfFCs < avFCs.Count())
                    {
                        numOfFCs = avFCs.Count();
                    }

                    dFClist.InnerHtml = "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'><tr style='width: 100%; border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><td style='text-align: left; margin-right: 10px'>Title</td><td style='text-align: left; margin-right: 10px'>Organisation</td><td style='text-align: left; margin-right: 10px'>Description</td><td style='text-align: left; margin-right: 10px'>Current Amount</td><td style='text-align: left; margin-right: 10px'>Total Requested</td></tr>";

                    for (int a = (pageCount - 1) * 8; a < pageCount * 8; a++)
                    {
                        if (a >= numOfFCs)
                        {
                            break;
                        }

                        if (searchStr.Equals(""))
                        {
                            dFClist.InnerHtml += "<tr><td>" + avFCs[a].VTitle + "</td><td>" + sev.getOrg(avFCs[a].OrgID1).OrganisationName + "</td><td style='text-align: left; margin-right: 10px; width: 150px;'>" + avFCs[a].VDescription + "</td><td style='text-align: right; padding-right: 10px;'>R " + avFCs[a].VCurrentAmount + "<a href='DonatToFund.aspx?FID=" + avFCs[a].IDF + "'>+</a></td><td style='text-align: right; padding-right: 10px;'>R " + avFCs[a].VTotalAmount + "</td></tr>";
                        }
                        else
                        {
                            int numOfFCsAdded = 0;
                            for (int b = 0; b < numOfFCs; b++)
                            {
                                if (numOfFCsAdded > 7)
                                {
                                    break;
                                }
                                if (avFCs[b].VDescription.Contains(searchStr))
                                {
                                    dFClist.InnerHtml += "<tr><td>" + avFCs[b].VTitle + "</td><td>" + sev.getOrg(avFCs[b].OrgID1).OrganisationName + "</td><td style='text-align: left; margin-right: 10px; width: 150px;'>" + avFCs[b].VDescription + "</td><td style='text-align: right; padding-right: 10px;'>R " + avFCs[b].VCurrentAmount + "<a href='DonatToFund.aspx?FID=" + avFCs[b].IDF + "'>+</a></td><td style='text-align: right; padding-right: 10px;'>R " + avFCs[b].VTotalAmount + "</td></tr>";
                                    numOfFCsAdded++;
                                }
                            }

                            searchStr = "";
                            txtSearch.Text = "";
                            break;
                        }
                    }

                    dFClist.InnerHtml += "</table>";
                }
            }
        }

        protected void btnPrevs_Click(object sender, EventArgs e)
        {
            if (pageCount > 1)
            {
                pageCount--;
                Page_Load(sender, e);
            }
        }

        protected void btnNexts_Click(object sender, EventArgs e)
        {
            if (pageCount * 8 < numOfFCs)
            {
                pageCount++;
                Page_Load(sender, e);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            searchStr = txtSearch.Text;
            Page_Load(sender, e);
        }

        protected void btnPrevsDone_Click(object sender, EventArgs e)
        {
            if (pageCountDone > 1)
            {
                pageCountDone--;
                Page_Load(sender, e);
            }
        }

        protected void btnNextsDone_Click(object sender, EventArgs e)
        {
            if (pageCountDone * 8 < numOfFCsDone)
            {
                pageCountDone++;
                Page_Load(sender, e);
            }
        }

        protected void btnSearchDone_Click(object sender, EventArgs e)
        {
            searchStrDone = txtSearchDone.Text;
            Page_Load(sender, e);
        }
    }
}