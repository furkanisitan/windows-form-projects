using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Mappings
{
    class BranchMap : EntityTypeConfiguration<Branch>
    {
        public BranchMap()
        {
            HasKey(x => x.Id);
            HasIndex(x => x.Name).IsUnique().HasName("UK_Name_Branches");

            Property(x => x.Name).IsRequired().HasColumnType("nvarchar");
        }
    }
}
