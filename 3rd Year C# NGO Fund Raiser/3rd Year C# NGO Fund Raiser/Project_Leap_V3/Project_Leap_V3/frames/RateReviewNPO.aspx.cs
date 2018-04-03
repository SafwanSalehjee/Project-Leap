using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    public partial class RateReviewNPO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 3 || (int)HttpContext.Current.Session["User_lvl"] == 5)
            {
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                int userId = user.userValue.UserID;
                int orgID = Convert.ToInt32(Request.QueryString["orgId"]);
                int rate = Convert.ToInt32(ddlRating.SelectedItem.ToString());
                String review = txtReview.Text.ToString();
                bool feedback = serv.SetFeedback(rate, review, userId, orgID);

                if (feedback == true)
                {
                    lblSuccess.Text = "Congratulations! You have successfully rated and reviewed the NPO!";
                }
                else
                {
                    lblSuccess.ForeColor = System.Drawing.Color.Red;
                    lblSuccess.Text = "Sorry! You were not able to rate and review the NPO!";
                }
            }
        }
    }
}