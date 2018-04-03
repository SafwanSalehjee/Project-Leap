<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="SummaryPageNPOMan.aspx.cs" Inherits="Project_Leap_V3.frames.summary_pages.SummaryPageNPOMan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Total received from donations</h1>
    <blockquote class='testimonial no-after' id="totalDons" runat="server" style="font-size: 20px;"></blockquote>

    <h1>Next event</h1>
    <blockquote class='testimonial no-after' id="nextEvent" runat="server" style="font-size: 20px;"></blockquote>

    <h1>Total fundraising campaign progress</h1>
    <blockquote class='testimonial no-after' id="FCProgress" runat="server" style="font-size: 20px;"></blockquote>
</asp:Content>
