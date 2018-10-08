using FluentValidation;
using HastaneYonetimRandevuSistemi.Entities.Concrete;

namespace HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation
{
    abstract class PersonValidator<TEntity> : AbstractValidator<TEntity> where TEntity : Person
    {
        protected PersonValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(30).OverridePropertyName("Ad");
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(30).OverridePropertyName("Soyad");
            RuleFor(x => x.TrIdentityNo).Matches(@"^[0-9]{11}$").WithMessage("Geçersiz TC Kimlik No!").OverridePropertyName("TC Kimlik No");
            RuleFor(x => x.Password).Length(4, 20).OverridePropertyName("Şifre");
        }
    }
}
