using System;
using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.Enums;
using System.Windows.Forms;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.CustomMethods;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.ExceptionHandling;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.SecretaryQuickAccessForms
{
    public partial class SecretaryAnnouncementListForm : Form
    {
        private static readonly IAnnouncementService AnnouncementService;
        private readonly PersonTypeEnum _auth;
        private static readonly DataGridViewCellStyle CellStyle =
            new DataGridViewCellStyle { Padding = new Padding(0, 25, 0, 0) };

        static SecretaryAnnouncementListForm()
        {
            AnnouncementService = InstanceFactory.GetInstance<IAnnouncementService>();
        }

        public SecretaryAnnouncementListForm(PersonTypeEnum auth)
        {
            _auth = auth;
            InitializeComponent();
        }

        private void SecretaryAnnouncementListForm_Load(object sender, EventArgs e)
        {
            UpdateForm();
            if (_auth == PersonTypeEnum.Secretary) return;
            var lastColumnIndex = dgvAnnouncements.Columns.Count - 1;

            dgvAnnouncements.Columns[lastColumnIndex].HeaderText = string.Empty;
            foreach (DataGridViewRow row in dgvAnnouncements.Rows)
                row.Cells[lastColumnIndex].Style = CellStyle;
        }

        private void SetDgvAnnouncements()
        {
            dgvAnnouncements.Rows.Clear();
            foreach (var announcement in AnnouncementService.GetAll())
                dgvAnnouncements.Rows.Add(announcement.Id, announcement.Date.ToShortDateString(), announcement.Text);
        }

        public void UpdateForm() =>
            SetDgvAnnouncements();

        private void dgvAnnouncements_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_auth != PersonTypeEnum.Secretary) return;

            var senderGrid = (DataGridView)sender;
            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var id = (int)senderGrid.Rows[e.RowIndex].Cells[0].Value;

            var result = CrudHandler.AddOrUpdate(() =>
            {
                AnnouncementService.DeleteById(id);
            });
            MyMethods.ShowMessageBox(result);
            if (result.IsSuccess)
                SetDgvAnnouncements();
        }
    }
}
