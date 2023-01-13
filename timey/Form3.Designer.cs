namespace timey
{
    partial class Form3
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
            this.lastloglbl = new System.Windows.Forms.Label();
            this.lastlogDateLbl = new System.Windows.Forms.Label();
            this.totalHlbl = new System.Windows.Forms.Label();
            this.checkoutBtn = new System.Windows.Forms.Button();
            this.totalHoursNum = new System.Windows.Forms.Label();
            this.checkinBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lastloglbl
            // 
            this.lastloglbl.AutoSize = true;
            this.lastloglbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lastloglbl.Location = new System.Drawing.Point(14, 12);
            this.lastloglbl.Name = "lastloglbl";
            this.lastloglbl.Size = new System.Drawing.Size(109, 28);
            this.lastloglbl.TabIndex = 0;
            this.lastloglbl.Text = "Last login:";
            this.lastloglbl.Click += new System.EventHandler(this.lastloglbl_Click);
            // 
            // lastlogDateLbl
            // 
            this.lastlogDateLbl.AutoSize = true;
            this.lastlogDateLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lastlogDateLbl.Location = new System.Drawing.Point(146, 12);
            this.lastlogDateLbl.Name = "lastlogDateLbl";
            this.lastlogDateLbl.Size = new System.Drawing.Size(79, 28);
            this.lastlogDateLbl.TabIndex = 0;
            this.lastlogDateLbl.Text = "<date>";
            this.lastlogDateLbl.Click += new System.EventHandler(this.label2_Click);
            // 
            // totalHlbl
            // 
            this.totalHlbl.AutoSize = true;
            this.totalHlbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.totalHlbl.Location = new System.Drawing.Point(14, 52);
            this.totalHlbl.Name = "totalHlbl";
            this.totalHlbl.Size = new System.Drawing.Size(235, 28);
            this.totalHlbl.TabIndex = 1;
            this.totalHlbl.Text = "Total Hours this month:";
            // 
            // checkoutBtn
            // 
            this.checkoutBtn.Enabled = false;
            this.checkoutBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkoutBtn.Location = new System.Drawing.Point(190, 108);
            this.checkoutBtn.Name = "checkoutBtn";
            this.checkoutBtn.Size = new System.Drawing.Size(100, 41);
            this.checkoutBtn.TabIndex = 2;
            this.checkoutBtn.Text = "Check Out";
            this.checkoutBtn.UseVisualStyleBackColor = true;
            this.checkoutBtn.Click += new System.EventHandler(this.checkoutBtn_Click);
            // 
            // totalHoursNum
            // 
            this.totalHoursNum.AutoSize = true;
            this.totalHoursNum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.totalHoursNum.Location = new System.Drawing.Point(255, 52);
            this.totalHoursNum.Name = "totalHoursNum";
            this.totalHoursNum.Size = new System.Drawing.Size(79, 28);
            this.totalHoursNum.TabIndex = 3;
            this.totalHoursNum.Text = "<num>";
            // 
            // checkinBtn
            // 
            this.checkinBtn.Enabled = false;
            this.checkinBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkinBtn.Location = new System.Drawing.Point(54, 108);
            this.checkinBtn.Name = "checkinBtn";
            this.checkinBtn.Size = new System.Drawing.Size(100, 41);
            this.checkinBtn.TabIndex = 2;
            this.checkinBtn.Text = "Check In ";
            this.checkinBtn.UseVisualStyleBackColor = true;
            this.checkinBtn.Click += new System.EventHandler(this.checkinBtn_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 185);
            this.Controls.Add(this.totalHoursNum);
            this.Controls.Add(this.checkinBtn);
            this.Controls.Add(this.checkoutBtn);
            this.Controls.Add(this.totalHlbl);
            this.Controls.Add(this.lastlogDateLbl);
            this.Controls.Add(this.lastloglbl);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lastloglbl;
        private Label lastlogDateLbl;
        private Label totalHlbl;
        private Button checkoutBtn;
        private Label totalHoursNum;
        private Button checkinBtn;
    }
}