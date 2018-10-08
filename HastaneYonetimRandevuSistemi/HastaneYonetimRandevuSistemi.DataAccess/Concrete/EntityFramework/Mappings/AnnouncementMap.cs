using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Mappings
{
    class AnnouncementMap : EntityTypeConfiguration<Announcement>
    {
        public AnnouncementMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Date).IsRequired().HasColumnType("date");
            Property(x => x.Text).IsRequired();
        }
    }
}
