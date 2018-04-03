<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="SummaryPageBus.aspx.cs" Inherits="Project_Leap_V3.frames.summary_pages.SummaryPageBus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Total donated towards NPOs</h1>
    <blockquote class='testimonial no-after' id="totalDons" runat="server" style="font-size: 20px;"></blockquote>

    <h1>Next event attending</h1>
    <blockquote class='testimonial no-after' id="nextEvent" runat="server" style="font-size: 20px;"></blockquote>

</asp:Content>
