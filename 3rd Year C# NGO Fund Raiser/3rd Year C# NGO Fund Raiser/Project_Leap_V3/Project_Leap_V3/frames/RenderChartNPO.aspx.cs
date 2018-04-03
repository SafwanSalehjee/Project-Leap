using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    public partial class RenderChartNPO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlRenderChartNPO.Items.Add("Daily Donations Received");
                ddlRenderChartNPO.Items.Add("Compare Donations");
                ddlRenderChartNPO.Items.Add("Volunteers Per Province");
                ddlRenderChartNPO.Items.Add("Fundraising Campaigns Progress");
                ddlRenderChartNPO.Items.Add("Top Donating Businesses");
                ddlRenderChartNPO.Items.Add("Volunteers Showing Up");
                ddlRenderChartNPO.Items.Add("Successful Fundraising Campaigns");
                ddlRenderChartNPO.Items.Add("Support NPO Industry By Province");
                ddlRenderChartNPO.Items.Add("Estimated Future Donations");
                ddlRenderChartNPO.Items.Add("Ratings");
            }
            DonationsRecievedReport.Visible = false;
            VolunteersPerRegion.Visible = false;
            FundCampCurrent.Visible = false;
            TopTenBus.Visible = false;
            ShowingUpCols.Visible = false;
            FCSuccessRate.Visible = false;
            SupportByRegion.Visible = false;
            PredictedDonations.Visible = false;
            RatingsRep.Visible = false;
            ComparableDons.Visible = false;

            if (ddlRenderChartNPO.SelectedValue.Equals("Daily Donations Received"))
            {
                DonationsRecievedReport.Visible = true;
            }
            else if (ddlRenderChartNPO.SelectedValue.Equals("Volunteers Per Province"))
            {
                VolunteersPerRegion.Visible = true;
            }
            else if (ddlRenderChartNPO.SelectedValue.Equals("Fundraising Campaigns Progress"))
            {
                FundCampCurrent.Visible = true;
            }
            else if (ddlRenderChartNPO.SelectedValue.Equals("Top Donating Businesses"))
            {
                TopTenBus.Visible = true;
            }
            else if (ddlRenderChartNPO.SelectedValue.Equals("Volunteers Showing Up"))
            {
                ShowingUpCols.Visible = true;
            }
            else if (ddlRenderChartNPO.SelectedValue.Equals("Successful Fundraising Campaigns"))
            {
                FCSuccessRate.Visible = true;
            }
            else if (ddlRenderChartNPO.SelectedValue.Equals("Support NPO Industry By Province"))
            {
                SupportByRegion.Visible = true;
            }
            else if (ddlRenderChartNPO.SelectedValue.Equals("Estimated Future Donations"))
            {
                PredictedDonations.Visible = true;
            }
            else if (ddlRenderChartNPO.SelectedValue.Equals("Ratings"))
            {
                RatingsRep.Visible = true;
            }
            else if (ddlRenderChartNPO.SelectedValue.Equals("Compare Donations"))
            {
                ComparableDons.Visible = true;
            }
        }
    }
}