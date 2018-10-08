using DevFramework.Core.Entities;
using System;

namespace HastaneYonetimRandevuSistemi.Entities.Concrete
{
    public class Announcement : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
