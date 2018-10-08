using HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Configuration.SampleDatabases;
using HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Mappings;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Data.Entity;

namespace HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Configuration
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new SampleDatabase1());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnnouncementMap());
            modelBuilder.Configurations.Add(new AppointmentMap());
            modelBuilder.Configurations.Add(new BranchMap());
            modelBuilder.Configurations.Add(new DoctorMap());
            modelBuilder.Configurations.Add(new PatientMap());
            modelBuilder.Configurations.Add(new SecretaryMap());
        }
    }
}
