namespace HastaneYonetimRandevuSistemi.WinFormAppUI.SecretaryForms
{
    partial class SecretaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecretaryForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.llblUpdate = new System.Windows.Forms.LinkLabel();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblTrIdentityNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnCreateAnnouncement = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.btnCreateAppointment = new System.Windows.Forms.Button();
            this.cbDoctors = new System.Windows.Forms.ComboBox();
            this.cbBranches = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnAnnouncements = new System.Windows.Forms.Button();
            this.btnDoctors = new System.Windows.Forms.Button();
            this.btnAppointment = new System.Windows.Forms.Button();
            this.btnBranches = new System.Windows.Forms.Button();
            this.cbHour = new System.Windows.Forms.ComboBox();
            this.cbMinute = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.llblUpdate);
            this.groupBox1.Controls.Add(this.lblFullName);
            this.groupBox1.Controls.Add(this.lblTrIdentityNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 112);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kişisel Bilgiler";
            // 
            // llblUpdate
            // 
            this.llblUpdate.AutoSize = true;
            this.llblUpdate.Location = new System.Drawing.Point(100, 86);
            this.llblUpdate.Name = "llblUpdate";
            this.llblUpdate.Size = new System.Drawing.Size(110, 18);
            this.llblUpdate.TabIndex = 2;
            this.llblUpdate.TabStop = true;
            this.llblUpdate.Text = "Bilgileri Güncelle";
            this.llblUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblUpdate_LinkClicked);
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(107, 58);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(59, 18);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "null null";
            // 
            // lblTrIdentityNo
            // 
            this.lblTrIdentityNo.AutoSize = true;
            this.lblTrIdentityNo.Location = new System.Drawing.Point(107, 28);
            this.lblTrIdentityNo.Name = "lblTrIdentityNo";
            this.lblTrIdentityNo.Size = new System.Drawing.Size(71, 18);
            this.lblTrIdentityNo.TabIndex = 0;
            this.lblTrIdentityNo.Text = "_________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ad Soyad :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "TC Kimlik No :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Controls.Add(this.btnCreateAnnouncement);
            this.groupBox2.Location = new System.Drawing.Point(12, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 191);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Duyuru Yayınla";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(9, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(201, 119);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // btnCreateAnnouncement
            // 
            this.btnCreateAnnouncement.Location = new System.Drawing.Point(6, 149);
            this.btnCreateAnnouncement.Name = "btnCreateAnnouncement";
            this.btnCreateAnnouncement.Size = new System.Drawing.Size(204, 33);
            this.btnCreateAnnouncement.TabIndex = 3;
            this.btnCreateAnnouncement.Text = "Oluştur";
            this.btnCreateAnnouncement.UseVisualStyleBackColor = true;
            this.btnCreateAnnouncement.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cbMinute);
            this.groupBox3.Controls.Add(this.cbHour);
            this.groupBox3.Controls.Add(this.dtpAppointmentDate);
            this.groupBox3.Controls.Add(this.btnCreateAppointment);
            this.groupBox3.Controls.Add(this.cbDoctors);
            this.groupBox3.Controls.Add(this.cbBranches);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(238, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(216, 191);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Randevu Paneli";
            // 
            // dtpAppointmentDate
            // 
            this.dtpAppointmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAppointmentDate.Location = new System.Drawing.Point(67, 24);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.Size = new System.Drawing.Size(135, 25);
            this.dtpAppointmentDate.TabIndex = 10;
            // 
            // btnCreateAppointment
            // 
            this.btnCreateAppointment.Enabled = false;
            this.btnCreateAppointment.Location = new System.Drawing.Point(67, 150);
            this.btnCreateAppointment.Name = "btnCreateAppointment";
            this.btnCreateAppointment.Size = new System.Drawing.Size(135, 30);
            this.btnCreateAppointment.TabIndex = 8;
            this.btnCreateAppointment.Text = "Kaydet";
            this.btnCreateAppointment.UseVisualStyleBackColor = true;
            this.btnCreateAppointment.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // cbDoctors
            // 
            this.cbDoctors.FormattingEnabled = true;
            this.cbDoctors.Location = new System.Drawing.Point(67, 118);
            this.cbDoctors.Name = "cbDoctors";
            this.cbDoctors.Size = new System.Drawing.Size(135, 26);
            this.cbDoctors.TabIndex = 5;
            this.cbDoctors.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // cbBranches
            // 
            this.cbBranches.FormattingEnabled = true;
            this.cbBranches.Location = new System.Drawing.Point(67, 86);
            this.cbBranches.Name = "cbBranches";
            this.cbBranches.Size = new System.Drawing.Size(135, 26);
            this.cbBranches.TabIndex = 4;
            this.cbBranches.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Doktor :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Branş :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Saat :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tarih :";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnAnnouncements);
            this.groupBox6.Controls.Add(this.btnDoctors);
            this.groupBox6.Controls.Add(this.btnAppointment);
            this.groupBox6.Controls.Add(this.btnBranches);
            this.groupBox6.Location = new System.Drawing.Point(238, 212);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(249, 109);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Hızlı Erişim";
            // 
            // btnAnnouncements
            // 
            this.btnAnnouncements.Location = new System.Drawing.Point(124, 59);
            this.btnAnnouncements.Name = "btnAnnouncements";
            this.btnAnnouncements.Size = new System.Drawing.Size(119, 29);
            this.btnAnnouncements.TabIndex = 10;
            this.btnAnnouncements.Text = "Duyurular";
            this.btnAnnouncements.UseVisualStyleBackColor = true;
            this.btnAnnouncements.Click += new System.EventHandler(this.btnQuickAccess_Click);
            // 
            // btnDoctors
            // 
            this.btnDoctors.Location = new System.Drawing.Point(10, 24);
            this.btnDoctors.Name = "btnDoctors";
            this.btnDoctors.Size = new System.Drawing.Size(108, 29);
            this.btnDoctors.TabIndex = 9;
            this.btnDoctors.Text = "Doktor Paneli";
            this.btnDoctors.UseVisualStyleBackColor = true;
            this.btnDoctors.Click += new System.EventHandler(this.btnQuickAccess_Click);
            // 
            // btnAppointment
            // 
            this.btnAppointment.Location = new System.Drawing.Point(124, 24);
            this.btnAppointment.Name = "btnAppointment";
            this.btnAppointment.Size = new System.Drawing.Size(119, 29);
            this.btnAppointment.TabIndex = 8;
            this.btnAppointment.Text = "Randevu Listesi";
            this.btnAppointment.UseVisualStyleBackColor = true;
            this.btnAppointment.Click += new System.EventHandler(this.btnQuickAccess_Click);
            // 
            // btnBranches
            // 
            this.btnBranches.Location = new System.Drawing.Point(10, 59);
            this.btnBranches.Name = "btnBranches";
            this.btnBranches.Size = new System.Drawing.Size(108, 29);
            this.btnBranches.TabIndex = 0;
            this.btnBranches.Text = "Branş Paneli";
            this.btnBranches.UseVisualStyleBackColor = true;
            this.btnBranches.Click += new System.EventHandler(this.btnQuickAccess_Click);
            // 
            // cbHour
            // 
            this.cbHour.FormattingEnabled = true;
            this.cbHour.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "13",
            "14",
            "15",
            "16"});
            this.cbHour.Location = new System.Drawing.Point(67, 55);
            this.cbHour.Name = "cbHour";
            this.cbHour.Size = new System.Drawing.Size(63, 26);
            this.cbHour.TabIndex = 11;
            // 
            // cbMinute
            // 
            this.cbMinute.FormattingEnabled = true;
            this.cbMinute.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cbMinute.Location = new System.Drawing.Point(140, 55);
            this.cbMinute.Name = "cbMinute";
            this.cbMinute.Size = new System.Drawing.Size(62, 26);
            this.cbMinute.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = ":";
            // 
            // SecretaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(499, 336);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SecretaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sekreter";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SecretaryForm_FormClosed);
            this.Load += new System.EventHandler(this.SecretaryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel llblUpdate;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblTrIdentityNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnCreateAnnouncement;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreateAppointment;
        private System.Windows.Forms.ComboBox cbDoctors;
        private System.Windows.Forms.ComboBox cbBranches;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnDoctors;
        private System.Windows.Forms.Button btnAppointment;
        private System.Windows.Forms.Button btnBranches;
        private System.Windows.Forms.DateTimePicker dtpAppointmentDate;
        private System.Windows.Forms.Button btnAnnouncements;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMinute;
        private System.Windows.Forms.ComboBox cbHour;
    }
}