<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="GetOwnVolunteerDetails.aspx.cs" Inherits="Project_Leap_V3.frames.GetOwnVolunteerDetails" %>
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
                    a.download = 'Volunteer.csv';

                    document.body.appendChild(a);
                    a.click();
                }
            </script>
    
        <article class="sixteen columns main-content">
            
            <h2>Volunteering at</h2>

            <table style="margin-bottom: -15px; margin-right: 50px; float: right;">
                <tr>
                    <td>
                        <asp:TextBox Width="100px" Height="10px" ID="txtSearchNew" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:LinkButton Font-Size="15px" Style="position: absolute; margin-top: 0px; margin-left: 10px" ID="btnSearchNew" runat="server" OnClick="btnSearchNew_Click"><i class="icon-search"></i></asp:LinkButton>
                    </td>
                </tr>
            </table>

            <div id="divVolunteeredTableNew" runat="server">
            </div>

            <ul style="display: inline; position: absolute; margin-top: -30px;">
                <li style="display: inline;">
                    <asp:LinkButton ID="btnPrevsNew" runat="server" OnClick="btnPrevsNew_Click"><i class="icon-arrow-left"></i></asp:LinkButton></li>
                <li style="display: inline;">
                    <asp:LinkButton ID="btnNextsNew" runat="server" OnClick="btnNextsNew_Click"><i class="icon-arrow-right"></i></asp:LinkButton></li>
            </ul>

            <h2>Where You Volunteered at</h2>

            <table style="margin-bottom: -15px; margin-right: 50px; float: right;">
                <tr>
                    <td>
                        <asp:TextBox Width="100px" Height="10px" ID="txtSearch" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:LinkButton Font-Size="15px" Style="position: absolute; margin-top: 0px; margin-left: 10px" ID="btnSearch" runat="server" OnClick="btnSearch_Click"><i class="icon-search"></i></asp:LinkButton>
                    </td>
                </tr>
            </table>

            <div id="divVolunteeredTable" runat="server">
            </div>

            <ul style="display: inline; position: absolute; margin-top: -30px;">
                <li style="display: inline;">
                    <asp:LinkButton ID="btnPrevs" runat="server" OnClick="btnPrevs_Click"><i class="icon-arrow-left"></i></asp:LinkButton></li>
                <li style="display: inline;">
                    <asp:LinkButton ID="btnNexts" runat="server" OnClick="btnNexts_Click"><i class="icon-arrow-right"></i></asp:LinkButton></li>
            </ul>
            <button type="button" onclick="downloadCSV()">Download as CSV</button><br>
        </article>

</asp:Content>
