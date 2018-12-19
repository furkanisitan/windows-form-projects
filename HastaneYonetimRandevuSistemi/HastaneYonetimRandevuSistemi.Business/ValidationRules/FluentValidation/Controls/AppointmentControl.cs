using FluentValidation;
using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation.Controls
{
    public class AppointmentControl : AbstractValidator<Appointment>
    {
        private static readonly TimeSpan Start = new TimeSpan(8, 0, 0);
        private static readonly TimeSpan LaunchTimeStart = new TimeSpan(12, 0, 0);
        private static readonly TimeSpan LaunchTimeEnd = new TimeSpan(13, 0, 0);
        private static readonly TimeSpan End = new TimeSpan(17, 0, 0);
        private static readonly TimeSpan Interval = TimeSpan.FromMinutes(60);
        private static readonly int[] ValidMinutes = { 0, 15, 30, 45 };

        private static readonly IAppointmentService AppointmentService;
        private static readonly IDoctorService DoctorService;

        static AppointmentControl()
        {
            AppointmentService = InstanceFactory.GetInstance<IAppointmentService>();
            DoctorService = InstanceFactory.GetInstance<IDoctorService>();
        }

        public AppointmentControl()
        {

            RuleFor(x => x.Date).Must(d => IsWorkDate(d))
                .WithMessage("Lütfen iş günleri ve saatleri içinde bir tarih giriniz");

            RuleFor(x => x.Date.Minute).Must(m => IsValidMinute(m))
                .WithMessage("Her saatin 0,15,30 ve 45. dakikalarında randevu tanımlanabilir.");

            RuleFor(x => x).Must(x =>
                IsUnique(AppointmentService
                        .GetAllAppointmentTimeByDoctorAndDay(x.DoctorId, x.Date), x.Date.TimeOfDay) || IsUpdate(x.Id, x.Date.TimeOfDay))
                .WithMessage("Randevu daha önce tanımlanmış!");

            RuleFor(x => x).Must(x =>
                !IsThereWithinInterval(AppointmentService
                        .GetAllAppointmentTimeByPatientAndDay(x.PatientId ?? -1, x.Date), x.Date.TimeOfDay))
                .When(x => x.PatientId.HasValue)
                .WithMessage($"{Interval.TotalMinutes} dakika içinde yeni bir randevu alamazsınız.");

            RuleFor(x => x).Must(x => !AppointmentService.GetAllAppointmentTimeByPatientAndBranchAndDay(
                    x.PatientId ?? -1, DoctorService.GetById(x.DoctorId).BranchId, x.Date).Any())
                .When(x => x.PatientId.HasValue)
                .WithMessage("Aynı bölümden bir günde sadece tek randevu alınabilir");
        }

        private bool IsWorkDate(DateTime date) =>
            IsWorkDay(date.DayOfWeek) && IsWorkHour(date);

        private bool IsWorkDay(DayOfWeek day) =>
            !(day == DayOfWeek.Saturday || day == DayOfWeek.Sunday);

        private bool IsWorkHour(DateTime time) =>
            IsTimeBetween(time.TimeOfDay, Start, LaunchTimeStart) ||
            IsTimeBetween(time.TimeOfDay, LaunchTimeEnd, End);

        private bool IsTimeBetween(TimeSpan time, TimeSpan start, TimeSpan end, bool includeStart = true) =>
            includeStart ? time >= start && time < end : time > start && time < end;

        private bool IsValidMinute(int minute) =>
            ValidMinutes.Any(x => x == minute);

        private bool IsUnique(ICollection<TimeSpan> list, TimeSpan time) =>
         !list.Any(x => x.Equals(time));

        private bool IsUpdate(int id, TimeSpan time)
        {
            if (id == 0) return false;
            return AppointmentService.GetById(id).Date.TimeOfDay == time;
        }

        // 'Interval' değişkeni ile belirtilen dakika aralığında hastanın başka bir randevusu var mı?
        private bool IsThereWithinInterval(ICollection<TimeSpan> list, TimeSpan time)
        {
            var start = time.Subtract(Interval);
            var end = time.Add(Interval);
            return list.Any(x => IsTimeBetween(x, start, end, false));
        }

    }
}
