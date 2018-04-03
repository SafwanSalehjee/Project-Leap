<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="RateReviewNPO.aspx.cs" Inherits="Project_Leap_V3.frames.RateReviewNPO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="left" id="divRate" runat="server" class="container">
        <article class="sixteen columns main-content">
            <h2>Rate and Review NPO</h2>
            <hr />
            <div align="left" id="info" runat="server">
                <asp:Label ID="lblRating" runat="server" Text="Rating:" Font-Bold="true"></asp:Label>
                <br />
                <asp:Label ID="lblExplanation" runat="server" Text="Please select from the dropdown list your rating: 1 being the worst and 10 being the best" Font-Size="Small"></asp:Label>
                <asp:DropDownList ID="ddlRating" runat="server" AutoPostBack="true">
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
                </asp:DropDownList>
                <asp:Label ID="lblReview" runat="server" Text="Review:" Font-Bold="true"></asp:Label>
                <asp:TextBox ID="txtReview" runat="server" TextMode="MultiLine" Columns="50" Rows="7"></asp:TextBox>
                <hr />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Send feedback" OnClick="btnSubmit_Click" />
                <br />
                <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
            </div>
        </article>
    </div>
</asp:Content>
