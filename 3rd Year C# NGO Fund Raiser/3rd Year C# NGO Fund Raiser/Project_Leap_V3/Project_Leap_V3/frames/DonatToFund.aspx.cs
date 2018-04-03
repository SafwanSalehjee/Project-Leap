using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    public partial class DonatToFund : System.Web.UI.Page
    {
        ServiceReference1.cFundraisingCampaign fund;
        string npoName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 3 || (int)HttpContext.Current.Session["User_lvl"] == 5)
            {
                int fID = Convert.ToInt32(Request.QueryString["FID"]);
                ServiceReference1.Service1Client sev = new ServiceReference1.Service1Client();
                fund = sev.getFundRaisingCampaign(fID);
                lblFund.Text = fund.VTitle;
                npoName = sev.getOrg(fund.OrgID1).OrganisationName;
                lblDiscrip.Text = fund.VDescription;
            }
        }

        protected void btnDonate_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 3 || (int)HttpContext.Current.Session["User_lvl"] == 5)
            {
                HttpContext.Current.Session["fundID"] = fund.IDF;
                HttpContext.Current.Session["NPOName"] = npoName;
                HttpContext.Current.Session["Amount"] = txtDonate.Text;
                Response.Redirect("PaymentForm.aspx");
            }
        }
    }
}