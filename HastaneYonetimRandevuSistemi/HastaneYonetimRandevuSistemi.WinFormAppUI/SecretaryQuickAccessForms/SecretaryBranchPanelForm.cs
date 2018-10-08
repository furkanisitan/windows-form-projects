using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using System.Windows.Forms;
using HastaneYonetimRandevuSistemi.WinFormAppUI.BranchForms;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.SecretaryQuickAccessForms
{
    public partial class SecretaryBranchPanelForm : Form
    {
        private static readonly IBranchService BranchService;

        static SecretaryBranchPanelForm()
        {
            BranchService = InstanceFactory.GetInstance<IBranchService>();
        }

        public SecretaryBranchPanelForm()
        {
            InitializeComponent();
        }

        private void SecretaryBranchPanelForm_Load(object sender, System.EventArgs e) =>
            UpdateForm();

        // update
        private void dgvBranches_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var branchId = (int)dgvBranches.Rows[e.RowIndex].Cells["Id"].Value;
            new BranchAddOrUpdateForm(branchId).ShowDialog();
        }

        // create
        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            new BranchAddOrUpdateForm().ShowDialog();

        private void SetDgvBranches()
        {
            dgvBranches.Rows.Clear();
            foreach (var branch in BranchService.GetAll())
                dgvBranches.Rows.Add(branch.Id, branch.Name);
        }

        public void UpdateForm() =>
            SetDgvBranches();
    }
}
