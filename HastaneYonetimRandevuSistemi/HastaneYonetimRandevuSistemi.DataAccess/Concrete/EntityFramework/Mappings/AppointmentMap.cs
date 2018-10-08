using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Mappings
{
    class AppointmentMap : EntityTypeConfiguration<Appointment>
    {
        public AppointmentMap()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Doctor).WithMany(d => d.Appointments).HasForeignKey(x => x.DoctorId);
            HasOptional(x => x.Patient).WithMany(p => p.Appointments).HasForeignKey(x => x.PatientId);

            Property(x => x.DiseaseDescription).IsOptional();
            Property(x => x.Date).IsRequired();
        }
    }
}
