namespace timey
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logBtnCode = new System.Windows.Forms.Button();
            this.adminBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.codeTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.logBtnList = new System.Windows.Forms.Button();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // logBtnCode
            // 
            this.logBtnCode.Location = new System.Drawing.Point(184, 51);
            this.logBtnCode.Name = "logBtnCode";
            this.logBtnCode.Size = new System.Drawing.Size(79, 31);
            this.logBtnCode.TabIndex = 0;
            this.logBtnCode.Text = "log in";
            this.logBtnCode.UseVisualStyleBackColor = true;
            this.logBtnCode.Click += new System.EventHandler(this.button1_Click);
            // 
            // adminBtn
            // 
            this.adminBtn.Location = new System.Drawing.Point(11, 164);
            this.adminBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.adminBtn.Name = "adminBtn";
            this.adminBtn.Size = new System.Drawing.Size(86, 32);
            this.adminBtn.TabIndex = 3;
            this.adminBtn.Text = "Admin";
            this.adminBtn.UseVisualStyleBackColor = true;
            this.adminBtn.Click += new System.EventHandler(this.Admin_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter code";
            // 
            // codeTB
            // 
            this.codeTB.Location = new System.Drawing.Point(11, 51);
            this.codeTB.Name = "codeTB";
            this.codeTB.Size = new System.Drawing.Size(161, 27);
            this.codeTB.TabIndex = 1;
            this.codeTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codeTB_KeyDown);
            this.codeTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codeTB_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(80, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "OR";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(11, 120);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 28);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // logBtnList
            // 
            this.logBtnList.Location = new System.Drawing.Point(184, 120);
            this.logBtnList.Name = "logBtnList";
            this.logBtnList.Size = new System.Drawing.Size(79, 31);
            this.logBtnList.TabIndex = 0;
            this.logBtnList.Text = "log in";
            this.logBtnList.UseVisualStyleBackColor = true;
            this.logBtnList.Click += new System.EventHandler(this.button2_Click);
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(104, 167);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '*';
            this.passwordTB.Size = new System.Drawing.Size(159, 27);
            this.passwordTB.TabIndex = 5;
            this.passwordTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 212);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.adminBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codeTB);
            this.Controls.Add(this.logBtnList);
            this.Controls.Add(this.logBtnCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button logBtnCode;
        private Button adminBtn;
        private Label label1;
        private TextBox codeTB;
        private Label label2;
        private ComboBox comboBox1;
        private Button logBtnList;
        private TextBox passwordTB;
    }
}