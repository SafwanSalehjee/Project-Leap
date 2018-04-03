<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="TopDonBus.aspx.cs" Inherits="Project_Leap_V3.frames.reports.mixed.TopDonBus" %>
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

            var name = <%=new JavaScriptSerializer().Serialize(this.name) %>;
            var amount = <%=new JavaScriptSerializer().Serialize(this.amount) %>;
            var buildArray = [];
            for(var a = 0; a < amount.length; a++)
            {
                buildArray[a] = [name[a], amount[a]];
            }

            var data = google.visualization.arrayToDataTable([
                ['Name'],
            ]);

            data.addColumn('number', 'Amount\nin rand');

            data.addRows(buildArray);

            var options = {
                bar: {groupWidth: "95%"},
                legend: { position: "none" },
                colors: ['#2C88C9'],
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('columnchart_values'));

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
            a.download    = 'TopDonBus.csv';

            document.body.appendChild(a);
            a.click();
        }

        google.setOnLoadCallback(drawChart);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Top 10 donating businesses</h1>
    <div id="columnchart_values" style="width: 550px; height: 300px;"></div>
    <button type="button" onclick="downloadCSV()">Download as CSV</button>
    <div id="table_div"></div>
</asp:Content>
