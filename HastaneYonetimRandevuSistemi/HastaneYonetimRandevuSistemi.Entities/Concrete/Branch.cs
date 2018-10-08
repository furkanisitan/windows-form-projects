using System.Collections.Generic;
using DevFramework.Core.Entities;

namespace HastaneYonetimRandevuSistemi.Entities.Concrete
{
    public class Branch : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
