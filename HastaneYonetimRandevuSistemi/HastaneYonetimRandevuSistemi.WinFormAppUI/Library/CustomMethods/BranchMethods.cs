using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using System.Linq;
using System.Windows.Forms;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.Library.CustomMethods
{
    public class BranchMethods
    {
        private static readonly IBranchService BranchService;

        static BranchMethods()
        {
            BranchService = InstanceFactory.GetInstance<IBranchService>();
        }

        public static void SetComboBox(ComboBox comboBox)
        {
            comboBox.DataSource = BranchService.GetAll().ToList();
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Id";
        }
    }
}
