using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace Project_Leap_V3
{
    /// <summary>
    /// This class handles the display and functionality of the Dashboard page
    /// </summary>
    public partial class DashboardPage : System.Web.UI.Page
    {
        /// <summary>
        /// Private variable declaration
        /// </summary>
        public static bool onPage;
        public static DateTime lastOnline;

        /// <summary>
        /// This method is called and executed when the page is loaded.
        /// Depending on the type of user, different functionality is permitted and restricted by the system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                onPage = true;
                index.onPage = false;
                RegisterPage.onPage = false;
                HelpPage.onPage = false;
                login.onPage = false;
                UserListPage.onPage = false;
                ReportPage.onPage = false;

                ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
                ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

                if (Request.Cookies["LastOnline"] != null)
                {
                    lastOnline = DateTime.Parse(Request.Cookies["LastOnline"].Value);
                }
                else
                {
                    lastOnline = DateTime.Today;
                }
                
                Response.Cookies["LastOnline"].Value = DateTime.Today.ToString();

                try
                {
                    if ((int)HttpContext.Current.Session["User_lvl"] == 1)
                    {
                        dashBoardBusFin.Visible = false;
                        dashBoardBusMan.Visible = false;
                        dashBoardNPOFin.Visible = false;
                        dashBoardInd.Visible = false;
                        dashBoardSysAdm.Visible = false;
                        dashBoardSysMan.Visible = false;

                        if (service.chechForNewDonations(service.getNPOWithManager(user.userValue.UserID), lastOnline))
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallPopUp", "ohSnap('You received a new donation. Please check it out.', 'green')", true);
                        }

                        if (service.GetNextEvent((service.getNPOWithManager(user.userValue.UserID))) != null)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallPopUp", "ohSnap('You have an event coming up.', 'green')", true);
                        }

                        npoDonations.Visible = false;
                        npoEvents.Visible = false;
                        npoFundCamps.Visible = false;
                        npoMans.Visible = false;
                        viewVols.Visible = false;
                        npoReports.Visible = false;
                        summaryNPO.Visible = true;
                        sideBarNPO.Visible = true;
                        mainNPO.Visible = false;
                    }
                    if ((int)HttpContext.Current.Session["User_lvl"] == 2)
                    {
                        dashBoardInd.Visible = false;
                        dashBoardNPOMan.Visible = false;
                        dashBoardBusFin.Visible = false;
                        dashBoardBusMan.Visible = false;
                        dashBoardSysAdm.Visible = false;
                        dashBoardSysMan.Visible = false;

                        finMDon.Visible = true;
                        finMFC.Visible = false;
                    }
                    if ((int)HttpContext.Current.Session["User_lvl"] == 3)
                    {
                        dashBoardBusFin.Visible = false;
                        dashBoardNPOMan.Visible = false;
                        dashBoardNPOFin.Visible = false;
                        dashBoardInd.Visible = false;
                        dashBoardSysAdm.Visible = false;
                        dashBoardSysMan.Visible = false;

                        if (service.getNextNPOEvent(user.userValue.UserID) != null)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallPopUp", "ohSnap('You have an event coming up.', 'green')", true);
                        }

                        busDon.Visible = false;
                        busE.Visible = false;
                        busFC.Visible = false;
                        busFMan.Visible = false;
                        busManReports.Visible = false;
                        summaryBus.Visible = true;
                        mainBusMan.Visible = false;
                        sideBusMan.Visible = true;
                    }
                    if ((int)HttpContext.Current.Session["User_lvl"] == 4)
                    {
                        dashBoardInd.Visible = false;
                        dashBoardNPOMan.Visible = false;
                        dashBoardNPOFin.Visible = false;
                        dashBoardBusMan.Visible = false;
                        dashBoardSysAdm.Visible = false;
                        dashBoardSysMan.Visible = false;
                    }
                    if ((int)HttpContext.Current.Session["User_lvl"] == 5)
                    {
                        dashBoardNPOFin.Visible = false;
                        dashBoardNPOMan.Visible = false;
                        dashBoardBusFin.Visible = false;
                        dashBoardBusMan.Visible = false;
                        dashBoardSysAdm.Visible = false;
                        dashBoardSysMan.Visible = false;

                        if (service.getNextVolunteer(user.userValue.UserID) != null)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallPopUp", "ohSnap('You have volunteering coming up.', 'green')", true);
                        }

                        indVol.Visible = false;
                        indDon.Visible = false;
                        indFC.Visible = false;
                        summaryInd.Visible = true;
                        mainInd.Visible = false;
                        sideInd.Visible = true;
                        indBadges.Visible = false;
                        indReports.Visible = false;
                    }
                    if ((int)HttpContext.Current.Session["User_lvl"] == 6)
                    {
                        dashBoardNPOFin.Visible = false;
                        dashBoardNPOMan.Visible = false;
                        dashBoardBusFin.Visible = false;
                        dashBoardBusMan.Visible = false;
                        dashBoardSysAdm.Visible = false;
                        dashBoardInd.Visible = false;

                        verifyPage.Visible = true;
                        reportsSysMan.Visible = false;
                        sideSysMan.Visible = true;
                    }
                    if ((int)HttpContext.Current.Session["User_lvl"] == 7)
                    {
                        dashBoardNPOFin.Visible = false;
                        dashBoardNPOMan.Visible = false;
                        dashBoardBusFin.Visible = false;
                        dashBoardBusMan.Visible = false;
                        dashBoardInd.Visible = false;
                        dashBoardSysMan.Visible = false;

                        admAddAdm.Visible = false;
                        admAddMan.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("HomePage.aspx");
                }

                for (int a = 0; a < 1000; a++)
                {
                    for (int b = 0; b < 1000; b++)
                    {
                        for (int c = 0; c < 1000; c++)
                        {

                        }
                    }
                }    
            }

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallPopUp", "ohSnap('Goin green sonsssssssssssssssssssssssssssssssssssssssssssssss!', 'blue')", true);
        }

        protected void btnSummary_Click(object sender, EventArgs e)
        {
            npoDonations.Visible = false;
            npoEvents.Visible = false;
            npoFundCamps.Visible = false;
            npoMans.Visible = false;
            viewVols.Visible = false;
            npoReports.Visible = false;
            summaryNPO.Visible = true;
            sideBarNPO.Visible = true;
            mainNPO.Visible = false;
        }

        protected void btnDonations_Click(object sender, EventArgs e)
        {
            npoDonations.Visible = true;
            npoEvents.Visible = false;
            npoFundCamps.Visible = false;
            npoMans.Visible = false;
            viewVols.Visible = false;
            npoReports.Visible = false;
            summaryNPO.Visible = false;
            sideBarNPO.Visible = false;
            mainNPO.Visible = true;
        }

        protected void btnEvent_Click(object sender, EventArgs e)
        {
            npoDonations.Visible = false;
            npoEvents.Visible = true;
            npoFundCamps.Visible = false;
            npoMans.Visible = false;
            viewVols.Visible = false;
            npoReports.Visible = false;
            summaryNPO.Visible = false;
            sideBarNPO.Visible = false;
            mainNPO.Visible = true;
        }

        protected void btnFundCamp_Click(object sender, EventArgs e)
        {
            npoDonations.Visible = false;
            npoEvents.Visible = false;
            npoFundCamps.Visible = true;
            npoMans.Visible = false;
            viewVols.Visible = false;
            npoReports.Visible = false;
            summaryNPO.Visible = false;
            sideBarNPO.Visible = false;
            mainNPO.Visible = true;
        }

        protected void btnViewVols_Click(object sender, EventArgs e)
        {
            npoDonations.Visible = false;
            npoEvents.Visible = false;
            npoFundCamps.Visible = false;
            npoMans.Visible = false;
            viewVols.Visible = true;
            npoReports.Visible = false;
            summaryNPO.Visible = false;
            sideBarNPO.Visible = false;
            mainNPO.Visible = true;
        }

        protected void btnAddFinMan_Click(object sender, EventArgs e)
        {
            npoDonations.Visible = false;
            npoEvents.Visible = false;
            npoFundCamps.Visible = false;
            npoMans.Visible = true;
            viewVols.Visible = false;
            npoReports.Visible = false;
            summaryNPO.Visible = false;
            sideBarNPO.Visible = false;
            mainNPO.Visible = true;
        }

        protected void btnReportsNPO_Click(object sender, EventArgs e)
        {
            npoDonations.Visible = false;
            npoEvents.Visible = false;
            npoFundCamps.Visible = false;
            npoMans.Visible = false;
            viewVols.Visible = false;
            npoReports.Visible = true;
            summaryNPO.Visible = false;
            sideBarNPO.Visible = false;
            mainNPO.Visible = true;
        }
        

        protected void btnDonNPOFin_Click(object sender, EventArgs e)
        {
            finMDon.Visible = true;
            finMFC.Visible = false;
        }

        protected void btnFunCNPOFin_Click(object sender, EventArgs e)
        {
            finMDon.Visible = false;
            finMFC.Visible = true;
        }

        protected void btnSummaryDon_Click(object sender, EventArgs e)
        {
            busDon.Visible = false;
            busE.Visible = false;
            busFC.Visible = false;
            busFMan.Visible = false;
            busManReports.Visible = false;
            summaryBus.Visible = true;
            mainBusMan.Visible = false;
            sideBusMan.Visible = true;
        }

        protected void btnBusDon_Click(object sender, EventArgs e)
        {
            busDon.Visible = true;
            busE.Visible = false;
            busFC.Visible = false;
            busFMan.Visible = false;
            busManReports.Visible = false;
            summaryBus.Visible = false;
            mainBusMan.Visible = true;
            sideBusMan.Visible = false;
        }

        protected void btnBusEvent_Click(object sender, EventArgs e)
        {
            busDon.Visible = false;
            busE.Visible = true;
            busFC.Visible = false;
            busFMan.Visible = false;
            busManReports.Visible = false;
            summaryBus.Visible = false;
            mainBusMan.Visible = true;
            sideBusMan.Visible = false;
        }

        protected void btnBusFund_Click(object sender, EventArgs e)
        {
            busDon.Visible = false;
            busE.Visible = false;
            busFC.Visible = true;
            busFMan.Visible = false;
            busManReports.Visible = false;
            summaryBus.Visible = false;
            mainBusMan.Visible = true;
            sideBusMan.Visible = false;
        }

        protected void btnBusFin_Click(object sender, EventArgs e)
        {
            busDon.Visible = false;
            busE.Visible = false;
            busFC.Visible = false;
            busFMan.Visible = true;
            busManReports.Visible = false;
            summaryBus.Visible = false;
            mainBusMan.Visible = true;
            sideBusMan.Visible = false;
        }

        protected void btnReportsBusMan_Click(object sender, EventArgs e)
        {
            busDon.Visible = false;
            busE.Visible = false;
            busFC.Visible = false;
            busFMan.Visible = false;
            busManReports.Visible = true;
            summaryBus.Visible = false;
            mainBusMan.Visible = true;
            sideBusMan.Visible = false;
        }


        protected void btnISummary_Click(object sender, EventArgs e)
        {
            indVol.Visible = false;
            indDon.Visible = false;
            indFC.Visible = false;
            summaryInd.Visible = true;
            mainInd.Visible = false;
            sideInd.Visible = true;
            indBadges.Visible = false;
            indReports.Visible = false;
        }

        protected void btnIVol_Click(object sender, EventArgs e)
        {
            indVol.Visible = true;
            indDon.Visible = false;
            indFC.Visible = false;
            summaryInd.Visible = false;
            mainInd.Visible = true;
            sideInd.Visible = false;
            indBadges.Visible = false;
            indReports.Visible = false;
        }

        protected void btnIDon_Click(object sender, EventArgs e)
        {
            indVol.Visible = false;
            indDon.Visible = true;
            indFC.Visible = false;
            summaryInd.Visible = false;
            mainInd.Visible = true;
            sideInd.Visible = false;
            indBadges.Visible = false;
            indReports.Visible = false;
        }

        protected void btnIFC_Click(object sender, EventArgs e)
        {
            indVol.Visible = false;
            indDon.Visible = false;
            indFC.Visible = true;
            summaryInd.Visible = false;
            mainInd.Visible = true;
            sideInd.Visible = false;
            indBadges.Visible = false;
            indReports.Visible = false;
        }

        protected void btnIBadges_Click(object sender, EventArgs e)
        {
            indVol.Visible = false;
            indDon.Visible = false;
            indFC.Visible = false;
            summaryInd.Visible = false;
            mainInd.Visible = true;
            sideInd.Visible = false;
            indBadges.Visible = true;
            indReports.Visible = false;
        }

        protected void btnIReports_Click(object sender, EventArgs e)
        {
            indVol.Visible = false;
            indDon.Visible = false;
            indFC.Visible = false;
            summaryInd.Visible = false;
            mainInd.Visible = true;
            sideInd.Visible = false;
            indBadges.Visible = false;
            indReports.Visible = true;
        }

        protected void btnVerifyOrgs_Click(object sender, EventArgs e)
        {
            verifyPage.Visible = true;
            reportsSysMan.Visible = false;
            sideSysMan.Visible = true;
        }

        protected void btnReportSys_Click(object sender, EventArgs e)
        {
            verifyPage.Visible = false;
            reportsSysMan.Visible = true;
            sideSysMan.Visible = false;
        }


        protected void btnAddSysMan_Click(object sender, EventArgs e)
        {
            admAddAdm.Visible = false;
            admAddMan.Visible = true;
        }

        protected void btnAddSysAdn_Click(object sender, EventArgs e)
        {
            admAddAdm.Visible = true;
            admAddMan.Visible = false;
        }
    }
}