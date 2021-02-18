/**
 * __________________________________________________________________
 *
 * C-Sharf Custom Classes
 * __________________________________________________________________
 *
 * MIT License
 * 
 * Copyright (c) 2020 Wilfred V. Pine
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 *
 * @package C-Sharf Custom Classes
 * @author Wilfred V. Pine <only.master.red@gmail.com>
 * @copyright Copyright 2020 (https://red.confired.com)
 * @link https://confired.com
 * @license https://opensource.org/licenses/MIT MIT License
 */

using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using C_Sharf_Classes.View;

namespace C_Sharf_Classes.Classes
{
    class UI_events
    {

        #region Form Events
            
            public void Show(Form frmNew, Form frmOld)
            {
                frmNew.Show();
                frmOld.Hide();
            }

            public void Dialog(Form frm)
            {
                frm.ShowDialog();
            }

            public void FormShow(Form frm, string dstyle = "Fill")
            {
                try
                {
                    foreach (Form child in frmMain.ActiveForm.MdiChildren)
                    {
                        child.Close();
                    }
                } catch { }

                frm.MdiParent = frmMain.formParent;
                switch (dstyle)
                {
                    case "Fill":
                        frm.Dock = DockStyle.Fill;
                        break;
                    case "Top":
                        frm.Dock = DockStyle.Top;
                        break;
                    case "Right":
                        frm.Dock = DockStyle.Right;
                        break;
                    case "Bottom":
                        frm.Dock = DockStyle.Bottom;
                        break;
                    case "Left":
                        frm.Dock = DockStyle.Left;
                        break;
                    default:
                        frm.Dock = DockStyle.None;
                        break;
                }
                frm.Show();
            }

        #endregion

        #region Data Visualization

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

        #endregion

    }
}
