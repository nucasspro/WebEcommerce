using NUShop.Data.Enums;
using NUShop.Data.Interfaces;
using NUShop.Infrastructure.Shared;
using System;
using System.Collections.Generic;

namespace NUShop.Data.Entities
{
    public class Blog : DomainEntity<int>, ISwitchable, IDateTracking, IHasSeoMetaData
    {
        public Blog()
        {
            BlogTags = new List<BlogTag>();
        }

        public Blog(string name, string thumbnailImage,
           string description, string content, bool? homeFlag, bool? hotFlag,
           string tags, Status status, string seoPageTitle,
           string seoAlias, string seoMetaKeyword,
           string seoMetaDescription)
        {
            Name = name;
            Image = thumbnailImage;
            Description = description;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            Tags = tags;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
        }

        public Blog(int id, string name, string thumbnailImage,
             string description, string content, bool? homeFlag, bool? hotFlag,
             string tags, Status status, string seoPageTitle,
             string seoAlias, string seoMetaKeyword,
             string seoMetaDescription)
        {
            Id = id;
            Name = name;
            Image = thumbnailImage;
            Description = description;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            Tags = tags;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
        }

        public string Name { set; get; }
        public string Image { set; get; }
        public string Description { set; get; }
        public string Content { set; get; }
        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }
        public string Tags { get; set; }
        public virtual ICollection<BlogTag> BlogTags { set; get; }
        public string SeoPageTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeywords { set; get; }
        public string SeoDescription { set; get; }
        public Status Status { set; get; }
        public string DateCreated { set; get; }
        public string DateModified { set; get; }
    }
}