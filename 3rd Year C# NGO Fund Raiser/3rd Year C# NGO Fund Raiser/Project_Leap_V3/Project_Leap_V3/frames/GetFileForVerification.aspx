<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="GetFileForVerification.aspx.cs" Inherits="Project_Leap_V3.frames.GetFileForVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function refreshParent() {
            window.parent.location.reload();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center" class="container">
        <article id="photo-item-1" class="sixteen columns feature-column">
            <h1>Verification</h1>
            <table>
                <tr>
                    <td>
                        <h3>Organisation Number:</h3>
                    </td>
                    <td>
                        <asp:Label ID="lblNum" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>Organisation Name:</h3>
                    </td>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>Contact number:</h3>
                    </td>
                    <td>
                        <asp:Label ID="lblCN" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Image ID="imgFile" runat="server" />
            <asp:Label ID="lblNoFile" runat="server" Text="No File was found!"></asp:Label>
        </article>
        <div class="sixteen columns">
            <asp:Button ID="btnDecVer" runat="server" Text="Decline Verification" OnClick="btnDecVer_Click" OnClientClick="return refreshParent();"/>
            <asp:Button ID="btnVerify" runat="server" Text="Verify" OnClick="btnVerify_Click" OnClientClick="return refreshParent();"/>
        </div>
        <div class="sixteen columns">
            <asp:Label ID="lblVerified" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
