using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Sockets;

namespace Project_Leap_V3
{
    /// <summary>
    /// this is used when password is forgotton by the user.
    /// </summary>
    public partial class ForgotPassPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Sends a link to the user's email for them to reset password.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEmalSubmit_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
            int userID;
            if (txtEmail.Text != null && txtEmail.Text != "")
            {
                EmailSender passEmal = new EmailSender();
                passEmal.setReceiverEmail(txtEmail.Text);
                userID = serv.getUserID(txtEmail.Text);
                if (passEmal.verfiyEmail())
                {

                    passEmal.setSubject("Retrieve Password");
                    passEmal.setDetails("Forgot Password follow link:" + "http://localhost:29451/frames/FinManDetails.aspx?User_ID=" + userID.ToString());
                    if (passEmal.sendEmail())
                    {
                        lblEmail.Text = "Sent";
                    }

                }

            }
        }
    }
}