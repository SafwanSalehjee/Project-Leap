<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="PaymentForm.aspx.cs" Inherits="Project_Leap_V3.frames.PaymentForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div align="center" class="container">
        <div class="sixteen columns">
            <table>
                <tr>
                    <td>
                        <h2><i class="icon-money"></i>Make a donation:</h2>
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
                    <td>NPO:</td>
                    <td style="text-align: right">
                        <asp:Label ID="lblNPO" runat="server" Text="Red Cross"></asp:Label></td>
                </tr>

                <tr>
                    <td>Amount:</td>
                    <td style="text-align: right">
                        <asp:Label ID="lblAmount" runat="server" Text="R 500.00"></asp:Label></td>
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
                    <td colspan="2">
                        <asp:RadioButtonList AutoPostBack="true" ID="rbPayment" TextAlign="Left" runat="server" Width="500px" RepeatColumns="4" RepeatDirection="Horizontal" CellPadding="2">
                            <asp:ListItem Text="" Value="Visa"><img style="width: 75px; height: 50px;" src="../images/payments/visa.jpg"/></asp:ListItem>
                            <asp:ListItem Text="" Value="MasterCard"><img style="width: 75px; height: 50px;" src="../images/payments/mastercard.png"/></asp:ListItem>
                            <asp:ListItem Text="" Value="AmericanExpress"><img style="width: 75px; height: 50px;" src="../images/payments/americanExpress.png"/></asp:ListItem>
                            <asp:ListItem Text="" Value="Paypal"><img style="width: 75px; height: 50px;" src="../images/payments/paypal.png"/></asp:ListItem>
                        </asp:RadioButtonList></td>
                    <td></td>
                </tr>

                <tr>
                    <td>Email:</td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                    <td></td>
                </tr>

                <tr runat="server" id="cardNum">
                    <td>Card number:</td>
                </tr>

                <tr runat="server" id="cardNumTxt">
                    <td colspan="2">
                        <asp:TextBox ID="txtCardNum" runat="server"></asp:TextBox></td>
                    <td></td>
                </tr>

                <tr runat="server" id="cardHolder">
                    <td>Card holder name:</td>
                </tr>

                <tr runat="server" id="cardHolderTxt">
                    <td colspan="2">
                        <asp:TextBox ID="txtHolder" runat="server"></asp:TextBox></td>
                    <td></td>
                </tr>

                <tr runat="server" id="ccvNum">
                    <td>CCV number:</td>
                </tr>

                <tr runat="server" id="ccvNumTxt">
                    <td colspan="2">
                        <asp:TextBox ID="txtCCV" runat="server"></asp:TextBox></td>
                    <td></td>
                </tr>

                <tr runat="server" id="expTitle">
                    <td>Card experation date:</td>
                </tr>

                <tr runat="server" id="expMY">
                    <td>Month:</td>
                    <td>Year:</td>
                </tr>

                <tr runat="server" id="expMYddl">
                    <td>
                        <asp:DropDownList ID="ddlMonth" runat="server" Width="120px">
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
                    </td>

                    <td>
                        <asp:DropDownList ID="ddlYear" runat="server" Width="120px">
                            <asp:ListItem Text="2015" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2016" Value="2"></asp:ListItem>
                            <asp:ListItem Text="2017" Value="3"></asp:ListItem>
                            <asp:ListItem Text="2018" Value="4"></asp:ListItem>
                            <asp:ListItem Text="2019" Value="5"></asp:ListItem>
                            <asp:ListItem Text="2020" Value="6"></asp:ListItem>
                            <asp:ListItem Text="2021" Value="7"></asp:ListItem>
                            <asp:ListItem Text="2022" Value="8"></asp:ListItem>
                            <asp:ListItem Text="2023" Value="9"></asp:ListItem>
                            <asp:ListItem Text="2024" Value="10"></asp:ListItem>
                            <asp:ListItem Text="2025" Value="11"></asp:ListItem>
                            <asp:ListItem Text="2026" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr runat="server" id="paypalPassword">
                    <td>Paypal Password:</td>
                </tr>
                <tr runat="server" id="paypalPasswordTxt">
                    <td colspan="2">
                        <asp:TextBox ID="txtPaypalPassword" TextMode="Password" runat="server"></asp:TextBox></td>
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
                        <asp:Button ID="btnDonate" runat="server" Style="margin-left: 50px" Text="Donate" OnClick="btnDonate_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblError" Visible="false" runat="server" ForeColor="Red" Text="Please make sure your details are correct and all filled in!"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="regExEmail" ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Static" ErrorMessage="Incorrect email format!" runat="server" />
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
    </div>


</asp:Content>
