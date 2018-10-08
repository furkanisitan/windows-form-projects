using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.WinFormAppUI.AppointmentForms;
using System.Windows.Forms;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.SecretaryQuickAccessForms
{
    public partial class SecretaryAppointmentListForm : Form
    {
        private static readonly IAppointmentService AppointmentService;

        static SecretaryAppointmentListForm()
        {
            AppointmentService = InstanceFactory.GetInstance<IAppointmentService>();
        }

        public SecretaryAppointmentListForm()
        {
            InitializeComponent();
        }

        private void SecretaryAppointmentListForm_Load(object sender, System.EventArgs e) =>
            UpdateForm();

        private void dgvAppointments_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var row = dgvAppointments.Rows[e.RowIndex];

            new AppointmentUpdateForm((int)row.Cells["Id"].Value).ShowDialog();
        }

        private void SetDgvAppointments()
        {
            dgvAppointments.Rows.Clear();
            foreach (var appointmentDetail in AppointmentService.GetAllAppointmentDetail())
            {
                dgvAppointments.Rows.Add(appointmentDetail.Id, appointmentDetail.DoctorName,
                    appointmentDetail.BranchName, appointmentDetail.Date.ToShortDateString(),
                    appointmentDetail.Date.ToShortTimeString(), appointmentDetail.PatientName);
            }
        }

        public void UpdateForm() =>
            SetDgvAppointments();
    }
}
