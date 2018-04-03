<%@ Page Title="" Language="C#" MasterPageFile="~/Project_Leap_Master.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="Project_Leap_V3.UserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    User
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div runat="server" id="OrgDiv">
            <div class="four columns main-content">
                <asp:Image ID="orgPic" Width="200px" Height="200px" runat="server" ImageUrl="~/images/ina.jpg" />
            </div>
            <asp:Button ID="btnRemoveOrg" runat="server" Text="Remove" OnClick="btnRemoveOrg_Click"/>
            <div id="orgDetailsDiv" runat="server" class="twelve columns right-sidebar">
            </div>
            <table>
                <tr>
                    <td>
                        <iframe runat="server" id="VolunteerFrame" style="width: 300px; height: 500px"></iframe>
                    </td>
                    <td style="width: 300px"></td>
                    <td>
                        <iframe runat="server" id="RateReviewNPOFrame" style="width: 500px; height: 500px"></iframe>
                    </td>

                    <td>
                        <iframe runat="server" id="AvgRatingFrame" style="width: 500px; height: 500px"></iframe>
                    </td>
                </tr>
            </table>
        </div>

        <div id="userDiv" runat="server">
            <div class="four columns main-content">
                <asp:Image ID="imgUser" Width="200px" Height="200px" runat="server" ImageUrl="~/images/avatar1.png" />
            </div>
            <asp:Button ID="btnRemoveUser" runat="server" Text="Remove" OnClick="btnRemove_Click" />
            <div runat="server" id="IndDetailsDiv" class="twelve columns right-sidebar"></div>
        </div>

    </div>
</asp:Content>
