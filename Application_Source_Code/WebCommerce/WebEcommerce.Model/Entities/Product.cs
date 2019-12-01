﻿using System.Collections.Generic;
using WebEcommerce.Infrastructure.Shared;

namespace WebEcommerce.Data.Entities
{
    public class Product : DomainEntity<int>
    {
        public Product()
        {
            ProductQuantities = new List<ProductQuantity>();
            BillDetails = new List<BillDetail>();
        }

        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { set; get; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public decimal OriginalPrice { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }
        public string Tags { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<ProductQuantity> ProductQuantities { set; get; }
        public virtual ICollection<BillDetail> BillDetails { set; get; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }


        public string DateCreated { set; get; }
        public string DateModified { set; get; }
    }
}
