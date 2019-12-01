using System.Collections.Generic;
using WebEcommerce.Infrastructure.Shared;
using WebEcommerce.Model.Enums;
using WebEcommerce.Model.Interfaces;

namespace WebEcommerce.Data.Entities
{
    public class Bill : DomainEntity<int>, IDateTracking
    {
        public Bill()
        {
            BillDetails = new List<BillDetail>();
        }

        public Bill(string customerName, string customerAddress, string customerMobile, string customerMessage,
            BillStatus billStatus, PaymentMethod paymentMethod, Status status, int? customerId)
        {
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerMobile = customerMobile;
            CustomerMessage = customerMessage;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;
            Status = status;
            CustomerId = customerId;
        }

        public Bill(int id, string customerName, string customerAddress, string customerMobile, string customerMessage,
            BillStatus billStatus, PaymentMethod paymentMethod, Status status, int? customerId)
        {
            Id = id;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerMobile = customerMobile;
            CustomerMessage = customerMessage;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;
            Status = status;
            CustomerId = customerId;
        }

        public string CustomerName { set; get; }
        public string CustomerAddress { set; get; }
        public string CustomerMobile { set; get; }
        public string CustomerMessage { set; get; }
        public PaymentMethod PaymentMethod { set; get; }
        public BillStatus BillStatus { set; get; }
        public string DateCreated { set; get; }
        public string DateModified { set; get; }
        public Status Status { set; get; } = Status.Active;

        public int? CustomerId { set; get; }
        public virtual User User { set; get; }

        public virtual ICollection<BillDetail> BillDetails { set; get; }
    }
}