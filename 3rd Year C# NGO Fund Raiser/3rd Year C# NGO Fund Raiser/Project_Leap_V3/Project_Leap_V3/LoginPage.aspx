<%@ Page Title="" Language="C#" MasterPageFile="~/Project_Leap_Master.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Project_Leap_V3.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div align="center" class="container">
        <div class="sixteen columns">
            <table>
                <tr>
                    <td>
                        <h2><i class="icon-key"></i>Login:</h2>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <hr />
                    </td>
                    <td>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUsername" runat="server" Text="Email:"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="reqFieldUsername" ForeColor="Red" ControlToValidate="txtUsername" runat="server" ErrorMessage="Enter a email"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="regFieldPassword" ForeColor="Red" ControlToValidate="txtPassword" runat="server" ErrorMessage="Enter a password!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr />
                    </td>
                    <td>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="chbShowP" runat="server" AutoPostBack="true" />
                        <asp:Label ID="lblShowP" runat="server" Text="Show password"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Style="margin-left: 50px" Text="Login" OnClick="btnLogin_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLoginFailed" ForeColor="Red" Visible="false" runat="server" Text=""></asp:Label></td>
                </tr>
                <!-- change made here -->
                <tr>
                    <td>
                        <a href="ForgotPassPage.aspx">Forgot Password?</a>

                    </td>
                </tr>
                <!-- end -->
            </table>
        </div>
    </div>

    <footer style="position: absolute; bottom: 0; width: 100%;">
        <div id="footer-base">
            <div class="container">
                <div class="eight columns">
                    2015 HashDash IT
                </div>
            </div>
        </div>
    </footer>

</asp:Content>
