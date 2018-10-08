using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation;
using HastaneYonetimRandevuSistemi.Core.Aspects.PostSharp.ValidationAspects;
using HastaneYonetimRandevuSistemi.DataAccess.Abstract;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Collections.Generic;

namespace HastaneYonetimRandevuSistemi.Business.Concrete.Managers
{
    class SecretaryManager : ISecretaryService
    {
        private readonly ISecretaryDal _secretaryDal;

        public SecretaryManager(ISecretaryDal secretaryDal)
        {
            _secretaryDal = secretaryDal;
        }

        public int GetId(string trIdentityNo, string password)
        {
            var secretary = _secretaryDal.Get(x => string.Equals(x.TrIdentityNo, trIdentityNo) && string.Equals(x.Password, password));
            return secretary?.Id ?? 0;
        }

        public Secretary GetById(int id) =>
            _secretaryDal.Get(x => x.Id == id);

        public IEnumerable<Secretary> GetAll() =>
            _secretaryDal.GetAll();

        [FluentValidationAspect(typeof(SecretaryValidator))]
        public void Update(Secretary secretary) =>
            _secretaryDal.Update(secretary);
    }
}
