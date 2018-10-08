using FluentValidation;
using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation.HelperValidators;
using HastaneYonetimRandevuSistemi.Entities.Concrete;

namespace HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation
{
    class DoctorValidator : PersonValidator<Doctor>
    {
        private static readonly IDoctorService DoctorService;
        static DoctorValidator()
        {
            DoctorService = InstanceFactory.GetInstance<IDoctorService>();
        }

        public DoctorValidator()
        {
            RuleFor(x => x.TrIdentityNo).IsUnique(DoctorService.GetAll(), nameof(Doctor.Id));
            RuleFor(x => x.BranchId).GreaterThan(0);
        }
    }
}
