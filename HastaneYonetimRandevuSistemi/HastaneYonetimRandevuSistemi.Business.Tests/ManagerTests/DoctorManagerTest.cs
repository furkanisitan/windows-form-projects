using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace HastaneYonetimRandevuSistemi.Business.Tests.ManagerTests
{
    [TestClass]
    public class DoctorManagerTest
    {
        private IDoctorService _doctorService;
        private IBranchService _branchService;

        [TestInitialize]
        public void TestInitialize()
        {
            _doctorService = InstanceFactory.GetInstance<IDoctorService>();
            _branchService = InstanceFactory.GetInstance<IBranchService>();
        }

        [TestMethod]
        public void Create_Database()
        {
            _doctorService.GetAll();
        }

        [TestMethod]
        public void Doctor_of_the_Branch_Should_Be_Updated_When_Update_Branch_of_the_Doctor()
        {
            var doctor = _doctorService.GetById(1);
            //var branch = _branchService.GetByIdWithDoctors(doctor.BranchId);

            //Console.WriteLine($"BranchId of Doctor => {doctor.BranchId}");
            //Console.WriteLine("-----Doctors of Branch-----");
            //foreach (var branchDoctor in branch.Doctors)
            //    Console.WriteLine($"Doctor Name: {branchDoctor.FirstName} {branchDoctor.LastName}, Id :{branchDoctor.Id}");

            doctor.BranchId = 2;
            _doctorService.Update(doctor);
            var branch = _branchService.GetByIdWithDoctors(1);

            //Console.WriteLine("----------------------------------");
            //Console.WriteLine($"BranchId of Doctor => {doctor.BranchId}");
            //Console.WriteLine("-----Doctors of Branch-----");
            foreach (var branchDoctor in branch.Doctors)
                Console.WriteLine($"Doctor Name: {branchDoctor.FirstName} {branchDoctor.LastName}, Id :{branchDoctor.Id}");

            //Assert.IsFalse(branch.Doctors.Select(x => x.Id).Contains(doctor.Id));
        }

    }
}
