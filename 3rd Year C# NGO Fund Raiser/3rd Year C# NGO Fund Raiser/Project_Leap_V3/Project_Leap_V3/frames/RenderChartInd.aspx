<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="RenderChartInd.aspx.cs" Inherits="Project_Leap_V3.frames.RenderChartInd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:DropDownList ID="ddlRenderChartBus" Style="border-radius: 0px;" CssClass="textBoxStyle" runat="server" AutoPostBack="true"></asp:DropDownList>
    </div>
    <div runat="server" id="DonationsMadeReport">
        <iframe style="width: 100%; height: 1000px;" src="reports/mixed/DonationsMadeReport.aspx"></iframe>
    </div>
    <div runat="server" id="MostActInd">
        <iframe style="width: 100%; height: 1000px;" src="reports/individual/Most_Active_Individual.aspx"></iframe>
    </div>
    <div runat="server" id="Top10Bus">
        <iframe style="width: 100%; height: 1000px;" src="reports/mixed/TopDonBus.aspx"></iframe>
    </div>
    <div runat="server" id="SupportedOrgs">
        <iframe style="width: 100%; height: 1000px;" src="reports/mixed/MostSuppportedNPOIndustry.aspx"></iframe>
    </div>
    <div runat="server" id="SupportedOrgsSpesific">
        <iframe style="width: 100%; height: 1000px;" src="reports/mixed/MostSupporttedNPOinSpecificIndustry.aspx"></iframe>
    </div>
    <div runat="server" id="BadgesReport">
        <iframe style="width: 100%; height: 1000px;" src="reports/individual/BadgesThatUserHaveReport.aspx"></iframe>
    </div>
</asp:Content>
