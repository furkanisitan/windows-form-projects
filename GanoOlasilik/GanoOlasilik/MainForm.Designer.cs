namespace GanoOlasilik
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.lessonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lessonCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lessonPoint = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lessonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnRun = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.tbPoint = new System.Windows.Forms.TextBox();
            this.tbCredit = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lessonName,
            this.lessonCredit,
            this.lessonPoint,
            this.lessonDelete});
            this.dgvMain.Location = new System.Drawing.Point(12, 12);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.Size = new System.Drawing.Size(410, 237);
            this.dgvMain.TabIndex = 0;
            this.dgvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellContentClick);
            this.dgvMain.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMain_RowValidating);
            // 
            // lessonName
            // 
            this.lessonName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.lessonName.HeaderText = "Ders Adı";
            this.lessonName.MaxInputLength = 30;
            this.lessonName.Name = "lessonName";
            this.lessonName.Width = 220;
            // 
            // lessonCredit
            // 
            this.lessonCredit.HeaderText = "Kredi";
            this.lessonCredit.MaxInputLength = 2;
            this.lessonCredit.Name = "lessonCredit";
            this.lessonCredit.Width = 50;
            // 
            // lessonPoint
            // 
            this.lessonPoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.lessonPoint.DefaultCellStyle = dataGridViewCellStyle6;
            this.lessonPoint.HeaderText = "H. Notu";
            this.lessonPoint.Name = "lessonPoint";
            this.lessonPoint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lessonPoint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lessonPoint.ToolTipText = "Eğer bu dersi daha önce aldıysanız, harf notunu giriniz.";
            this.lessonPoint.Width = 69;
            // 
            // lessonDelete
            // 
            this.lessonDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.lessonDelete.HeaderText = "Sil";
            this.lessonDelete.Name = "lessonDelete";
            this.lessonDelete.ReadOnly = true;
            this.lessonDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lessonDelete.Text = "Sil";
            this.lessonDelete.UseColumnTextForButtonValue = true;
            this.lessonDelete.Width = 24;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 255);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Başla";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(118, 260);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(38, 13);
            this.lbl1.TabIndex = 6;
            this.lbl1.Text = "Puan :";
            // 
            // tbPoint
            // 
            this.tbPoint.Location = new System.Drawing.Point(162, 257);
            this.tbPoint.MaxLength = 4;
            this.tbPoint.Name = "tbPoint";
            this.tbPoint.Size = new System.Drawing.Size(56, 20);
            this.tbPoint.TabIndex = 7;
            // 
            // tbCredit
            // 
            this.tbCredit.Location = new System.Drawing.Point(267, 257);
            this.tbCredit.MaxLength = 4;
            this.tbCredit.Name = "tbCredit";
            this.tbCredit.Size = new System.Drawing.Size(56, 20);
            this.tbCredit.TabIndex = 9;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(224, 260);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(37, 13);
            this.lbl2.TabIndex = 8;
            this.lbl2.Text = "Kredi :";
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(12, 281);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(42, 9);
            this.lblWarning.TabIndex = 10;
            this.lblWarning.Text = "lblWarning";
            this.lblWarning.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 291);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.tbCredit);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.tbPoint);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.dgvMain);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gano Olasılık";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox tbPoint;
        private System.Windows.Forms.TextBox tbCredit;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn lessonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lessonCredit;
        private System.Windows.Forms.DataGridViewComboBoxColumn lessonPoint;
        private System.Windows.Forms.DataGridViewButtonColumn lessonDelete;
        private System.Windows.Forms.Label lblWarning;
    }
}

