using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Collections.Generic;

namespace HastaneYonetimRandevuSistemi.Business.Abstract
{
    public interface IPatientService
    {
        int GetId(string trIdentityNo, string password);
        Patient GetById(int id);
        IEnumerable<Patient> GetAll();
        void Add(Patient patient);
        void Update(Patient patient);
    }
}
