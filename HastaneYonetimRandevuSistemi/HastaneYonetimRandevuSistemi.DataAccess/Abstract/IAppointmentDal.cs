using HastaneYonetimRandevuSistemi.Core.DataAccess;
using HastaneYonetimRandevuSistemi.Entities.ComplexTypes;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HastaneYonetimRandevuSistemi.DataAccess.Abstract
{
    public interface IAppointmentDal : IEntityRepository<Appointment>
    {
        ICollection<Appointment> GetAllWithPatient(Expression<Func<Appointment, bool>> filter = null);
        ICollection<AppointmentDetail> GetAllAppointmentDetail(Expression<Func<Appointment, bool>> filter = null);
        AppointmentDetail GetAppointmentDetail(Expression<Func<Appointment, bool>> filter);
    }
}
