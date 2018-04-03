using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// This class adds a system adminstrator to the system
    /// </summary>
    public partial class AddSystemAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This method is called and executed when the btnSendFMR is clicked.
        /// It verifies that the email is not in the system.  If not in the system, the email address is added and the email is sent to the new system adminstrator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendFMR_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 7)
            {
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                bool IsRegister = false;
                try
                {
                    int AccLvl = Convert.ToInt32(HttpContext.Current.Session["User_lvl"].ToString());
                    string email = txtEmailAddress.Text;
                    ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                    int OrgNumber = serv.getNPOWithManager(user.userValue.UserID);

                    if (txtEmailAddress.Text != null && txtEmailAddress.Text != "")
                    {
                        IsRegister = serv.registerIndividual(email, null, AccLvl, OrgNumber);
                    }
                    int userID = serv.getUserID(email);
                    if (IsRegister == true)
                    {
                        EmailSender passEmal = new EmailSender();
                        passEmal.setReceiverEmail(txtEmailAddress.Text);
                        if (passEmal.verfiyEmail())
                        {
                            passEmal.setSubject("Reset Password");
                            passEmal.setDetails("Set Password to the following link: " + "http://localhost:29451/frames/FinManDetails.aspx?User_ID=" + userID.ToString() + "");
                            if (passEmal.sendEmail())
                            {
                                lblRegSysAdm.Text = "System administrator Added. Further Instructions forwarded to the new system administrator.";
                            }

                        }
                    }
                    else
                    {
                        lblRegSysAdm.Text = "User Already Exists.";
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}