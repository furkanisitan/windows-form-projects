using HastaneYonetimRandevuSistemi.Core.DataAccess.EntityFramework;
using HastaneYonetimRandevuSistemi.DataAccess.Abstract;
using HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Configuration;
using HastaneYonetimRandevuSistemi.Entities.Concrete;

namespace HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework
{
    public class EfSecretaryDal : EfEntityRepositoryBase<Secretary, DatabaseContext>, ISecretaryDal
    {
    }
}
