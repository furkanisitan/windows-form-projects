using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Mappings
{
    class PersonMap<T> : EntityTypeConfiguration<T> where T : Person
    {
        public PersonMap()
        {
            HasKey(x => x.Id);
            HasIndex(x => x.TrIdentityNo).IsUnique().HasName("UK_TrIdentityNo");

            Property(x => x.FirstName).IsRequired().HasMaxLength(30);
            Property(x => x.LastName).IsRequired().HasMaxLength(30);
            Property(x => x.Password).IsRequired().HasMaxLength(20);
            Property(x => x.TrIdentityNo).IsRequired().HasMaxLength(11);
        }
    }
}
