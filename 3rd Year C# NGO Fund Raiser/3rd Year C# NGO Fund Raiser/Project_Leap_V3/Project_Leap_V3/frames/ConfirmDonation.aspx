<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="ConfirmDonation.aspx.cs" Inherits="Project_Leap_V3.frames.ConfirmDonation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function refreshParent() {
            window.parent.location.reload();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div align="center" class="container">
        <div class="sixteen columns">
            <table>
                <tr>
                    <td>
                        <h2><i class="icon-money"></i>Confirm donation:</h2>
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
                        <h3>Transaction Details</h3>
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
                    <td>
                        <h3>Your Details</h3>
                    </td>
                </tr>

                <tr runat="server" id="cardHolder">
                    <td>Card holder name:</td>
                    <td style="text-align: right">
                        <asp:Label ID="lblCardHolder" runat="server" Text="Ronnie"></asp:Label></td>
                </tr>

                <tr>
                    <td>Email:</td>
                    <td style="text-align: right">
                        <asp:Label ID="lblEmail" runat="server" Text="r@r.com"></asp:Label></td>
                </tr>

                <tr runat="server" id="cardNumber">
                    <td>Card number:</td>
                    <td style="text-align: right">
                        <asp:Label ID="lblCardNum" runat="server" Text="**** **** **** 5544"></asp:Label></td>
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
                        <asp:Button ID="btnConfirm" runat="server" Style="margin-left: 50px" Text="Confirm" OnClick="btnConfirm_Click"  OnClientClick="return refreshParent();"/>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblError" ForeColor="Red" runat="server" Visible="false" Text="An error occured. Please try the transaction again!"></asp:Label>
                    </td>
                </tr>

            </table>
        </div>
    </div>

</asp:Content>
