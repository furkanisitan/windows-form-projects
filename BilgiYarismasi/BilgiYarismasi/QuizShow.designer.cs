namespace BilgiYarismasi
{
    partial class QuizShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizShow));
            this.btnA = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFalseNum = new System.Windows.Forms.Label();
            this.lblTrueNum = new System.Windows.Forms.Label();
            this.lblLingeringQuestion = new System.Windows.Forms.Label();
            this.lblQuestionNum = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblAnnotate = new System.Windows.Forms.Label();
            this.timerTrue = new System.Windows.Forms.Timer(this.components);
            this.timerFalse = new System.Windows.Forms.Timer(this.components);
            this.timerWait = new System.Windows.Forms.Timer(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnA
            // 
            this.btnA.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnA.Enabled = false;
            this.btnA.Location = new System.Drawing.Point(13, 150);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(276, 30);
            this.btnA.TabIndex = 1;
            this.btnA.TabStop = false;
            this.btnA.Text = "A";
            this.btnA.UseVisualStyleBackColor = false;
            this.btnA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMouseClick);
            // 
            // btnB
            // 
            this.btnB.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnB.Enabled = false;
            this.btnB.Location = new System.Drawing.Point(295, 150);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(276, 30);
            this.btnB.TabIndex = 1;
            this.btnB.TabStop = false;
            this.btnB.Text = "B";
            this.btnB.UseVisualStyleBackColor = false;
            this.btnB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMouseClick);
            // 
            // btnC
            // 
            this.btnC.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnC.Enabled = false;
            this.btnC.Location = new System.Drawing.Point(12, 186);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(276, 30);
            this.btnC.TabIndex = 1;
            this.btnC.TabStop = false;
            this.btnC.Text = "C";
            this.btnC.UseVisualStyleBackColor = false;
            this.btnC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMouseClick);
            // 
            // btnD
            // 
            this.btnD.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnD.Enabled = false;
            this.btnD.Location = new System.Drawing.Point(295, 186);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(276, 30);
            this.btnD.TabIndex = 1;
            this.btnD.TabStop = false;
            this.btnD.Text = "D";
            this.btnD.UseVisualStyleBackColor = false;
            this.btnD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(596, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Soru No :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(579, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kalan Soru :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(608, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Yanlış :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(608, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Doğru :";
            // 
            // lblFalseNum
            // 
            this.lblFalseNum.AutoSize = true;
            this.lblFalseNum.Location = new System.Drawing.Point(665, 115);
            this.lblFalseNum.Name = "lblFalseNum";
            this.lblFalseNum.Size = new System.Drawing.Size(15, 18);
            this.lblFalseNum.TabIndex = 6;
            this.lblFalseNum.Text = "0";
            // 
            // lblTrueNum
            // 
            this.lblTrueNum.AutoSize = true;
            this.lblTrueNum.Location = new System.Drawing.Point(665, 83);
            this.lblTrueNum.Name = "lblTrueNum";
            this.lblTrueNum.Size = new System.Drawing.Size(15, 18);
            this.lblTrueNum.TabIndex = 7;
            this.lblTrueNum.Text = "0";
            // 
            // lblLingeringQuestion
            // 
            this.lblLingeringQuestion.AutoSize = true;
            this.lblLingeringQuestion.Location = new System.Drawing.Point(665, 51);
            this.lblLingeringQuestion.Name = "lblLingeringQuestion";
            this.lblLingeringQuestion.Size = new System.Drawing.Size(22, 18);
            this.lblLingeringQuestion.TabIndex = 8;
            this.lblLingeringQuestion.Text = "30";
            // 
            // lblQuestionNum
            // 
            this.lblQuestionNum.AutoSize = true;
            this.lblQuestionNum.Location = new System.Drawing.Point(665, 19);
            this.lblQuestionNum.Name = "lblQuestionNum";
            this.lblQuestionNum.Size = new System.Drawing.Size(15, 18);
            this.lblQuestionNum.TabIndex = 9;
            this.lblQuestionNum.Text = "0";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Palatino Linotype", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTime.Location = new System.Drawing.Point(612, 159);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 47);
            this.lblTime.TabIndex = 10;
            // 
            // lblAnnotate
            // 
            this.lblAnnotate.AutoSize = true;
            this.lblAnnotate.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAnnotate.ForeColor = System.Drawing.Color.Red;
            this.lblAnnotate.Location = new System.Drawing.Point(498, 218);
            this.lblAnnotate.Name = "lblAnnotate";
            this.lblAnnotate.Size = new System.Drawing.Size(197, 16);
            this.lblAnnotate.TabIndex = 11;
            this.lblAnnotate.Text = "Yarışmayı başlatmak için \'Enter\' a basın";
            // 
            // timerTrue
            // 
            this.timerTrue.Tick += new System.EventHandler(this.timerTrue_Tick);
            // 
            // timerFalse
            // 
            this.timerFalse.Tick += new System.EventHandler(this.timerFalse_Tick);
            // 
            // timerWait
            // 
            this.timerWait.Tick += new System.EventHandler(this.timerWait_Tick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(12, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(559, 131);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // timerTime
            // 
            this.timerTime.Interval = 1000;
            this.timerTime.Tick += new System.EventHandler(this.timerTime_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(611, 159);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // QuizShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(698, 235);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblAnnotate);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblQuestionNum);
            this.Controls.Add(this.lblLingeringQuestion);
            this.Controls.Add(this.lblTrueNum);
            this.Controls.Add(this.lblFalseNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnA);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "QuizShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bilgi Yarışması";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.QuizShow_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFalseNum;
        private System.Windows.Forms.Label lblTrueNum;
        private System.Windows.Forms.Label lblLingeringQuestion;
        private System.Windows.Forms.Label lblQuestionNum;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblAnnotate;
        private System.Windows.Forms.Timer timerTrue;
        private System.Windows.Forms.Timer timerFalse;
        private System.Windows.Forms.Timer timerWait;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timerTime;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

