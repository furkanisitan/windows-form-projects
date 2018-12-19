using FluentValidation;
using HastaneYonetimRandevuSistemi.Entities.Concrete;

namespace HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation.Validators
{
    class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(x => x.DoctorId).NotEmpty().OverridePropertyName("Doktor");
            RuleFor(x => x.Date).NotEmpty().OverridePropertyName("Tarih");
        }
    }
}
