<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="AddFundrasingCampaign.aspx.cs" Inherits="Project_Leap_V3.frames.AddFundrasingCampaign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function refreshParent() {
            window.parent.location.reload();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add Fundraising Campaign</h2>
    <table style="width: 100%; border: solid #ddd; border-width: 1px; clear: both; margin: 10px 0 30px; height: 0;">
        <tr>
            <td>Title:</td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtTitle" Text="Expansion Drive" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td>Description:</td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtDescription" Text="We want to increase our NPO operation. Please help." TextMode="multiline" Columns="50" Rows="7" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td>Amount:</td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtAmount" Text="100000" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnAddFundrasingCampaign" runat="server" Text="Add Fundrasing Campaign" OnClick="btnAddFundrasingCampaign_Click" OnClientClick="return refreshParent();"/></td>
        </tr>
    </table>
    <asp:Label ID="lblAdded" runat="server" Text=""></asp:Label>
</asp:Content>
