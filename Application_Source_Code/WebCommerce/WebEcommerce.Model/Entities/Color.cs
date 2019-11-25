using System.Collections.Generic;
using WebEcommerce.Infrastructure.Shared;

namespace WebEcommerce.Model.Entities
{
    public class Color: DomainEntity<int>
    {
        public Color()
        {
            ProductQuantities = new List<ProductQuantity>();
            BillDetails = new List<BillDetail>();
        }
        public Color(string name, string code)
        {
            Name = name;
            Code = code;
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public virtual ICollection<ProductQuantity> ProductQuantities { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }

    }
}