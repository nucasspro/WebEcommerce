using System.Collections.Generic;
using WebEcommerce.Infrastructure.Shared;
using WebEcommerce.Model.Enums;
using WebEcommerce.Model.Interfaces;

namespace WebEcommerce.Model.Entities
{
    public class Category: DomainEntity<int>, ISwitchable, IDateTracking 
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public Category(string name, string description, int? parentId, int? homeOrder,
            string image, bool? homeFlag, int sortOrder)
        {
            Name = name;
            Description = description;
            ParentId = parentId;
            HomeOrder = homeOrder;
            Image = image;
            HomeFlag = homeFlag;
            SortOrder = sortOrder;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? HomeOrder { get; set; }
        public string Image { get; set; }
        public bool? HomeFlag { get; set; }
        public string DateCreated { set; get; }
        public string DateModified { set; get; }
        public int SortOrder { set; get; }
        public Status Status { get; set; }
        public virtual ICollection<Product> Products { set; get; }
        
    }
}