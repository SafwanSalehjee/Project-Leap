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
    /// Registration is handled here.
    /// </summary>
    public partial class RegisterPage : System.Web.UI.Page
    {

        public static bool onPage;
        private NPO npo;
        private Business business;
        private static int orgNumber;
        /*
         Individual
         */

        /// <summary>
        /// Makes sure that appropriate pages are accesable from this page
        /// Also the appropraite components are populated with correct options to the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                onPage = true;
                index.onPage = false;
                login.onPage = false;
                HelpPage.onPage = false;
                DashboardPage.onPage = false;

                ddlBusIndustry.Items.Add("Agriculture");
                ddlBusIndustry.Items.Add("Architecture");
                ddlBusIndustry.Items.Add("Banking or financial services");
                ddlBusIndustry.Items.Add("Education");
                ddlBusIndustry.Items.Add("Engineering");
                ddlBusIndustry.Items.Add("Health care and medical");
                ddlBusIndustry.Items.Add("Information Technology");
                ddlBusIndustry.Items.Add("Legal");
                ddlBusIndustry.Items.Add("Manufacturing");
                ddlBusIndustry.Items.Add("Telecommunications");
                ddlBusIndustry.Items.Add("Travel");
                ddlBusIndustry.Items.Add("Other");

                DDLNPOInd.Items.Add("Animal protection");
                DDLNPOInd.Items.Add("Child care");
                DDLNPOInd.Items.Add("Crime prevention");
                DDLNPOInd.Items.Add("Community");
                DDLNPOInd.Items.Add("Disability care");
                DDLNPOInd.Items.Add("Educational");
                DDLNPOInd.Items.Add("Environmental protection");
                DDLNPOInd.Items.Add("Old age care");
                DDLNPOInd.Items.Add("Other");

                BusDDProvince.Items.Add("Eastern Cape");
                BusDDProvince.Items.Add("Free State");
                BusDDProvince.Items.Add("Gauteng");
                BusDDProvince.Items.Add("KwaZulu-Natal");
                BusDDProvince.Items.Add("Limpopo");
                BusDDProvince.Items.Add("Mpumalanga");
                BusDDProvince.Items.Add("Northern Cape");
                BusDDProvince.Items.Add("North West");
                BusDDProvince.Items.Add("Western Cape");

                ddlNPOProv.Items.Add("Eastern Cape");
                ddlNPOProv.Items.Add("Free State");
                ddlNPOProv.Items.Add("Gauteng");
                ddlNPOProv.Items.Add("KwaZulu-Natal");
                ddlNPOProv.Items.Add("Limpopo");
                ddlNPOProv.Items.Add("Mpumalanga");
                ddlNPOProv.Items.Add("Northern Cape");
                ddlNPOProv.Items.Add("North West");
                ddlNPOProv.Items.Add("Western Cape");

                try
                {
                    if (Request.QueryString["regType"].ToString() == "Bus")
                    {
                        regIndDiv.Visible = false;
                        regNPODiv.Visible = false;
                    }
                    if (Request.QueryString["regType"].ToString() == "NPO")
                    {
                        regIndDiv.Visible = false;
                        regBusDiv.Visible = false;
                    }
                    if (Request.QueryString["regType"].ToString() == "Ind")
                    {
                        regBusDiv.Visible = false;
                        regNPODiv.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                if (DDLNPOInd.SelectedIndex == 8)
                {
                    lblNPOIndOther.Visible = true;
                    txtNPOOtherInd.Visible = true;
                }
                else
                {
                    lblNPOIndOther.Visible = false;
                    txtNPOOtherInd.Visible = false;
                }

                if (ddlBusIndustry.SelectedIndex == 11)
                {
                    lblBusIndustryType.Visible = true;
                    txtBusInd.Visible = true;
                }
                else
                {
                    lblBusIndustryType.Visible = false;
                    txtBusInd.Visible = false;
                }
            }
        }

        /// <summary>
        /// Data for NPO are captured and then sent to the the server to the stored in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegNPO_Click(object sender, EventArgs e)
        {
            lblWrongInput.Visible = false;
            lblReqField2.Visible = false;

            if (fupNPO.HasFile)
            {
                if (!txtNPONum.Text.Equals("") && !txtNPOName.Text.Equals("") && !txtNPOStreet.Text.Equals("") && !txtNPOSub.Text.Equals("") && !txtNPONumber.Text.Equals(""))
                {
                    try
                    {
                        ServiceReference1.Service1Client regNPOServ = new ServiceReference1.Service1Client();
                        bool registrationSuccessful = false;

                        npo = new NPO(int.Parse(txtNPONum.Text), txtNPOName.Text);
                        npo.Street1 = txtNPOStreet.Text;
                        npo.Suburb1 = txtNPOSub.Text;
                        npo.Province1 = ddlNPOProv.SelectedItem.Text;
                        npo.ContactNumber1 = txtNPONumber.Text;
                        npo.Industry1 = DDLNPOInd.SelectedItem.Text;
                        npo.OrganisaionType1 = 1;
                        orgNumber = int.Parse(txtNPONum.Text);

                        registrationSuccessful = regNPOServ.addOrganisation(npo.OrganisationNumber1, npo.OrganisationName1, npo.Street1, npo.Suburb1, npo.Province1, npo.COUNTRY1, npo.ContactNumber1, npo.Industry1, npo.OrganisaionType1);


                        string filename = Path.GetFileName(fupNPO.FileName);
                        ServiceReference1.FileClass file = new ServiceReference1.FileClass();
                        file.FilePath = filename;
                        file.FileBytes = fupNPO.FileBytes;
                        regNPOServ.addOrgFile(file, orgNumber);

                        if (fileUpNPOProfilePic.HasFile)
                        {
                            string filePname = Path.GetFileName(fileUpNPOProfilePic.FileName);
                            ServiceReference1.FileClass fileP = new ServiceReference1.FileClass();
                            fileP.FilePath = filePname;
                            fileP.FileBytes = fileUpNPOProfilePic.FileBytes;
                            regNPOServ.addOrgImage(fileP, orgNumber);
                        }

                        if (registrationSuccessful == true)
                        {
                            regNPODiv.Visible = false;
                            regIndDiv.Visible = true;
                            lblTitleRI.Text = "NPO manager";
                        }
                        else if (registrationSuccessful == false)
                        {
                            lblRegMessage.Text = "Error occured when registering. Please make sure your email has not been registered previously.";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblWrongInput.Visible = true;
                    }
                }
                else
                {
                    lblReqField2.Visible = true;
                }
            }
            else
            {
                lblReqField2.Visible = true;
                lblReqField2.Text = "Please add a file to proof the existance of your NPO!";
            }
        }

        /// <summary>
        /// Data for Businesses are captured and then sent to the the server to the stored in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegBus_Click(object sender, EventArgs e)
        {
            lblWrongText.Visible = false;
            lblReqField.Visible = false;

            if (fupBus.HasFile)
            {
                if (!txtBusENum.Text.Equals("") && !txtBusName.Text.Equals("") && !txtBusStreet.Text.Equals("") && !txtBusSuburb.Text.Equals("") && !TxtBusCNumber.Text.Equals(""))
                {
                    try
                    {
                        ServiceReference1.Service1Client regBusServ = new ServiceReference1.Service1Client();
                        bool registrationSuccessful = false;

                        business = new Business(long.Parse(txtBusENum.Text), txtBusName.Text);
                        business.Street1 = txtBusStreet.Text;
                        business.Suburb1 = txtBusSuburb.Text;
                        business.Province1 = BusDDProvince.SelectedItem.Text;
                        business.ContactNumber1 = TxtBusCNumber.Text;
                        business.Industry1 = ddlBusIndustry.SelectedItem.Text;
                        business.OrganisaionType1 = 2;

                        orgNumber = int.Parse(txtBusENum.Text);

                        registrationSuccessful = regBusServ.addOrganisation(business.OrganisationNumber1, business.OrganisationName1, business.Street1, business.Suburb1, business.Province1, business.COUNTRY1, business.ContactNumber1, business.Industry1, business.OrganisaionType1);

                        string filename = Path.GetFileName(fupBus.FileName);
                        ServiceReference1.FileClass file = new ServiceReference1.FileClass();
                        file.FilePath = filename;
                        file.FileBytes = fupBus.FileBytes;
                        regBusServ.addOrgFile(file, orgNumber);

                        if (fudBusP.HasFile)
                        {
                            string filePname = Path.GetFileName(fudBusP.FileName);
                            ServiceReference1.FileClass fileP = new ServiceReference1.FileClass();
                            fileP.FilePath = filePname;
                            fileP.FileBytes = fudBusP.FileBytes;
                            regBusServ.addOrgImage(fileP, orgNumber);
                        }

                        if (registrationSuccessful == true)
                        {
                            regBusDiv.Visible = false;
                            regIndDiv.Visible = true;
                            lblTitleRI.Text = "Business manager";
                        }
                        else if (registrationSuccessful == false)
                        {
                            lblRegMessage.Text = "Error occured when registering. Please make sure your email has not been registered previously.";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblWrongText.Visible = true;
                    }
                }
                else
                {
                    lblReqField.Visible = true;
                }
            }
            else
            {
                lblReqField.Visible = true;
                lblReqField.Text = "Please add a file to proof the existance of your NPO!";
            }
        }

        /// <summary>
        /// Data for Individual are captured and then sent to the the server to the stored in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegInd_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client regIndServ = new ServiceReference1.Service1Client();
            bool registrationSuccessful = false;
            try
            {
                if (Request.QueryString["regType"].ToString() == "Ind")
                {
                    registrationSuccessful = regIndServ.registerIndividual(txtEmail.Text, Security.Encrypt(txtPass.Text), 5, 0);
                    if (registrationSuccessful == true)
                    {
                        lblRegMessage.Text = "Registration successful";
                    }
                    else if (registrationSuccessful == false)
                    {
                        lblRegMessage.Text = "Error occured when registering. Please make sure your email has not been registered previously.";
                    }
                }
                if (Request.QueryString["regType"].ToString() == "NPO")
                {
                    registrationSuccessful = regIndServ.registerIndividual(txtEmail.Text, Security.Encrypt(txtPass.Text), 1, orgNumber);
                    if (registrationSuccessful == true)
                    {
                        lblRegMessage.Text = "Registration successful";
                    }
                    else if (registrationSuccessful == false)
                    {
                        lblRegMessage.Text = "Error occured when registering. Please make sure your email has not been registered previously.";
                    }
                }
                if (Request.QueryString["regType"].ToString() == "Bus")
                {
                    registrationSuccessful = regIndServ.registerIndividual(txtEmail.Text, Security.Encrypt(txtPass.Text), 3, orgNumber);
                    if (registrationSuccessful == true)
                    {
                        lblRegMessage.Text = "Registration successful";
                    }
                    else if (registrationSuccessful == false)
                    {
                        lblRegMessage.Text = "Error occured when registering. Please make sure your email has not been registered previously.";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}