using NUShop.Infrastructure.Shared;

namespace NUShop.Data.Entities
{
    public class ProductTag : DomainEntity<int>
    {
       
        public int ProductId { get; set; }
        public virtual Product Product { set; get; }

        public string TagId { set; get; }
        public virtual Tag Tag { set; get; }
    }
}