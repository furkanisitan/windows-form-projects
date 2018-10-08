using Bogus;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Configuration.SampleDatabases
{
    class SampleDatabase1 : DropCreateDatabaseAlways<DatabaseContext>
    {
        public override void InitializeDatabase(DatabaseContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , $"ALTER DATABASE [{context.Database.Connection.Database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            base.InitializeDatabase(context);
        }

        protected override void Seed(DatabaseContext context)
        {
            // add branches
            var branches = new List<Branch>();
            for (var i = 0; i < 5; i++)
                branches.Add(new Branch { Name = $"Branş {i + 1}" });
            context.Branches.AddRange(branches);
            context.Branches.Add(new Branch { Name = "Empty Branch" });
            context.SaveChanges();

            var doctorIds = 0;
            var doctors = new Faker<Doctor>("tr")
                .RuleFor(x => x.Id, f => doctorIds++)
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.TrIdentityNo, f => f.Random.ReplaceNumbers("###########"))
                .RuleFor(x => x.Password, f => f.Internet.Password(8))
                .RuleFor(x => x.Branch, f => branches[f.Random.Number(branches.Count - 1)]);

            var d = new Doctor { FirstName = "doctor", LastName = "doctor", TrIdentityNo = "12345678999", Password = "1234", BranchId = 1 };
            context.Doctors.Add(d);
            context.Doctors.AddRange(doctors.Generate(10));
            context.SaveChanges();

            var patientIds = 0;
            var patients = new Faker<Patient>("tr")
                .RuleFor(x => x.Id, f => patientIds++)
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.TrIdentityNo, f => f.Random.ReplaceNumbers("###########"))
                .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber("(###) ###-####"))
                .RuleFor(x => x.Password, f => f.Internet.Password(8));

            var p = new Patient { FirstName = "patient", LastName = "patient", TrIdentityNo = "12345678998", PhoneNumber = "(111) 111-1111", Password = "1234" };
            context.Patients.Add(p);
            context.Patients.AddRange(patients.Generate(10));
            context.SaveChanges();

            var secretaryIds = 0;
            var secretaries = new Faker<Secretary>("tr")
                .RuleFor(x => x.Id, f => secretaryIds++)
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.TrIdentityNo, f => f.Random.ReplaceNumbers("###########"))
                .RuleFor(x => x.Password, f => f.Internet.Password(8));

            var secretary = new Secretary { FirstName = "secretary", LastName = "secretary", TrIdentityNo = "12345678997", Password = "1234" };
            context.Secretaries.Add(secretary);
            context.Secretaries.AddRange(secretaries.Generate(5));
            context.SaveChanges();

            var appointmentIds = 0;
            var appointments = new Faker<Appointment>("tr")
                .RuleFor(x => x.Id, f => appointmentIds++)
                .RuleFor(x => x.Date, f => f.Date.Future());

            // random patient appointments
            var patientList = context.Patients.ToList();
            var doctorList = context.Doctors.ToList();
            var random = new Random();

            var faker = new Faker("tr");

            for (var i = 0; i < 50; i++)
            {
                var appointment = appointments.Generate();
                appointment.Patient = i % 2 == 0 ? patientList[random.Next(patientList.Count)] : null;
                var doctor = doctorList[random.Next(doctorList.Count)];
                appointment.Doctor = doctor;
                appointment.DiseaseDescription =
                    appointment.Patient == null ? null : faker.Lorem.Paragraph();

                context.Appointments.Add(appointment);
            }
            context.SaveChanges();

            var announcementIds = 0;
            var announcements = new Faker<Announcement>("tr")
                .RuleFor(x => x.Id, f => announcementIds++)
                .RuleFor(x => x.Text, f => f.Lorem.Sentence())
                .RuleFor(x => x.Date, f => f.Date.Past());
            context.Announcements.AddRange(announcements.Generate(10));
            context.SaveChanges();
        }
    }
}
