using NUShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUShop.ViewModel.ViewModels
{
    public class AnnouncementViewModel
    {
        public string Id { get; set; }
        public string Title { set; get; }
        public string Content { set; get; }
        public Status Status { set; get; }
        public Guid UserId { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
    }
}
