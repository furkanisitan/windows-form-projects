using System;
using System.Windows.Forms;
using WindowsShutdownUI.Library;

namespace WindowsShutdownUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            cbOpr.SelectedIndex = 0;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var totalSecond = dtpTime.Value.TimeOfDay.TotalSeconds;

            if (totalSecond < 1)
                return;

            switch (cbOpr.SelectedIndex)
            {
                case 1:
                    MessageBox.Show(ShutdownHelper.Shutdown(totalSecond));
                    break;
                case 2:
                    MessageBox.Show(ShutdownHelper.Restart(totalSecond));
                    break;
            }
        }

        private void lbtnCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(ShutdownHelper.Cancel());
        }

        private void ChangedValueOrIndex(object sender, EventArgs e)
        {
            btnApply.Enabled = cbOpr.SelectedIndex != 0 && dtpTime.Value.TimeOfDay.TotalSeconds > 0;
        }
    }
}
