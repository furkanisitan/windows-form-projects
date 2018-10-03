using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace WifiPassword
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string output;
            using (var process = new Process())
            {
                process.StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "/C netsh wlan show profile | findstr All",
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };
                process.Start();
                output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }
            SetCbxWifiNames(GetWifiNames(output));
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var wifiName = cbxWifiNames.SelectedValue.ToString();
            if (string.IsNullOrEmpty(wifiName))
            {
                MessageBox.Show("Hatalı wifi adı");
                return;
            }

            string output;
            using (var process = new Process())
            {
                process.StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = $"/C netsh wlan show profile name=\"{wifiName}\" key=clear | findstr Key",
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };
                process.Start();
                output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }
            MessageBox.Show($@"Şifre: {GetPassword(output)}");
        }

        private static IEnumerable<string> GetWifiNames(string text)
        {
            var array = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < array.Length; i++)
                array[i] = array[i].Substring(array[i].LastIndexOf(':') + 1).Trim();
            return array;
        }

        private void SetCbxWifiNames(IEnumerable<string> wifiNames) =>
            cbxWifiNames.DataSource = wifiNames;

        private string GetPassword(string text) =>
            text.Substring(text.LastIndexOf(' '));

    }
}
