using System;
using System.Collections.Generic;
using System.Text;
using WebEcommerce.Utility.DTOs;
using WebEcommerce.ViewModel.ViewModels;

namespace WebEcommerce.Service.Interfaces
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
    }
}
