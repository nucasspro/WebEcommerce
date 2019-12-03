using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEcommerce.Model.Enums;
using WebEcommerce.ViewModel.ViewModels;

namespace WebEcommerce.Service.Interfaces
{
    public interface IProductService
    {
        List<ProductViewModel> GetAll();
        ProductViewModel Add(ProductViewModel product);
        void Update(ProductViewModel productViewModel);
        void Delete(int id);
        ProductViewModel GetById(int id);
        void AddQuantity(int productId, List<ProductQuantityViewModel> quantities);
        List<ProductQuantityViewModel> GetQuantities(int productId);
        void AddImages(int productId, string[] images);
        List<ProductImageViewModel> GetImages(int productId);
        List<ProductViewModel> GetLastest(int top);
        List<ProductViewModel> GetHotProduct(int top);
        List<ProductViewModel> GetRelatedProducts(int id, int top);
        List<ProductViewModel> GetUpSellProducts(int top);
        bool CheckAvailability(int productId, int size, int color);
    }
}
