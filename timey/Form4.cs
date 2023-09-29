using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using timeLib;

namespace timey
{
    public partial class Form4 : Form
    {
        List<employee> emps = sqlDataAccess.getEmployees();

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public Form4()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;

            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            List<int> ids = sqlDataAccess.getlastActive();
            List<string> names = new List<string>();
            names.Add("Logged in");
            if (ids != null)
                foreach (var id in ids)
                {
                    foreach (var x in emps)
                    {
                        if (x.code == id)
                        {
                            names.Add(x.name);
                            break;
                        }
                    }
                }
            label1.Text = string.Join(Environment.NewLine, names);
            int requiredHeight = TextRenderer.MeasureText(label1.Text, label1.Font).Height;
            this.ClientSize = new Size(label1.Width + 20, requiredHeight + 20);
            this.Location = new Point(workingArea.Right - this.Width, workingArea.Top);
            int initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x20);


        }
        public void Restart()
        {
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            List<int> ids = sqlDataAccess.getlastActive();
            List<string> names = new List<string>();
            names.Add("Logged in");
            if (ids != null)
                foreach (var id in ids)
                {
                    foreach (var x in emps)
                    {
                        if (x.code == id)
                        {
                            names.Add(x.name);
                            break;
                        }
                    }
                }
            label1.Text = string.Join(Environment.NewLine, names);
            int requiredHeight = TextRenderer.MeasureText(label1.Text, label1.Font).Height;
            this.ClientSize = new Size(label1.Width + 20, requiredHeight + 20);
            this.Location = new Point(workingArea.Right - this.Width, workingArea.Top);
            int initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x20);

        }
    }
}
