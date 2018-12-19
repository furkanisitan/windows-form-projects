using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.Enums;
using System.Windows.Forms;
using HastaneYonetimRandevuSistemi.WinFormAppUI.SecretaryQuickAccessForms;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.DoctorForms
{
    public partial class DoctorForm : Form
    {
        private static readonly IDoctorService DoctorService;
        private static readonly IAppointmentService AppointmentService;

        private readonly int _id;
        private Doctor _doctor;

        static DoctorForm()
        {
            DoctorService = InstanceFactory.GetInstance<IDoctorService>();
            AppointmentService = InstanceFactory.GetInstance<IAppointmentService>();
        }

        public DoctorForm(int id)
        {
            _id = id;
            InitializeComponent();
        }

        private void DoctorForm_Load(object sender, System.EventArgs e)
        {
            UpdateForm();
            SetDgvMyAppointments(_id);
            SetDiseaseDescription(0);
        }

        private void DoctorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
            (Application.OpenForms[nameof(MainForm)] ?? new MainForm()).Show();
        }

        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            new DoctorAddOrUpdateForm(_id).ShowDialog();

        private void SetDgvMyAppointments(int doctorId)
        {
            dgvAppointments.Rows.Clear();
            var list = AppointmentService.GetAllWithPatientByDoctorId(doctorId);
            foreach (var appointment in list)
                dgvAppointments.Rows.Add(appointment.Id, appointment.DiseaseDescription,
                    $"{appointment.Patient.FirstName} {appointment.Patient.LastName}",
                    appointment.Date.ToShortDateString(), appointment.Date.ToShortTimeString());
        }

        private void SetDoctorInfo(Doctor doctor)
        {
            lblTrIdentityNo.Text = doctor.TrIdentityNo;
            lblFullName.Text = $@"{doctor.FirstName} {doctor.LastName}";
        }

        public void UpdateForm()
        {
            _doctor = DoctorService.GetById(_id);
            SetDoctorInfo(_doctor);
        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SetDiseaseDescription(e.RowIndex);
        }

        private void SetDiseaseDescription(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvAppointments.RowCount) return;
            var row = dgvAppointments.Rows[rowIndex];
            richTextBox1.Text = row.Cells["DiseaseDescription"].Value?.ToString();
        }

        private void btnQuickAccess_Click(object sender, System.EventArgs e)
        {
            var btnName = ((Button)sender).Name;

            if (btnName == btnAnnouncement.Name)
                new SecretaryAnnouncementListForm(PersonTypeEnum.Doctor).ShowDialog();
            else
            {
                Hide();
                (Application.OpenForms[nameof(MainForm)] ?? new MainForm()).Show();
            }

        }


    }
}
