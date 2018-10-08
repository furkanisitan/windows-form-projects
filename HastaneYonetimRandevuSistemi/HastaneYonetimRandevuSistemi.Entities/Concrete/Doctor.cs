using System.Collections.Generic;

namespace HastaneYonetimRandevuSistemi.Entities.Concrete
{
    public class Doctor : Person
    {
        public int BranchId { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
