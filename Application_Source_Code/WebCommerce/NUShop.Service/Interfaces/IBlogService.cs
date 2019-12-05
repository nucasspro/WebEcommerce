using NUShop.Utilities.DTOs;
using NUShop.ViewModel.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUShop.Service.EF.Interfaces
{
    public interface IBlogService
    {
        List<BlogViewModel> GetAll();

        PagedResult<BlogViewModel> GetAllPaging(string keyword, int pageSize = 10, int pageIndex = 1);

        List<BlogViewModel> GetLastest(int top);

        List<BlogViewModel> GetHotProduct(int top);

        List<BlogViewModel> GetListPaging(string sort, out int totalRow, int pageIndex = 1, int pageSize = 10);

        List<BlogViewModel> GetList(string keyword);

        List<BlogViewModel> GetReatedBlogs(int id, int top);

        List<string> GetListByName(string name);

        BlogViewModel GetById(int id);

        List<TagViewModel> GetListTagByBlogTagId(int id);

        TagViewModel GetTag(string tagId);

        List<BlogViewModel> GetListByTag(string tagId, out int totalRow, int pageIndex = 1, int pagesize = 10);

        List<TagViewModel> GetListTag(string searchText);

        Task<BlogViewModel> AddAsync(BlogViewModel blogViewModel);

        Task UpdateAsync(BlogViewModel blogViewModel);

        List<BlogViewModel> Search(string keyword, string sort, out int totalRow, int pageIndex = 1, int pageSize = 10);

        Task IncreaseView(int id);

        Task DeleteAsync(int id);
    }
}