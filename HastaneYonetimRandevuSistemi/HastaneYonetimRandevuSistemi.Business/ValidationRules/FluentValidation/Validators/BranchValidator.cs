using FluentValidation;
using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation.HelperValidators;
using HastaneYonetimRandevuSistemi.Entities.Concrete;

namespace HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation.Validators
{
    class BranchValidator : AbstractValidator<Branch>
    {
        private static readonly IBranchService BranchService = InstanceFactory.GetInstance<IBranchService>();

        public BranchValidator()
        {
            RuleFor(x => x.Name).NotEmpty().IsUnique(BranchService.GetAll(), nameof(Branch.Id));
        }
    }
}
