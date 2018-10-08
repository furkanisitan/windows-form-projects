using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation;
using HastaneYonetimRandevuSistemi.Core.Aspects.PostSharp.ValidationAspects;
using HastaneYonetimRandevuSistemi.DataAccess.Abstract;
using HastaneYonetimRandevuSistemi.Entities.ComplexTypes;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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

        public ICollection<AppointmentDetail> GetAllAppointmentDetail(Expression<Func<Appointment, bool>> filter = null) =>
            _appointmentDal.GetAllAppointmentDetail(filter);

        [FluentValidationAspect(typeof(AppointmentValidator))]
        public void Add(Appointment appointment) =>
            _appointmentDal.Add(appointment);

        [FluentValidationAspect(typeof(AppointmentValidator))]
        public void Update(Appointment appointment) =>
            _appointmentDal.Update(appointment);
    }
}
