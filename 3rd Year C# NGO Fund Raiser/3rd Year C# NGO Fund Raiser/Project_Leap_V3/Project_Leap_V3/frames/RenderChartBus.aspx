<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="RenderChartBus.aspx.cs" Inherits="Project_Leap_V3.RenderChartBus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:DropDownList ID="ddlRenderChartBus" Style="border-radius: 0px;" CssClass="textBoxStyle" runat="server" AutoPostBack="true"></asp:DropDownList>
    </div>
    <div runat="server" id="DonationsMadeReport">
        <iframe style="width: 100%; height: 1000px;" src="reports/mixed/DonationsMadeReport.aspx"></iframe>
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
</asp:Content>
