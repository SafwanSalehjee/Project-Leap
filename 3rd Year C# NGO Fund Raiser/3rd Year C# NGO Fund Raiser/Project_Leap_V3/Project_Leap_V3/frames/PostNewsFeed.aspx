<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="PostNewsFeed.aspx.cs" Inherits="Project_Leap_V3.frames.PostNewsFeed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Post news feed</h1>
        <p>Title</p>
        <asp:TextBox ID="txtTitle" Text="Thanks to Safwan's Cars" runat="server"></asp:TextBox>
        <p>Details</p>
        <asp:TextBox ID="txtBody" TextMode="multiline" Text="We appretiate your help." Columns="50" Rows="7" runat="server"></asp:TextBox>
        <asp:Button ID="btnPostNewsFeed" runat="server" Text="Post" OnClick="btnPostNewsFeed_Click" />
        <asp:Label ID="lblReply" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
