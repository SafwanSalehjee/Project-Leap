﻿<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="ManAddFinMan.aspx.cs" Inherits="Project_Leap_V3.frames.ManAddFinMan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="sixteen columns">
            <div class="four columns">
                <h5></h5>
            </div>
            <div class="eight columns">
                <td>
                    <h2><i></i>Add financial manager</h2>
                </td>
                <hr />
                <asp:Label ID="lblAddFinMan" runat="server" Text="Email address:"></asp:Label>
                <asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox>

                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" ControlToValidate="txtEmailAddress" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Static" ErrorMessage="Incorrect email type!" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="txtEmailAddress" runat="server" ErrorMessage="Enter an email address!"></asp:RequiredFieldValidator>

                <br />
                <hr />
                <asp:Button ID="btnSendFMR" Text="Add" runat="server" OnClick="btnSendFMR_Click" />
                <asp:Label ID="lblRegFinMan" runat="server" Text=""></asp:Label>
            </div>
</asp:Content>
