using System;
using System.Collections.Generic;
using WebEcommerce.Model.Enums;

namespace WebEcommerce.ViewModel.ViewModels
{
    public class BillViewModel
    {
        public int Id { get; set; }
        public string CustomerName { set; get; }
        public string CustomerAddress { set; get; }
        public string CustomerMobile { set; get; }
        public string CustomerMessage { set; get; }
        public BillStatus BillStatus { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public Status Status { set; get; }
        public Guid? CustomerId { set; get; }
        public List<BillDetailViewModel> BillDetails { set; get; }
    }
}