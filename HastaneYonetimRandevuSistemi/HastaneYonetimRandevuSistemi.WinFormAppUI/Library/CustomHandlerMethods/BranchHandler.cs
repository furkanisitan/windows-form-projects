using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.Library.CustomHandlerMethods
{
    public class BranchHandler
    {
        private static readonly IDoctorService DoctorService;

        private readonly IEnumerable<Doctor> _doctors;

        static BranchHandler()
        {
            DoctorService = InstanceFactory.GetInstance<IDoctorService>();
        }

        public BranchHandler()
        {
            _doctors = DoctorService.GetAll();
        }

        public void OnComboBoxIndexChanged(object sender, ComboBox cbDoctors)
        {
            try
            {
                var branchId = (int)((ComboBox)sender).SelectedValue;
                SetCbDoctors(_doctors.Where(x => x.BranchId == branchId), cbDoctors);
            }
            catch
            {
                // ignored
            }
        }
        private static void SetCbDoctors(IEnumerable<Doctor> doctors, ComboBox cbDoctors)
        {
            cbDoctors.Text = string.Empty;
            cbDoctors.DataSource = doctors.Select(x => new { x.Id, FullName = $"{x.FirstName} {x.LastName}" }).ToList();
            cbDoctors.DisplayMember = "FullName";
            cbDoctors.ValueMember = "Id";
        }
    }
}
