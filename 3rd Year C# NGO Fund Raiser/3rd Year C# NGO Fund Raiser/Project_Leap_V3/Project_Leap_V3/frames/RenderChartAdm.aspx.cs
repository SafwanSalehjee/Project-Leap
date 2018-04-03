using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    public partial class RenderChartAdm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlRenderChartNPO.Items.Add("System Income Generated");
                ddlRenderChartNPO.Items.Add("Predicted System Income");
                ddlRenderChartNPO.Items.Add("Daily User Registration");
                ddlRenderChartNPO.Items.Add("Daily Organisation Registration");
                ddlRenderChartNPO.Items.Add("Top Donating Businesses");
            }

            SystemIncomeRep.Visible = false;
            SystemPredInc.Visible = false;
            Top10Bus.Visible = false;
            DailyRegUsers.Visible = false;
            DailyRegOrgs.Visible = false;

            if (ddlRenderChartNPO.SelectedValue.Equals("System Income Generated"))
            {
                SystemIncomeRep.Visible = true;
            }
            else if (ddlRenderChartNPO.SelectedValue.Equals("Predicted System Income"))
            {
                SystemPredInc.Visible = true;
            }
            else if (ddlRenderChartNPO.SelectedValue.Equals("Top Donating Businesses"))
            {
                Top10Bus.Visible = true;
            }
            else if (ddlRenderChartNPO.SelectedValue.Equals("Daily User Registration"))
            {
                DailyRegUsers.Visible = true;
            }
            else if (ddlRenderChartNPO.SelectedValue.Equals("Daily Organisation Registration"))
            {
                DailyRegOrgs.Visible = true;
            }
        }
    }
}