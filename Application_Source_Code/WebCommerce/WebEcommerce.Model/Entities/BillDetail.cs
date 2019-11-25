using System.Drawing;
using WebEcommerce.Infrastructure.Shared;

namespace WebEcommerce.Model.Entities
{
    public class BillDetail : DomainEntity<int>
    {
        public BillDetail()
        {
        }

        public BillDetail(int id, int billId, int productId, int quantity, decimal price, int colorId, int sizeId)
        {
            Id = id;
            BillId = billId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
            ColorId = colorId;
            SizeId = sizeId;
        }

        public BillDetail(int billId, int productId, int quantity, decimal price, int colorId, int sizeId)
        {
            BillId = billId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
            ColorId = colorId;
            SizeId = sizeId;
        }

        public int BillId { set; get; }
        public virtual Bill Bill { set; get; }

        public int ProductId { set; get; }
        public virtual Product Product { set; get; }

        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public int ColorId { get; set; }
        public virtual Color Color { set; get; }

        public int SizeId { get; set; }
        public virtual Size Size { set; get; }
    }
}