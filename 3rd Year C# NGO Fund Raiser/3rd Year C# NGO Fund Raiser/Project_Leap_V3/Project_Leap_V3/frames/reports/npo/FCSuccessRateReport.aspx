<%@ Page Title="" Language="C#" MasterPageFile="~/frames/Frame.Master" AutoEventWireup="true" CodeBehind="FCSuccessRateReport.aspx.cs" Inherits="Project_Leap_V3.frames.reports.npo.FCSuccessRateReport" %>
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
        google.load("visualization", "1", {packages:["corechart"]});
        google.load("visualization", "1.1", {packages:["table"]});

        var csvString;

        function drawChart() {

           var cssClassNames = {
               'headerRow': 'large-font bold-font',
               'tableRow': '',
           };

          var successful = <%=new JavaScriptSerializer().Serialize(this.successful) %>;
          var notSuccessful = <%=new JavaScriptSerializer().Serialize(this.notSuccessful) %>;

          var data = google.visualization.arrayToDataTable([
            ['Success Rate', 'Percentage'],
            ['Successful', successful],
            ['Unsuccessful', notSuccessful],
          ]);

          var options = {
              pieHole: 0.4,
              slices: {
                  0: { color: '#2C88C9' },
                  1: { color: 'red' }
              }
          };

          var chart = new google.visualization.PieChart(document.getElementById('donutchart'));

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
            a.download    = 'FCSuccess.csv';

            document.body.appendChild(a);
            a.click();
        }

        google.setOnLoadCallback(drawChart);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Fundraising campaigns success percentage</h1>
    <div id="donutchart" style="width: 550px; height: 300px;"></div>
    <button type="button" onclick="downloadCSV()">Download as CSV</button>
    <div id="table_div"></div>
</asp:Content>
