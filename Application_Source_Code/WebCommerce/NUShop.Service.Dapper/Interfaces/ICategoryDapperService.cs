using NUShop.Utilities.DTOs;
using NUShop.ViewModel.ViewModels;
using System.Collections.Generic;

namespace NUShop.Service.Dapper.Interfaces
{
    public interface ICategoryDapperService
    {
        CategoryViewModel Add(CategoryViewModel categoryViewModel);

        CategoryViewModel Update(CategoryViewModel categoryViewModel);

        bool Delete(int id);

        List<CategoryViewModel> GetAll();

        List<CategoryViewModel> GetAll(string keyword);

        //PagedResult<CategoryViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);

        //List<CategoryViewModel> GetAllByParentId(int parentId);

        CategoryViewModel GetById(int id);

        //void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);

        //void ReOrder(int sourceId, int targetId);

        //List<CategoryViewModel> GetHomeCategories(int top);
    }
}