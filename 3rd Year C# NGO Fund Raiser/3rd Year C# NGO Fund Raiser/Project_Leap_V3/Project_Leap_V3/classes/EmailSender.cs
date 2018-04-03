using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace Project_Leap_V3
{
    /// <summary>
    /// The class handles the sending of the emails
    /// </summary>
    public class EmailSender
    {
        /// <summary>
        /// Private Variables declarations
        /// </summary>
        private string SenderEmail;
        private string ReceiverEmail;
        private string subject;
        private string details;
        private bool isEMail;
        private const string PASS = "hashdash";
        private const string EMAIL = "projectleap15@gmail.com";

        /// <summary>
        /// The no arg Constructor
        /// </summary>
        public EmailSender() {}
        /// <summary>
        /// The parameterized constructor which assigns the private variables
        /// </summary>
        /// <param name="SenderEmail"> the email sender</param>
        /// <param name="ReceiverEmail">the receiver of the email</param>
        /// <param name="subject">The Subjet of the email</param>
        /// <param name="details">The message of the email.</param>
        public EmailSender(String SenderEmail, string ReceiverEmail, String subject, String details)
        {
            setSenderEmail(SenderEmail);
            setReceiverEmail(ReceiverEmail);
            setSubject(subject);
            setDetails(details);
        }

        /// <summary>
        /// Sets the Sender email address
        /// </summary>
        /// <param name="semail">Email Address of the sender</param>
        public void setSenderEmail(string semail)
        {
            SenderEmail = semail;
        }

        /// <summary>
        /// The Receiver of the email is set
        /// </summary>
        /// <param name="remail"> the email address receiver</param>
        public void setReceiverEmail(string remail)
        {
            ReceiverEmail = remail;
        }

        /// <summary>
        /// The message of the email is set
        /// </summary>
        /// <param name="details">The message</param>
        public void setDetails(string details)
        {
            this.details = details;
        }

        /// <summary>
        /// The Subject is set
        /// </summary>
        /// <param name="subject">The Subject of the email</param>
        public void setSubject(string subject)
        {
            this.subject = subject;
        }

        /// <summary>
        /// verifies if the email is in database or not
        /// </summary>
        /// <returns>a Bool value</returns>
        public bool verfiyEmail()
        {
            ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
            isEMail = serv.verifyEmail(ReceiverEmail);
            return isEMail;
        }
        /// <summary>
        /// Sends email
        /// </summary>
        /// <returns>bool value indicating the success of sending the email </returns>
        public bool sendEmail()
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            mail.From = new MailAddress(EMAIL);
            mail.To.Add(ReceiverEmail);
            mail.Subject = subject;
            mail.Body = details;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(EMAIL, PASS);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return true;
        }
    }
}