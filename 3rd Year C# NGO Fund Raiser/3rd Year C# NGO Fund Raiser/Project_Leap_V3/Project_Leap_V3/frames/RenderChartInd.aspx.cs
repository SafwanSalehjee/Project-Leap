using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    public partial class RenderChartInd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlRenderChartBus.Items.Add("Daily Donations Made");
                ddlRenderChartBus.Items.Add("Most Active Independent Users");
                ddlRenderChartBus.Items.Add("Supported Organisations By Type");
                ddlRenderChartBus.Items.Add("Supported Organisations of a certain Type(Based on past support)");
                ddlRenderChartBus.Items.Add("Number Of Badges Users Have");
                ddlRenderChartBus.Items.Add("Top Donating Businesses");
            }

            DonationsMadeReport.Visible = false;
            Top10Bus.Visible = false;
            MostActInd.Visible = false;
            SupportedOrgs.Visible = false;
            SupportedOrgsSpesific.Visible = false;
            BadgesReport.Visible = false;

            if (ddlRenderChartBus.SelectedValue.Equals("Daily Donations Made"))
            {
                DonationsMadeReport.Visible = true;
            }
            else if (ddlRenderChartBus.SelectedValue.Equals("Top Donating Businesses"))
            {
                Top10Bus.Visible = true;
            }
            else if (ddlRenderChartBus.SelectedValue.Equals("Most Active Independent Users"))
            {
                MostActInd.Visible = true;
            }
            else if (ddlRenderChartBus.SelectedValue.Equals("Supported Organisations By Type"))
            {
                SupportedOrgs.Visible = true;
            }
            else if (ddlRenderChartBus.SelectedValue.Equals("Supported Organisations of a certain Type(Based on past support)"))
            {
                SupportedOrgsSpesific.Visible = true;
            }
            else if (ddlRenderChartBus.SelectedValue.Equals("Number Of Badges Users Have"))
            {
                BadgesReport.Visible = true;
            }
        }
    }
}