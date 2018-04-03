<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="FinManDetails.aspx.cs" Inherits="Project_Leap_V3.frames.FinManDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="sixteen columns">
            <div class="four columns">
                <h5></h5>
            </div>
            <div class="eight columns">

                <div align="center" class="container">
                    <td>
                        <h2><i></i>Set Password:</h2>
                    </td>
                    <hr />
                    <div id="regIndDiv" runat="server" class="sixteen columns">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblPass">Password:</asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="txtPass" runat="server" ErrorMessage="Enter a password!"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lblConPass" runat="server" Text="Label">Confirm Password:</asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtConPass" runat="server" TextMode="Password"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ControlToValidate="txtConPass" runat="server" ErrorMessage="Enter your password again!"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSubmitPass" runat="server" Text="Submit" OnClick="btnSubmitPass_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:Label ID="lblIsPassUpdate" runat="server" Text=""></asp:Label>
                    <asp:CompareValidator ID="CompareValidator1" ForeColor="Red" ControlToValidate="txtPass" ControlToCompare="txtConPass" runat="server" ErrorMessage="Your passwords don't match!"></asp:CompareValidator>
                    <hr />
                </div>
</asp:Content>
