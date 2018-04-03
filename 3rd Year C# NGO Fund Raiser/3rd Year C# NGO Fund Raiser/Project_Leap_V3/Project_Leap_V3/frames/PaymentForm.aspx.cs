using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{

    /// <summary>
    /// The donor fills in this form when donating money to an NPO
    /// </summary>
    public partial class PaymentForm : System.Web.UI.Page
    {
        /// <summary>
        /// ServiceReference1.DonationRequester variable declaration
        /// </summary>
        ServiceReference1.DonationRequester donation;

        bool fund = false;
        /// <summary>
        /// This method is called when the page is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 3 || (int)HttpContext.Current.Session["User_lvl"] == 5)
            {
                if (!Page.IsPostBack)
                {
                    paypalPassword.Visible = false;
                    paypalPasswordTxt.Visible = false;
                    cardNum.Visible = true;
                    cardNumTxt.Visible = true;
                    cardHolder.Visible = true;
                    cardHolderTxt.Visible = true;
                    ccvNum.Visible = true;
                    ccvNumTxt.Visible = true;
                    expTitle.Visible = true;
                    expMY.Visible = true;
                    expMYddl.Visible = true;

                    lblError.Visible = false;
                }
                else
                {
                    lblError.Visible = false;
                    if (rbPayment.SelectedIndex == 3)
                    {
                        paypalPassword.Visible = true;
                        paypalPasswordTxt.Visible = true;
                        cardNum.Visible = false;
                        cardNumTxt.Visible = false;
                        cardHolder.Visible = false;
                        cardHolderTxt.Visible = false;
                        ccvNum.Visible = false;
                        ccvNumTxt.Visible = false;
                        expTitle.Visible = false;
                        expMY.Visible = false;
                        expMYddl.Visible = false;
                    }
                    else
                    {
                        paypalPassword.Visible = false;
                        paypalPasswordTxt.Visible = false;
                        cardNum.Visible = true;
                        cardNumTxt.Visible = true;
                        cardHolder.Visible = true;
                        cardHolderTxt.Visible = true;
                        ccvNum.Visible = true;
                        ccvNumTxt.Visible = true;
                        expTitle.Visible = true;
                        expMY.Visible = true;
                        expMYddl.Visible = true;
                    }
                }

                try
                {
                    lblError.Visible = false;
                    ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
                    donation = new ServiceReference1.DonationRequester();

                    if (HttpContext.Current.Session["fundID"] == null)
                    {
                        donation = service.getDonation(int.Parse(Request.QueryString["donationID"].ToString()));

                        lblNPO.Text = donation.NpoName;
                        lblAmount.Text = "R " + donation.Donate.Amount;
                    }
                    else
                    {
                        lblNPO.Text = HttpContext.Current.Session["NPOName"].ToString();
                        lblAmount.Text = "R " + HttpContext.Current.Session["Amount"];
                        fund = true;
                    }
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = "An error occured!";
                }
            }
        }

        /// <summary>
        /// This method is called and executed when the btnDonate button is clicked.
        /// When the donor donates money, they fill in the payment form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDonate_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 3 || (int)HttpContext.Current.Session["User_lvl"] == 5)
            {
                lblError.Text = "Please make sure your details are correct and all filled in!";

                if (rbPayment.SelectedIndex >= 0)
                {
                    if (rbPayment.SelectedIndex == 3)
                    {
                        if (!txtEmail.Text.Equals("") && !txtPaypalPassword.Text.Equals(""))
                        {
                            if (!fund)
                                Response.Redirect("ConfirmDonation.aspx?paypal=Yes&donationID=" + donation.Donate.RequestIDNumber);
                            else
                                Response.Redirect("ConfirmDonation.aspx?paypal=Yes");
                        }
                        else
                        {
                            lblError.Visible = true;
                        }
                    }
                    else
                    {
                        if (!txtEmail.Text.Equals("") && !txtCardNum.Text.Equals("") && !txtHolder.Text.Equals("") && !txtCCV.Text.Equals(""))
                        {
                            try
                            {
                                long cardNum = long.Parse(txtCardNum.Text);
                                int cvvNum = int.Parse(txtCCV.Text);
                                string cnum = txtCardNum.Text;
                                char[] cnums = cnum.ToCharArray();
                                cnum = "";
                                for (int a = cnums.Length - 1; a > cnums.Length - 5; a--)
                                {
                                    cnum = cnums[a] + cnum;
                                }
                                if (!fund)
                                    Response.Redirect("ConfirmDonation.aspx?paypal=No&donationID=" + donation.Donate.RequestIDNumber + "&cnum=" + cnum);
                                else
                                    Response.Redirect("ConfirmDonation.aspx?paypal=No&cnum=" + cnum);
                            }
                            catch (Exception ex)
                            {
                                lblError.Visible = true;
                                lblError.Text = "Make sure card number and CVV number contain only numbers!";
                            }
                        }
                        else
                        {
                            lblError.Visible = true;
                        }
                    }
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Please select a payment option!";
                }
            }
        }
    }
}