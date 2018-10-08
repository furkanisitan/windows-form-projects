using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.CustomMethods;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.ExceptionHandling;
using HastaneYonetimRandevuSistemi.WinFormAppUI.SecretaryQuickAccessForms;
using System.Windows.Forms;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.DoctorForms
{
    public partial class DoctorAddOrUpdateForm : Form
    {
        private static readonly IDoctorService DoctorService;

        private readonly Doctor _doctor;

        static DoctorAddOrUpdateForm()
        {
            DoctorService = InstanceFactory.GetInstance<IDoctorService>();
        }

        public DoctorAddOrUpdateForm(int? doctorId = null)
        {
            _doctor = doctorId == null ? new Doctor() : DoctorService.GetById((int)doctorId);
            InitializeComponent();
        }

        private void DoctorAddOrUpdateForm_Load(object sender, System.EventArgs e)
        {
            BranchMethods.SetComboBox(cbBranch);
            if (_doctor.Id == 0)
            {
                Text = "Doktor Ekle";
                btnUpdate.Text = "Ekle";
                return;
            }
            SetDoctorInfo();
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            var doctor = GetDoctorInstance();
            var result = CrudHandler.AddOrUpdate(() =>
            {
                if (doctor.Id == 0)
                    DoctorService.Add(doctor);
                else
                    DoctorService.Update(doctor);
            });
            MyMethods.ShowMessageBox(result);
            if (!result.IsSuccess) return;
            Close();
            (Application.OpenForms[nameof(DoctorForm)] as DoctorForm)?.UpdateForm();
            (Application.OpenForms[nameof(SecretaryDoctorPanelForm)] as SecretaryDoctorPanelForm)?.UpdateForm();
        }

        private void Password_TextChanged(object sender, System.EventArgs e) =>
            btnUpdate.Enabled = MyMethods.PasswordCompare(tbPassword.Text, tbPasswordAgain.Text);

        private Doctor GetDoctorInstance()
        {
            return new Doctor
            {
                Id = _doctor.Id,
                FirstName = tbName.Text,
                LastName = tbSurname.Text,
                TrIdentityNo = tbTrIdentityNo.Text,
                Password = tbPassword.Text,
                BranchId = (int)cbBranch.SelectedValue
            };
        }

        private void SetDoctorInfo()
        {
            tbName.Text = _doctor.FirstName;
            tbSurname.Text = _doctor.LastName;
            tbTrIdentityNo.Text = _doctor.TrIdentityNo;
            tbPassword.Text = _doctor.Password;
            cbBranch.SelectedValue = _doctor.BranchId;
        }
    }
}
