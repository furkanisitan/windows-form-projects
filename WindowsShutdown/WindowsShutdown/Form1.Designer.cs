namespace WindowsShutdown
{
    partial class Form1
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
            this.nudHour = new System.Windows.Forms.NumericUpDown();
            this.nudMinute = new System.Windows.Forms.NumericUpDown();
            this.nudSecond = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.rbAfter = new System.Windows.Forms.RadioButton();
            this.rbAt = new System.Windows.Forms.RadioButton();
            this.btnApply = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecond)).BeginInit();
            this.SuspendLayout();
            // 
            // nudHour
            // 
            this.nudHour.Location = new System.Drawing.Point(12, 36);
            this.nudHour.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudHour.Name = "nudHour";
            this.nudHour.Size = new System.Drawing.Size(41, 20);
            this.nudHour.TabIndex = 0;
            this.nudHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudHour.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // nudMinute
            // 
            this.nudMinute.Location = new System.Drawing.Point(59, 36);
            this.nudMinute.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudMinute.Name = "nudMinute";
            this.nudMinute.Size = new System.Drawing.Size(41, 20);
            this.nudMinute.TabIndex = 1;
            this.nudMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMinute.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // nudSecond
            // 
            this.nudSecond.Location = new System.Drawing.Point(106, 36);
            this.nudSecond.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudSecond.Name = "nudSecond";
            this.nudSecond.Size = new System.Drawing.Size(41, 20);
            this.nudSecond.TabIndex = 2;
            this.nudSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSecond.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "sa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "dk";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "sn";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Bilgisayarı Kapat",
            "Yeniden Başlat"});
            this.comboBox1.Location = new System.Drawing.Point(12, 72);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(135, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // rbAfter
            // 
            this.rbAfter.AutoSize = true;
            this.rbAfter.Checked = true;
            this.rbAfter.Location = new System.Drawing.Point(163, 36);
            this.rbAfter.Name = "rbAfter";
            this.rbAfter.Size = new System.Drawing.Size(127, 17);
            this.rbAfter.TabIndex = 7;
            this.rbAfter.TabStop = true;
            this.rbAfter.Text = "Belirtilen zaman sonra";
            this.rbAfter.UseVisualStyleBackColor = true;
            this.rbAfter.MouseHover += new System.EventHandler(this.mouseHover);
            // 
            // rbAt
            // 
            this.rbAt.AutoSize = true;
            this.rbAt.Location = new System.Drawing.Point(163, 59);
            this.rbAt.Name = "rbAt";
            this.rbAt.Size = new System.Drawing.Size(110, 17);
            this.rbAt.TabIndex = 8;
            this.rbAt.Text = "Belirtilen zamanda";
            this.rbAt.UseVisualStyleBackColor = true;
            this.rbAt.MouseHover += new System.EventHandler(this.mouseHover);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(52, 108);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(95, 23);
            this.btnApply.TabIndex = 9;
            this.btnApply.Text = "Uygula";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this._Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(169, 113);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(131, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Zamanlanmış işlemi iptal et";
            this.linkLabel1.Click += new System.EventHandler(this._Click);
            this.linkLabel1.MouseHover += new System.EventHandler(this.mouseHover);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(312, 141);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.rbAfter);
            this.Controls.Add(this.rbAt);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudSecond);
            this.Controls.Add(this.nudMinute);
            this.Controls.Add(this.nudHour);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Shutdown";
            ((System.ComponentModel.ISupportInitialize)(this.nudHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecond)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudHour;
        private System.Windows.Forms.NumericUpDown nudMinute;
        private System.Windows.Forms.NumericUpDown nudSecond;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton rbAfter;
        private System.Windows.Forms.RadioButton rbAt;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

