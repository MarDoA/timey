using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using timeLib;
using timey.Properties;

namespace timey
{
    public partial class Form2 : Form
    {
        bool newRow = false;
        employee emp;
        employee editEmp;
        int m;
        int y;
        public DataTable dt = new DataTable();

        List<employee> emps = sqlDataAccess.getEmployees();
        List<int> deletedTime = new List<int>();
        List<updateValue> updatedTime = new List<updateValue>();
        time newInsert = new time();

        DateTimePicker dtp = new DateTimePicker();


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

            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "hh:mm tt";
            dtp.ShowUpDown = true;
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
        //private void stop_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}
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
            //else if (dataGridView1.CurrentCell.ColumnIndex ==1|| dataGridView1.CurrentCell.ColumnIndex == 2)
            //{
            //    //TextBox tb = e.Control as TextBox;
            //    if (tb != null)
            //    {
            //        tb.KeyPress += new KeyPressEventHandler(stop_KeyPress);
            //    }
            //}
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
            dtp.Visible = false;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==1||e.ColumnIndex==2)
            {
                Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);             
                dtp.Size = new Size(rect.Width,rect.Height);
                dtp.Location = new Point(rect.X,rect.Y);
                if (!string.IsNullOrEmpty(dataGridView1.CurrentCell.Value.ToString()))
                {
                    dtp.Value = DateTime.Parse(dataGridView1.CurrentCell.Value.ToString());
                }
                dtp.Visible = true;
                dtp.Focus();
                dtp.Select();   
               
            }
            else
            {
                dtp.Visible = false;
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                e.Cancel = true;              
            }
            else
            {
                dtp.Visible = false;
            }
        }


        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dtp.Visible = false;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {


        }
    }
}
