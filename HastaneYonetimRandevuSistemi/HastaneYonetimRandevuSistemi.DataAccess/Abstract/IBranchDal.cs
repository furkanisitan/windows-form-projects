using HastaneYonetimRandevuSistemi.Core.DataAccess;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System;
using System.Linq.Expressions;

namespace HastaneYonetimRandevuSistemi.DataAccess.Abstract
{
    public interface IBranchDal : IEntityRepository<Branch>
    {
        Branch GetWithDoctors(Expression<Func<Branch, bool>> filter = null);
    }
}
