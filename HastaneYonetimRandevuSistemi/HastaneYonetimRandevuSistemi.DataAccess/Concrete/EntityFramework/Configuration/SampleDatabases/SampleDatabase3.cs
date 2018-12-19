using System;
using Bogus;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;

namespace HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Configuration.SampleDatabases
{
    class SampleDatabase3 : DropCreateDatabaseAlways<DatabaseContext>
    {
        private const int DoctorCount = 30, PatientCount = 50, AnnouncementCount = 10, SecretaryCount = 4, MaxAppCountOfADoctor = 5, MaxAppCountOfAPatient = 3;
        private readonly Faker _faker = new Faker("tr");

        public override void InitializeDatabase(DatabaseContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , $"ALTER DATABASE [{context.Database.Connection.Database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            base.InitializeDatabase(context);
        }

        protected override void Seed(DatabaseContext context)
        {
            // announcements
            var announcementIds = 0;
            var announcements = new Faker<Announcement>("tr")
                .RuleFor(x => x.Id, f => announcementIds++)
                .RuleFor(x => x.Text, f => f.Lorem.Sentence())
                .RuleFor(x => x.Date, f => f.Date.Past());
            context.Announcements.AddRange(announcements.Generate(AnnouncementCount));

            // secretaries
            var testSecretary = new Secretary { FirstName = "Test", LastName = "Secretary", TrIdentityNo = "33333333333", Password = "1234" };

            var secretaryIds = 0;
            var secretaries = new Faker<Secretary>("tr")
                .RuleFor(x => x.Id, f => secretaryIds++)
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.TrIdentityNo, f => f.Random.ReplaceNumbers($"1{secretaryIds}{new string('#', 10 - GetIntegerDigitCount(secretaryIds))}"))
                .RuleFor(x => x.Password, f => f.Internet.Password(8));

            context.Secretaries.Add(testSecretary);
            context.Secretaries.AddRange(secretaries.Generate(SecretaryCount));

            // branches
            var branches = new List<Branch>
            {
                new Branch { Name = "Ağız, Diş ve Çene Cerrahisi" },
                new Branch { Name = "Beyin Ve Sinir Cerrahisi" },
                new Branch { Name = "Diş Hekimliği" },
                new Branch { Name = "Genel Cerrahi" },
                new Branch { Name = "Göz Hastalıkları" },
                new Branch { Name = "Kalp ve Damar Cerrahisi" },
                new Branch { Name = "Kulak Burun Boğaz Hastalıkları" },
                new Branch { Name = "Nöroloji"},
                new Branch { Name = "Ortopedi ve Travmatoloji" },
                new Branch { Name = "Ruh Sağlığı ve Hastalıkları" }
            };
            context.Branches.AddRange(branches);

            // doctors
            var doctorIds = 0;
            var testDoctor = new Faker<Doctor>("tr")
                .RuleFor(x => x.Id, f => doctorIds++)
                .RuleFor(x => x.FirstName, f => "Test")
                .RuleFor(x => x.LastName, f => "Doctor")
                .RuleFor(x => x.TrIdentityNo, f => "22222222222")
                .RuleFor(x => x.Password, f => "1234")
                .RuleFor(x => x.Branch, f => branches[f.Random.Number(branches.Count - 1)])
                .RuleFor(x => x.Appointments, f => CreateAppointmentListForOnlyDoctor(f.Random.Number(MaxAppCountOfADoctor)));

            var doctors = new Faker<Doctor>("tr")
                .RuleFor(x => x.Id, f => doctorIds++)
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.TrIdentityNo, f => f.Random.ReplaceNumbers($"3{doctorIds}{new string('#', 10 - GetIntegerDigitCount(doctorIds))}"))
                .RuleFor(x => x.Password, f => f.Internet.Password(8))
                .RuleFor(x => x.Branch, f => branches[f.Random.Number(branches.Count - 1)])
                .RuleFor(x => x.Appointments, f => CreateAppointmentListForOnlyDoctor(f.Random.Number(MaxAppCountOfADoctor)));

            context.Doctors.AddRange(doctors.Generate(DoctorCount));
            context.Doctors.AddRange(testDoctor.Generate(1));

            // patients
            var patientIds = 0;
            var testPatient = new Faker<Patient>("tr")
                .RuleFor(x => x.Id, f => patientIds++)
                .RuleFor(x => x.FirstName, f => "Test")
                .RuleFor(x => x.LastName, f => "Patient")
                .RuleFor(x => x.TrIdentityNo, f => "11111111111")
                .RuleFor(x => x.PhoneNumber, f => "(535) 505-5555")
                .RuleFor(x => x.Password, f => "1234")
                .RuleFor(x => x.Appointments, f => GetAppointmentListForPatient());

