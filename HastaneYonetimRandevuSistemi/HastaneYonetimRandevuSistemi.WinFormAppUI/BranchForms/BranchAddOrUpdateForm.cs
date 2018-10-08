using System.Windows.Forms;
using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.CustomMethods;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.ExceptionHandling;
using HastaneYonetimRandevuSistemi.WinFormAppUI.SecretaryQuickAccessForms;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.BranchForms
{
    public partial class BranchAddOrUpdateForm : Form
    {
        private static readonly IBranchService BranchService;

        private readonly Branch _branch;

        static BranchAddOrUpdateForm()
        {
            BranchService = InstanceFactory.GetInstance<IBranchService>();
        }

        public BranchAddOrUpdateForm(int? branchId = null)
        {
            _branch = branchId == null ? new Branch() : BranchService.GetById((int)branchId);
            InitializeComponent();
        }

        private void BranchAddOrUpdateForm_Load(object sender, System.EventArgs e)
        {
            if (_branch.Id == 0)
            {
                Text = @"Branş Ekle";
                btnUpdate.Text = @"Ekle";
                return;
            }
            SetBranchInfo();
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            var branch = GetBranchInstance();
            var result = CrudHandler.AddOrUpdate(() =>
            {
                if (branch.Id == 0)
                    BranchService.Add(branch);
                else
                    BranchService.Update(branch);
            });
            MyMethods.ShowMessageBox(result);
            if (!result.IsSuccess) return;
            Close();
            (Application.OpenForms[nameof(SecretaryBranchPanelForm)] as SecretaryBranchPanelForm)?.UpdateForm();
        }

        private Branch GetBranchInstance()
        {
            _branch.Name = tbBranchName.Text;
            return _branch;
        }

        private void SetBranchInfo()
        {
            tbBranchName.Text = _branch.Name;
        }
    }
}
