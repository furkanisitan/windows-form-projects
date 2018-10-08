namespace HastaneYonetimRandevuSistemi.WinFormAppUI.SecretaryForms
{
    partial class SecretaryUpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecretaryUpdateForm));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbPasswordAgain = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbTrIdentityNo = new System.Windows.Forms.MaskedTextBox();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblPasswordAgain = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblTrIdentityNo = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(107, 167);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(145, 31);
            this.btnUpdate.TabIndex = 56;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tbPasswordAgain
            // 
            this.tbPasswordAgain.Location = new System.Drawing.Point(107, 136);
            this.tbPasswordAgain.Name = "tbPasswordAgain";
            this.tbPasswordAgain.Size = new System.Drawing.Size(145, 25);
            this.tbPasswordAgain.TabIndex = 54;
            this.tbPasswordAgain.UseSystemPasswordChar = true;
            this.tbPasswordAgain.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(107, 106);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(145, 25);
            this.tbPassword.TabIndex = 55;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // tbTrIdentityNo
            // 
            this.tbTrIdentityNo.Location = new System.Drawing.Point(107, 75);
            this.tbTrIdentityNo.Mask = "00000000000";
            this.tbTrIdentityNo.Name = "tbTrIdentityNo";
            this.tbTrIdentityNo.Size = new System.Drawing.Size(145, 25);
            this.tbTrIdentityNo.TabIndex = 53;
            this.tbTrIdentityNo.ValidatingType = typeof(int);
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(107, 45);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(145, 25);
            this.tbSurname.TabIndex = 52;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(107, 15);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(145, 25);
            this.tbName.TabIndex = 51;
            // 
            // lblPasswordAgain
            // 
            this.lblPasswordAgain.AutoSize = true;
            this.lblPasswordAgain.Location = new System.Drawing.Point(18, 139);
            this.lblPasswordAgain.Name = "lblPasswordAgain";
            this.lblPasswordAgain.Size = new System.Drawing.Size(83, 18);
            this.lblPasswordAgain.TabIndex = 50;
            this.lblPasswordAgain.Text = "Şifre Tekrar :";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(60, 109);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(41, 18);
            this.lblPassword.TabIndex = 49;
            this.lblPassword.Text = "Şifre :";
            // 
            // lblTrIdentityNo
            // 
            this.lblTrIdentityNo.AutoSize = true;
            this.lblTrIdentityNo.Location = new System.Drawing.Point(6, 78);
            this.lblTrIdentityNo.Name = "lblTrIdentityNo";
            this.lblTrIdentityNo.Size = new System.Drawing.Size(95, 18);
            this.lblTrIdentityNo.TabIndex = 47;
            this.lblTrIdentityNo.Text = "TC Kimlik No :";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(50, 48);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(51, 18);
            this.lblSurname.TabIndex = 46;
            this.lblSurname.Text = "Soyad :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(69, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(32, 18);
            this.lblName.TabIndex = 45;
            this.lblName.Text = "Ad :";
            // 
            // SecretaryUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 213);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tbPasswordAgain);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbTrIdentityNo);
            this.Controls.Add(this.tbSurname);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblPasswordAgain);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblTrIdentityNo);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SecretaryUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bilgi Güncelle";
            this.Load += new System.EventHandler(this.SecretaryUpdateForm_Load);
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
        private System.Windows.Forms.Label lblTrIdentityNo;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblName;
    }
}