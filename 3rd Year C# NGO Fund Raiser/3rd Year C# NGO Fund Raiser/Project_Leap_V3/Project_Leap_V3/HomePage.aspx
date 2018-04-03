<%@ Page Title="" Language="C#" MasterPageFile="~/Project_Leap_Master.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Project_Leap_V3.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Home
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <!-- Slider and welcome message
	================================================== -->
        <p class="five columns"></p>
        <blockquote class="testimonial six columns">
            From coding hands to helping hands.
            
            <cite>W Bezuidenhout</cite> 
        </blockquote>
        
        <div class="sixteen columns">
            <div class="flex-container">
                <!-- The frame around the slider -->
                <div class="flexslider">
                    <!-- The slider -->
                    <ul class="slides">
                        <li>
                            <img style="height: 400px;" src="images/Carousel/rhino2.png" alt="rhino" />
                            <div class="flex-caption">

                                <h5><a href="#">Save the rhino</a></h5>
                                <p>These guys are nearly extinct. Please help them.</p>
                            </div>
                        </li>
                        <li>
                            <img style="height: 400px;" src="images/Carousel/tree2.jpg" alt="Cat" />
                            <div class="flex-caption">

                                <h5><a href="#">Not an animal person</a></h5>
                                <p>Don't worry we have many causes you can support.</p>
                            </div>
                        </li>
                        <li>
                            <img style="height: 400px;" src="images/Carousel/dog.jpg" alt="Dog" />
                            <div class="flex-caption">

                                <h5><a href="#">Have a dog</a></h5>
                                <p>This guy can use your help.</p>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <hr />
        <div class="tagline">
            <p>What <strong>Project Leap</strong> can do for you...</p>
        </div>

        <div class="one-third column">
            <h3><i class="icon-heart rounded"></i>For NPOs</h3>
            <p>
                <br />
                Connect with businesses and grow as a non-profit organisation.
                Connect with other non-profit organisations as well as businesses and people.
                Grow your NPO now and start being more effective.
                Keep your donors updated with news feeds and progress reports.
                Enjoy easy to use donation request systems, fundraising campaigns and event management.
                Join now!
            </p>
        </div>
        <div class="one-third column">
            <h3><i class="icon-money rounded"></i>For Businesses</h3>
            <p>
                <br />
                Help the community by supporting non-profit organisations. Connect with NPOs and reap the rewards.
					Give back to the community with our easy to use and dynamic donation system.
					Get exposure for your business when you help via our social network integration.
					Improve your public image and enjoy tax break.
					Join now!
            </p>
        </div>
        <div class="one-third column">
            <h3><i class="icon-user rounded"></i>For Individuals</h3>
            <p>
                <br />
                Want to make a difference in your community?
					Your help will not go unnoticed with our easy to use system.
					Stand out in the crowd and help your local NPO.
					Choose the cause you want to help, donate and even volunteer.
					Sign up today and enjoy a brighter tomorrow.
					Show your friends when you help with our social media integration. Join now!
            </p>
        </div>
        <hr />
        
    
      <div runat="server" id="Top10Bus" >
        <iframe style="width: 100%; height: 500px;" src="frames/reports/mixed/TopDonBus_HomePage.aspx"></iframe>
    </div>
    <div runat="server" id="TopTenIndividuals" >
        <iframe style="width: 100%; height: 500px;" src="frames/reports/individual/Most_Active_Individual_HomePage.aspx"></iframe>
    </div>
  </div>
    <footer>
        <div id="scrolleeD" class="footer-inner container">

            <asp:Table ID="BottomTable" runat="server" Width="100%" HorizontalAlign="Center"  Font-Size="Large">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center" Width="20%">
                    <div class="one-third column">
                        <h3>About Us</h3>
                        <p>
                            Project leap's Main Goal is to increase the
                    Exposure of NPO to businesses and Individuals
                    so they can Continue with the Goodness:)
                        </p>
                    </div>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center" Width="20%">
                       <div class="one-third column">
                            <h3>Contact Us</h3>
                          
                            <p><b>Email:</b> projectleap@gmail.com</p>
                            
                             
                       </div>
                      
                        
                        <asp:Table ID="Table1" runat ="server">
                            <asp:TableRow>
                                <asp:TableCell>
                             <a href="https://www.facebook.com/ProjectLeap01">
                            
                            <asp:Image ID="imgFacebook" runat="server" ImageUrl="images/icons/Facebook_icon.png" Width="60" Height="60" />   .</a>
                            
                                </asp:TableCell>
                                
                                <asp:TableCell>
                                <a href="https://twitter.com/ProjectLeap15">
                            
                            <asp:Image ID="imgTwitter" runat="server" ImageUrl="images/icons/twitter.png" Width="60" Height="60" /></a>
                                    </asp:TableCell>
                                </asp:TableRow>
                            
                        </asp:Table>
                    </asp:TableCell>

                    <asp:TableCell HorizontalAlign="Center" Width="20%">
                        <div class="one-third column"><h3>Feedback </h3>
                            <p> We will Love to hear from you 
                                and take your advice.
                                Either Contact us on Social media 
                                or email us!
                            </p>
                            <a href="HelpPage.aspx">
                        FAQ<br />
                        </a>
                        </div>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <div id="footer-base">
                <div class="container">
                    <div class="eight columns">
                        2015 HashDash IT
                    </div>
                    <div class="eight columns far-edge">
                        <a href="#">back to top...</a>
                    </div>
                </div>
            </div>
       </div>
    </footer>

</asp:Content>
