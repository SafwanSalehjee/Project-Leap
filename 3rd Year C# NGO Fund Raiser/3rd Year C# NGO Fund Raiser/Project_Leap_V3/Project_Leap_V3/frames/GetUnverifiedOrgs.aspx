<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="GetUnverifiedOrgs.aspx.cs" Inherits="Project_Leap_V3.frames.GetUnverifiedOrgs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div align="center" id="divNPO" runat="server" class="container">
        <article class="sixteen columns main-content">

            <h2 style="float: left;">Unverified Organisations</h2>
            <div style="clear: both"></div>
            <table style="margin-bottom: -15px; margin-right: 50px; float: right;">
                <tr>
                    <td>
                        <asp:TextBox Width="100px" Height="10px" ID="txtSearch" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:LinkButton Font-Size="15px" Style="position: absolute; margin-top: 0px; margin-left: 10px" ID="btnSearch" runat="server" OnClick="btnSearch_Click"><i class="icon-search"></i></asp:LinkButton>
                    </td>
                </tr>
            </table>

            <div id="divNPOTable" runat="server">
            </div>

            <ul style="display: inline; position: relative; margin-top: -30px; float: left">
                <li style="display: inline;">
                    <asp:LinkButton ID="btnPrevs" runat="server" OnClick="btnPrevs_Click"><i class="icon-arrow-left"></i></asp:LinkButton></li>
                <li style="display: inline;">
                    <asp:LinkButton ID="btnNexts" runat="server" OnClick="btnNexts_Click"><i class="icon-arrow-right"></i></asp:LinkButton></li>
            </ul>

        </article>
    </div>

</asp:Content>
