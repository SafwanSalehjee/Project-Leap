<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="FundRaisingCampCurrent.aspx.cs" Inherits="Project_Leap_V3.frames.reports.npo.FundRaisingCampCurrent" %>
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
        google.load("visualization", "1", { packages: ["corechart"] });
        google.load("visualization", "1.1", {packages:["table"]});

        var csvString;

        function drawChart() {

            var cssClassNames = {
                'headerRow': 'large-font bold-font',
                'tableRow': '',
            };

            var title = <%=new JavaScriptSerializer().Serialize(this.title) %>;
            var percentage = <%=new JavaScriptSerializer().Serialize(this.percentage) %>;
            var buildArray = [];
            for(var a = 0; a < title.length; a++)
            {
                buildArray[a] = [title[a], percentage[a]];
            }

            var data = google.visualization.arrayToDataTable([
                ['Campaign name']
            ]);

            data.addColumn('number', 'Percentage Completed');

            data.addRows(buildArray);

            var options = {
                bar: {groupWidth: "95%"},
                legend: { position: "none" },
                colors: ['#2C88C9'],
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('columnchart_values'));
            var table = new google.visualization.Table(document.getElementById('table_div'));
            
            csvString = google.visualization.dataTableToCsv(data);
            
            chart.draw(data, options);
            table.draw(data, {showRowNumber: true, width: '100%', height: '100%', 'allowHtml': true, 'cssClassNames': cssClassNames});
        }

        function downloadCSV()
        {
            var a         = document.createElement('a');
            a.href        = 'data:attachment/csv,' + csvString;
            a.target      = '_blank';
            a.download    = 'FCCampCur.csv';

            document.body.appendChild(a);
            a.click();
        }

        google.setOnLoadCallback(drawChart);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Current fundraising campaigns progress</h1>
    <div id="columnchart_values" style="width: 550px; height: 300px;"></div>
    <button type="button" onclick="downloadCSV()">Download as CSV</button>
    <div id="table_div"></div>
</asp:Content>
