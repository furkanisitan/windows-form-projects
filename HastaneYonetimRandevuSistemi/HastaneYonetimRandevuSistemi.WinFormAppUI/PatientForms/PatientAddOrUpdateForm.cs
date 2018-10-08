using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.CustomMethods;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.ExceptionHandling;
using System;
using System.Windows.Forms;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.PatientForms
{
    public partial class PatientAddOrUpdateForm : Form
    {
        private static readonly IPatientService PatientService;

        private readonly Patient _patient;

        static PatientAddOrUpdateForm()
        {
            PatientService = InstanceFactory.GetInstance<IPatientService>();
        }

        public PatientAddOrUpdateForm(int? patientId = null)
        {
            _patient = patientId == null ? new Patient() : PatientService.GetById((int)patientId);
            InitializeComponent();
        }

        private void PatientEditProfileForm_Load(object sender, EventArgs e)
        {
            if (_patient.Id == 0)
            {
                Text = "Hasta Kayıt";
                btnUpdate.Text = "Kayıt Ol";
                return;
            }
            SetPatientInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var patient = GetPatientInstance();
            var result = CrudHandler.AddOrUpdate(() =>
            {
                if (patient.Id == 0)
                    PatientService.Add(patient);
                else
                    PatientService.Update(patient);
            });
            MyMethods.ShowMessageBox(result);
            if (!result.IsSuccess) return;
            Close();
            (Application.OpenForms[nameof(PatientForm)] as PatientForm)?.UpdateForm();
        }

        private void Password_TextChanged(object sender, EventArgs e) =>
            btnUpdate.Enabled = MyMethods.PasswordCompare(tbPassword.Text, tbPasswordAgain.Text);

        // TODO Yeni nesne oluşturulmadan döndürülürse Validation yapmıyor. Sorun PostSharp 'dan olabilir!
        private Patient GetPatientInstance()
        {
            return new Patient
            {
                Id = _patient.Id,
                FirstName = tbName.Text,
                LastName = tbSurname.Text,
                TrIdentityNo = tbTrIdentityNo.Text,
                PhoneNumber = tbPhoneNumber.Text,
                Password = tbPassword.Text
            };
        }

        private void SetPatientInfo()
        {
            tbName.Text = _patient.FirstName;
            tbSurname.Text = _patient.LastName;
            tbTrIdentityNo.Text = _patient.TrIdentityNo;
            tbPhoneNumber.Text = _patient.PhoneNumber;
            tbPassword.Text = _patient.Password;
        }
    }
}
