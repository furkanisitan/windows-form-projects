using System.Windows.Forms;
using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.CustomMethods;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.ExceptionHandling;
using HastaneYonetimRandevuSistemi.WinFormAppUI.SecretaryQuickAccessForms;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.AnnouncementForms
{
    public partial class AnnouncementUpdateForm : Form
    {
        private static readonly IAnnouncementService AnnouncementService;

        private readonly Announcement _announcement;

        static AnnouncementUpdateForm()
        {
            AnnouncementService = InstanceFactory.GetInstance<IAnnouncementService>();
        }

        public AnnouncementUpdateForm(int id)
        {
            _announcement = AnnouncementService.GetById(id);
            InitializeComponent();
        }

        private void AnnouncementUpdateForm_Load(object sender, System.EventArgs e)
        {
            SetAnnouncementInfo();
        }

        private void btnCreateAnnouncement_Click(object sender, System.EventArgs e)
        {
            var announcement = GetAnnouncementInstance();
            var result = CrudHandler.AddOrUpdate(() => AnnouncementService.Update(announcement));
            MyMethods.ShowMessageBox(result);
            if (!result.IsSuccess) return;
            Close();
            (Application.OpenForms[nameof(SecretaryAnnouncementListForm)] as SecretaryAnnouncementListForm)?.UpdateForm();
        }

        private Announcement GetAnnouncementInstance()
        {
            _announcement.Text = richTextBox1.Text;
            return _announcement;
        }

        private void SetAnnouncementInfo()
        {
            richTextBox1.Text = _announcement.Text;
        }
    }
}
