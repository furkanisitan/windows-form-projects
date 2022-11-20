namespace WindowsShutdownUI
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOpr = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.lbtnCancel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // dtpTime
            // 
            this.dtpTime.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(13, 13);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(84, 25);
            this.dtpTime.TabIndex = 1;
            this.dtpTime.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTime.ValueChanged += new System.EventHandler(this.ChangedValueOrIndex);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "(sa: dk: sn)";
            // 
            // cbOpr
            // 
            this.cbOpr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOpr.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbOpr.FormattingEnabled = true;
            this.cbOpr.Items.AddRange(new object[] {
            "-- İşlem Seçin --",
            "Kapat",
            "Yeniden Başlat"});
            this.cbOpr.Location = new System.Drawing.Point(103, 13);
            this.cbOpr.Name = "cbOpr";
            this.cbOpr.Size = new System.Drawing.Size(122, 25);
            this.cbOpr.TabIndex = 0;
            this.cbOpr.SelectedIndexChanged += new System.EventHandler(this.ChangedValueOrIndex);
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnApply.Location = new System.Drawing.Point(144, 59);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Uygula";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lbtnCancel
            // 
            this.lbtnCancel.AutoSize = true;
            this.lbtnCancel.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbtnCancel.Location = new System.Drawing.Point(75, 40);
            this.lbtnCancel.Name = "lbtnCancel";
            this.lbtnCancel.Size = new System.Drawing.Size(150, 16);
            this.lbtnCancel.TabIndex = 3;
            this.lbtnCancel.TabStop = true;
            this.lbtnCancel.Text = "Zamanlanmış işlemi iptal et";
            this.lbtnCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtnCancel_LinkClicked);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(231, 93);
            this.Controls.Add(this.lbtnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbOpr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Shutdown UI";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbOpr;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.LinkLabel lbtnCancel;
    }
}

