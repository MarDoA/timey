
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using timeLib;
using timey.Properties;
using Point = System.Drawing.Point;
using Rectangle = System.Drawing.Rectangle;
using TextBox = System.Windows.Forms.TextBox;

//to do: hours after stime e time edit
namespace timey
{
    public partial class Form2 : Form
    {
        bool newRow = false;
        employee emp;
        employee editEmp;
        int m;
        int y;
        public System.Data.DataTable dt = new System.Data.DataTable();

        List<employee> emps = sqlDataAccess.getEmployees();
        List<int> deletedTime = new List<int>();
        List<updateValue> updatedTime = new List<updateValue>();
        time newInsert = new time();

        private DateTimePicker dtp ;


        struct updateValue
        {
            public string valuename;
            public string value;
            public int id;
            public updateValue(string vn, string v, int i)
            {
                valuename = vn;
                value = v;
                id = i;
            }
        }

        public Form2()
        {
            InitializeComponent();
            dtp = new DateTimePicker();
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "hh:mm tt";
            dtp.ShowUpDown = true;
            dtp.Visible = false;
            dtp.KeyPress += new KeyPressEventHandler(dtp_KeyPress);
            dtp.CloseUp += new EventHandler(dtp_CloseUp);
            dtp.TextChanged += new EventHandler(dtp_TextChanged);
            dataGridView1.Controls.Add(dtp);

            dt.Columns.Add("Day", typeof(int));
            dt.Columns.Add("sTime", typeof(string));
            dt.Columns.Add("eTime", typeof(string));
            dt.Columns.Add("Hours", typeof(double));
            dt.Columns.Add("id", typeof(string));
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns[0].FillWeight = 15;
            dataGridView1.Columns[3].FillWeight = 15;
            dataGridView1.Columns[1].FillWeight = 35;
            dataGridView1.Columns[2].FillWeight = 35;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            yearCB.DataSource = Enumerable.Range(1950, 100).ToList();
            yearCB.SelectedIndex = yearCB.Items.IndexOf(DateTime.Now.Year);
            y = (int)yearCB.SelectedValue;

            monthCB.DataSource = Enumerable.Range(1, 12).ToList();
            monthCB.SelectedIndex = monthCB.Items.IndexOf(DateTime.Now.Month);
            m = (int)monthCB.SelectedValue;

            empList.DataSource = null;
            empList.DataSource = emps;
            empList.DisplayMember = "name";
            emp = (employee)empList.SelectedItem;
            codeLbl.Text = emp.code.ToString();

            empEditList.DataSource = null;
            empEditList.DataSource = new List<employee>(emps);
            empEditList.DisplayMember = "name";
            editEmp = (employee)empEditList.SelectedValue;
            editNameTB.Text = editEmp.name;
            editCodeTB.Text = editEmp.code.ToString();

            updateTable();
        }

