using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Project_Leap_V3
{
    /// <summary>
    /// The page displays a specific user's information
    /// </summary>
    public partial class UserPage : System.Web.UI.Page
    {
        /// <summary>
        /// This method is called and executed when the page is loaded.
        /// A specific user's information is displayed on this page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] > 0 && (int)HttpContext.Current.Session["User_lvl"] < 8)
            {
                btnRemoveOrg.Visible = false;
                btnRemoveUser.Visible = false;

                try
                {
                    userDiv.Visible = false;
                    OrgDiv.Visible = false;
                    VolunteerFrame.Visible = false;
                    RateReviewNPOFrame.Visible = false;
                    AvgRatingFrame.Visible = false;

                    if (Request.QueryString["orgId"] != null)
                    {
                        OrgDiv.Visible = true;
                        int tmpID = int.Parse(Request.QueryString["orgId"].ToString());
                        ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                        ServiceReference1.Organisation currentOrg = serv.getOrg(tmpID);
                        orgDetailsDiv.InnerHtml = "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'><tr><td><h1>" + currentOrg.OrganisationName + "</h1></td><td></td><td></td><td></td></tr><tr><td><h1>Address:</h1></td><td></td><td></td><td></td></tr><tr><td></td><td>" + currentOrg.Street + "</td><td></td><td></td></tr><tr><td></td><td>" + currentOrg.Suburb + "</td><td></td><td></td></tr><tr><td></td><td>" + currentOrg.Province + "</td><td></td><td></td></tr><tr><td><h1>Contact number:</h1></td><td>" + currentOrg.ContactNumber + "</td><td></td><td></td></tr><tr><td><h1>Industry:</h1></td><td>" + currentOrg.Industry + "</td><td></td><td></td></tr><table>";
                        ServiceReference1.UserDetail u = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];

                        if ((int)HttpContext.Current.Session["User_lvl"] == 7)
                        {
                            btnRemoveOrg.Visible = true;
                        }

                        if (u.AccessLvl == 5)
                        {
                            VolunteerFrame.Visible = true;
                            VolunteerFrame.Src = "frames/VolunteerPage.aspx?Org_ID=" + tmpID;
                        }

                        if (u.AccessLvl == 5 || u.AccessLvl == 3)
                        {
                            RateReviewNPOFrame.Visible = true;
                            RateReviewNPOFrame.Src = "frames/RateReviewNPO.aspx?orgId=" + tmpID;
                        }
                        if (currentOrg.OrganisationType == 1)
                        {
                            if (u.AccessLvl == 1 || u.AccessLvl == 2 || u.AccessLvl == 3 || u.AccessLvl == 4 || u.AccessLvl == 5 || u.AccessLvl == 6 || u.AccessLvl == 7)
                            {
                                AvgRatingFrame.Visible = true;
                                AvgRatingFrame.Src = "frames/AverageRating.aspx?orgId=" + tmpID;
                            }
                        }

                        try
                        {
                            ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                            ServiceReference1.FileClass file = serv.getFile(tmpID, true);
                            MemoryStream ms = new MemoryStream(file.FileBytes, 0, file.FileBytes.Length);
                            orgPic.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(file.FileBytes);
                        }
                        catch (Exception ex)
                        {
                            imgUser.ImageUrl = "~/images/ina.jpg";
                        }
                    }

                    if (Request.QueryString["userId"] != null)
                    {
                        userDiv.Visible = true;
                        int tmpID = int.Parse(Request.QueryString["userId"].ToString());
                        ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                        ServiceReference1.User currentUser = serv.getUser(tmpID);
                        IndDetailsDiv.InnerHtml = "<table style='width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;'><tr><td><h1>" + currentUser.FirstNameValue + " " + currentUser.LastNameValue + "</h1></td><td></td><td></td><td></td></tr><tr><td><h2>Email:</h2></td><td>" + currentUser.EmailValue + "</td><td></td><td></td></tr></table>";

                        if ((int)HttpContext.Current.Session["User_lvl"] == 7)
                        {
                            btnRemoveUser.Visible = true;
                        }

                        try
                        {
                            ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                            ServiceReference1.FileClass file = serv.getUserImage(user.userValue.UserID);
                            MemoryStream ms = new MemoryStream(file.FileBytes, 0, file.FileBytes.Length);
                            imgUser.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(file.FileBytes);
                        }
                        catch (Exception ex)
                        {
                            imgUser.ImageUrl = "~/images/avatar1.png";
                        }
                    }

                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 7)
            {
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                bool isDeleted = serv.deleteUser(int.Parse(Request.QueryString["userId"].ToString()));
                if (isDeleted)
                {
                    Response.Redirect("DashboardPage.aspx");
                }
                else
                {
                    IndDetailsDiv.InnerHtml += "<p style='color:red'>Remove unsuccessful!</p>";
                }
            }
        }

        protected void btnRemoveOrg_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 7)
            {
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                bool isDeleted = serv.deleteOrg(int.Parse(Request.QueryString["orgId"].ToString()));
                if (isDeleted)
                {
                    Response.Redirect("DashboardPage.aspx");
                }
                else
                {
                    OrgDiv.InnerHtml += "<p style='color:red'>Remove unsuccessful!</p>";
                }
            }
        }
    }
}