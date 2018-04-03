using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// The general Manager adds a Financial manager.
    /// </summary>
    public partial class ManAddFinMan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// data for Financial manager is stored and sent to the database.
        /// A Link is then emailed to the finanicial maager which will lead the
        /// financial manager to set his/her password.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendFMR_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 1 || (int)HttpContext.Current.Session["User_lvl"] == 3)
            {
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                bool IsRegister = false;
                try
                {
                    int AccLvl = Convert.ToInt32(HttpContext.Current.Session["User_lvl"].ToString());
                    string email = txtEmailAddress.Text;
                    ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                    int OrgNumber = serv.getNPOWithManager(user.userValue.UserID);
                    ServiceReference1.Organisation o = serv.getOrg(OrgNumber);

                    if (txtEmailAddress.Text != null && txtEmailAddress.Text != "")
                    {
                        IsRegister = serv.registerIndividual(email, null, AccLvl++, OrgNumber);
                    }
                    int userID = serv.getUserID(email);
                    if (IsRegister == true)
                    {
                        EmailSender passEmal = new EmailSender();
                        passEmal.setReceiverEmail(txtEmailAddress.Text);
                        if (passEmal.verfiyEmail())
                        {
                            passEmal.setSubject("Set Password");
                            passEmal.setDetails("Set Password to the following link: " + "http://localhost:29451/frames/FinManDetails.aspx?User_ID=" + userID.ToString() + ". You were added as a finantion manager for " + o.OrganisationName + ".");
                            if (passEmal.sendEmail())
                            {
                                lblRegFinMan.Text = "Financial Manager Added. Further Instructions forwarded to Financial Manager.";
                            }

                        }
                    }
                    else
                    {
                        lblRegFinMan.Text = "User Already Exists.";
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