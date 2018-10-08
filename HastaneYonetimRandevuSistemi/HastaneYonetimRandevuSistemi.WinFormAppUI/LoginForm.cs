using EnumStringValues;
using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.WinFormAppUI.DoctorForms;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.Enums;
using HastaneYonetimRandevuSistemi.WinFormAppUI.PatientForms;
using HastaneYonetimRandevuSistemi.WinFormAppUI.SecretaryForms;
using System;
using System.Windows.Forms;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI
{
    public partial class LoginForm : Form
    {
        private static readonly IDoctorService DoctorService;
        private static readonly IPatientService PatientService;
        private static readonly ISecretaryService SecretaryService;

        private readonly PersonTypeEnum _personTypeEnum;

        static LoginForm()
        {
            DoctorService = InstanceFactory.GetInstance<IDoctorService>();
            PatientService = InstanceFactory.GetInstance<IPatientService>();
            SecretaryService = InstanceFactory.GetInstance<ISecretaryService>();
        }

        public LoginForm(PersonTypeEnum personTypeEnum)
        {
            _personTypeEnum = personTypeEnum;

            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Text = $@"{_personTypeEnum.GetStringValue()} Giriş Paneli";
            linkSignUp.Visible = _personTypeEnum == PersonTypeEnum.Patient;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var trIdentityNo = tbTrIdentityNo.Text;
            var password = tbPassword.Text;

            int id;
            switch (_personTypeEnum)
            {
                case PersonTypeEnum.Doctor when (id = DoctorService.GetId(trIdentityNo, password)) != 0:
                    new DoctorForm(id).Show();
                    SetVisibilityOfPreviousForms();
                    break;
                case PersonTypeEnum.Patient when (id = PatientService.GetId(trIdentityNo, password)) != 0:
                    new PatientForm(id).Show();
                    SetVisibilityOfPreviousForms();
                    break;
                case PersonTypeEnum.Secretary when (id = SecretaryService.GetId(trIdentityNo, password)) != 0:
                    new SecretaryForm(id).Show();
                    SetVisibilityOfPreviousForms();
                    break;
                default:
                    MessageBox.Show(@"T.C. Kimlik No ya da Şifre Hatalı!", @"Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            new PatientAddOrUpdateForm().ShowDialog();

        private void SetVisibilityOfPreviousForms()
        {
            Close();
            Application.OpenForms[nameof(MainForm)]?.Hide();
        }
    }
}
