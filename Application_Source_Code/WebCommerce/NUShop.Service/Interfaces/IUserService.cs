using System;
using System.Collections.Generic;
using System.Text;
using NUShop.Utilities.DTOs;
using NUShop.ViewModel.ViewModels;
using System.Threading.Tasks;

namespace NUShop.Service.Interfaces
{
    public interface IUserService
    {
        List<AppUserViewModel> GetAll();
        PagedResult<AppUserViewModel> GetAllPaging(string keyword, int pageIndex, int pageSize);
        Task<AppUserViewModel> GetById(string id);
        Task<bool> AddAsync(AppUserViewModel appUserViewModel);
        Task UpdateAsync(AppUserViewModel appUserViewModel);
        Task DeleteAsync(string id);
    }
}
