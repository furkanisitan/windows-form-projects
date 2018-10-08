using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Collections.Generic;
using System.Data.Entity;

namespace HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Configuration.SampleDatabases
{
    class SampleDatabase2 : DropCreateDatabaseAlways<DatabaseContext>
    {
        public override void InitializeDatabase(DatabaseContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , $"ALTER DATABASE [{context.Database.Connection.Database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            base.InitializeDatabase(context);
        }

        protected override void Seed(DatabaseContext context)
        {
            var branches = new List<Branch>
            {
                new Branch {Name = "Branş 1"},
                new Branch {Name = "Branş 2"},
            };

            var doctors = new List<Doctor>
            {
                new Doctor{FirstName = "FirstName 1", LastName = "LastName 1", Branch = branches[0], Password = "1234", TrIdentityNo = "11111111111"},
                new Doctor{FirstName = "FirstName 2", LastName = "LastName 2", Branch = branches[1], Password = "1234", TrIdentityNo = "11111111111"},
                new Doctor{FirstName = "FirstName 3", LastName = "LastName 3", Branch = branches[0], Password = "1234", TrIdentityNo = "11111111111"}
            };
            context.Doctors.AddRange(doctors);
            context.SaveChanges();
        }
    }
}
