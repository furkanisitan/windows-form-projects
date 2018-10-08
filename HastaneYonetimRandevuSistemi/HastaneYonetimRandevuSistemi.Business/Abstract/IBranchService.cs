using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Collections.Generic;

namespace HastaneYonetimRandevuSistemi.Business.Abstract
{
    public interface IBranchService
    {
        IEnumerable<Branch> GetAll();
        Branch GetById(int id);
        Branch GetByIdWithDoctors(int id);
        void Add(Branch branch);
        void Update(Branch branch);
    }
}
