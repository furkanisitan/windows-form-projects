using HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HastaneYonetimRandevuSistemi.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EfAppointmentDalTest
    {
        private EfAppointmentDal _appointmentDal;

        [TestInitialize]
        public void TestInitialize()
        {
            _appointmentDal = new EfAppointmentDal();
        }

        [TestMethod]
        public void Get_All_AppointmentDetail()
        {
            var appointments = _appointmentDal.GetAllAppointmentDetail();
            var a = appointments.First();

        }

        [TestMethod]
        public void Get_All_AppointmentDetail_By_PatientId()
        {
            var appointments = _appointmentDal.GetAllAppointmentDetail(x => x.PatientId == 1);
            var a = appointments.First();
        }
    }
}
