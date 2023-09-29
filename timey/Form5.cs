using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using timeLib;

namespace timey
{
    public partial class Form5 : Form
    {
        List<employee> emps = sqlDataAccess.getEmployees();
        int y;
        int m;
        public Form5(int _y, int _m)
        {
            y = _y;
            m = _m;

            InitializeComponent();

            foreach (var e in emps)
            {
                checkedListBox1.Items.Add(e);
                
            }
            checkedListBox1.DisplayMember = "name";
            checkedListBox1.ValueMember = "code";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count != 0)
            { 
                List<int> cods = new List<int>();
               
                foreach (employee ito in checkedListBox1.CheckedItems)
                {
                   cods.Add(ito.code);
                }

                List<time> shiftData = new List<time>();
                var ids = string.Join(",", cods.Select(x => x.ToString()).ToArray());
                shiftData = sqlDataAccess.chartData(y, m,ids);

                Form chartForm = new Form();
                chartForm.Text = "Bar Chart";
                chartForm.Width = 1000;
                chartForm.Height = 1000;

                // Create a chart control and add it to the form
                Chart chart1 = new Chart();
                chart1.Dock = DockStyle.Fill;
                chartForm.Controls.Add(chart1);

                // Clear the chart
                chart1.Series.Clear();

                // Set up chart properties
                chart1.ChartAreas.Add("MainChartArea");
                chart1.ChartAreas["MainChartArea"].AxisY.Interval = 1;
                chart1.ChartAreas["MainChartArea"].AxisY.Minimum = 0;
                chart1.ChartAreas["MainChartArea"].AxisY.Maximum = 23;
                chart1.ChartAreas["MainChartArea"].AxisY.MajorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas["MainChartArea"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
                chart1.ChartAreas["MainChartArea"].AxisX.Minimum = 1;
                chart1.ChartAreas["MainChartArea"].AxisX.Maximum = 31;
                chart1.ChartAreas["MainChartArea"].AxisX.Interval = 1;
                chart1.ChartAreas["MainChartArea"].AxisX.MajorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas["MainChartArea"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

                // Group the data by day of month
                var data = new List<List<Tuple<string, DateTime, DateTime>>>();
                for (int i = 0; i < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
                {
                    data.Add(new List<Tuple<string, DateTime, DateTime>>());
                }

                foreach (var shift in shiftData)
                {
                    if (shift.etime != null && shift.stime != null)
                    {
                        var dayOfMonth = shift.day;
                        var year = shift.year;
                        var startTime = DateTime.ParseExact(shift.stime, "hh:mm tt", CultureInfo.InvariantCulture);
                        var endTime = DateTime.ParseExact(shift.etime, "hh:mm tt", CultureInfo.InvariantCulture);
                        if (endTime < startTime)// shift ends next day
                        {
                            // Split shift into two: one until midnight, and another from midnight until end time
                            var firstShiftEndTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 23, 59, 59);
                            var secondShiftStartTime = new DateTime(endTime.Year, endTime.Month, endTime.Day, 0, 0, 0);
                            var firstShiftDuration = firstShiftEndTime - startTime;
                            var secondShiftDuration = endTime - secondShiftStartTime;

                            data[dayOfMonth - 1].Add(Tuple.Create(shift.name, startTime, firstShiftEndTime));
                            data[dayOfMonth].Add(Tuple.Create(shift.name, secondShiftStartTime, endTime));
                        }
                        else
                        {
                            data[dayOfMonth - 1].Add(Tuple.Create(shift.name, startTime, endTime));

                        }
                    }
                }

                // Create a new series for each employee
                var employeeNames = shiftData.Select(x => x.name).Distinct();
                foreach (var employeeName in employeeNames)
                {
                    var series = new Series(employeeName);
                    series.ChartType = SeriesChartType.RangeBar;
                    series.BorderColor = Color.Black;
                    series.BorderWidth = 1;

                    // Add shift data to each series
                    for (int i = 0; i < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
                    {
                        var dayData = data[i].Where(x => x.Item1 == employeeName);
                        if (dayData.Any())
                        {
                            foreach (var shift in dayData)
                            {
                                var start = shift.Item2;
                                var end = shift.Item3;
                                var duration = end - start;
                                var startHour = start.Hour;
                                var endHour = end.Hour;
                                var endMinute = end.Minute;
                                var endY = endHour;
                                if (endMinute > 0)
                                {
                                    endY += endMinute / 60;
                                }

                                // Add data
                                var point = new DataPoint();
                                point.SetValueXY(i + 1, startHour, endY);
                                series.Points.Add(point);
                            }
                        }
                    }

                    // Add the series to the chart
                    chart1.Series.Add(series);
                }


                // Add a legend for the employees
                var legend = new Legend("Employees");
                chart1.Legends.Add(legend);
                foreach (var series in chart1.Series)
                {
                    series.Legend = "Employees";
                    series.IsVisibleInLegend = true;
                }


                chartForm.ShowDialog();

            }
        }
    }
}
