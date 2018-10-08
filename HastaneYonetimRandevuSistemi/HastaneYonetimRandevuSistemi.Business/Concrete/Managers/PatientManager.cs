using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation;
using HastaneYonetimRandevuSistemi.Core.Aspects.PostSharp.ValidationAspects;
using HastaneYonetimRandevuSistemi.DataAccess.Abstract;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Collections.Generic;

namespace HastaneYonetimRandevuSistemi.Business.Concrete.Managers
{
    class PatientManager : IPatientService
    {
        private readonly IPatientDal _patientDal;

        public PatientManager(IPatientDal patientDal)
        {
            _patientDal = patientDal;
        }

        public int GetId(string trIdentityNo, string password)
        {
            var patient = _patientDal.Get(x => string.Equals(x.TrIdentityNo, trIdentityNo) && string.Equals(x.Password, password));
            return patient?.Id ?? 0;
        }

        public Patient GetById(int id) =>
            _patientDal.Get(x => x.Id == id);

        public IEnumerable<Patient> GetAll() =>
            _patientDal.GetAll();

        [FluentValidationAspect(typeof(PatientValidator))]
        public void Add(Patient patient) => _patientDal.Add(patient);

        [FluentValidationAspect(typeof(PatientValidator))]
        public void Update(Patient patient) => _patientDal.Update(patient);
    }

}
