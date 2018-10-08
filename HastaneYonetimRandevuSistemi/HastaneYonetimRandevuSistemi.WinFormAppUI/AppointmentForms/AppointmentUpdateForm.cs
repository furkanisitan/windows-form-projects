using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.Entities.ComplexTypes;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.CustomHandlerMethods;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.CustomMethods;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.ExceptionHandling;
using HastaneYonetimRandevuSistemi.WinFormAppUI.SecretaryQuickAccessForms;
using System.Windows.Forms;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.AppointmentForms
{
    public partial class AppointmentUpdateForm : Form
    {
        private static readonly IAppointmentService AppointmentService;

        private readonly BranchHandler _branchHandler;

        private readonly Appointment _appointment;
        private readonly AppointmentDetail _appointmentDetail;

        static AppointmentUpdateForm()
        {
            AppointmentService = InstanceFactory.GetInstance<IAppointmentService>();
        }

        public AppointmentUpdateForm(int appointmentId)
        {
            _branchHandler = new BranchHandler();

            _appointment = AppointmentService.GetById(appointmentId);
            _appointmentDetail = AppointmentService.GetAppointmentDetailById(appointmentId);

            InitializeComponent();
        }

        private void AppointmentUpdateForm_Load(object sender, System.EventArgs e)
        {
            BranchMethods.SetComboBox(cbBranches);
            cbBranches_SelectedIndexChanged(cbBranches, null);
            SetAppointmentInfo();
        }

        private void cbBranches_SelectedIndexChanged(object sender, System.EventArgs e) =>
            _branchHandler.OnComboBoxIndexChanged(sender, cbDoctors);

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            var appointment = GetAppointmentInstance();
            var result = CrudHandler.AddOrUpdate(() => AppointmentService.Update(appointment));
            MyMethods.ShowMessageBox(result);
            if (!result.IsSuccess) return;
            Close();
            (Application.OpenForms[nameof(SecretaryAppointmentListForm)] as SecretaryAppointmentListForm)?.UpdateForm();
        }

        private Appointment GetAppointmentInstance()
        {
            _appointment.Date = dtpAppointmentDate.Value.Date + dtpAppointmentTime.Value.TimeOfDay;
            _appointment.DoctorId = (int)cbDoctors.SelectedValue;
            return _appointment;
        }

        private void SetAppointmentInfo()
        {
            dtpAppointmentDate.Text = _appointmentDetail.Date.ToShortDateString();
            dtpAppointmentTime.Text = _appointmentDetail.Date.ToShortTimeString();

            cbBranches.SelectedIndex = cbBranches.FindStringExact(_appointmentDetail.BranchName);
            cbDoctors.SelectedIndex = cbDoctors.FindStringExact(_appointmentDetail.DoctorName);
        }
    }
}
