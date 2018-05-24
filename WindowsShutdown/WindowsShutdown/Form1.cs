using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsShutdown
{
    public partial class Form1 : Form
    {
        TimeSpan time = new TimeSpan(0, 0, 0);
        double oneDayTotalSecond = 24 * 60 * 60;


        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void _Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                double second = time.TotalSeconds;
                if (rbAt.Checked)
                {
                    TimeSpan timeNow = DateTime.Now.TimeOfDay;
                    second = Math.Round(time.Subtract(timeNow).TotalSeconds);
                    second += second < 0 ? oneDayTotalSecond : 0;
                }
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        Process.Start("shutdown", $"/s /t {second}");
                        break;
                    case 1:
                        Process.Start("shutdown", $"/r /t {second}");
                        break;
                }
            }
            else
                Process.Start("shutdown", "/a");
        }

        // ToolTip
        private void mouseHover(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                string opr = comboBox1.SelectedIndex == 0 ? "kapatılacak" : "yeniden başlatılacak";
                if (((RadioButton)sender).Name == rbAfter.Name)
                    toolTip1.SetToolTip(rbAfter, $"{time.TotalSeconds} saniye sonra {opr}.");
                else
                    toolTip1.SetToolTip(rbAt, $"Saat {time.ToString()} da {opr}.");
            }
            else
                toolTip1.SetToolTip(linkLabel1, "Daha önceden tanımlanmış bir yeniden başlatma/kapatma işlemi varsa iptel eder.");
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            time = new TimeSpan((int)nudHour.Value, (int)nudMinute.Value, (int)nudSecond.Value);
        }
    }
}
