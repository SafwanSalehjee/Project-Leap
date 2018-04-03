<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="RenderChartNPO.aspx.cs" Inherits="Project_Leap_V3.frames.RenderChartNPO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:DropDownList ID="ddlRenderChartNPO" Style="border-radius: 0px;" CssClass="textBoxStyle" runat="server" AutoPostBack="true"></asp:DropDownList>
    </div>
    <div runat="server" id="DonationsRecievedReport">
        <iframe style="width: 100%; height: 1000px;" src="reports/npo/DonationsRecievedReport.aspx"></iframe>
    </div>
    <div runat="server" id="ComparableDons">
        <iframe style="width: 100%; height: 1000px;" src="reports/npo/ComparableDons.aspx"></iframe>
    </div>
    <div runat="server" id="VolunteersPerRegion">
        <iframe style="width: 100%; height: 1000px;" src="reports/npo/VolunteersPerRegion.aspx"></iframe>
    </div>
    <div runat="server" id="FundCampCurrent">
        <iframe style="width: 100%; height: 1000px;" src="reports/npo/FundRaisingCampCurrent.aspx"></iframe>
    </div>
    <div runat="server" id="TopTenBus">
        <iframe style="width: 100%; height: 1000px;" src="reports/mixed/TopDonBus.aspx"></iframe>
    </div>
    <div runat="server" id="ShowingUpCols">
        <iframe style="width: 100%; height: 1000px;" src="reports/npo/VolunteersShowingUp.aspx"></iframe>
    </div>
    <div runat="server" id="FCSuccessRate">
        <iframe style="width: 100%; height: 1000px;" src="reports/npo/FCSuccessRateReport.aspx"></iframe>
    </div>
    <div runat="server" id="SupportByRegion">
        <iframe style="width: 100%; height: 1000px;" src="reports/mixed/MostSupportedIndustryArea.aspx"></iframe>
    </div>
    <div runat="server" id="PredictedDonations">
        <iframe style="width: 100%; height: 1000px;" src="reports/npo/PredictDon.aspx"></iframe>
    </div>
    <div runat="server" id="RatingsRep">
        <iframe style="width: 100%; height: 1000px;" src="reports/npo/NPORatingsReport.aspx"></iframe>
    </div>
</asp:Content>
