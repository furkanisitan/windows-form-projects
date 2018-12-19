using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation.Validators;
using HastaneYonetimRandevuSistemi.Core.Aspects.PostSharp.ValidationAspects;
using HastaneYonetimRandevuSistemi.DataAccess.Abstract;
using HastaneYonetimRandevuSistemi.Entities.ComplexTypes;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation.Controls;

namespace HastaneYonetimRandevuSistemi.Business.Concrete.Managers
{
    class AppointmentManager : IAppointmentService
    {
        private readonly IAppointmentDal _appointmentDal;

        public AppointmentManager(IAppointmentDal appointmentDal)
        {
            _appointmentDal = appointmentDal;
        }

        public Appointment GetById(int id) =>
            _appointmentDal.Get(x => x.Id == id);

        public ICollection<Appointment> GetAllWithPatientByDoctorId(int doctorId) =>
            _appointmentDal.GetAllWithPatient(x => x.DoctorId == doctorId && x.PatientId != null);

        public AppointmentDetail GetAppointmentDetailById(int id) =>
            _appointmentDal.GetAppointmentDetail(x => x.Id == id);

        public ICollection<AppointmentDetail> GetAllAppointmentDetail(
                Expression<Func<Appointment, bool>> filter = null) =>
            _appointmentDal.GetAllAppointmentDetail(filter);

        public ICollection<TimeSpan> GetAllAppointmentTimeByDoctorAndDay(int doctorId, DateTime date) =>
            _appointmentDal.GetAllAppointmentTimeByFilter(x =>
                x.DoctorId == doctorId && DbFunctions.TruncateTime(x.Date) == date.Date);

        public ICollection<TimeSpan> GetAllAppointmentTimeByPatientAndDay(int patientId, DateTime date) =>
            _appointmentDal.GetAllAppointmentTimeByFilter(x =>
                x.PatientId == patientId && DbFunctions.TruncateTime(x.Date) == date.Date);

        public ICollection<TimeSpan> GetAllAppointmentTimeByPatientAndBranchAndDay(
                int patientId, int branchId, DateTime date) =>
            _appointmentDal.GetAllAppointmentTimeByFilter(x =>
                x.PatientId == patientId && x.Doctor.BranchId == branchId &&
                DbFunctions.TruncateTime(x.Date) == date.Date);

        [FluentValidationAspect(typeof(AppointmentValidator))]
        [FluentValidationAspect(typeof(AppointmentControl))]
        public void Add(Appointment appointment) =>
            _appointmentDal.Add(appointment);

        [FluentValidationAspect(typeof(AppointmentValidator))]
        [FluentValidationAspect(typeof(AppointmentControl))]
        public void Update(Appointment appointment) =>
            _appointmentDal.Update(appointment);
    }
}
