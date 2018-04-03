<%@ Page Title="" Language="C#" MasterPageFile="~/Project_Leap_Master.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Project_Leap_V3.Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="sixteen columns">
            <div class="four columns">
                <h5>.</h5>
            </div>
            <div class="eight columns">
                <td>
                    <h2><i></i>Update information:</h2>
                </td>
                <hr />
                <asp:Label ID="lblFirstname" runat="server" Text="First Name:"></asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                <asp:Label ID="lblTitle" runat="server" Text="Title:"></asp:Label>
                <asp:DropDownList ID="ddlTitle" runat="server" Width="120px">
                    <asp:ListItem Text="Select Title" Value="Select"></asp:ListItem>
                    <asp:ListItem Text="Mr" Value="Mr"></asp:ListItem>
                    <asp:ListItem Text="Mrs" Value="Mrs"></asp:ListItem>
                    <asp:ListItem Text="Miss" Value="Miss"></asp:ListItem>
                    <asp:ListItem Text="Dr" Value="Dr"></asp:ListItem>
                    <asp:ListItem Text="Prof" Value="Prof"></asp:ListItem>
                    <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
                <asp:Table ID="tblGender" runat="server" Width="232px">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:RadioButtonList ID="rbGender" TextAlign="Left" runat="server" Width="197px" RepeatColumns="3" RepeatDirection="Horizontal" CellPadding="2">
                                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                            </asp:RadioButtonList>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <asp:Label ID="lblDOB" runat="server" Text="Date Of Birth:"></asp:Label>
                <table>
                    <tr>
                        <td>Day:</td>
                        <td></td>
                        <td>Month:</td>
                        <td>Year:</td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlDay1" runat="server" Width="55px" Style="margin-right: 5px;">
                                <asp:ListItem Text="" Value="Select"></asp:ListItem>
                                <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDay2" runat="server" Width="55px" Style="margin-right: 10px;">
                                <asp:ListItem Text="" Value="Select"></asp:ListItem>
                                <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMonth" runat="server" Width="55px" Style="margin-right: 10px;">
                                <asp:ListItem Text="" Value="Select"></asp:ListItem>
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
                            <asp:DropDownList ID="ddlYear1" runat="server" Width="55px" Style="margin-right: 5px;">
                                <asp:ListItem Text="" Value="Select"></asp:ListItem>
                                <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlYear2" runat="server" Width="55px" Style="margin-right: 5px;">
                                <asp:ListItem Text="" Value="Select"></asp:ListItem>
                                <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlYear3" runat="server" Width="55px">
                                <asp:ListItem Text="" Value="Select"></asp:ListItem>
                                <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblProv" runat="server" Text="Province:"></asp:Label>
                <asp:DropDownList ID="ddlProvince" runat="server" Width="130px">
                    <asp:ListItem Text="Select Province" Value="Select"></asp:ListItem>
                    <asp:ListItem Text="Eastern Cape" Value="Eastern Cape"></asp:ListItem>
                    <asp:ListItem Text="Free State" Value="Free State"></asp:ListItem>
                    <asp:ListItem Text="Gauteng" Value="Gauteng"></asp:ListItem>
                    <asp:ListItem Text="KwaZulu Natal" Value="KwaZulu Natal"></asp:ListItem>
                    <asp:ListItem Text="Limpopo" Value="Limpopo"></asp:ListItem>
                    <asp:ListItem Text="Mpumalanga" Value="Mpumalanga"></asp:ListItem>
                    <asp:ListItem Text="North West" Value="North West"></asp:ListItem>
                    <asp:ListItem Text="Northern Cape" Value="Northern Cape"></asp:ListItem>
                    <asp:ListItem Text="Western Cape" Value="Western Cape"></asp:ListItem>
                </asp:DropDownList>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblProfilePic" runat="server" Text="Profile Picture:"></asp:Label></td>
                        <td>
                            <asp:FileUpload ID="fileUpProfilePic" runat="server" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="imgUserPic" Width="150px" Height="150px" runat="server" ImageUrl="~/images/ina.jpg" /></td>
                    </tr>
                </table>

                <hr />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdata_Click" />
                <asp:Label ID="lblIsValid" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
