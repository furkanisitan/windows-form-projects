using System.Collections.Generic;

namespace HastaneYonetimRandevuSistemi.Entities.Concrete
{
    public class Patient : Person
    {
        public string PhoneNumber { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
