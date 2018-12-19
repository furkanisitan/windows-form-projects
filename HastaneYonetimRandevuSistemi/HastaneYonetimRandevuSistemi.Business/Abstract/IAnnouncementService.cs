using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System.Collections.Generic;

namespace HastaneYonetimRandevuSistemi.Business.Abstract
{
    public interface IAnnouncementService
    {
        IEnumerable<Announcement> GetAll();
        Announcement GetById(int id);
        void Add(Announcement announcement);
        void DeleteById(int id);
    }
}
