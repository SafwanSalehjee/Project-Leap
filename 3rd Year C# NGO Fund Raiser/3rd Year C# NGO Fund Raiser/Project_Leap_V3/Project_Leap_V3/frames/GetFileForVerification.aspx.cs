using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Project_Leap_V3.frames
{
    public partial class GetFileForVerification : System.Web.UI.Page
    {
        ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 6)
            {
                try
                {
                    lblNoFile.Visible = false;
                    imgFile.Visible = true;

                    ServiceReference1.Organisation org = serv.getOrg(int.Parse(Request.QueryString["orgId"].ToString()));
                    lblName.Text = org.OrganisationName;
                    lblNum.Text = org.OrganisationNumber.ToString();
                    lblCN.Text = org.ContactNumber;

                    ServiceReference1.FileClass file = serv.getFile(int.Parse(Request.QueryString["orgId"].ToString()), false);
                    MemoryStream ms = new MemoryStream(file.FileBytes, 0, file.FileBytes.Length);
                    imgFile.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(file.FileBytes);
                }
                catch (Exception ex)
                {
                    imgFile.Visible = false;
                    lblNoFile.Visible = true;
                }
            }
        }

        protected void btnDecVer_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 6)
            {
                try
                {
                    int tmpID = int.Parse(Request.QueryString["orgId"].ToString());
                    bool ver = serv.verifyOrg(tmpID, false);

                    if (ver)
                    {
                        lblVerified.Text = "Verification set!";
                    }
                    else
                    {
                        lblVerified.Text = "Verification failed!";
                    }
                }
                catch (Exception ex)
                {
                    lblVerified.Text = "Verification failed";
                }
            }
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            if ((int)HttpContext.Current.Session["User_lvl"] == 6)
            {
                try
                {
                    int tmpID = int.Parse(Request.QueryString["orgId"].ToString());
                    bool ver = serv.verifyOrg(tmpID, true);

                    if (ver)
                    {
                        lblVerified.Text = "Verification set!";
                    }
                    else
                    {
                        lblVerified.Text = "Verification failed!";
                    }
                }
                catch (Exception ex)
                {
                    lblVerified.Text = "Verification failed";
                }
            }
        }
    }
}