<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="RetrieveNewsFeeds.aspx.cs" Inherits="Project_Leap_V3.frames.RetrieveNewsFeeds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <aside class="four columns right-sidebar">
        <div class="sidebar-widget social" align="center" id="Retrive" runat="server">
        </div>
    </aside>

    <ul style="display: inline; position: absolute; margin-top: -30px;">
        <li style="display: inline;">
            <asp:LinkButton ID="btnPrevs" runat="server" OnClick="btnPrevs_Click"><i class="icon-arrow-left"></i></asp:LinkButton></li>
        <li style="display: inline;">
            <asp:LinkButton ID="btnNexts" runat="server" OnClick="btnNexts_Click"><i class="icon-arrow-right"></i></asp:LinkButton></li>
    </ul>
</asp:Content>
