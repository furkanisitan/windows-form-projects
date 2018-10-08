using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI
{
    public partial class MainForm : Form
    {
        private readonly Dictionary<string, PersonTypeEnum> _dictionary;

        public MainForm()
        {
            InitializeComponent();
            _dictionary = new Dictionary<string, PersonTypeEnum>
            {
                { btnDoctor.Name, PersonTypeEnum.Doctor},
                { btnPatient.Name, PersonTypeEnum.Patient},
                { btnSecretary.Name, PersonTypeEnum.Secretary}
            };
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var btnName = ((Button)sender).Name;
            new LoginForm(_dictionary[btnName]).ShowDialog();
        }
    }
}
