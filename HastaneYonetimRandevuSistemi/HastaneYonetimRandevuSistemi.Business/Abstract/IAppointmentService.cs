using HastaneYonetimRandevuSistemi.Entities.ComplexTypes;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HastaneYonetimRandevuSistemi.Business.Abstract
{
    public interface IAppointmentService
    {
        Appointment GetById(int id);
        ICollection<Appointment> GetAllWithPatientByDoctorId(int doctorId);
        AppointmentDetail GetAppointmentDetailById(int id);
        ICollection<AppointmentDetail> GetAllAppointmentDetail(Expression<Func<Appointment, bool>> filter = null);
        ICollection<TimeSpan> GetAllAppointmentTimeByDoctorAndDay(int doctorId, DateTime date);
        ICollection<TimeSpan> GetAllAppointmentTimeByPatientAndDay(int patientId, DateTime date);
        ICollection<TimeSpan> GetAllAppointmentTimeByPatientAndBranchAndDay(int patientId, int branchId, DateTime date);
        void Add(Appointment appointment);
        void Update(Appointment appointment);
    }
}
