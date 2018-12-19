using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation;
using HastaneYonetimRandevuSistemi.Core.Aspects.PostSharp.ValidationAspects;
using HastaneYonetimRandevuSistemi.DataAccess.Abstract;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Collections.Generic;
using HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation.Validators;

namespace HastaneYonetimRandevuSistemi.Business.Concrete.Managers
{
    class BranchManager : IBranchService
    {
        private readonly IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }

        public IEnumerable<Branch> GetAll() =>
            _branchDal.GetAll();

        public Branch GetById(int id) =>
            _branchDal.Get(x => x.Id == id);

        public Branch GetByIdWithDoctors(int id) =>
            _branchDal.GetWithDoctors(x => x.Id == id);

        [FluentValidationAspect(typeof(BranchValidator))]
        public void Add(Branch branch) =>
            _branchDal.Add(branch);

        [FluentValidationAspect(typeof(BranchValidator))]
        public void Update(Branch branch) =>
            _branchDal.Update(branch);
    }
}
