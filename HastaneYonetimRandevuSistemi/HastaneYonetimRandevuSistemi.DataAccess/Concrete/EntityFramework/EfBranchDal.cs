using HastaneYonetimRandevuSistemi.Core.DataAccess.EntityFramework;
using HastaneYonetimRandevuSistemi.DataAccess.Abstract;
using HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Configuration;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework
{
    public class EfBranchDal : EfEntityRepositoryBase<Branch, DatabaseContext>, IBranchDal
    {
        public Branch GetWithDoctors(Expression<Func<Branch, bool>> filter)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Branch>().Include(x => x.Doctors).SingleOrDefault(filter);
            }
        }
    }
}
