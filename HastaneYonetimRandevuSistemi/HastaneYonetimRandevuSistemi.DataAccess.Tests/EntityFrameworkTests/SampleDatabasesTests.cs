using HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HastaneYonetimRandevuSistemi.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class SampleDatabasesTests
    {
        [TestMethod]
        public void Create_SampleDatabase1()
        {
            var doctorDal = new EfDoctorDal();
            var doctors = doctorDal.GetAll();

            Assert.IsTrue(doctors.Any());
        }
    }
}
