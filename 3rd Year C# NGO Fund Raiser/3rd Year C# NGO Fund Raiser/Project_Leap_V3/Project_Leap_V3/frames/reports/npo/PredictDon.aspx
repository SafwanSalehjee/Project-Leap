<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="PredictDon.aspx.cs" Inherits="Project_Leap_V3.frames.reports.npo.PredictDon" %>
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

            var cVal = getCookie("threshold")

            if(cVal == "")
            {
                cVal = 0;
            }

            document.getElementById('thresholdTXT').value = cVal;

            for(var a = 0; a < amounts.length; a++)
            {
                buildArray[a] = [new Date(dates[a]), amounts[a], parseInt(cVal)];
            }
            var data = new google.visualization.DataTable();
            data.addColumn('date', 'Date');
            data.addColumn('number', 'Amount \nin Rand');
            data.addColumn('number', 'Threashold');

            data.addRows(buildArray);

            var chart = new google.visualization.AnnotationChart(document.getElementById('chart_div'));
            var table = new google.visualization.Table(document.getElementById('table_div'));

            var options = {
                displayAnnotations: true
            };

            csvString = google.visualization.dataTableToCsv(data);

            chart.draw(data, options);
            table.draw(data, {showRowNumber: true, width: '100%', height: '100%', 'allowHtml': true, 'cssClassNames': cssClassNames});
        }

        function downloadCSV()
        {
            var a         = document.createElement('a');
            a.href        = 'data:attachment/csv,' + csvString;
            a.target      = '_blank';
            a.download    = 'PredictedIncome.csv';

            document.body.appendChild(a);
            a.click();
        }

        function setThreshold()
        {
            var ThresholdVal = document.getElementById('thresholdTXT').value
            document.cookie="threshold=" + ThresholdVal;
            location.reload(); 
        }

        function getCookie(cname) {
            var name = cname + "=";
            var ca = document.cookie.split(';');
            for(var i=0; i<ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0)==' ') c = c.substring(1);
                if (c.indexOf(name) == 0) return c.substring(name.length,c.length);
            }
            return "";
        } 

        google.setOnLoadCallback(drawChart);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Estimate donations</h1>
    <div id='chart_div' style='width: 550px; height: 300px;'></div>
    Threshold: <input type="text" id="thresholdTXT"/>
    <button type="button" onclick="setThreshold()">Set threshold</button>
    <button type="button" onclick="downloadCSV()">Download as CSV</button><br>
    <div id="table_div"></div>
</asp:Content>
