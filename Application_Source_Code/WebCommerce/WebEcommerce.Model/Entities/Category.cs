using System.Collections.Generic;
using WebEcommerce.Infrastructure.Shared;
using WebEcommerce.Model.Enums;
using WebEcommerce.Model.Interfaces;

namespace WebEcommerce.Data.Entities
{
    public class Category : DomainEntity<int>, ISwitchable
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public Category(string name, string description, string image, int sortOrder)
        {
            Name = name;
            Description = description;
            Image = image;
            SortOrder = sortOrder;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int SortOrder { set; get; }
        public Status Status { get; set; }

        public virtual ICollection<Product> Products { set; get; }
    }
}