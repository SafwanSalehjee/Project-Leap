<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="RenderChartAdm.aspx.cs" Inherits="Project_Leap_V3.frames.RenderChartAdm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:DropDownList ID="ddlRenderChartNPO" Style="border-radius: 0px;" CssClass="textBoxStyle" runat="server" AutoPostBack="true"></asp:DropDownList>
    </div> 

    <div runat="server" id="SystemIncomeRep">
        <iframe style="width: 100%; height: 1000px;" src="reports/system/SysteIncome.aspx"></iframe>
    </div>

    <div runat="server" id="SystemPredInc">
        <iframe style="width: 100%; height: 1000px;" src="reports/system/PredictIncome.aspx"></iframe>
    </div>
    
    <div runat="server" id="Top10Bus">
        <iframe style="width: 100%; height: 1000px;" src="reports/mixed/TopDonBus.aspx"></iframe>
    </div>

    <div runat="server" id="DailyRegUsers">
        <iframe style="width: 100%; height: 1000px;" src="reports/system/DailyUserRegistration.aspx"></iframe>
    </div>

    <div runat="server" id="DailyRegOrgs">
        <iframe style="width: 100%; height: 1000px;" src="reports/system/DailyOrganisationRegistration.aspx"></iframe>
    </div>
</asp:Content>
