<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="LogVolunteer.aspx.cs" Inherits="Project_Leap_V3.frames.LogVolunteer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center" id="divEve" runat="server" class="container">
        <article class="sixteen columns main-content">
            <h2>Log Volunteer</h2>
            <div align="left" id="divLV">
                <asp:Label ID="lblHours" runat="server" Text="Number of hours volunteered:"></asp:Label>
                <asp:TextBox ID="txtHours" runat="server"></asp:TextBox>
                <asp:Label ID="lblComment" runat="server" Text="Comment:" Style="text-align: left"></asp:Label>
                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Columns="50" Rows="7"></asp:TextBox>
                <br />
                <asp:Button ID="btnLV" runat="server" Text="Log Volunteer" OnClick="btnLV_Click" />
                <br />
                <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
            </div>
        </article>
    </div>
</asp:Content>
