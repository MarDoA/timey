using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using timeLib;

namespace timey
{
    public partial class Form3 : Form
    {
        private Form4 frm4;
        employee emp;
        time lr;
        public Form3(employee emp,Form4 frm4 )
        {
            InitializeComponent();
            this.frm4 = frm4;
            this.emp = emp;
            lr = sqlDataAccess.getlastRecord(emp.code);
            if (lr.etime != "" && lr.etime != null)
            {
                lastlogDateLbl.Text = lr.etime;
                lastloglbl.Text = "Last logout:";
                checkinBtn.Enabled = true;
            }
            else if(!string.IsNullOrEmpty(lr.stime))
            {
                lastlogDateLbl.Text = lr.stime;
                lastloglbl.Text = "Last login:";
                checkoutBtn.Enabled = true;
            }
            else
            {
                lastlogDateLbl.Text = "";
                lastloglbl.Text = "Welcome!!";
                checkinBtn.Enabled = true;
            }
            totalHoursNum.Text = sqlDataAccess.getTotalMonth(emp.code,DateTime.Now.Month,DateTime.Now.Year).ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void lastloglbl_Click(object sender, EventArgs e)
        {

        }

        private void checkinBtn_Click(object sender, EventArgs e)
        {
            time t = new time();
            DateTime tn = DateTime.Now;
            t.stime = tn.ToString("hh:mm tt");
            t.month = tn.Month;
            t.year = tn.Year;
            t.day = tn.Day;
            sqlDataAccess.insertStartTime(emp.code,t);
            MessageBox.Show("logged in at: " + t.stime);
            this.Close();
            if (frm4 != null)
            {
                frm4.Restart();
            }
        }

        private void checkoutBtn_Click(object sender, EventArgs e)
        {
            time t = new time();
            DateTime tn = DateTime.Now;
            t.etime = tn.ToString("hh:mm tt");
            t.month = lr.month;
            t.day = lr.day;
            t.year = lr.year;
            t.hours = Math.Round((tn - time.convertTimeToDateTime(lr,true)).TotalHours,2);
            sqlDataAccess.insertEndTime(t,lr.id);
            MessageBox.Show("looged out at: " + t.etime + " for a total of " + t.hours.ToString()+ " hours");
            this.Close();
            if (frm4 != null)
            {
                frm4.Restart();
            }
        }
    }
}
