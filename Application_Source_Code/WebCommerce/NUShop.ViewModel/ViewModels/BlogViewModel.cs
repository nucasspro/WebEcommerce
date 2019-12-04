using NUShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUShop.ViewModel.ViewModels
{
    public class BlogViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Image { set; get; }
        public string Description { set; get; }
        public string Content { set; get; }
        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }
        public string Tags { get; set; }
        public List<BlogTagViewModel> BlogTags { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public Status Status { set; get; }
        public string SeoPageTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeywords { set; get; }
        public string SeoDescription { set; get; }
    }
}
