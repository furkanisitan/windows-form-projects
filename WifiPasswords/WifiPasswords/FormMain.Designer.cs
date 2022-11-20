namespace WifiPasswords
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
            this.cbxWifiNames = new System.Windows.Forms.ComboBox();
            this.btnFindWifi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxWifiNames
            // 
            this.cbxWifiNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWifiNames.FormattingEnabled = true;
            this.cbxWifiNames.Location = new System.Drawing.Point(12, 12);
            this.cbxWifiNames.Name = "cbxWifiNames";
            this.cbxWifiNames.Size = new System.Drawing.Size(172, 21);
            this.cbxWifiNames.TabIndex = 4;
            // 
            // btnFindWifi
            // 
            this.btnFindWifi.Location = new System.Drawing.Point(109, 48);
            this.btnFindWifi.Name = "btnFindWifi";
            this.btnFindWifi.Size = new System.Drawing.Size(75, 23);
            this.btnFindWifi.TabIndex = 5;
            this.btnFindWifi.Text = "Bul";
            this.btnFindWifi.UseVisualStyleBackColor = true;
            this.btnFindWifi.Click += new System.EventHandler(this.btnFindWifi_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 84);
            this.Controls.Add(this.btnFindWifi);
            this.Controls.Add(this.cbxWifiNames);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wifi Şifreleri";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxWifiNames;
        private System.Windows.Forms.Button btnFindWifi;
    }
}