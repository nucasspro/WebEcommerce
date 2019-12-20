using NUShop.Utilities.DTOs;
using NUShop.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUShop.Service.Dapper.Interfaces
{
    public interface IProductDapperService
    {
        List<ProductViewModel> GetAll();

        //PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int pageIndex, int pageSize);

        //ProductViewModel Add(ProductViewModel product);

        //void Update(ProductViewModel productViewModel);

        //void Delete(int id);

        ProductViewModel GetById(int id);

        ProductViewModel GetByName(string name);

        //void AddQuantity(int productId, List<ProductQuantityViewModel> quantities);

        //List<ProductQuantityViewModel> GetQuantities(int productId);

        //void AddImages(int productId, string[] images);

        //List<ProductImageViewModel> GetImages(int productId);

        //void AddWholePrice(int productId, List<WholePriceViewModel> wholePrices);

        //List<WholePriceViewModel> GetWholePrices(int productId);

        //List<ProductViewModel> GetLastest(int top);

        //List<ProductViewModel> GetHotProduct(int top);

        //List<ProductViewModel> GetRelatedProducts(int id, int top);

        //List<ProductViewModel> GetUpSellProducts(int top);

        //List<TagViewModel> GetProductTags(int productId);

        //bool CheckAvailability(int productId, int size, int color);

        //Task ImportExcelAsync(string filePath, int categoryId);
    }
}
