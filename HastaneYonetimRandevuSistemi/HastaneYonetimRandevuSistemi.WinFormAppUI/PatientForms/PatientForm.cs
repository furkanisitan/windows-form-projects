using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.CustomHandlerMethods;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.CustomMethods;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.ExceptionHandling;
using System;
using System.Windows.Forms;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.PatientForms
{
    public partial class PatientForm : Form
    {
        private static readonly IAppointmentService AppointmentService;
        private static readonly IPatientService PatientService;
        private static readonly DataGridViewCellStyle CellStyle = 
            new DataGridViewCellStyle { Padding = new Padding(0, 25, 0, 0) };

        private readonly BranchHandler _branchHandler;

        private readonly int _id;
        private Patient _patient;

        static PatientForm()
        {
            AppointmentService = InstanceFactory.GetInstance<IAppointmentService>();
            PatientService = InstanceFactory.GetInstance<IPatientService>();
        }

        public PatientForm(int id)
        {
            _id = id;
            _branchHandler = new BranchHandler();

            InitializeComponent();
        }

        private void PatientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
            (Application.OpenForms[nameof(MainForm)] ?? new MainForm()).Show();
        }

        private void PatientForm_Load(object sender, EventArgs e)
        {
            UpdateForm();
            SetDgvMyAppointments(_patient.Id);
            BranchMethods.SetComboBox(cbBranches);

            ComboBox_SelectedIndexChanged(cbBranches, null);
            ComboBox_SelectedIndexChanged(cbDoctors, null);
        }

        private void btnGetAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedCells.Count < 1) return;

            var appointmentId = (int)dgvAppointments.SelectedCells[0].Value;
            var result = CrudHandler.AddOrUpdate(() =>
            {
                AppointmentService.Update(
                    CreateAppointmentInstance(appointmentId, _patient.Id, rtbComplaint.Text));
            });
            MyMethods.ShowMessageBox(result);
            if (!result.IsSuccess) return;
            ResetAppointmentPreferences();
            ComboBox_SelectedIndexChanged(cbBranches, null);
            SetDgvMyAppointments(_id);
        }

        private void linkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            new PatientAddOrUpdateForm(_patient.Id).ShowDialog();

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;

            if (comboBox.Name == cbBranches.Name)
            {
                _branchHandler.OnComboBoxIndexChanged(sender, cbDoctors);
                if (cbDoctors.Items.Count < 1)
                    SetDgvAppointments(0);
            }
            else
            {
                try
                {
                    var doctorId = (int)((ComboBox)sender).SelectedValue;
                    SetDgvAppointments(doctorId);
                }
                catch
                {
                    // ignored
                }
            }
            btnGetAppointment.Enabled = cbDoctors.Items.Count > 0;
        }

        private void Dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Name.Equals(dgvAppointments.Name))
                dgvMyAppointments.ClearSelection();
            else
                dgvAppointments.ClearSelection();
        }

        private void dgvMyAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var id = (int)senderGrid.Rows[e.RowIndex].Cells[0].Value;
            var appointment = AppointmentService.GetById(id);
            appointment.PatientId = null;
            var result = CrudHandler.AddOrUpdate(() =>
            {
                AppointmentService.Update(
                    CreateAppointmentInstance(id, null, null));
            });
            MyMethods.ShowMessageBox(result);
            if (!result.IsSuccess) return;
            senderGrid.Rows.RemoveAt(e.RowIndex);
            ComboBox_SelectedIndexChanged(cbDoctors, null);
        }

        private void SetDgvAppointments(int doctorId)
        {
            dgvAppointments.Rows.Clear();
            var list = AppointmentService.GetAllAppointmentDetail(x => x.DoctorId == doctorId && x.PatientId == null && x.Date > DateTime.Now);
            foreach (var appointmentDetail in list)
                dgvAppointments.Rows.Add(appointmentDetail.Id, appointmentDetail.DoctorName,
                    appointmentDetail.BranchName, appointmentDetail.Date.ToShortDateString(),
                    appointmentDetail.Date.ToShortTimeString());
        }

        private void SetDgvMyAppointments(int patientId)
        {
            dgvMyAppointments.Rows.Clear();
            var list = AppointmentService.GetAllAppointmentDetail(x => x.PatientId == patientId);

            var i = 0;
            var lastColumnIndex = dgvMyAppointments.Columns.Count - 1;
            foreach (var appointmentDetail in list)
            {
                dgvMyAppointments.Rows.Add(appointmentDetail.Id, appointmentDetail.DoctorName, appointmentDetail.BranchName,
                    appointmentDetail.Date.ToShortDateString(), appointmentDetail.Date.ToShortTimeString());

                if (appointmentDetail.Date < DateTime.Now)
                    dgvMyAppointments.Rows[i++].Cells[lastColumnIndex].Style = CellStyle;
            }
        }

        private void SetPatientInfo(Patient patient)
        {
            lblFullName.Text = $@"{patient.FirstName} {patient.LastName}";
            lblTrIdentityNo.Text = patient.TrIdentityNo;
        }

        private void ResetAppointmentPreferences()
        {
            cbBranches.SelectedIndex = 0;
            cbBranches.SelectedIndex = 0;
            rtbComplaint.Text = string.Empty;
        }

        private Appointment CreateAppointmentInstance(int id, int? patientId, string diseaseDescription)
        {
            var appointment = AppointmentService.GetById(id);
            return new Appointment
            {
                Id = appointment.Id,
                Date = appointment.Date,
                DoctorId = appointment.DoctorId,
                PatientId = patientId,
                DiseaseDescription = diseaseDescription
            };
        }

        public void UpdateForm()
        {
            _patient = PatientService.GetById(_id);
            SetPatientInfo(_patient);
        }
    }
}
