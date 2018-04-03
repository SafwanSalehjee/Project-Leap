using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// Confirming the Donation
    /// </summary>
    public partial class ConfirmDonation : System.Web.UI.Page
    {
        /// <summary>
        /// user and service and donation are the gobal variables used in this class
        /// </summary>
        ServiceReference1.DonationRequester donation;
        ServiceReference1.Service1Client service;
        ServiceReference1.UserDetail user;

        /// <summary>
        /// when page  is loaded: the labels and textboxs are set approtpriatly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 3 || (int)HttpContext.Current.Session["User_lvl"] == 5)
            {
                lblError.Visible = false;

                try
                {
                    donation = new ServiceReference1.DonationRequester();
                    service = new ServiceReference1.Service1Client();
                    user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                    if (HttpContext.Current.Session["fundID"] == null)
                    {
                        donation = service.getDonation(int.Parse(Request.QueryString["donationID"].ToString()));

                        lblAmount.Text = "R " + donation.Donate.Amount;
                        lblNPO.Text = donation.NpoName;
                    }
                    else
                    {
                        lblNPO.Text = HttpContext.Current.Session["NPOName"].ToString();
                        lblAmount.Text = "R " + HttpContext.Current.Session["Amount"];
                    }
                    lblCardHolder.Text = user.FirstNameValue;
                    lblEmail.Text = user.EmailValue;

                    if (Request.QueryString["paypal"].ToString().Equals("Yes"))
                    {
                        cardNumber.Visible = false;
                        cardHolder.Visible = false;
                    }
                    else
                    {
                        cardNumber.Visible = true;
                        cardHolder.Visible = true;
                        lblCardNum.Text = "**** **** **** " + Request.QueryString["cnum"];
                    }
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                }
            }

        }
        /// <summary>
        /// Appropriate methods are called from the server to do the donation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 3 || (int)HttpContext.Current.Session["User_lvl"] == 5)
            {
                ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                donation.Donate = null;
                bool success;
                if (HttpContext.Current.Session["fundID"] == null)
                {
                    donation.Donate = null;
                    success = service.addDonation(user.userValue.UserID, donation);
                }
                else
                {
                    success = service.DonateFC(Convert.ToInt32(HttpContext.Current.Session["fundID"]), user.userValue.UserID, Convert.ToDouble(HttpContext.Current.Session["Amount"]));
                }

                if (success)
                {
                    lblError.ForeColor = System.Drawing.Color.Black;
                    lblError.Text = "Donation successful";
                    lblError.Visible = true;
                    btnConfirm.Visible = false;
                }
                else
                {
                    lblError.Text = "Donation failed";
                    lblError.Visible = true;
                }
            }
        }
    }
}