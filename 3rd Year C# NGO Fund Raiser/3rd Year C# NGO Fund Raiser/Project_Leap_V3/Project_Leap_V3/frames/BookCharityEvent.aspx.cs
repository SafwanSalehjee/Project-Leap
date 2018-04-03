using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Leap_V3.frames
{
    /// <summary>
    /// Charity Event is booked.
    /// </summary>
    public partial class BookCharityEvent : System.Web.UI.Page
    {
        /// <summary>
        /// On Page Load; Get today's date and set the necessary  lables and textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime today = DateTime.Today;
                calEventDate.TodaysDate = today;
                calEventDate.SelectedDate = calEventDate.TodaysDate;
                lblEventDate.Text = calEventDate.SelectedDate.ToShortDateString();
            }
            txtOther.Enabled = false;
        }
        /// <summary>
        /// Selected an appropraite date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void calEventDate_SelectionChanged(object sender, EventArgs e)
        {
            lblEventDate.Text = calEventDate.SelectedDate.ToShortDateString();
            calEventDate.Visible = false;
        }

        /// <summary>
        /// CalEventDate is meant to be visiable 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCal_Click(object sender, ImageClickEventArgs e)
        {
            calEventDate.Visible = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBook_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 1)
            {
                lblIsValid.Text = "";

                ServiceReference1.Service1Client ser = new ServiceReference1.Service1Client();

                ServiceReference1.Eve eve = new ServiceReference1.Eve();
                string[] s;
                DateTime DateOfBook;
                try
                {
                    s = lblEventDate.Text.Split('-');
                    DateOfBook = new DateTime(Convert.ToInt32(s[0]), Convert.ToInt32(s[1]), Convert.ToInt32(s[2]), Convert.ToInt32(ddlSTHr.SelectedItem.Text), Convert.ToInt32(ddlSTMin.SelectedItem.Text), 0);
                }
                catch (Exception ex)
                {
                    s = lblEventDate.Text.Split('/');
                    DateOfBook = new DateTime(Convert.ToInt32(s[0]), Convert.ToInt32(s[1]), Convert.ToInt32(s[2]), Convert.ToInt32(ddlSTHr.SelectedItem.Text), Convert.ToInt32(ddlSTMin.SelectedItem.Text), 0);
                }

                eve.DateValue = DateOfBook;
                eve.Host = txtHost.Text;
                eve.Name = txtEName.Text;
                eve.Location = txtVenue.Text;
                eve.Description = txtDescription.Text;
                eve.Time = ddlSTHr.SelectedValue + ":" + ddlSTMin.SelectedValue + " " + ddlSTAP.SelectedValue;
                ServiceReference1.UserDetail u = (ServiceReference1.UserDetail)HttpContext.Current.Session["User"];
                int id = ser.getNPOWithManager(u.userValue.UserID);
                eve.OrgID = id;
                bool added = ser.addEvent(eve, id);
                if (ddlEventType.SelectedItem.Text != "Other")
                    eve.Description = ddlEventType.SelectedItem.Text;
                else
                    eve.Description = txtOther.Text;

                if (added)
                {
                    lblIsValid.ForeColor = System.Drawing.Color.Black;
                    lblIsValid.Text = "Event added successfully!";
                }
                else
                {
                    lblIsValid.ForeColor = System.Drawing.Color.Red;
                    lblIsValid.Text = "An error occured. Please try again later!";
                }
            }
        }

        protected void ddlEventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEventType.SelectedItem.Text.Equals("Other"))
            {
                txtOther.Enabled = true;
            }
        }

    }
}