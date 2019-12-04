using NUShop.Infrastructure.Shared;
using System.Collections.Generic;

namespace NUShop.Data.Entities
{
    public class Tag : DomainEntity<string>
    {
        public Tag()
        {
            ProductTags = new List<ProductTag>();
            BlogTags = new List<BlogTag>();
        }
        public Tag(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
        public virtual ICollection<BlogTag> BlogTags { get; set; }

    }
}