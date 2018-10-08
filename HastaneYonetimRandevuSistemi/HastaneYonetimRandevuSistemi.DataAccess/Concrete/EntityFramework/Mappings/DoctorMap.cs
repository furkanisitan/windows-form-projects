using HastaneYonetimRandevuSistemi.Entities.Concrete;

namespace HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Mappings
{
    class DoctorMap : PersonMap<Doctor>
    {
        public DoctorMap()
        {
            HasRequired(x => x.Branch).WithMany(b => b.Doctors).HasForeignKey(x => x.BranchId);
        }
    }
}
