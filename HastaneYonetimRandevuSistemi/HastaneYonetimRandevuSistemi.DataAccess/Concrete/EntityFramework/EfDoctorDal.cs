using HastaneYonetimRandevuSistemi.Core.DataAccess.EntityFramework;
using HastaneYonetimRandevuSistemi.DataAccess.Abstract;
using HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Configuration;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework
{
    public class EfDoctorDal : EfEntityRepositoryBase<Doctor, DatabaseContext>, IDoctorDal
    {
        public ICollection<Doctor> GetAllWithBranch(Expression<Func<Doctor, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return (filter == null ? context.Set<Doctor>() : context.Set<Doctor>().Where(filter))
                    .Include(x => x.Branch).ToList();
            }
        }
    }
}
