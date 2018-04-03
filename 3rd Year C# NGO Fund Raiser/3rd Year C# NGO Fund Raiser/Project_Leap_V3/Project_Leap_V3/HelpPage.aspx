<%@ Page Title="" Language="C#" MasterPageFile="~/Project_Leap_Master.Master" AutoEventWireup="true" CodeBehind="HelpPage.aspx.cs" Inherits="Project_Leap_V3.HelpPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    FAQ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center" class="container">
        <div class="one-third column">
            <blockquote class="testimonial">
                Why are my login details not working?
            </blockquote>
            <p>
                If you have trouble logging in then please select the "Forgot password" link.
            From here enter your details and wait for an email with further steps.
            </p>
        </div>
        <div class="one-third column">
            <blockquote class="testimonial">
                What is required for registration?
            </blockquote>
            <p>
                The requirements for registration is different for each type of entity you are registering for.
            Please have a look at the registration form to view what is required.
            </p>
        </div>
        <div class="one-third column">
            <blockquote class="testimonial">
                What file do NPOs require?
            </blockquote>
            <p>
                The file that NPOs need is the proof of NPO registration in South Africa. 
        This document should have been supplied upon registration as an NPO.
            </p>
        </div>
    </div>
    <div align="center" class="container">
        <div class="one-third column">
            <blockquote class="testimonial">
                What file do businesses require?
            </blockquote>
            <p>
                Businesses must upload a tax return statement as proof of the business. 
        This file is required for business verification.
            </p>
        </div>
        <div class="one-third column">
            <blockquote class="testimonial">
                Why can't I donate or receive donations?
            </blockquote>
            <p>
                If you are a business or an NPO, the organisation must be verified by the system manager. 
        If there is a problem with your verification, there will be a message displaying it on your dashboard.
            </p>
        </div>
        <div class="one-third column">
            <blockquote class="testimonial">
                How is verification done?
            </blockquote>
            <p>
                Verification is done by the system manager. The manager will view all newly registered businesses and NPOs
        . The manager will use the files provided during registration to do so.
            </p>
        </div>
    </div>

    <footer style="position: absolute; bottom: 0; width: 100%;">
        <div id="footer-base">
            <div class="container">
                <div class="eight columns">
                    2015 HashDash IT
                </div>
            </div>
        </div>
    </footer>
</asp:Content>
