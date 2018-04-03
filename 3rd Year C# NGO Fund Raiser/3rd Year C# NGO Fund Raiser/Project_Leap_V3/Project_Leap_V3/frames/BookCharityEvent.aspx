<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="BookCharityEvent.aspx.cs" Inherits="Project_Leap_V3.frames.BookCharityEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function refreshParent() {
            window.parent.location.reload();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="sixteen columns">
            <div class="four columns">
                <h5>.</h5>
            </div>
            <div class="eight columns">
                <td>
                    <h2><i></i>Book charity event</h2>
                </td>
                <hr />
                <asp:Table runat="server">
                    <asp:TableRow>
                        <asp:TableCell Width="50">
                            <asp:Label ID="lblDate" Text="Date:" runat="server"></asp:Label></asp:TableCell>
                        <asp:TableCell Width="100">
                            <asp:Label ID="lblEventDate" runat="server"></asp:Label></asp:TableCell>
                        <asp:TableCell>
                            <asp:ImageButton ID="btnCal" runat="server" ImageUrl="~/images/Calendar icon.png" OnClick="btnCal_Click" /></asp:TableCell>
                        <asp:TableCell>
                            <asp:Calendar ID="calEventDate" runat="server" Font-Size="Small" OnSelectionChanged="calEventDate_SelectionChanged" Visible="false" DayHeaderStyle-ForeColor="#0033CC" DayHeaderStyle-BackColor="White" TitleStyle-BackColor="#3366CC"></asp:Calendar>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:Label ID="lblStartTime" Text="Start Time:" runat="server"></asp:Label>
                <asp:Table runat="server" Width="230px">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlSTHr" runat="server" Width="60" AutoPostBack="true">
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                <asp:ListItem Text="12" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlSTMin" runat="server" Width="60" AutoPostBack="true">
                                <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlSTAP" runat="server" Width="60" AutoPostBack="true">
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:Label ID="lblEventType" Text="Type of event:" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlEventType" runat="server" OnSelectedIndexChanged="ddlEventType_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="Auction" Value="Auction"></asp:ListItem>
                    <asp:ListItem Text="Car wash" Value="Car wash"></asp:ListItem>
                    <asp:ListItem Text="Cake sale" Value="Cake sale"></asp:ListItem>
                    <asp:ListItem Text="Fun walk" Value="Fun walk"></asp:ListItem>
                    <asp:ListItem Text="Gala" Value="Gala"></asp:ListItem>
                    <asp:ListItem Text="Raffle" Value="Raffle"></asp:ListItem>
                    <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtOther" runat="server"></asp:TextBox>

                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblHost" Text="Host:" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblEName" Text="Event name:" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblVenue" Text="Venue:" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox Text="In The Wild" Style="margin-right: 10px" Width="120px" ID="txtHost" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox Text="For the animals" Style="margin-right: 10px" Width="120px" ID="txtEName" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox Text="Gallagher Estate" Width="120px" ID="txtVenue" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDisc" runat="server" Text="Description"></asp:Label></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:TextBox ID="txtDescription" Text="We are having an endangered animal awareness event." TextMode="multiline" Width="100%" Columns="150" Rows="7" runat="server"></asp:TextBox></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <hr />
                        </td>
                        <td>
                            <hr />
                        </td>
                        <td>
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>
                            <asp:Button ID="btnBook" runat="server" Text="Book" OnClick="btnBook_Click" OnClientClick="return refreshParent();"/></td>
                    </tr>
                </table>

                <asp:Label ID="lblIsValid" runat="server" Text=""></asp:Label>
            </div>
        </div>

    </div>
</asp:Content>
