<%@ Page Title="" Language="C#" MasterPageFile="~/Project_Leap_Master.Master" AutoEventWireup="true" CodeBehind="ForgotPassPage.aspx.cs" Inherits="Project_Leap_V3.ForgotPassPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center" class="container">
        <div class="sixteen columns">
            <table>
                <tr>
                    <td colspan="2">
                        <h2><i class="icon-inbox"></i>Retrieve password:</h2>
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
                        <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
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
                    <td></td>
                    <td>
                        <asp:Button ID="btnEmailSubmit" Style="margin-left: 50px" runat="server" Text="Submit" OnClick="btnEmalSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="regExEmail" ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Static" ErrorMessage="Incorrect email format!" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="reqEmail" ForeColor="Red" ControlToValidate="txtEmail" runat="server" ErrorMessage="Enter an email address!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
