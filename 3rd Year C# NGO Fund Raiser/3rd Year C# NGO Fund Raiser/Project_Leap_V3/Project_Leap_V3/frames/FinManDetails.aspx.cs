using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// Financial manager sets his password as he/she clicks on link sent to his/her email
    /// </summary>
    public partial class FinManDetails : System.Web.UI.Page
    {
        /// <summary>
        /// Password are stored in the Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmitPass_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
            bool IsUpdate = false;

            IsUpdate = serv.UpdatePassword(Security.Encrypt(txtPass.Text), Convert.ToInt32(Request.QueryString["User_ID"]));

            if (IsUpdate == true)
            {
                lblIsPassUpdate.Text = "Password Updated! ";

                //Response.Redirect("LoginPage.aspx");
            }
            else
            {
                lblIsPassUpdate.Text = "Password reset Failed. Please try again.";
            }



        }
    }
}