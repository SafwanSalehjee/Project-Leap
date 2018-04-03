<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="ComparableDons.aspx.cs" Inherits="Project_Leap_V3.frames.reports.npo.ComparableDons" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type='text/css'>
      .bold-font {
        font-weight: bold;
      }

      .large-font {
        font-size: 15px;
      }

      .text_al {
          text-align: right;
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
                'tableCell': 'text_al',
            };

            var dates = <%=new JavaScriptSerializer().Serialize(this.dates) %>;
            var amount = <%=new JavaScriptSerializer().Serialize(this.amount) %>;
            var buildArray = [];
            for(var a = 0; a < dates.length; a++)
            {
                buildArray[a] = [dates[a], amount[a]];
            }

            var data = google.visualization.arrayToDataTable([
                ['Year/Month']
            ]);

            data.addColumn('number', 'Amount in Rand');

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
            a.download    = 'NPOCompDons.csv';

            document.body.appendChild(a);
            a.click();
        }

        google.setOnLoadCallback(drawChart);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Donations Comparison</h1>
    <div>
        <asp:DropDownList ID="ddlUpdateChart" Style="border-radius: 0px;" Width="150px" CssClass="textBoxStyle" runat="server" AutoPostBack="true"></asp:DropDownList>
    </div>
    <div id="columnchart_values" style="width: 550px; height: 300px;"></div>
    <button type="button" onclick="downloadCSV()">Download as CSV</button>
    <div id="table_div"></div>
</asp:Content>
