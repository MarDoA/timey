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
            this.logBtnCode.Location = new System.Drawing.Point(161, 38);
            this.logBtnCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logBtnCode.Name = "logBtnCode";
            this.logBtnCode.Size = new System.Drawing.Size(69, 23);
            this.logBtnCode.TabIndex = 0;
            this.logBtnCode.Text = "log in";
            this.logBtnCode.UseVisualStyleBackColor = true;
            this.logBtnCode.Click += new System.EventHandler(this.button1_Click);
            // 
            // adminBtn
            // 
            this.adminBtn.Location = new System.Drawing.Point(10, 123);
            this.adminBtn.Name = "adminBtn";
            this.adminBtn.Size = new System.Drawing.Size(75, 24);
            this.adminBtn.TabIndex = 3;
            this.adminBtn.Text = "Admin";
            this.adminBtn.UseVisualStyleBackColor = true;
            this.adminBtn.Click += new System.EventHandler(this.Admin_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter code";
            // 
            // codeTB
            // 
            this.codeTB.Location = new System.Drawing.Point(10, 38);
            this.codeTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.codeTB.Name = "codeTB";
            this.codeTB.Size = new System.Drawing.Size(141, 23);
            this.codeTB.TabIndex = 1;
            this.codeTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codeTB_KeyDown);
            this.codeTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codeTB_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(70, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "OR";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 90);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(141, 23);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // logBtnList
            // 
            this.logBtnList.Location = new System.Drawing.Point(161, 90);
            this.logBtnList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logBtnList.Name = "logBtnList";
            this.logBtnList.Size = new System.Drawing.Size(69, 23);
            this.logBtnList.TabIndex = 0;
            this.logBtnList.Text = "log in";
            this.logBtnList.UseVisualStyleBackColor = true;
            this.logBtnList.Click += new System.EventHandler(this.button2_Click);
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(91, 125);
            this.passwordTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '*';
            this.passwordTB.Size = new System.Drawing.Size(140, 23);
            this.passwordTB.TabIndex = 5;
            this.passwordTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 159);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.adminBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codeTB);
            this.Controls.Add(this.logBtnList);
            this.Controls.Add(this.logBtnCode);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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