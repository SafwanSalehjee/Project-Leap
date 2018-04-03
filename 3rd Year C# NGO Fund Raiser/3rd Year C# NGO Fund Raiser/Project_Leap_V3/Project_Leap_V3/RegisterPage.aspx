<%@ Page Title="" Language="C#" MasterPageFile="~/Project_Leap_Master.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Project_Leap_V3.RegisterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Register
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div align="center" class="container">
        <div id="regNPODiv" runat="server" class="sixteen columns">
            <table>
                <tr>
                    <td>
                        <h2><i class="icon-pencil"></i>NPO registration</h2>
                    </td>
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
                    <td>
                        <asp:Label ID="lblNPONum" runat="server" Text="Label">NPO number:</asp:Label></td>
                    <td>
                        <asp:Label ID="lblNPOName" runat="server" Text="Label">NPO name:</asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:TextBox ID="txtNPONum" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtNPOName" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblNPOAd" runat="server" Text="Label">Address:</asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblNPOStreet" runat="server" Text="Label">Street name and number:</asp:Label></td>
                    <td>
                        <asp:Label ID="lblNPOSuburb" runat="server" Text="Label">Suburb:</asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:TextBox ID="txtNPOStreet" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtNPOSub" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblNPOProvince" runat="server" Text="Label">Province:</asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:DropDownList ID="ddlNPOProv" runat="server"></asp:DropDownList></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblNPONumber" runat="server" Text="Label">Contact Number:</asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:TextBox ID="txtNPONumber" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblNPOInd" runat="server" Text="Label">Industry:</asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:DropDownList ID="DDLNPOInd" Style="border-radius: 0px;" CssClass="textBoxStyle" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblNPOIndOther" Visible="false" runat="server" Text="Label">Enter your industry type:</asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:TextBox ID="txtNPOOtherInd" Visible="false" CssClass="textBoxStyle" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblNPOProof" runat="server" Text="Label">Certificate of registration(for verification process):</asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:FileUpload ID="fupNPO" Style="width: 280px; margin: 0; padding: 5px; color: #666; background: #f5f5f5; border: 1px solid #ccc; margin: 5px 0; webkit-border-radius: 5px;" runat="server" /></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblBpoProfilePic" runat="server" Text="Logo:"></asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:FileUpload ID="fileUpNPOProfilePic" runat="server" /></td>
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

                <tr class="tableRowLastStyle">
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnRegNPO" runat="server" Text="Continue" OnClick="btnRegNPO_Click" /></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblReqField2" runat="server" Visible="false" ForeColor="Red" Text="Make sure all fields are filled in!"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblWrongInput" runat="server" Visible="false" ForeColor="Red" Text="Make sure your NPO and contact number are both numbers only!"></asp:Label></td>
                </tr>
            </table>
        </div>
    </div>


    <div align="center" class="container">
        <div id="regBusDiv" runat="server" class="sixteen columns">
            <table>
                <tr>
                    <td>
                        <h2><i class="icon-pencil"></i>Business registration</h2>
                    </td>
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
                    <td>
                        <asp:Label ID="lbBusENum" runat="server">Enteprise number:</asp:Label></td>
                    <td>
                        <asp:Label ID="lblBusName" runat="server">Business name:</asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:TextBox ID="txtBusENum" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtBusName" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblBusAddress" runat="server">Address:</asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblBusStreet" runat="server">Street name and number:</asp:Label></td>
                    <td>
                        <asp:Label ID="lblBusSuburb" runat="server">Suburb:</asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:TextBox ID="txtBusStreet" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtBusSuburb" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblBusProvince" runat="server">Province:</asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:DropDownList ID="BusDDProvince" runat="server"></asp:DropDownList></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblBusNumber" runat="server">Contact Number:</asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:TextBox ID="TxtBusCNumber" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblBusIndustry" runat="server">Industry:</asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:DropDownList ID="ddlBusIndustry" Style="border-radius: 0px;" CssClass="textBoxStyle" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblBusIndustryType" Visible="false" runat="server">Enter your industry type:</asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:TextBox ID="txtBusInd" Visible="false" CssClass="textBoxStyle" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblBusTax" runat="server">Tax statement/return(for verification process):</asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:FileUpload ID="fupBus" Style="width: 280px; margin: 0; padding: 5px; color: #666; background: #f5f5f5; border: 1px solid #ccc; margin: 5px 0; webkit-border-radius: 5px;" runat="server" /></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblBusPP" runat="server" Text="Logo:"></asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:FileUpload ID="fudBusP" runat="server" /></td>
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
                        <asp:Button ID="btnRegBus" runat="server" Text="Continue" OnClick="btnRegBus_Click" /></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblReqField" runat="server" Visible="false" ForeColor="Red" Text="Make sure all fields are filled in!"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblWrongText" runat="server" Visible="false" ForeColor="Red" Text="Make sure your enterprise and contact number are both numbers only!"></asp:Label></td>
                </tr>
            </table>
        </div>
    </div>


    <div align="center" class="container">
        <div id="regIndDiv" runat="server" class="sixteen columns">
            <table>
                <tr>
                    <td>
                        <h2>
                            <asp:Label ID="lblTitleRI" runat="server"><i class="icon-pencil"></i>Individual registration</asp:Label></h2>
                    </td>
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
                    <td>
                        <asp:Label ID="lblEmail" runat="server">Email address:</asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Static" ErrorMessage="Incorrect email type!" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="txtEmail" runat="server" ErrorMessage="Enter an email address!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
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
                        <asp:Button ID="btnRegInd" runat="server" Text="Register" OnClick="btnRegInd_Click" /></td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblRegMessage" runat="server" Text=""></asp:Label>
        <asp:CompareValidator ID="CompareValidator1" ForeColor="Red" ControlToValidate="txtPass" ControlToCompare="txtConPass" runat="server" ErrorMessage="Your passwords don't match!"></asp:CompareValidator>
        <asp:RegularExpressionValidator ID="uplValidator1" runat="server" ControlToValidate="fupBus"
            ErrorMessage=".jpg, .jpeg & png formats are allowed"
            ValidationExpression="(.+\.([Jj][Pp][Gg])|.+\.([Pp][Nn][Gg])|.+\.([Jj][Pp][Ee][Gg]))"></asp:RegularExpressionValidator>
        <%--<asp:RegularExpressionValidator ID="uplValidator2" runat="server" ControlToValidate="fupNPO"
 ErrorMessage=".jpg, .jpeg & png formats are allowed" 
 ValidationExpression="(.+\.([Jj][Pp][Gg])|.+\.([Pp][Nn][Gg])|.+\.([Jj][Pp][Ee][Gg]))"></asp:RegularExpressionValidator>--%>
    </div>
</asp:Content>
