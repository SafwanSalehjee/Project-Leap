using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// The frame handle the retrieval of the verification status of the organisation
    /// </summary>
    public partial class GetVerificationStatus : System.Web.UI.Page
    {
        /// <summary>
        /// This method is called and executed when the page is loaded.
        /// The Page_Load handle the retrieval of the verification status of the organisation and displays it 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] > 0 && (int)HttpContext.Current.Session["User_lvl"] < 5)
            {
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();

                ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

                bool verified = serv.getVerificationStatus(serv.getNPOWithManager(user.userValue.UserID));

                lblReason.Visible = false;

                if (verified)
                {
                    lblVerified.ForeColor = System.Drawing.Color.Green;
                    lblVerified.Text = "Verified";
                }
                else
                {
                    lblVerified.ForeColor = System.Drawing.Color.Red;
                    lblVerified.Text = "Not Verified";
                    lblReason.Visible = true;
                    lblReason.ForeColor = System.Drawing.Color.Red;
                    lblReason.Text = "Please make sure you have the correct file attached as proof of your organisation!";
                }
            }
        }
    }
}