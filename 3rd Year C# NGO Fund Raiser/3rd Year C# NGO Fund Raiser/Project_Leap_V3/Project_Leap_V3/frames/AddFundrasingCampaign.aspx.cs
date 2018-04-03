using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// Used to add fundraising campaigns
    /// </summary>
    public partial class AddFundrasingCampaign : System.Web.UI.Page
    {
        ServiceReference1.UserDetail user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
            if (user.AccessLvl > 1)
            {
                Response.Redirect("DashboardPage.aspx");
            }
        }
        protected void btnAddFundrasingCampaign_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 1)
            {
                ServiceReference1.Service1Client sev = new ServiceReference1.Service1Client();

                ServiceReference1.cFundraisingCampaign fundC = new ServiceReference1.cFundraisingCampaign();

                int orgID = sev.getNPOWithManager(user.userValue.UserID);

                try
                {
                    fundC.VTitle = txtTitle.Text;
                    fundC.VDescription = txtDescription.Text;
                    fundC.VTotalAmount = Convert.ToDouble(txtAmount.Text);
                    fundC.OrgID1 = orgID;
                    fundC.VCurrentAmount = 0;

                    if (sev.AddNewFundraisingCamp(fundC))
                    {
                        lblAdded.ForeColor = System.Drawing.Color.Black;
                        lblAdded.Text = "Campaign added successfully";
                    }
                    else
                    {
                        lblAdded.ForeColor = System.Drawing.Color.Red;
                        lblAdded.Text = "An error occured!";
                    }
                }
                catch (Exception ex)
                {
                    lblAdded.ForeColor = System.Drawing.Color.Red;
                    lblAdded.Text = "An error occured. Please check if your amount is a valid number format!";
                }


            }
        }
    }
}