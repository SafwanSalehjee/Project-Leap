<%@ Page Title="" Language="C#" MasterPageFile="~/Project_Leap_Master.Master" AutoEventWireup="true" CodeBehind="ReportPage.aspx.cs" Inherits="Project_Leap_V3.ReportPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center" class="container">
        <h1>Monthly NPO Registration</h1>
        <div class="eight columns">
            <div class="featured-image img-wrapper">
                <a href="images/Charts/g3.png" rel="prettyPhoto" class="img-link" title="Monthly NPO Registration">
                    <img src="images/Charts/g3.png" class="scale-with-grid" alt="Monthly NPO Registration" />
                    <div class="overlay zoom"></div>
                </a>
            </div>
        </div>
        <div class="eight columns">
            <table style="width: 100%; border: solid #ddd; border-width: 1px 1px 1px 1px; clear: both; margin: 10px 0 30px; height: 0;">
                <tr style="border-bottom: solid #ddd; border-bottom-width: 1px; clear: both; margin: 10px 0 30px; height: 0;">
                    <td style="border-right: solid #ddd; border-right-width: 1px; clear: both; margin: 10px 0 30px; height: 0;"></td>
                    <td>Week 1
                    </td>
                    <td>Week 2
                    </td>
                    <td>Week 3
                    </td>
                    <td>Week 4
                    </td>
                </tr>
                <tr>
                    <td style="border-right: solid #ddd; border-right-width: 1px; clear: both; margin: 10px 0 30px; height: 0;">January
                    </td>
                    <td>5
                    </td>
                    <td>4
                    </td>
                    <td>3
                    </td>
                    <td>8
                    </td>
                </tr>
                <tr>
                    <td style="border-right: solid #ddd; border-right-width: 1px; clear: both; margin: 10px 0 30px; height: 0;">February
                    </td>
                    <td>8
                    </td>
                    <td>10
                    </td>
                    <td>12
                    </td>
                    <td>32
                    </td>
                </tr>
                <tr>
                    <td style="border-right: solid #ddd; border-right-width: 1px; clear: both; margin: 10px 0 30px; height: 0;">March
                    </td>
                    <td>11
                    </td>
                    <td>15
                    </td>
                    <td>4
                    </td>
                    <td>6
                    </td>
                </tr>
                <tr>
                    <td style="border-right: solid #ddd; border-right-width: 1px; clear: both; margin: 10px 0 30px; height: 0;">April
                    </td>
                    <td>2
                    </td>
                    <td>3
                    </td>
                    <td>1
                    </td>
                    <td>0
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
