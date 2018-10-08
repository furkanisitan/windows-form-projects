using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Collections.Generic;

namespace HastaneYonetimRandevuSistemi.Business.Abstract
{
    public interface ISecretaryService
    {
        int GetId(string trIdentityNo, string password);
        Secretary GetById(int id);
        IEnumerable<Secretary> GetAll();
        void Update(Secretary secretary);
    }
}
