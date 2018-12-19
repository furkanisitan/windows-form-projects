using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation;
using HastaneYonetimRandevuSistemi.Core.Aspects.PostSharp.ValidationAspects;
using HastaneYonetimRandevuSistemi.DataAccess.Abstract;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Collections.Generic;
using HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation.Validators;

namespace HastaneYonetimRandevuSistemi.Business.Concrete.Managers
{
    class DoctorManager : IDoctorService
    {
        private readonly IDoctorDal _doctorDal;

        public DoctorManager(IDoctorDal doctorDal)
        {
            _doctorDal = doctorDal;
        }

        public int GetId(string trIdentityNo, string password)
        {
            var doctor = _doctorDal.Get(x => string.Equals(x.TrIdentityNo, trIdentityNo) && string.Equals(x.Password, password));
            return doctor?.Id ?? 0;
        }

        public IEnumerable<Doctor> GetAll() => _doctorDal.GetAll();

        public IEnumerable<Doctor> GetAllWithBranch() =>
            _doctorDal.GetAllWithBranch();

        public Doctor GetById(int id) =>
            _doctorDal.Get(x => x.Id == id);

        [FluentValidationAspect(typeof(DoctorValidator))]
        public void Add(Doctor doctor) =>
            _doctorDal.Add(doctor);

        [FluentValidationAspect(typeof(DoctorValidator))]
        public void Update(Doctor doctor) =>
            _doctorDal.Update(doctor);
    }
}
