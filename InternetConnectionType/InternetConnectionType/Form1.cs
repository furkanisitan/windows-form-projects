using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace InternetConnectionType
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            var result = CheckTypes();
            lblWifi.Text = result[0].ToString();
            lblEthernet.Text = result[1].ToString();
        }

        private static bool[] CheckTypes()
        {
            bool[] result = { false, false }; // 0 => wifi, 1 => ethernet
            foreach (var ni in NetworkInterface.GetAllNetworkInterfaces().Where(ni => ni.OperationalStatus == OperationalStatus.Up))
            {
                var name = ni.Name.ToLower();
                if (name.Contains("wi-fi"))
                    result[0] = true;
                if (name.Contains("ethernet"))
                    result[1] = true;
            }
            return result;
        }
    }
}
