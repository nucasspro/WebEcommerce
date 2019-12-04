﻿using NUShop.Infrastructure.Shared;

namespace NUShop.Data.Entities
{
    public class ProductImage : DomainEntity<int>
    {
       

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string Path { get; set; }
        public string Caption { get; set; }
    }
}