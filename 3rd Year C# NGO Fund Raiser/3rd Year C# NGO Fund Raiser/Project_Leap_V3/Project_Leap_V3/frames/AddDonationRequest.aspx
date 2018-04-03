<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="AddDonationRequest.aspx.cs" Inherits="Project_Leap_V3.frames.AddDonationRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function refreshParent() {
            window.parent.location.reload();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add new donation request</h2>
    <table style="width: 100%; border: solid #ddd; border-width: 1px; clear: both; margin: 10px 0 30px; height: 0;">
        <tr>
            <td>Type:
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlType" AutoPostBack="true" runat="server"></asp:DropDownList>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAmount" runat="server" Text="Donation amount:"></asp:Label>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtAmount" Text="1000" runat="server"></asp:TextBox>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Description:
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:TextBox ID="txtDescription" Text="Food for the wild animals" TextMode="multiline" Columns="50" Rows="7" runat="server"></asp:TextBox>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td>
                <asp:Button ID="btnAddDonation" runat="server" Text="Add Donation" OnClick="btnAddDonation_Click" OnClientClick="return refreshParent();"/>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </td>
            <td></td>
            <td></td>
        </tr>
    </table>
</asp:Content>