        private void dtp_TextChanged(object? sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dtp.Text;
        }
        private void dtp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                dtp.Visible = false;
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                dtp.Visible = false;
            }
        }

        private void reFresh()
        {
            emps = sqlDataAccess.getEmployees();
            empList.DataSource = null;
            empList.DataSource = emps;
            empList.DisplayMember = "name";
            emp = (employee)empList.SelectedItem;
            codeLbl.Text = emp.code.ToString();

            empEditList.DataSource = null;
            empEditList.DataSource = new List<employee>(emps);
            empEditList.DisplayMember = "name";
            editEmp = (employee)empEditList.SelectedValue;
            editNameTB.Text = editEmp.name;
            editCodeTB.Text = editEmp.code.ToString();

            updateTable();
        }

        private void loadMonth(List<time> m)
        {
            dt.Rows.Clear();
            foreach (time item in m)
            {
                /*
                if (item.etime != null && item.etime != "")
                {
                    DateTime tempE = DateTime.Parse(item.etime);
                    item.etime = tempE.ToString("t");
                }
                */
                dt.Rows.Add(item.day, item.stime, item.etime, item.hours, item.id);
            }
        }
        private void updateTable()
        {
            List<time> thismonth = sqlDataAccess.loadTime(emp.code, y, m);
            totalHAmount.Text = sqlDataAccess.getTotalMonth(emp.code, m, y).ToString();
            loadMonth(thismonth);
        }

        private void monthCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            m = (int)monthCB.SelectedValue;
            updateTable();
        }

        private void yearCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            y = (int)yearCB.SelectedValue;
            updateTable();
        }

        private void empList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            emp = (employee)empList.SelectedItem;
            codeLbl.Text = emp.code.ToString();
            updateTable();
        }

        private void AddrecordBtn_Click(object sender, EventArgs e)
        {
            if (!newRow)
            {
                DataRow dr = dt.NewRow();
                dr[4] = "new";
                dt.Rows.Add(dr);
                newRow = true;
            }
            else
            {
                MessageBox.Show("Can't add more than one row at a time, save the new row first!");
            }
        }
        private void deleterecordBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                if (!string.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells["id"].Value as string))
                {
                    string idString = dataGridView1.SelectedRows[0].Cells["id"].Value as string;
                    if (idString == "new")
                    {
                        newRow = false;
                    }
                    else
                    {
                        deletedTime.Add(int.Parse(idString));
                    }
                }
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.FormattedValue as string))
            {
                string errorMessage = "";
                bool isError = false;
                updateValue uv = new updateValue();

                string testString = (string)e.FormattedValue;
                if (dataGridView1.CurrentCell.ColumnIndex == 0)
                {
                    errorMessage = "Days can only be a number from 1 to 31";
                    int numbTest;
                    if (int.TryParse(testString, out numbTest))
                    {
                        if (numbTest <= 0 || numbTest > 31)
                        {
                            isError = true;
                            errorMessage = "Maximum number of days is 31";
                        }
                        else
                        {
                            string idString = dataGridView1.Rows[e.RowIndex].Cells["id"].Value as string;
                            if (idString == "new")
                            {
                                newInsert.day = int.Parse((string)e.FormattedValue);
                            }
                            else
                            {
                                uv.id = int.Parse(idString);
                                uv.value = testString;
                                uv.valuename = "day";
                                updatedTime.Add(uv);
                            }
                        }
                    }
                    else
                    {
                        errorMessage = "Day can only be a number";
                        isError = true;
                    }
                }
                else if (dataGridView1.CurrentCell.ColumnIndex == 3)
                {
                    errorMessage = " ";
                    double numbTest;
                    if (!double.TryParse(testString, out numbTest))
                    {
                        errorMessage = "Hours can only be a number";
                        isError = true;
                    }
                    else
                    {
                        string idString = dataGridView1.Rows[e.RowIndex].Cells["id"].Value as string;
                        if (idString == "new")
                        {
                            newInsert.hours = double.Parse((string)e.FormattedValue);
                        }
                        else
                        {
                            uv.id = int.Parse(idString);
                            uv.value = e.FormattedValue.ToString();
                            uv.valuename = "hours";
                            updatedTime.Add(uv);
                        }
                    }
                }
                else if (dataGridView1.CurrentCell.ColumnIndex ==1 )
                {

                    string idString = dataGridView1.Rows[e.RowIndex].Cells["id"].Value as string;
                    if (idString == "new")
                    {
                        newInsert.stime = e.FormattedValue.ToString();
                    }
                    else
                    {
                        uv.id = int.Parse(idString);
                        uv.value = e.FormattedValue.ToString();
                        uv.valuename = "stime";
                        updatedTime.Add(uv);
                    }
                    if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex+1].Value != null 
                        || dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex + 1].Value.ToString()!="")
                    {                        
                        DateTime endTime,starttime = new DateTime();
                        starttime = DateTime.Parse(dataGridView1.CurrentCell.Value.ToString());
                        endTime = DateTime.Parse( dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex + 1].Value.ToString());

                        if (endTime<starttime)
                        {
                            endTime = endTime.AddDays(1);
                        }
                        
                        double hours;
                        hours = Math.Round((endTime-starttime).TotalHours, 2);

                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value = hours.ToString();

                        uv.id = int.Parse(idString);
                        uv.value = hours.ToString();
                        uv.valuename = "hours";
                        updatedTime.Add(uv);
                    }

                }
                else if (dataGridView1.CurrentCell.ColumnIndex ==2)
                {
                    string idString = dataGridView1.Rows[e.RowIndex].Cells["id"].Value as string;
                    if (idString == "new")
                    {
                        newInsert.stime = e.FormattedValue.ToString();
                    }
                    else
                    {
                        uv.id = int.Parse(idString);
                        uv.value = e.FormattedValue.ToString();
                        uv.valuename = "etime";
                        updatedTime.Add(uv);
                    }
                    if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex - 1].Value != null
                        || dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex -1].Value.ToString() != "")
                    {
                        DateTime endTime, starttime = new DateTime();
                        endTime = DateTime.Parse(dataGridView1.CurrentCell.Value.ToString());
                        starttime = DateTime.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex - 1].Value.ToString());

                        if (endTime < starttime)
                        {
                           endTime= endTime.AddDays(1);
                        }

                        double hours;
                        hours = Math.Round(( endTime - starttime).TotalHours, 2);

                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value = hours.ToString();


                        uv.id = int.Parse(idString);
                        uv.value = hours.ToString();
                        uv.valuename = "hours";
                        updatedTime.Add(uv);
                    }
                }
                if (isError)
                {
                    MessageBox.Show(errorMessage);
                    dataGridView1.CancelEdit();
                }
            }
            totalHAmount.Text = tempTotalHours().ToString();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            DeleteRecords(deletedTime);
            UpdateRecords(updatedTime);
            if (newRow)
            {
                newInsert.month = m;
                newInsert.year = y;
                if (newInsert.day != 0 && !string.IsNullOrEmpty(newInsert.stime))
                {
                    sqlDataAccess.InsertNewRecord(newInsert, emp.code);
                }
            }
        }

        private void UpdateRecords(List<updateValue> updatedTime)
        {
            foreach (updateValue item in updatedTime)
            {
                sqlDataAccess.updateRecord(item.id, item.valuename, item.value);
            }
        }

        private void DeleteRecords(List<int> deletedTime)
        {
            foreach (int item in deletedTime)
            {
                sqlDataAccess.deleteRecord(item);
            }
        }

        private void empEditList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            editEmp = (employee)empEditList.SelectedValue;
            editNameTB.Text = editEmp.name;
            editCodeTB.Text = editEmp.code.ToString();
        }

        private void editEmpBtn_Click(object sender, EventArgs e)
        {
            int editCode = int.Parse(editCodeTB.Text);
            bool dupCode = false;
            foreach (var em in emps)
            {
                if (editCode == em.code && editCode != editEmp.code)
                {
                    MessageBox.Show("code exists");
                    dupCode = true;
                    break;
                }
            }
            if (!dupCode)
            {
                employee edditedEmp = new employee();
                edditedEmp.name = editNameTB.Text;
                edditedEmp.code = int.Parse(editCodeTB.Text);
                sqlDataAccess.EditEmployee(edditedEmp, editEmp.code);

                reFresh();
            }
        }

        private void newEmpBtn_Click(object sender, EventArgs e)
        {
            int editCode = int.Parse(editCodeTB.Text);
            bool dupCode = false;
            foreach (var em in emps)
            {
                if (editCode == em.code)
                {
                    MessageBox.Show("code exists");
                    dupCode = true;
                    break;
                }
            }
            if (!dupCode)
            {
                employee newEmp = new employee();
                newEmp.name = editNameTB.Text;
                newEmp.code = int.Parse(editCodeTB.Text);
                sqlDataAccess.NewEmployee(newEmp);

                reFresh();
            }
        }

        private void editCodeTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void DayColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void HoursColumn_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(DayColumn_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(HoursColumn_KeyPress);
            //e.Control.KeyPress -= new KeyPressEventHandler(stop_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(DayColumn_KeyPress);
                }
            }
            else if (dataGridView1.CurrentCell.ColumnIndex == 3)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(HoursColumn_KeyPress);
                }

            }
            else if (dataGridView1.CurrentCell.ColumnIndex == 1 || dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                
                Rectangle rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, false);
                dtp.Size = new Size(rect.Width, rect.Height);
                dtp.Location = new Point(rect.X, rect.Y);
                dtp.Visible = true;
                if (!string.IsNullOrEmpty(dataGridView1.CurrentCell.Value.ToString()))
                {
                    dtp.Text = dataGridView1.CurrentCell.Value.ToString();
                }
                if (e.Control is DateTimePicker)
                {
                    // Attach a KeyDown event handler to the editing control
                }
            }
        }

        private void confirmpassBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordTB.Text))
            {
                string pass = passwordTB.Text;
                Settings.Default.password = pass;
                Settings.Default.Save();
                MessageBox.Show("new password is " + pass);
            }
        }
        private double tempTotalHours()
        {
            double total = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    try
                    {
                        total += Convert.ToDouble(item.Cells[3].Value.ToString());
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return Math.Round(total, 2);
        }

        private void dtp_CloseUp(object? sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dtp.Value;
            dtp.Visible = false;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }


        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==1||e.ColumnIndex==2)
            {                
                //dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtp.Text;
                dtp.Visible = false;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toExcelBTN_Click(object sender, EventArgs e)
        {
            List<time> shiftData = new List<time>();
            shiftData = sqlDataAccess.chartData(y, m);

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
                if (shift.etime != null && shift.stime !=null)
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
                            if (endMinute>0)
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
