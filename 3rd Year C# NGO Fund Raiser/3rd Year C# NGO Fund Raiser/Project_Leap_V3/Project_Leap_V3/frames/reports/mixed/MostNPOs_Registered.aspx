<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="MostNPOs_Registered.aspx.cs" Inherits="Project_Leap_V3.frames.reports.mixed.MostNPOs_Registered" %>
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
        google.load("visualization", "1", { packages: ["geochart"] });
        google.load("visualization", "1.1", {packages:["table"]});
        
        var csvString;

        function drawRegionsMap() {

            var cssClassNames = {
                'headerRow': 'large-font bold-font',
                'tableRow': '',
            };

            var code = <%=new JavaScriptSerializer().Serialize(this.arrC) %> ;
            var text = <%=new JavaScriptSerializer().Serialize(this.arrP) %> ;
            var value = <%=new JavaScriptSerializer().Serialize(this.arrV) %> ;

            //We need to combine the different arrays to add it as rows
            var buildArray = [];
            for(var a = 0; a < code.length; a++)
            {
                buildArray[a] = [code[a], text[a], value[a]];
            }

            var data = google.visualization.arrayToDataTable([
                ['Province', 'Text']
            ]);

            //We need this to add numbers to the chart
            data.addColumn('number', 'Num');
            
            //Add the entire array we build up
            data.addRows(buildArray);

            var options = {
                region: 'ZA',
                displayMode: 'regions',
                resolution: 'provinces',
                colorAxis: {colors: ['#2C88C9']}
            };

            var chart = new google.visualization.GeoChart(document.getElementById('regions_div'));

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
            a.download    = 'MostNPOReg.csv';

            document.body.appendChild(a);
            a.click();
        }

        google.setOnLoadCallback(drawRegionsMap);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Organisations across South Africa</h1>
    <div id="regions_div" style="width: 575px; height: 500px;"></div>
    <button type="button" onclick="downloadCSV()">Download as CSV</button>
    <div id="table_div"></div>
</asp:Content>
