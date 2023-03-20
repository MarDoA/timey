using System.Data;

namespace timey
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveBtn = new System.Windows.Forms.Button();
            this.empEditList = new System.Windows.Forms.ComboBox();
            this.newEmpBtn = new System.Windows.Forms.Button();
            this.divider1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.empList = new System.Windows.Forms.ComboBox();
            this.codeLbl = new System.Windows.Forms.Label();
            this.editCodeTB = new System.Windows.Forms.TextBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.codLblfixed = new System.Windows.Forms.Label();
            this.totalHLbl = new System.Windows.Forms.Label();
            this.totalHAmount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editNameTB = new System.Windows.Forms.TextBox();
            this.editEmpBtn = new System.Windows.Forms.Button();
            this.monthCB = new System.Windows.Forms.ComboBox();
            this.yearCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.confirmpassBtn = new System.Windows.Forms.Button();
            this.AddrecordBtn = new System.Windows.Forms.Button();
            this.deleterecordBtn = new System.Windows.Forms.Button();
            this.toExcelBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(14, 16);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(374, 599);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellLeave);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(446, 249);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(112, 31);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // empEditList
            // 
            this.empEditList.FormattingEnabled = true;
            this.empEditList.Location = new System.Drawing.Point(395, 334);
            this.empEditList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.empEditList.Name = "empEditList";
            this.empEditList.Size = new System.Drawing.Size(138, 28);
            this.empEditList.TabIndex = 7;
            this.empEditList.SelectionChangeCommitted += new System.EventHandler(this.empEditList_SelectionChangeCommitted);
            // 
            // newEmpBtn
            // 
            this.newEmpBtn.Location = new System.Drawing.Point(504, 442);
            this.newEmpBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.newEmpBtn.Name = "newEmpBtn";
            this.newEmpBtn.Size = new System.Drawing.Size(86, 31);
            this.newEmpBtn.TabIndex = 11;
            this.newEmpBtn.Text = "New";
            this.newEmpBtn.UseVisualStyleBackColor = true;
            this.newEmpBtn.Click += new System.EventHandler(this.newEmpBtn_Click);
            // 
            // divider1
            // 
            this.divider1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider1.Location = new System.Drawing.Point(398, 295);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(206, 3);
            this.divider1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(395, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 28);
            this.label2.TabIndex = 10;
            this.label2.Text = "Edit emp";
            // 
            // empList
            // 
            this.empList.FormattingEnabled = true;
            this.empList.Location = new System.Drawing.Point(394, 127);
            this.empList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.empList.Name = "empList";
            this.empList.Size = new System.Drawing.Size(138, 28);
            this.empList.TabIndex = 3;
            this.empList.SelectionChangeCommitted += new System.EventHandler(this.empList_SelectionChangeCommitted);
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.codeLbl.Location = new System.Drawing.Point(539, 128);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(74, 23);
            this.codeLbl.TabIndex = 7;
            this.codeLbl.Text = "<Code>";
            // 
            // editCodeTB
            // 
            this.editCodeTB.Location = new System.Drawing.Point(539, 395);
            this.editCodeTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editCodeTB.Name = "editCodeTB";
            this.editCodeTB.Size = new System.Drawing.Size(62, 27);
            this.editCodeTB.TabIndex = 9;
            this.editCodeTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editCodeTB_KeyPress);
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(395, 371);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(49, 20);
            this.nameLbl.TabIndex = 12;
            this.nameLbl.Text = "Name";
            // 
            // codLblfixed
            // 
            this.codLblfixed.AutoSize = true;
            this.codLblfixed.Location = new System.Drawing.Point(539, 371);
            this.codLblfixed.Name = "codLblfixed";
            this.codLblfixed.Size = new System.Drawing.Size(44, 20);
            this.codLblfixed.TabIndex = 12;
            this.codLblfixed.Text = "Code";
            // 
            // totalHLbl
            // 
            this.totalHLbl.AutoSize = true;
            this.totalHLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.totalHLbl.Location = new System.Drawing.Point(393, 161);
            this.totalHLbl.Name = "totalHLbl";
            this.totalHLbl.Size = new System.Drawing.Size(116, 25);
            this.totalHLbl.TabIndex = 13;
            this.totalHLbl.Text = "Total hours:";
            // 
            // totalHAmount
            // 
            this.totalHAmount.AutoSize = true;
            this.totalHAmount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.totalHAmount.Location = new System.Drawing.Point(497, 161);
            this.totalHAmount.Name = "totalHAmount";
            this.totalHAmount.Size = new System.Drawing.Size(104, 25);
            this.totalHAmount.TabIndex = 13;
            this.totalHAmount.Text = "<number>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(395, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Name";
            // 
            // editNameTB
            // 
            this.editNameTB.Location = new System.Drawing.Point(395, 395);
            this.editNameTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editNameTB.Name = "editNameTB";
            this.editNameTB.Size = new System.Drawing.Size(138, 27);
            this.editNameTB.TabIndex = 8;
            // 
            // editEmpBtn
            // 
            this.editEmpBtn.Location = new System.Drawing.Point(402, 442);
            this.editEmpBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editEmpBtn.Name = "editEmpBtn";
            this.editEmpBtn.Size = new System.Drawing.Size(86, 31);
            this.editEmpBtn.TabIndex = 10;
            this.editEmpBtn.Text = "Edit";
            this.editEmpBtn.UseVisualStyleBackColor = true;
            this.editEmpBtn.Click += new System.EventHandler(this.editEmpBtn_Click);
            // 
            // monthCB
            // 
            this.monthCB.FormattingEnabled = true;
            this.monthCB.Location = new System.Drawing.Point(395, 28);
            this.monthCB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.monthCB.Name = "monthCB";
            this.monthCB.Size = new System.Drawing.Size(99, 28);
            this.monthCB.TabIndex = 1;
            this.monthCB.SelectionChangeCommitted += new System.EventHandler(this.monthCB_SelectionChangeCommitted);
            // 
            // yearCB
            // 
            this.yearCB.FormattingEnabled = true;
            this.yearCB.Location = new System.Drawing.Point(514, 28);
            this.yearCB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.yearCB.Name = "yearCB";
            this.yearCB.Size = new System.Drawing.Size(95, 28);
            this.yearCB.TabIndex = 2;
            this.yearCB.SelectionChangeCommitted += new System.EventHandler(this.yearCB_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(397, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "month";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(514, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "year";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(398, 488);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 3);
            this.label6.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(393, 496);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 28);
            this.label7.TabIndex = 10;
            this.label7.Text = "Admin Password";
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(394, 555);
            this.passwordTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(206, 27);
            this.passwordTB.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(394, 531);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "new password";
            // 
            // confirmpassBtn
            // 
            this.confirmpassBtn.Location = new System.Drawing.Point(465, 589);
            this.confirmpassBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.confirmpassBtn.Name = "confirmpassBtn";
            this.confirmpassBtn.Size = new System.Drawing.Size(86, 31);
            this.confirmpassBtn.TabIndex = 13;
            this.confirmpassBtn.Text = "Confirm";
            this.confirmpassBtn.UseVisualStyleBackColor = true;
            this.confirmpassBtn.Click += new System.EventHandler(this.confirmpassBtn_Click);
            // 
            // AddrecordBtn
            // 
            this.AddrecordBtn.Location = new System.Drawing.Point(402, 202);
            this.AddrecordBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddrecordBtn.Name = "AddrecordBtn";
            this.AddrecordBtn.Size = new System.Drawing.Size(86, 31);
            this.AddrecordBtn.TabIndex = 4;
            this.AddrecordBtn.Text = "Add";
            this.AddrecordBtn.UseVisualStyleBackColor = true;
            this.AddrecordBtn.Click += new System.EventHandler(this.AddrecordBtn_Click);
            // 
            // deleterecordBtn
            // 
            this.deleterecordBtn.Location = new System.Drawing.Point(503, 202);
            this.deleterecordBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleterecordBtn.Name = "deleterecordBtn";
            this.deleterecordBtn.Size = new System.Drawing.Size(86, 31);
            this.deleterecordBtn.TabIndex = 5;
            this.deleterecordBtn.Text = "Delete";
            this.deleterecordBtn.UseVisualStyleBackColor = true;
            this.deleterecordBtn.Click += new System.EventHandler(this.deleterecordBtn_Click);
            // 
            // toExcelBTN
            // 
            this.toExcelBTN.Location = new System.Drawing.Point(446, 63);
            this.toExcelBTN.Name = "toExcelBTN";
            this.toExcelBTN.Size = new System.Drawing.Size(120, 29);
            this.toExcelBTN.TabIndex = 18;
            this.toExcelBTN.Text = "Month to Chart";
            this.toExcelBTN.UseVisualStyleBackColor = true;
            this.toExcelBTN.Click += new System.EventHandler(this.toExcelBTN_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 628);
            this.Controls.Add(this.toExcelBTN);
            this.Controls.Add(this.deleterecordBtn);
            this.Controls.Add(this.AddrecordBtn);
            this.Controls.Add(this.confirmpassBtn);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yearCB);
            this.Controls.Add(this.monthCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalHAmount);
            this.Controls.Add(this.totalHLbl);
            this.Controls.Add(this.codLblfixed);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.editNameTB);
            this.Controls.Add(this.editCodeTB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.divider1);
            this.Controls.Add(this.editEmpBtn);
            this.Controls.Add(this.newEmpBtn);
            this.Controls.Add(this.codeLbl);
            this.Controls.Add(this.empList);
            this.Controls.Add(this.empEditList);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.dataGridView1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView dataGridView1;
        private Button saveBtn;
        private ComboBox empEditList;
        private Button newEmpBtn;
        private Label divider1;
        private Label label2;
        private ComboBox empList;
        private Label codeLbl;
        private TextBox editCodeTB;
        private Label nameLbl;
        private Label codLblfixed;
        private Label totalHLbl;
        private Label totalHAmount;
        private Label label1;
        private TextBox editNameTB;
        private Button editEmpBtn;
        private ComboBox monthCB;
        private ComboBox yearCB;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox passwordTB;
        private Label label9;
        private Button confirmpassBtn;
        private Button AddrecordBtn;
        private Button deleterecordBtn;
        private Button toExcelBTN;
    }
}