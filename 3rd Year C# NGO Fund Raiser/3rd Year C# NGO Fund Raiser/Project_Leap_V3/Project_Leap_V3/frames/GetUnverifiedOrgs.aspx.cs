using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Project_Leap_V3.frames
{
    public partial class GetUnverifiedOrgs : System.Web.UI.Page
    {
        private static int pageCount = 1;
        private int numOfUOs = 0;
        private static string searchStr = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 6)
            {
                ServiceReference1.Service1Client orgServ = new ServiceReference1.Service1Client();
                ServiceReference1.Orga[] orgList = orgServ.getOrganisations();

                divNPOTable.InnerHtml = "";
                divNPOTable.InnerHtml += "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'>";
                divNPOTable.InnerHtml += "<tr style='width: 100%; border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;'><th style='text-align: left; margin-right: 10px; width: 70px'>Name</th><th style='text-align: left; margin-right: 10px; width: 50px'>Type</th><th style='text-align: left; margin-right: 10px; width: 150px'>Industry</th><th style='text-align: left; margin-right: 10px; width: 30px'>Verify</th></tr>";

                ArrayList orgs = new ArrayList();

                for(int a = 0; a < orgList.Count(); a++)
                {
                    if(!orgList[a].Verified)
                    {
                        orgs.Add(orgList[a]);
                    }
                }

                ServiceReference1.Orga[] orgArr = (ServiceReference1.Orga[])orgs.ToArray(typeof(ServiceReference1.Orga));

                if (numOfUOs < orgArr.Count())
                {
                    numOfUOs = orgArr.Count();
                }

                for (int a = (pageCount - 1) * 10; a < pageCount * 10; a++)
                {
                    if (a >= numOfUOs)
                    {
                        break;
                    }

                    if (searchStr.Equals(""))
                    {
                        string type = "";
                        if (orgArr[a].Type == 1)
                        {
                            type = "NPO";
                        }
                        else if (orgArr[a].Type == 2)
                        {
                            type = "Business";
                        }

                        divNPOTable.InnerHtml += "<tr><td style='text-align: left; margin-right: 10px'>" + orgArr[a].OrgName + "</td><td style='text-align: left; margin-right: 10px'>" + type + "</td><td style='text-align: left; margin-right: 10px'>" + orgArr[a].Industry + "</td><td><a href='GetFileForVerification.aspx?orgId=" + orgArr[a].OrgID + "'>Verify</a></td></tr>";  
                    }
                    else
                    {
                        int numOfEvesAdded = 0;
                        for (int b = 0; b < numOfUOs; b++)
                        {
                            if (numOfEvesAdded > 9)
                            {
                                break;
                            }
                            if (orgArr[b].OrgName.Contains(searchStr))
                            {
                                string type = "";
                                if (orgArr[b].Type == 1)
                                {
                                    type = "NPO";
                                }
                                else if (orgArr[b].Type == 2)
                                {
                                    type = "Business";
                                }

                                divNPOTable.InnerHtml += "<tr><td style='text-align: left; margin-right: 10px'>" + orgArr[b].OrgName + "</td><td style='text-align: left; margin-right: 10px'>" + type + "</td><td style='text-align: left; margin-right: 10px'>" + orgArr[b].Industry + "</td><td><a href='GetFileForVerification.aspx?orgId=" + orgArr[b].OrgID + "'>Verify</a></td></tr>";  
                                numOfEvesAdded++;
                            }
                        }

                        searchStr = "";
                        txtSearch.Text = "";
                        break;
                    }
                }

                divNPOTable.InnerHtml += "</table>";
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
            if (pageCount * 10 < numOfUOs)
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
    }
}