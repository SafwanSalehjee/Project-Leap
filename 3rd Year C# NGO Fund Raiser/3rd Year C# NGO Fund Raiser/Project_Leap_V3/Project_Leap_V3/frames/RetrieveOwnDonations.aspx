<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="RetrieveOwnDonations.aspx.cs" Inherits="Project_Leap_V3.frames.RetrieveOwnDonations" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function downloadCSV() {
            var dons = <%=new JavaScriptSerializer().Serialize(this.donationCSV) %>;
            var a = document.createElement('a');
            a.href = 'data:attachment/csv,' + dons;
            a.target = '_blank';
            a.download = 'Donations.csv';

            document.body.appendChild(a);
            a.click();
        }
    </script>
    <h2>Donation requests in progress</h2>

    <table style="margin-bottom: -15px; margin-right: 50px;float: right;">
        <tr>
            <td>
                <asp:TextBox Width="100px" Height="10px" ID="txtSearch" runat="server"></asp:TextBox></td>
            <td>
                <asp:LinkButton Font-Size="15px" Style="position: absolute; margin-top: 0px; margin-left: 10px" ID="btnSearch" runat="server" OnClick="btnSearch_Click"><i class="icon-search"></i></asp:LinkButton>
            </td>
        </tr>
    </table>

    <div style="clear: both;" id="DonationsTable" runat="server">
    </div>

    <ul style="display: inline; position: absolute; margin-top: -30px;">
        <li style="display: inline;">
            <asp:LinkButton ID="btnPrevs" runat="server" OnClick="btnPrevs_Click"><i class="icon-arrow-left"></i></asp:LinkButton></li>
        <li style="display: inline;">
            <asp:LinkButton ID="btnNexts" runat="server" OnClick="btnNexts_Click"><i class="icon-arrow-right"></i></asp:LinkButton></li>
    </ul>

    <h2>Donation requests which are completed</h2>

    <table style="margin-bottom: -15px; margin-right: 50px;float: right;">
        <tr>
            <td>
                <asp:TextBox Width="100px" Height="10px" ID="txtSearchOld" runat="server"></asp:TextBox></td>
            <td>
                <asp:LinkButton Font-Size="15px" Style="position: absolute; margin-top: 0px; margin-left: 10px" ID="btnSearchOld" runat="server" OnClick="btnSearchOld_Click"><i class="icon-search"></i></asp:LinkButton>
            </td>
        </tr>
    </table>

    <div style="clear: both;" id="DonationsTableOld" runat="server">
    </div>

    <ul style="display: inline; position: absolute; margin-top: -30px;">
        <li style="display: inline;">
            <asp:LinkButton ID="btnPrevsOld" runat="server" OnClick="btnPrevsOld_Click"><i class="icon-arrow-left"></i></asp:LinkButton></li>
        <li style="display: inline;">
            <asp:LinkButton ID="btnNextsOld" runat="server" OnClick="btnNextsOld_Click"><i class="icon-arrow-right"></i></asp:LinkButton></li>
    </ul>

    <button type="button" onclick="downloadCSV()">Download as CSV</button><br>
</asp:Content>
