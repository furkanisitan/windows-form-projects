using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.CustomHandlerMethods;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.CustomMethods;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.Enums;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.ExceptionHandling;
using HastaneYonetimRandevuSistemi.WinFormAppUI.SecretaryQuickAccessForms;
using System;
using System.Windows.Forms;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.SecretaryForms
{
    public partial class SecretaryForm : Form
    {
        private static readonly ISecretaryService SecretaryService;
        private static readonly IAppointmentService AppointmentService;
        private static readonly IAnnouncementService AnnouncementService;

        private readonly BranchHandler _handlerMethods;

        private readonly int _id;
        private Secretary _secretary;

        static SecretaryForm()
        {
            SecretaryService = InstanceFactory.GetInstance<ISecretaryService>();
            AppointmentService = InstanceFactory.GetInstance<IAppointmentService>();
            AnnouncementService = InstanceFactory.GetInstance<IAnnouncementService>();
        }

        public SecretaryForm(int id)
        {
            _id = id;
            _handlerMethods = new BranchHandler();
            InitializeComponent();
        }

        private void SecretaryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
            (Application.OpenForms[nameof(MainForm)] ?? new MainForm()).Show();

        }

        private void SecretaryForm_Load(object sender, EventArgs e)
        {
            UpdateForm();
            dtpAppointmentDate.MinDate = DateTime.Now;
            BranchMethods.SetComboBox(cbBranches);

            ComboBox_SelectedIndexChanged(cbBranches, null);
            cbHour.SelectedIndex = 0;
            cbMinute.SelectedIndex = 0;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var btnName = (sender as Button)?.Name;
            var result = CrudHandler.AddOrUpdate(() =>
            {
                if (string.Equals(btnName, btnCreateAppointment.Name))
                    AppointmentService.Add(CreateAppointmentInstance());
                else
                    AnnouncementService.Add(new Announcement { Text = richTextBox1.Text });
            });
            MyMethods.ShowMessageBox(result);
            if (string.Equals(btnName, btnCreateAnnouncement.Name) && result.IsSuccess)
                richTextBox1.Text = string.Empty;
        }

        private void llblUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            new SecretaryUpdateForm(_secretary.Id).ShowDialog();

        private void btnQuickAccess_Click(object sender, EventArgs e)
        {
            var btnName = ((Button)sender).Name;

            if (btnName == btnDoctors.Name)
                new SecretaryDoctorPanelForm().ShowDialog();
            else if (btnName == btnBranches.Name)
                new SecretaryBranchPanelForm().ShowDialog();
            else if (btnName == btnAppointment.Name)
                new SecretaryAppointmentListForm().ShowDialog();
            else if (btnName == btnAnnouncements.Name)
                new SecretaryAnnouncementListForm(PersonTypeEnum.Secretary).ShowDialog();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;

            if (comboBox.Name == cbBranches.Name)
                _handlerMethods.OnComboBoxIndexChanged(comboBox, cbDoctors);
            else
                btnCreateAppointment.Enabled = !string.IsNullOrEmpty(cbDoctors.Text);
        }

        private Appointment CreateAppointmentInstance()
        {
            var doctorId = cbDoctors.SelectedValue;
            if (doctorId == null) throw new Exception("Doktor Seçimi Yapılmadı");
            return new Appointment
            {
                DoctorId = (int)doctorId,
                Date = dtpAppointmentDate.Value.Date + GetSelectedTime()
            };
        }

        private void SetSecretaryInfo(Secretary secretary)
        {
            lblFullName.Text = $@"{secretary.FirstName} {secretary.LastName}";
            lblTrIdentityNo.Text = secretary.TrIdentityNo;
        }

        public void UpdateForm()
        {
            _secretary = SecretaryService.GetById(_id);
            SetSecretaryInfo(_secretary);
        }

        private TimeSpan GetSelectedTime()
        {
            var hour = int.Parse(cbHour.SelectedItem.ToString());
            var minute = int.Parse(cbMinute.SelectedItem.ToString());
            return new TimeSpan(hour, minute, 0);
        }
    }
}
