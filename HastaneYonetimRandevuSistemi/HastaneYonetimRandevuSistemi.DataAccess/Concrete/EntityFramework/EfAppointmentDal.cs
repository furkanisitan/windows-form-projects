using HastaneYonetimRandevuSistemi.Core.DataAccess.EntityFramework;
using HastaneYonetimRandevuSistemi.DataAccess.Abstract;
using HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework.Configuration;
using HastaneYonetimRandevuSistemi.Entities.ComplexTypes;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HastaneYonetimRandevuSistemi.DataAccess.Concrete.EntityFramework
{
    public class EfAppointmentDal : EfEntityRepositoryBase<Appointment, DatabaseContext>, IAppointmentDal
    {
        public ICollection<Appointment> GetAllWithPatient(Expression<Func<Appointment, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return (filter == null ? context.Set<Appointment>() : context.Set<Appointment>().Where(filter))
                    .Include(x => x.Patient).ToList();
            }
        }

        public ICollection<AppointmentDetail> GetAllAppointmentDetail(
            Expression<Func<Appointment, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                var appointments = filter == null ? context.Appointments : context.Appointments.Where(filter);
                var query = appointments
                    .Join(context.Doctors, a => a.DoctorId, d => d.Id, (a1, doctor) => new { a1, doctor })
                    .Join(context.Branches, a => a.doctor.BranchId, b => b.Id, (a2, branch) => new { a2, branch })
                    .GroupJoin(context.Patients, a => a.a2.a1.PatientId, p => p.Id, (a3, patient) => new { a3, patient })
                    .SelectMany(p => p.patient.DefaultIfEmpty(),
                        (x, y) => new AppointmentDetail
                        {
                            Id = x.a3.a2.a1.Id,
                            Date = x.a3.a2.a1.Date,
                            DoctorName = x.a3.a2.doctor.FirstName + " " + x.a3.a2.doctor.LastName,
                            BranchName = x.a3.branch.Name,
                            PatientName = y == null ? null : y.FirstName + " " + y.LastName,
                        });
                return query.OrderBy(x => x.Date).ToList();
            }
        }

        public AppointmentDetail GetAppointmentDetail(Expression<Func<Appointment, bool>> filter)
        {
            return GetAllAppointmentDetail(filter).FirstOrDefault();
        }
    }
}
