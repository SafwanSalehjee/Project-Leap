<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="ViewProgressReports.aspx.cs" Inherits="Project_Leap_V3.frames.ViewProgressReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Send progress report:</h1>
        <p>Title</p>
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        <p>Details</p>
        <asp:TextBox ID="txtBody" TextMode="multiline" Columns="50" Rows="7" runat="server"></asp:TextBox>
        <asp:Button ID="btnSendEmail" runat="server" Text="Send Progress Report" OnClick="btnSendEmail_Click" />
        <asp:Label ID="lblReply" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
