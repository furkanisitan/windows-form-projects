using DevFramework.Core.Entities;
using System;

namespace HastaneYonetimRandevuSistemi.Entities.Concrete
{
    public class Appointment : IEntity
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int? PatientId { get; set; }
        public string DiseaseDescription { get; set; }
        public DateTime Date { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
