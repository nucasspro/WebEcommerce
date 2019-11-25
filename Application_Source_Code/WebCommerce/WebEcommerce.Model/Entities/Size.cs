using System.Collections.Generic;
using WebEcommerce.Infrastructure.Shared;

namespace WebEcommerce.Model.Entities
{
    public class Size: DomainEntity<int>
    {
        public Size()
        {
            ProductQuantities = new List<ProductQuantity>();
            BillDetails = new List<BillDetail>();
        }
        public Size(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public virtual ICollection<ProductQuantity> ProductQuantities { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}