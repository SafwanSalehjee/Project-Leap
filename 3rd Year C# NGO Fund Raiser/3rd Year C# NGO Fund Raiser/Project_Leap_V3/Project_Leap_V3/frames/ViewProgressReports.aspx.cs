using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// This class sends an email of the NPOs progress report to all donors
    /// </summary>
    public partial class ViewProgressReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This method sends the email to the donors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 1)
            {
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                int OrgNumber = 1;
                ServiceReference1.Organisation org = serv.getOrg(OrgNumber);
                String[] donorEmails = serv.getDonorEmails(OrgNumber);


                foreach (String email in donorEmails)
                {
                    EmailSender passEmail = new EmailSender();

                    passEmail.setReceiverEmail(email);
                    passEmail.setSubject("Progress Report");
                    passEmail.setDetails(org.OrganisationName + "\r\n" + txtTitle.Text + "\r\n" + txtBody.Text);

                    if (passEmail.sendEmail())
                    {
                        lblReply.Text = "Emails have successfully been sent to all donors.";
                    }

                }
            }
        }
    }
}