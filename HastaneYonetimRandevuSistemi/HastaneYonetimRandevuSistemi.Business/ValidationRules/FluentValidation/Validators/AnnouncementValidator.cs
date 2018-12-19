using FluentValidation;
using HastaneYonetimRandevuSistemi.Entities.Concrete;

namespace HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation.Validators
{
    class AnnouncementValidator : AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Text).NotEmpty().OverridePropertyName("Duyuru");
        }
    }
}
