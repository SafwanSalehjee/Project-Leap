<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="VolunteerPage.aspx.cs" Inherits="Project_Leap_V3.frames.VolunteerPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="sixteen columns">
            <div class="four columns">
                <h5></h5>
            </div>
            <div class="eight columns">

                <div align="left" class="container">
                    <td>
                        <h2><i></i>Volunteer:</h2>
                    </td>
                    <hr />
                    <asp:Table runat="server">
                        <asp:TableRow>
                            <asp:TableCell Width="200">
                                <asp:Label ID="lblDate" Text="Date of Volunteering:" runat="server"></asp:Label></asp:TableCell>
                            <asp:TableCell Width="100">
                                <asp:Label ID="lblVolDate" runat="server"></asp:Label></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Table runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:ImageButton ID="btnCal" runat="server" ImageUrl="~/images/Calendar icon.png" OnClick="btnCal_Click" /></asp:TableCell>
                            <asp:TableCell Width="200">
                                <asp:Calendar ID="calVolDate" runat="server" Font-Size="Small" OnSelectionChanged="calVolDate_SelectionChanged" Visible="false" DayHeaderStyle-ForeColor="#0033CC" DayHeaderStyle-BackColor="White" TitleStyle-BackColor="#3366CC"></asp:Calendar>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnVolunteer" runat="server" Text="Volunteer" OnClick="btnVolunteer_Click" />
                    <asp:Label ID="lblSuccessful" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
