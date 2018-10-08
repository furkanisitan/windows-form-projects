namespace HastaneYonetimRandevuSistemi.WinFormAppUI.DoctorForms
{
    partial class DoctorAddOrUpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorAddOrUpdateForm));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbPasswordAgain = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbTrIdentityNo = new System.Windows.Forms.MaskedTextBox();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblPasswordAgain = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lblTrIdentityNo = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.cbBranch = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(112, 194);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(145, 31);
            this.btnUpdate.TabIndex = 43;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tbPasswordAgain
            // 
            this.tbPasswordAgain.Location = new System.Drawing.Point(112, 163);
            this.tbPasswordAgain.Name = "tbPasswordAgain";
            this.tbPasswordAgain.Size = new System.Drawing.Size(145, 25);
            this.tbPasswordAgain.TabIndex = 41;
            this.tbPasswordAgain.UseSystemPasswordChar = true;
            this.tbPasswordAgain.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(112, 133);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(145, 25);
            this.tbPassword.TabIndex = 42;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // tbTrIdentityNo
            // 
            this.tbTrIdentityNo.Location = new System.Drawing.Point(112, 72);
            this.tbTrIdentityNo.Mask = "00000000000";
            this.tbTrIdentityNo.Name = "tbTrIdentityNo";
            this.tbTrIdentityNo.Size = new System.Drawing.Size(145, 25);
            this.tbTrIdentityNo.TabIndex = 39;
            this.tbTrIdentityNo.ValidatingType = typeof(int);
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(112, 42);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(145, 25);
            this.tbSurname.TabIndex = 38;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(112, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(145, 25);
            this.tbName.TabIndex = 37;
            // 
            // lblPasswordAgain
            // 
            this.lblPasswordAgain.AutoSize = true;
            this.lblPasswordAgain.Location = new System.Drawing.Point(23, 166);
            this.lblPasswordAgain.Name = "lblPasswordAgain";
            this.lblPasswordAgain.Size = new System.Drawing.Size(83, 18);
            this.lblPasswordAgain.TabIndex = 36;
            this.lblPasswordAgain.Text = "Şifre Tekrar :";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(65, 136);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(41, 18);
            this.lblPassword.TabIndex = 35;
            this.lblPassword.Text = "Şifre :";
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(50, 105);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(49, 18);
            this.lblBranch.TabIndex = 34;
            this.lblBranch.Text = "Branş :";
            // 
            // lblTrIdentityNo
            // 
            this.lblTrIdentityNo.AutoSize = true;
            this.lblTrIdentityNo.Location = new System.Drawing.Point(11, 75);
            this.lblTrIdentityNo.Name = "lblTrIdentityNo";
            this.lblTrIdentityNo.Size = new System.Drawing.Size(95, 18);
            this.lblTrIdentityNo.TabIndex = 33;
            this.lblTrIdentityNo.Text = "TC Kimlik No :";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(55, 45);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(51, 18);
            this.lblSurname.TabIndex = 32;
            this.lblSurname.Text = "Soyad :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(74, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(32, 18);
            this.lblName.TabIndex = 31;
            this.lblName.Text = "Ad :";
            // 
            // cbBranch
            // 
            this.cbBranch.FormattingEnabled = true;
            this.cbBranch.Location = new System.Drawing.Point(112, 102);
            this.cbBranch.Name = "cbBranch";
            this.cbBranch.Size = new System.Drawing.Size(145, 26);
            this.cbBranch.TabIndex = 44;
            // 
            // DoctorAddOrUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 234);
            this.Controls.Add(this.cbBranch);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tbPasswordAgain);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbTrIdentityNo);
            this.Controls.Add(this.tbSurname);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblPasswordAgain);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblTrIdentityNo);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "DoctorAddOrUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bilgileri Güncelle";
            this.Load += new System.EventHandler(this.DoctorAddOrUpdateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbPasswordAgain;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.MaskedTextBox tbTrIdentityNo;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblPasswordAgain;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label lblTrIdentityNo;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cbBranch;
    }
}