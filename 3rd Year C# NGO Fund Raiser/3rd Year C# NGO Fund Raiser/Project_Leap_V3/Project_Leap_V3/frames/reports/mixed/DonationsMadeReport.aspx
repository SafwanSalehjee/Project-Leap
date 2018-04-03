<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="DonationsMadeReport.aspx.cs" Inherits="Project_Leap_V3.frames.reports.mixed.DonationsMadeReport" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type='text/css'>
      .bold-font {
        font-weight: bold;
      }

      .large-font {
        font-size: 15px;
      }
    </style>

    <script type="text/javascript">
        google.load('visualization', '1', { 'packages': ['annotationchart'] });
       
        var csvString;

        function drawChart() {

            var cssClassNames = {
                'headerRow': 'large-font bold-font',
                'tableRow': '',
            };

            var dates = <%=new JavaScriptSerializer().Serialize(this.dates) %>;
            var amounts = <%=new JavaScriptSerializer().Serialize(this.amounts) %>;
            var buildArray = [];
            for(var a = 0; a < amounts.length; a++)
            {
                buildArray[a] = [new Date(dates[a]), amounts[a]];
            }
            var data = new google.visualization.DataTable();
            data.addColumn('date', 'Date');
            data.addColumn('number', 'Amount \nin Rand');

            data.addRows(buildArray);

            var chart = new google.visualization.AnnotationChart(document.getElementById('chart_div'));

            var options = {
                displayAnnotations: true
            };

            csvString = google.visualization.dataTableToCsv(data);

            chart.draw(data, options);

            var table = new google.visualization.Table(document.getElementById('table_div'));
            table.draw(data, {showRowNumber: true, width: '100%', height: '100%', 'allowHtml': true, 'cssClassNames': cssClassNames});
        }

        function downloadCSV()
        {
            var a         = document.createElement('a');
            a.href        = 'data:attachment/csv,' + csvString;
            a.target      = '_blank';
            a.download    = 'DonsMade.csv';

            document.body.appendChild(a);
            a.click();
        }

        google.setOnLoadCallback(drawChart);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Donations made by you</h1>
    <div id='chart_div' style='width: 550px; height: 300px;'></div>
    <button type="button" onclick="downloadCSV()">Download as CSV</button>
    <div id="table_div"></div>
</asp:Content>
