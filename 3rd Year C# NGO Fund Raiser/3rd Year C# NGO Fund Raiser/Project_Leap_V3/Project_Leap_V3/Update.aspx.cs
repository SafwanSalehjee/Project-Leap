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
    /// This class is called when the Update page is rendered
    /// </summary>
    public partial class Update : System.Web.UI.Page
    {
        /// <summary>
        /// Private variable declaration
        /// </summary>
        private ServiceReference1.Service1Client serv;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] > 0 && (int)HttpContext.Current.Session["User_lvl"] < 8)
            {
                try
                {
                    ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                    ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                    ServiceReference1.FileClass file = serv.getUserImage(user.userValue.UserID);
                    MemoryStream ms = new MemoryStream(file.FileBytes, 0, file.FileBytes.Length);
                    imgUserPic.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(file.FileBytes);
                }
                catch (Exception ex)
                {
                    imgUserPic.ImageUrl = "~/images/ina.jpg";
                }
            }
        }

        /// <summary>
        /// This method is called and executed when the btnUpdate button is clicked.
        /// The user's information is updated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdata_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] > 0 && (int)HttpContext.Current.Session["User_lvl"] < 8)
            {
                serv = new ServiceReference1.Service1Client();
                ServiceReference1.UserDetail user = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                user.userValue.FirstName = txtFirstName.Text;
                user.userValue.LastName = txtLastName.Text;

                if (ddlTitle.SelectedIndex > 0)
                    user.userValue.Title = ddlTitle.SelectedItem.Text;

                if (ddlDay1.SelectedIndex > 0 && ddlDay2.SelectedIndex > 0 && ddlMonth.SelectedIndex > 0 && ddlYear1.SelectedIndex > 0 && ddlYear2.SelectedIndex > 0 && ddlYear3.SelectedIndex > 0)
                {
                    string dateStr = ddlYear1.SelectedValue + ddlYear2.SelectedValue + ddlYear3.SelectedValue + "-" + ddlMonth.SelectedValue + "-" + ddlDay1.SelectedValue + ddlDay2.SelectedValue;
                    user.userValue.DateOfBirth = Convert.ToDateTime(dateStr);
                }

                if (ddlProvince.SelectedIndex > 0)
                    user.userValue.Province = ddlProvince.SelectedItem.Text;

                if (rbGender.SelectedIndex == 1)
                    user.userValue.Gender = 'F';
                if (rbGender.SelectedIndex == 0)
                    user.userValue.Gender = 'M';
                if (rbGender.SelectedIndex == 2)
                    user.userValue.Gender = 'O';

                if (fileUpProfilePic.HasFile)
                {
                    try
                    {
                        string filename = Path.GetFileName(fileUpProfilePic.FileName);
                        ServiceReference1.FileClass file = new ServiceReference1.FileClass();
                        file.FilePath = filename;
                        file.FileBytes = fileUpProfilePic.FileBytes;
                        serv.addUserImage(file, user.userValue.UserID);
                    }
                    catch (Exception ex)
                    {
                    }
                }

                if (serv.UpdateProfile(user))
                {
                    HttpContext.Current.Session["User_FistName"] = user.userValue.FirstName;
                    lblIsValid.Text = "Updated";
                }
                else
                {
                    lblIsValid.Text = "Failed";
                }
            }
        }
    }
}