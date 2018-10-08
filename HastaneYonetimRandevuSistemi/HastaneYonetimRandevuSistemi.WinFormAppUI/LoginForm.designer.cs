namespace HastaneYonetimRandevuSistemi.WinFormAppUI
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.lblTrIdentityNo = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbTrIdentityNo = new System.Windows.Forms.MaskedTextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.linkSignUp = new System.Windows.Forms.LinkLabel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblTrIdentityNo
            // 
            this.lblTrIdentityNo.AutoSize = true;
            this.lblTrIdentityNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTrIdentityNo.Location = new System.Drawing.Point(27, 23);
            this.lblTrIdentityNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTrIdentityNo.Name = "lblTrIdentityNo";
            this.lblTrIdentityNo.Size = new System.Drawing.Size(113, 22);
            this.lblTrIdentityNo.TabIndex = 4;
            this.lblTrIdentityNo.Text = "TC Kimlik No :";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPassword.Location = new System.Drawing.Point(91, 55);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(49, 22);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Şifre :";
            // 
            // tbTrIdentityNo
            // 
            this.tbTrIdentityNo.Location = new System.Drawing.Point(145, 23);
            this.tbTrIdentityNo.Mask = "00000000000";
            this.tbTrIdentityNo.Name = "tbTrIdentityNo";
            this.tbTrIdentityNo.Size = new System.Drawing.Size(112, 25);
            this.tbTrIdentityNo.TabIndex = 0;
            this.tbTrIdentityNo.ValidatingType = typeof(int);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(145, 55);
            this.tbPassword.MaxLength = 20;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(112, 25);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // linkSignUp
            // 
            this.linkSignUp.AutoSize = true;
            this.linkSignUp.Location = new System.Drawing.Point(28, 91);
            this.linkSignUp.Name = "linkSignUp";
            this.linkSignUp.Size = new System.Drawing.Size(49, 18);
            this.linkSignUp.TabIndex = 3;
            this.linkSignUp.TabStop = true;
            this.linkSignUp.Text = "Üye Ol";
            this.linkSignUp.Visible = false;
            this.linkSignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSignUp_LinkClicked);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(177, 86);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(80, 28);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Giriş Yap";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(287, 128);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.linkSignUp);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbTrIdentityNo);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblTrIdentityNo);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hasta Giriş Paneli";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTrIdentityNo;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.MaskedTextBox tbTrIdentityNo;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.LinkLabel linkSignUp;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}