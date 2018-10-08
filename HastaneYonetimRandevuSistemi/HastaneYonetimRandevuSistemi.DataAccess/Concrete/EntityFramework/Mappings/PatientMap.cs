using HastaneYonetimRandevuSistemi.Entities.Concrete;

namespace HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Mappings
{
    class PatientMap : PersonMap<Patient>
    {
        public PatientMap()
        {
            Property(x => x.PhoneNumber).IsOptional().HasMaxLength(20);
        }
    }
}
