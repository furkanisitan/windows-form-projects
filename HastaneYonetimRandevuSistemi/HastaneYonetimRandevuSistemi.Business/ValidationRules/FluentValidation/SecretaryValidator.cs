using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation.HelperValidators;
using HastaneYonetimRandevuSistemi.Entities.Concrete;

namespace HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation
{
    class SecretaryValidator : PersonValidator<Secretary>
    {
        private static readonly ISecretaryService SecretaryService;

        static SecretaryValidator()
        {
            SecretaryService = InstanceFactory.GetInstance<ISecretaryService>();
        }

        public SecretaryValidator()
        {
            RuleFor(x => x.TrIdentityNo).IsUnique(SecretaryService.GetAll(), nameof(Secretary.Id));
        }
    }
}
