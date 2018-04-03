<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="ViewEvents.aspx.cs" Inherits="Project_Leap_V3.frames.ViewEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Upcoming Events</h2>

    <table style="margin-bottom: -15px; margin-right: 50px; float: right;">
        <tr>
            <td>
                <asp:TextBox Width="100px" Height="10px" ID="txtSearch" runat="server"></asp:TextBox></td>
            <td>
                <asp:LinkButton Font-Size="15px" Style="position: absolute; margin-top: 0px; margin-left: 10px" ID="btnSearch" runat="server" OnClick="btnSearch_Click"><i class="icon-search"></i></asp:LinkButton>
            </td>
        </tr>
    </table>

    <div id="divEventsTable" runat="server">
    </div>

    <ul style="display: inline; position: absolute; margin-top: -30px;">
        <li style="display: inline;">
            <asp:LinkButton ID="btnPrevs" runat="server" OnClick="btnPrevs_Click"><i class="icon-arrow-left"></i></asp:LinkButton></li>
        <li style="display: inline;">
            <asp:LinkButton ID="btnNexts" runat="server" OnClick="btnNexts_Click"><i class="icon-arrow-right"></i></asp:LinkButton></li>
    </ul>

    <div runat="server" id="NPOPastEvents">
        <h2>Previous Events</h2>

        <table style="margin-bottom: -15px; margin-right: 50px; float: right;">
            <tr>
                <td>
                    <asp:TextBox Width="100px" Height="10px" ID="txtSearchOld" runat="server"></asp:TextBox></td>
                <td>
                    <asp:LinkButton Font-Size="15px" Style="position: absolute; margin-top: 0px; margin-left: 10px" ID="btnSearchOld" runat="server" OnClick="btnSearchOld_Click"><i class="icon-search"></i></asp:LinkButton>
                </td>
            </tr>
        </table>

        <div id="divEventsTableOld" runat="server">
        </div>

        <ul style="display: inline; position: absolute; margin-top: -30px;">
            <li style="display: inline;">
                <asp:LinkButton ID="btnPrevsOld" runat="server" OnClick="btnPrevsOld_Click"><i class="icon-arrow-left"></i></asp:LinkButton></li>
            <li style="display: inline;">
                <asp:LinkButton ID="btnNextsOld" runat="server" OnClick="btnNextsOld_Click"><i class="icon-arrow-right"></i></asp:LinkButton></li>
        </ul>
    </div>

</asp:Content>
