using FluentValidation;
using HastaneYonetimRandevuSistemi.Entities.Concrete;

namespace HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation
{
    class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(x => x.DoctorId).NotEmpty().OverridePropertyName("Doktor");
            RuleFor(x => x.Date).NotEmpty().OverridePropertyName("Tarih");
            RuleFor(x => x.DiseaseDescription).MinimumLength(20).When(x => x.PatientId.HasValue)
                .OverridePropertyName("Şikayet");
        }
    }
}
