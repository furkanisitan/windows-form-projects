using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.WinFormAppUI.DoctorForms;
using System.Windows.Forms;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.SecretaryQuickAccessForms
{
    public partial class SecretaryDoctorPanelForm : Form
    {
        private static readonly IDoctorService DoctorService;

        static SecretaryDoctorPanelForm()
        {
            DoctorService = InstanceFactory.GetInstance<IDoctorService>();
        }

        public SecretaryDoctorPanelForm()
        {
            InitializeComponent();
        }

        private void SecretaryDoctorPanelForm_Load(object sender, System.EventArgs e) =>
            UpdateForm();

        // Update
        private void dgvDoctors_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var doctorId = (int)dgvDoctors.Rows[e.RowIndex].Cells["Id"].Value;
            new DoctorAddOrUpdateForm(doctorId, true).ShowDialog();
        }

        // Create
        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            new DoctorAddOrUpdateForm().ShowDialog();

        private void SetDgvDoctors()
        {
            dgvDoctors.Rows.Clear();
            foreach (var doctor in DoctorService.GetAllWithBranch())
                dgvDoctors.Rows.Add(doctor.Id, doctor.Branch.Id, doctor.FirstName, doctor.LastName,
                    doctor.TrIdentityNo, doctor.Password, doctor.Branch.Name);
        }

        public void UpdateForm() =>
            SetDgvDoctors();
    }
}
