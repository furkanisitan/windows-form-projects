using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.ValidationRules.FluentValidation.Validators;
using HastaneYonetimRandevuSistemi.Core.Aspects.PostSharp.ValidationAspects;
using HastaneYonetimRandevuSistemi.DataAccess.Abstract;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HastaneYonetimRandevuSistemi.Business.Concrete.Managers
{
    class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public IEnumerable<Announcement> GetAll() =>
            _announcementDal.GetAll().OrderBy(x => x.Date);

        public Announcement GetById(int id) =>
            _announcementDal.Get(x => x.Id == id);

        [FluentValidationAspect(typeof(AnnouncementValidator))]
        public void Add(Announcement announcement)
        {
            announcement.Date = DateTime.Now;
            _announcementDal.Add(announcement);
        }

        public void DeleteById(int id) =>
            _announcementDal.Delete(GetById(id));
    }
}
