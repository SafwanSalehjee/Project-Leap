using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// This class adds a donation request
    /// </summary>
    public partial class AddDonationRequest : System.Web.UI.Page
    {
        /// <summary>
        /// This code is executed when the page is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 1)
            {
                if (!Page.IsPostBack)
                {
                    ddlType.Items.Add("Money");
                    //ddlType.Items.Add("Equipment");
                }
                else
                {
                    //if (ddlType.SelectedIndex == 1)
                    //{
                    //    lblAmount.Text = "Equipment estimate value:";
                    //}
                    //else 
                    //{
                    lblAmount.Text = "Donation amount:";
                    //}
                }
            }
        }

        /// <summary>
        /// This method is called and executed when btnAddDonation is clicked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddDonation_Click(object sender, EventArgs e)
        {
            try
            {
                if ((int)HttpContext.Current.Session["User_lvl"] == 1)
                {
                    ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
                    ServiceReference1.DonationRequester newDonation = new ServiceReference1.DonationRequester();
                    ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

                    newDonation.OrgID = service.getNPOWithManager(user.userValue.UserID);
                    newDonation.Discription = txtDescription.Text;
                    double amount = double.Parse(txtAmount.Text);
                    newDonation.Amount = amount;
                    int typeInt = ddlType.SelectedIndex + 1;
                    newDonation.Type = typeInt;
                    newDonation.Date = Convert.ToDateTime(DateTime.Today);

                    bool added = service.addDonationRequest(newDonation);

                    if (added)
                    {
                        lblError.Text = "Donation request added successfully!";
                    }
                    else
                    {
                        lblError.Text = "An error occured please try again!";
                    }
                }
                else
                {
                    lblError.Text = "You have insufficient permission to do this!";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "An error occured when adding the donation. Please check the amount textbox and try again. Use a ',' for decimals!";
            }
        }
    }
}