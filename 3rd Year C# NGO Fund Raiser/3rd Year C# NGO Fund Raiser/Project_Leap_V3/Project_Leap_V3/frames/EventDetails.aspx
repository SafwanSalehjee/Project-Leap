<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs" Inherits="Project_Leap_V3.frames.EventDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Events Details:</h2>
    <div id="divEventsDetailsTable" runat="server">
    </div>

    <asp:Table ID="tblRSVP" runat="server" Width="232px">
        <asp:TableRow>
            <asp:TableCell>
                <asp:RadioButtonList ID="RBLrsvp" TextAlign="Left" runat="server" AutoPostBack="true" Width="197px" RepeatColumns="3" RepeatDirection="Horizontal" CellPadding="2">
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Maybe" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label ID="lblRSVP" runat="server" Text=""></asp:Label>
</asp:Content>
