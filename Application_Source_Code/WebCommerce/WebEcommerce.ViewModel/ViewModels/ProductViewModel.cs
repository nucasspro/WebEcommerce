using System;
using WebEcommerce.Model.Enums;

namespace WebEcommerce.ViewModel.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
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
        public CategoryViewModel Category { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public Status Status { set; get; }
    }
}