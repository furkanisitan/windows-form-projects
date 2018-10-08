using HastaneYonetimRandevuSistemi.Core.DataAccess;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HastaneYonetimRandevuSistemi.DataAccess.Abstract
{
    public interface IDoctorDal : IEntityRepository<Doctor>
    {
        ICollection<Doctor> GetAllWithBranch(Expression<Func<Doctor, bool>> filter = null);
    }
}
