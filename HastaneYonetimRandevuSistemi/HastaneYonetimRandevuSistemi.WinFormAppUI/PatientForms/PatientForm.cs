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

        private void PatientForm_FormClosed(object sender, FormClosedEventArgs e) =>
            Application.Exit();

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
            var result = CrudHandler.AddOrUpdate(() => { AppointmentService.Update(GetAppointmentInstance()); });
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

        private void SetDgvAppointments(int doctorId)
        {
            dgvAppointments.Rows.Clear();
            var list = AppointmentService.GetAllAppointmentDetail(x => x.DoctorId == doctorId && x.PatientId == null);
            foreach (var appointmentDetail in list)
                dgvAppointments.Rows.Add(appointmentDetail.Id, appointmentDetail.DoctorName,
                    appointmentDetail.BranchName, appointmentDetail.Date.ToShortDateString(),
                    appointmentDetail.Date.ToShortTimeString());
        }

        private void SetDgvMyAppointments(int patientId)
        {
            dgvMyAppointments.Rows.Clear();
            var list = AppointmentService.GetAllAppointmentDetail(x => x.PatientId == patientId);
            foreach (var appointmentDetail in list)
                dgvMyAppointments.Rows.Add(appointmentDetail.DoctorName, appointmentDetail.BranchName,
                    appointmentDetail.Date.ToShortDateString(), appointmentDetail.Date.ToShortTimeString());
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

        private Appointment GetAppointmentInstance()
        {
            var appointmentId = (int)dgvAppointments.SelectedCells[0].Value;
            var appointment = AppointmentService.GetById(appointmentId);
            appointment.PatientId = _patient.Id;
            appointment.DiseaseDescription = rtbComplaint.Text;
            return new Appointment
            {
                Id = appointment.Id,
                Date = appointment.Date,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                DiseaseDescription = appointment.DiseaseDescription,
            };
        }

        public void UpdateForm()
        {
            _patient = PatientService.GetById(_id);
            SetPatientInfo(_patient);
        }
    }
}
