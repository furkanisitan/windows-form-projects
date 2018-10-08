using System.Windows.Forms;
using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.WinFormAppUI.AnnouncementForms;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.Enums;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.SecretaryQuickAccessForms
{
    public partial class SecretaryAnnouncementListForm : Form
    {
        private static readonly IAnnouncementService AnnouncementService;
        private readonly PersonTypeEnum _auth;

        static SecretaryAnnouncementListForm()
        {
            AnnouncementService = InstanceFactory.GetInstance<IAnnouncementService>();
        }

        public SecretaryAnnouncementListForm(PersonTypeEnum auth)
        {
            _auth = auth;
            InitializeComponent();
        }

        private void SecretaryAnnouncementListForm_Load(object sender, System.EventArgs e) =>
            UpdateForm();

        private void dgvAnnouncements_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_auth != PersonTypeEnum.Secretary) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var row = dgvAnnouncements.Rows[e.RowIndex];
            new AnnouncementUpdateForm((int)row.Cells["Id"].Value).ShowDialog();
        }

        private void SetDgvAnnouncements()
        {
            dgvAnnouncements.Rows.Clear();
            foreach (var announcement in AnnouncementService.GetAll())
                dgvAnnouncements.Rows.Add(announcement.Id, announcement.Date.ToShortDateString(), announcement.Text);
        }

        public void UpdateForm() =>
            SetDgvAnnouncements();
    }
}
