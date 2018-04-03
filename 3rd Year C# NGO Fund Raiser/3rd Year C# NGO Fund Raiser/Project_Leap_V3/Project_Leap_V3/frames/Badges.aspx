<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="Badges.aspx.cs" Inherits="Project_Leap_V3.frames.Badges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sixteen columns">
        <div class="four columns">
            <h5></h5>
        </div>
        <div class="eight columns" align="center">
            <td>
                <h2><i></i>Badges</h2>
            </td>
            <hr />
            <div id="badgesContainer" runat="server"></div>
            <hr />
        </div>
    </div>
</asp:Content>
