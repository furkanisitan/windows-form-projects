using System;
using System.Linq;
using System.Windows.Forms;
using WifiPasswords.Library;

namespace WifiPasswords
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SetCbxWifiNames();
        }

        private void SetCbxWifiNames()
        {
            cbxWifiNames.Items.Insert(0, "-- Wifi Seçin --");
            cbxWifiNames.Items.AddRange(WifiHelper.GetWifiNames().Cast<object>().ToArray());
            cbxWifiNames.SelectedIndex = 0;
        }

        private void btnFindWifi_Click(object sender, EventArgs e)
        {
            if (cbxWifiNames.SelectedIndex == 0) return;

            var wifiName = cbxWifiNames.SelectedItem?.ToString();
            var wifiPassword = WifiHelper.GetPwdOfWifi(wifiName);
            ShowMessageBox("Şifre",wifiPassword);
        }

        private void ShowMessageBox(string title, string message)
        {
            MessageBoxManager.Yes = "Kapat";
            MessageBoxManager.No = "Kopyala";

            MessageBoxManager.Register();

            if (MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                Clipboard.SetText(message);

            MessageBoxManager.Unregister();
        }
    }
}
