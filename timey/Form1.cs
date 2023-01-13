using timeLib;
using timey.Properties;

namespace timey
{
    public partial class Form1 : Form
    {
        List<employee> emps = sqlDataAccess.getEmployees();
        string password;
        int code;
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = null;
            comboBox1.DataSource = emps;
            comboBox1.DisplayMember = "name";
            password = Settings.Default.password;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                code = int.Parse(codeTB.Text);
            }
            catch (Exception)
            {
                
            }
            foreach (employee em in emps)
            {
                if (em.code== code)
                {
                    openCheckForm(em);                   
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            employee em = (employee)comboBox1.SelectedItem;
            openCheckForm(em);
        }
        private void openCheckForm(employee emp)
        {
            Form3 frm = new Form3(emp);
            frm.Text = emp.name;
            frm.Show();
        }

        private void codeTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                logBtnCode.PerformClick();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                logBtnList.PerformClick();
            }
        }

        private void Admin_click(object sender, EventArgs e)
        {
            if (passwordTB.Text == password)
            {
                Program.openAdminForm = true;
                this.Close();
            }
        }

        private void codeTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                adminBtn.PerformClick();
            }
        }
    }
}