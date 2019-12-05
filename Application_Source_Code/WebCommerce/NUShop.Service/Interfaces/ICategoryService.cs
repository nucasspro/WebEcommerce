using NUShop.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUShop.Utilities.DTOs;

namespace NUShop.Service.EF.Interfaces
{
    public interface ICategoryService
    {
        CategoryViewModel Add(CategoryViewModel categoryViewModel);
        void Update(CategoryViewModel categoryViewModel);
        void Delete(int id);
        List<CategoryViewModel> GetAll();
        List<CategoryViewModel> GetAll(string keyword);
        PagedResult<CategoryViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);
        List<CategoryViewModel> GetAllByParentId(int parentId);
        CategoryViewModel GetById(int id);
        void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);
        void ReOrder(int sourceId, int targetId);
        List<CategoryViewModel> GetHomeCategories(int top);
    }
}
