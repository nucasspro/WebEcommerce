using NUShop.Data.Enums;
using NUShop.Data.Interfaces;
using NUShop.Infrastructure.Shared;
using System;
using System.Collections.Generic;

namespace NUShop.Data.Entities
{
    public class Announcement : DomainEntity<string>, ISwitchable, IDateTracking
    {
        public Announcement()
        {
            AnnouncementUsers = new List<AnnouncementUser>();
        }

        public Announcement(string title, string content)
        {
            Title = title;
            Content = content;
            Status = Status.Active;
        }

        public string Title { set; get; }
        public string Content { set; get; }

        public Status Status { set; get; }
        public string DateCreated { set; get; }
        public string DateModified { set; get; }

        public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }
    }
}