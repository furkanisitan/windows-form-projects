using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Collections.Generic;

namespace HastaneYonetimRandevuSistemi.Business.Abstract
{
    public interface IDoctorService
    {
        int GetId(string trIdentityNo, string password);
        IEnumerable<Doctor> GetAll();
        IEnumerable<Doctor> GetAllWithBranch();
        Doctor GetById(int id);
        void Add(Doctor doctor);
        void Update(Doctor doctor);
    }
}