            var patients = new Faker<Patient>("tr")
                .RuleFor(x => x.Id, f => patientIds++)
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.TrIdentityNo, f => f.Random.ReplaceNumbers($"2{patientIds}{new string('#', 10 - GetIntegerDigitCount(patientIds))}"))
                .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber("(###) ###-####"))
                .RuleFor(x => x.Password, f => f.Internet.Password(8))
                .RuleFor(x => x.Appointments, f => GetAppointmentListForPatient());


            context.Patients.AddRange(testPatient.Generate(1));
            context.Patients.AddRange(patients.Generate(PatientCount));

            context.SaveChanges();
        }

        private ICollection<Appointment> GetAppointmentListForPatient() =>
             CreateAppointmentListForPatient(_faker.Random.Number(MaxAppCountOfAPatient))
                .Concat(CreateAppointmentListForPatient(_faker.Random.Number(MaxAppCountOfAPatient), true)).ToList();


        private ICollection<Appointment> CreateAppointmentListForPatient(int size, bool isFuture = false)
        {
            var futureOrPast = isFuture ? 1 : -1;
            var date = CreateWorkDateTime(null, isFuture);
            var list = new List<Appointment>(size);

            for (var i = 0; i < size; i++)
            {
                if (IsNonWorkDay(date.DayOfWeek))
                    date = date.AddDays(2 * futureOrPast);
                list.Add(new Appointment { Date = date, DiseaseDescription = _faker.Lorem.Sentence(), DoctorId = _faker.Random.Number(1, DoctorCount) });
                date = CreateWorkDateTime(date.AddDays(1 * futureOrPast), isFuture);
            }
            return list;
        }

        private ICollection<Appointment> CreateAppointmentListForOnlyDoctor(int size)
        {
            var dateTimeString = $"{DateTime.Now.AddDays(1).ToShortDateString()} 10:00:00";
            var date = DateTime.Parse(dateTimeString, CultureInfo.CurrentCulture);
            var list = new List<Appointment>(size);

            for (var i = 0; i < size; i++)
            {
                if (IsNonWorkDay(date.DayOfWeek))
                    date = date.AddDays(2);

                if (!IsWorkHour(date))
                {
                    date = date.AddMinutes(60);
                    if (!IsWorkHour(date))
                        break;
                }
                list.Add(new Appointment { Date = date, DiseaseDescription = _faker.Lorem.Sentence() });
                date = date.AddDays(i % 2 == 0 ? 1 : -1).AddMinutes(30);
            }
            return list;
        }

        private static readonly TimeSpan Start = new TimeSpan(8, 0, 0);
        private static readonly TimeSpan LaunchTimeStart = new TimeSpan(12, 0, 0);
        private static readonly TimeSpan LaunchTimeEnd = new TimeSpan(13, 0, 0);
        private static readonly TimeSpan End = new TimeSpan(17, 0, 0);

        private bool IsWorkHour(DateTime time) =>
            IsTimeBetween(time.TimeOfDay, Start, LaunchTimeStart) ||
            IsTimeBetween(time.TimeOfDay, LaunchTimeEnd, End);

        private bool IsTimeBetween(TimeSpan time, TimeSpan start, TimeSpan end, bool includeStart = true) =>
            includeStart ? time >= start && time < end : time > start && time < end;

        private bool IsNonWorkDay(DayOfWeek day) =>
            day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;

        private static readonly int[] ValidMinutes = { 0, 15, 30, 45 };
        private static readonly int[] ValidHours = { 8, 9, 10, 11, 13, 14, 15, 16 };

        private DateTime CreateWorkDateTime(DateTime? dateTime = null, bool isFuture = false)
        {
            var futureOrPast = isFuture ? 1 : -1;
            dateTime = dateTime ?? DateTime.Now.AddDays(10 * futureOrPast);
            var dateTimeString = $"{dateTime.Value.ToShortDateString()} " +
                                 $"{ValidHours[_faker.Random.Number(ValidHours.Length - 1)]}:{ValidMinutes[_faker.Random.Number(ValidMinutes.Length - 1)]}:00";
            var date = DateTime.Parse(dateTimeString, CultureInfo.CurrentCulture);
            if (IsNonWorkDay(date.DayOfWeek))
                date = date.AddDays(2 * futureOrPast);
            return date;
        }

        private int GetIntegerDigitCount(int number) =>
             (int)Math.Floor(Math.Log10(number) + 1);
    }
}
