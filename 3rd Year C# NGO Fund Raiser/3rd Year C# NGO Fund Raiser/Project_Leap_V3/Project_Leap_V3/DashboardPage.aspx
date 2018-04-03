<%@ Page Title="" Language="C#" MasterPageFile="~/Project_Leap_Master.Master" AutoEventWireup="true" CodeBehind="DashboardPage.aspx.cs" Inherits="Project_Leap_V3.DashboardPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Dashboard
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(window).load(function () {
            $('body').addClass('loaded');
            $('h1').css('color', '#003c67');
        })
    </script>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <div id="loader-cont">
			<div id="loader"></div>
				<%--<div class="loader-section section-left"></div>
				<div class="loader-section section-right"></div>--%>
		</div>

    <div align="center" id="dashBoardNPOFin" runat="server" class="container">

        <article class="two columns left-sidebar" style="text-align: left;">
            <ul>
                <li>
                    <asp:LinkButton ID="btnDonNPOFin" runat="server" OnClick="btnDonNPOFin_Click">Donations</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnFunCNPOFin" runat="server" OnClick="btnFunCNPOFin_Click">Fundraising campaigns</asp:LinkButton></li>
            </ul>
        </article>

        <article class="ten columns main-content">

            <div runat="server" id="finMDon">
                <iframe style="width: 100%; height: 500px;" src="frames/RetrieveOwnDonations.aspx"></iframe>
            </div>

            <div runat="server" id="finMFC">
                <iframe style="width: 100%; height: 500px;" src="frames/FundraisingList.aspx"></iframe>
            </div>

        </article>


        <aside class="four columns right-sidebar">

            <div class="sidebar-widget social">
                <h1>NPO Status</h1>

                <div>
                    <iframe style="width: 100%; height: 100px;" src="frames/GetVerificationStatus.aspx"></iframe>
                </div>
            </div>

            <div class="sidebar-widget social">
                <h1>Rating</h1>
                <div>
                    <iframe style="width: 100%; height: 100px;" src="frames/AverageRating.aspx"></iframe>
                </div>
            </div>

            <div class="sidebar-widget social">
                <h1>News feeds</h1>

                <div>
                    <iframe style="width: 200px; height: 500px;" src="frames/RetrieveNewsFeeds.aspx"></iframe>
                </div>
            </div>
        </aside>
    </div>

    <div align="center" id="dashBoardNPOMan" runat="server" class="container">

        <article class="two columns left-sidebar" style="text-align: left;">
            <ul>
                <li>
                    <asp:LinkButton ID="btnSummary" runat="server" OnClick="btnSummary_Click">Summary</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnDonations" runat="server" OnClick="btnDonations_Click">Donations</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnEvent" runat="server" OnClick="btnEvent_Click">Events</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnFundCamp" runat="server" OnClick="btnFundCamp_Click">Fundraising campaigns</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnViewVols" runat="server" OnClick="btnViewVols_Click" >View Volunteers</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnAddFinMan" runat="server" OnClick="btnAddFinMan_Click">Add financial managers</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnRepNPO" runat="server" OnClick="btnReportsNPO_Click">Reports</asp:LinkButton></li>
            </ul>
        </article>

        <article class="ten columns main-content" runat="server" id="summaryNPO">
            <iframe style="width: 100%; height: 1000px;" src="frames/summary_pages/SummaryPageNPOMan.aspx"></iframe>
        </article>

        <article class="fourteen columns main-content" runat="server" id="mainNPO"> 

            <div runat="server" id="npoDonations">
                <div>
                    <iframe style="width: 100%; height: 600px;" src="frames/RetrieveOwnDonations.aspx"></iframe>
                </div>

                <div>
                    <iframe style="width: 100%; height: 550px" src="frames/AddDonationRequest.aspx"></iframe>
                </div>
            </div>

            <div runat="server" id="npoEvents">
                <div>
                    <iframe style="width: 100%; height: 500px" src="frames/ViewEvents.aspx"></iframe>
                </div>

                <div>
                    <iframe style="width: 100%; height: 900px;" src="frames/BookCharityEvent.aspx"></iframe>
                </div>
            </div>

            <div runat="server" id="npoFundCamps">
                <div>
                    <iframe style="width: 100%; height: 500px;" src="frames/FundraisingList.aspx"></iframe>
                </div>

                <div>
                    <iframe style="width: 100%; height: 700px;" src="frames/AddFundrasingCampaign.aspx"></iframe>
                </div>
            </div>

            <div runat="server" id="viewVols">
                <iframe style="width: 100%; height: 1400px;" src="frames/ViewVolunteers.aspx"></iframe>
            </div>

            <div runat="server" id="npoMans">
                <iframe style="width: 100%; height: 700px;" src="frames/ManAddFinMan.aspx"></iframe>
            </div>

            <div runat="server" id="npoReports">
                <iframe style="width: 100%; height: 1200px;" src="frames/RenderChartNPO.aspx"></iframe>
            </div>

           
        </article>

        <aside class="four columns right-sidebar" runat="server" id="sideBarNPO">

            <div style="text-align: left" class="sidebar-widget social">
                <h1>NPO Status</h1>

                <div>
                    <iframe style="width: 100%; height: 100px;" src="frames/GetVerificationStatus.aspx"></iframe>
                </div>
            </div>

            <div style="text-align: left" class="sidebar-widget social">
                <h1>Rating</h1>
                <div>
                    <iframe style="width: 100%; height: 100px;" src="frames/AverageRating.aspx"></iframe>
                </div>
            </div>

            <div class="sidebar-widget social">
                <iframe style="width: 300px; height: 400px;" src="frames/PostNewsFeed.aspx"></iframe>
            </div>

            <div class="sidebar-widget social">
                <iframe style="width: 300px; height: 400px;" src="frames/ViewProgressReports.aspx"></iframe>
            </div>
        </aside>
    </div>

    <div align="center" id="dashBoardBusFin" runat="server" class="container">

        <article class="twelve columns main-content">

            <div>
                <iframe style="width: 95%; height: 300px;" src="frames/RetrieveDonationsMade.aspx"></iframe>
            </div>

            
        </article>


        <aside class="four columns right-sidebar">

            <div class="sidebar-widget social">
                <h1>Business Status</h1>

                <div>
                    <iframe style="width: 100%; height: 100px;" src="frames/GetVerificationStatus.aspx"></iframe>
                </div>
            </div>

            <div class="sidebar-widget social">
                <h1>Your Points</h1>

                <div>
                    <iframe style="width: 100%; height: 100px;" src="frames/GetBusPoints.aspx"></iframe>
                </div>
            </div>

            <div class="sidebar-widget social">
                <h1>News feeds</h1>

                <div>
                    <iframe style="width: 200px; height: 500px;" src="frames/RetrieveNewsFeeds.aspx"></iframe>
                </div>

            </div>
        </aside>
    </div>

    <div id="dashBoardBusMan" runat="server" class="container">

        <article class="two columns left-sidebar" style="text-align: left;">
            <ul>
                <li>
                    <asp:LinkButton ID="btnBusSummary" runat="server" OnClick="btnSummaryDon_Click">Summary</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnBusDon" runat="server" OnClick="btnBusDon_Click">Donations</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnBusEvent" runat="server" OnClick="btnBusEvent_Click">Events</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnBusFund" runat="server" OnClick="btnBusFund_Click">Fundraising campaigns</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnBusFin" runat="server" OnClick="btnBusFin_Click">Add financial managers</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnReportsBusMan" runat="server" OnClick="btnReportsBusMan_Click">Reports</asp:LinkButton></li>
            </ul>
        </article>

        <article class="ten columns main-content" runat="server" id="summaryBus">
            <iframe style="width: 100%; height: 1000px;" src="frames/summary_pages/SummaryPageBus.aspx"></iframe>
        </article>

        <article class="fourteen columns main-content" runat="server" id="mainBusMan">

            <div runat="server" id="busDon">
                <div>
                    <iframe style="width: 95%; height: 400px;" src="frames/RetrieveDonationsMade.aspx"></iframe>
                </div>

                <div>
                    <iframe style="width: 100%; height: 1500px;" src="frames/RetrieveDonations.aspx"></iframe>
                </div>
            </div>

            <div runat="server" id="busE">
                <iframe style="width: 95%; height: 700px;" src="frames/ViewEvents.aspx"></iframe>
            </div>

            <div runat="server" id="busFC">
                <iframe style="width: 95%; height: 800px;" src="frames/FundraisingList.aspx"></iframe>
            </div>

            <div runat="server" id="busFMan">
                <iframe style="width: 100%; height: 700px;" src="frames/ManAddFinMan.aspx"></iframe>
            </div>

            <div runat="server" id="busManReports">
                <iframe style="width: 100%; height: 1200px;" src="frames/RenderChartBus.aspx"></iframe>
            </div>
        </article>

        <aside class="four columns right-sidebar" runat="server" id="sideBusMan">

            <div class="sidebar-widget social">
                <h1>Business Status</h1>

                <div>
                    <iframe style="width: 100%; height: 100px;" src="frames/GetVerificationStatus.aspx"></iframe>
                </div>
            </div>

            <div class="sidebar-widget social">
                <h1>Your Points</h1>

                <div>
                    <iframe style="width: 100%; height: 100px;" src="frames/GetBusPoints.aspx"></iframe>
                </div>
            </div>

            <div class="sidebar-widget social">
                <h1>News feeds</h1>

                <div>
                    <iframe style="width: 200px; height: 500px;" src="frames/RetrieveNewsFeeds.aspx"></iframe>
                </div>

            </div>
        </aside>
    </div>

    <div align="center" id="dashBoardInd" runat="server" class="container">

        <article class="two columns left-sidebar" style="text-align: left;">
            <ul>
                <li>
                    <asp:LinkButton ID="btnSummaryInd" runat="server" OnClick="btnISummary_Click">Summary</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnIVol" runat="server" OnClick="btnIVol_Click">Volunteering</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnIDon" runat="server" OnClick="btnIDon_Click">Donations</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnIFC" runat="server" OnClick="btnIFC_Click">Fundraising campaigns</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnBadges" runat="server" OnClick="btnIBadges_Click">Badges</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnReportsInd" runat="server" OnClick="btnIReports_Click">Reports</asp:LinkButton></li>
            </ul>
        </article>

        <article class="ten columns main-content" runat="server" id="summaryInd">
            <iframe style="width: 100%; height: 1000px;" src="frames/summary_pages/SummaryPageInd.aspx"></iframe>
        </article>

        <article class="fourteen columns main-content" runat="server" id="mainInd">

            <div runat="server" id="indVol">
                <iframe style="width: 100%; height: 500px;" src="frames/GetOwnVolunteerDetails.aspx"></iframe>
            </div>

            <div  runat="server" id="indDon">
                <div>
                    <iframe style="width: 100%; height: 400px;" src="frames/RetrieveDonationsMade.aspx"></iframe>
                </div>

                <div>
                    <iframe style="width: 100%; height: 1500px;" src="frames/RetrieveDonations.aspx"></iframe>
                </div>

            </div>

            <div  runat="server" id="indFC">
                <iframe style="width: 95%; height: 1000px;" src="frames/FundraisingList.aspx"></iframe>
            </div>

            <div  runat="server" id="indBadges">
                <iframe style="width: 95%; height: 1000px;" src="frames/Badges.aspx"></iframe>
            </div>

            <div runat="server" id="indReports">
                <iframe style="width: 100%; height: 1200px;" src="frames/RenderChartInd.aspx"></iframe>
            </div>
        </article>

        <aside class="four columns right-sidebar" runat="server" id="sideInd">

            <div class="sidebar-widget social">
                <h1>Your Points</h1>

                <div>
                    <iframe style="width: 100%; height: 100px;" src="frames/GetIndPoint.aspx"></iframe>
                </div>
            </div>

            <div class="sidebar-widget social">
                <h1>News feeds</h1>

                <div>
                    <iframe style="width: 200px; height: 500px;" src="frames/RetrieveNewsFeeds.aspx"></iframe>
                </div>

            </div>
        </aside>
    </div>

    <div align="center" id="dashBoardSysMan" runat="server" class="container">

        <article class="two columns left-sidebar" style="text-align: left;">
            <ul>
                <li>
                    <asp:LinkButton ID="btnSystemVerify" runat="server" OnClick="btnVerifyOrgs_Click">Verify Organisation</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnReportsSysMan" runat="server" OnClick="btnReportSys_Click">Reports</asp:LinkButton>
                </li>
            </ul>
        </article>

        <article class="ten columns main-content" runat="server" id="verifyPage">
            <iframe style="width: 100%; height: 1500px;" src="frames/GetUnverifiedOrgs.aspx"></iframe>
        </article>

        <article class="fourteen columns main-content" runat="server" id="reportsSysMan">
            <iframe style="width: 100%; height: 1200px;" src="frames/RenderChartAdm.aspx"></iframe>
        </article>

        <aside class="four columns right-sidebar" runat="server" id="sideSysMan">

            <div class="sidebar-widget social">
                <h1>Amount made by system</h1>

                <div>
                    <iframe style="width: 100%; height: 100px;" src="frames/AmountSystemGenerated.aspx"></iframe>
                </div>
            </div>

            <div class="sidebar-widget social">
                <h1>News feeds</h1>

                <div>
                    <iframe style="width: 200px; height: 500px;" src="frames/RetrieveNewsFeeds.aspx"></iframe>
                </div>
            </div>
        </aside>
    </div>

    <div align="center" id="dashBoardSysAdm" runat="server" class="container">

        <article class="two columns left-sidebar" style="text-align: left;">
            <ul>
                <li>
                    <asp:LinkButton ID="btnAddSysMan" runat="server" OnClick="btnAddSysMan_Click">Add system manager</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="btnAddSysAdn" runat="server" OnClick="btnAddSysAdn_Click">Add system administrator</asp:LinkButton></li>
            </ul>
        </article>

        <article class="ten columns main-content">

            <div runat="server" id="admAddMan">
                <iframe style="width: 100%; height: 500px;" src="frames/AddSystemManager.aspx"></iframe>
            </div>

            <div runat="server" id="admAddAdm">
                <iframe style="width: 100%; height: 500px;" src="frames/AddSystemAdmin.aspx"></iframe>
            </div>

        </article>

        <aside class="four columns right-sidebar">

            <div class="sidebar-widget social">
                <h1>News feeds</h1>

                <div>
                    <iframe style="width: 200px; height: 500px;" src="frames/RetrieveNewsFeeds.aspx"></iframe>
                </div>
            </div>
        </aside>
    </div>

    <style>
		#ohsnap {
			position: fixed;
			bottom: 5px;
			right: 5px;
			margin-left: 5px;
			z-index: 99;
			width: 250px;
		}
		.alert {
		  padding: 15px;
		  margin-bottom: 20px;
		  border: 1px solid #eed3d7;
		  border-radius: 4px;
		  position: absolute;
		  bottom: 0px;
		  right: 21px;
		  /* Each alert has its own width */
		  float: right; 
		  clear: right;
		}

		.alert-red {
		  color: white;
		  background-color: #DA4453;
		}
		.alert-green {
		  color: white;
		  background-color: #37BC9B;
		}
		.alert-blue {
		  color: white;
		  background-color: #4A89DC;
		}
		.alert-yellow {
		  color: white;
		  background-color: #F6BB42;
		}
		.alert-orange {
		  color:white;
		  background-color: #E9573F;
		}
	</style>

    <div id="ohsnap" class="buttons"> </div>
    <script>
        $('#red').on('click', function () { ohSnap('Oh Snap! You can\'t access this page!', 'red') });
        $('#blue').on('click', function () { ohSnap('Goin green sonsssssssssssssssssssssssssssssssssssssssssssssss!', 'blue') });
        //window.onload = function () { ohSnap('Goin green sonsssssssssssssssssssssssssssssssssssssssssssssss!', 'blue') };
        function ohSnap(text, color, icon) {
            var icon_markup = "",
				html,
				time = '5000',
				$container = $('#ohsnap');

            if (icon) {
                icon_markup = "<span class='" + icon + "'></span> ";
            }

            // Generate the HTML
            html = $('<div class="alert alert-' + color + '">' + icon_markup + text + '</div>').fadeIn('fast');

            // Append the label to the container
            $container.append(html);

            // Remove the notification on click
            html.on('click', function () {
                ohSnapX($(this));
            });

            // After 'time' seconds, the animation fades out
            setTimeout(function () {
                ohSnapX(html);
            }, time);
        }

        function ohSnapX(element) {
            // Called without argument, the function removes all alerts
            // element must be a jQuery object

            if (typeof element !== "undefined") {
                element.fadeOut('fast', function () {
                    $(this).remove();
                });
            } else {
                $('.alert').fadeOut('fast', function () {
                    $(this).remove();
                });
            }
        }
	</script> 
</asp:Content>
