using DevFramework.Core.Entities;

namespace HastaneYonetimRandevuSistemi.Entities.Concrete
{
    public abstract class Person : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TrIdentityNo { get; set; }
        public string Password { get; set; }
    }
}
