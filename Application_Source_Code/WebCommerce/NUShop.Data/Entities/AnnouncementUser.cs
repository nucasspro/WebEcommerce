using NUShop.Infrastructure.Shared;
using System;

namespace NUShop.Data.Entities
{
    public class AnnouncementUser : DomainEntity<int>
    {
        public AnnouncementUser()
        {
        }

        public AnnouncementUser(string announcementId, Guid userId, bool? hasRead)
        {
            AnnouncementId = announcementId;
            UserId = userId;
            HasRead = hasRead;
        }

        public string AnnouncementId { get; set; }
        public virtual Announcement Announcement { get; set; }

        public Guid UserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public bool? HasRead { get; set; }
    }
}