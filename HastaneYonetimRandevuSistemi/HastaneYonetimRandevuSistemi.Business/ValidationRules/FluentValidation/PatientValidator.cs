using FluentValidation;
using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation.HelperValidators;
using HastaneYonetimRandevuSistemi.Entities.Concrete;

namespace HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation
{
    class PatientValidator : PersonValidator<Patient>
    {
        private static readonly IPatientService PatientService;
        static PatientValidator()
        {
            PatientService = InstanceFactory.GetInstance<IPatientService>();
        }

        public PatientValidator()
        {
            RuleFor(x => x.PhoneNumber).Matches(@"^\(\d{3}\)\s\d{3}-\d{4}$").WithMessage("Geçersiz Telefon Numarası!").OverridePropertyName("Telefon");
            RuleFor(x => x.TrIdentityNo).IsUnique(PatientService.GetAll(), nameof(Patient.Id));
        }
    }
}
