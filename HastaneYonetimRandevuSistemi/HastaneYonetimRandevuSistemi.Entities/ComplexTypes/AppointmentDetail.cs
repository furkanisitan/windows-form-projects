using System;

namespace HastaneYonetimRandevuSistemi.Entities.ComplexTypes
{
    public class AppointmentDetail
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string BranchName { get; set; }
        public DateTime Date { get; set; }
        public string PatientName { get; set; }
    }
}
