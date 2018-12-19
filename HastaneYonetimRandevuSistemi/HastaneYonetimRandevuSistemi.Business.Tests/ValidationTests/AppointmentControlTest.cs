using HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation.Controls;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace HastaneYonetimRandevuSistemi.Business.Tests.ValidationTests
{
    [TestClass]
    public class AppointmentControlTest
    {
        private AppointmentControl _appointmentControl;

        [TestInitialize]
        public void TestInitialize()
        {
            _appointmentControl = new AppointmentControl();
        }

        [TestMethod]
        public void Should_have_error_when_day_of_the_Date_is_not_workday()
        {
            var appointment = new Appointment
            {
                Id = 100,
                Date = new DateTime(2018, 12, 15, 13, 0, 0),   // Hafta sonu 
                DoctorId = 1,
                DiseaseDescription = "Hastalık"
            };
            var res = _appointmentControl.Validate(appointment);
            Assert.IsTrue(res.Errors.Any());                    // Hata bekleniyor
        }

        [TestMethod]
        public void Should_have_error_when_hour_of_the_Date_is_not_workhour()
        {
            var appointment = new Appointment
            {
                Id = 100,
                Date = new DateTime(2018, 12, 14, 12, 30, 0),   // Hafta içi / Öğle arası
                DoctorId = 1,
                DiseaseDescription = "Hastalık"
            };
            var res = _appointmentControl.Validate(appointment);
            Assert.IsTrue(res.Errors.Any());                    // Hata bekleniyor
        }

        [TestMethod]
        public void Should_have_error_when_minute_of_the_Date_is_not_valid_minute()
        {
            var appointment = new Appointment
            {
                Id = 100,
                Date = new DateTime(2018, 12, 14, 10, 29, 0),   // Hafta içi / Öğle arası
                DoctorId = 1,
                DiseaseDescription = "Hastalık"
            };
            var res = _appointmentControl.Validate(appointment);
            Assert.IsTrue(res.Errors.Any());                    // Hata bekleniyor
        }


    }
}
