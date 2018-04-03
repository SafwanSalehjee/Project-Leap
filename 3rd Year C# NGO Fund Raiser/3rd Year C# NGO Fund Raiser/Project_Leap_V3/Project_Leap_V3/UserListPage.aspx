<%@ Page Title="" Language="C#" MasterPageFile="~/Project_Leap_Master.Master" AutoEventWireup="true" CodeBehind="UserListPage.aspx.cs" Inherits="Project_Leap_V3.UserListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Users
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div align="center" id="divNPO" runat="server" class="container">
        <article class="sixteen columns main-content">

            <h2>NPOs</h2>

            <table style="margin-bottom: -15px; margin-right: 30px; float: right;">
                <tr>
                    <td>
                        <asp:TextBox Width="100px" Height="10px" ID="txtSearchNPO" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:LinkButton Font-Size="15px" Style="position: absolute; margin-top: -42px; margin-left: 10px" ID="btnSearchNPO" runat="server" OnClick="btnSearchNPO_Click"><i class="icon-search"></i></asp:LinkButton>
                    </td>
                </tr>
            </table>

            <%--<div align="left" id="divNPOFilter" runat="server" class="container">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblFilter" runat="server" style="margin-top: -55px; position: absolute" Text="Filter NPO:"></asp:Label></td>
                        <td></td>
                        <td>
                            <asp:DropDownList ID="ddlFilter" runat="server" Width="200px" AutoPostBack="true"></asp:DropDownList></td>
                    </tr>
                </table>
            </div>--%>
            <div id="divNPOTable" runat="server">
            </div>

            <ul style="display: inline; position: absolute; margin-top: -30px;">
                <li style="display: inline;">
                    <asp:LinkButton ID="btnPrevsNPO" runat="server" OnClick="btnPrevsNPO_Click"><i class="icon-arrow-left"></i></asp:LinkButton></li>
                <li style="display: inline;">
                    <asp:LinkButton ID="btnNextsNPO" runat="server" OnClick="btnNextsNPO_Click"><i class="icon-arrow-right"></i></asp:LinkButton></li>
            </ul>

        </article>
    </div>

    <div align="center" id="divBus" runat="server" class="container">
        <article class="sixteen columns main-content">

            <h2>Businesses</h2>

            <table style="margin-bottom: -15px; margin-right: 30px; float: right;">
                <tr>
                    <td>
                        <asp:TextBox Width="100px" Height="10px" ID="txtSearchBus" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:LinkButton Font-Size="15px" Style="position: absolute; margin-top: -42px; margin-left: 10px; height: 21px;" ID="btnSearchBus" runat="server" OnClick="btnSearchBus_Click"><i class="icon-search"></i></asp:LinkButton>
                    </td>
                </tr>
            </table>

            <div id="BusinessDiv" runat="server">
            </div>

            <ul style="display: inline; position: absolute; margin-top: -30px;">
                <li style="display: inline;">
                    <asp:LinkButton ID="btnPrevsBus" runat="server" OnClick="btnPrevsBus_Click"><i class="icon-arrow-left"></i></asp:LinkButton></li>
                <li style="display: inline;">
                    <asp:LinkButton ID="btnNextsBus" runat="server" OnClick="btnNextsBus_Click"><i class="icon-arrow-right"></i></asp:LinkButton></li>
            </ul>

        </article>
    </div>

    <div align="center" id="divInd" runat="server" class="container">
        <article class="sixteen columns main-content">

            <h2>Individuals</h2>

            <table style="margin-bottom: -15px; margin-right: 30px; float: right;">
                <tr>
                    <td>
                        <asp:TextBox Width="100px" Height="10px" ID="txtSearchInd" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:LinkButton Font-Size="15px" Style="position: absolute; margin-top: -42px; margin-left: 10px" ID="btnSearchInd" OnClick="btnSearchInd_Click" runat="server"><i class="icon-search"></i></asp:LinkButton>
                    </td>
                </tr>
            </table>

            <div id="divIndTable" runat="server">
            </div>

            <ul style="display: inline; position: absolute; margin-top: -30px;">
                <li style="display: inline;">
                    <asp:LinkButton ID="btnPrevsInd" runat="server" OnClick="btnPrevsInd_Click"><i class="icon-arrow-left"></i></asp:LinkButton></li>
                <li style="display: inline;">
                    <asp:LinkButton ID="btnNextsInd" runat="server" OnClick="btnNextsInd_Click"><i class="icon-arrow-right"></i></asp:LinkButton></li>
            </ul>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </article>
    </div>
</asp:Content>
