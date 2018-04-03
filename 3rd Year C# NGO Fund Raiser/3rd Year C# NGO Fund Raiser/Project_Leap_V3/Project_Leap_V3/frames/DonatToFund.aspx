<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="DonatToFund.aspx.cs" Inherits="Project_Leap_V3.frames.DonatToFund" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <asp:Label ID="lblFund" runat="server" Text=""></asp:Label></h2>
    <table style="width: 100%; border: solid #ddd; border-width: 1px; clear: both; margin: 10px 0 30px; height: 0;">
        <tr>
            <td>
                <asp:Label ID="lblDiscrip" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDonat" runat="server">Please donate:</asp:Label></td>

        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtDonate" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnDonate" runat="server" Text="Donate" OnClick="btnDonate_Click" /></td>
        </tr>
    </table>
</asp:Content>
