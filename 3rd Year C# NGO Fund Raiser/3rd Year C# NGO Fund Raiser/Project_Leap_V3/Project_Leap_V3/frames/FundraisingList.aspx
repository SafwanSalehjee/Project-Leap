<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="FundraisingList.aspx.cs" Inherits="Project_Leap_V3.frames.FundraisingList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Fundraising Campaigns</h2>

    <table style="margin-bottom: -15px; margin-right: 50px;float: right;">
        <tr>
            <td>
                <asp:TextBox Width="100px" Height="10px" ID="txtSearch" runat="server"></asp:TextBox></td>
            <td>
                <asp:LinkButton Font-Size="15px" Style="position: absolute; margin-top: 0px; margin-left: 10px" ID="btnSearch" runat="server" OnClick="btnSearch_Click"><i class="icon-search"></i></asp:LinkButton>
            </td>
        </tr>
    </table>

    <div id="dFClist" runat="server">
    </div>

    <ul style="display: inline; position: absolute; margin-top: -30px;">
        <li style="display: inline;">
            <asp:LinkButton ID="btnPrevs" runat="server" OnClick="btnPrevs_Click"><i class="icon-arrow-left"></i></asp:LinkButton></li>
        <li style="display: inline;">
            <asp:LinkButton ID="btnNexts" runat="server" OnClick="btnNexts_Click"><i class="icon-arrow-right"></i></asp:LinkButton></li>
    </ul>

    <div id="FCDoneNPO" runat="server">
        <h2>Completed Fundraising Campaigns</h2>

        <table style="margin-bottom: -15px; margin-right: 50px;float: right;">
            <tr>
                <td>
                    <asp:TextBox Width="100px" Height="10px" ID="txtSearchDone" runat="server"></asp:TextBox></td>
                <td>
                    <asp:LinkButton Font-Size="15px" Style="position: absolute; margin-top: 0px; margin-left: 10px" ID="btnSearchDone" runat="server" OnClick="btnSearchDone_Click"><i class="icon-search"></i></asp:LinkButton>
                </td>
            </tr>
        </table>

        <div id="dFClistDone" runat="server">
        </div>

        <ul style="display: inline; position: absolute; margin-top: -30px;">
            <li style="display: inline;">
                <asp:LinkButton ID="btnPrevsDone" runat="server" OnClick="btnPrevsDone_Click"><i class="icon-arrow-left"></i></asp:LinkButton></li>
            <li style="display: inline;">
                <asp:LinkButton ID="btnNextsDone" runat="server" OnClick="btnNextsDone_Click"><i class="icon-arrow-right"></i></asp:LinkButton></li>
        </ul>
    </div>
</asp:Content>
