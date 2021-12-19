using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Classes
{
    class Visualizer
    {
        /* Visualizing data
         * 
         */
            public void chart(Chart chart, string SeriesName, string[] x, int[] y, string chartType = "Column")
            {
                if (chart.Series[0].Name == "Series1")
                {
                    //remove default series
                    chart.Series.Remove(chart.Series["Series1"]);
                }
                //add new series
                chart.Series.Add(SeriesName);

                //chart Type
                switch (chartType)
                {
                    case "Area":
                        chart.Series[SeriesName].ChartType = SeriesChartType.Area;
                        break;
                    case "Bar":
                        chart.Series[SeriesName].ChartType = SeriesChartType.Bar;
                        break;
                    case "BoxPlot":
                        chart.Series[SeriesName].ChartType = SeriesChartType.BoxPlot;
                        break;
                    case "Bubble":
                        chart.Series[SeriesName].ChartType = SeriesChartType.Bubble;
                        break;
                    case "Candlestick":
                        chart.Series[SeriesName].ChartType = SeriesChartType.Candlestick;
                        break;
                    case "Doughnut":
                        chart.Series[SeriesName].ChartType = SeriesChartType.Doughnut;
                        break;
                    case "ErrorBar":
                        chart.Series[SeriesName].ChartType = SeriesChartType.ErrorBar;
                        break;
                    case "FastLine":
                        chart.Series[SeriesName].ChartType = SeriesChartType.FastLine;
                        break;
                    case "FastPoint":
                        chart.Series[SeriesName].ChartType = SeriesChartType.FastPoint;
                        break;
                    case "Funnel":
                        chart.Series[SeriesName].ChartType = SeriesChartType.Funnel;
                        break;
                    case "Kagi":
                        chart.Series[SeriesName].ChartType = SeriesChartType.Kagi;
                        break;
                    case "Line":
                        chart.Series[SeriesName].ChartType = SeriesChartType.Line;
                        break;
                    case "Pie":
                        chart.Series[SeriesName].ChartType = SeriesChartType.Pie;
                        break;
                    case "Point":
                        chart.Series[SeriesName].ChartType = SeriesChartType.Point;
                        break;
                    default:
                        chart.Series[SeriesName].ChartType = SeriesChartType.Column;
                        break;
                }

                int count = 0;
                //pass the legend & value
                foreach (string addx in x)
                {
                    chart.Series[SeriesName].Points.AddXY(addx, y[count]);
                    count++;
                }
            }
    }
}
