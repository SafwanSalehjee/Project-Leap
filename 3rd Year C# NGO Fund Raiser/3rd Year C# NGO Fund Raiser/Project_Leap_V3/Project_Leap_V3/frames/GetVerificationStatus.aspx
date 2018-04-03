<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="GetVerificationStatus.aspx.cs" Inherits="Project_Leap_V3.frames.GetVerificationStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <blockquote style="font-size: 50px" class="testimonial no-after">
        <asp:Label ID="lblVerified" runat="server" Text=""></asp:Label>
    </blockquote>
    <asp:Label ID="lblReason" runat="server" Text=""></asp:Label>
</asp:Content>
